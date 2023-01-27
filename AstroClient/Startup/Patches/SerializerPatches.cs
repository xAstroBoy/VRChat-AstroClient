using AstroClient.xAstroBoy.Patching;
using Photon.Pun;

namespace AstroClient.Startup.Patches
{
    #region Imports

    using System;
    using System.Reflection;
    using Cheetos;
    using ExitGames.Client.Photon;
    using HarmonyLib;
    using Tools.Player.Movement.Exploit;

    #endregion Imports


    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class SerializerPatches : AstroEvents
    {
        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]

        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(SerializerPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        
        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(Photon.Realtime.LoadBalancingClient).GetMethod(nameof(Photon.Realtime.LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OpRaiseEvent)));
            new AstroPatch(typeof(PhotonNetwork).GetMethod(nameof(PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OpRaiseEvent)));
            new AstroPatch(typeof(PhotonNetwork).GetMethod(nameof(PhotonNetwork.Method_Private_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OpRaiseEvent)));

        }
        private static bool OpRaiseEvent(ref byte __0, ref Il2CppSystem.Object __1, ref Photon.Realtime.RaiseEventOptions __2, ref SendOptions __3)
        {
            try
            {
                if (__0 == 12 || __0 == 1)
                {
                    return !MovementSerializer.SerializerActivated;
                }
            }
            catch { }
            return true;
        }


    }
}