using System.Reflection;
using AmplitudeSDKWrapper;
using AstroClient.xAstroBoy.Patching;
using HarmonyLib;
using VRC.Core;
using VRC.UI.Elements.Analytics;

namespace AstroClient.Startup.Patches
{
    #region Imports

    #endregion Imports

    [Obfuscation(Feature = "HarmonyRenamer")]
    internal class AnalyticsPurger : AstroEvents
    {
        private static readonly BindingFlags TargetedFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }

        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(AnalyticsPurger).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }
        [Obfuscation(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            Log.Write($"Blocked {typeof(AnalyticsController).PatchAllWith(GetPatch(nameof(Destroy_AnalyticsController_AndReturnFalse)))} {typeof(AnalyticsController).FullDescription()} Methods.");
            Log.Write($"Blocked {typeof(Analytics).PatchAllWith(GetPatch(nameof(Destroy_Analytics_AndReturnFalse)))} {typeof(Analytics).FullDescription()} Methods.");
            Log.Write($"Blocked {typeof(AnalyticsInterface).PatchAllWith(GetPatch(nameof(ReturnFalse)))} {typeof(AnalyticsInterface).FullDescription()} Methods.");
            Log.Write($"Blocked {typeof(AmplitudeWrapper).PatchAllWith(GetPatch(nameof(ReturnFalse)))} {typeof(AmplitudeWrapper).FullDescription()} Methods.");
        }
        private static bool Destroy_AnalyticsController_AndReturnFalse(ref AnalyticsController __instance)
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

        private static bool Destroy_Analytics_AndReturnFalse(ref Analytics __instance)
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
        private static bool ReturnFalse()
        {
            return false;
        }

    }
}
    
