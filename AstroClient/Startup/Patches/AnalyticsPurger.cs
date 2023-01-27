using System.Reflection;
using AmplitudeSDKWrapper;
using AstroClient.xAstroBoy.Patching;
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
            new UnityClassBlocker<AnalyticsController>();
            new UnityClassBlocker<Analytics>();
            new ClassBlocker(typeof(AnalyticsInterface));
            new ClassBlocker(typeof(AmplitudeWrapper));
        }

        

    }
}
    
