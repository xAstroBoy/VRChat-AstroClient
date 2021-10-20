namespace CheetoLibrary.ButtonAPI
{
    using UnityEngine;

    internal class UIUtils
    {
        private static GameObject _nestedMenuTemplate;
        private static Transform _nestedPages;

        internal static GameObject NestedMenuTemplate
        {
            get
            {
                if (_nestedMenuTemplate == null)
                {
                    var Buttons = QMUtils.QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                    {
                        if (button.name == "Menu_Camera")
                        {
                            _nestedMenuTemplate = button.gameObject;
                            break;
                        }
                    };
                }
                return _nestedMenuTemplate;
            }
        }

        internal static Transform NestedPages
        {
            get
            {
                if (_nestedPages == null)
                {
                    var Buttons = QMUtils.QuickMenuInstance.GetComponentsInChildren<Transform>(true);
                    foreach (var button in Buttons)
                    {
                        if (button.name == "QMParent")
                        {
                            _nestedPages = button;
                            break;
                        }
                    };
                }
                return _nestedPages;
            }
        }

        internal static string UserInterface { get; } = "UserInterface";
        internal static string QuickMenu { get; } = "UserInterface/Canvas_QuickMenu(Clone)";
        internal static string Container { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container";
        internal static string Window { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window";
        internal static string QickMenuParent { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent";
        internal static string QMDashboard { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard";
        internal static string WorldButton { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Worlds";
        internal static string LaunchPadTab { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard";
        internal static string Banner { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners";
        internal static string LeftWingContainer { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup";
        internal static string RightWingContainer { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup";
        internal static string ProfileButton { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile";
        internal static string HeaderQuicklinks { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks";
        internal static string ButtonsQuicklinks { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks";
        internal static string HeaderQuickActions { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions";
        internal static string ButtonsQuickActions { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions";
        internal static string ExpandButton { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand";
        internal static string TabsGroup { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup";
    }
}