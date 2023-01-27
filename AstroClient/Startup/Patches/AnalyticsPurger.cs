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
            new UnityClassBlocker<AnalyticsController>();
            new UnityClassBlocker<Analytics>();
            new ClassBlocker(typeof(AnalyticsInterface));
            new ClassBlocker(typeof(AmplitudeWrapper));
        }

        

    }
}
    
