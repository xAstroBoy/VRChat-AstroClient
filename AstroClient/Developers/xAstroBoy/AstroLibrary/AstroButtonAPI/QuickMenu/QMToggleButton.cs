namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenu
{
    using System;
    using ClientResources.Loaders;
    using TMPro;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using Object = UnityEngine.Object;

    internal class QMToggleButton : QMButtonBase
    {
        private TextMeshProUGUI TextMesh;

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
        private bool State { get; set; }
        internal GameObject ButtonsPageNestedButton { get; set; }
        private string BtnType { get; set; }
        private GameObject ButtonsMenu { get; set; }
        private string CurrentButtonText { get; set; }

        private Action btnOnAction { get; set; }
        private Action btnOffAction { get; set; }

        private Toggle ButtonToggle { get; set; }
        private Color OffColor { get; set; }
        private Color OnColor { get; set; }

        private string CurrentColor { get; set; }
        private TextMeshProUGUI ButtonText { get; set; }

        private string ButtonText_On { get; set; }
        private string ButtonText_Off { get; set; }

        internal void initButton(float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = "", bool DefaultState = false)
        {
            BtnType = "_ToggleButton_";
            var id = $"{QMButtonAPI.identifier}_{BtnType}_{Title}_{btnTextOff}_{btnTextOn}";
            if (ButtonsMenu == null)
            {
                var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindObject(btnQMLoc);
                if (Part1 != null) ButtonsMenu = Part1.FindObject("Buttons");
            }

            button = Object.Instantiate(QuickMenuTools.ToggleButtonTemplate.gameObject, ButtonsMenu.transform, true);
            Extensions.NewText(button, "Text_H4").text = Title;
            button.name = id;
            ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
            btnOn = button.FindObject("Icon_On");
            btnOff = button.FindObject("Icon_Off");
            btnOff.SetActive(true);
            btnOn.SetActive(false);
            if (btnOnColor.HasValue)
                OnColor = btnOnColor.Value;
            else
                OnColor = Color.green;
            if (btnOffColor.HasValue)
                OffColor = btnOffColor.Value;
            else
                OffColor = Color.red;

            ButtonText_On = btnTextOn;
            ButtonText_Off = btnTextOff;
            //string TextColorHTML = null;
            //if (btnTextColor.HasValue)
            //{
            //    TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(btnTextColor.Value);
            //}
            //else
            //{
            //}
            setTextColorHTML("#red");
            ButtonToggle = button.GetComponentInChildren<Toggle>();
            SetLocation(btnXLocation, btnYLocation);
            btnOn.GetComponentInChildren<RectTransform>().anchoredPosition -= new Vector2(50, 0);
            btnOff.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(50, 0);

            btnOn.GetComponentInChildren<Image>().overrideSprite = Icons.check_sprite;

            btnOff.GetComponentInChildren<Image>().overrideSprite = Icons.cancel_sprite;

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

        internal void SetOffButtonText(string Text)
        {
            ButtonText_Off = Text;
            if (!State) SetButtonText(ButtonText_Off);
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

        internal override void SetTextColor(Color color)
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