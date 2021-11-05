namespace AstroClient
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
    #endregion Imports


    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class SerializerPatches : GameEvents
    {
        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]

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
                new AstroPatch(typeof(Photon.Realtime.LoadBalancingClient).GetMethod(nameof(Photon.Realtime.LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0)), GetPatch(nameof(OpRaiseEvent)));
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
                    return !MovementSerializer.SerializerActivated;
                }
            }
            catch { }
            return true;
        }
    }
}