using AstroClient.Config;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Extensions;
using VRC.Udon;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetos;
    using HarmonyLib;
    using MelonLoader;
    using Tools.Extensions;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class UdonEventsHook : AstroEvents
    {
        internal static event Action<UdonBehaviour> Event_Udon_OnPickup;
        internal static event Action<UdonBehaviour> Event_Udon_OnPickupUseUp;
        internal static event Action<UdonBehaviour> Event_Udon_OnPickupUseDown;
        internal static event Action<UdonBehaviour> Event_Udon_OnDrop;
        internal static event Action<UdonBehaviour> Event_Udon_OnInteract;
        internal static event Action<UdonBehaviour, string> Event_Udon_SendCustomEvent;

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
        }


        private static void Hook_UdonBehaviour_Event_OnPickup(UdonBehaviour __instance)
        {
            if (__instance == null) return;
            Event_Udon_OnPickup.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnPickupUseUp(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            Event_Udon_OnPickupUseUp.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnPickupUseDown(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            Event_Udon_OnPickupUseDown.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnDrop(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            Event_Udon_OnDrop.SafetyRaiseWithParams(__instance);

        }
        private static void Hook_UdonBehaviour_Event_OnInteract(UdonBehaviour __instance)
        {
            if (__instance == null) return;

            Event_Udon_OnInteract.SafetyRaiseWithParams(__instance);
        }
        private static bool Hook_UdonBehaviour_Event_SendCustomEvent(UdonBehaviour __instance, string __0)
        {
            if (__instance == null) return true;
            if (__0.IsNullOrEmptyOrWhiteSpace()) return true;

            Event_Udon_SendCustomEvent.SafetyRaiseWithParams(__instance, __0);
            //if(GameObject_RPC_Firewall.isRPCEventBlocked(null, __instance.transform, __0))
            //{
            //    return false;
            //}
            return true;

        }


    }
}