namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Extensions;
    using UnhollowerBaseLib.Runtime;

    internal class UdonVariableGenerator
    {

        private static string CurrentBehaviourTemplateName { get; } = "RenameMePlease";

        // Use this to fill a component and make a reader out of it!

        // THIS WILL GENERATE ONLY GETTER PROPERTIES, (if you need to edit it, add A setter!)
        private static List<string> initializeUdonVarList { get; set;  } = new List<string>();
        private static List<string> CleanupSystemUdonVarList { get; set; } = new List<string>();

        private static List<string> RegionPrivateVars { get; set; } = new List<string>();

        internal static void HeapGetterGenerator(RawUdonBehaviour behaviour)
        {
            initializeUdonVarList.Clear();
            CleanupSystemUdonVarList.Clear();
            RegionPrivateVars.Clear();
            if (behaviour != null)
            {
                var builder = new StringBuilder();

                builder.AppendLine("        // TODO: Bind UdonBehaviour with this section");
                builder.AppendLine("        // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!");
                builder.AppendLine("         private RawUdonBehaviour "+ CurrentBehaviourTemplateName +" {[HideFromIl2Cpp] get; [HideFromIl2Cpp] set;} =  null;");

                builder.AppendLine($"       #region Getter / Setters UdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");

                foreach (var symbol in behaviour.IUdonSymbolTable.GetSymbols())
                {
                    if (symbol != null)
                    {
                        var address = behaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                        var UnboxVariable = behaviour.IUdonHeap.GetHeapVariable(address);
                        if (UnboxVariable != null)
                        {
                            builder.AppendLine(GetterBuilder(CurrentBehaviourTemplateName, symbol, UnboxVariable));
                        }
                    }
                }
                builder.AppendLine($"     #endregion Getter / Setters UdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");

                builder.AppendLine(GenerateMethod(initializeUdonVarList, $"Initialize_{CurrentBehaviourTemplateName}"));
                builder.AppendLine(GenerateMethod(initializeUdonVarList, $"Cleanup_{CurrentBehaviourTemplateName}"));

                builder.AppendLine($"       #region  UdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");

                foreach (var item in RegionPrivateVars)
                {
                    builder.AppendLine(item);
                }

                builder.AppendLine($"     #endregion UdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");


                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"AstroClient\GeneratedPropertyReader.cs"), builder.ToString());
                ModConsole.DebugLog("Generated Reader File!");
                initializeUdonVarList.Clear();
                CleanupSystemUdonVarList.Clear();
                RegionPrivateVars.Clear();

            }
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
                default: return name;
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

                default: return false;
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

            var NullVariableInstance = $"private UdonVariable<{CorrectedType.Replace("?", String.Empty)}>  {PrivateVar} {{  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; }} = null;";
            if (!RegionPrivateVars.Contains(NullVariableInstance))
            {
                RegionPrivateVars.Add(NullVariableInstance);
            }

            var InitializationInstance = $"{PrivateVar} = new UdonVariable<{CorrectedType.Replace("?", String.Empty)}>({templatename},  \"{Symbol}\");";
            if (!initializeUdonVarList.Contains(InitializationInstance))
            {
                initializeUdonVarList.Add(InitializationInstance);
            }


            var CleanupVariableInstance = $"{PrivateVar} = null;";
            if (!CleanupSystemUdonVarList.Contains(CleanupVariableInstance))
            {
                CleanupSystemUdonVarList.Add(CleanupVariableInstance);
            }


            #endregion


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
if(DoIAddNullChar)           getter.AppendLine("                if (value.HasValue)                                                                                                                                           ");
if(DoIAddNullChar)           getter.AppendLine("                {                                                                                                                                                             ");
                             getter.AppendLine($"                    if ({PrivateVar} != null)                                                                                                                                ");
                             getter.AppendLine("                    {                                                                                                                                                         ");
if(DoIAddNullChar)           getter.AppendLine($"                        {PrivateVar}.Value = value.Value;                                                                                                                    ");
else                         getter.AppendLine($"                        {PrivateVar}.Value = value;                                                                                                                    ");
                             getter.AppendLine("                    }                                                                                                                                                         ");
if(DoIAddNullChar)           getter.AppendLine("                }                                                                                                                                                             ");
                             getter.AppendLine("            }                                                                                                                                                                 ");
                             getter.AppendLine("        }                                                                                                                                                                     ");
                             getter.AppendLine("                                                                                                                                                                              ");


            return getter.ToString();
        }




        

        


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


    }
    
}
