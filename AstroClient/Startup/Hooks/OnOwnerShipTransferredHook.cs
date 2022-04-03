using System.Linq;
using Photon.Pun;
using VRC.SDKBase;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetos;
    using Harmony;
    using MelonLoader;
    using Tools.Extensions;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class OnOwnerShipTransferredHook : AstroEvents
    {
        internal static event Action<PhotonView, int> Event_OnOwnerShipTranferred;

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
            Event_OnOwnerShipTranferred.SafetyRaise(__instance, __0);
        }

    }
}