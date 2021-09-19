﻿namespace Blaze.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class QMToggleButton : QMButtonBase
    {
        public GameObject btnOn;
        public GameObject btnOff;
        public List<QMButtonBase> showWhenOn = new List<QMButtonBase>();
        public List<QMButtonBase> hideWhenOn = new List<QMButtonBase>();
        public bool shouldSaveInConfig = false;
        public bool ToggleState;

        System.Action btnOnAction = null;
        System.Action btnOffAction = null;

        public QMToggleButton(QMNestedButton btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, System.Action btnActionOn, string btnTextOff, System.Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.getMenuName();
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColor, shouldSaveInConfig, defaultPosition);
        }

        public QMToggleButton(string btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, System.Action btnActionOn, string btnTextOff, System.Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool shouldSaveInConfig = false, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu;
            initButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColor, shouldSaveInConfig, defaultPosition);
        }

        private void initButton(int btnXLocation, int btnYLocation, string btnTextOn, System.Action btnActionOn, string btnTextOff, System.Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool shouldSaveInConf = false, bool defaultPosition = false)
        {
            btnType = "ToggleButton";
            button = UnityEngine.Object.Instantiate<GameObject>(QMStuff.ToggleButtonTemplate(), QMStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

            btnOn = button.transform.Find("Toggle_States_Visible/ON").gameObject;
            btnOff = button.transform.Find("Toggle_States_Visible/OFF").gameObject;

            initShift[0] = -3;
            initShift[1] = -1;
            SetLocation(btnXLocation, btnYLocation);

            ToggleState = false;
            setOnText(btnTextOn);
            setOffText(btnTextOff);
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].name = "Text_ON";
            btnTextsOn[0].resizeTextForBestFit = true;
            btnTextsOn[1].name = "Text_OFF";
            btnTextsOn[1].resizeTextForBestFit = true;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].name = "Text_ON";
            btnTextsOff[0].resizeTextForBestFit = true;
            btnTextsOff[1].name = "Text_OFF";
            btnTextsOff[1].resizeTextForBestFit = true;

            SetToolTip(btnToolTip);
            //button.transform.GetComponentInChildren<UiTooltip>().SetToolTipBasedOnToggle();

            setAction(btnActionOn, btnActionOff);
            btnOn.SetActive(false);
            btnOff.SetActive(true);

            if (btnBackgroundColor != null)
                SetBackgroundColor((Color)btnBackgroundColor);
            else
                OrigBackground = btnOn.GetComponentsInChildren<Text>().First().color;

            if (btnTextColor != null)
                SetTextColor((Color)btnTextColor);
            else
                OrigText = btnOn.GetComponentsInChildren<UnityEngine.UI.Image>().First().color;

            SetActive(true);
            shouldSaveInConfig = shouldSaveInConf;
            if (defaultPosition == true)// && !ButtonSettings.Contains(this))
            {
                setToggleState(true, false);
            }

            BlazesAPIs.allToggleButtons.Add(this);
            //ButtonSettings.InitToggle(this);
        }

        public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
            foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
            if (save)
                OrigBackground = (Color)buttonBackgroundColor;
        }

        public override void SetTextColor(Color buttonTextColor, bool save = true)
        {
            Text[] btnTxtColorList = (btnOn.GetComponentsInChildren<Text>()).Concat(btnOff.GetComponentsInChildren<Text>()).ToArray();
            foreach (Text btnText in btnTxtColorList) btnText.color = buttonTextColor;
            if (save)
                OrigText = buttonTextColor;
        }

        public void setAction(System.Action buttonOnAction, System.Action buttonOffAction)
        {
            btnOnAction = buttonOnAction;
            btnOffAction = buttonOffAction;

            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>((System.Action)(() =>
            {
                if (btnOn.activeSelf)
                {
                    ToggleState = false;
                    setToggleState(false, true);
                }
                else
                {
                    ToggleState = true;
                    setToggleState(true, true);
                }
            })));
        }


        public void setToggleState(bool toggleOn, bool shouldInvoke = false)
        {
            btnOn.SetActive(toggleOn);
            btnOff.SetActive(!toggleOn);
            try
            {
                if (toggleOn && shouldInvoke)
                {
                    btnOnAction.Invoke();
                    showWhenOn.ForEach(x => x.SetActive(true));
                    hideWhenOn.ForEach(x => x.SetActive(false));
                }
                else if (!toggleOn && shouldInvoke)
                {
                    btnOffAction.Invoke();
                    showWhenOn.ForEach(x => x.SetActive(false));
                    hideWhenOn.ForEach(x => x.SetActive(true));
                }
            }
            catch { }

            if (shouldSaveInConfig)
            {
                //ButtonSettings.UpdateToggle(this);
            }
        }

        public string getOnText()
        {
            return btnOn.GetComponentsInChildren<Text>()[0].text;
        }

        public void setOnText(string buttonOnText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].text = buttonOnText;
            btnTextsOn[0].supportRichText = true;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].text = buttonOnText;
            btnTextsOff[0].supportRichText = true;
        }

        public void setOffText(string buttonOffText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[1].text = buttonOffText;
            btnTextsOn[1].supportRichText = true;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[1].text = buttonOffText;
            btnTextsOff[1].supportRichText = true;
        }

        public bool GetToggleState()
        {
            return ToggleState;
        }
    }
}