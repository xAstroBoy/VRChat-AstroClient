namespace QuickMenuAPI
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
        internal List<QMButtonBase> showWhenOn = new List<QMButtonBase>();
        internal List<QMButtonBase> hideWhenOn = new List<QMButtonBase>();
        internal bool Toggled = false;

        System.Action btnOnAction = null;
        System.Action btnOffAction = null;

        internal QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string Title, System.Action btnActionOn, System.Action btnActionOff, string btnToolTip, string btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.getMenuName();
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
            var Part1 = QMStuff.GetQuickMenuInstance().gameObject.FindObject(btnQMLoc);
            button = UnityEngine.Object.Instantiate<GameObject>(QMStuff.ToggleButtonTemplate(), Part1.FindObject("Buttons").transform, true);
            Extensions.NewText(button, "Text_H4").text = Title;
            button.name = QMButtonAPI.identifier + btnType + Title;
            btnOn = button.FindObject("Icon_On");
            btnOff = button.FindObject("Icon_Off");
            btnOff.SetActive(true);
            btnOn.SetActive(false);

            if (TextColor != null)
                setTextColorHTML(TextColor);
            else
                setTextColorHTML("#blue");

            button.transform.position = QMStuff.SingleButtonTemplate().transform.position;
            initShift[0] = -1;
            initShift[1] = -3;
            setLocation(btnXLocation, btnYLocation);

            btnOn.GetComponentInChildren<RectTransform>().anchoredPosition -= new Vector2(50, 0);
            btnOff.GetComponentInChildren<RectTransform>().anchoredPosition += new Vector2(50, 0);

            btnOn.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG("check.png").ToSprite();
            btnOff.GetComponentInChildren<Image>().overrideSprite = CheetoUtils.LoadPNG("cancel.png").ToSprite();

            setToolTip(btnToolTip);
            setAction(btnActionOn, btnActionOff);
            //QMButtonAPI.allToggleButtons.Add(this);
        }

        internal void setTextColorHTML(string buttonTextColor)
        {
            string NewText = $"<color={buttonTextColor}>{button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text}</color>";
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = NewText;
        }

        internal override void setBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
            foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
            if (save)
                OrigBackground = buttonBackgroundColor;
        }


        internal void setAction(System.Action buttonOnAction, System.Action buttonOffAction)
        {
            btnOnAction = buttonOnAction;
            btnOffAction = buttonOffAction;

            button.GetComponentInChildren<Toggle>().onValueChanged.AddListener(new Action<bool>
            ((g) =>
            {
                if (g)
                {
                    btnOn.SetActive(true);
                    btnOff.SetActive(false);
                    btnOnAction.Invoke();
                }
                else
                {
                    btnOn.SetActive(false);
                    btnOff.SetActive(true);
                    btnOffAction.Invoke();
                }
            }));
        }
    }
}