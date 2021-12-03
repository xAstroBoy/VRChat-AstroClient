namespace AstroClient.xAstroBoy.AstroButtonAPI.Tools
{
    using QuickMenuAPI;
    using UnityEngine;
    using UnityEngine.UI;
    using Utility;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Menus;
    using Color = System.Drawing.Color;

    internal static class QuickMenuTools
    {
        //Templates and references
        internal static bool SelectSelf = false;

        private static Transform _UserInterface;
        private static BoxCollider _QuickMenuBackground = null;
        private static Transform SingleButtonReference = null;
        private static Vector3? _SingleButtonTemplatePosition;
        private static Transform _ToggleButtonTemplate;
        private static Transform _NestedMenuTemplate;
        private static Transform SelectedUserPageReference;
        private static Transform _SelectedUserPage_ButtonsSection;
        private static Transform _NestedPages;
        private static Transform _MenuDashboard_ButtonsSection;
        private static Transform _TabButtonTemplate;
        private static Transform _QuickMenuTransform;
        private static Transform _Header_DashboardTemplate;
        private static Transform _SliderTemplate;
        private static Transform _ToolTipPanel;
        private static Transform _TabMenu;
        private static Transform _MenuDashboard;

        private static Transform _SingleButtonTemplate;

        //VRC
        private static Transform _Carousel_Banners;

        private static QuickMenu _QuickMenuInstance;
        internal static VRCUiManager vrcuimInstance = null; // Dead
        private static GameObject shortcutMenu = null;
        private static GameObject userInteractMenu = null;
        private static Transform _SelectedUserPage_Remote = null;
        private static Transform _SelectedUserPage_Local = null;

        private static Transform _SelectedUserPage_Remote_VerticalLayoutGroup = null;
        private static Transform _SelectedUserPage_Local_VerticalLayoutGroup = null;
        private static Transform _MenuDashboard_VerticalLayoutGroup = null;

        private static UIPage _UIPageTemplate_Right;
        private static UIPage _UIPageTemplate_Left;
        private static Wing WingmenuInstance = null;
        private static Wing _Wing_Right;
        private static Wing _Wing_Left;
        private static GameObject _WingButtonTemplate_Right;
        private static GameObject _WingButtonTemplate_Left;
        private static GameObject _WingPageButtonTemplate;
        private static MenuStateController _WingMenuStateControllerRight;
        private static MenuStateController _WingMenuStateControllerLeft;
        private static MenuStateController _QuickMenuController;
        private static SelectedUserMenuQM _SelectedUserMenuQM;
        private static UIPage _QuickMenuPage;

        private static GameObject _DebugPanelTemplate;

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
                if (_QuickMenuInstance == null)
                {
                    var test = UnityUtils.FindInactiveObjectInActiveRoot("UserInterface/Canvas_QuickMenu(Clone)")?.GetComponent<QuickMenu>();
                    if (test != null) ModConsole.DebugLog("Found QuickMenu Instance!", Color.Chartreuse);

                    return _QuickMenuInstance = test;
                }

                return _QuickMenuInstance;
            }
        }

        internal static BoxCollider QuickMenuBackground
        {
            get
            {
                if (_QuickMenuBackground == null)
                    _QuickMenuBackground = QuickMenuTransform.transform.Find("Container/Button_Worlds").GetComponent<BoxCollider>();
                return _QuickMenuBackground;
            }
        }

        internal static Vector2 SingleButtonDefaultSize => new(200, 176);

        internal static Vector2 SingleButtonTemplatePos => new(-110, -88);

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
                if (_SingleButtonTemplatePosition == null) return _SingleButtonTemplatePosition = SingleButtonTemplate.transform.position;

                return _SingleButtonTemplatePosition;
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
                if (_TabButtonTemplate == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Button>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Page_Settings")
                        {
                            ModConsole.DebugLog("Found Tab Settings!", Color.Chartreuse);
                            return _TabButtonTemplate = button.transform;
                        }
                }

                return _TabButtonTemplate;
            }
        }

        internal static Transform TabMenu
        {
            get
            {
                if (_TabMenu == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Page_Buttons_QM")
                        {
                            ModConsole.DebugLog("Found Tab Menu!", Color.Chartreuse);
                            return _TabMenu = button.transform;
                        }
                }

                return _TabMenu;
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
                if (_SliderTemplate == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "VolumeSlider_Master")
                        {
                            ModConsole.DebugLog("Found Slider Template!", Color.Chartreuse);
                            return _SliderTemplate = button;
                        }
                }

                return _SliderTemplate;
            }
        }

        internal static Transform ToggleButtonTemplate
        {
            get
            {
                if (_ToggleButtonTemplate == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Button_ToggleTooltips")
                        {
                            ModConsole.DebugLog("Found ToolTips button!", Color.Chartreuse);
                            return _ToggleButtonTemplate = button;
                        }
                }

                return _ToggleButtonTemplate;
            }
        }

        internal static Transform NestedMenuTemplate
        {
            get
            {
                if (QuickMenuTransform == null) return null;
                if (_NestedMenuTemplate == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Menu_Camera")
                        {
                            ModConsole.DebugLog("Found Camera Page!", Color.Chartreuse);
                            return _NestedMenuTemplate = button;
                        }
                }

                return _NestedMenuTemplate;
            }
        }

        internal static Transform MenuDashboard
        {
            get
            {
                if (QuickMenuTransform == null) return null;
                if (_MenuDashboard == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Menu_Dashboard")
                        {
                            ModConsole.DebugLog("Found Dashboard Page!", Color.Chartreuse);
                            return _MenuDashboard = button;
                        }
                }

                return _MenuDashboard;
            }
        }

        internal static Transform MenuDashboard_VerticalLayoutGroup
        {
            get
            {
                if (QuickMenuTransform == null) return null;
                if (_MenuDashboard_VerticalLayoutGroup == null)
                {
                    return _MenuDashboard_VerticalLayoutGroup = MenuDashboard.FindObject("ScrollRect/Viewport/VerticalLayoutGroup");
                }

                return _MenuDashboard_VerticalLayoutGroup;
            }
        }


        internal static Transform NestedPages
        {
            get
            {
                if (_NestedPages == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "QMParent")
                        {
                            return _NestedPages = button;
                            break;
                        }
                }

                return _NestedPages;
            }
        }


        internal static SelectedUserMenuQM SelectedUserMenuQM
        {
            get
            {
                if (_SelectedUserMenuQM == null) _SelectedUserMenuQM = QuickMenuTransform.gameObject.FindObject("Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>();
                return _SelectedUserMenuQM;
            }
        }

        internal static UIPage UIPageTemplate_Right
        {
            get
            {
                if (_UIPageTemplate_Right == null)
                {
                    var Buttons = Wing_Right.GetComponentsInChildren<UIPage>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Friends")
                        {
                            _UIPageTemplate_Right = button;
                            break;
                        }
                }

                return _UIPageTemplate_Right;
            }
        }

        internal static UIPage UIPageTemplate_Left
        {
            get
            {
                if (_UIPageTemplate_Left == null)
                {
                    var Buttons = Wing_Left.GetComponentsInChildren<UIPage>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Friends")
                        {
                            _UIPageTemplate_Left = button;
                            break;
                        }
                }

                return _UIPageTemplate_Left;
            }
        }

        internal static GameObject DebugPanelTemplate
        {
            get
            {
                if (_DebugPanelTemplate == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<DebugInfoPanel>(true);
                    foreach (var button in Buttons)
                        if (button.name == "DebugInfoPanel")
                        {
                            _DebugPanelTemplate = button.gameObject;
                            break;
                        }
                }

                return _DebugPanelTemplate;
            }
        }

        internal static MenuStateController WingMenuStateControllerRight
        {
            get
            {
                if (_WingMenuStateControllerRight == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<MenuStateController>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Wing_Right")
                        {
                            _WingMenuStateControllerRight = button;
                            break;
                        }
                }

                return _WingMenuStateControllerRight;
            }
        }

        internal static MenuStateController WingMenuStateControllerLeft
        {
            get
            {
                if (_WingMenuStateControllerLeft == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<MenuStateController>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Wing_Left")
                        {
                            _WingMenuStateControllerLeft = button;
                            break;
                        }
                }

                return _WingMenuStateControllerLeft;
            }
        }

        internal static Wing Wing_Left
        {
            get
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
        }

        internal static Wing Wing_Right
        {
            get
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
        }

        internal static MenuStateController QuickMenuController
        {
            get
            {
                if (_QuickMenuController == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<MenuStateController>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Canvas_QuickMenu(Clone)")
                        {
                            _QuickMenuController = button;
                            break;
                        }
                }

                return _QuickMenuController;
            }
        }

        internal static Transform Carousel_Banners
        {
            get
            {
                if (_Carousel_Banners == null)
                {
                    var Transforms = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var transform in Transforms)
                        if (transform.name == "Carousel_Banners")
                        {
                            _Carousel_Banners = transform;
                            break;
                        }
                }

                return _Carousel_Banners;
            }
        }

        internal static Transform Header_DashboardTemplate
        {
            get
            {
                if (_Header_DashboardTemplate == null)
                {
                    var Transforms = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var transform in Transforms)
                        if (transform.name == "Header_QuickLinks")
                            _Header_DashboardTemplate = transform;
                }

                return _Header_DashboardTemplate;
            }
        }

        internal static GameObject WingPageButtonTemplate
        {
            get
            {
                if (_WingPageButtonTemplate == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Button>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Button_ActionMenu")
                        {
                            _WingPageButtonTemplate = button.gameObject;
                            break;
                        }
                }

                return _WingPageButtonTemplate;
            }
        }

        internal static GameObject WingButtonTemplate_Right
        {
            get
            {
                if (_WingButtonTemplate_Right == null)
                {
                    var Buttons = Wing_Right.GetComponentsInChildren<Button>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Button_Profile")
                        {
                            _WingButtonTemplate_Right = button.gameObject;
                            break;
                        }
                }

                return _WingButtonTemplate_Right;
            }
        }

        internal static GameObject WingButtonTemplate_Left
        {
            get
            {
                if (_WingButtonTemplate_Left == null)
                {
                    var Buttons = Wing_Left.GetComponentsInChildren<Button>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Button_Profile")
                        {
                            _WingButtonTemplate_Left = button.gameObject;
                            break;
                        }
                }

                return _WingButtonTemplate_Left;
            }
        }
        internal static Transform SelectedUserPage_Remote_VerticalLayoutGroup
        {
            get
            {
                if (_SelectedUserPage_Remote_VerticalLayoutGroup == null)
                {
                   return _SelectedUserPage_Remote_VerticalLayoutGroup = SelectedUserPage_Remote.FindObject("ScrollRect/Viewport/VerticalLayoutGroup");
                }

                return _SelectedUserPage_Remote_VerticalLayoutGroup;
            }
        }



        internal static Transform SelectedUserPage_Local_VerticalLayoutGroup
        {
            get
            {
                if (_SelectedUserPage_Local_VerticalLayoutGroup == null)
                {
                    return _SelectedUserPage_Local_VerticalLayoutGroup = SelectedUserPage_Local.FindObject("ScrollRect/Viewport/VerticalLayoutGroup");
                }

                return _SelectedUserPage_Local_VerticalLayoutGroup;
            }
        }

        internal static Transform SelectedUserPage_Remote
        {
            get
            {
                if (_SelectedUserPage_Remote == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Menu_SelectedUser_Remote")
                        {
                            _SelectedUserPage_Remote = button;
                            break;
                        }
                }

                return _SelectedUserPage_Remote;
            }
        }


        internal static Transform SelectedUserPage_Local
        {
            get
            {
                if (_SelectedUserPage_Local == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Menu_SelectedUser_Local")
                        {
                            _SelectedUserPage_Local = button;
                            break;
                        }
                }

                return _SelectedUserPage_Local;
            }
        }


        internal static Transform SelectedUserPage_ButtonsSection
        {
            get
            {
                if (_SelectedUserPage_ButtonsSection == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Buttons_UserActions")
                        {
                            _SelectedUserPage_ButtonsSection = button;
                            break;
                        }
                }

                return _SelectedUserPage_ButtonsSection;
            }
        }

        internal static Transform MenuDashboard_ButtonsSection
        {
            get
            {
                if (_MenuDashboard_ButtonsSection == null)
                {
                    var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                        if (button.name == "Buttons_QuickActions")
                        {
                            _MenuDashboard_ButtonsSection = button;
                            break;
                        }
                }

                return _MenuDashboard_ButtonsSection;
            }
        }

        internal static void ShowQuickmenuPage(string pagename)
        {
            QuickMenuController.PushPage(pagename);
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