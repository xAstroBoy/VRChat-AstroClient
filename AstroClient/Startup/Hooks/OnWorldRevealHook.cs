﻿using System.Collections.Generic;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Reflection;
    using AstroEventArgs;
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

    internal class OnWorldRevealHook : AstroEvents
    {
        internal static event Action<string, string, List<string>, string, string> Event_OnWorldReveal;


        //internal static 

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(OnWorldRevealHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            new AstroPatch(typeof(VRCUiManager).GetMethod(nameof(VRCUiManager.Method_Public_Void_String_Single_Action_1)), GetPatch(nameof(OnFadeEvent)));

        }

        private static void OnFadeEvent(string __0, float __1, Il2CppSystem.Action __2)
        {
            string fadeType = __0;
            float duration = __1;

            ModConsole.DebugLog("FadeType Called : " + fadeType + " With duration : " + duration);
            if (fadeType.Equals("BlackFade") && duration.Equals(0f) &&
                RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
            {
                Event_OnWorldReveal.SafetyRaise(WorldUtils.WorldID, WorldUtils.WorldName, WorldUtils.WorldTags, WorldUtils.AuthorName, WorldUtils.AssetURL);
            }

        }

    }
}