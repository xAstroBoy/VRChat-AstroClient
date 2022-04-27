using System.Linq;
using AstroClient.ClientActions;
using Photon.Pun;
using VRC.SDKBase;

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
    internal class OnOwnerShipTransferredHook : AstroEvents
    {

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(OnOwnerShipTransferredHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(PhotonView).GetMethods().First(mb => mb.Name.StartsWith("Method_FamOrAssem_set_Void_Int32_")), GetPatch(nameof(OnOwnerShipTransferredEvent)));

        }


        private static void OnOwnerShipTransferredEvent(PhotonView __instance, int __0)
        {
            ClientEventActions.Event_OnOwnerShipTranferred.SafetyRaiseWithParams(__instance, __0);
        }

    }
}