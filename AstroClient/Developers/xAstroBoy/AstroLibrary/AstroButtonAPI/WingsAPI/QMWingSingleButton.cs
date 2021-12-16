namespace AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI
{
    using System;
    using AstroClient.xAstroBoy.Utility;
    using Extensions;
    using QuickMenuAPI;
    using TMPro;
    using Tools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using Object = UnityEngine.Object;

    internal class QMWingSingleButton 
    {
        //public QMWingSingleButton(QMWings Parent, string btnText, System.Action btnAction, string btnToolTip, string TextColor = null)
        //{
        //    initButton2(Parent.WingPage.gameObject, btnText, btnAction, btnToolTip, TextColor);
        //}

        internal string CurrentButtonColor { get; set; }
        internal string CurrentButtonText { get; set; }
        internal TextMeshProUGUI ButtonText { get; set; }

        private VRC.UI.Elements.Tooltips.UiTooltip _ButtonToolTip;
        internal VRC.UI.Elements.Tooltips.UiTooltip ButtonToolTip
        {
            get
            {
                if (_ButtonToolTip == null)
                {
                    var attempt1 = ButtonObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
                    if (attempt1 == null)
                    {
                        attempt1 = ButtonObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true);
                    }
                        if(attempt1 == null)
                        {
                            attempt1 = ButtonObject.GetOrAddComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
                        }
                    if (attempt1 != null)
                    {
                        return _ButtonToolTip = attempt1;
                    }
                }

                return _ButtonToolTip;
            }
        }
        internal string ToolTipText { get; set; }
        internal string btnQMLoc { get; set; }
        internal string btnTag { get; set; }
        internal string btnType { get; set; }
        internal GameObject ButtonObject { get; set; }

        public QMWingSingleButton(QMWings Parent, string btnText, Action btnAction, string btnToolTip, Color? TextColor = null)
        {
            initButton2(Parent.VerticalLayoutGroup.gameObject, btnText, btnAction, btnToolTip, $"#{ColorUtility.ToHtmlStringRGB(TextColor.GetValueOrDefault(Color.white))}");
        }

        protected void initButton2(GameObject VerticalLayoutGroup, string btnText, Action btnAction, string btnToolTip, string TextColor)
        {
            btnType = "WingSingleButton";

            ButtonObject = Object.Instantiate(QuickMenuTools.WingPageButtonTemplate, VerticalLayoutGroup.transform, true);
            ButtonObject.name = QMButtonAPI.identifier + "_" + btnType + "_" + btnText;
            ButtonObject.SetActive(true);
            ButtonObject.GetComponentInChildren<TextMeshProUGUI>().fontSize = 35;
            ButtonObject.GetComponentInChildren<TextMeshProUGUI>().autoSizeTextContainer = true;
            SetToolTip(btnToolTip);
            ButtonObject.GetComponent<RectTransform>().sizeDelta = new Vector2(350, 120);
            ButtonText = ButtonObject.GetComponentInChildren<TextMeshProUGUI>();
            SetButtonText(btnText);
            setAction(btnAction);
        }
        internal void SetToolTip(string text)
        {
            ToolTipText = text;
            ButtonToolTip.SetButtonToolTip(text);
        }

        internal void SetButtonText(string buttonText)
        {
            CurrentButtonText = buttonText;
            var NewText = $"<color={CurrentButtonColor}>{CurrentButtonText}</color>";
            ButtonText.text = CurrentButtonText;
        }


        internal void setAction(Action buttonAction)
        {
            ButtonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null) ButtonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }

        //internal void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        //{
        //    button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
        //}
        internal void SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
        }

        internal void DestroyMe()
        {
            try
            {
                Object.Destroy(ButtonObject);
            }
            catch
            {
            }
        }
        internal void SetInteractable(bool isIntractable)
        {
            ButtonObject.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        internal void SetTextColor(Color buttonTextColor)
        {
            SetTextColorHTML("#" + ColorUtility.ToHtmlStringRGB(buttonTextColor));
        }

        internal void SetTextColorHTML(string buttonTextColor)
        {
            CurrentButtonColor = buttonTextColor;
            var NewText = $"<color={CurrentButtonColor}>{CurrentButtonText}</color>";
            ButtonText.text = NewText;
        }
    }
}