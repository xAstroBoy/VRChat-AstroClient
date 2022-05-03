using AstroClient.xAstroBoy.Utility;

namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using Extensions;
    using System;
    using TMPro;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using Object = UnityEngine.Object;

    [Obsolete("Use GridNestedMenu and new QMSingleToggles instead, this class will be removed In future!")]
    internal class QMSingleToggleButton
    {
        internal QMSingleToggleButton(QMNestedGridMenu btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            if (btnHalf) btnYLocation -= 0.25f;
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(QMNestedGridMenu btnMenu, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            if (btnHalf) btnYLocation -= 0.25f;
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(QMGridTab btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsMenu = btnMenu.GetButtonsMenu();
            if (btnHalf) btnYLocation -= 0.25f;
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf) btnYLocation -= 0.25f;
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            if (btnHalf) btnYLocation -= 0.25f;
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(GameObject parent, string btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            ButtonsMenu = parent;
            if (btnHalf) btnYLocation -= 0.25f;
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal string btnQMLoc { get; set; }
        internal string btnTag { get; set; }
        internal string btnType { get; set; }
        internal bool State { get; set; }
        internal string OnText { get; set; }
        internal string OffText { get; set; }
        internal Color OffColor { get; set; }
        internal Color OnColor { get; set; }
        internal Action OffAction { get; set; }
        internal Action OnAction { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal TextMeshProUGUI ButtonText { get; set; }
        internal GameObject ButtonObject { get; set; }

        private VRC.UI.Elements.Tooltips.UiTooltip _ButtonToolTip;

        internal VRC.UI.Elements.Tooltips.UiTooltip ButtonToolTip
        {
            get
            {
                if (_ButtonToolTip == null)
                {
                    return _ButtonToolTip = ButtonObject.GetGetInChildrens_OrAddComponent<VRC.UI.Elements.Tooltips.UiTooltip>(true);
                }

                return _ButtonToolTip;
            }
        }

        internal string ToolTipText { get; set; }

        private void InitButton(float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFAction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool defaultstate = false, bool btnHalf = false)
        {
            btnType = "SingleToggleButton";
            switch (btnQMLoc)
            {
                case "Dashboard":
                    ButtonObject = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, QuickMenuTools.MenuDashboard_ButtonsSection, true);
                    ButtonObject.EnableComponents();
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnONText;
                    break;

                //case "QA_MainMenu":
                //    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_MainMenu.QuickActions.transform, true);
                //    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnONText;
                //    break;

                //case "QA_SelectedUser":
                //    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, MenuAPI_New.QA_SelectedUser.QuickActions.transform, true);
                //    button.EnableComponents();
                //    button.FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
                //    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnONText;
                //    break;

                default:
                    if (ButtonsMenu == null)
                    {
                        var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindUIObject(btnQMLoc);
                        ButtonsMenu = Part1.FindUIObject("Buttons");
                    }

                    ButtonObject = Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, ButtonsMenu.transform, true);
                    ButtonObject.EnableComponents();
                    ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnONText;
                    SetLocation(btnXLocation, btnYLocation);
                    break;
            }

            ButtonObject.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);
            ButtonText = ButtonObject.GetComponentInChildren<TextMeshProUGUI>();
            SetButtonText(defaultstate ? btnONText : btnOffText);
            OnText = btnONText;
            OffText = btnOffText;
            SetToolTip(btnToolTip);
            SetAction(btnONAction, btnOFFAction);
            OnAction = btnONAction;
            OffAction = btnOFFAction;
            State = defaultstate;

            if (btnBackgroundColor != null)
                SetBackgroundColor((Color)btnBackgroundColor);

            SetTextColor(defaultstate ? (Color)btnOnColor : (Color)btnOFFColor);
            //OrigText = button.GetComponentInChildren<Text>().color;
            OnColor = btnOnColor == null ? Color.magenta : (Color)btnOnColor;
            OffColor = btnOFFColor == null ? Color.white : (Color)btnOFFColor;
            SetActive(true);
            if (btnHalf) SetSize(new Vector2(200, 88));
            //QMButtonAPI.allSingleToggleButtons.Add(this);
        }

        internal void SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
        }

        internal void DestroyMe()
        {
            UnityEngine.Object.Destroy(ButtonObject);
        }

        internal void SetButtonText(string buttonText)
        {
            ButtonText.text = buttonText;
        }

        internal void SetToolTip(string text)
        {
            ToolTipText = text;
            ButtonToolTip.SetButtonToolTip(text);
        }

        internal void SetAction(Action buttonONAction, Action buttonOFFAction)
        {
            ButtonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonONAction != null && buttonOFFAction != null)
                ButtonObject.GetComponent<Button>().onClick.AddListener(new Action(() =>
                {
                    State = !State;
                    if (State)
                        SetToggleState(true, true);
                    else
                        SetToggleState(false, true);
                }));
        }

        internal void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            ButtonObject.GetComponent<RectTransform>().anchoredPosition = QuickMenuTools.SingleButtonTemplatePos;
            ButtonObject.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * buttonXLoc);
            ButtonObject.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * buttonYLoc);
        }

        internal void SetBackgroundColor(Color buttonBackgroundColor)
        {
            ButtonObject.GetComponentInChildren<Button>().colors = new ColorBlock
            {
                colorMultiplier = 1f,
                disabledColor = Color.grey,
                highlightedColor = buttonBackgroundColor * 1.5f,
                normalColor = buttonBackgroundColor / 1.5f,
                pressedColor = Color.grey * 1.5f
            };
        }

        internal void SetTextColorOff(Color buttonTextColorOff)
        {
            OffColor = buttonTextColorOff;
            SetTextColor(buttonTextColorOff);
        }

        internal void SetTextColorOn(Color buttonTextColorOn)
        {
            OnColor = buttonTextColorOn;
            SetTextColor(buttonTextColorOn);
        }

        internal void SetTextColor(Color buttonTextColor)
        {
            ButtonText.color = buttonTextColor;
            //if (save)
            //OrigText = (Color)buttonTextColor;
        }

        internal bool GetToggleState()
        {
            return State;
        }

        internal void SetToggleState(bool toggleOn, bool shouldInvoke = false)
        {
            SetButtonText(toggleOn ? OnText : OffText);
            SetTextColor(toggleOn ? OnColor : OffColor);
            State = toggleOn;
            try
            {
                if (toggleOn && shouldInvoke) OnAction.Invoke();
                if (!toggleOn && shouldInvoke) OffAction.Invoke();
            }
            catch
            {
            }
        }

        internal void SetSize(Vector2? size = null)
        {
            if (size == null)
            {
                // Standard Size
                ButtonObject.GetComponent<RectTransform>().sizeDelta = QuickMenuTools.SingleButtonDefaultSize;
            }
            else
            {
                // New Size
                var Size = (Vector2)size;
                ButtonObject.GetComponent<RectTransform>().sizeDelta = Size;
            }
        }
    }
}