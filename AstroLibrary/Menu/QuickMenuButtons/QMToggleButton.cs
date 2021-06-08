namespace RubyButtonAPI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.UI;
	using Button = UnityEngine.UI.Button;

	public class QMToggleButton : QMButtonBase
    {

		private bool State { get; set; }
		public GameObject btnOn;
        public GameObject btnOff;
        public List<QMButtonBase> showWhenOn = new List<QMButtonBase>();
        public List<QMButtonBase> hideWhenOn = new List<QMButtonBase>();
        public bool shouldSaveInConfig = false;

        private Action btnOnAction = null;
        private Action btnOffAction = null;

        public QMToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool shouldSaveInConfig = true, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            InitButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, shouldSaveInConfig, defaultPosition);
        }

        public QMToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool shouldSaveInConfig = true, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            InitButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, shouldSaveInConfig, defaultPosition);
        }

        public QMToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool shouldSaveInConfig = true, bool defaultPosition = false)
        {
            btnQMLoc = btnMenu;
            InitButton(btnXLocation, btnYLocation, btnTextOn, btnActionOn, btnTextOff, btnActionOff, btnToolTip, btnBackgroundColor, btnTextColorOn, btnTextColorOff, shouldSaveInConfig, defaultPosition);
        }

        private void InitButton(float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool shouldSaveInConf = true, bool defaultState = false)
        {
            btnType = "ToggleButton";
            button = UnityEngine.Object.Instantiate(QuickMenuStuff.ToggleButtonTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

            btnOn = button.transform.Find("Toggle_States_Visible/ON").gameObject;
            btnOff = button.transform.Find("Toggle_States_Visible/OFF").gameObject;

            initShift[0] = -3;
            initShift[1] = -1;
            SetLocation(btnXLocation, btnYLocation);

            SetOnText(btnTextOn);
            SetOffText(btnTextOff);
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].name = "Text_ON";
            btnTextsOn[0].resizeTextForBestFit = true;
            btnTextsOn[0].supportRichText = true;
            btnTextsOn[1].name = "Text_OFF";
            btnTextsOn[1].resizeTextForBestFit = true;
            btnTextsOn[1].supportRichText = true;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].name = "Text_ON";
            btnTextsOff[0].resizeTextForBestFit = true;
            btnTextsOff[0].supportRichText = true;
            btnTextsOff[1].name = "Text_OFF";
            btnTextsOff[1].resizeTextForBestFit = true;
            btnTextsOff[1].supportRichText = true;

            SetToolTip(btnToolTip);
            //button.transform.GetComponentInChildren<UiTooltip>().SetToolTipBasedOnToggle();

            SetAction(btnActionOn, btnActionOff);
            btnOn.SetActive(false);
            btnOff.SetActive(true);

            if (btnBackgroundColor != null)
                SetBackgroundColor((Color)btnBackgroundColor);
            else
                OrigBackground = btnOn.GetComponentsInChildren<Text>().First().color;

            if (btnTextColorOn != null)
                SetTextColorOn((Color)btnTextColorOn);
            else
                OrigText = btnOn.GetComponentsInChildren<Image>().First().color;

            if (btnTextColorOff != null)
                SetTextColorOff((Color)btnTextColorOff);
            else
                OrigText = btnOn.GetComponentsInChildren<Image>().First().color;

            SetActive(true);
            shouldSaveInConfig = shouldSaveInConf;
			State = defaultState;
            SetToggleState(defaultState, false);

            QMButtonAPI.allToggleButtons.Add(this);
            //ButtonSettings.InitToggle(this);
        }

        public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
        {
            Image[] btnBgColorList = btnOn.GetComponentsInChildren<Image>().Concat(btnOff.GetComponentsInChildren<Image>()).ToArray().Concat(button.GetComponentsInChildren<Image>()).ToArray();
            foreach (Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
            if (save)
                OrigBackground = buttonBackgroundColor;
        }

        public override void SetTextColorOn(Color buttonTextColorOn, bool save = true)
        {
            Text[] btnTxtColorOnList = btnOn.GetComponentsInChildren<Text>().ToArray();
            foreach (Text btnText in btnTxtColorOnList) btnText.color = buttonTextColorOn;
            if (save)
                OrigText = buttonTextColorOn;
        }

        public override void SetTextColorOff(Color buttonTextColorOff, bool save = true)
        {
            Text[] btnTxtColorOffList = btnOff.GetComponentsInChildren<Text>().ToArray();
            foreach (Text btnText in btnTxtColorOffList) btnText.color = buttonTextColorOff;
            if (save)
                OrigText = buttonTextColorOff;
        }

		public void SetAction(Action buttonONAction, Action buttonOFFAction)
		{
			button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
			if (buttonONAction != null && buttonOFFAction != null)
				button.GetComponent<Button>().onClick.AddListener(new Action(() =>
				{
					State = !State;
					if (State)
					{
						SetToggleState(true, true);
					}
					else
					{
						SetToggleState(false, true);
					}
				}));
		}


		public bool GetToggleState()
		{
			return State;
		}
		public void SetToggleState(bool toggleOn, bool shouldInvoke = false)
        {
            btnOn.SetActive(toggleOn);
            btnOff.SetActive(!toggleOn);
			State = toggleOn;
            try
            {
                if (toggleOn && shouldInvoke)
                {
                    btnOnAction.Invoke();
                    showWhenOn.ForEach(x => x.SetActive(true));
                    hideWhenOn.ForEach(x => x.SetActive(false));
                }
                if (!toggleOn && shouldInvoke)
                {
                    btnOffAction.Invoke();
                    showWhenOn.ForEach(x => x.SetActive(false));
                    hideWhenOn.ForEach(x => x.SetActive(true));
                }
            }
            catch { }
        }

        public string GetOnText()
        {
            return btnOn.GetComponentsInChildren<Text>()[0].text;
        }

        public void SetOnText(string buttonOnText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].text = buttonOnText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].text = buttonOnText;
        }

        public void SetOffText(string buttonOffText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[1].text = buttonOffText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[1].text = buttonOffText;
        }
    }
}