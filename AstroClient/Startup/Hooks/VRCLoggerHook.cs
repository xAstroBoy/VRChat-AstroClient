using System.Collections.Generic;

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

    internal class VRCLoggerHook : AstroEvents
    {


        //internal static 

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(VRCLoggerHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            new AstroPatch(typeof(VRC.Core.Logger).GetMethod(nameof(VRC.Core.Logger.Log)), GetPatch(nameof(OnFadeEvent)));

        }

        private static void Logger_log()
    }
}