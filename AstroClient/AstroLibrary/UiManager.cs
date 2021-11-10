using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.DataModel;
using VRC.UI;
using VRC.UI.Elements;

namespace AstroButtonAPI
{
    using AstroClient;
    using AstroClientCore.Events;
    using AstroLibrary.Extensions;

    // This "Button API", if you can it that, is based off of RubyButtonAPI, by DubyaDude (dooba lol) (https://github.com/DubyaDude)
    /// <summary>
    /// A UiManager that contains many utilites pertaining to VRChat's UI.
    /// </summary>
    internal class UiManager : GameEvents
    {

        internal static EventHandler Event_OnQuickMenuOpen { get; set; }
        internal static EventHandler Event_OnQuickMenuClose { get; set; }

        internal static EventHandler Event_OnBigMenuOpen { get; set; }
        internal static EventHandler Event_OnBigMenuClose { get; set; }

        internal static EventHandler Event_OnUserInfoMenuOpen { get; set; }
        internal static EventHandler Event_OnUserInfoMenuClose { get; set; }

        internal static EventHandler<OnUiPageEventArgs> Event_OnUiPageToggled { get; set; }


        private static MethodInfo _popupV2;
        private static MethodInfo _popupV2Small;

        /// <summary>
        /// Called when the big menu is opened.
        /// </summary>
        internal static event Action OnBigMenuOpened;

        /// <summary>
        /// Called when the big menu is closed.
        /// </summary>
        internal static event Action OnBigMenuClosed;

        private static MethodInfo _closeBigMenu;
        private static MethodBase _openBigMenu;
        private static bool _shouldSkipPlaceUiAfterPause;
        private static bool _shouldChangeScreenStackValue;
        private static bool _newScreenStackValue;

        /// <summary>
        /// The type of the enum that is used for the big menu index.
        /// </summary>
        internal static Type BigMenuIndexEnum { get; private set; }

        /// <summary>
        /// A table that will convert the big menu index to the path of the page.
        /// </summary>
        internal static Dictionary<int, string> BigMenuIndexToPathTable { get => _bigMenuIndexToPathTable; }

        private static readonly Dictionary<int, string> _bigMenuIndexToPathTable = new Dictionary<int, string>()
        {
            { -1, "" },
            { 0, "UserInterface/MenuContent/Screens/WorldInfo" },
            { 1, "UserInterface/MenuContent/Screens/Avatar" },
            { 2, "UserInterface/MenuContent/Screens/Social" },
            { 3, "UserInterface/MenuContent/Screens/Settings" },
            { 4, "UserInterface/MenuContent/Screens/UserInfo" },
            { 5, "UserInterface/MenuContent/Screens/ImageDetails" },
            { 6, "UserInterface/MenuContent/Screens/Settings_Safety" },
            { 7, "UserInterface/MenuContent/Screens/Playlists" },
            { 8, "UserInterface/MenuContent/Screens/Playlists" },
            { 9, "UserInterface/MenuContent/Screens/VRC+" },
            { 10, "UserInterface/MenuContent/Screens/Gallery" },
        };

        /// <summary>
        /// Called when the user info menu is opened.
        /// </summary>
        internal static event Action OnUserInfoMenuOpened;

        /// <summary>
        /// Called when the user info menu is closed.
        /// </summary>
        internal static event Action OnUserInfoMenuClosed;

        /// <summary>
        /// Called when the QuickMenu is opened.
        /// </summary>
        internal static event Action OnQuickMenuOpened;

        /// <summary>
        /// Called when the QuickMenu is closed.
        /// </summary>
        internal static event Action OnQuickMenuClosed;

        /// <summary>
        /// Called when a UIPage is shown in the QuickMenu.
        /// The bool in the event is whether the page was shown or hidden.
        /// </summary>
        internal static event Action<UIPage, bool> OnUIPageToggled;

        internal static object _selectedUserManagerObject;
        private static MethodInfo _selectUserMethod;
        internal static MethodInfo _pushPageMethod;
        internal static MethodInfo _removePageMethod;

        private static MethodInfo _openQuickMenuPageMethod;
        private static MethodInfo _openQuickMenuMethod;

        private static MethodInfo _closeMenuMethod;
        private static MethodInfo _closeQuickMenuMethod;

        private static PropertyInfo _quickMenuEnumProperty;

        /// <summary>
        /// The type of the enum that is used for the QuickMenu index.
        /// </summary>
        internal static Type QuickMenuIndexEnum { get; private set; }

        internal static Transform tempUIParent;

        /// <summary>
        /// The QuickMenu MenuStateController used by VRChat
        /// </summary>
        internal static MenuStateController QMStateController { get; private set; }


        internal override void ExecutePriorityPatches()
        {
            Init();
        }

        internal override void VRChat_OnQuickMenuInit()
        {
            UiInit();
        }




