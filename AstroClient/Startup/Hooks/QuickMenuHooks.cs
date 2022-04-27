﻿using AstroClient.ClientActions;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Reflection;
    
    using Cheetos;
    using HarmonyLib;
    using MelonLoader;
    using Tools.Extensions;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class QuickMenuHooks : AstroEvents
    {

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(QuickMenuHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.Method_Public_Void_Player_0)), GetPatch(nameof(OnSelectedPlayerPatch)));
        }


        private static void OnSelectedPlayerPatch(ref VRC.Player __0)
        {
            ClientEventActions.Event_OnPlayerSelected.SafetyRaiseWithParams(__0);
        }

    }
}