﻿namespace AstroClient.xAstroBoy.AstroButtonAPI
{
    using System;
    using TMPro;
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
        internal TextMeshProUGUI Text;
        internal UiTooltip ToolTip;

        public QMWingSingleButton(QMWings Parent, string btnText, Action btnAction, string btnToolTip, Color? TextColor = null)
        {
            string TextColorHTML = null;
            if (TextColor.HasValue) TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(TextColor.Value);
            initButton2(Parent.WingPageTransform.gameObject, btnText, btnAction, btnToolTip, TextColorHTML);
        }

        protected void initButton2(GameObject Parent, string btnText, Action btnAction, string btnToolTip, string TextColor)
        {
            btnType = "WingSingleButton";

            var Layout = Parent.FindObject("VerticalLayoutGroup");
            button = Object.Instantiate(QuickMenuTools.WingPageButtonTemplate(), Layout.transform, true);
            button.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            button.SetActive(true);
            button.GetComponentInChildren<TextMeshProUGUI>().fontSize = 35;
            button.GetComponentInChildren<TextMeshProUGUI>().autoSizeTextContainer = true;
            ToolTip = button.AddComponent<UiTooltip>();
            SetToolTip(btnToolTip);
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);
            Text = button.GetComponentInChildren<TextMeshProUGUI>();
            BtnText = btnText;
            SetButtonText(btnText);
            setAction(btnAction);
        }

        internal void SetButtonText(string buttonText)
        {
            CurrentButtonText = buttonText;
            var NewText = $"<color={CurrentButtonColor}>{CurrentButtonText}</color>";
            button.GetComponentInChildren<TextMeshProUGUI>().text = CurrentButtonText;
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
            button.GetComponentInChildren<TextMeshProUGUI>().text = NewText;
        }
    }
}