using AstroClient.xAstroBoy.Patching;
using VRC.SDKBase.Validation.Performance.Stats;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Reflection;
    using Cheetos;
    using Config;
    using Constants;
    using Tools.Extensions;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using HarmonyLib;
    using VRC.SDKBase.Validation.Performance;
    using WorldModifications.WorldsIds;

    #endregion Imports
    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class PerformanceScannerHook : AstroEvents
    {


        //internal static 
        private HarmonyLib.Harmony harmony;

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(HarmonyLib.AccessTools.Method(typeof(PerformanceScannerSet), nameof(PerformanceScannerSet.RunPerformanceScan)), GetPatch(nameof(CalculatePerformance)));
            new AstroPatch(HarmonyLib.AccessTools.Method(typeof(PerformanceScannerSet), nameof(PerformanceScannerSet.RunPerformanceScanEnumerator)), GetPatch(nameof(CalculatePerformance)));

        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(PerformanceScannerHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        private static bool CalculatePerformance(AvatarPerformanceStats __1)
        {
            if(!ConfigManager.Performance.AllowPerformanceScanner)
            {
                for(int i = 0; i < __1._performanceRatingCache.Count; i++)
                {
                    __1._performanceRatingCache[i] = PerformanceRating.None;
                }
            }
            return true;
        }
    }
}