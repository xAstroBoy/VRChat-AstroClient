using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
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
            new AstroPatch(typeof(VRCStation).GetMethod(nameof(VRCStation.UseStation)), GetPatch(nameof(OnStationEnter)));
            new AstroPatch(typeof(VRCStation).GetMethod(nameof(VRCStation.ExitStation)), GetPatch(nameof(OnStationExit)));


            new AstroPatch(typeof(VRC_StationInternal).GetMethod(nameof(VRC_StationInternal.UseStation)), GetPatch(nameof(OnStationEnter2)));
            new AstroPatch(typeof(VRC_StationInternal).GetMethod(nameof(VRC_StationInternal.ExitStation)), GetPatch(nameof(OnStationExit2)));

        }


        private static void OnStationEnter(VRCStation __instance, VRCPlayerApi __0)
        {
            if (__instance == null) return;
            if(__0 == null) return;
            if (!__0.isLocal) return;
            Log.Debug($"Sit Event {__instance.gameObject.name}");
            ClientEventActions.OnStationEnter.SafetyRaiseWithParams(__instance);

        }
        private static bool OnStationExit(VRCStation __instance, VRCPlayerApi __0)
        {
            if (__instance == null) return true;
            if (__0 == null) return true;
            if (!__0.isLocal) return true;
            var Station = __instance.gameObject.GetComponent<VRC_AstroStation>();
            if (Station != null)
            {
                if (Station.OverrideStationExit)
                {
                    return false;
                }
            }


            Log.Debug($"Unsit Event {__instance.gameObject.name}");
            ClientEventActions.OnStationExit.SafetyRaiseWithParams(__instance);
            return true;
        }

        private static void OnStationEnter2(VRC_StationInternal __instance, VRCPlayerApi __0)
        {
            if (__instance == null) return;
            if (__0 == null) return;
            if (!__0.isLocal) return;
            Log.Debug($"Sit Event {__instance.gameObject.name}");
            ClientEventActions.OnStationEnter2.SafetyRaiseWithParams(__instance);

        }
        private static bool OnStationExit2(VRC_StationInternal __instance, VRCPlayerApi __0)
        {
            if (__instance == null) return true;
            if (__0 == null) return true;
            if (!__0.isLocal) return true;
            var Station = __instance.gameObject.GetComponent<VRC_AstroStation>();
            if (Station != null)
            {
                if(Station.OverrideStationExit)
                {
                    return false;
                }
            }


            Log.Debug($"Unsit Event {__instance.gameObject.name}");
            ClientEventActions.OnStationExit2.SafetyRaiseWithParams(__instance);
            return true;
        }
    }
}