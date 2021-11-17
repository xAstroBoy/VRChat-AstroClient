namespace AstroClient.xAstroBoy.AstroButtonAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Menus;
    using Color = System.Drawing.Color;

    internal static class QuickMenuTools
    {
        //Templates and references
        internal static bool SelectSelf = false;

        private static Transform _UserInterface;
        private static BoxCollider QuickMenuBackgroundReference = null;
        private static Transform SingleButtonReference = null;
        private static Vector3? _SingleButtonReferencePosition;
        private static Transform _ToggleButtonReference;
        private static Transform _NestedButtonReference;
        private static Transform SelectedUserPageReference;
        private static Transform SelectedUserPageButtonsReference;
        private static Transform _NestedPagesReference;
        private static Transform MenuDashboardReference;
        private static Transform _TabButtonReference;
        private static Transform _QuickMenuTransform;
        private static Transform HeaderDashboardReference;
        private static Transform _SliderReference;
        private static Transform _ToolTipPanel;
        private static Transform _TabMenuReference;

        private static Transform _SingleButtonTemplate;

        //VRC
        private static Transform _CarouselBanners;

        private static QuickMenu _QuickMenuInstance;
        internal static VRCUiManager vrcuimInstance = null; // Dead
        private static GameObject shortcutMenu = null;
        private static GameObject userInteractMenu = null;
        private static GameObject _SelectedUserPage = null;
        private static UIPage UIPageReference_Right;
        private static UIPage UIPageReference_Left;
        private static Wing WingmenuInstance = null;
        private static Wing _Wing_Right;
        private static Wing _Wing_Left;
        private static GameObject WingButtonReferenceRight;
        private static GameObject WingPageButtonReferenceLeft;
        private static GameObject WingPageButtonReference;
        private static MenuStateController MenuStateController_Wing_Right;
        private static MenuStateController MenuStateController_Wing_Left;
        private static MenuStateController _QuickMenuControllert;
        private static SelectedUserMenuQM _SelectedQMGO;
        private static UIPage _QuickMenuPage;

        private static GameObject DebugPanelReference;

        internal static Transform QuickMenuTransform
        {
            get
            {
                if (UserInterface == null) return null;
                if (_QuickMenuTransform == null) return _QuickMenuTransform = UserInterface.Find("Canvas_QuickMenu(Clone)");

                return _QuickMenuTransform;
            }
        }

        internal static QuickMenu QuickMenuInstance
        {
            get
            {
                if (UserInterface == null || QuickMenuTransform == null) return null;
                if (_QuickMenuInstance == null)
                {
                    var test = QuickMenuTransform.GetComponentInChildren<QuickMenu>(true);
                    if (test != null) ModConsole.DebugLog("Found QuickMenu Instance!", Color.Chartreuse);

                    return _QuickMenuInstance = test;
                }

                return _QuickMenuInstance;
            }
        }

        //internal static BoxCollider QuickMenuBackground()
        //{
        //    if (QuickMenuBackgroundReference == null)
        //        QuickMenuBackgroundReference = QuickMenuTransform.transform.Find("Container/Button_Worlds").GetComponent<BoxCollider>();
        //    return QuickMenuBackgroundReference;
        //}

        internal static Vector2 SingleButtonDefaultSize => new Vector2(200, 176);

        internal static Vector2 SingleButtonTemplatePos => new Vector2(-110, -88);

        internal static Transform SingleButtonTemplate
        {
            get
            {
                if (_SingleButtonTemplate == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Button>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Button_VoteKick")
                            _SingleButtonTemplate = button.transform;
                }

                return _SingleButtonTemplate;
            }
        }

        internal static Vector3? SingleButtonTemplatePosition
        {
            get
            {
                if (_SingleButtonReferencePosition == null) return _SingleButtonReferencePosition = SingleButtonTemplate.transform.position;

                return _SingleButtonReferencePosition;
            }
        }

        internal static Transform UserInterface
        {
            get
            {
                if (_UserInterface == null) return _UserInterface = GameObject.Find("UserInterface").transform;
                return _UserInterface;
            }
        }

        internal static UIPage QuickMenuPage
        {
            get
            {
                if (_QuickMenuPage == null)
                    foreach (var item in QuickMenuInstance.GetComponentsInChildren<UIPage>(true))
                        if (item.name == "Menu_Camera")
                            return _QuickMenuPage = item;

                return _QuickMenuPage;
            }
        }


        internal static Transform TabButtonTemplate
        {
            get
            {
                if (_TabButtonReference == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Button>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Page_Settings")
                        {
                            ModConsole.DebugLog("Found Tab Settings!", Color.Chartreuse);
                            return _TabButtonReference = button.transform;
                        }
                }

                return _TabButtonReference;
            }
        }

        internal static Transform TabMenu
        {
            get
            {
                if (_TabMenuReference == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Page_Buttons_QM")
                        {
                            ModConsole.DebugLog("Found Tab Menu!", Color.Chartreuse);
                            return _TabMenuReference = button.transform;
                        }
                }

                return _TabMenuReference;
            }
        }


        internal static Transform ToolTipPanel
        {
            get
            {
                if (_ToolTipPanel == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "ToolTipPanel")
                        {
                            ModConsole.DebugLog("Found ToolTip Panel!", Color.Chartreuse);
                            return _ToolTipPanel = button.transform;
                        }
                }

                return _ToolTipPanel;
            }
        }

        public static Transform SliderTemplate
        {
            get
            {
                if (_SliderReference == null)
                {
                    //
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "VolumeSlider_Master")
                        {
                            ModConsole.DebugLog("Found Slider Template!", Color.Chartreuse);
                            return _SliderReference = button;
                        }
                }

                return _SliderReference;
            }
        }

        internal static Transform ToggleButtonTemplate
        {
            get
            {
                if (_ToggleButtonReference == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Button_ToggleTooltips")
                        {
                            ModConsole.DebugLog("Found ToolTips button!", Color.Chartreuse);
                            return _ToggleButtonReference = button;
                        }
                }

                return _ToggleButtonReference;
            }
        }

        internal static Transform NestedMenuTemplate
        {
            get
            {
                if (QuickMenuTransform == null) return null;
                if (_NestedButtonReference == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Menu_Camera")
                        {
                            ModConsole.DebugLog("Found Camera Page!", Color.Chartreuse);
                            return _NestedButtonReference = button;
                        }
                }

                return _NestedButtonReference;
            }
        }

        internal static Transform NestedPages
        {
            get
            {
                if (_NestedPagesReference == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "QMParent")
                        {
                            return _NestedPagesReference = button;
                            break;
                        }
                }

                return _NestedPagesReference;
            }
        }

        //New shit

        internal static SelectedUserMenuQM GetSelectedUserQMInstance()
        {
            if (_SelectedQMGO == null) _SelectedQMGO = QuickMenuTransform.gameObject.FindObject("Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>();

            return _SelectedQMGO;
        }

        internal static UIPage UIPageTemplate_Right()
        {
            if (UIPageReference_Right == null)
            {
                var Buttons = Wing_Right().GetComponentsInChildren<UIPage>(true);
                foreach (var button in Buttons)
                    if (button.name == "Friends")
                    {
                        UIPageReference_Right = button;
                        break;
                    }
            }

            return UIPageReference_Right;
        }

        internal static UIPage UIPageTemplate_Left()
        {
            if (UIPageReference_Left == null)
            {
                var Buttons = Wing_Left().GetComponentsInChildren<UIPage>(true);
                foreach (var button in Buttons)
                    if (button.name == "Friends")
                    {
                        UIPageReference_Left = button;
                        break;
                    }
            }

            return UIPageReference_Left;
        }

        internal static GameObject DebugPanelTemplate()
        {
            if (DebugPanelReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<DebugInfoPanel>(true);
                foreach (var button in Buttons)
                    if (button.name == "DebugInfoPanel")
                    {
                        DebugPanelReference = button.gameObject;
                        break;
                    }
            }

            return DebugPanelReference;
        }

        internal static MenuStateController WingMenuStateControllerRight()
        {
            if (MenuStateController_Wing_Right == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<MenuStateController>(true);
                foreach (var button in Buttons)
                    if (button.name == "Wing_Right")
                    {
                        MenuStateController_Wing_Right = button;
                        break;
                    }
            }

            return MenuStateController_Wing_Right;
        }

        internal static MenuStateController WingMenuStateControllerLeft()
        {
            if (MenuStateController_Wing_Left == null)
            {
                var Buttons = QuickMenuInstance.GetComponentsInChildren<MenuStateController>(true);
                foreach (var button in Buttons)
                    if (button.name == "Wing_Left")
                    {
                        MenuStateController_Wing_Left = button;
                        break;
                    }
            }

            return MenuStateController_Wing_Left;
        }

        internal static Wing Wing_Left()
        {
            if (_Wing_Left == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Wing>(true);
                foreach (var button in Buttons)
                    if (button.name == "Wing_Left")
                    {
                        _Wing_Left = button;
                        break;
                    }
            }

            return _Wing_Left;
        }

        internal static Wing Wing_Right()
        {
            if (_Wing_Right == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Wing>(true);
                foreach (var button in Buttons)
                    if (button.name == "Wing_Right")
                    {
                        _Wing_Right = button;
                        break;
                    }
            }

            return _Wing_Right;
        }

        internal static MenuStateController QuickMenuController()
        {
            if (_QuickMenuControllert == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<MenuStateController>(true);
                foreach (var button in Buttons)
                    if (button.name == "Canvas_QuickMenu(Clone)")
                    {
                        _QuickMenuControllert = button;
                        break;
                    }
            }

            return _QuickMenuControllert;
        }

        internal static Transform Carousel_Banners()
        {
            if (_CarouselBanners == null)
            {
                var Transforms = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var transform in Transforms)
                    if (transform.name == "Carousel_Banners")
                    {
                        _CarouselBanners = transform;
                        break;
                    }
            }

            return _CarouselBanners;
        }

        internal static Transform Header_DashboardTemplate()
        {
            if (HeaderDashboardReference == null)
            {
                var Transforms = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var transform in Transforms)
                    if (transform.name == "Header_QuickLinks")
                        HeaderDashboardReference = transform;

                ;
            }

            return HeaderDashboardReference;
        }


        internal static GameObject WingPageButtonTemplate()
        {
            if (WingPageButtonReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                    if (button.name == "Button_ActionMenu")
                    {
                        WingPageButtonReference = button.gameObject;
                        break;
                    }
            }

            return WingPageButtonReference;
        }

        internal static GameObject WingButtonTemplate_Right()
        {
            if (WingButtonReferenceRight == null)
            {
                var Buttons = Wing_Right().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                    if (button.name == "Button_Profile")
                    {
                        WingButtonReferenceRight = button.gameObject;
                        break;
                    }

                ;
            }

            return WingButtonReferenceRight;
        }

        internal static GameObject WingButtonTemplate_Left()
        {
            if (WingPageButtonReferenceLeft == null)
            {
                var Buttons = Wing_Left().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                    if (button.name == "Button_Profile")
                    {
                        WingPageButtonReferenceLeft = button.gameObject;
                        break;
                    }
            }

            return WingPageButtonReferenceLeft;
        }

        internal static Transform SelectedUserPage()
        {
            if (SelectedUserPageReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                    if (button.name == "Header_UserActions")
                    {
                        SelectedUserPageReference = button;
                        break;
                    }
            }

            return SelectedUserPageReference;
        }

        internal static Transform SelectedUserPage_ButtonsSection()
        {
            if (SelectedUserPageButtonsReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                    if (button.name == "Buttons_UserActions")
                    {
                        SelectedUserPageButtonsReference = button;
                        break;
                    }
            }

            return SelectedUserPageButtonsReference;
        }

        internal static Transform MenuDashboard_ButtonsSection()
        {
            if (MenuDashboardReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                    if (button.name == "Buttons_QuickActions")
                    {
                        MenuDashboardReference = button;
                        break;
                    }
            }

            return MenuDashboardReference;
        }

        internal static void ShowQuickmenuPage(string pagename)
        {
            QuickMenuController().PushPage(pagename);
        }

        internal static void NoShader(QMSingleButton x)
        {
            x.GetGameObject().GetComponent<Button>().name = "NoShader";
        }

        internal static void NoShader(QMNestedButton x)
        {
            x.GetMainButton().GetGameObject().GetComponent<Button>().name = "NoShader";
        }
    }
}