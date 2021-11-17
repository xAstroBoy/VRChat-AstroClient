namespace AstroButtonAPI
{
    using System;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class QMSingleButton : QMButtonBase
    {
        public QMSingleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
            if (btnHalf)
            {
                button.GetComponentInChildren<RectTransform>().sizeDelta /= new Vector2(1f, 2.0175f);
            }
        }

        public QMSingleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
            if (btnHalf)
            {
                button.GetComponentInChildren<RectTransform>().sizeDelta /= new Vector2(1f, 2.0175f);
            }
        }

        public QMSingleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            if (btnHalf)
            {
                btnYLocation -= 0.25f;
            }
            InitButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
            if (btnHalf)
            {
                button.GetComponentInChildren<RectTransform>().sizeDelta /= new Vector2(1f, 2.0175f);
            }
        }

        private void InitButton(float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            btnType = "SingleButton";
            button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

            initShift[0] = -1;
            initShift[1] = 0;
            SetLocation(btnXLocation, btnYLocation);
            SetButtonText(btnText);
            SetToolTip(btnToolTip);
            SetAction(btnAction);

            if (btnBackgroundColor != null)
                SetBackgroundColor((Color)btnBackgroundColor);
            else
                OrigBackground = button.GetComponentInChildren<Image>().color;

            if (btnTextColor != null)
                SetTextColor((Color)btnTextColor);
            else
                OrigText = button.GetComponentInChildren<Text>().color;

            SetActive(true);
            QMButtonAPI.allSingleButtons.Add(this);
        }

        public void SetButtonText(string buttonText)
        {
            button.GetComponentInChildren<Text>().text = buttonText;
        }

        public string GetButtonText()
        {
            return button.GetComponentInChildren<Text>().text;
        }

        public void SetAction(Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
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

        public override void SetTextColor(Color buttonTextColor, bool save = true)
        {
            button.GetComponentInChildren<Text>().color = buttonTextColor;
            if (save)
                OrigText = buttonTextColor;
        }
    }
}