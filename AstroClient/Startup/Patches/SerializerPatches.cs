namespace AstroClient.BetterPatch
{
    #region Imports

    using AstroClient.Features.Player.Movement.Exploit;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using Patch = AstroClient.Patch;
    #endregion Imports

    internal class SerializerPatches : GameEvents
    {
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(SerializerPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        
        internal override void ExecutePriorityPatches()
        {
            InitPatch();
        }

        private void InitPatch()
        {
            try
            {
                new Patch(typeof(Photon.Realtime.LoadBalancingClient).GetMethod(nameof(Photon.Realtime.LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OpRaiseEvent)));
                new Patch(typeof(ObjectInstantiator).GetMethod(nameof(ObjectInstantiator._InstantiateObject)), GetPatch(nameof(Debug_ObjectInstantiator)));
                new Patch(typeof(Networking).GetMethod(nameof(Networking.Instantiate)), GetPatch(nameof(Debug_NetworkingInstantiate)));
            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }

        private static bool OpRaiseEvent(ref byte __0, ref Il2CppSystem.Object __1, ref Photon.Realtime.RaiseEventOptions __2, ref SendOptions __3)
        {
            try
            {
                if (__0 == 7 || __0 == 206 || __0 == 201 || __0 == 1)
                {
                    return !MovementSerializer.Enabled;
                }
            }
            catch { }
            return true;
        }

        private static void Debug_ObjectInstantiator(ref string __0, ref Vector3 __1, ref Quaternion __2, ref int __3, ref Player __4)
        {
            if (__4 != null)
            {
                ModConsole.DebugLog($"ObjectInstantiator Fired with Params  : {__0}, {__1}, {__2}, {__3}, {__4.DisplayName()}");
            }
            else
            {
                ModConsole.DebugLog($"ObjectInstantiator Fired with Params  : {__0}, {__1}, {__2}, {__3}");
            }
        }

        private static void Debug_NetworkingInstantiate(ref VRC_EventHandler.VrcBroadcastType __0, ref string __1, ref Vector3 __2, ref Quaternion __3)
        {
            var broadcast = __0;
            var prefabPathOrDynamicPrefabName = __1;
            var position = __2.ToString();
            var rotation = __3.ToString();

            ModConsole.DebugLog($"Networking.Instantiate Fired with Params  : {broadcast}, {prefabPathOrDynamicPrefabName}, {position}, {rotation}");
        }
    }
}