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

    internal class VRCPlayerPatches : GameEvents
    {
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(VRCPlayerPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        
        internal override void ExecutePriorityPatches()
        {
            InitPatch();
        }

        private void InitPatch()
        {
            try
            {
                new Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isSuper)).GetMethod, null, GetPatch(nameof(VRCPlayerBypass)));
                new Patch(AccessTools.Property(typeof(VRCPlayerApi), nameof(VRCPlayerApi.isModerator)).GetMethod, null, GetPatch(nameof(VRCPlayerBypass)));


            }
            catch (Exception e) { ModConsole.Error("Error in applying patches : " + e); }
            finally { }
        }


        private static void VRCPlayerBypass(VRCPlayerApi __instance, ref bool __result)
        {
            if (__instance.isLocal)
            {
                __result = true;
            }
        }


    }
}