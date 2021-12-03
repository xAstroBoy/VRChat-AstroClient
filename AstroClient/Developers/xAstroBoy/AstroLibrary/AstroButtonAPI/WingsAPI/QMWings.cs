﻿namespace AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI
{
    using System;
    using Extensions;
    using Il2CppSystem.Collections.Generic;
    using QuickMenuAPI;
    using TMPro;
    using Tools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using Object = UnityEngine.Object;

    internal class QMWings
    {
        internal GameObject ButtonObject { get; set; }
        internal Button BackButton { get; set; }
        internal GameObject backbuttonObject { get; set; }
        internal TextMeshProUGUI ButtonText { get; set; }
        internal TextMeshProUGUI ButtonText_Title { get; set; }
        internal UIPage CurrentPage { get; set; }
        internal string MenuName { get; set; }
        internal Transform WingPageTransform { get; set; }
        internal string btnQMLoc { get; set; }
        internal GameObject VerticalLayoutGroup { get; set; }
        internal string btnType { get; set; } = "WingPage";
        internal MenuStateController CurrentController { get; set; }
        internal bool isLeftWing { get; set; }
        internal UiTooltip ButtonToolTip { get; set; }
        internal string ToolTipText { get; set; }

        internal string CurrentBtnColor { get; set; }
        internal string BtnText { get; set; }

        internal QMWings(int Index, bool LeftWing, string MenuName, string btnToolTip,  Sprite icon = null)
        {
            btnQMLoc = "WingPage" + MenuName;
            initButton(Index, LeftWing, MenuName, btnToolTip, icon);
        }


        // TODO : Cleanup and make it prettier and better!
        internal void initButton(int Index, bool LeftWing, string AssignedMenu, string btnToolTip,  Sprite icon = null)
        {
            if (LeftWing)
            {
                isLeftWing = true;
                btnQMLoc += $"_LEFT_{Guid.NewGuid().ToString()} ";
                ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Left, QuickMenuTools.Wing_Left.gameObject.FindObject("VerticalLayoutGroup").transform, true);
                ButtonObject.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = ButtonObject.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerLeft;
                ButtonToolTip = ButtonObject.GetComponentInChildren<UiTooltip>(true);
                SetToolTip(btnToolTip);
                ButtonObject.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);
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
                ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Right, QuickMenuTools.Wing_Right.gameObject.FindObject("VerticalLayoutGroup").transform, true);
                ButtonObject.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = ButtonObject.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerRight;

                ButtonToolTip = ButtonObject.GetComponentInChildren<UiTooltip>(true);
                SetToolTip(btnToolTip);
                ButtonObject.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);
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
            
            ButtonObject.LoadSprite(icon, "Icon");
            SetActive(true);
        }


        internal QMWings(QMWings menu, string MenuName, string btnToolTip, Sprite icon = null)
        {
            btnQMLoc = "WingSubPage" + MenuName;
            initButton(menu, MenuName, btnToolTip, icon);
        }


        internal void initButton(QMWings menu, string AssignedMenu, string btnToolTip, Sprite icon = null)
        {
            btnType = "WingSubPage";
            
                if (menu.isLeftWing)
                {
                    isLeftWing = true;
                    btnQMLoc += $"_LEFT_{Guid.NewGuid().ToString()} ";
                    ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Left, menu.VerticalLayoutGroup.transform, true);
                    ButtonObject.name = QMButtonAPI.identifier + btnType;
                    MenuName = AssignedMenu;
                    ButtonText = ButtonObject.NewText("Text_QM_H3");
                    ButtonText.text = MenuName;
                    CurrentController = QuickMenuTools.WingMenuStateControllerLeft;

                    ButtonToolTip = ButtonObject.GetComponentInChildren<UiTooltip>(true);
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
                    ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Right, menu.VerticalLayoutGroup.transform, true);
                    MenuName = AssignedMenu;
                    ButtonText = ButtonObject.NewText("Text_QM_H3");
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

                ButtonObject.LoadSprite(icon, "Icon");
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


        internal void LoadIcon(Sprite icon)
        { 
            ButtonObject.LoadSprite(icon, "Icon");
        }
        internal void SetToolTip(string text)
        {
            ToolTipText = text;
            ButtonToolTip.SetButtonToolTip(text);
        }



        internal void SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
        }

        internal void ClickBackButton()
        {
            BackButton.onClick.Invoke();
        }
        internal void SetButtonShortcut(QMNestedButton btn)
        {
            SetButtonShortcut(btn.GetMainButton());
        }

        internal void SetButtonShortcut(QMNestedGridMenu btn)
        {
            SetButtonShortcut(btn.GetMainButton());
        }

        internal void SetButtonShortcut(QMSingleButton btn)
        {
            ModConsole.DebugLog("Setting ToolTip");
            SetToolTip(btn.ToolTipText);
            ModConsole.DebugLog($"Set Tooltip as {btn.ToolTipText}");
            ModConsole.DebugLog("Setting Button Text");
            SetButtonText(btn.BtnText);
            ModConsole.DebugLog($"Set Button Text as {btn.BtnText}");
            ModConsole.DebugLog($"Setting Action...");
            SetAction(() => { btn.GetGameObject().GetComponent<Button>().onClick.Invoke(); });
            ModConsole.DebugLog($"Done Setting Action!");
        }
        internal void ClickMe()
        {
            ButtonObject.GetComponent<Button>().onClick.Invoke();
        }

        internal void SetInteractable(bool isIntractable)
        {
            ButtonObject.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        internal void DestroyMe()
        {
            try
            {
                Object.Destroy(ButtonObject);
            }
            catch
            {
            }
        }
        internal void SetTextColor(Color buttonTextColor)
        {
            setTextColorHTML($"#{ColorUtility.ToHtmlStringRGB(buttonTextColor)}");
        }
        internal void setTextColorHTML(string buttonTextColor)
        {
            if (buttonTextColor.IsNotNullOrEmptyOrWhiteSpace())
            {
                CurrentBtnColor = buttonTextColor;
                var NewText = $"<color={buttonTextColor}>{BtnText}</color>";
                ButtonText.text = NewText;
            }
        }
        internal void SetButtonText(string text)
        {
            BtnText = text;
            var NewText = $"<color={CurrentBtnColor}>{text}</color>";
            ButtonText.text = NewText;
        }

        internal void SetAction(Action buttonAction)
        {
            ButtonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                ButtonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}