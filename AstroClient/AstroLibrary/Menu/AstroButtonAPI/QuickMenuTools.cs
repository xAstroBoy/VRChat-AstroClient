namespace AstroButtonAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Menus;

    internal static class QuickMenuTools
    {
        //Templates and references
        internal static bool SelectSelf = false;

        private static Transform _UserInterface = null;
        private static BoxCollider QuickMenuBackgroundReference = null;
        private static Transform SingleButtonReference = null;
        private static Vector3? SingleButtonReferencePosition = null;
        private static Transform SingleButtonReferenceSelectedUser = null;
        private static Transform ToggleButtonReference = null;
        private static Transform _NestedButtonReference = null;
        private static Transform SelectedUserPageReference = null;
        private static Transform SelectedUserPageButtonsReference = null;
        private static Transform NestedPagesReference = null;
        private static Transform MenuDashboardReference = null;
        private static Transform TabButtonReference = null;
        private static Transform _QuickMenuTransform = null;
        private static Transform HeaderDashboardReference = null;

        //VRC
        private static Transform _CarouselBanners = null;
        private static VRC.UI.Elements.QuickMenu _QuickMenuInstance = null;
        internal static VRCUiManager vrcuimInstance = null; // Dead
        private static GameObject shortcutMenu = null;
        private static GameObject userInteractMenu = null;
        private static GameObject _SelectedUserPage = null;
        private static UIPage UIPageReference_Right = null;
        private static UIPage UIPageReference_Left = null;
        private static Wing WingmenuInstance = null;
        private static Wing _Wing_Right = null;
        private static Wing _Wing_Left = null;
        private static GameObject WingButtonReferenceRight = null;
        private static GameObject WingPageButtonReferenceLeft = null;
        private static GameObject WingPageButtonReference = null;
        private static MenuStateController MenuStateController_Wing_Right = null;
        private static MenuStateController MenuStateController_Wing_Left = null;
        private static MenuStateController _QuickMenuControllert = null;
        private static SelectedUserMenuQM _SelectedQMGO = null;
        //New shit


        internal static SelectedUserMenuQM GetSelectedUserQMInstance()
        {
            if (_SelectedQMGO == null)
            {
                _SelectedQMGO = QuickMenuTransform.gameObject.FindObject("Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>();
            }
            return _SelectedQMGO;
        }

        internal static UIPage UIPageTemplate_Right()
        {
            if (UIPageReference_Right == null)
            {
                var Buttons = Wing_Right().GetComponentsInChildren<UIPage>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Friends")
                    {
                        UIPageReference_Right = button;
                        break;
                    }
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
                {
                    if (button.name == "Friends")
                    {
                        UIPageReference_Left = button;
                        break;
                    }
                }

                
            }

            return UIPageReference_Left;
        }

        private static GameObject DebugPanelReference;

        internal static GameObject DebugPanelTemplate()
        {
            if (DebugPanelReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<DebugInfoPanel>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "DebugInfoPanel")
                    {
                        DebugPanelReference = button.gameObject;
                        break;
                    }
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
                {
                    if (button.name == "Wing_Right")
                    {
                        MenuStateController_Wing_Right = button;
                        break;
                    }
                }

                
            }

            return MenuStateController_Wing_Right;
        }

        internal static MenuStateController WingMenuStateControllerLeft()
        {
            if (MenuStateController_Wing_Left == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<MenuStateController>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Wing_Left")
                    {
                        MenuStateController_Wing_Left = button;
                        break;
                    }
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
                {
                    if (button.name == "Wing_Left")
                    {
                        _Wing_Left = button;
                        break;
                    }
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
                {
                    if (button.name == "Wing_Right")
                    {
                        _Wing_Right = button;
                        break;
                    }
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
                {
                    if (button.name == "Canvas_QuickMenu(Clone)")
                    {
                        _QuickMenuControllert = button;
                        break;
                    }
                }
            }

            return _QuickMenuControllert;
        }

        internal static Transform QuickMenuTransform
        {
            get
            {
                if (UserInterface == null) return null;
                if (_QuickMenuTransform == null)
                {
                    return _QuickMenuTransform = UserInterface.Find("Canvas_QuickMenu(Clone)");
                }

                return _QuickMenuTransform;

            }
        }

        internal static VRC.UI.Elements.QuickMenu QuickMenuInstance
        {
            get
            {
                if (UserInterface == null || QuickMenuTransform == null) return null;
                if (_QuickMenuInstance == null)
                {
                    return _QuickMenuInstance = QuickMenuTransform.GetComponent<VRC.UI.Elements.QuickMenu>();
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

        internal static Transform SingleButtonTemplate()
        {
            if (SingleButtonReference == null)
            {
                SingleButtonReference = QuickMenuInstance.transform.Find("Container/Window/QMParent/Menu_Camera/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_Screenshot");
            }

            return SingleButtonReference;
        }

        internal static Vector3? SingleButtonTemplatePosition()
        {
            if (SingleButtonReferencePosition == null)
            {
                SingleButtonReferencePosition = SingleButtonTemplate().transform.position;
            }

            if (!SingleButtonReferencePosition.HasValue)
            {
                return null;
            }
            return SingleButtonReferencePosition;
        }

        internal static Transform SingleButtonTemplateSelUser()
        {
            if (SingleButtonReferenceSelectedUser == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_VoteKick")
                    {
                        SingleButtonReferenceSelectedUser = button.transform;
                    }
                }

                ;
            }

            return SingleButtonReferenceSelectedUser;
        }

        internal static Transform Carousel_Banners()
        {
            if (_CarouselBanners == null)
            {
                var Transforms = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var transform in Transforms)
                {
                    if (transform.name == "Carousel_Banners")
                    {
                        _CarouselBanners = transform;
                        break;
                    }
                }

                ;
            }

            return _CarouselBanners;
        }

        internal static Transform Header_DashboardTemplate()
        {
            if (HeaderDashboardReference == null)
            {
                var Transforms = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var transform in Transforms)
                {
                    if (transform.name == "Header_QuickLinks")
                    {
                        HeaderDashboardReference = transform;
                    }
                }

                ;
            }

            return HeaderDashboardReference;
        }


        internal static Transform UserInterface
        {
            get
            {
                if (_UserInterface == null)
                {
                    return _UserInterface = GameObject.Find("UserInterface").transform;
                }
                return _UserInterface;
            }
        }


        internal static Transform TabButtonTemplate()
        {
            if (TabButtonReference == null)
            {
                TabButtonReference = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").transform;
            }
            return TabButtonReference;
        }

        internal static GameObject WingPageButtonTemplate()
        {
            if (WingPageButtonReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_ActionMenu")
                    {
                        WingPageButtonReference = button.gameObject;
                        break;
                    }
                }

                ;
            }

            return WingPageButtonReference;
        }

        internal static GameObject WingButtonTemplate_Right()
        {
            if (WingButtonReferenceRight == null)
            {
                var Buttons = Wing_Right().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_Profile")
                    {
                        WingButtonReferenceRight = button.gameObject;
                        break;
                    }
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
                {
                    if (button.name == "Button_Profile")
                    {
                        WingPageButtonReferenceLeft = button.gameObject;
                        break;
                    }
                }

                ;
            }

            return WingPageButtonReferenceLeft;
        }
        internal static Transform ToggleButtonTemplate()
        {
            if (ToggleButtonReference == null)
            {
                ToggleButtonReference = QuickMenuTransform.Find("Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions/Button_Mute");
            }
            return ToggleButtonReference;
        }



        internal static Transform NestedMenuTemplate
        {
            get
            {
                if (QuickMenuTransform == null) return null;
                if (_NestedButtonReference == null)
                {
                    return _NestedButtonReference = QuickMenuTransform.Find("Container/Window/QMParent/Menu_Camera");
                }
                return _NestedButtonReference;

            }
        }




        internal static Transform SelectedUserPage()
        {
            if (SelectedUserPageReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Header_UserActions")
                    {
                        SelectedUserPageReference = button;
                        break;
                    }
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
                {
                    if (button.name == "Buttons_UserActions")
                    {
                        SelectedUserPageButtonsReference = button;
                        break;
                    }
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
                {
                    if (button.name == "Buttons_QuickActions")
                    {
                        MenuDashboardReference = button;
                        break;
                    }
                }

                
            }

            return MenuDashboardReference;
        }


        internal static Transform NestedPages()
        {
            if (NestedPagesReference == null)
            {
                var Buttons = QuickMenuTransform.GetComponentsInChildren<Transform>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "QMParent")
                    {
                        NestedPagesReference = button;
                        break;
                    }
                }

                
            }

            return NestedPagesReference;
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