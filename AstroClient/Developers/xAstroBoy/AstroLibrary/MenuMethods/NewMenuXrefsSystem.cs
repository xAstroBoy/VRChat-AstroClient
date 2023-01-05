using AstroClient.xAstroBoy.AstroButtonAPI.Tools;

namespace AstroClient.xAstroBoy.MenuMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Tools;
    using UnhollowerRuntimeLib.XrefScans;
    using UnityEngine;
    using VRC.DataModel;
    using VRC.UI;
    using VRC.UI.Elements;
    using UiManagerImpl = UIManagerPublicBoObBoAc1BoAcGa1MeUnique;
    internal static class NewMenuXrefsSystem
    {


        private static MethodInfo _popupV2;
        internal static MethodInfo popupV2
        {
            get
            {
                if (_popupV2 == null)
                {
                    return _popupV2 = typeof(VRCUiPopupManager).GetMethods()
                        .First(mb => mb.Name.StartsWith("Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_") 
                                     && !mb.Name.Contains("PDM") 
                                     && XrefUtils.CheckStrings(mb, "UserInterface/MenuContent/Popups/StandardPopupV2"));
                }
                return _popupV2;
            }
        }

        private static MethodInfo _popupV2Small;
        internal static MethodInfo popupV2Small
        {
            get
            {
                if (_popupV2Small == null)
                {
                    return _popupV2Small = typeof(VRCUiPopupManager).GetMethods()
                        .First(mb => mb.Name.StartsWith("Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_") && !mb.Name.Contains("PDM") && XrefUtils.CheckStrings(mb, "UserInterface/MenuContent/Popups/StandardPopupV2") && XrefUtils.CheckUsedBy(mb, "OpenSaveSearchPopup"));

                }
                return _popupV2Small;
            }
        }

        //private static MethodInfo _closeBigMenu;
        //internal static MethodInfo closeBigMenu
        //{
        //    get
        //    {
        //        if (_closeBigMenu == null)
        //        {
        //            return _closeBigMenu = typeof(VRCUiManager).GetMethods()
        //                .First(mb => mb.Name.StartsWith("Method_Public_Void_Boolean_Boolean_") 
        //                             && !mb.Name.Contains("_PDM_") 
        //                             && XrefUtils.CheckUsedBy(mb, "ChangeToSelectedAvatar"));

        //        }
        //        return _closeBigMenu;
        //    }
        //}

        //private static MethodInfo _openBigMenu;
        //internal static MethodInfo openBigMenu
        //{
        //    get
        //    {
        //        if (_openBigMenu == null)
        //        {
        //            return _openBigMenu = typeof(VRCUiManager).GetMethods()
        //                .First(mb => mb.Name.StartsWith("Method_Public_Void_Boolean_Boolean_") 
        //                             && !mb.Name.Contains("_PDM_") 
        //                             && XrefUtils.CheckStrings(mb, "UserInterface/MenuContent/Backdrop/Backdrop"));

        //        }
        //        return _openBigMenu;
        //    }
        //}
        private static MethodInfo _selectUserMethod;
        internal static MethodInfo selectUserMethod
        {
            get
            {
                if (_selectUserMethod == null)
                {
                    return _selectUserMethod = typeof(Helper.EventPump).GetMethods()
                .First(method => method.Name.StartsWith("Method_Public_Void_APIUser_") && !method.Name.Contains("_PDM_")
                && XrefUtils.CheckUsedBy(method, "Method_Public_Void_VRCPlayer_")
                && XrefUtils.CheckUsedBy(method, "Method_Public_Virtual_Final_New_Void_IUser_"));

                }
                return _selectUserMethod;
            }
        }
        private static MethodInfo[] _pageMethods;
        internal static MethodInfo[] pageMethods
        {
            get
            {
                if (_pageMethods == null)
                {
                    return _pageMethods = typeof(UIPage).GetMethods()
                        .Where(method => method.Name.StartsWith("Method_Public_Void_UIPage_") && !method.Name.Contains("_PDM_"))
                        .ToArray();

                }
                return _pageMethods;
            }
        }
        private static MethodInfo _pushPageMethod;
        internal static MethodInfo pushPageMethod
        {
            get
            {
                if (_pushPageMethod == null)
                {
                    return _pushPageMethod = pageMethods.First(method => XrefUtils.CheckUsing(method, "Add"));

                }
                return _pushPageMethod;
            }
        }
        private static MethodInfo _removePageMethod;
        internal static MethodInfo removePageMethod
        {
            get
            {
                if (_removePageMethod == null)
                {
                    return _removePageMethod = pageMethods.First(method => method != _pushPageMethod);

                }
                return _removePageMethod;
            }
        }
        private static MethodInfo _openQuickMenuPageMethod;
        internal static MethodInfo openQuickMenuPageMethod
        {
            get
            {
                if (_openQuickMenuPageMethod == null)
                {
                    return _openQuickMenuPageMethod = typeof(UiManagerImpl).GetMethods()
                        .First(method => method.Name.StartsWith("Method_Public_Virtual_Final_New_Void_String_") && XrefUtils.CheckUsing(method, openQuickMenuMethod.Name, openQuickMenuMethod.DeclaringType));

                }
                return _openQuickMenuPageMethod;
            }
        }

        private static MethodInfo _onQuickMenuOpenedMethod;
        internal static MethodInfo onQuickMenuOpenedMethod
        {
            get
            {
                if (_onQuickMenuOpenedMethod == null)
                {
                    return _onQuickMenuOpenedMethod = typeof(UiManagerImpl).GetMethods()
                        .First(method => method.Name.StartsWith("Method_Private_Void_Boolean_") && !method.Name.Contains("_PDM_") && XrefUtils.CheckUsedBy(method, openQuickMenuMethod.Name));

                }
                return _onQuickMenuOpenedMethod;
            }
        }
        private static MethodInfo _openQuickMenuMethod;
        internal static MethodInfo openQuickMenuMethod
        {
            get
            {
                if (_openQuickMenuMethod == null)
                {
                    return _openQuickMenuMethod = typeof(UiManagerImpl).GetMethods()
                        .First(method => method.Name.StartsWith("Method_Public_Void_Boolean_") && 
                                         method.Name.Length <= 29 &&
                                         XrefUtils.CheckUsing(method, "Method_Private_Void_"));

                }
                return _openQuickMenuMethod;
            }
        }

        private static MethodInfo _closeMenuMethod;
        internal static MethodInfo closeMenuMethod
        {
            get
            {
                if (_closeMenuMethod == null)
                {
                    return _closeMenuMethod = typeof(UiManagerImpl).GetMethods()
                        .First(method => method.Name.StartsWith("Method_Public_Virtual_Final_New_Void_") && XrefScanner.XrefScan(method).Count() == 2);

                }
                return _closeMenuMethod;
            }
        }
        private static MethodInfo _closeQuickMenuMethod;
        internal static MethodInfo closeQuickMenuMethod
        {
            get
            {
                if (_closeQuickMenuMethod == null)
                {
                    return _closeQuickMenuMethod = typeof(UiManagerImpl).GetMethods()
                        .First(method => method.Name.StartsWith("Method_Public_Void_Boolean_") && XrefUtils.CheckUsedBy(method, closeMenuMethod.Name));

                }
                return _closeQuickMenuMethod;
            }
        }


        private static PropertyInfo _quickMenuEnumProperty;
        internal static PropertyInfo quickMenuEnumProperty
        {
            get
            {
                if (_quickMenuEnumProperty == null)
                {
                    return _quickMenuEnumProperty = typeof(QuickMenu).GetProperties()
                        .First(pi => pi.PropertyType.IsEnum && quickMenuNestedEnums.Contains(pi.PropertyType));

                }
                return _quickMenuEnumProperty;
            }
        }
        private static Type _BigMenuIndexEnum;
        /// <summary>
        /// The type of the enum that is used for the big menu index.
        /// </summary>
        internal static Type BigMenuIndexEnum
        {
            get
            {
                if (_BigMenuIndexEnum == null)
                {
                    return _BigMenuIndexEnum = quickMenuNestedEnums.First(type => type.IsEnum && type != QuickMenuIndexEnum); ;

                }
                return _BigMenuIndexEnum;
            }
        }

        private static Type _QuickMenuIndexEnum;

        /// <summary>
        /// The type of the enum that is used for the QuickMenu index.
        /// </summary>
        internal static Type QuickMenuIndexEnum
        {
            get
            {
                if (_QuickMenuIndexEnum == null)
                {
                    return _QuickMenuIndexEnum = quickMenuEnumProperty.PropertyType;

                }
                return _QuickMenuIndexEnum;
            }
        }
        private static List<Type> _quickMenuNestedEnums;
        internal static List<Type> quickMenuNestedEnums
        {
            get
            {
                if (_quickMenuNestedEnums == null)
                {
                    return _quickMenuNestedEnums = typeof(QuickMenu).GetNestedTypes().Where(type => type.IsEnum).ToList();
                }
                return _quickMenuNestedEnums;
            }
        }
        private static MethodInfo _placeUiAfterPause;
        internal static MethodInfo placeUiAfterPause
        {
            get
            {
                if (_placeUiAfterPause == null)
                {
                    return _placeUiAfterPause = typeof(QuickMenu).GetNestedTypes().First(type => type.Name.Contains("IEnumerator")).GetMethod("MoveNext");

                }
                return _placeUiAfterPause;
            }
        }

        private static object _selectedUserManagerObject;
        internal static object selectedUserManagerObject
        {
            get
            {
                if (_selectedUserManagerObject == null)
                {
                    return _selectedUserManagerObject = GameObject.Find($"{QuickMenuTools.Application.name}/UIManager/SelectedUserManager").GetComponent<Helper.EventPump>();

                }
                return _selectedUserManagerObject;
            }
        }

        private static MenuStateController _QMStateController;

        /// <summary>
        /// The QuickMenu MenuStateController used by VRChat
        /// </summary>
        internal static MenuStateController QMStateController
        {
            get
            {
                if (_QMStateController == null)
                {
                    return _QMStateController = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)").GetComponent<MenuStateController>();

                }
                return _QMStateController;

            }
        }

        /// <summary>
        /// A table that will convert the big menu index to the path of the page.
        /// </summary>
        internal static Dictionary<int, string> BigMenuIndexToPathTable { get => _BigMenuIndexToPathTable; }

        /// <summary>
        /// A table that will convert the big menu index to the path of the page.
        /// </summary>
        private static readonly Dictionary<int, string> _BigMenuIndexToPathTable = new Dictionary<int, string>()
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

    }
}
