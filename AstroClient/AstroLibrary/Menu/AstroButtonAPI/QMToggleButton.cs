namespace AstroButtonAPI
{
    using System;
    using System.Reflection;
    using CheetoLibrary;
    using TMPro;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    internal class QMToggleButton : QMButtonBase
    {
        internal GameObject btnOn { get; set; }
        internal GameObject btnOff { get; set; }
        private bool State { get; set; }
        internal GameObject ButtonsPageNestedButton { get; set; }
        private string BtnType { get; set; }

        private TMPro.TextMeshProUGUI TextMesh;
        private string ButtonText { get; set; }
        private System.Action btnOnAction { get; set; }
        private System.Action btnOffAction { get; set; }

        private Color btnOffColor { get; set; }
        public bool V { get; }

        public QMToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedGridMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }

        public QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }
        public QMToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = null, bool DefaultToggleState = false)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnOnColor, btnOffColor, Title, DefaultToggleState);
        }


        internal void initButton(float btnXLocation, float btnYLocation, string btnTextOn, System.Action btnActionOn, string btnTextOff, System.Action btnActionOff, string btnToolTip, Color? btnOnColor = null, Color? btnOffColor = null, string Title = "", bool DefaultState = false)
        {
            BtnType = "_ToggleButton_";
            var Part1 = QuickMenuTools.QuickMenuInstance.gameObject.FindObject(btnQMLoc);
            button = UnityEngine.Object.Instantiate<GameObject>(QuickMenuTools.ToggleButtonTemplate.gameObject, Part1.FindObject("Buttons").transform, true);
            Extensions.NewText(button, "Text_H4").text = Title;
            button.name = QMButtonAPI.identifier + BtnType + Title;
            btnOn = button.FindObject("Icon_On");
            btnOff = button.FindObject("Icon_Off");
            btnOff.SetActive(true);
            btnOn.SetActive(false);

            //string TextColorHTML = null;
            //if (btnTextColor.HasValue)
            //{
            //    TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(btnTextColor.Value);
            //}
            //else
            //{
            //}
            setTextColorHTML("#blue");

            button.transform.position = QuickMenuTools.SingleButtonTemplate.transform.position;
            initShift[0] = -1;
            initShift[1] = -3;
            SetLocation(btnXLocation, btnYLocation);

            btnOn.GetComponentInChildren<RectTransform>().anchoredPosition -= new Vector2(50, 0);
            btnOff.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(50, 0);

            btnOn.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.check.png")).ToSprite();
            btnOff.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.cancel.png")).ToSprite();

            SetToolTip(btnToolTip);
            SetAction(btnActionOn, btnActionOff);
        }


        internal void setTextColorHTML(string buttonTextColor)
        {
            string NewText = $"<color={buttonTextColor}>{ButtonText}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = NewText;
        }


        internal void SetButtonText(string Text)
        {
            ButtonText = Text;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
        }

        internal void SetAction(Action buttonOnAction, Action buttonOffAction)
        {
            btnOnAction = buttonOnAction;
            btnOffAction = buttonOffAction;

            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>((Action)(() =>
            {
                if (btnOn.activeSelf)
                {
                    SetToggleState(false, true);
                }
                else
                {
                    SetToggleState(true, true);
                }
            })));
        }
        internal override void SetTextColor(Color color)
        {
            setTextColorHTML("#" + ColorUtility.ToHtmlStringRGB(color));
        }

        internal void SetOnText(string buttonOnText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].text = buttonOnText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].text = buttonOnText;
        }

        internal void SetOffText(string buttonOffText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[1].text = buttonOffText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[1].text = buttonOffText;
        }

        internal void SetToggleState(bool toggleOn, bool shouldInvoke = false)
        {
            btnOn.SetActive(toggleOn);
            btnOff.SetActive(!toggleOn);
            State = toggleOn;
            try
            {
                if (toggleOn && shouldInvoke)
                {
                    if (shouldInvoke)
                    {
                        btnOffAction.Invoke();
                    }
                    btnOn.SetActive(true);
                    btnOff.SetActive(false);
                }
                if (!toggleOn && shouldInvoke)
                {
                    if (shouldInvoke)
                    {
                        btnOffAction.Invoke();
                    }
                    btnOn.SetActive(false);
                    btnOff.SetActive(true);
                }
            }
            catch { }
        }
    }
}