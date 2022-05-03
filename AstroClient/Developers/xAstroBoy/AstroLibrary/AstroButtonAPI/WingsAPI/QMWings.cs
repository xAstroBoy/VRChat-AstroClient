using AstroClient.xAstroBoy.AstroButtonAPI.PageGenerators;

namespace AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI
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
        internal string menuName { get; set; }
        internal GameObject VerticalLayoutGroup { get; set; }
        internal string btnType { get; set; } = "WingPage";
        internal MenuStateController CurrentController { get; set; }
        internal bool isLeftWing { get; set; }
        internal string ToolTipText { get; set; }

        internal string CurrentBtnColor { get; set; }
        internal string BtnText { get; set; }
        internal Action OnWingOpen { get; set; }
        internal Action OnWingClose { get; set; }

        internal QMWings(int Index, bool LeftWing, string MenuName, string btnToolTip, Sprite icon = null)
        {
            menuName = "WingPage" + MenuName;
            initButton(Index, LeftWing, MenuName, btnToolTip, icon);

        }

        // TODO : Cleanup and make it prettier and better!
        internal void initButton(int Index, bool LeftWing, string AssignedMenu, string btnToolTip, Sprite icon = null)
        {
            if (LeftWing)
            {
                isLeftWing = true;
                menuName += $"_LEFT_{Guid.NewGuid().ToString()} ";
                ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Left, QuickMenuTools.Wing_Left.gameObject.FindUIObject("VerticalLayoutGroup").transform, true);
                ButtonObject.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = ButtonObject.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerLeft;
                SetToolTip(btnToolTip);
                ButtonObject.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);
                CurrentPage = QuickMenuTools.UIPageTemplate_Left.GeneratePage(QuickMenuTools.WingMenuStateControllerLeft, menuName);
                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                ButtonText_Title.text = $"{MenuName}";
                ButtonText_Title.fontSize = 36;

                var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                VerticalLayoutGroup = CurrentPage.gameObject.FindUIObject("VerticalLayoutGroup");
                VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindUIObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindUIObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.transform.FindObject("WngHeader_H1/LeftItemContainer/Button_Back").gameObject;
                BackButton = backbuttonObject.GetComponent<Button>();

                //PushPage
                SetAction(() =>
                {
                    QuickMenuTools.Wing_Left.ShowWingPage(menuName);
                });
                SetBackButtonAction(() =>
                {
                    QuickMenuTools.Wing_Left.ShowWingPage("Root");

                });
            }
            else
            {
                isLeftWing = false;
                menuName += $"_RIGHT_{Guid.NewGuid().ToString()} ";
                ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Right, QuickMenuTools.Wing_Right.gameObject.FindUIObject("VerticalLayoutGroup").transform, true);
                ButtonObject.name = QMButtonAPI.identifier + btnType + Index;
                MenuName = AssignedMenu;
                ButtonText = ButtonObject.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerRight;

                SetToolTip(btnToolTip);
                ButtonObject.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);
                CurrentPage = QuickMenuTools.UIPageTemplate_Right.GeneratePage(QuickMenuTools.WingMenuStateControllerRight, menuName);


                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                ButtonText_Title.text = $"{MenuName}";
                ButtonText_Title.fontSize = 36;

                var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                VerticalLayoutGroup = CurrentPage.gameObject.FindUIObject("VerticalLayoutGroup");
                VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindUIObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindUIObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.transform.FindObject("WngHeader_H1/LeftItemContainer/Button_Back").gameObject;
                BackButton = backbuttonObject.GetComponent<Button>();
                //PushPage
                SetAction(() =>
                {
                    QuickMenuTools.Wing_Right.ShowWingPage(menuName);
                });
                SetBackButtonAction(() =>
                {
                    QuickMenuTools.Wing_Right.ShowWingPage("Root");
                });

            }

            ButtonObject.LoadSprite(icon, "Icon");
            SetActive(true);
        }

        internal QMWings(QMWings menu, string MenuName, string btnToolTip, Sprite icon = null)
        {
            menuName = "WingSubPage" + MenuName;
            initButton(menu, MenuName, btnToolTip, icon);

        }

        private VRC.UI.Elements.Tooltips.UiTooltip _ButtonToolTip;

        internal VRC.UI.Elements.Tooltips.UiTooltip ButtonToolTip
        {
            get
            {
                if (_ButtonToolTip == null)
                {
                    var attempt1 = ButtonObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
                    if (attempt1 == null)
                    {
                        attempt1 = ButtonObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true);
                    }
                    if (attempt1 == null)
                    {
                        attempt1 = ButtonObject.GetComponentInParent<VRC.UI.Elements.Tooltips.UiTooltip>();
                    }

                    if (attempt1 != null)
                    {
                        return _ButtonToolTip = attempt1;
                    }
                }

                return _ButtonToolTip;
            }
        }

        internal void initButton(QMWings menu, string AssignedMenu, string btnToolTip, Sprite icon = null)
        {
            btnType = "WingSubPage";

            if (menu.isLeftWing)
            {
                isLeftWing = true;
                menuName += $"_LEFT_{Guid.NewGuid().ToString()} ";
                ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Left, menu.VerticalLayoutGroup.transform, true);
                ButtonObject.name = QMButtonAPI.identifier + btnType;
                MenuName = AssignedMenu;
                ButtonText = ButtonObject.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerLeft;

                SetToolTip(btnToolTip);
                CurrentPage = QuickMenuTools.UIPageTemplate_Left.GeneratePage(QuickMenuTools.WingMenuStateControllerLeft, menuName);
                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                ButtonText_Title.text = $"{MenuName}";
                ButtonText_Title.fontSize = 36;

                var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                VerticalLayoutGroup = CurrentPage.gameObject.FindUIObject("VerticalLayoutGroup");
                VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindUIObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindUIObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.gameObject.FindUIObject("Button_Back");
                BackButton = backbuttonObject.GetComponent<Button>();

                SetBackButtonAction(() =>
                {
                    menu.ShowWingsPage();

                });

                //PushPage
                SetAction(() =>
                {
                    QuickMenuTools.Wing_Left.ShowWingPage(menuName);
                });


            }
            else
            {
                isLeftWing = false;
                menuName += $"_RIGHT_{Guid.NewGuid().ToString()} ";
                ButtonObject = Object.Instantiate(QuickMenuTools.WingButtonTemplate_Right, menu.VerticalLayoutGroup.transform, true);
                MenuName = AssignedMenu;
                ButtonText = ButtonObject.NewText("Text_QM_H3");
                ButtonText.text = MenuName;
                CurrentController = QuickMenuTools.WingMenuStateControllerRight;

                SetToolTip(btnToolTip);
                CurrentPage = QuickMenuTools.UIPageTemplate_Right.GeneratePage(QuickMenuTools.WingMenuStateControllerRight, menuName);
                ButtonText_Title = CurrentPage.gameObject.NewText("Text_Title");
                ButtonText_Title.text = $"{MenuName}";
                ButtonText_Title.fontSize = 36;

                var VLGC = CurrentPage.GetComponentInChildren<VerticalLayoutGroup>();
                VLGC.spacing = 12;
                VLGC.m_Spacing = 12;
                VLGC.childScaleHeight = false;
                VLGC.childScaleWidth = false;
                VLGC.childControlHeight = false;
                VLGC.childControlWidth = false;

                VerticalLayoutGroup = CurrentPage.gameObject.FindUIObject("VerticalLayoutGroup");
                VerticalLayoutGroup.transform.FindChild("VerticalLayoutGroup").gameObject.SetActive(false);
                VerticalLayoutGroup.transform.FindChild("Header_Wing_H3").gameObject.SetActive(false);
                CurrentPage.gameObject.FindUIObject("Cell_Wing_Toolbar").SetActive(false);
                var Rect = CurrentPage.gameObject.FindUIObject("Panel_Wing_ScrollRect_Labeled").transform.FindChild("Viewport").GetComponentInChildren<RectTransform>(true);
                Rect.anchoredPosition = new Vector2(0, 110);
                Rect.offsetMin = new Vector2(0, 40);
                backbuttonObject = CurrentPage.gameObject.FindUIObject("Button_Back");
                BackButton = backbuttonObject.GetComponent<Button>();
                SetBackButtonAction(() =>
                {
                    menu.ShowWingsPage();
                });

                //PushPage
                SetAction(() =>
                {
                    QuickMenuTools.Wing_Right.ShowWingPage(menuName);
                });
            }

            ButtonObject.LoadSprite(icon, "Icon");
            SetActive(true);
        }

        internal string GetMenuName()
        {
            return menuName;
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
            Log.Debug("Setting ToolTip");
            SetToolTip(btn.ToolTipText);
            Log.Debug($"Set Tooltip as {btn.ToolTipText}");
            Log.Debug("Setting Button Text");
            SetButtonText(btn.BtnText);
            Log.Debug($"Set Button Text as {btn.BtnText}");
            Log.Debug($"Setting Action...");
            SetAction(() => { btn.GetGameObject().GetComponent<Button>().onClick.Invoke(); });
            Log.Debug($"Done Setting Action!");
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
                if(isLeftWing)
                {
                    QuickMenuTools.WingMenuStateControllerLeft.RemovePage(CurrentPage);
                }
                else
                {
                    QuickMenuTools.WingMenuStateControllerRight.RemovePage(CurrentPage);

                }
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
        internal void SetBackButtonAction(Action buttonAction)
        {
            if (buttonAction != null)
            {
                backbuttonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                backbuttonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(() =>
                {
                    if (buttonAction != null) buttonAction();
                    if (OnWingClose != null) OnWingClose();

                }));
            }
        }

        internal void SetAction(Action buttonAction)
        {
            if (buttonAction != null)
            {
                ButtonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                ButtonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(()=>
                {
                    if (buttonAction != null) buttonAction();
                    if (OnWingOpen != null) OnWingOpen();

                }));

            }
        }

    }
}