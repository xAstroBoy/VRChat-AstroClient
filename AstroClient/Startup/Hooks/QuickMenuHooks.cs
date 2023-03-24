using AstroClient.ClientActions;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.Patching;
using AstroClient.xAstroBoy.Utility;
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
    internal class QuickMenuHooks : AstroEvents
    {

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(QuickMenuHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            //QuickMenu.Method_Public_Virtual_Void_Boolean_IUser_0
        //MonoBehaviourPublicObBoAuGaBoTrGaObReAnUnique
        new AstroPatch(typeof(VRC.UI.Elements.QuickMenu).GetMethod(nameof(VRC.UI.Elements.QuickMenu.Method_Public_Virtual_New_Void_Boolean_0)), null, GetPatch(nameof(OnSelectedPlayerPatch)));
        }


        private static void OnSelectedPlayerPatch(ref bool __0, ref IUser __1)
        {
            ClientEventActions.OnPlayerSelected.SafetyRaiseWithParams(__1.ToAPIUser().GetPlayer());
        }

    }
}