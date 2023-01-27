using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Patching;
using AstroClient.xAstroBoy.Utility;
using VRC.SDK3.Components;
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
    internal class VRCPickupHooks : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomJoined += OnRoomJoined;
            ClientEventActions.OnRoomLeft += OnRoomLeft;

        }


        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(VRCPickupHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static bool EnableListener { get; set; } = false;
        private void OnRoomJoined()
        {
            EnableListener = true;
        }

        private void OnRoomLeft()
        {
            EnableListener = false;
        }

        

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(AccessTools.Property(typeof(VRC_Pickup), nameof(VRC_Pickup.IsHeld)).GetMethod, null, GetPatch(nameof(IsHeldListener)));
            new AstroPatch(typeof(VRC_Pickup).GetMethod(nameof(VRC_Pickup.Awake)), GetPatch(nameof(SDK1_Pickup)), showErrorOnConsole: false);

        }



        private static void SDK1_Pickup(VRC_Pickup __instance)
        {
            ClientEventActions.OnPickupAwake.SafetyRaiseWithParams(__instance);
        }

        private static void IsHeldListener(VRC_Pickup __instance, ref bool __result)
        {
            if (!EnableListener) return;
            try
            {
                if (__instance == null)
                {
                    return;
                }
                ClientEventActions.Pickup_isHeld.SafetyRaiseWithParams(__instance, __result);

            }
            catch{}
        }


    }
}