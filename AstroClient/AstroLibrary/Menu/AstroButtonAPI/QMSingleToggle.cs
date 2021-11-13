namespace AstroButtonAPI
{
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Button = UnityEngine.UI.Button;

    internal class QMSingleToggleButton : QMButtonBase
    {
        private bool State { get; set; }
        private string OnText { get; set; }
        private string OffText { get; set; }
        private Color OffColor { get; set; }
        private Color OnColor { get; set; }
        private Action OffAction { get; set; }
        private Action OnAction { get; set; }
        private string btnQMLoc { get; set; }


        internal QMSingleToggleButton(QMNestedGridMenu btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(QMNestedGridMenu btnMenu, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            InitButton(0, 0, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        internal QMSingleToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        private void InitButton(float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFAction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool defaultstate = false, bool btnHalf = false)
        {
            btnType = "SingleToggleButton";
            switch (btnQMLoc)
            {
                case "Dashboard":
                    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, QuickMenuTools.MenuDashboard_ButtonsSection(), true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnONText;
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
                    var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindObject(btnQMLoc);
                    button = UnityEngine.Object.Instantiate(QuickMenuTools.SingleButtonTemplate.gameObject, Part1.FindObject("Buttons").transform, true);
                    button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnONText;
                    initShift[0] = -1;
                    initShift[1] = -3;
                    SetLocation(btnXLocation, btnYLocation);
                    break;
            }

            button.transform.Find("Icon").GetComponentInChildren<Image>().gameObject.SetActive(false);
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
            else
                OrigBackground = button.GetComponentInChildren<Image>().color;

            SetTextColor(defaultstate ? (Color)btnOnColor : (Color)btnOFFColor);
            //OrigText = button.GetComponentInChildren<Text>().color;
            OnColor = btnOnColor == null ? Color.magenta : (Color)btnOnColor;
            OffColor = btnOFFColor == null ? Color.white : (Color)btnOFFColor;
            SetActive(true);
            if (btnHalf)
            {
                SetSize(new Vector2(200, 88));
            }
            //QMButtonAPI.allSingleToggleButtons.Add(this);
        }

        internal void SetButtonText(string buttonText)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = buttonText;
        }
        internal void SetAction(Action buttonONAction, Action buttonOFFAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonONAction != null && buttonOFFAction != null)
                button.GetComponent<Button>().onClick.AddListener(new Action(() =>
                {
                    State = !State;
                    if (State)
                    {
                        SetToggleState(true, true);
                    }
                    else
                    {
                        SetToggleState(false, true);
                    }
                }));
        }

        internal override void SetBackgroundColor(Color buttonBackgroundColor)
        {
            //button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
            //if (save)
            //    OrigBackground = buttonBackgroundColor;
            //UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
            //foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
            button.GetComponentInChildren<Button>().colors = new ColorBlock()
            {
                colorMultiplier = 1f,
                disabledColor = Color.grey,
                highlightedColor = buttonBackgroundColor * 1.5f,
                normalColor = buttonBackgroundColor / 1.5f,
                pressedColor = Color.grey * 1.5f
            };
        }

        internal override void SetTextColorOff(Color buttonTextColorOff)
        {
            OffColor = buttonTextColorOff;
            SetTextColor(buttonTextColorOff);
        }

        internal override void SetTextColorOn(Color buttonTextColorOn)
        {
            OnColor = buttonTextColorOn;
            SetTextColor(buttonTextColorOn);
        }

        internal override void SetTextColor(Color buttonTextColor)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = buttonTextColor;
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
                if (toggleOn && shouldInvoke)
                {
                    OnAction.Invoke();
                }
                if (!toggleOn && shouldInvoke)
                {
                    OffAction.Invoke();
                }
            }
            catch { }
        }

        internal void SetSize(Vector2? size = null)
        {
            if (size == null)
            {
                // Standart Size
                button.GetComponent<RectTransform>().sizeDelta = QuickMenuTools.SingleButtonDefaultSize;
            }
            else
            {
                // New Size
                var Size = (Vector2)size;
                button.GetComponent<RectTransform>().sizeDelta = Size;
            }
        }
    }
}