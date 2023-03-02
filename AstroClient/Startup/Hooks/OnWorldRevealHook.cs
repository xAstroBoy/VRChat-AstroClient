using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Patching;

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

    internal class OnWorldRevealHook : AstroEvents
    {


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
            new AstroPatch(typeof(VRCUiManager).GetMethod(nameof(VRCUiManager.Method_Public_Void_String_Single_Action_0)), null, GetPatch(nameof(OnFadeEvent)));

        }

        private static void OnFadeEvent(string __0, float __1, Il2CppSystem.Action __2)
        {
            string fadeType = __0;
            float duration = __1;

            Log.Debug("FadeType Called : " + fadeType + " With duration : " + duration);
            if (fadeType.Equals("BlackFade") && duration.Equals(0f) &&
                RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
            {
                ClientEventActions.OnWorldReveal.SafetyRaiseWithParams(WorldUtils.WorldID, WorldUtils.WorldName, WorldUtils.WorldTags, WorldUtils.AssetURL, WorldUtils.AuthorName);
            }

        }

    }
}