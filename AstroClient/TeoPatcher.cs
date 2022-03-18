namespace AstroClient
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using System.Diagnostics;
    using MelonLoader;
    using Mono.CSharp;
    using UnityEngine;
    using Attribute = System.Attribute;
    using Color = System.Drawing.Color;

    internal class TeoPatcher : AstroEvents
    {
        internal override void ExecutePriorityPatches()
        {
            MelonCoroutines.Start(TeoPatcherRoutine());
        }

        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(TeoPatcher).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        private static Assembly _TeoClientAssembly = null;
        private static Assembly TeoClientAssembly
        {
            get
            {
                if (_TeoClientAssembly == null)
                {
                    Assembly[] LoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                    if (LoadedAssemblies != null)
                    {
                        foreach (var item in LoadedAssemblies)
                        {
                            var CopyrightAttrib = GetAssemblyAttribute<AssemblyCopyrightAttribute>(item);
                            if (CopyrightAttrib != null)
                            {
                                if (CopyrightAttrib.Copyright.Equals("Created by Teo"))
                                {
                                    var titleattrib = GetAssemblyAttribute<AssemblyTitleAttribute>(item);
                                    if (titleattrib != null)
                                    {
                                        if (titleattrib.Title.Equals("Client"))
                                        {
                                            // Possible match.
                                            ModConsole.DebugLog($"Found TeoClient assembly! : {item.FullName}", Color.Chartreuse);
                                            return _TeoClientAssembly = item;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                return _TeoClientAssembly;
            }
        }

        private static BindingFlags SelectedFlags => BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;

        private static bool CancelEvent()
        {
            return false; // Anti-debugger hopefully dies.
        }
        private static bool ReturnTrue(bool __result)
        {
            __result = true;
            return false;
        }
        private static bool CancelAndReturnTrue(bool __result)
        {
            __result = true;
            return false; // Anti-debugger hopefully dies.
        }

        internal static IEnumerator TeoPatcherRoutine()
        {

            while (TeoClientAssembly == null) yield return null;
            ModConsole.DebugLog("TeoClient has Been Loaded, Starting Patcher!");
            ModConsole.DebugLog("Blocking Process Killers since teo is paranoid.");

            foreach (var method in typeof(Process).GetMethods())
            {
                if (!method.Name.Contains("Kill")) continue;
                new AstroPatch(method, GetPatch(nameof(CancelEvent)), null, null, null, null, false);
            }
            foreach (var method in typeof(Application).GetMethods())
            {
                if (!method.Name.Contains("Quit")) continue;
                new AstroPatch(method, GetPatch(nameof(CancelEvent)), null, null, null, null, false);
            }
            foreach (var method in typeof(Application).GetMethods())
            {
                if (!method.Name.Contains("ForceCrash")) continue;
                new AstroPatch(method, GetPatch(nameof(CancelEvent)), null, null, null, null, false);
            }
            foreach (var method in typeof(Environment).GetMethods())
            {
                if (!method.Name.Contains("Exit")) continue;
                new AstroPatch(method, GetPatch(nameof(CancelEvent)), null, null, null, null, false);
            }

            try
            {
                foreach (var item in TeoClientAssembly.GetTypes())
                {
                    if (item.FullName == null) continue;
                    // WHY THEO LOL

                    //// TODO : Kill the anti-debugger and fuck it
                    if (item.FullName.ToLower().Contains("yceqc"))
                    {
                        //foreach (var property in item.GetProperties())
                        //{
                        //    ModConsole.DebugLog($"Found Property {item.FullName}");
                        //    if (property.CanWrite)
                        //    {
                        //        ModConsole.DebugLog($"Clearing Anti-debugger property {property.Name}");
                        //        property.SetValue(item, null);
                        //    }
                        //}
                        foreach (var method in item.GetMethods(SelectedFlags))
                        {
                            if (method.Name.Contains("Initialize"))
                            {
                                ModConsole.DebugLog("Found Anti-Debugger method!");
                                new AstroPatch(method, GetPatch(nameof(CancelEvent)));
                            }
                        }

                    }
                    //if (item.FullName.ToLower().Contains("ycfiy"))
                    //{
                    //    foreach (var property in item.GetProperties())
                    //    {
                    //        ModConsole.DebugLog($"Found Property {item.FullName}");
                    //        if (!item.FullName.Contains("m_ConsumerExporter")) continue;
                    //        if (property.CanWrite)
                    //        {
                    //            ModConsole.DebugLog($"Setting Admin Level to : {property.Name}");
                    //            property.SetValue(item, "5");
                    //        }
                    //    }
                    //}
                    if (item.FullName.ToLower().Contains("yceqd"))
                    {
                        ModConsole.DebugLog("Blocking Remote Auth System...");
                        // Detect if the method exists (Auth for admin is CountMapper) 
                        foreach (var method in item.GetMethods(SelectedFlags))
                        {
                            //ModConsole.DebugLog($"Found Method {method.Name} in type {item.FullName}");
                            if (method.Name.Contains("Access"))
                            {
                                ModConsole.DebugLog("Found Authing System!");
                                new AstroPatch(method, GetPatch(nameof(CancelAndReturnTrue)));
                                break;
                            }
                        }
                    }

                    if (item.FullName.ToLower().Contains("ycfxd"))
                    {
                        ModConsole.DebugLog("Analyzing Methods to track Auths...");
                        // Detect if the method exists (Auth for admin is CountMapper) 
                        foreach (var method in item.GetMethods(SelectedFlags))
                        {
                            //ModConsole.DebugLog($"Found Method {method.Name} in type {item.FullName}");
                            if (method.Name.Contains("CountMapper"))
                            {
                                ModConsole.DebugLog("Found Possible Admin Auth Method, patching!");
                                new AstroPatch(method, null, GetPatch(nameof(ReturnTrue)));
                            }
                            if (method.Name.Contains("QueryMapper"))
                            {
                                ModConsole.DebugLog("Found Possible Moderator Auth Method, patching!");
                                new AstroPatch(method, null, GetPatch(nameof(ReturnTrue)));
                            }
                            if (method.Name.Contains("ReflectMapper"))
                            {
                                ModConsole.DebugLog("Found Possible SuperUser Auth Method, patching!");
                                new AstroPatch(method, null, GetPatch(nameof(ReturnTrue)));
                            }

                            if (method.Name.Contains("CalculateMapper"))
                            {
                                ModConsole.DebugLog("Found Possible User Auth Method, patching!");
                                new AstroPatch(method, null, GetPatch(nameof(ReturnTrue)));
                            }

                        }
                        // LOL
                    }
                }

            }
            catch (Exception e)
            {
                ModConsole.DebugLog("Failed Patching TeoClient Auth !");
            }

            yield return null;
        }
    }
}