        internal static void Init()
        {
            List<Type> quickMenuNestedEnums = typeof(QuickMenu).GetNestedTypes().Where(type => type.IsEnum).ToList();
            _quickMenuEnumProperty = typeof(QuickMenu).GetProperties()
                .First(pi => pi.PropertyType.IsEnum && quickMenuNestedEnums.Contains(pi.PropertyType));
            QuickMenuIndexEnum = _quickMenuEnumProperty.PropertyType;

            BigMenuIndexEnum = quickMenuNestedEnums.First(type => type.IsEnum && type != QuickMenuIndexEnum);
            _closeBigMenu = typeof(VRCUiManager).GetMethods()
                .First(mb => mb.Name.StartsWith("Method_Public_Void_Boolean_Boolean_") && !mb.Name.Contains("_PDM_") && XrefUtils.CheckUsedBy(mb, "ChangeToSelectedAvatar"));
            _openBigMenu = typeof(VRCUiManager).GetMethods()
                .First(mb => mb.Name.StartsWith("Method_Public_Void_Boolean_Boolean_") && !mb.Name.Contains("_PDM_") && XrefUtils.CheckStrings(mb, "UserInterface/MenuContent/Backdrop/Backdrop"));

            MethodInfo _placeUiAfterPause = typeof(QuickMenu).GetNestedTypes().First(type => type.Name.Contains("IEnumerator")).GetMethod("MoveNext");

            new AstroPatch(typeof(UIPage).GetMethod("Method_Public_Void_Boolean_TransitionType_0"), new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnUIPageToggle), BindingFlags.NonPublic | BindingFlags.Static)));
            new AstroPatch(_openBigMenu, null, new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnBigMenuOpen_Event), BindingFlags.NonPublic | BindingFlags.Static)));
            new AstroPatch(_closeBigMenu, null, new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnBigMenuClose_Event), BindingFlags.NonPublic | BindingFlags.Static)));
            new AstroPatch(_placeUiAfterPause, new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnPlaceUiAfterPause), BindingFlags.NonPublic | BindingFlags.Static)));
            new AstroPatch(typeof(VRCUiManager).GetMethod("Method_Public_Void_String_Boolean_0"), new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnShowScreen), BindingFlags.NonPublic | BindingFlags.Static)));

            foreach (MethodInfo method in typeof(MenuController).GetMethods().Where(mi => mi.Name.StartsWith("Method_Public_Void_APIUser_") && !mi.Name.Contains("_PDM_")))
                new AstroPatch(method, null, new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnUserInfoOpen_event), BindingFlags.NonPublic | BindingFlags.Static)));
            new AstroPatch(AccessTools.Method(typeof(PageUserInfo), "Back"), null, new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnUserInfoClose), BindingFlags.NonPublic | BindingFlags.Static)));

            _closeMenuMethod = typeof(UIManagerImpl).GetMethods()
                .First(method => method.Name.StartsWith("Method_Public_Virtual_Final_New_Void_") && XrefScanner.XrefScan(method).Count() == 2);
            _closeQuickMenuMethod = typeof(UIManagerImpl).GetMethods()
                .First(method => method.Name.StartsWith("Method_Public_Void_Boolean_") && XrefUtils.CheckUsedBy(method, _closeMenuMethod.Name));
            new AstroPatch(_closeQuickMenuMethod, null, new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnQuickMenuClose_Event), BindingFlags.NonPublic | BindingFlags.Static)));

            _openQuickMenuMethod = typeof(UIManagerImpl).GetMethods()
                .First(method => method.Name.StartsWith("Method_Public_Void_Boolean_") && method.Name.Length <= 29 && XrefUtils.CheckUsing(method, "Method_Private_Void_"));
            _openQuickMenuPageMethod = typeof(UIManagerImpl).GetMethods()
                .First(method => method.Name.StartsWith("Method_Public_Virtual_Final_New_Void_String_") && XrefUtils.CheckUsing(method, _openQuickMenuMethod.Name, _openQuickMenuMethod.DeclaringType));

            // Patching the other method doesn't work for some reason you have to patch this
            MethodInfo _onQuickMenuOpenedMethod = typeof(UIManagerImpl).GetMethods()
                .First(method => method.Name.StartsWith("Method_Private_Void_Boolean_") && !method.Name.Contains("_PDM_") && XrefUtils.CheckUsedBy(method, _openQuickMenuMethod.Name));
            new AstroPatch(_onQuickMenuOpenedMethod, null, new HarmonyMethod(typeof(UiManager).GetMethod(nameof(OnQuickMenuOpen_Event), BindingFlags.NonPublic | BindingFlags.Static)));

            _popupV2Small = typeof(VRCUiPopupManager).GetMethods()
                .First(mb => mb.Name.StartsWith("Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_") && !mb.Name.Contains("PDM") && XrefUtils.CheckStrings(mb, "UserInterface/MenuContent/Popups/StandardPopupV2") && XrefUtils.CheckUsedBy(mb, "OpenSaveSearchPopup"));
            _popupV2 = typeof(VRCUiPopupManager).GetMethods()
                .First(mb => mb.Name.StartsWith("Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_") && !mb.Name.Contains("PDM") && XrefUtils.CheckStrings(mb, "UserInterface/MenuContent/Popups/StandardPopupV2"));
        }

        internal static void UiInit()
        {
            tempUIParent = new GameObject("AstroClientTempUIParent").transform;
            GameObject.DontDestroyOnLoad(tempUIParent.gameObject);

            QMStateController = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)").GetComponent<MenuStateController>();

            // index 0 works because transform doesn't inherit from monobehavior
            _selectedUserManagerObject = GameObject.Find("_Application/UIManager/SelectedUserManager").GetComponent<UserSelectionManager>();

            _selectUserMethod = typeof(UserSelectionManager).GetMethods()
                .First(method => method.Name.StartsWith("Method_Public_Void_APIUser_") && !method.Name.Contains("_PDM_") && XrefUtils.CheckUsedBy(method, "Method_Public_Virtual_Final_New_Void_IUser_"));

            MethodInfo[] pageMethods = typeof(UIPage).GetMethods()
                .Where(method => method.Name.StartsWith("Method_Public_Void_UIPage_") && !method.Name.Contains("_PDM_"))
                .ToArray();
            _pushPageMethod = pageMethods.First(method => XrefUtils.CheckUsing(method, "Add"));
            _removePageMethod = pageMethods.First(method => method != _pushPageMethod);
        }

        private static void OnBigMenuOpen_Event() => Event_OnBigMenuOpen.SafetyRaise();

        private static void OnBigMenuClose_Event() => Event_OnBigMenuClose.SafetyRaise();

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
            VRCUiManager.field_Private_Static_VRCUiManager_0.Method_Public_Void_String_Boolean_0(_bigMenuIndexToPathTable[index]);
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
        internal static void CloseBigMenu() => _closeBigMenu.Invoke(VRCUiManager.prop_VRCUiManager_0, new object[2] { true, false });

        /// <summary>
        /// Opens the big menu.
        /// </summary>
        internal static void OpenBigMenu() => OpenBigMenu(true);

        /// <summary>
        /// Opens the big menu
        /// </summary>
        /// <param name="showDefaultScreen">Whether to show the world menu after opening the big menu</param>
        internal static void OpenBigMenu(bool showDefaultScreen) => _openBigMenu.Invoke(VRCUiManager.prop_VRCUiManager_0, new object[2] { showDefaultScreen, true });

        private static void OnUserInfoOpen_event() => Event_OnUserInfoMenuOpen.SafetyRaise();

        private static void OnUserInfoClose() => Event_OnUserInfoMenuClose.SafetyRaise();

        private static void OnQuickMenuOpen_Event() => Event_OnQuickMenuOpen.SafetyRaise();

        private static void OnQuickMenuClose_Event() => Event_OnQuickMenuClose.SafetyRaise();

        private static void OnUIPageToggle(UIPage __instance, bool __0) => Event_OnUiPageToggled.SafetyRaise(new OnUiPageEventArgs(__instance, __0));

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
            _selectUserMethod.Invoke(UserSelectionManager.prop_UserSelectionManager_0, new object[1] { playerToSelect });
        }

        /// <summary>
        /// Opens the QuickMenu.
        /// </summary>
        internal static void OpenQuickMenu() => _openQuickMenuMethod?.Invoke(UIManagerImpl.prop_UIManagerImpl_0, null);

        /// <summary>
        /// Closes the QuickMenu.
        /// </summary>
        internal static void CloseQuickMenu() => _closeQuickMenuMethod?.Invoke(UIManagerImpl.prop_UIManagerImpl_0, new object[1] { false });

        /// <summary>
        /// Closes all open menus.
        /// </summary>
        internal static void CloseMenu() => _closeMenuMethod?.Invoke(UIManagerImpl.prop_UIManagerImpl_0, null);

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
        internal static void OpenSmallPopup(string title, string description, string buttonText, Action onButtonClick, Action<VRCUiPopup> additionalSetup = null) => _popupV2Small.Invoke(VRCUiPopupManager.prop_VRCUiPopupManager_0, new object[5] { title, description, buttonText, (Il2CppSystem.Action)onButtonClick, (Il2CppSystem.Action<VRCUiPopup>)additionalSetup });

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
        internal static void OpenPopup(string title, string description, string leftButtonText, Action leftButtonClick, string rightButtonText, Action rightButtonClick, Action<VRCUiPopup> additionalSetup = null) => _popupV2.Invoke(VRCUiPopupManager.prop_VRCUiPopupManager_0, new object[7] { title, description, leftButtonText, (Il2CppSystem.Action)leftButtonClick, rightButtonText, (Il2CppSystem.Action)rightButtonClick, (Il2CppSystem.Action<VRCUiPopup>)additionalSetup });

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
    }
}