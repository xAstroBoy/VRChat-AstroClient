namespace AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI
{
    using System;
    using QuickMenuAPI;
    using TMPro;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements.Tooltips;
    using Object = UnityEngine.Object;

    internal class QMWingToggleButton 
    {
        public QMWingToggleButton(QMWings Parent, string btnText, Action OnAction, Action OffAction, string btnToolTip, Color? TextColor = null, bool Defaultstate = false)
        {
            initButton2(Parent.WingPageTransform.gameObject, btnText, OnAction, OffAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.cyan))}", Defaultstate);
        }

        private bool State { get; set; }
        private TextMeshProUGUI ButtonText { get; set; }
        private string BtnText { get; set; }
        private Action OffAction { get; set; }
        private Action OnAction { get; set; }
        private GameObject button { get; set; }
        internal string btnType { get; set; }
        //public QMWingToggleButton(QMWings Parent, string btnText, System.Action OnAction, System.Action OffAction, string btnToolTip, string TextColor = null , bool Defaultstate = false)
        //{
        //    initButton2(Parent.WingPage.gameObject, btnText, OnAction, OffAction, btnToolTip, TextColor, Defaultstate);
        //}

        protected void initButton2(GameObject Parent, string btnText, Action btnONAction, Action btnOFFAction, string btnToolTip, string TextColor = null, bool Defaultstate = false)
        {
            btnType = "WingToggleButton";

            var Layout = Parent.FindObject("VerticalLayoutGroup");
            button = Object.Instantiate(QuickMenuTools.WingPageButtonTemplate, Layout.transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            button.SetActive(true);
            button.GetComponentInChildren<TextMeshProUGUI>().fontSize = 35;
            button.GetComponentInChildren<TextMeshProUGUI>().autoSizeTextContainer = true;
            button.AddComponent<UiTooltip>().field_Public_String_0 = btnToolTip;
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);
            ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
            BtnText = btnText;
            State = Defaultstate;
            if (!State)
                setOffText();
            else
                setOnText();

            SetAction(btnONAction, btnOFFAction);
        }

        internal void setButtonText(string buttonText)
        {
            BtnText = buttonText;
            ButtonText.text = buttonText;
        }

        internal void setOnText()
        {
            var Text = BtnText + " <color=green>ON</color>";
            ButtonText.text = Text;
        }

        internal void setOffText()
        {
            var Text = BtnText + " <color=red>OFF</color>";
            ButtonText.text = Text;
        }

        internal void SetAction(Action buttonONAction, Action buttonOFFAction)
        {
            OnAction = buttonONAction;
            OffAction = buttonOFFAction;
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
                button.GetComponent<Button>().onClick.AddListener(new Action(() =>
                {
                    State = !State;
                    if (State)
                        SetToggleState(true, true);
                    else
                        SetToggleState(false, true);
                }));
        }


        internal void SetToggleState(bool toggleOn, bool shouldInvoke = false)
        {
            State = toggleOn;
            if (toggleOn)
            {
                setOnText();
            }
            else
            {
                setOffText();
            }
            try
            {
                if (toggleOn && shouldInvoke) OnAction.Invoke();
                if (!toggleOn && shouldInvoke) OffAction.Invoke();
            }
            catch
            {
            }
        }


        internal void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            button.GetComponentInChildren<Image>().color = buttonBackgroundColor;
        }

        internal void setTextColor(Color buttonTextColor)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().color = buttonTextColor;
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            var NewText = $"<color={buttonTextColor}>{BtnText}</color>";
            button.GetComponentInChildren<TextMeshProUGUI>().text = NewText;
        }
    }
}