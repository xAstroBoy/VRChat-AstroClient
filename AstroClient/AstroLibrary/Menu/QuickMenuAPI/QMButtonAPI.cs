namespace QuickMenuAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CheetoLibrary;
    using global::AstroLibrary.Extensions;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal static class QMButtonAPI
    {
        //REPLACE THIS STRING SO YOUR MENU DOESNT COLLIDE WITH OTHER MENUS
        internal static string identifier = "Notorious";
        //internal static Color mBackground = Color.red;
        //internal static Color mForeground = Color.white;
        //internal static Color bBackground = Color.red;
        //internal static Color bForeground = Color.yellow;
        //internal static List<QMSingleButton> allSingleButtons = new List<QMSingleButton>();
        //internal static List<QMToggleButton> allToggleButtons = new List<QMToggleButton>();
        //internal static List<QMNestedButton> allNestedButtons = new List<QMNestedButton>();
    }

    internal class QMStuff
    {
        //Templates and references
        internal static bool SelectSelf = false;
        internal static BoxCollider QuickMenuBackgroundReference;
        internal static GameObject SingleButtonReference;
        internal static Vector3 SingleButtonReferencePosition;
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
                var Buttons = QMStuff.Wing_Right().GetComponentsInChildren<UIPage>(true);
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
                var Buttons = QMStuff.Wing_Left().GetComponentsInChildren<UIPage>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<MenuStateController>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<MenuStateController>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Wing>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Wing>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<MenuStateController>(true);
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

        //internal static BoxCollider QuickMenuBackground()
        //{
        //    if (QuickMenuBackgroundReference == null)
        //        QuickMenuBackgroundReference = GetQuickMenuInstance().transform.Find("Container/Button_Worlds").GetComponent<BoxCollider>();
        //    return QuickMenuBackgroundReference;
        //}

        internal static GameObject SingleButtonTemplate()
        {
            if (SingleButtonReference == null)
            {
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
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
            return SingleButtonReferencePosition;
        }

        internal static GameObject SingleButtonTemplateSelUser()
        {
            if (SingleButtonReferenceSelectedUser == null)
            {
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
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
                var Transforms = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
                var Transforms = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
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
                var Buttons = QMStuff.Wing_Right().GetComponentsInChildren<Button>(true);
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
                var Buttons = QMStuff.Wing_Left().GetComponentsInChildren<Button>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Toggle>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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

                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
                var Buttons = QMStuff.GetQuickMenuInstance().GetComponentsInChildren<Transform>(true);
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
            QMStuff.GetQuickMenuInstance().prop_MenuStateController_0.PushPage(pagename);
        }

        internal static void NoShader(QMSingleButton x)
        {
            x.getGameObject().GetComponent<Button>().name = "NoShader";
        }

        internal static void NoShader(QMNestedButton x)
        {
            x.getMainButton().getGameObject().GetComponent<Button>().name = "NoShader";
        }
    }

    internal class QmQuickActions
    {
        internal string btnType;
        internal GameObject Header;
        internal GameObject QuickActions;
        internal QmQuickActions(int Index, string Menu, string Title, Color32 TextColor)
        {
            initButton(Index, Menu, Title, TextColor);
        }

        internal QmQuickActions(int Index, string Menu, string Title, string TextColor)
        {
            initButton(Index, Menu, Title, TextColor.HexToColor());
        }

        internal void initButton(int Index, string Menu, string Title, Color32 TextColor)
        {
            btnType = "_QMQuickActions_";

            switch (Menu)
            {
                case "MainMenu":
                    Header = UnityEngine.Object.Instantiate(QMStuff.Header_DashboardTemplate(), QMStuff.Header_DashboardTemplate().transform.parent, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    var Text = Extensions.NewText(Header, "Text_Title");
                    Text.text = Title;
                    Text.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = UnityEngine.Object.Instantiate(QMStuff.MenuDashboard_ButtonsSection().gameObject, QMStuff.Header_DashboardTemplate().transform.parent, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;

                case "SelectedUser":
                    Index += 5;
                    Header = UnityEngine.Object.Instantiate(QMStuff.Header_DashboardTemplate(), QMStuff.SelectedUserPage().transform.parent, true);
                    Header.name = QMButtonAPI.identifier + btnType + Title + "_Header";
                    var Text2 = Extensions.NewText(Header, "Text_Title");
                    Text2.text = Title;
                    Text2.SetFaceColor(TextColor);
                    Header.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                    QuickActions = UnityEngine.Object.Instantiate(QMStuff.SelectedUserPage_ButtonsSection().gameObject, QMStuff.SelectedUserPage().transform.parent, true);
                    QuickActions.CleanButtonsQuickActions();
                    QuickActions.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index + 1);
                    QuickActions.name = QMButtonAPI.identifier + btnType + Title + "_Buttons";
                    break;
            }

        }
    }

    internal class QMTabButton : QMButtonBase
    {
        internal QMTabButton(int Index, System.Action btnAction, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(int Index, System.Action btnAction, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            btnType = "_QMTabButton_";
            button = UnityEngine.Object.Instantiate(QMStuff.TabButtonTemplate(), QMStuff.TabButtonTemplate().transform.parent, true);
            button.name = QMButtonAPI.identifier + btnType + Index;
            setToolTip(btnToolTip);
            setAction(btnAction);
            button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

            if (LoadSprite != "")
                button.LoadSprite(LoadSprite, "Icon");

            setActive(true);
        }

        internal void setAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }

    internal class QMWings : QMButtonBase
    {
        internal Transform WingPage;
        internal QMWings(int Index, bool LeftWing, string MenuName, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            btnQMLoc = "WingPage" + MenuName;
            initButton(Index, LeftWing, MenuName, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(int Index, bool LeftWing, string MenuName, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            if (LeftWing)
            {
                btnQMLoc += "_LEFT";
                button = UnityEngine.Object.Instantiate(QMStuff.WingButtonTemplate_Left(), QMStuff.Wing_Left().gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                Extensions.NewText(button, "Text_QM_H3").text = MenuName;
                setToolTip(btnToolTip);
                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                UIPage Page = QMStuff.UIPageTemplate_Left();
                UIPage Wing_UP_1 = UnityEngine.Object.Instantiate(Page, Page.transform.parent, true);
                WingPage = Wing_UP_1.transform;
                Extensions.NewText(Wing_UP_1.gameObject, "Text_Title").text = $"{MenuName}";
                Wing_UP_1.field_Public_String_0 = btnQMLoc;
                Wing_UP_1.gameObject.name = btnQMLoc;
                Wing_UP_1.field_Public_Boolean_0 = true;
                Wing_UP_1.field_Private_MenuStateController_0 = QMStuff.WingMenuStateControllerLeft();
                Wing_UP_1.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
                Wing_UP_1.field_Private_List_1_UIPage_0.Add(Wing_UP_1);
                QMStuff.WingMenuStateControllerLeft().field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, Wing_UP_1);

                var VLGC = Wing_UP_1.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                GameObject VLG = Wing_UP_1.gameObject.FindObject("VerticalLayoutGroup");
                VLG.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VLG.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                Wing_UP_1.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = Wing_UP_1.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);

                //GameObject SCB = Wing_UP_1.gameObject.FindObject("Scrollbar");
                //SCB.GetComponentInChildren<Scrollbar>(true).size = 1f;
                //SCB.GetComponentInChildren<RectTransform>(true).anchoredPosition = new Vector2(-4,100);

                //Wing_UP_1.gameObject.CleanButtonsWingMenu();
                setAction(() => { QMStuff.Wing_Left().field_Private_MenuStateController_0.PushPage(btnQMLoc); });
            }
            else
            {
                btnQMLoc += "_RIGHT";
                button = UnityEngine.Object.Instantiate(QMStuff.WingButtonTemplate_Right(), QMStuff.Wing_Right().gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                Extensions.NewText(button, "Text_QM_H3").text = MenuName;
                setToolTip(btnToolTip);

                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

                UIPage Page = QMStuff.UIPageTemplate_Right();
                UIPage Wing_UP_1 = UnityEngine.Object.Instantiate(Page, Page.transform.parent, true);
                WingPage = Wing_UP_1.transform;
                Extensions.NewText(Wing_UP_1.gameObject, "Text_Title").text = MenuName;
                Extensions.NewText(Wing_UP_1.gameObject, "Text_Title").fontSize = 36;
                Wing_UP_1.field_Public_String_0 = btnQMLoc;
                Wing_UP_1.gameObject.name = btnQMLoc;
                Wing_UP_1.field_Public_Boolean_0 = true;
                Wing_UP_1.field_Private_MenuStateController_0 = QMStuff.WingMenuStateControllerRight();
                Wing_UP_1.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
                Wing_UP_1.field_Private_List_1_UIPage_0.Add(Wing_UP_1);
                QMStuff.WingMenuStateControllerRight().field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, Wing_UP_1);
                //Wing_UP_1.gameObject.CleanButtonsWingMenu();

                var VLGC2 = Wing_UP_1.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC2.spacing = 12;
                VLGC2.m_Spacing = 12;
                VLGC2.childScaleHeight = false;
                VLGC2.childScaleWidth = false;
                VLGC2.childControlHeight = false;
                VLGC2.childControlWidth = false;

                GameObject VLG = Wing_UP_1.gameObject.FindObject("VerticalLayoutGroup");
                VLG.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VLG.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                Wing_UP_1.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = Wing_UP_1.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);

                setAction(() => { QMStuff.Wing_Right().field_Private_MenuStateController_0.PushPage(btnQMLoc); });
            }



            if (LoadSprite != "")
                button.LoadSprite(LoadSprite, "Icon");
            setActive(true);
        }

        internal void setAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }

    internal class QMToggleButton : QMButtonBase
    {
        internal GameObject btnOn;
        internal GameObject btnOff;
        internal List<QMButtonBase> showWhenOn = new List<QMButtonBase>();
        internal List<QMButtonBase> hideWhenOn = new List<QMButtonBase>();
        internal bool Toggled = false;

        System.Action btnOnAction = null;
        System.Action btnOffAction = null;

        internal QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOn, System.Action btnActionOff, string btnToolTip, string btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.getMenuName();
            initButton(btnActionOn, btnXLocation, btnYLocation, Title, btnActionOff, btnToolTip, btnTextColor, shouldSaveInConfig, defaultPosition);
        }

        internal QMToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOn, System.Action btnActionOff, string btnToolTip, string btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu;
            initButton(btnActionOn, btnXLocation, btnYLocation, Title, btnActionOff, btnToolTip, btnTextColor, shouldSaveInConfig, defaultPosition);
        }

        private protected void initButton(System.Action btnActionOn, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOff, string btnToolTip, string TextColor = null, bool shouldSaveInConf = false, bool defaultPosition = false)
        {
            btnType = "_ToggleButton_";
            var Part1 = QMStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
            button = UnityEngine.Object.Instantiate<GameObject>(QMStuff.ToggleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
            Extensions.NewText(button, "Text_H4").text = Title;
            button.name = QMButtonAPI.identifier + btnType + Title;
            btnOn = button.FindObject("Icon_On");
            btnOff = button.FindObject("Icon_Off");
            btnOff.SetActive(true);
            btnOn.SetActive(false);

            if (TextColor != null)
                setTextColorHTML(TextColor);
            else
                setTextColorHTML("#blue");

            button.transform.position = QMStuff.SingleButtonTemplate().transform.position;
            initShift[0] = -1;
            initShift[1] = -3;
            setLocation(btnXLocation, btnYLocation);

            btnOn.GetComponentInChildren<RectTransform>().anchoredPosition -= new Vector2(50, 0);
            btnOff.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(50, 0);

            btnOn.GetComponentInChildren<Image>().overrideSprite = LoadAssets.LoadSprite("check.png");
            btnOff.GetComponentInChildren<Image>().overrideSprite = LoadAssets.LoadSprite("x.png");

            setToolTip(btnToolTip);
            setAction(btnActionOn, btnActionOff);
            //QMButtonAPI.allToggleButtons.Add(this);
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            string NewText = $"<color={buttonTextColor}>{button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = NewText;
        }

        internal override void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
            foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
            if (save)
                OrigBackground = buttonBackgroundColor;
        }


        internal void setAction(System.Action buttonOnAction, System.Action buttonOffAction)
        {
            btnOnAction = buttonOnAction;
            btnOffAction = buttonOffAction;

            button.GetComponentInChildren<Toggle>().onValueChanged.AddListener(new Action<bool>
            ((g) =>
            {
                if (g)
                {
                    btnOn.SetActive(true);
                    btnOff.SetActive(false);
                    btnOnAction.Invoke();
                }
                else
                {
                    btnOn.SetActive(false);
                    btnOff.SetActive(true);
                    btnOffAction.Invoke();
                }
            }));
        }
    }

    internal class QMNestedButton
    {
        public QMSingleButton mainButton;
        internal static GameObject backButton;
        //internal QMSingleButton NotoriousMainButton;

        internal string menuName;
        internal string btnQMLoc;
        internal string btnType;

        internal QMNestedButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = Parent.getMenuName();
            initButton(btnXLocation, btnYLocation, btnText, btnToolTip, Title, LoadSprite, TextColor);
        }

        internal QMNestedButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, string Title, string btnToolTip, string TextColor = null, string LoadSprite = "")
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnText, btnToolTip, Title, LoadSprite, TextColor);
        }

        internal void initButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title, string LoadSprite = "", string TextColor = null, bool CanBeDragged = false)
        {
            btnType = QMButtonAPI.identifier + "_Nested_Menu_";
            menuName = "Page_" + btnType + Title;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QMStuff.NestedMenuTemplate_GameO(), QMStuff.NestedPages(), true);
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            UnityEngine.GameObject.Destroy(NestedPart.FindObject("Buttons").GetComponentInChildren<GridLayoutGroup>());

            UIPage Page_UI = NestedPart.AddComponent<UIPage>();
            Page_UI.name = menuName; 
            Page_UI.field_Public_Boolean_0 = true;
            Page_UI.field_Private_MenuStateController_0 = QMStuff.QuickMenuController();
            Page_UI.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page_UI.field_Private_List_1_UIPage_0.Add(Page_UI);
            NestedPart.name = menuName;
            Extensions.NewText(NestedPart, "Text_Title").text = Title;
            NestedPart.SetActive(false);
            Extensions.CleanButtonsNestedMenu(NestedPart);
            QMStuff.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, Page_UI);

            mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QMStuff.ShowQuickmenuPage(menuName); }, btnToolTip, TextColor);

            //Sets image for nested menu if needed

            if (LoadSprite.Contains("_ICON"))
            {
                LoadSprite = LoadSprite.Replace("_ICON", "");
                mainButton.getGameObject().LoadSprite(LoadSprite, "Icon");
            }
            else if (LoadSprite != "")
            {
                mainButton.getGameObject().LoadSprite(LoadSprite, "Background");
            }

            //QMButtonAPI.allNestedButtons.Add(this);

            switch (Title)
            {
                case "Main Menu":
                    NestedPart.CreateMainBackButton();
                    break;

                default:
                    NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_Menu_" + "Main Menu");
                    break;
            }
        }


        internal string getMenuName()
        {
            return menuName;
        }

        internal QMSingleButton getMainButton()
        {
            return mainButton;
        }

        internal void DestroyMe()
        {
            //mainButton.DestroyMe();
            //backButton.DestroyMe();
        }
    }

    public class QMButtonBase
    {
        protected GameObject button;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;
        protected Color OrigText;

        public GameObject getGameObject()
        {
            return button;
        }

        public void setActive(bool state)
        {
            button.gameObject.SetActive(state);
        }

        public void setLocation(float buttonXLoc, float buttonYLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * (buttonXLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * (buttonYLoc + initShift[1]));

            //btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            //button.name = btnQMLoc + "/" + btnType + btnTag;
            //button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void setToolTip(string buttonToolTip)
        {
            button.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = buttonToolTip;
        }

        internal virtual void setBackgroundColor(Color buttonBackgroundColor, bool save = true) { }
        internal virtual void setTextColor(Color buttonTextColor) { }
    }

    internal class QMSingleButton : QMButtonBase
    {
        internal bool State = false;
        internal TMPro.TextMeshProUGUI Text;
        public QMSingleButton(QMWings Parent, string btnText, System.Action btnAction, string btnToolTip, bool IsToggle = false, string TextColor = null)
        {
            initButton2(Parent.WingPage.gameObject, btnText, btnAction, btnToolTip, IsToggle);
        }

        public QMSingleButton(QMNestedButton Parent, float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
        {
            btnQMLoc = Parent.getMenuName();
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);

            if (btnHalf)
            {
                RectTransform Recto = button.GetComponent<RectTransform>();

                if (IsUp)
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition += new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
                else
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
            }
        }

        public QMSingleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, String btnToolTip, string TextColor = null, bool btnHalf = false, bool IsUp = true)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, TextColor);

            if (btnHalf)
            {
                RectTransform Recto = button.GetComponent<RectTransform>();

                if (IsUp)
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition += new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
                else
                {
                    Recto.sizeDelta = new Vector2(Recto.sizeDelta.x, Recto.sizeDelta.y / 2 - 10f);
                    Recto.anchoredPosition -= new Vector2(0, Recto.sizeDelta.y / 2 + 10);
                    button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition -= new Vector2(0, 50);
                }
            }
        }

        //Creates a button for VRC Menus
        private protected void initButton(float btnXLocation, float btnYLocation, string btnText, System.Action btnAction, String btnToolTip, string TextColor = null)
        {
            btnType = "SingleButton";

            switch (btnQMLoc)
            {
                case "Dashboard":
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), QMStuff.MenuDashboard_ButtonsSection(), true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                case "QA_MainMenu":
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), MenuAPI_New.QA_MainMenu.QuickActions.transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                case "QA_SelectedUser":
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplateSelUser(), MenuAPI_New.QA_SelectedUser.QuickActions.transform, true);
                    button.EnableComponents();
                    button.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    break;

                default:
                    var Part1 = QMStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
                    button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
                    initShift[0] = -1;
                    initShift[1] = -3;
                    setLocation(btnXLocation, btnYLocation);
                    break;
            }

            setButtonText(btnText);
            setToolTip(btnToolTip);

            setAction(btnAction);

            button.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition += new Vector2(0, 50);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 26;

            if (TextColor != null)
                setTextColorHTML(TextColor);
            else
                setTextColorHTML("#blue");


            setActive(true);
            //QMButtonAPI.allSingleButtons.Add(this);
        }




        //Creates button and parents it to a GameObject
        private protected void initButton(GameObject Parent, string btnText, System.Action btnAction, String btnToolTip)
        {
            btnType = "SingleButton";

            button = UnityEngine.Object.Instantiate(QMStuff.SingleButtonTemplate(), Parent.FindObject("Buttons").transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;

            setButtonText(btnText);
            setToolTip(btnToolTip);
            setAction(btnAction);

            button.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition += new Vector2(0, 50);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 30;

            //if (btnBackgroundColor != null)
            //    setBackgroundColor((Color)btnBackgroundColor);
            //else
            //    OrigBackground = button.GetComponentInChildren<UnityEngine.UI.Image>().color;

            //if (btnTextColor != null)
            //    setTextColor((Color)btnTextColor);
            //else
            //    OrigText = button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color;

            setActive(true);
            //QMButtonAPI.allSingleButtons.Add(this);
        }

        internal string BtnText;
        private protected void initButton2(GameObject Parent, string btnText, System.Action btnAction, String btnToolTip, bool IsToggle = false)
        {
            btnType = "SingleButton";

            var Layout = Parent.FindObject("VerticalLayoutGroup");
            button = UnityEngine.Object.Instantiate(QMStuff.WingPageButtonTemplate(), Layout.transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            button.SetActive(true);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 35;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().autoSizeTextContainer = true;
            button.AddComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = btnToolTip;
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);

            if (IsToggle)
            {
                BtnText = btnText;
                setOffText();
                btnAction += delegate ()
                {
                    State = !State;
                };
            }
            else
            {
                setButtonText(btnText);
            }


            setAction(btnAction);


            //if (btnBackgroundColor != null)
            //    setBackgroundColor((Color)btnBackgroundColor);
            //else
            //    OrigBackground = button.GetComponentInChildren<UnityEngine.UI.Image>().color;

            //if (btnTextColor != null)
            //    setTextColor((Color)btnTextColor);
            //else
            //    OrigText = button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color;

            //QMButtonAPI.allSingleButtons.Add(this);
        }

        internal void setButtonText(string buttonText)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = buttonText;
        }

        internal void setOnText()
        {
            string Text = BtnText + " <color=green>ON</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
        }

        internal void setOffText()
        {
            string Text = BtnText + " <color=red>OFF</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
        }

        internal void setAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
            {
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
            }
        }


        internal override void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
        }

        internal override void setTextColor(Color buttonTextColor)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = buttonTextColor;
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            string NewText = $"<color={buttonTextColor}>{button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = NewText;
        }
    }

    internal static class Extensions
    {
        internal static void LoadSprite(this GameObject Parent, string LoadSprite, string name)
        {
            foreach (var image in Parent.GetComponentsInChildren<Image>(true))
            {
                if (image.name == name)// allows background image change
                {
                    image.gameObject.SetActive(true);
                    var texture = CheetoUtils.LoadPNG(LoadSprite);
                    image.overrideSprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);

                }
            }
        }
        public static GameObject FindObject(this GameObject parent, string name)
        {
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in trs)
            {
                if (t.name == name)
                {
                    return t.gameObject;
                }
            }
            return null;
        }

        public static void EnableComponents(this GameObject parent)
        {
            parent.GetComponent<Button>().enabled = true;
            parent.GetComponent<LayoutElement>().enabled = true;
            parent.GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
            parent.GetComponentInChildren<VRC.UI.Core.Styles.StyleElement>(true).enabled = true;
            parent.GetComponent<CanvasGroup>().enabled = true;
            parent.GetComponentInChildren<Image>().enabled = true;
            parent.GetComponentInChildren<TMPro.TextMeshProUGUI>(true).enabled = true;
            parent.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().enabled = true;
            UnityEngine.GameObject.Destroy(parent.GetComponent<MonoBehaviourPublic38Bu12Vo37Vo12St37VoUnique>());
        }

        public static TMPro.TextMeshProUGUI NewText(this GameObject Parent, string search)
        {
            TMPro.TextMeshProUGUI text = new TMPro.TextMeshProUGUI();

            var TextTop = Parent.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
            foreach (TMPro.TextMeshProUGUI texto in TextTop)
            {
                if (texto.name == search)
                    text = texto;
            }

            return text;
        }

        public static void CleanButtonsQuickActions(this GameObject Parent)
        {
            TMPro.TextMeshProUGUI text = new TMPro.TextMeshProUGUI();

            var Buttons = Parent.GetComponentsInChildren<Transform>(true);
            foreach (var button in Buttons)
            {
                if (button.name.Contains("Button_") || button.name == "SitStandCalibrateButton" || button.name == "Buttons_AvatarDetails"
                    || button.name == "Buttons_AvatarAuthor")
                    UnityEngine.Object.Destroy(button.gameObject);
            }
        }

        public static void CleanButtonsNestedMenu(this GameObject Parent)
        {
            var ButtonToDelete = Parent.GetComponentsInChildren<Button>(true);
            foreach (var Button in ButtonToDelete)
            {
                if (Button.name.Contains("Camera") || Button.name == "Button_Panorama" || Button.name == "Button_Screenshot"
                    || Button.name == "Button_VrChivePano" || Button.name == "Button_DynamicLight")
                    UnityEngine.Object.Destroy(Button.gameObject);
            }

            var ButtonToDelete2 = Parent.GetComponentsInChildren<Toggle>(true);
            foreach (var Button in ButtonToDelete2)
            {
                if (Button.name == "Button_Steadycam")
                    UnityEngine.Object.Destroy(Button.gameObject);
            }
        }

        public static void CleanButtonsWingMenu(this GameObject Parent)
        {
            var ButtonToDelete = Parent.GetComponentsInChildren<Transform>(true);
            //foreach (var Button in ButtonToDelete)
            //{
            //    if ( Button.name == "Cell_Wing_UserCompact(Clone)" || Button.name == "Cell_Wing_UserCompact(Clone)" || Button.name == "Header_Wing_H3"
            //        /*|| Button.name == "AV3_Text" || Button.name == "Button_ActionMenu"*/)
            //        UnityEngine.Object.Destroy(Button.gameObject);
            //}
            //foreach (var Button in ButtonToDelete)
            //{
            //    if (Button.name.Contains("Wing_Button_") || Button.name == "Expressions_SDK3" || Button.name == "Emotes_SDK2" 
            //        || Button.name == "AV3_Text" || Button.name == "Button_ActionMenu")
            //        UnityEngine.Object.Destroy(Button.gameObject);
            //}
        }

        internal static void PushPage(this MenuStateController _MenuStateController, string Page)
        {
            _MenuStateController.Method_Public_Void_String_UIContext_Boolean_0(Page);
        }

        internal static void CreateMainBackButton(this GameObject NestedPart)
        {
            QMNestedButton.backButton = NestedPart.FindObject("Button_Back");
            QMNestedButton.backButton.SetActive(true);
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                QMStuff.GetQuickMenuInstance().prop_MenuStateController_0.field_Private_UIPage_0.enabled = true;
                QMStuff.GetQuickMenuInstance().prop_MenuStateController_0.SwitchToRootPage("QuickMenuDashboard");
            }));
        }

        internal static void CreateBackButton(this GameObject NestedPart, string menuName)
        {
            QMNestedButton.backButton = NestedPart.FindObject("Button_Back");
            QMNestedButton.backButton.SetActive(true);
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                QuickMenu quickmenu = QMStuff.GetQuickMenuInstance();
                QMStuff.ShowQuickmenuPage(menuName);
            }));
        }

        internal static Color HexToColor(this string hex)
        {
            Color color = Color.white;

            if (ColorUtility.TryParseHtmlString(hex, out color))
            {
                return color;
            }

            return color;
        }
    }
}