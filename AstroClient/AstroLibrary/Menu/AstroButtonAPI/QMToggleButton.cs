namespace AstroButtonAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CheetoLibrary;
    using UnityEngine;
    using UnityEngine.UI;
    internal class QMToggleButton : QMButtonBase
    {
        internal GameObject btnOn;
        internal GameObject btnOff;
        internal bool Toggled = false;
        System.Action btnOnAction = null;
        System.Action btnOffAction = null;

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

        private protected void initButton(System.Action btnActionOn, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOff, string btnToolTip, string TextColor = null, bool shouldSaveInConf = false, bool defaultPosition = false)
        {
            btnType = "_ToggleButton_";

            if (ButtonsPageNestedButton == null)
            {
                var Part1 = QMStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
                button = UnityEngine.Object.Instantiate(QMStuff.ToggleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
            }
            else
            {
                button = UnityEngine.Object.Instantiate(QMStuff.ToggleButtonTemplate(), ButtonsPageNestedButton.transform, true);
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

            button.transform.position = QMStuff.SingleButtonTemplate().transform.position;
            initShift[0] = -1;
            initShift[1] = -3;
            setLocation(btnXLocation, btnYLocation);

            btnOn.GetComponentInChildren<RectTransform>().anchoredPosition -= new Vector2(50, 60);
            btnOff.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(50, -60);

            btnOn.GetComponentInChildren<Image>().overrideSprite = LoadAssets.LoadSprite("check.png");
            btnOff.GetComponentInChildren<Image>().overrideSprite = LoadAssets.LoadSprite("x.png");

            setToolTip(btnToolTip);
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

        internal override void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
            foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
            if (save)
                OrigBackground = buttonBackgroundColor;
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
    }

}