namespace CheetosLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;

    public class UIPaths
    {
        public static string UserInterface { get; } = "UserInterface";
        public static string QuickMenu { get; } = "UserInterface/Canvas_QuickMenu(Clone)";
        public static string Container { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container";
        public static string Window { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window";
        public static string WorldButton { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Worlds";
        public static string LaunchPadTab { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard";
        public static string Banner { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners";
        public static string LeftWingContainer { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup";
        public static string RightWingContainer { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup";
        public static string ProfileButton { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile";
        public static string HeaderQuicklinks { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks";
        public static string ButtonsQuicklinks { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks";
        public static string HeaderQuickActions { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions";
        public static string ButtonsQuickActions { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions";
        public static string ExpandButton { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand";
        public static string TabsGroup { get; } = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup";
    }
}