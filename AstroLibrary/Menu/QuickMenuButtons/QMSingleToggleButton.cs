namespace RubyButtonAPI
{
	using System;
	using UnityEngine;
	using UnityEngine.UI;
	using Button = UnityEngine.UI.Button;

	public class QMSingleToggleButton : QMButtonBase
    {
        private bool State { get; set; }
        private string OnText { get; set; }
        private string OffText { get; set; }
        private Color OffColor { get; set; }
        private Color OnColor { get; set; }
        private Action OffAction { get; set; }
        private Action OnAction { get; set; }

        public QMSingleToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        public QMSingleToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
        }

        public QMSingleToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
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
            button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

            initShift[0] = -1;
            initShift[1] = 0;
            SetLocation(btnXLocation, btnYLocation);
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
                SetSize(new Vector2(420, 210));
            }
            QMButtonAPI.allSingleToggleButtons.Add(this);
        }

        public void SetButtonText(string buttonText)
        {
            button.GetComponentInChildren<Text>().text = buttonText;
        }

        public void SetAction(Action buttonONAction, Action buttonOFFAction)
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

        public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            //button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
            if (save)
                OrigBackground = buttonBackgroundColor;
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

        public override void SetTextColorOff(Color buttonTextColorOff, bool save = true)
        {
            OffColor = buttonTextColorOff;
            SetTextColor(buttonTextColorOff, save);
        }

        public override void SetTextColorOn(Color buttonTextColorOn, bool save = true)
        {
            OnColor = buttonTextColorOn;
            SetTextColor(buttonTextColorOn, save);
        }

		public override void SetTextColor(Color buttonTextColor, bool save = true)
		{
			button.GetComponentInChildren<Text>().color = buttonTextColor;
			//if (save)
			//OrigText = (Color)buttonTextColor;
		}

		public bool GetToggleState()
		{
			return State;
		}

        public void SetToggleState(bool toggleOn, bool shouldInvoke = false)
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

        public void SetSize(Vector2? size = null)
        {
            if (size == null)
            {
                // Standart Size
                button.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 420);
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