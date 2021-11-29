namespace AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI
{
    using System;
    using Il2CppSystem.Collections.Generic;
    using MongoDB.Entities;
    using QuickMenuAPI;
    using TMPro;
    using Tools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Tooltips;
    using Object = UnityEngine.Object;

    internal class QMWings : QMButtonBase
    {
        internal Button BackButton { get; set; }
        internal GameObject backbuttonObject { get; set; }
        internal TextMeshProUGUI ButtonText { get; set; }
        internal TextMeshProUGUI ButtonText_Title { get; set; }
        internal UIPage CurrentPage { get; set; }
        internal string MenuName { get; set; }
        internal Transform WingPageTransform { get; set; }

        internal GameObject VerticalLayoutGroup { get; set; }


        internal MenuStateController CurrentController { get; set; }

        internal UiTooltip ToolTip { get; set; }
        internal bool isLeftWing { get; set; }

        internal QMWings(int Index, bool LeftWing, string MenuName, string btnToolTip, Color? btnBackgroundColor = null, Sprite icon = null)
        {
            btnQMLoc = "WingPage" + MenuName;
            initButton(Index, LeftWing, MenuName, btnToolTip, btnBackgroundColor, icon);
        }


        // TODO : Cleanup and make it prettier and better!
        internal void initButton(int Index, bool LeftWing, string AssignedMenu, string btnToolTip, Color? btnBackgroundColor = null, Sprite icon = null)
        {
            if (LeftWing)
            {
                isLeftWing = true;
                btnQMLoc += $"_LEFT_{Guid.NewGuid().ToString()} ";
                button = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Left, QuickMenuTools.Wing_Left.gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = button.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerLeft;

                SetToolTip(btnToolTip);
                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);
                var Page = QuickMenuTools.UIPageTemplate_Left;
                CurrentPage = Object.Instantiate(Page, Page.transform.parent, true);
                WingPageTransform = CurrentPage.transform;
                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                ButtonText_Title.text = $"{MenuName}";
                ButtonText_Title.fontSize = 36;
                CurrentPage.field_Public_String_0 = btnQMLoc; //Name
                CurrentPage.gameObject.name = btnQMLoc;
                CurrentPage.field_Public_Boolean_0 = true; //_inited
                CurrentPage.field_Private_MenuStateController_0 = CurrentController; //_menuStateController
                CurrentPage.field_Private_List_1_UIPage_0 = new List<UIPage>(); //_pageStack
                CurrentPage.field_Private_List_1_UIPage_0.Add(CurrentPage);
                QuickMenuTools.WingMenuStateControllerLeft.field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, CurrentPage); //_uiPages

                var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                VerticalLayoutGroup = CurrentPage.gameObject.FindObject("VerticalLayoutGroup");
                VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.transform.FindObject("WngHeader_H1/LeftItemContainer/Button_Back").gameObject;
                BackButton = backbuttonObject.GetComponent<Button>();

                //PushPage
                SetAction(() => { QuickMenuTools.Wing_Left.ShowQuickmenuPage(btnQMLoc); });
            }
            else
            {
                isLeftWing = false;
                btnQMLoc += $"_RIGHT_{Guid.NewGuid().ToString()} ";
                button = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Right, QuickMenuTools.Wing_Right.gameObject.FindObject("VerticalLayoutGroup").transform, true);
                button.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = button.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerRight;

                SetToolTip(btnToolTip);
                button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);
                var Page = QuickMenuTools.UIPageTemplate_Right;
                CurrentPage = Object.Instantiate(Page, Page.transform.parent, true);
                WingPageTransform = CurrentPage.transform;
                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                ButtonText_Title.text = $"{MenuName}";
                ButtonText_Title.fontSize = 36;
                CurrentPage.field_Public_String_0 = btnQMLoc; //Name
                CurrentPage.gameObject.name = btnQMLoc;
                CurrentPage.field_Public_Boolean_0 = true; //_inited
                CurrentPage.field_Private_MenuStateController_0 = CurrentController; //_menuStateController
                CurrentPage.field_Private_List_1_UIPage_0 = new List<UIPage>(); //_pageStack
                CurrentPage.field_Private_List_1_UIPage_0.Add(CurrentPage);
                QuickMenuTools.WingMenuStateControllerRight.field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, CurrentPage); //_uiPages

                var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                VerticalLayoutGroup = CurrentPage.gameObject.FindObject("VerticalLayoutGroup");
                VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.transform.FindObject("WngHeader_H1/LeftItemContainer/Button_Back").gameObject;
                BackButton = backbuttonObject.GetComponent<Button>();
                //PushPage
                SetAction(() => { QuickMenuTools.Wing_Right.ShowQuickmenuPage(btnQMLoc); });
            }
            
            button.LoadSprite(icon, "Icon");
            SetActive(true);
        }


        internal QMWings(QMWings menu, string MenuName, string btnToolTip, Color? btnBackgroundColor = null, Sprite icon = null)
        {
            btnQMLoc = "WingSubPage" + MenuName;
            initButton(menu, MenuName, btnToolTip, btnBackgroundColor, icon);
        }


        internal void initButton(QMWings menu, string AssignedMenu, string btnToolTip, Color? btnBackgroundColor = null, Sprite icon = null)
        {
            btnType = "WingSubPage";
            
                if (menu.isLeftWing)
                {
                    isLeftWing = true;
                    btnQMLoc += $"_LEFT_{Guid.NewGuid().ToString()} ";
                    button = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Left, menu.VerticalLayoutGroup.transform, true);
                    button.name = QMButtonAPI.identifier + btnType;
                    MenuName = AssignedMenu;
                    ButtonText = button.NewText("Text_QM_H3");
                    ButtonText.text = MenuName;
                    CurrentController = QuickMenuTools.WingMenuStateControllerLeft;

                    SetToolTip(btnToolTip);
                    var Page = QuickMenuTools.UIPageTemplate_Left;
                    CurrentPage = Object.Instantiate(Page, Page.transform.parent, true);
                    WingPageTransform = CurrentPage.transform;
                    ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                    ButtonText_Title.text = $"{MenuName}";
                    ButtonText_Title.fontSize = 36;
                    CurrentPage.field_Public_String_0 = btnQMLoc; //Name
                    CurrentPage.gameObject.name = btnQMLoc;
                    CurrentPage.field_Public_Boolean_0 = true; //_inited
                    CurrentPage.field_Private_MenuStateController_0 = CurrentController; //_menuStateController
                    CurrentPage.field_Private_List_1_UIPage_0 = new List<UIPage>(); //_pageStack
                    CurrentPage.field_Private_List_1_UIPage_0.Add(CurrentPage);
                    QuickMenuTools.WingMenuStateControllerLeft.field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, CurrentPage); //_uiPages

                    var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                    VLGC.spacing = 12;
                    VLGC.m_Spacing = 12;
                    VLGC.childScaleHeight = false;
                    VLGC.childScaleWidth = false;
                    VLGC.childControlHeight = false;
                    VLGC.childControlWidth = false;

                    VerticalLayoutGroup = CurrentPage.gameObject.FindObject("VerticalLayoutGroup");
                    VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                    VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                    CurrentPage.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                    var Rect = CurrentPage.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                    Rect.anchoredPosition = new Vector2(0, 110);
                    Rect.offsetMin = new Vector2(0, 40);
                    backbuttonObject = CurrentPage.gameObject.FindObject("Button_Back");
                    BackButton = backbuttonObject.GetComponent<Button>();

                    //PushPage
                    SetAction(() => { QuickMenuTools.Wing_Left.ShowQuickmenuPage(btnQMLoc); });
                }
                else
                {
                    isLeftWing = false;
                    btnQMLoc += $"_RIGHT_{Guid.NewGuid().ToString()} ";
                    button = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Right, menu.VerticalLayoutGroup.transform, true);
                    MenuName = AssignedMenu;
                    ButtonText = button.NewText("Text_QM_H3");
                    ButtonText.text = MenuName;
                    CurrentController = QuickMenuTools.WingMenuStateControllerRight;

                    SetToolTip(btnToolTip);
                    var Page = QuickMenuTools.UIPageTemplate_Right;
                    CurrentPage = Object.Instantiate(Page, Page.transform.parent, true);
                    WingPageTransform = CurrentPage.transform;
                    ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                    ButtonText_Title.text = $"{MenuName}";
                    ButtonText_Title.fontSize = 36;
                    CurrentPage.field_Public_String_0 = btnQMLoc; //Name
                    CurrentPage.gameObject.name = btnQMLoc;
                    CurrentPage.field_Public_Boolean_0 = true; //_inited
                    CurrentPage.field_Private_MenuStateController_0 = CurrentController; //_menuStateController
                    CurrentPage.field_Private_List_1_UIPage_0 = new List<UIPage>(); //_pageStack
                    CurrentPage.field_Private_List_1_UIPage_0.Add(CurrentPage);
                    QuickMenuTools.WingMenuStateControllerRight.field_Private_Dictionary_2_String_UIPage_0.Add(btnQMLoc, CurrentPage); //_uiPages

                    var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                    VLGC.spacing = 12;
                    VLGC.m_Spacing = 12;
                    VLGC.childScaleHeight = false;
                    VLGC.childScaleWidth = false;
                    VLGC.childControlHeight = false;
                    VLGC.childControlWidth = false;

                    VerticalLayoutGroup = CurrentPage.gameObject.FindObject("VerticalLayoutGroup");
                    VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                    VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                    CurrentPage.gameObject.FindObject("Cell_Wing_Toolbar").SetActive(false);
                    var Rect = CurrentPage.gameObject.FindObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                    Rect.anchoredPosition = new Vector2(0, 110);
                    Rect.offsetMin = new Vector2(0, 40);
                    backbuttonObject = CurrentPage.gameObject.FindObject("Button_Back");
                    BackButton = backbuttonObject.GetComponent<Button>();

                    //PushPage
                    SetAction(() => { QuickMenuTools.Wing_Right.ShowQuickmenuPage(btnQMLoc); });
                }

                button.LoadSprite(icon, "Icon");
                SetActive(true);
            }


        internal string GetMenuName()
        {
            return btnQMLoc;
        }

        internal UIPage GetPage()
        {
            return CurrentPage;
        }

        internal void SetButtonTitle(string text)
        {
            ButtonText_Title.text = text;
        }

        internal void SetButtonText(string text)
        {
            ButtonText.text = text;
        }

        internal void LoadIcon(Sprite icon)
        {
                button.LoadSprite(icon, "Icon");
        }

        internal void ClickBackButton()
        {
            BackButton.onClick.Invoke();
        }

        internal void SetAction(Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}