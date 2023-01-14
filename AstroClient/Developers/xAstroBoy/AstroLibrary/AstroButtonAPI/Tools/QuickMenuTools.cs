
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
        internal static bool SelectSelf  { get; set; }= false;
        private static Transform _UnscaledUI { get; set; }
        private static Transform _Application  { get; set; }

        private static Transform _UserInterface  { get; set; }
        private static Transform SingleButtonReference  { get; set; } = null;
        private static Vector3? _SingleButtonTemplatePosition { get; set; }
        private static Transform _ToggleButtonTemplate { get; set; }
        private static Transform _NestedMenuTemplate { get; set; }
        private static Transform SelectedUserPageReference { get; set; }
        private static Transform _SelectedUserPage_ButtonsSection { get; set; }
        private static Transform _NestedPages { get; set; }
        private static Transform _MenuDashboard_ButtonsSection { get; set; }
        private static Transform _TabButtonTemplate { get; set; }
        
        private static Transform _Header_DashboardTemplate { get; set; }
        private static Transform _SliderTemplate { get; set; }
        private static Transform _ToolTipPanel { get; set; }
        private static Transform _TabMenu { get; set; }
        private static Transform _MenuDashboard { get; set; }

        private static Transform _SingleButtonTemplate { get; set; }

        //VRC
        private static Transform _Carousel_Banners  { get; set; }

        private static QuickMenu _QuickMenuInstance { get; set; }
        internal static VRCUiManager vrcuimInstance  { get; set; } = null; // Dead
        private static GameObject shortcutMenu  { get; set; } = null;
        private static GameObject userInteractMenu  { get; set; } = null;
        private static Transform _SelectedUserPage_Remote  { get; set; } = null;
        private static Transform _SelectedUserPage_Local  { get; set; } = null;

        private static Transform _SelectedUserPage_Remote_VerticalLayoutGroup { get; set; }= null;
        private static Transform _SelectedUserPage_Local_VerticalLayoutGroup { get; set; }= null;
        private static Transform _MenuDashboard_VerticalLayoutGroup { get; set; }= null;

        private static UIPage _UIPageTemplate_Right{ get; set; }
        private static UIPage _UIPageTemplate_Left{ get; set; }
        private static WingMenu WingmenuInstance { get; set; }= null;
        private static WingMenu _Wing_Right{ get; set; }
        private static WingMenu _Wing_Left{ get; set; }
        private static GameObject _WingButtonTemplate_Right { get; set; }
        private static GameObject _WingButtonTemplate_Left { get; set; }
        private static GameObject _WingPageButtonTemplate { get; set; }
        private static MenuStateController _WingMenuStateControllerRight{ get; set; }
        private static MenuStateController _WingMenuStateControllerLeft{ get; set; }
        private static MenuStateController _QuickMenuController{ get; set; }
        private static MenuStateController _MainMenuStateController{ get; set; }

        private static SelectedUserMenuQM _SelectedUserMenuQM{ get; set; }
        private static UIPage _QuickMenuPage{ get; set; }

        private static GameObject _DebugPanelTemplate{ get; set; }
        private static Transform _Canvas_QuickMenu{ get; set; }
        internal static Transform Canvas_QuickMenu
        {
            get
            {
                if (UserInterface == null) return null;
                if (_Canvas_QuickMenu == null)  _Canvas_QuickMenu = UserInterface.Find("Canvas_QuickMenu(Clone)");
                return _Canvas_QuickMenu;
            }
        }
        private static Transform _Canvas_MainMenu;
        internal static Transform Canvas_MainMenu
        {
            get
            {
                if (UserInterface == null) return null;
                if (_Canvas_MainMenu == null) _Canvas_MainMenu = UserInterface.Find("Canvas_MainMenu(Clone)");
                return _Canvas_MainMenu;
            }
        }
        internal static QuickMenu QuickMenuInstance
        {
            get
            {
                if (Canvas_QuickMenu == null) return null;
                if (_QuickMenuInstance == null)
                {
                    var test = Canvas_QuickMenu.GetComponent<QuickMenu>();
                    if (test != null) Log.Debug("Found QuickMenu Instance!", Color.Chartreuse);

                    return _QuickMenuInstance = test;
                }

                return _QuickMenuInstance;
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<Button>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Button button = Buttons[i];
                        if (button.name == "Button_VoteKick")
                            _SingleButtonTemplate = button.transform;
                    }
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
                if (_UserInterface == null) return _UserInterface = Resources.FindObjectsOfTypeAll<MonoBehaviour1PublicVo0>()[0].gameObject.transform;
                return _UserInterface;
            }
        }
        internal static Transform Application
        {
            get
            {
                if (_Application == null) return _Application = Resources.FindObjectsOfTypeAll<VRC.FeaturePermissionManager>()[0].gameObject.transform;
                return _Application;
            }
        }

        internal static Transform UnscaledUI
        {
            get
            {
                if (_UnscaledUI == null) return _UnscaledUI = UserInterface.FindObject("UnscaledUI");
                return _UnscaledUI;
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Button button = Buttons[i];
                        if (button.name == "Page_Settings")
                        {
                            Log.Debug("Found Tab Settings!", Color.Chartreuse);
                            return _TabButtonTemplate = button.transform;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Page_Buttons_QM")
                        {
                            Log.Debug("Found Tab Menu!", Color.Chartreuse);
                            return _TabMenu = button.transform;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "ToolTipPanel")
                        {
                            Log.Debug("Found ToolTip Panel!", Color.Chartreuse);
                            return _ToolTipPanel = button.transform;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "VolumeSlider_Master")
                        {
                            Log.Debug("Found Slider Template!", Color.Chartreuse);
                            return _SliderTemplate = button;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Button_ShowGroupNameplateBanners")
                        {
                            Log.Debug("Found ShowGroupNameplateBanners button!", Color.Chartreuse);
                            return _ToggleButtonTemplate = button;
                        }
                    }
                }

                return _ToggleButtonTemplate;
            }
        }

        internal static Transform NestedMenuTemplate
        {
            get
            {
                if (Canvas_QuickMenu == null) return null;
                if (_NestedMenuTemplate == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Menu_Camera")
                        {
                            Log.Debug("Found Menu_Camera Page!", Color.Chartreuse);
                            return _NestedMenuTemplate = button;
                        }
                    }
                }

                return _NestedMenuTemplate;
            }
        }

        internal static Transform MenuDashboard
        {
            get
            {
                if (Canvas_QuickMenu == null) return null;
                if (_MenuDashboard == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Menu_Dashboard")
                        {
                            Log.Debug("Found Dashboard Page!", Color.Chartreuse);
                            return _MenuDashboard = button;
                        }
                    }
                }

                return _MenuDashboard;
            }
        }

        internal static Transform MenuDashboard_VerticalLayoutGroup
        {
            get
            {
                if (Canvas_QuickMenu == null) return null;
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
                    _NestedPages = NestedMenuTemplate.transform.parent;
                    
                }

                return _NestedPages;
            }
        }


        internal static SelectedUserMenuQM SelectedUserMenuQM
        {
            get
            {
                if (_SelectedUserMenuQM == null) _SelectedUserMenuQM = Canvas_QuickMenu.gameObject.FindUIObject("Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>();
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        UIPage button = Buttons[i];
                        if (button.name == "Friends")
                        {
                            _UIPageTemplate_Right = button;
                            break;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        UIPage button = Buttons[i];
                        if (button.name == "Friends")
                        {
                            _UIPageTemplate_Left = button;
                            break;
                        }
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<DebugInfoPanel>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        DebugInfoPanel button = Buttons[i];
                        if (button.name == "DebugInfoPanel")
                        {
                            _DebugPanelTemplate = button.gameObject;
                            break;
                        }
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<MenuStateController>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        MenuStateController button = Buttons[i];
                        if (button.name == "Wing_Right")
                        {
                            _WingMenuStateControllerRight = button;
                            break;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        MenuStateController button = Buttons[i];
                        if (button.name == "Wing_Left")
                        {
                            _WingMenuStateControllerLeft = button;
                            break;
                        }
                    }
                }

                return _WingMenuStateControllerLeft;
            }
        }

        internal static WingMenu Wing_Left
        {
            get
            {
                if (_Wing_Left == null)
                {
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<WingMenu>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        WingMenu button = Buttons[i];
                        if (button.name == "Wing_Left")
                        {
                            _Wing_Left = button;
                            break;
                        }
                    }
                }

                return _Wing_Left;
            }
        }

        internal static WingMenu Wing_Right
        {
            get
            {
                if (_Wing_Right == null)
                {
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<WingMenu>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        WingMenu button = Buttons[i];
                        if (button.name == "Wing_Right")
                        {
                            _Wing_Right = button;
                            break;
                        }
                    }
                }

                return _Wing_Right;
            }
        }
        internal static MenuStateController MainMenuStateController
        {
            get
            {
                if (_QuickMenuController == null)
                {
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<MenuStateController>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        MenuStateController button = Buttons[i];
                        if (button.name == "Canvas_MainMenu(Clone)")
                        {
                            _MainMenuStateController = button;
                            break;
                        }
                    }
                }

                return _QuickMenuController;
            }
        }

        internal static MenuStateController QuickMenuController
        {
            get
            {
                if (_QuickMenuController == null)
                {
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<MenuStateController>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        MenuStateController button = Buttons[i];
                        if (button.name == "Canvas_QuickMenu(Clone)")
                        {
                            _QuickMenuController = button;
                            break;
                        }
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
                    var Transforms = Canvas_QuickMenu.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Transforms.Count; i++)
                    {
                        Transform transform = Transforms[i];
                        if (transform.name == "Carousel_Banners")
                        {
                            _Carousel_Banners = transform;
                            break;
                        }
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
                    var Transforms = Canvas_QuickMenu.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Transforms.Count; i++)
                    {
                        Transform transform = Transforms[i];
                        if (transform.name == "Header_QuickLinks")
                            _Header_DashboardTemplate = transform;
                    }
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<Button>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Button button = Buttons[i];
                        if (button.name == "Button_ActionMenu")
                        {
                            _WingPageButtonTemplate = button.gameObject;
                            break;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Button button = Buttons[i];
                        if (button.name == "Button_Profile")
                        {
                            _WingButtonTemplate_Right = button.gameObject;
                            break;
                        }
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
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Button button = Buttons[i];
                        if (button.name == "Button_Profile")
                        {
                            _WingButtonTemplate_Left = button.gameObject;
                            break;
                        }
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Menu_SelectedUser_Remote")
                        {
                            _SelectedUserPage_Remote = button;
                            break;
                        }
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Menu_SelectedUser_Local")
                        {
                            _SelectedUserPage_Local = button;
                            break;
                        }
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Buttons_UserActions")
                        {
                            _SelectedUserPage_ButtonsSection = button;
                            break;
                        }
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
                    var Buttons = Canvas_QuickMenu.GetComponentsInChildren<Transform>(true);
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Transform button = Buttons[i];
                        if (button.name == "Buttons_QuickActions")
                        {
                            _MenuDashboard_ButtonsSection = button;
                            break;
                        }
                    }
                }

                return _MenuDashboard_ButtonsSection;
            }
        }

        internal static void ShowQuickmenuPage(string pagename)
        {
            QuickMenuController.ShowTabContent(pagename);
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