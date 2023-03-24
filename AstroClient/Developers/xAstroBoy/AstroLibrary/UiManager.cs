using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Patching;

namespace AstroClient.xAstroBoy
{
    
    using Cheetos;
    using HarmonyLib;
    using System;
    using System.Linq;
    using System.Reflection;
    using MenuMethods;
    using Tools.Extensions;
    using UnhollowerRuntimeLib.XrefScans;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.Core;
    using VRC.DataModel;
    using VRC.UI;
    using VRC.UI.Elements;
    using Il2CppSystem.Collections.Generic;
    // This "Button API", if you can it that, is based off of RubyButtonAPI, by DubyaDude (dooba lol) (https://github.com/DubyaDude)
    /// <summary>
    /// A UiManager that contains many utilites pertaining to VRChat's UI.
    /// </summary>
    ///
    [ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class UiManager : AstroEvents
    {


        [ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UiManager).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            Init();
        }

        internal static void Init()
        {

            new AstroPatch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.OnEnable)),  null,GetPatch(nameof(OnQuickMenuOpen_Event)));
            new AstroPatch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.OnDisable)), null,GetPatch(nameof(OnQuickMenuClose_Event)));

            new AstroPatch(typeof(VRC.UI.Elements.MainMenu).GetMethod(nameof(VRC.UI.Elements.MainMenu.OnEnable)), null, GetPatch(nameof(OnBigMenuOpen_Event)));
            new AstroPatch(typeof(VRC.UI.Elements.MainMenu).GetMethod(nameof(VRC.UI.Elements.MainMenu.OnDisable)), null, GetPatch(nameof(OnBigMenuClose_Event)));

            foreach (MethodInfo method in typeof(MenuController).GetMethods().Where(mi => mi.Name.StartsWith("Method_Public_Void_APIUser_") && !mi.Name.Contains("_PDM_")))
            {
                new AstroPatch(method, null, GetPatch(nameof(OnUserInfoOpen_event)));
            }
            new AstroPatch(typeof(PageUserInfo).GetMethod(nameof(PageUserInfo.Back)), null, GetPatch(nameof(OnUserInfoClose)));


        }

        private static void OnBigMenuOpen_Event() => ClientEventActions.OnBigMenuOpen.SafetyRaise();

        private static void OnBigMenuClose_Event() => ClientEventActions.OnBigMenuClose.SafetyRaise();



        /// <summary>
        /// Opens the given user in the user info page.
        /// </summary>
        /// <param name="user">The user to open</param>
        internal static void OpenUserInUserInfoPage(IUser user)
        {// Method_Public_Void_IUser_0
            UIManagerPublicBoObBoAc1BoAcGa1MeUnique.prop_UIManagerPublicBoObBoAc1BoAcGa1MeUnique_0.Method_Private_Boolean_byref_ValueTypeNPrivateSealedObObObUnique_0(user);
        }

        private static void OnUserInfoOpen_event() => ClientEventActions.OnUserInfoMenuOpen.SafetyRaise();

        private static void OnUserInfoClose() => ClientEventActions.OnUserInfoMenuClose.SafetyRaise();

        private static void OnQuickMenuOpen_Event() => ClientEventActions.OnQuickMenuOpen.SafetyRaise();

        private static void OnQuickMenuClose_Event() => ClientEventActions.OnQuickMenuClose.SafetyRaise();


        /// <summary>
        /// Opens given user in the QuickMenu.
        /// </summary>
        /// <param name="playerToSelect">The player to select</param>
        internal static void OpenUserInQuickMenu(APIUser playerToSelect)
        {
            if (playerToSelect == null)
                throw new ArgumentNullException("Given APIUser was null.");
            NewMenuXrefsSystem.selectUserMethod.Invoke(Helper.EventPump.prop_EventPump_0, new object[1] { playerToSelect });
        }


    }
}