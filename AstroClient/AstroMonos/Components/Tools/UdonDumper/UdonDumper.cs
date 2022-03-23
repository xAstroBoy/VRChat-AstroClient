using AstroClient.xAstroBoy.Extensions;

namespace AstroClient.AstroMonos.Components.Tools.UdonDumper
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using CustomClasses;
    using Il2CppSystem;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;
    using String = System.String;

    [RegisterComponent]
    public class UdonDumper : AstroMonoBehaviour
    {
        private Il2CppSystem.Collections.Generic.List<Object> AntiGarbageCollection = new();

        public UdonDumper(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private static List<string> initializeUdonVarList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new List<string>();
        private static List<string> CleanupSystemUdonVarList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new List<string>();

        private static List<string> RegionPrivateVars { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new List<string>();

        internal System.Collections.Generic.List<UdonBehaviour_Cached> TargetedUdons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new System.Collections.Generic.List<UdonBehaviour_Cached>();

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
            {
                foreach (var item in gameObject.transform.Get_UdonBehaviours())
                {
                    if (item.gameObject.name == "Player Hitbox")
                    {
                        var obj = item.FindUdonEvent("_GetHeight");
                        if (obj != null)
                        {
                            if (!TargetedUdons.Contains(obj))
                            {
                                ModConsole.DebugLog($"Found Behaviour with name {obj.gameObject.name}, having Event _GetHeight");
                                TargetedUdons.Add(obj);
                            }
                        }
                    }
                }
                GenerateFile();
            }
            else
            {
                Destroy(this);
            }
        }

        internal System.Collections.Generic.List<UdonSymbolsAndTypes> AllSymbolsAndTypes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new System.Collections.Generic.List<UdonSymbolsAndTypes>();

        [HideFromIl2Cpp]
        private bool ContainsSymbol(string Symbol)
        {
            if (AllSymbolsAndTypes.Count != 0)
            {
                foreach (var item in AllSymbolsAndTypes)
                {
                    if (item.Symbol.Equals(Symbol))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [HideFromIl2Cpp]
        internal static string GenerateMethod(List<string> content, string methodname)
        {
            var Result = new StringBuilder();

            Result.AppendLine();
            Result.AppendLine($"internal void {methodname}()");
            Result.AppendLine("{");
            foreach (var item in content)
            {
                Result.AppendLine(item);
            }
            Result.AppendLine("}");

            return Result.ToString();
        }

        private static string CorrectType(string name)
        {
            switch (name)
            {
                case UdonTypes_String.System_String: return "string";
                case UdonTypes_String.System_String_Array: return "string[]";
                case UdonTypes_String.System_Uint32: return "uint?";
                case UdonTypes_String.System_Uint32_Array: return "uint[]";
                case UdonTypes_String.System_Int32: return "int?";
                case UdonTypes_String.System_Int32_Array: return "int[]";
                case UdonTypes_String.System_Int64: return "long?";
                case UdonTypes_String.System_Int64_Array: return "long[]";
                case UdonTypes_String.System_Char: return "char?";
                case UdonTypes_String.System_Char_Array: return "char[]";
                case UdonTypes_String.System_Single: return "float?";
                case UdonTypes_String.System_Single_Array: return "float[]";
                case UdonTypes_String.System_Boolean: return "bool?";
                case UdonTypes_String.System_Boolean_Array: return "bool[]";
                case UdonTypes_String.System_Byte: return "byte?";
                case UdonTypes_String.System_Byte_Array: return "byte[]";
                case UdonTypes_String.System_UInt16: return "ushort?";
                case UdonTypes_String.System_UInt16_Array: return "ushort[]";
                case UdonTypes_String.System_Double: return "double?";
                case UdonTypes_String.System_Double_Array: return "double[]";
                case UdonTypes_String.UnityEngine_Vector3: return "UnityEngine.Vector3?";
                case UdonTypes_String.UnityEngine_Quaternion: return "UnityEngine.Quaternion?";
                case UdonTypes_String.UnityEngine_Color: return "UnityEngine.Color?";
                case UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget: return "VRC.Udon.Common.Interfaces.NetworkEventTarget?";
                default:
                    if (name.Contains("+"))
                    {
                        return name.Replace("+", ".") + "?".RemoveWhitespace(); //More likely a enum, so let's add ? as well to make it nullable.
                    }
                    return name;
            }

        }
        private static bool DoIAddNullCharBool(string name)
        {
            switch (name)
            {
                case UdonTypes_String.System_Uint32:
                case UdonTypes_String.System_Int32:
                case UdonTypes_String.System_Int64:
                case UdonTypes_String.System_Char:
                case UdonTypes_String.System_Single:
                case UdonTypes_String.System_Boolean:
                case UdonTypes_String.System_Byte:
                case UdonTypes_String.System_UInt16:
                case UdonTypes_String.System_Double:
                case UdonTypes_String.UnityEngine_Vector3:
                case UdonTypes_String.UnityEngine_Quaternion:
                case UdonTypes_String.UnityEngine_Color:
                case UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget:
                    return true;

                default:
                    if (name.Contains("+"))
                    {
                        return true;
                    }
                    return false;
            }
        }



            internal static string GetterBuilder(string templatename, string Symbol, Il2CppSystem.Object obj)
        {
            var getter = new StringBuilder();
            var ActualType = obj.GetIl2CppType().FullName;
            var CorrectedType = CorrectType(ActualType);
            var PrivateVar = $"Private_{Symbol}";
            var DoIAddNullChar = DoIAddNullCharBool(ActualType);

            #region Methods Filler (Creates Initiator, Variable and Cleanup content)

            var NullVariableInstance = $"private AstroUdonVariable<{CorrectedType.Replace("?", String.Empty)}>  {PrivateVar} {{  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; }} = null;";
            if (!RegionPrivateVars.Contains(NullVariableInstance))
            {
                RegionPrivateVars.Add(NullVariableInstance);
            }

            var InitializationInstance = $"{PrivateVar} = new AstroUdonVariable<{CorrectedType.Replace("?", String.Empty)}>({templatename},  \"{Symbol}\");";
            if (!initializeUdonVarList.Contains(InitializationInstance))
            {
                initializeUdonVarList.Add(InitializationInstance);
            }

            var CleanupVariableInstance = $"{PrivateVar} = null;";
            if (!CleanupSystemUdonVarList.Contains(CleanupVariableInstance))
            {
                CleanupSystemUdonVarList.Add(CleanupVariableInstance);
            }

            #endregion Methods Filler (Creates Initiator, Variable and Cleanup content)

            // Then Generate the getter/setter to make life easier
            getter.AppendLine("                                                                                                                                                                              ");
            getter.AppendLine($"        internal {CorrectedType} {Symbol}                                                                                                                                    ");
            getter.AppendLine("        {                                                                                                                                                                     ");
            getter.AppendLine("            [HideFromIl2Cpp]                                                                                                                                                  ");
            getter.AppendLine("            get                                                                                                                                                               ");
            getter.AppendLine("            {                                                                                                                                                                 ");
            getter.AppendLine($"                if ({PrivateVar} != null)                                                                                                                                    ");
            getter.AppendLine("                {                                                                                                                                                             ");
            getter.AppendLine($"                    return {PrivateVar}.Value;                                                                                                                               ");
            getter.AppendLine("                }                                                                                                                                                             ");
            getter.AppendLine("                                                                                                                                                                              ");
            getter.AppendLine("                return null;                                                                                                                                                  ");
            getter.AppendLine("            }                                                                                                                                                                 ");
            getter.AppendLine("            [HideFromIl2Cpp]                                                                                                                                                  ");
            getter.AppendLine("            set                                                                                                                                                               ");
            getter.AppendLine("            {                                                                                                                                                                 ");
            if (DoIAddNullChar) getter.AppendLine("                if (value.HasValue)                                                                                                                                           ");
            if (DoIAddNullChar) getter.AppendLine("                {                                                                                                                                                             ");
            getter.AppendLine($"                    if ({PrivateVar} != null)                                                                                                                                ");
            getter.AppendLine("                    {                                                                                                                                                         ");
            if (DoIAddNullChar) getter.AppendLine($"                        {PrivateVar}.Value = value.Value;                                                                                                                    ");
            else getter.AppendLine($"                        {PrivateVar}.Value = value;                                                                                                                    ");
            getter.AppendLine("                    }                                                                                                                                                         ");
            if (DoIAddNullChar) getter.AppendLine("                }                                                                                                                                                             ");
            getter.AppendLine("            }                                                                                                                                                                 ");
            getter.AppendLine("        }                                                                                                                                                                     ");
            getter.AppendLine("                                                                                                                                                                              ");

            return getter.ToString();
        }

        [HideFromIl2Cpp]
        internal void GenerateFile()
        {
            foreach (var behaviour in TargetedUdons)
            {
                if (behaviour != null)
                {
                    if (behaviour.RawItem != null)
                    {
                        foreach (var symbol in behaviour.RawItem.IUdonSymbolTable.GetSymbols())
                        {
                            if (symbol != null)
                            {
                                var address = behaviour.RawItem.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                                var UnboxVariable = behaviour.RawItem.IUdonHeap.GetHeapVariable(address);
                                if (UnboxVariable != null)
                                {
                                    if (!ContainsSymbol(symbol))
                                    {
                                        var entry = new UdonSymbolsAndTypes(symbol, UnboxVariable);
                                        AllSymbolsAndTypes.Add(entry);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var builder = new StringBuilder();

            string GeneratedBehaviour = "RenameMePlease";
            builder.AppendLine("        // TODO: Bind UdonBehaviour with this section");
            builder.AppendLine("        // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!");
            builder.AppendLine("         private RawUdonBehaviour " + GeneratedBehaviour + " {[HideFromIl2Cpp] get; [HideFromIl2Cpp] set;} =  null;");

            builder.AppendLine($"       #region Getter / Setters AstroUdonVariables  of {GeneratedBehaviour}                                                                                                                                        ");

            foreach (var item in AllSymbolsAndTypes)
            {
                if (item != null)
                {
                    if(item.Type.GetIl2CppType().FullName == UdonTypes_String.System_RuntimeType) continue;
                    if (item.Type.GetIl2CppType().FullName == UdonTypes_String.System_RuntimeType_Array) continue;

                    builder.AppendLine(GetterBuilder(GeneratedBehaviour, item.Symbol, item.Type));
                }
            }

            builder.AppendLine($"     #endregion Getter / Setters AstroUdonVariables  of {GeneratedBehaviour}                                                                                                                                        ");

            builder.AppendLine(GenerateMethod(initializeUdonVarList, $"Initialize_{GeneratedBehaviour}"));
            builder.AppendLine(GenerateMethod(CleanupSystemUdonVarList, $"Cleanup_{GeneratedBehaviour}"));

            builder.AppendLine($"       #region  AstroUdonVariables  of {GeneratedBehaviour}                                                                                                                                        ");

            foreach (var item in RegionPrivateVars)
            {
                builder.AppendLine(item);
            }

            builder.AppendLine($"     #endregion AstroUdonVariables  of {GeneratedBehaviour}                                                                                                                                        ");

            var path = Path.Combine(Environment.CurrentDirectory, @"AstroClient\Generated.cs");
            File.WriteAllText(path, builder.ToString());
            ModConsole.DebugLog("Generated Reader File!");
            Process.Start(path);
        }

        // Use this for initialization
    }
}