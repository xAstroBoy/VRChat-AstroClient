using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.Text.RegularExpressions;
using UnityEngine;

namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using VRC.Udon;

    internal static class UdonDumper
    {
        internal static void Dump_All_UdonBehaviours_Programs()
        {
            MelonCoroutines.Start(Internal_Dump_All_UdonBehaviours_Programs());
        }

        internal static void Dump_All_UdonBehaviours(bool IncludeSymbolsAndInternals = false)
        {
            internal_Dump_All_UdonBehaviours(IncludeSymbolsAndInternals);
        }

        internal static void Dump_AllCustomEventKeysDuplicates()
        {
            var duplicatelist = new List<string>();
            for (var index = 0; index < WorldUtils.UdonScripts.Length; index++)
            {
                var udon = WorldUtils.UdonScripts[index];
                var keys = udon.Get_EventKeys();
                if (keys != null)
                {
                    for (int i = 0; i < keys.Length; i++)
                    {
                        var key = keys[i];
                        if (key.StartsWith("_"))
                        {
                            if (UdonCustomEventsLists.VRChatUdonSDKEvents.Contains(key))
                            {
                                continue;
                            }
                            duplicatelist.Add(key);
                        }

                    }
                }
            }

            var entries = from x in duplicatelist
                          group x by x into g
                          let count = g.Count()
                          orderby count descending
                          select new { Value = g.Key, Count = count };
            if (duplicatelist.Count != 0)
            {

                foreach (var duplicate in entries)
                {
                    if (duplicate.Count != 1) // ignore if not higher than 1
                    {
                        Log.Debug("Duplicate Value: " + duplicate.Value + " Count: " + duplicate.Count);
                    }

                }
            }
        }
        internal static void UnboxUdonToConsole(UdonBehaviour udonnode)
        {
            if (udonnode != null)
            {
                StringBuilder builder = new StringBuilder();

                var raw = udonnode.ToRawUdonBehaviour();
                if (raw != null)
                {
                    Console.Clear();
                    builder.AppendLine($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..");
                    builder.AppendLine();
                    foreach (var symbol in raw.UdonSymbolTable.GetSymbols())
                    {
                        if (symbol != null)
                        {
                            var address = raw.UdonSymbolTable.GetAddressFromSymbol(symbol);
                            Il2CppSystem.Object UnboxVariable = null;
                            if(!raw.isFakeUdon)
                            {
                                UnboxVariable = raw.UdonHeap.GetHeapVariable(address);
                            }
                            else
                            {
                                UnboxVariable = raw.FakeUdonHeap.GetHeapVariable(address);
                            }
                            if (UnboxVariable != null)
                            {
                                var Il2CppType = UnboxVariable.GetIl2CppType();
                                string unpackedsymbol;
                                if(!raw.isFakeUdon)
                                {
                                     unpackedsymbol = UdonHeapUnboxerUtils.UnboxAsString(raw.FakeUdonHeap, address, UnboxVariable);
                                }
                                else
                                {
                                     unpackedsymbol = UdonHeapUnboxerUtils.UnboxAsString(raw.UdonHeap, address, UnboxVariable);
                                }
                                builder.AppendLine($"[Udon Unboxer] : ACTION {udonnode.name} : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}");
                            }
                        }
                    }
                    var resultString = Regex.Replace(builder.ToString(), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline); // This will fix and remove Useless empty lines. (but from file it can be kept)
                    Log.Write(resultString, System.Drawing.Color.Gold);
                    builder.Clear();
                }
            }
        }


        private static string GetAllUdonEventKeys(UdonBehaviour udon)
        {
            if (udon != null)
            {
                var eventKeys = udon.Get_EventKeys();
                if (eventKeys == null) return null;
                StringBuilder builder = new StringBuilder();
                for (int Key = 0; Key < eventKeys.Length; Key++)
                {
                    var subaction = eventKeys[Key];
                    builder.AppendLine($"Key : {subaction}");
                }
                return builder.ToString();
            }
            return null;
        }

        private static IEnumerator Internal_Dump_All_UdonBehaviours_Programs()
        {
            var udonevents = WorldUtils.UdonScripts;
            if (udonevents == null) { yield return null; }
            if (udonevents.Count() == 0) { yield return null; }

            for (int i = 0; i < udonevents.Length; i++)
            {
                udonevents[i].DumpUdonProgramCode();
            }
            yield return null;
        }

        internal static string Get_All_SymbolsAndInternals_Of_UdonBehaviour(UdonBehaviour udonnode)
        {
            if (udonnode != null)
            {
                var unpackedudon = udonnode.ToRawUdonBehaviour();
                if (unpackedudon != null)
                {
                    StringBuilder builder = new StringBuilder();
                    _ = builder.AppendLine($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..");
                    foreach (var symbol in unpackedudon.UdonSymbolTable.GetSymbols())
                    {
                        if (symbol != null)
                        {
                            var address = unpackedudon.UdonSymbolTable.GetAddressFromSymbol(symbol);
                            var UnboxVariable = unpackedudon.UdonHeap.GetHeapVariable(address);
                            if (UnboxVariable != null)
                            {
                                var Il2CppType = UnboxVariable.GetIl2CppType();
                                var unpackedsymbol = UdonHeapUnboxerUtils.UnboxAsString(unpackedudon.UdonHeap, address, UnboxVariable);
                                _ = builder.AppendLine($"[Udon Unboxer] : ACTION {udonnode.name} : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}");
                            }
                        }
                    }
                    return builder.ToString();
                }
            }
            return null;
        }

        private static void internal_Dump_All_UdonBehaviours(bool IncludeSymbolsAndInternals)
        {
            StringBuilder Output = new StringBuilder();
            var worldname = WorldUtils.WorldName;
            var UdonBehaviours = Resources.FindObjectsOfTypeAll<UdonBehaviour>();
            string path = Path.Combine(Environment.CurrentDirectory, @"AstroClient\Dumper");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = null;

            if (IncludeSymbolsAndInternals)
            {
                filename = "Udon_Dump_Internals_" + worldname + ".log";
            }
            else
            {
                filename = "Udon_Dump_" + worldname + ".log";
            }
            Output.AppendLine($"Dumping all Udon Events in World : {worldname}");
            foreach(var udon in UdonBehaviours)
            {
                try
                {
                    Output.AppendLine($"ACTION: {udon.name}");
                    var Keys = GetAllUdonEventKeys(udon);
                    if (Keys.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        Output.AppendLine(Keys);
                    }
                    else
                    {
                        Output.AppendLine("Failed Unpacking Keys");
                    }
                    if (IncludeSymbolsAndInternals)
                    {
                        var internals = Get_All_SymbolsAndInternals_Of_UdonBehaviour(udon);
                        if (internals.IsNotNullOrEmptyOrWhiteSpace())
                        {
                            Output.AppendLine(internals);
                        }
                        else
                        {
                            Output.AppendLine("Failed Unpacking Internals (most likely empty)");
                        }
                    }
                }
                catch{}
                Output.AppendLine();
            }

            var fullpath = Path.Combine(path, filename);
            File.WriteAllText(fullpath, Output.ToString()) ;
            Process.Start(fullpath);
            if (IncludeSymbolsAndInternals)
            {
                DumpUdonUnsupportedTypes();
            }
            Output.Clear();
        }

        internal static void DumpUdonUnsupportedTypes()
        {
            if (UdonHeapUnboxerUtils.UnsupportedTypes.Count() != 0)
            {
                Log.Warn($"[Udon Unboxer] : Found {UdonHeapUnboxerUtils.UnsupportedTypes.Count} Unsupported Types. \n Please send the Generated File Unsupported_UdonTypes.txt to the developer for further Udon Unpacking support!");
                StringBuilder builder = new StringBuilder();

                foreach (var value in UdonHeapUnboxerUtils.UnsupportedTypes)
                {
                    builder.AppendLine(value);
                }
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"AstroClient\Dumper\Unsupported_UdonTypes.txt"), builder.ToString());
            }
        }




        internal static void GenerateGettersReaders(UdonBehaviour node)
        {
            UdonVariableGenerator.HeapGetterGenerator(node.ToRawUdonBehaviour());
        }

    }
}