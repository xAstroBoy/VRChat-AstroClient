using AstroClient.ClientActions;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using VRC.UI.Elements;

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
    internal class FixRandomQMOpen : AstroEvents
    {

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(FixRandomQMOpen).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(MenuStateController).GetMethod(nameof(MenuStateController.Method_Public_Void_String_Boolean_Boolean_2)), GetPatch(nameof(BlockAndReport)));

        }


        private static bool BlockAndReport(string __0, bool __1, bool __2)
        {
            //Log.Debug($"MenuStateController.Method_Public_Void_String_Boolean_Boolean_2 Has Been Invoked with params :" +
            //$" string param_0 = {__0} , bool : {__1}, bool : {__2}");

            return false;

        }

    }
}