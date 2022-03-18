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
        internal Image btnOn_Image { get; set; }
        internal Image btnOff_Image { get; set; }

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

        internal UiToggleTooltip ButtonToolTip
        {
            get
            {
                if (_ButtonToolTip == null)
                {
                    var attempt1 = ButtonObject.GetComponent<UiToggleTooltip>();
                    if (attempt1 == null)
                    {
                        attempt1 = ButtonObject.GetComponentInChildren<UiToggleTooltip>(true);
                    }
                    if (attempt1 == null)
                    {
                        attempt1 = ButtonObject.GetComponentInParent<UiToggleTooltip>();
                    }

                    if (attempt1 != null)
                    {
                        return _ButtonToolTip = attempt1;
                    }
                }

                return _ButtonToolTip;
            }
        }

        internal string ToolTipText { get; set; }

        internal TextMeshProUGUI ButtonTitleMesh { get; set; }
        internal TextMeshProUGUI ButtonText { get; set; }

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
            ButtonTitleMesh = Extensions.NewText(ButtonObject, "Text_H4");
            ButtonTitleMesh.text = Title;
            ButtonObject.name = id;
            ButtonText = ButtonObject.GetComponentInChildren<TextMeshProUGUI>();
            ButtonToggle = ButtonObject.GetComponentInChildren<Toggle>();
            btnOn = ButtonObject.FindUIObject("Icon_On");
            btnOff = ButtonObject.FindUIObject("Icon_Off");
            btnOff.SetActive(true);
            btnOn.SetActive(false);
            btnOff_Rect = btnOff.GetComponentInChildren<RectTransform>();
            btnOn_Rect = btnOn.GetComponentInChildren<RectTransform>();
            btnOff_Image = btnOff.GetComponentInChildren<Image>();
            btnOn_Image = btnOn.GetComponentInChildren<Image>();

            OnColor = btnOffColor.GetValueOrDefault(System.Drawing.Color.GreenYellow.ToUnityEngineColor());
            OffColor = btnOffColor.GetValueOrDefault(System.Drawing.Color.Red.ToUnityEngineColor());
            ButtonText_On = btnTextOn;
            ButtonText_Off = btnTextOff;
            setTextColorHTML("#red");
            SetLocation(btnXLocation, btnYLocation);
            btnOn_Rect.anchoredPosition -= new Vector2(50, 0);
            btnOff_Rect.anchoredPosition += new Vector2(50, 0);

            btnOn_Image.overrideSprite = Icons.check_sprite;

            btnOff_Image.overrideSprite = Icons.cancel_sprite;

            SetToolTip(btnToolTip);
            SetAction(btnActionOn, btnActionOff);
            SetToggleState(DefaultState);
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            CurrentColor = buttonTextColor;
            var NewText = $"<color={CurrentColor}>{CurrentButtonText}</color>";
            ButtonText.text = NewText;
        }

        internal void DestroyMe()
        {
            btnOn.DestroyMeLocal(true);
            btnOff.DestroyMeLocal(true);
            btnOn_Rect.DestroyMeLocal(true);
            btnOff_Rect.DestroyMeLocal(true);
            btnOn_Image.DestroyMeLocal(true);
            btnOff_Image.DestroyMeLocal(true);
            ButtonToggle.DestroyMeLocal(true);
            _ButtonToolTip.DestroyMeLocal(true);
            ButtonObject.DestroyMeLocal(true);
            ButtonTitleMesh.DestroyMeLocal(true);
            ButtonText.DestroyMeLocal(true);
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