using AmplitudeSDKWrapper;
using AstroClient.xAstroBoy.Patching;
using HarmonyLib;
using System;
using System.Reflection;
using VRC.Core;
using VRC.UI.Elements.Analytics;

namespace AstroClient.Startup.Patches
{
    [Obfuscation(Feature = "HarmonyRenamer")]
    internal class AnalyticsPurger : AstroEvents
    {

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }


        private static Type[] typesToBlock { get; } = 
        {
                typeof(AnalyticsController),
                typeof(Analytics),
                typeof(AnalyticsInterface),
                typeof(AmplitudeWrapper),
                typeof(AnalyticsSDK),
                //typeof(DatabaseHelper),
                //typeof(SessionManager)
        };


        [Obfuscation(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            //foreach (var item in typesToBlock)
            //{
            //    var Patched = item.BlockAllMethods();
            //    Log.Write($"Blocked {Patched} {item.FullDescription()} Methods.");
            //}
        }
    }
}