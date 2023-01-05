using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using VRC.Networking;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks.Linq;
using MelonLoader;
using UnityEngine;
using VRC;
using VRC.Networking;
using VRC.SDKBase;
using VRC.Udon;


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

            new AstroPatch(typeof(UdonSync).GetMethod(nameof(UdonSync.UdonSyncRunProgramAsRPC)), GetPatch(nameof(Hook_UdonSync_UdonSyncRunProgramAsRPC)));

           // PatchMethod(typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC"), GetLocalPatch("PreOnUdonRPCReceivedPatch"), GetLocalPatch("PostOnUdonRPCReceivedPatch"));
            var RunProgramString = (from m in typeof(UdonBehaviour).GetMethods()
                                   where m.Name.Equals("RunProgram") && m.GetParameters()[0].ParameterType == typeof(string)
                                   select m).First();
            var RunProgramUint = (from m in typeof(UdonBehaviour).GetMethods()
                                  where m.Name.Equals("RunProgram") && m.GetParameters()[0].ParameterType == typeof(uint)
                                  select m).First();


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

        private static bool Hook_UdonSync_UdonSyncRunProgramAsRPC(UdonSync __instance, string __0, Player __1)
        {
            if (__instance == null) return true;
            if (__0.IsNullOrEmptyOrWhiteSpace()) return true;
            return EventDispatcher_HandleUdonEvent.Handle_UdonEvent_UdonSyncRunProgramAsRPC(__instance, __0, __1);

        }

        private static bool Hook_UdonBehaviour_Event_SendCustomEvent(UdonBehaviour __instance, string __0)
        {
            if (__instance == null) return true;
            if (__0.IsNullOrEmptyOrWhiteSpace()) return true;
            return EventDispatcher_HandleUdonEvent.Handle_UdonEvent_CustomEvent(__instance, __0);

        }


    }
}