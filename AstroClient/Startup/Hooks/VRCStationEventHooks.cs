using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Patching;
using AstroClient.xAstroBoy.Utility;
using VRC;
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
    internal class VRCStationEventHooks : AstroEvents
    {

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(VRCStationEventHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            //new AstroPatch(typeof(VRCStation).GetMethod(nameof(VRCStation.UseStation)), GetPatch(nameof(OnStationEnter)));
            //new AstroPatch(typeof(VRCStation).GetMethod(nameof(VRCStation.ExitStation)), GetPatch(nameof(OnStationExit)));


            new AstroPatch(typeof(VRC_StationInternal).GetMethod(nameof(VRC_StationInternal.UseStation)), GetPatch(nameof(OnStationEnter)));
            new AstroPatch(typeof(VRC_StationInternal).GetMethod(nameof(VRC_StationInternal.ExitStation)), GetPatch(nameof(OnStationExit)));
            new AstroPatch(typeof(VRC_StationInternal).GetMethod(nameof(VRC_StationInternal.Method_Private_Void_Player_2)), GetPatch(nameof(OnStationExit)));
            new AstroPatch(typeof(VRC_StationInternal).GetMethod(nameof(VRC_StationInternal.Method_Private_Void_Player_4)), GetPatch(nameof(OnStationExit)));


        }




        private static void OnStationEnter(VRC_StationInternal __instance, Player __0)
        {
            if (__instance == null) return;
            if (__0 == null) return;
            if (!__0.GetVRCPlayerApi().isLocal) return;
            //Log.Debug($"Sit Event {__instance.gameObject.name}");
            ClientEventActions.OnStationEnter.SafetyRaiseWithParams(__instance);

        }
        private static bool OnStationExit(VRC_StationInternal __instance, Player __0)
        {
            if (__instance == null) return true;
            if (__0 == null) return true;
            if (!__0.GetVRCPlayerApi().isLocal) return true;
            var Station = __instance.gameObject.GetComponent<VRC_AstroStation>();
            if (Station != null)
            {
                if(Station.BlockVanillaStationExit)
                {
                    return false;
                }
            }


            //Log.Debug($"Unsit Event {__instance.gameObject.name}");
            ClientEventActions.OnStationExit.SafetyRaiseWithParams(__instance);
            return true;
        }


    }
}