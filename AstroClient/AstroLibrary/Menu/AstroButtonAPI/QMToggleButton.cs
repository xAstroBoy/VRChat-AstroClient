namespace AstroButtonAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CheetoLibrary;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    internal class QMToggleButton : QMButtonBase
    {
        internal GameObject btnOn;
        internal GameObject btnOff;
        private bool State { get; set; }
        internal GameObject ButtonsPageNestedButton;

        System.Action btnOnAction = null;
        System.Action btnOffAction = null;


        public QMToggleButton(QMNestedButton btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            InitButton(btnXLocation, btnYLocation, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, null, null, null, false);
        }

        public QMToggleButton(QMNestedGridMenu btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            InitButton(btnXLocation, btnYLocation, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, null, null, null, false);
        }

        public QMToggleButton(QMTabMenu btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.GetMainButton().GetGameObject();
            InitButton(btnXLocation, btnYLocation, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, null, null, null, false);
        }

        public QMToggleButton(string btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip)
        {
            btnQMLoc = btnMenu;
            InitButton(btnXLocation, btnYLocation, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, null, null, null, false);
        }

        public QMToggleButton(QMNestedGridMenu btnMenu, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            InitButton(0, 0, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }

        public QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            InitButton(btnXLocation, btnYLocation, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }

        public QMToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.GetMainButton().GetGameObject();
            InitButton(btnXLocation, btnYLocation, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }

        public QMToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu;
            InitButton(btnXLocation, btnYLocation, null, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }


        public QMToggleButton(QMNestedGridMenu btnMenu, string Title, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            InitButton(0, 0, Title, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }

        public QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string Title, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            InitButton(btnXLocation, btnYLocation, Title, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }

        public QMToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string Title,  string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.GetMainButton().GetGameObject();
            InitButton(btnXLocation, btnYLocation, Title, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }

        public QMToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string Title ,string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu;
            InitButton(btnXLocation, btnYLocation,  Title, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, defaultPosition);
        }




        internal QMToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOn, System.Action btnActionOff, string btnToolTip, string btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.GetMainButton().GetGameObject();
            initButton(btnActionOn, btnXLocation, btnYLocation, Title, btnActionOff, btnToolTip, btnTextColor, shouldSaveInConfig, defaultPosition);
        }

        internal QMToggleButton(QMNestedGridMenu btnMenu,  string Title, System.Action btnActionOn, System.Action btnActionOff, string btnToolTip, string btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            initButton(btnActionOn, 0, 0, Title, btnActionOff, btnToolTip, btnTextColor, shouldSaveInConfig, defaultPosition);
        }


        internal QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOn, System.Action btnActionOff, string btnToolTip, string btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            ButtonsPageNestedButton = btnMenu.ButtonsMenu;
            initButton(btnActionOn, btnXLocation, btnYLocation, Title, btnActionOff, btnToolTip, btnTextColor, shouldSaveInConfig, defaultPosition);
        }

        internal QMToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOn, System.Action btnActionOff, string btnToolTip, string btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu;
            initButton(btnActionOn, btnXLocation, btnYLocation, Title, btnActionOff, btnToolTip, btnTextColor, shouldSaveInConfig, defaultPosition);
        }


        private void InitButton(float btnXLocation, float btnYLocation, string Title, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool defaultState = false)
        {
            btnType = "_ToggleButton_";

            if (ButtonsPageNestedButton == null)
            {
                var Part1 = QuickMenuStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
                button = UnityEngine.Object.Instantiate(QuickMenuStuff.ToggleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
            }
            else
            {
                button = UnityEngine.Object.Instantiate(QuickMenuStuff.ToggleButtonTemplate(), ButtonsPageNestedButton.transform, true);
            }

            var Texto = button.NewText("Text_H4");
            Texto.text = Title;
            Texto.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, 90);
            button.name = QMButtonAPI.identifier + btnType + Title;
            btnOn = button.FindObject("Icon_On");
            btnOff = button.FindObject("Icon_Off");
            btnOff.SetActive(true);
            btnOn.SetActive(false);
            string TextColorHTML = null;

            if (btnTextColorOn.HasValue)
            {
                TextColorHTML = ColorUtility.ToHtmlStringRGB(btnTextColorOn.Value);
            }

            if (TextColorHTML != null)
                setTextColorHTML(TextColorHTML, Texto);
            else
                setTextColorHTML("#blue", Texto);

            button.transform.position = QuickMenuStuff.SingleButtonTemplate().transform.position;
            initShift[0] = -1;
            initShift[1] = -3;
            SetLocation(btnXLocation, btnYLocation);

            btnOn.GetComponentInChildren<RectTransform>().anchoredPosition -= new Vector2(50, 60);
            btnOff.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(50, -60);

            btnOn.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG("check.png").ToSprite();
            btnOff.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG("cancel.png").ToSprite();

            SetToolTip(btnToolTip);
            setAction(btnActionOn, btnActionOff);
        }


        private protected void initButton(System.Action btnActionOn, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOff, string btnToolTip, string TextColor = null, bool shouldSaveInConf = false, bool defaultPosition = false)
        {
            btnType = "_ToggleButton_";

            if (ButtonsPageNestedButton == null)
            {
                var Part1 = QuickMenuStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
                button = UnityEngine.Object.Instantiate(QuickMenuStuff.ToggleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
            }
            else
            {
                button = UnityEngine.Object.Instantiate(QuickMenuStuff.ToggleButtonTemplate(), ButtonsPageNestedButton.transform, true);
            }

            var Texto = button.NewText("Text_H4");
            Texto.text = Title;
            Texto.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(0, 90);
            button.name = QMButtonAPI.identifier + btnType + Title;
            btnOn = button.FindObject("Icon_On");
            btnOff = button.FindObject("Icon_Off");
            btnOff.SetActive(true);
            btnOn.SetActive(false);

            if (TextColor != null)
                setTextColorHTML(TextColor, Texto);
            else
                setTextColorHTML("#blue", Texto);

            button.transform.position = QuickMenuStuff.SingleButtonTemplate().transform.position;
            initShift[0] = -1;
            initShift[1] = -3;
            SetLocation(btnXLocation, btnYLocation);

            btnOn.GetComponentInChildren<RectTransform>().anchoredPosition -= new Vector2(50, 60);
            btnOff.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(50, -60);

            btnOn.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG("check.png").ToSprite();
            btnOff.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG("cancel.png").ToSprite();

            SetToolTip(btnToolTip);
            setAction(btnActionOn, btnActionOff);
        }

        internal void setTextColorHTML(string buttonTextColor, TMPro.TextMeshProUGUI Texto)
        {
            string NewText = $"<color={buttonTextColor}>{Texto.text}</color>";
            Texto.text = NewText;
        }

        internal void SetButtonText(string Text)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
        }

        internal override void SetBackgroundColor(Color buttonBackgroundColor)
        {
            UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
            foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
        }
        internal static bool IsBeingCreated = true;

        internal static bool ButtonChangedState = false;



        internal void setAction(System.Action buttonOnAction, System.Action buttonOffAction)
        {
            btnOnAction = buttonOnAction;
            btnOffAction = buttonOffAction;

            button.GetComponent<Toggle>().onValueChanged = new Toggle.ToggleEvent();
            button.GetComponentInChildren<Toggle>().onValueChanged.AddListener(new Action<bool>
            ((g) =>
            {
                if (g)
                {
                    if (!IsBeingCreated)
                    {
                        btnOn.SetActive(true);
                        btnOff.SetActive(false);
                        btnOnAction.Invoke();
                    }
                }
                else
                {
                    if (!IsBeingCreated)
                    {
                        btnOn.SetActive(false);
                        btnOff.SetActive(true);
                        btnOffAction.Invoke();
                    }
                }

                ButtonChangedState = true;
            }));
        }

        internal  void SetAction(Action buttonOnAction, Action buttonOffAction)
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

        internal  void SetOnText(string buttonOnText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].text = buttonOnText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].text = buttonOnText;
        }

        internal  void SetOffText(string buttonOffText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[1].text = buttonOffText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[1].text = buttonOffText;
        }




        internal  void SetToggleState(bool toggleOn, bool shouldInvoke = false)
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