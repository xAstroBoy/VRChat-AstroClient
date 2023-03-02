
using AstroClient.ClientActions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Patching;
using VRC;

namespace AstroClient.Startup.Hooks
{
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Utility;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class NetworkManagerHooks : AstroEvents
    {


        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerJoinMethod.Name), GetPatch(nameof(OnPhotonPlayerJoin)));
            new AstroPatch(typeof(NetworkManager).GetMethod(XrefTesting.OnPhotonPlayerLeftMethod.Name), GetPatch(nameof(OnPhotonPlayerLeft)));
            new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnMasterClientSwitched)), GetPatch(nameof(OnMasterClientSwitchedPatch)));
            new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnLeftRoom)), GetPatch(nameof(OnRoomLeftPatch)));
            new AstroPatch(typeof(NetworkManager).GetMethod(nameof(NetworkManager.OnJoinedRoom)), GetPatch(nameof(OnRoomJoinedPatch)));

        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(NetworkManagerHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static void OnMasterClientSwitchedPatch(Player __0) => ClientEventActions.OnMasterClientSwitched?.SafetyRaiseWithParams(__0);

        private static void OnPhotonPlayerJoin(ref Player __0) => ClientEventActions.OnPhotonPlayerJoined?.SafetyRaiseWithParams(__0);

        private static void OnPhotonPlayerLeft(ref Player __0) => ClientEventActions.OnPhotonPlayerLeft.SafetyRaiseWithParams(__0);


        private static void OnRoomLeftPatch() => ClientEventActions.OnRoomLeft?.SafetyRaise();

        private static void OnRoomJoinedPatch() => ClientEventActions.OnRoomJoined?.SafetyRaise();

    }
}