using AstroClient.febucci;
using AstroClient.febucci.Utilities;
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
        //internal static

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
            new AstroPatch(typeof(AnalyticsController).GetMethod(nameof(AnalyticsController.OnEnable)), GetPatch(nameof(KillItWithFire)));
        }

        private static void KillItWithFire(ref AnalyticsController __instance)
        {
            try
            {
                if (__instance != null)
                {
                    UnityEngine.Object.DestroyImmediate(__instance);
                }
            }
            catch{}
        }
    }
}
    
