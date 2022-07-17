﻿using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

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
    internal class UdonEventsHook : AstroEvents
    {

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UdonEventsHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnPickup)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnPickup)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnPickupUseUp)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnPickupUseUp)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnPickupUseDown)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnPickupUseDown)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnDrop)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnDrop)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.Interact)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnInteract)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.SendCustomEvent)), GetPatch(nameof(Hook_UdonBehaviour_Event_SendCustomEvent)));
            //ClientEventActions.VRChat_OnQuickMenuInit += VrChatOnQuickMenuInit;


        }

        //private void VrChatOnQuickMenuInit()
        //{
        //    UdonBehaviour.OnInit += (Il2CppSystem.Action<UdonBehaviour, IUdonProgram>)Hook_Udon_OnInit;
        //    Log.Debug("Hooked UdonBehaviour OnInit!");
        //}


        private static void Hook_UdonBehaviour_Event_OnPickup(UdonBehaviour __instance)
        {
            if (__instance == null) return;
            ClientEventActions.Udon_OnPickup.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnPickupUseUp(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            ClientEventActions.Udon_OnPickupUseUp.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnPickupUseDown(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            ClientEventActions.Udon_OnPickupUseDown.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnDrop(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            ClientEventActions.Udon_OnDrop.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnInteract(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            ClientEventActions.Udon_OnInteract.SafetyRaiseWithParams(__instance);
        }
        private static void Hook_Udon_OnInit(UdonBehaviour instance, IUdonProgram program)
        {
            if (instance == null) return;

            ClientEventActions.Udon_OnInit.SafetyRaiseWithParams(instance);

        }


        private static bool Hook_UdonBehaviour_Event_SendCustomEvent(UdonBehaviour __instance, string __0)
        {
            if (__instance == null) return true;
            if (__0.IsNullOrEmptyOrWhiteSpace()) return true;
            return EventDispatcher_HandleUdonEvent.Handle_UdonEvent_CustomEvent(__instance, __0);

        }


    }
}