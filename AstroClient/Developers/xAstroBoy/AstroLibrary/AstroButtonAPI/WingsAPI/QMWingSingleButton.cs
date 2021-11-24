namespace AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI
{
    using System;
    using QuickMenuAPI;
    using TMPro;
    using Tools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using VRC.UI.Elements.Tooltips;
    using Object = UnityEngine.Object;

    internal class QMWingSingleButton : QMButtonBase
    {
        //public QMWingSingleButton(QMWings Parent, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null)
        //{
        //    initButton2(Parent.WingPage.gameObject, btnText, btnAction, btnToolTip, TextColor);
        //}

        internal string BtnText;
        internal string CurrentButtonColor;

        internal string CurrentButtonText;
        internal TextMeshProUGUI ButtonText;
        internal UiTooltip ToolTip;

        public QMWingSingleButton(QMWings Parent, string btnText, Action btnAction, string btnToolTip, Color? TextColor = null)
        {
            initButton2(Parent.VerticalLayoutGroup.gameObject, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
        }

        protected void initButton2(GameObject VerticalLayoutGroup, string btnText, Action btnAction, string btnToolTip, string TextColor)
        {
            btnType = "WingSingleButton";

            button = Object.Instantiate(QuickMenuTools.WingPageButtonTemplate, VerticalLayoutGroup.transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            button.SetActive(true);
            button.GetComponentInChildren<TextMeshProUGUI>().fontSize = 35;
            button.GetComponentInChildren<TextMeshProUGUI>().autoSizeTextContainer = true;
            ToolTip = button.AddComponent<UiTooltip>();
            SetToolTip(btnToolTip);
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);
            ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
            BtnText = btnText;
            SetButtonText(btnText);
            setAction(btnAction);
        }

        internal void SetButtonText(string buttonText)
        {
            CurrentButtonText = buttonText;
            var NewText = $"<color={CurrentButtonColor}>{CurrentButtonText}</color>";
            ButtonText.text = CurrentButtonText;
        }

        internal void setButtonToolTip(string ButtonToolTip)
        {
            ToolTip.field_Public_String_0 = ButtonToolTip;
        }

        internal void setAction(Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null) button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
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
            var NewText = $"<color={CurrentButtonColor}>{CurrentButtonText}</color>";
            ButtonText.text = NewText;
        }
    }
}