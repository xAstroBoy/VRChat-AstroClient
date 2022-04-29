using AstroClient.ClientActions;

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

        private static bool _shouldSkipPlaceUiAfterPause;
        private static bool _shouldChangeScreenStackValue;
        private static bool _newScreenStackValue;

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

            new AstroPatch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.OnEnable)), null, GetPatch(nameof(OnQuickMenuOpen_Event)));
            new AstroPatch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.OnDisable)), null, GetPatch(nameof(OnQuickMenuClose_Event)));

            new AstroPatch(typeof(UIPage).GetMethod(nameof(UIPage.Method_Public_Void_Boolean_TransitionType_0)), GetPatch(nameof(OnUIPageToggle)));
            new AstroPatch(typeof(UIPage).GetMethod(nameof(UIPage.Method_Protected_Void_Boolean_TransitionType_0)), GetPatch(nameof(OnUIPageToggle)));

            new AstroPatch(NewMenuXrefsSystem.openBigMenu, null, GetPatch(nameof(OnBigMenuOpen_Event)));
            new AstroPatch(NewMenuXrefsSystem.closeBigMenu, null, GetPatch(nameof(OnBigMenuClose_Event)));

            foreach (MethodInfo method in typeof(MenuController).GetMethods().Where(mi => mi.Name.StartsWith("Method_Public_Void_APIUser_") && !mi.Name.Contains("_PDM_")))
            {
                new AstroPatch(method, null, GetPatch(nameof(OnUserInfoOpen_event)));
            }
            new AstroPatch(typeof(PageUserInfo).GetMethod(nameof(PageUserInfo.Back)), null, GetPatch(nameof(OnUserInfoClose)));

            //new AstroPatch(NewMenuXrefsSystem.placeUiAfterPause, GetPatch(nameof(OnPlaceUiAfterPause)));

            new AstroPatch(typeof(VRCUiManager).GetMethod(nameof(VRCUiManager.Method_Public_Void_String_Boolean_0)), GetPatch(nameof(OnShowScreen)));

            //new AstroPatch(NewMenuXrefsSystem.closeQuickMenuMethod, null, GetPatch(nameof(OnQuickMenuClose_Event)));
            //new AstroPatch(NewMenuXrefsSystem.onQuickMenuOpenedMethod, null, GetPatch(nameof(OnQuickMenuOpen_Event)));

        }

        private static void OnBigMenuOpen_Event() => ClientEventActions.OnBigMenuOpen.SafetyRaise();

        private static void OnBigMenuClose_Event() => ClientEventActions.OnBigMenuClose.SafetyRaise();

        private static bool OnPlaceUiAfterPause(ref bool __result)
        {
            if (!_shouldSkipPlaceUiAfterPause)
                return true;

            _shouldSkipPlaceUiAfterPause = false;
            __result = false;
            return false;
        }

        private static void OnShowScreen(ref bool __1)
        {
            if (_shouldChangeScreenStackValue)
            {
                __1 = _newScreenStackValue;
                _shouldChangeScreenStackValue = false;
            }
        }

        /// <summary>
        /// Sets the index of the big menu.
        /// </summary>
        /// <param name="index">The index to set it to</param>
        internal static void MainMenu(int index) => MainMenu(index, true, true, true);

        /// <summary>
        /// Sets the index of the big menu.
        /// </summary>
        /// <param name="index">The index to set it to</param>
        /// <param name="openUi">Whether to open the Ui along with setting the index</param>
        internal static void MainMenu(int index, bool openUi) => MainMenu(index, openUi, true, true);

        /// <summary>
        /// Sets the index of the big menu.
        /// </summary>
        /// <param name="index">The index to set it to</param>
        /// <param name="openUi">Whether to open the Ui along with setting the index</param>
        /// <param name="addToScreenStack">Whether the new screen opened should be added to the screen stack</param>
        internal static void MainMenu(int index, bool openUi, bool addToScreenStack) => MainMenu(index, addToScreenStack, openUi, true);

        /// <summary>
        /// Sets the index of the big menu.
        /// </summary>
        /// <param name="index">The index to set it to</param>
        /// <param name="openUi">Whether to open the Ui along with setting the index</param>
        /// <param name="addToScreenStack">Whether the new screen opened should be added to the screen stack</param>
        /// <param name="rePlaceUi">Whether to recalculate and reposition the UI</param>
        internal static void MainMenu(int index, bool openUi, bool addToScreenStack, bool rePlaceUi)
        {
            _shouldChangeScreenStackValue = true;
            _newScreenStackValue = addToScreenStack;
            _shouldSkipPlaceUiAfterPause = !rePlaceUi;
            if (openUi)
                OpenBigMenu(false);
            VRCUiManager.field_Private_Static_VRCUiManager_0.Method_Public_Void_String_Boolean_0(NewMenuXrefsSystem.BigMenuIndexToPathTable[index]);
        }

        /// <summary>
        /// Opens the given user in the user info page.
        /// </summary>
        /// <param name="user">The user to open</param>
        internal static void OpenUserInUserInfoPage(IUser user)
        {
            UIManagerImpl.prop_UIManagerImpl_0.Method_Public_Void_IUser_0(user);
        }

        /// <summary>
        /// Closes the big menu.
        /// </summary>
        internal static void CloseBigMenu() => NewMenuXrefsSystem.closeBigMenu.Invoke(VRCUiManager.prop_VRCUiManager_0, new object[2] { true, false });

        /// <summary>
        /// Opens the big menu.
        /// </summary>
        internal static void OpenBigMenu() => OpenBigMenu(true);

        /// <summary>
        /// Opens the big menu
        /// </summary>
        /// <param name="showDefaultScreen">Whether to show the world menu after opening the big menu</param>
        internal static void OpenBigMenu(bool showDefaultScreen) => NewMenuXrefsSystem.openBigMenu.Invoke(VRCUiManager.prop_VRCUiManager_0, new object[2] { showDefaultScreen, true });

        private static void OnUserInfoOpen_event() => ClientEventActions.OnUserInfoMenuOpen.SafetyRaise();

        private static void OnUserInfoClose() => ClientEventActions.OnUserInfoMenuClose.SafetyRaise();

        private static void OnQuickMenuOpen_Event() => ClientEventActions.OnQuickMenuOpen.SafetyRaise();

        private static void OnQuickMenuClose_Event() => ClientEventActions.OnQuickMenuClose.SafetyRaise();

        private static void OnUIPageToggle(UIPage __instance, bool __0, UIPage.TransitionType __1)
        {
            if (__instance == null) return;
            ClientEventActions.OnUiPageToggled.SafetyRaiseWithParamsAndNoExceptions(__instance, __0, __1);
        }

        private static Exception OnQuickMenuIndexAssignedErrorSuppressor(Exception __exception)
        {
            // There's actually no better way to do this https://github.com/knah/Il2CppAssemblyUnhollower/blob/master/UnhollowerBaseLib/Il2CppException.cs
            if (__exception is NullReferenceException || __exception.Message.Contains("System.NullReferenceException"))
                return null;
            else
                return __exception;
        }

        /// <summary>
        /// Opens given user in the QuickMenu.
        /// </summary>
        /// <param name="playerToSelect">The player to select</param>
        internal static void OpenUserInQuickMenu(APIUser playerToSelect)
        {
            if (playerToSelect == null)
                throw new ArgumentNullException("Given APIUser was null.");
            NewMenuXrefsSystem.selectUserMethod.Invoke(UserSelectionManager.prop_UserSelectionManager_0, new object[1] { playerToSelect });
        }

        /// <summary>
        /// Opens the QuickMenu.
        /// </summary>
        internal static void OpenQuickMenu() => NewMenuXrefsSystem.openQuickMenuMethod?.Invoke(UIManagerImpl.prop_UIManagerImpl_0, null);

        /// <summary>
        /// Closes the QuickMenu.
        /// </summary>
        internal static void CloseQuickMenu() => NewMenuXrefsSystem.closeQuickMenuMethod?.Invoke(UIManagerImpl.prop_UIManagerImpl_0, new object[1] { false });

        /// <summary>
        /// Closes all open menus.
        /// </summary>
        internal static void CloseMenu() => NewMenuXrefsSystem.closeMenuMethod?.Invoke(UIManagerImpl.prop_UIManagerImpl_0, null);

        /// <summary>
        /// Closes the current open popup
        /// </summary>
        internal static void ClosePopup() => VRCUiManager.prop_VRCUiManager_0.HideScreen("POPUP");

        /// <summary>
        /// Opens a small popup v2.
        /// </summary>
        /// <param name="title">The title of the popup</param>
        /// <param name="description">The description of the popup</param>
        /// <param name="buttonText">The text of the center button</param>
        /// <param name="onButtonClick">The onClick of the center button</param>
        /// <param name="additionalSetup">A callback called when the popup is initialized</param>
        internal static void OpenSmallPopup(string title, string description, string buttonText, Action onButtonClick, Action<VRCUiPopup> additionalSetup = null) => NewMenuXrefsSystem.popupV2Small.Invoke(VRCUiPopupManager.prop_VRCUiPopupManager_0, new object[5] { title, description, buttonText, (Il2CppSystem.Action)onButtonClick, (Il2CppSystem.Action<VRCUiPopup>)additionalSetup });

        /// <summary>
        /// Opens a small popup v2 with the title "Error!".
        /// </summary>
        /// <param name="description">The description of the popup</param>
        internal static void OpenErrorPopup(string description) => OpenSmallPopup("Error!", description, "Ok", new Action(ClosePopup));

        /// <summary>
        /// Opens a small popup v2 with the title "Alert!".
        /// </summary>
        /// <param name="description">The description of the popup</param>
        internal static void OpenAlertPopup(string description) => OpenSmallPopup("Alert!", description, "Ok", new Action(ClosePopup));

        /// <summary>
        /// Opens a small popup v2.
        /// </summary>
        /// <param name="title">The title of the popup</param>
        /// <param name="description">The description of the popup</param>
        /// <param name="leftButtonText">The text of the left button</param>
        /// <param name="leftButtonClick">The onClick of the left button</param>
        /// <param name="rightButtonText">The text of the right button</param>
        /// <param name="rightButtonClick">The onClick of the right button</param>
        /// <param name="additionalSetup">A callback called when the popup is initialized</param>
        internal static void OpenPopup(string title, string description, string leftButtonText, Action leftButtonClick, string rightButtonText, Action rightButtonClick, Action<VRCUiPopup> additionalSetup = null) => NewMenuXrefsSystem.popupV2.Invoke(VRCUiPopupManager.prop_VRCUiPopupManager_0, new object[7] { title, description, leftButtonText, (Il2CppSystem.Action)leftButtonClick, rightButtonText, (Il2CppSystem.Action)rightButtonClick, (Il2CppSystem.Action<VRCUiPopup>)additionalSetup });

        ///// <summary>
        ///// Adds a button to an existing group of buttons.
        ///// </summary>
        ///// <param name="groupGameObject">The GameObject of the button group. VRChat ones generally end with the prefix "Buttons_".</param>
        ///// <param name="button">The button to add to the group</param>
        //internal  static void AddButtonToExistingGroup(GameObject groupGameObject, SingleButton button)
        //{
        //    button.gameObject.transform.SetParent(groupGameObject.transform);
        //}

        ///// <summary>
        ///// Adds a button group to an existing menu.
        ///// </summary>
        ///// <param name="menuGameObject">The GameObject of the existing menu. This should have a VerticalLayoutGroup attached.</param>
        ///// <param name="buttonGroup">The button to add to the group</param>
        //internal  static void AddButtonGroupToExistingMenu(GameObject menuGameObject, ButtonGroup buttonGroup)
        //{
        //    buttonGroup.Header.gameObject.transform.SetParent(menuGameObject.transform);
        //    buttonGroup.gameObject.transform.SetParent(menuGameObject.transform);
        //}

        /// <summary>
        /// Toggles the scrollbar on the given menu.
        /// </summary>
        /// <param name="menuGameObject">The menu to toggle the scrollbar on</param>
        /// <param name="active">Whether to enable or disable the scrollbar</param>
        internal static void ToggleScrollRectOnExistingMenu(GameObject menuGameObject, bool active)
        {
            ScrollRect scrollRect = menuGameObject.transform.parent.parent.GetComponent<ScrollRect>();
            Scrollbar scrollbar = menuGameObject.transform.parent.parent.Find("Scrollbar").GetComponent<Scrollbar>();

            scrollbar.gameObject.SetActive(active);
            scrollRect.verticalScrollbar = scrollbar;
        }

        internal delegate void ShowUiInputPopupAction(string title, string initialText, InputField.InputType inputType,
    bool isNumeric, string confirmButtonText, Il2CppSystem.Action<string, List<KeyCode>, Text> onComplete,
    Il2CppSystem.Action onCancel, string placeholderText = "Enter text...", bool closeAfterInput = true,
    Il2CppSystem.Action<VRCUiPopup> onPopupShown = null, bool bUnknown = false, int charLimit = 0);

        private static ShowUiInputPopupAction ourShowUiInputPopupAction;

        internal static ShowUiInputPopupAction ShowUiInputPopup
        {
            get
            {
                if (ourShowUiInputPopupAction != null) return ourShowUiInputPopupAction;

                var candidates = typeof(VRCUiPopupManager)
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Where(it =>
                        it.Name.StartsWith("Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_")
                        && !it.Name.EndsWith("_PDM"))
                    .ToList();

                var targetMethod = candidates.SingleOrDefault(it => XrefScanner.XrefScan(it).Any(jt =>
                    jt.Type == XrefType.Global &&
                    jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/InputPopup"));

                if (targetMethod == null)
                    targetMethod = typeof(VRCUiPopupManager).GetMethod(nameof(VRCUiPopupManager.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0),
                    BindingFlags.Instance | BindingFlags.Public);

                ourShowUiInputPopupAction = (ShowUiInputPopupAction)Delegate.CreateDelegate(typeof(ShowUiInputPopupAction), VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, targetMethod);

                return ourShowUiInputPopupAction;
            }
        }

    }
}