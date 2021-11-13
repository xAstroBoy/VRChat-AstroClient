namespace AstroButtonAPI
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    internal class QMWingSingleButton : QMButtonBase
    {
        internal TMPro.TextMeshProUGUI Text;
        internal VRC.UI.Elements.Tooltips.UiTooltip ToolTip;

        internal string CurrentButtonText;
        internal string CurrentButtonColor;

        public QMWingSingleButton(QMWings Parent, string btnText, System.Action btnAction, string btnToolTip, Color? TextColor = null)
        {
            string TextColorHTML = null;
            if (TextColor.HasValue)
            {
                TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(TextColor.Value);
            }
            initButton2(Parent.WingPageTransform.gameObject, btnText, btnAction, btnToolTip, TextColorHTML);
        }

        //public QMWingSingleButton(QMWings Parent, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null)
        //{
        //    initButton2(Parent.WingPage.gameObject, btnText, btnAction, btnToolTip, TextColor);
        //}

        internal string BtnText;

        protected void initButton2(GameObject Parent, string btnText, System.Action btnAction, string btnToolTip, string TextColor)
        {
            btnType = "WingSingleButton";

            var Layout = Parent.FindObject("VerticalLayoutGroup");
            button = UnityEngine.Object.Instantiate(QuickMenuTools.WingPageButtonTemplate(), Layout.transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            button.SetActive(true);
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().fontSize = 35;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().autoSizeTextContainer = true;
            ToolTip = button.AddComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
            SetToolTip(btnToolTip);
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);
            Text = button.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            BtnText = btnText;
            SetButtonText(btnText);
            setAction(btnAction);
        }

        internal void SetButtonText(string buttonText)
        {
            CurrentButtonText = buttonText;
            string NewText = $"<color={CurrentButtonColor}>{CurrentButtonText}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = CurrentButtonText;
        }

        internal void setButtonToolTip(string ButtonToolTip)
        {
            ToolTip.field_Public_String_0 = ButtonToolTip;
        }

        internal void setAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
            {
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
            }
        }

        //internal void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        //{
        //    button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
        //}

        internal void setTextColor(Color buttonTextColor)
        {
            setTextColorHTML("#" + ColorUtility.ToHtmlStringRGB(buttonTextColor));
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            CurrentButtonColor = buttonTextColor;
            string NewText = $"<color={CurrentButtonColor}>{CurrentButtonText}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = NewText;
        }
    }
}