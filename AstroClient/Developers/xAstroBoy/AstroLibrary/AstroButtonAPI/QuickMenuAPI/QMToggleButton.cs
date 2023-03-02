﻿using AstroClient.xAstroBoy.Utility;
using Cinemachine;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;

namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using ClientResources.Loaders;
    using Extensions;
    using System;
    using TMPro;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements.Tooltips;
    using Object = UnityEngine.Object;

    internal class QMToggleButton
    {
        public QMToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMTabMenu btnMenu, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMTabMenu btnMenu, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }
        public QMToggleButton(QmQuickActions baseMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false, bool isUserPage = false)
        {
            btnQMLoc = baseMenu.GetMenuName();
            ButtonsMenu = baseMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);

            if (isUserPage)
            {
                //ButtonObject.FindUIObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
            }
        }

        public QMToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMGridTab btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMGridTab btnMenu, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMGridTab btnMenu, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMGridTab btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedGridMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedGridMenu btnMenu, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedGridMenu btnMenu, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedGridMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedButton btnMenu, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedButton btnMenu, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            initButton(0, 0, btnTextOn, btnActionOn, btnTextOn, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        internal GameObject btnOn { get; set; }
        internal GameObject btnOff { get; set; }
        internal RectTransform btnOn_Rect { get; set; }
        internal RectTransform btnOff_Rect { get; set; }
        internal UIWidgets.ImageAdvanced btnOn_Image { get; set; }
        internal UIWidgets.ImageAdvanced btnOff_Image { get; set; }

        internal bool State { get; set; }
        internal string BtnType { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal string CurrentButtonText { get; set; }
        internal string btnQMLoc { get; set; }
        internal Action btnOnAction { get; set; }
        internal Action btnOffAction { get; set; }
        internal Toggle ButtonToggle { get; set; }
        internal Color OffColor { get; set; }
        internal Color OnColor { get; set; }
        internal string CurrentColor { get; set; }
        internal string ButtonText_On { get; set; }
        internal string ButtonText_Off { get; set; }
        private UiToggleTooltip _ButtonToolTip;
        internal GameObject ButtonObject { get; set; }
        private UiToggleTooltip _toolTipCache;
        public UiToggleTooltip ButtonToolTip
        {
            get
            {
                if (_toolTipCache != null) return _toolTipCache;
                var attempt1 = (ButtonObject.GetComponent<UiToggleTooltip>() ?? ButtonObject.GetComponentInChildren<UiToggleTooltip>(true)) ?? ButtonObject.AddComponent<UiToggleTooltip>();
                return attempt1 != null ? _toolTipCache = attempt1 : _toolTipCache;
            }
        }
        internal string ToolTipText { get; set; }

        internal TextMeshProUGUIEx ButtonTitleMesh { get; set; }
        internal TextMeshProUGUIEx ButtonText { get; set; }

        internal void initButton(float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = "", bool DefaultState = false)
        {
            BtnType = "_ToggleButton_";
            var id = $"{QMButtonAPI.identifier}_{BtnType}_{Title}_{btnTextOff}_{btnTextOn}";
            if (ButtonsMenu == null)
            {
                var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindUIObject(btnQMLoc);
                if (Part1 != null) ButtonsMenu = Part1.FindUIObject("Buttons");
            }

            ButtonObject = Object.Instantiate(QuickMenuTools.ToggleButtonTemplate.gameObject, ButtonsMenu.transform, true); 
            ButtonObject.EnableUIComponents();
            ButtonTitleMesh = Extensions.NewText(ButtonObject, "Text_H4");
            ButtonTitleMesh.text = Title;
            ButtonTitleMesh.RemoveComponents<StyleElement>();
            ButtonObject.name = id;
            ButtonText = ButtonObject.GetComponentInChildren<TextMeshProUGUIEx>();
            ButtonToggle = ButtonObject.GetComponentInChildren<Toggle>();
            btnOn = ButtonObject.FindUIObject("Icon_On");
            btnOff = ButtonObject.FindUIObject("Icon_Off");
            btnOn.RemoveComponents<StyleElement>();
            btnOff.RemoveComponents<StyleElement>();
            btnOff.SetActive(true);
            btnOn.SetActive(false);
            btnOff_Rect = btnOff.GetComponentInChildren<RectTransform>();
            btnOn_Rect = btnOn.GetComponentInChildren<RectTransform>();
            btnOff_Image = btnOff.GetComponentInChildren<UIWidgets.ImageAdvanced>();
            btnOn_Image = btnOn.GetComponentInChildren<UIWidgets.ImageAdvanced>();

            OnColor = btnOffColor.GetValueOrDefault(System.Drawing.Color.GreenYellow.ToUnityEngineColor());
            OffColor = btnOffColor.GetValueOrDefault(System.Drawing.Color.Red.ToUnityEngineColor());
            ButtonText_On = btnTextOn;
            ButtonText_Off = btnTextOff;
            setTextColorHTML("#red");
            SetLocation(btnXLocation, btnYLocation);
            btnOn_Rect.anchoredPosition -= new Vector2(50, 0);
            btnOff_Rect.anchoredPosition += new Vector2(50, 0);

            btnOn_Image.overrideSprite = Icons.check_sprite;
            btnOn_Image.MakeBackgroundMoreSolid();

            btnOff_Image.overrideSprite = Icons.cancel_sprite;
            btnOff_Image.MakeBackgroundMoreSolid();

            SetToolTip(btnToolTip);
            SetAction(btnActionOn, btnActionOff);
            SetToggleState(DefaultState);
        }

        internal void Kill_StyleElement()
        {
            ButtonObject.RemoveComponents<StyleElement>();
        }
        internal void setTextColorHTML(string buttonTextColor)
        {
            CurrentColor = buttonTextColor;
            var NewText = $"<color={CurrentColor}>{CurrentButtonText}</color>";
            ButtonText.text = NewText;
        }

        internal void DestroyMe()
        {
            UnityEngine.Object.Destroy(ButtonObject);

        }

        internal void SetToolTip(string text)
        {
            ToolTipText = text;
            ButtonToolTip.SetButtonToolTip(text);
        }

        internal void SetOffButtonText(string Text)
        {
            ButtonText_Off = Text;
            if (!State) SetButtonText(ButtonText_Off);
        }

        internal void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            ButtonObject.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplatePos;
            ButtonObject.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * buttonXLoc);
            ButtonObject.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * buttonYLoc);
        }

        internal void SetOnButtonText(string Text)
        {
            ButtonText_On = Text;
            if (State) SetButtonText(ButtonText_On);
        }

        internal void SetOffColor(Color color)
        {
            OffColor = color;
            if (!State) SetTextColor(OffColor);
        }

        internal void SetOnColor(Color color)
        {
            OnColor = color;
            if (State) SetTextColor(OnColor);
        }

        internal void SetButtonText(string Text)
        {
            CurrentButtonText = Text;
            var NewText = $"<color={CurrentColor}>{CurrentButtonText}</color>";

            ButtonText.text = NewText;
        }

        internal void SetAction(Action buttonOnAction, Action buttonOffAction)
        {
            btnOnAction = buttonOnAction;
            btnOffAction = buttonOffAction;
            ButtonToggle.onValueChanged.AddListener(new Action<bool>
            (state =>
            {
                State = state;
                if (state)
                {
                    btnOn.SetActive(true);
                    btnOff.SetActive(false);
                    SetButtonText(ButtonText_On);
                    SetTextColor(OnColor);
                    btnOnAction.Invoke();
                }
                else
                {
                    btnOn.SetActive(false);
                    btnOff.SetActive(true);
                    SetButtonText(ButtonText_Off);
                    SetTextColor(OffColor);
                    btnOffAction.Invoke();
                }
            }));
        }

        internal void SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
        }

        internal void SetTextColor(Color color)
        {
            setTextColorHTML("#" + ColorUtility.ToHtmlStringRGB(color));
        }

        internal void SetToggleState(bool toggleOn, bool shouldInvoke = false)
        {
            State = toggleOn;
            ButtonToggle.SetIsOnWithoutNotify(toggleOn);
            if (toggleOn)
            {
                SetButtonText(ButtonText_On);
                SetTextColor(OnColor);
                btnOn.SetActive(true);
                btnOff.SetActive(false);
                try
                {
                    if (shouldInvoke) btnOnAction.Invoke();
                }
                catch
                {
                }
            }
            else
            {
                SetButtonText(ButtonText_Off);
                SetTextColor(OffColor);
                btnOn.SetActive(false);
                btnOff.SetActive(true);
                try
                {
                    if (shouldInvoke) btnOffAction.Invoke();
                }
                catch
                {
                }
            }
        }
    }
}