
using AstroClient.ClientActions;

namespace AstroClient.ModsDetector
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using MelonLoader;
    using Attribute = System.Attribute;
    using AstroClient.Tools.Extensions;

    internal class EmmPatcher : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnPatchShieldRemoved += OnPatchShieldRemoved;
        }

        private static BindingFlags SelectedFlags => BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;

        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(EmmPatcher).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private void OnPatchShieldRemoved()
        {
            InitEmmPatch();
        }

        private static Assembly _EmmVRCClient = null;
        private static Assembly EmmVRCClient
        {
            get
            {
                if (_EmmVRCClient == null)
                {
                    Assembly[] LoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                    if (LoadedAssemblies != null)
                    {
                        for (int i = 0; i < LoadedAssemblies.Length; i++)
                        {
                            Assembly item = LoadedAssemblies[i];
                            var attrib = item.GetAssemblyAttribute<AssemblyDescriptionAttribute>();
                            if (item.FullName.Contains("emmVRC"))
                            {
                                if (attrib != null)
                                {
                                    if (attrib.Description.Equals("Main class and modules for the emmVRC Mod"))
                                    {
                                        Log.Debug("Found Emm Client!");
                                        return _EmmVRCClient = item;
                                    }
                                }
                            }
                        }
                    }
                }
                return _EmmVRCClient;
            }
        }

        private static void InitEmmPatch()
        {
            if (EmmVRCClient == null) return;

            foreach (var item in EmmVRCClient.GetTypes())
            {
                if (item.FullName == null) continue;
                if (item.FullName.Contains("PlayerUtils"))
                {
                    foreach (var method in item.GetMethods(SelectedFlags))
                    {
                        if(method.Name.Equals("DoesUserHaveVRCPlus"))
                        {
                            new AstroPatch(method, GetPatch(nameof(Patched_DoesUserHaveVRCPlus)));
                        }
                    }
                }
                if (item.FullName.Contains("RiskyFunctionsManager"))
                {
                    foreach (var property in item.GetProperties(SelectedFlags))
                    {
                        if (property.Name.Equals("AreRiskyFunctionsAllowed"))
                        {
                            new AstroPatch(property.SetMethod, GetPatch(nameof(Patched_AreRiskyFunctionsAllowed)));
                        }
                    }
                }

            }


        }

        private static bool Patched_DoesUserHaveVRCPlus(bool __result)
        {
            __result = true;
            Log.Debug("Forced DoesUserHaveVRCPlus to true");
            return false;
        }

        private static bool Patched_AreRiskyFunctionsAllowed(bool __0)
        {
            __0 = true;
            Log.Debug("Forced RiskyFunction Bool to true");
            return true;
        }
    }
}