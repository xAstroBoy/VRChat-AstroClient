namespace AstroButtonAPI
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    internal class QMWingToggleButton : QMButtonBase
    {
        private bool State { get; set; }
        private TMPro.TextMeshProUGUI ButtonText { get; set; }
        private string BtnText { get; set; }
        private Action OffAction { get; set; }
        private Action OnAction { get; set; }

        public QMWingToggleButton(QMWings Parent, string btnText, System.Action OnAction, System.Action OffAction, string btnToolTip, Color? TextColor = null, bool Defaultstate = false)
        {
            string TextColorHTML = null;
            if (TextColor.HasValue)
            {
                TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(TextColor.Value);
            }
            initButton2(Parent.WingPageTransform.gameObject, btnText, OnAction, OffAction, btnToolTip, TextColorHTML, Defaultstate);
        }

        //public QMWingToggleButton(QMWings Parent, string btnText, System.Action OnAction, System.Action OffAction, string btnToolTip, string TextColor = null , bool Defaultstate = false)
        //{
        //    initButton2(Parent.WingPage.gameObject, btnText, OnAction, OffAction, btnToolTip, TextColor, Defaultstate);
        //}

        protected void initButton2(GameObject Parent, string btnText, System.Action btnONAction, System.Action btnOFFAction, string btnToolTip, string TextColor = null, bool Defaultstate = false)
        {
            btnType = "WingToggleButton";

            var Layout = Parent.FindObject("VerticalLayoutGroup");
            button = UnityEngine.Object.Instantiate(QuickMenuTools.WingPageButtonTemplate(), Layout.transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            button.SetActive(true);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 35;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().autoSizeTextContainer = true;
            button.AddComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = btnToolTip;
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);
            ButtonText = button.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            BtnText = btnText;
            OnAction = OnAction;
            OffAction = OffAction;
            State = Defaultstate;
            if (!State)
            {
                setOffText();
            }
            else
            {
                setOnText();
            }

            SetAction(btnONAction, btnOFFAction);
        }

        internal void setButtonText(string buttonText)
        {
            BtnText = buttonText;
            ButtonText.text = buttonText;
        }

        internal void setOnText()
        {
            string Text = BtnText + " <color=green>ON</color>";
            ButtonText.text = Text;
        }

        internal void setOffText()
        {
            string Text = BtnText + " <color=red>OFF</color>";
            ButtonText.text = Text;
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
                        setOnText();
                        OnAction.Invoke();
                    }
                    else
                    {
                        setOffText();
                        OffAction.Invoke();
                    }
                }));
        }

        internal void SetToggleState(bool toggleOn, bool shouldInvoke = false)
        {
            State = toggleOn;
            if (State)
            {
                setOnText();
            }
            else
            {
                setOffText();
            }
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

        internal void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
        }

        internal void setTextColor(Color buttonTextColor)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = buttonTextColor;
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            string NewText = $"<color={buttonTextColor}>{BtnText}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = NewText;
        }
    }
}