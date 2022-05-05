using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using System.Diagnostics;
using System.ServiceModel.Configuration;
using VRC.Udon.Common.Interfaces;

namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal class UdonVariableGenerator
    {
        private static string CurrentBehaviourTemplateName { get; } = "RenameMePlease";

        // Use this to fill a component and make a reader out of it!

        // THIS WILL GENERATE ONLY GETTER PROPERTIES, (if you need to edit it, add A setter!)
        private static List<string> initializeUdonVarList { get; set; } = new List<string>();

        private static List<string> CleanupSystemUdonVarList { get; set; } = new List<string>();

        private static List<string> RegionPrivateVars { get; set; } = new List<string>();
        private static List<string> UsedSymbols { get; set; } = new List<string>();

        private static List<string> GettersSettersGen { get; set; } = new List<string>();



        internal static void HeapGetterGenerator(RawUdonBehaviour behaviour)
        {
            ClearLists();
            if (behaviour != null)
            {
                var builder = new StringBuilder();

                builder.AppendLine("        // TODO: Bind UdonBehaviour with this section");
                builder.AppendLine("        // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!");
                builder.AppendLine($"       // TODO: READER FOR UDONBEHAVIOUR {behaviour.udonBehaviour.name}!");

                builder.AppendLine("         private RawUdonBehaviour " + CurrentBehaviourTemplateName + " {[HideFromIl2Cpp] get; [HideFromIl2Cpp] set;} =  null;");

                foreach (var symbol in behaviour.IUdonSymbolTable.GetSymbols())
                {
                    if (symbol != null)
                    {
                        var address = behaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                        var UnboxVariable = behaviour.IUdonHeap.GetHeapVariable(address);
                        if (UnboxVariable != null)
                        {
                            if (UnboxVariable.GetIl2CppType().FullName == "System.RuntimeType" || UnboxVariable.GetIl2CppType().FullName == "System.RuntimeType[]")
                            {
                                if (!UsedSymbols.Contains(symbol))
                                {
                                    UsedSymbols.Add(symbol);
                                }
                                continue;
                            }
                            if (!UsedSymbols.Contains(symbol))
                            {
                                GenerateReaderVariable(CurrentBehaviourTemplateName, symbol, UnboxVariable); // Let it generate first
                            }
                        }
                    }
                }

                builder.AppendLine(GenerateMethod(initializeUdonVarList, $"Initialize_{CurrentBehaviourTemplateName}"));
                builder.AppendLine(GenerateMethod(CleanupSystemUdonVarList, $"Cleanup_{CurrentBehaviourTemplateName}"));

                builder.AppendLine($"       #region Getter / Setters AstroUdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");

                foreach (var item in GettersSettersGen)
                {
                    builder.AppendLine(item);
                }

                builder.AppendLine($"     #endregion Getter / Setters AstroUdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");

                builder.AppendLine($"       #region  AstroUdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");

                foreach (var item in RegionPrivateVars)
                {
                    builder.AppendLine(item);
                }

                builder.AppendLine($"     #endregion AstroUdonVariables  of {CurrentBehaviourTemplateName}                                                                                                                                        ");
                var path = Path.Combine(Environment.CurrentDirectory, @$"AstroClient\GeneratedReaders\{WorldUtils.WorldName}");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var completepath = Path.Combine(path, $"{behaviour.udonBehaviour.name}.cs");

                File.WriteAllText(completepath, builder.ToString());
                Process.Start(completepath);
                Log.Debug($"Generated Reader File for {behaviour.udonBehaviour.name}!");
                ClearLists();
            }
        }

        private static void ClearLists()
        {
            initializeUdonVarList.Clear();
            CleanupSystemUdonVarList.Clear();
            RegionPrivateVars.Clear();
            GettersSettersGen.Clear();
            UsedSymbols.Clear();
        }

        private static string CorrectType(string name)
        {
            switch (name)
            {
                case "System.String": return "string";
                case "System.String[]": return "string[]";
                case "System.UInt32": return "uint?";
                case "System.UInt32[]": return "uint[]";
                case "System.Int32": return "int?";
                case "System.Int32[]": return "int[]";
                case "System.Int64": return "long?";
                case "System.Int64[]": return "long[]";
                case "System.Char": return "char?";
                case "System.Char[]": return "char[]";
                case "System.Single": return "float?";
                case "System.Single[]": return "float[]";
                case "System.Boolean": return "bool?";
                case "System.Boolean[]": return "bool[]";
                case "System.Byte": return "byte?";
                case "System.Byte[]": return "byte[]";
                case "System.UInt16": return "ushort?";
                case "System.UInt16[]": return "ushort[]";
                case "System.Double": return "double?";
                case "System.Double[]": return "double[]";
                case "UnityEngine.Vector3": return "UnityEngine.Vector3?";
                case "UnityEngine.Quaternion": return "UnityEngine.Quaternion?";
                case "UnityEngine.Color": return "UnityEngine.Color?";
                case "VRC.Udon.Common.Interfaces.NetworkEventTarget": return "VRC.Udon.Common.Interfaces.NetworkEventTarget?";
                case "VRC.Udon.Common.Enums.EventTiming": return "VRC.Udon.Common.Enums.EventTiming?";
                case "UnityEngine.Rect": return "UnityEngine.Rect?";

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
                case "System.UInt32":
                case "System.Int32":
                case "System.Int64":
                case "System.Char":
                case "System.Single":
                case "System.Boolean":
                case "System.Byte":
                case "System.UInt16":
                case "System.Double":
                case "UnityEngine.Vector3":
                case "UnityEngine.Quaternion":
                case "UnityEngine.Color":
                case "VRC.Udon.Common.Interfaces.NetworkEventTarget":
                case "VRC.Udon.Common.Enums.EventTiming":
                case "UnityEngine.Rect":    
                    return true;

                default:
                    if (name.Contains("+"))
                    {
                        return true;
                    }
                    return false;
            }
        }



        internal static void GenerateReaderVariable(string templatename, string Symbol, Il2CppSystem.Object obj)
        {
            UsedSymbols.Add(Symbol);
            var getter = new StringBuilder();
            var ActualType = obj.GetIl2CppType().FullName;


            var CorrectedType = CorrectType(ActualType);
            if (CorrectedType.Contains("System.UInt32"))
            {
                CorrectedType = CorrectedType.Replace("System.UInt32", "uint"); // idk why, but there's this annoying bug where it fails to detect System.UInt32 and replace it with uint..
            }
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
            if (DoIAddNullChar)
                getter.AppendLine("                if (value.HasValue)                                                                                                                                           ");
            if (DoIAddNullChar)
                getter.AppendLine("                {                                                                                                                                                             ");
            getter.AppendLine($"                    if ({PrivateVar} != null)                                                                                                                                ");
            getter.AppendLine("                    {                                                                                                                                                         ");
            if (DoIAddNullChar)
                getter.AppendLine($"                        {PrivateVar}.Value = value.Value;                                                                                                                    ");
            else
                getter.AppendLine($"                        {PrivateVar}.Value = value;                                                                                                                    ");
            getter.AppendLine("                    }                                                                                                                                                         ");
            if (DoIAddNullChar)
                getter.AppendLine("                }                                                                                                                                                             ");
            getter.AppendLine("            }                                                                                                                                                                 ");
            getter.AppendLine("        }                                                                                                                                                                     ");
            getter.AppendLine("                                                                                                                                                                              ");

            var result = getter.ToString();
            if (!GettersSettersGen.Contains(result))
            {
                GettersSettersGen.Add(result);
            }
        }

        internal static string GenerateMethod(List<string> content, string methodname)
        {
            var Result = new StringBuilder();

            Result.AppendLine();
            Result.AppendLine($"private void {methodname}()");
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