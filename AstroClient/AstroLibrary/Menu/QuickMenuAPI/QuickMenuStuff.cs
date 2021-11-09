namespace QuickMenuAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QuickMenuStuff
    {
        //Templates and references
        internal static bool SelectSelf = false;
        internal static BoxCollider QuickMenuBackgroundReference;
        internal static GameObject SingleButtonReference;
        internal static Vector3? SingleButtonReferencePosition;
        internal static GameObject SingleButtonReferenceSelectedUser;
        internal static GameObject ToggleButtonReference;
        internal static Transform NestedButtonReference;
        internal static Transform SelectedUserPageReference;
        internal static Transform SelectedUserPageButtonsReference;
        internal static GameObject NestedButtonReferenceGameO;
        internal static Transform NestedPagesReference;
        internal static Transform MenuDashboardReference;
        internal static GameObject TabButtonReference;

        internal static GameObject HeaderDashboardReference;

        //VRC
        internal static GameObject _CarouselBanners;
        internal static QuickMenu quickmenuInstance;
        internal static VRCUiManager vrcuimInstance;
        internal static GameObject shortcutMenu;
        internal static GameObject userInteractMenu;



        internal static GameObject _SelectedUserPage;
        internal static UIPage UIPageReference_Right;
        internal static UIPage UIPageReference_Left;
        internal static Wing WingmenuInstance;
        internal static Wing _Wing_Right;
        internal static Wing _Wing_Left;
        internal static GameObject WingButtonReferenceRight;
        internal static GameObject WingPageButtonReferenceLeft;
        internal static GameObject WingPageButtonReference;
        internal static MenuStateController MenuStateController_Wing_Right;
        internal static MenuStateController MenuStateController_Wing_Left;

        internal static MenuStateController _QuickMenuControllert;
        //New shit

        internal static UIPage UIPageTemplate_Right()
        {
            if (UIPageReference_Right == null)
            {
                var Buttons = QuickMenuStuff.Wing_Right().GetComponentsInChildren<UIPage>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Friends")
                    {
                        UIPageReference_Right = button;
                        break;
                    }
                };
            }
            return UIPageReference_Right;
        }

        internal static UIPage UIPageTemplate_Left()
        {
            if (UIPageReference_Left == null)
            {
                var Buttons = QuickMenuStuff.Wing_Left().GetComponentsInChildren<UIPage>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Friends")
                    {
                        UIPageReference_Left = button;
                        break;
                    }
                };
            }
            return UIPageReference_Left;
        }

        internal static MenuStateController WingMenuStateControllerRight()
        {
            if (MenuStateController_Wing_Right == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<MenuStateController>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Wing_Right")
                    {
                        MenuStateController_Wing_Right = button;
                        break;
                    }
                };
            }
            return MenuStateController_Wing_Right;
        }

        internal static MenuStateController WingMenuStateControllerLeft()
        {
            if (MenuStateController_Wing_Left == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<MenuStateController>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Wing_Left")
                    {
                        MenuStateController_Wing_Left = button;
                        break;
                    }
                };
            }
            return MenuStateController_Wing_Left;
        }

        internal static Wing Wing_Left()
        {
            if (_Wing_Left == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Wing>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Wing_Left")
                    {
                        _Wing_Left = button;
                        break;
                    }
                };
            }
            return _Wing_Left;
        }
        internal static Wing Wing_Right()
        {
            if (_Wing_Right == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Wing>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Wing_Right")
                    {
                        _Wing_Right = button;
                        break;
                    }
                };
            }
            return _Wing_Right;
        }

        internal static MenuStateController QuickMenuController()
        {
            if (_QuickMenuControllert == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<MenuStateController>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Canvas_QuickMenu(Clone)")
                    {
                        _QuickMenuControllert = button;
                        break;
                    }
                };
            }
            return _QuickMenuControllert;
        }

        internal static QuickMenu GetQuickMenuInstance()
        {
            if (quickmenuInstance == null)
                quickmenuInstance = Resources.FindObjectsOfTypeAll<QuickMenu>()[0];

            return quickmenuInstance;
        }

        internal static BoxCollider QuickMenuBackground()
        {
            if (QuickMenuBackgroundReference == null)
                QuickMenuBackgroundReference = GetQuickMenuInstance().transform.Find("Container/Button_Worlds").GetComponent<BoxCollider>();
            return QuickMenuBackgroundReference;
        }

        internal static GameObject SingleButtonTemplate()
        {
            if (SingleButtonReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_Respawn")
                    {
                        SingleButtonReference = button.gameObject;
                    }
                };
            }
            return SingleButtonReference;
        }

        internal static Vector3 SingleButtonTemplatePosition()
        {
            if (SingleButtonReferencePosition == null)
            {
                SingleButtonReferencePosition = SingleButtonTemplate().transform.position;
            }
            return SingleButtonReferencePosition.Value;
        }

        internal static GameObject SingleButtonTemplateSelUser()
        {
            if (SingleButtonReferenceSelectedUser == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_VoteKick")
                    {
                        SingleButtonReferenceSelectedUser = button.gameObject;
                    }
                };
            }
            return SingleButtonReferenceSelectedUser;
        }

        internal static GameObject Carousel_Banners()
        {
            if (_CarouselBanners == null)
            {
                var Transforms = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var transform in Transforms)
                {
                    if (transform.name == "Carousel_Banners")
                    {
                        _CarouselBanners = transform.gameObject;
                        break;
                    }
                };
            }

            return _CarouselBanners;
        }

        internal static GameObject Header_DashboardTemplate()
        {
            if (HeaderDashboardReference == null)
            {
                var Transforms = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var transform in Transforms)
                {
                    if (transform.name == "Header_QuickLinks")
                    {
                        HeaderDashboardReference = transform.gameObject;
                    }
                };
            }

            return HeaderDashboardReference;
        }

        internal static GameObject TabButtonTemplate()
        {
            if (TabButtonReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Page_Settings")
                    {
                        TabButtonReference = button.gameObject;
                        break;
                    }
                };
            }
            return TabButtonReference;
        }

        internal static GameObject WingPageButtonTemplate()
        {
            if (WingPageButtonReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_ActionMenu")
                    {
                        WingPageButtonReference = button.gameObject;
                        break;
                    }
                };
            }
            return WingPageButtonReference;
        }

        internal static GameObject WingButtonTemplate_Right()
        {
            if (WingButtonReferenceRight == null)
            {
                var Buttons = QuickMenuStuff.Wing_Right().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_Profile")
                    {
                        WingButtonReferenceRight = button.gameObject;
                        break;
                    }
                };
            }
            return WingButtonReferenceRight;
        }

        internal static GameObject WingButtonTemplate_Left()
        {
            if (WingPageButtonReferenceLeft == null)
            {
                var Buttons = QuickMenuStuff.Wing_Left().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_Profile")
                    {
                        WingPageButtonReferenceLeft = button.gameObject;
                        break;
                    }
                };
            }
            return WingPageButtonReferenceLeft;
        }

        internal static GameObject ToggleButtonTemplate()
        {
            if (ToggleButtonReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Toggle>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_ToggleFallbackIcon")
                    {
                        ToggleButtonReference = button.gameObject;
                        break;
                    }
                };
            }
            return ToggleButtonReference;
        }

        internal static Transform NestedMenuTemplate()
        {
            if (NestedButtonReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Menu_Camera")
                    {
                        NestedButtonReference = button;
                        break;
                    }
                };
            }
            return NestedButtonReference;
        }

        internal static Transform SelectedUserPage()
        {

            if (SelectedUserPageReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Header_UserActions")
                    {
                        SelectedUserPageReference = button;
                        break;
                    }
                };
            }
            return SelectedUserPageReference;
        }

        internal static Transform SelectedUserPage_ButtonsSection()
        {
            if (SelectedUserPageButtonsReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Buttons_UserActions")
                    {
                        SelectedUserPageButtonsReference = button;
                        break;
                    }
                };
            }
            return SelectedUserPageButtonsReference;
        }

        internal static GameObject NestedMenuTemplate_GameO()
        {
            if (NestedButtonReferenceGameO == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Menu_Camera")
                    {
                        NestedButtonReferenceGameO = button.gameObject;
                        break;
                    }
                };
            }
            return NestedButtonReferenceGameO;
        }

        internal static Transform MenuDashboard_ButtonsSection()
        {
            if (MenuDashboardReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Buttons_QuickActions")
                    {
                        MenuDashboardReference = button;
                        break;
                    }
                };
            }
            return MenuDashboardReference;
        }

        internal static Transform NestedMenus()
        {
            if (NestedButtonReference == null)
            {

                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Menu_Camera")
                    {
                        NestedButtonReference = button;
                        break;
                    }
                };
            }
            return NestedButtonReference;
        }

        internal static Transform NestedPages()
        {
            if (NestedPagesReference == null)
            {
                var Buttons = QuickMenuStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "QMParent")
                    {
                        NestedPagesReference = button;
                        break;
                    }
                };
            }
            return NestedPagesReference;
        }

        internal static Transform VRC_Camera_Menu()
        {
            if (NestedButtonReference == null)
            {
                NestedButtonReference = SingleButtonTemplate().transform.parent;
            }
            return NestedButtonReference;
        }

        internal static void ShowQuickmenuPage(string pagename)
        {
            QuickMenuStuff.GetQuickMenuInstance().prop_MenuStateController_0.PushPage(pagename);
        }
    }
}