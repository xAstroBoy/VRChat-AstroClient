using AmplitudeSDKWrapper;
using AstroClient.febucci;
using AstroClient.febucci.Utilities;
using HarmonyLib;
using VRC.Core;
using VRC.UI.Elements.Analytics;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using Cheetos;
    using System.Reflection;
    using xAstroBoy.Utility;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class AnalyticsPurger : AstroEvents
    {
        private static readonly BindingFlags TargetedFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(AnalyticsPurger).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }
        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            int AnalyticsController_Patches = 0;
            int Analytics_Patches = 0;
            int AnalyticsInterface_Patches = 0;
            int AmplitudeWrapper_Patches = 0;

            Log.Write("Deactivating VRChat Analytics System..");
            foreach (var method in typeof(AnalyticsController).GetMethods(TargetedFlags))
            {
                if (method.FullDescription().Contains(typeof(AnalyticsController).FullDescription()))
                {
                    var patch =new AstroPatch(method, GetPatch(nameof(DieAndFuckOff)), showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: false);
                    if(patch.isActivePatch)
                    {
                        AnalyticsController_Patches++;
                    }
                }
            }

            foreach (var method in typeof(Analytics).GetMethods(TargetedFlags))
            {
                if (method.FullDescription().Contains(typeof(Analytics).FullDescription()))
                {
                    var patch = new AstroPatch(method, GetPatch(nameof(DieAnFuckoff1)), showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: false);
                    if (patch.isActivePatch)
                    {
                        Analytics_Patches++;

                    }
                }
            }


            foreach (var method in typeof(AnalyticsInterface).GetMethods(TargetedFlags))
            {
                if(method.FullDescription().Contains(typeof(AnalyticsInterface).FullDescription()))
                {
                    var patch = new AstroPatch(method, GetPatch(nameof(FuckOff)), showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: false);
                    if (patch.isActivePatch)
                    {
                        AnalyticsInterface_Patches++;

                    }
                }
            }

            foreach (var method in typeof(AmplitudeWrapper).GetMethods(TargetedFlags))
            {
                if (method.FullDescription().Contains(typeof(AmplitudeWrapper).FullDescription()))
                {
                    var patch = new AstroPatch(method, GetPatch(nameof(FuckOff)), showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: false);
                    if (patch.isActivePatch)
                    {
                        AmplitudeWrapper_Patches++;

                    }
                }
            }
            Log.Write($"Blocked {AnalyticsController_Patches} {typeof(AnalyticsController).FullDescription()} Methods.");
            Log.Write($"Blocked {Analytics_Patches} {typeof(Analytics).FullDescription()} Methods.");
            Log.Write($"Blocked {AnalyticsInterface_Patches} {typeof(AnalyticsInterface).FullDescription()} Methods.");
            Log.Write($"Blocked {AmplitudeWrapper_Patches} {typeof(AmplitudeWrapper).FullDescription()} Methods.");

        }

        private static bool DieAndFuckOff(ref AnalyticsController __instance)
        {
            try
            {
                if (__instance != null)
                {
                    UnityEngine.Object.DestroyImmediate(__instance);
                }
            }
            catch { }
            return false;
        }

        private static bool DieAnFuckoff1(ref Analytics __instance)
        {
            try
            {
                if (__instance != null)
                {
                    UnityEngine.Object.DestroyImmediate(__instance);
                }
            }
            catch { }
            return false;
        }
        private static bool FuckOff()
        {
            return false;
        }

    }
}
    
