namespace RubyButtonAPI
{
	using AstroClient;
	using AstroClient.Cheetos;
	using DayClientML2.Utility.Extensions;
	using Il2CppSystem.Reflection;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.UI;
	using Button = UnityEngine.UI.Button;

	// Dubya:
	//Firstly, thanks to Emilia for helping me update this to the unhollower.
	//This adds a couple of new functions compared to the old one, however,
	//like the last one, I will not be providing any support as I will
	//personally not be using melonloader/unhollower in the near future.

	//Look here for a useful example guide:
	//https://github.com/DubyaDude/RubyButtonAPI/blob/master/RubyButtonAPI_Old.cs

	// Day:
	// This is my edited Ruby with more stuff and such.
	// remember this is just an edit and not its own thing,
	// if you have any questions or ways to improve it,
	// you can contact me on discord.gg/day

	public static class QMButtonAPI
	{
		//REPLACE THIS STRING SO YOUR MENU DOESNT COLLIDE WITH OTHER MENUS
		public static string identifier = BuildInfo.Name;

		public static Color mBackground = Color.red;
		public static Color mForeground = Color.white;
		public static Color bBackground = Color.red;
		public static Color bForeground = Color.yellow;
		public static List<QMSingleButton> allSingleButtons = new List<QMSingleButton>();
		public static List<QMToggleButton> allToggleButtons = new List<QMToggleButton>();
		public static List<QMNestedButton> allNestedButtons = new List<QMNestedButton>();
		public static List<QMSingleToggleButton> allSingleToggleButtons = new List<QMSingleToggleButton>();
		public static List<QMInfo> AllInfos = new List<QMInfo>();
	}

	public class QMButtonBase
	{
		protected GameObject button;
		protected string btnQMLoc;
		protected string btnType;
		protected string btnTag;
		protected int[] initShift = { 0, 0 };
		protected Color OrigBackground;
		protected Color OrigText;

		public GameObject GetGameObject()
		{
			return button;
		}

		public void SetActive(bool isActive)
		{
			button.gameObject.SetActive(isActive);
		}

		public void SetIntractable(bool isIntractable)
		{
			if (isIntractable)
			{
				SetBackgroundColor(OrigBackground, false);
				SetTextColor(OrigText, false);
			}
			else
			{
				SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1), false);
				SetTextColor(new Color(0.7f, 0.7f, 0.7f, 1), false); ;
			}
			button.gameObject.GetComponent<Button>().interactable = isIntractable;
		}

		public void SetLocation(float buttonXLoc, float buttonYLoc)
		{
			button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (buttonXLoc + initShift[0]));
			button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));

			btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
			button.name = btnQMLoc + "/" + btnType + btnTag;
			button.GetComponent<Button>().name = btnType + btnTag;
		}

		public void SetRawLocation(float buttonXLoc, float buttonYLoc)
		{
			button.GetComponent<RectTransform>().anchoredPosition = QuickMenuStuff.SingleButtonTemplate().GetComponent<RectTransform>().anchoredPosition + (Vector2.right * (420 * (buttonXLoc + initShift[0])));
			button.GetComponent<RectTransform>().anchoredPosition = QuickMenuStuff.SingleButtonTemplate().GetComponent<RectTransform>().anchoredPosition + (Vector2.down * (420 * (buttonYLoc + initShift[1])));

			btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
			button.name = btnQMLoc + "/" + btnType + btnTag;
			button.GetComponent<Button>().name = btnType + btnTag;
		}

		public void SetToolTip(string buttonToolTip)
		{
			button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;
			button.GetComponent<UiTooltip>().field_Public_String_1 = buttonToolTip;
		}

		public void DestroyMe()
		{
			try
			{
				UnityEngine.Object.Destroy(button);
			}
			catch { }
		}

		public void LoadSprite(string url)
		{
			MelonLoader.MelonCoroutines.Start(LoadSprite(button.GetComponent<Image>(), url));
		}

		private static IEnumerator LoadSprite(Image Instance, string url)
		{
			while (VRCPlayer.field_Internal_Static_VRCPlayer_0 != true) yield return null;
			WWW www = new WWW(url, null, new Il2CppSystem.Collections.Generic.Dictionary<string, string>());
			yield return www;
			Sprite sprite;
			{
				sprite = Sprite.CreateSprite(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
			}
			Instance.sprite = sprite;
			Instance.color = Color.white;
			yield break;
		}

		public void SetParent(QMNestedButton Parent)
		{
			button.transform.SetParent(QuickMenuStuff.GetQuickMenuInstance().transform.Find(Parent.GetMenuName()));
		}

		public void SetParent(Transform Parent)
		{
			button.transform.SetParent(Parent);
		}

		public void SetResizeTextForBestFit(bool resizeTextForBestFit)
		{
			button.gameObject.GetComponentInChildren<Text>().resizeTextForBestFit = resizeTextForBestFit;
		}

		public virtual void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
		{
		}

		public virtual void SetTextColor(Color buttonTextColor, bool save = true)
		{
		}

		public virtual void SetTextColorOn(Color buttonTextColorOn, bool save = true)
		{
		}

		public virtual void SetTextColorOff(Color buttonTextColorOff, bool save = true)
		{
		}
	}

	public class QMTabBase
	{
		protected GameObject button;
		protected GameObject Icon;
		protected string btnQMLoc;
		protected string btnType;
		protected string btnTag;
		protected int[] initShift = { 0, 0 };
		protected Color OrigBackground;

		public GameObject GetGameObject()
		{
			return button;
		}

		public GameObject GetIcon()
		{
			if (Icon == null)
				Icon = button.transform.Find("Icon").gameObject;
			return Icon;
		}

		public void SetActive(bool isActive)
		{
			button.gameObject.SetActive(isActive);
		}

		public void SetIntractable(bool isIntractable)
		{
			if (isIntractable)
			{
				SetBackgroundColor(OrigBackground, false);
			}
			else
			{
				SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1), false);
			}
			button.gameObject.GetComponent<Button>().interactable = isIntractable;
		}

		public void SetLocation(float buttonXLoc)
		{
			//button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (210 * (buttonXLoc + initShift[0]));
			//button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));
			button.transform.SetSiblingIndex((int)buttonXLoc);
			btnTag = "(" + buttonXLoc + ")";
			button.name = btnQMLoc + "/" + btnType + btnTag;
			button.GetComponent<Button>().name = btnType + btnTag;
		}

		public void SetToolTip(string buttonToolTip)
		{
			button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;
			button.GetComponent<UiTooltip>().field_Public_String_1 = buttonToolTip;
		}

		public void DestroyMe()
		{
			try
			{
				UnityEngine.Object.Destroy(button);
			}
			catch { }
		}

		public void LoadSprite(string path)
		{
			var image = GetIcon().GetComponent<Image>();
			var texture = CheetosHelpers.LoadPNG(path);
			image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
			image.color = Color.white;
		}

		public void SetParent(QMNestedButton Parent)
		{
			button.transform.SetParent(QuickMenuStuff.GetQuickMenuInstance().transform.Find(Parent.GetMenuName()));
		}

		public void SetParent(Transform Parent)
		{
			button.transform.SetParent(Parent);
		}

		public virtual void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
		{
		}
	}

	public class QMTabButton : QMTabBase
	{
		public QMTabButton(float btnXLocation, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, string ImageURL = null)
		{
			InitButton(btnXLocation, btnAction, btnToolTip, btnBackgroundColor, ImageURL);
		}

		private void InitButton(float btnXLocation, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, string ImageURL = null)
		{
			btnType = "QMTabButton";
			button = UnityEngine.Object.Instantiate(QuickMenuStuff.TabButtonTemplate(), QuickMenuStuff.TabButtonTemplate().transform.parent, true);

			initShift[0] = 0;
			initShift[1] = 0;
			SetLocation(btnXLocation);
			SetToolTip(btnToolTip);
			SetAction(btnAction);

			if (btnBackgroundColor != null)
				SetBackgroundColor((Color)btnBackgroundColor);
			else
				OrigBackground = button.GetComponent<Image>().color;

			if (ImageURL != null)
				LoadSprite(ImageURL);

			SetActive(true);
		}

		public void SetAction(Action buttonAction)
		{
			button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
			if (buttonAction != null)
				button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
		}

		public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
		{
			//button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
			if (save)
				OrigBackground = buttonBackgroundColor;
			button.GetComponentInChildren<Button>().colors = new ColorBlock()
			{
				colorMultiplier = 1f,
				disabledColor = Color.grey,
				highlightedColor = buttonBackgroundColor * 1.5f,
				normalColor = buttonBackgroundColor / 1.5f,
				pressedColor = Color.grey * 1.5f
			};
		}
	}

	public class QMTabMenu
	{
		protected QMTabButton mainButton;
		protected QMSingleButton backButton;
		protected string menuName;
		protected string btnQMLoc;
		protected string btnType;

		public QMTabMenu(float btnXLocation, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageURL = null)
		{
			InitButton(btnXLocation, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageURL);
		}

		public void InitButton(float btnXLocation, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageURL = null)
		{
			btnType = "QMTabMenu";

			Transform menu = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform);
			menuName = QMButtonAPI.identifier + btnQMLoc + "_" + btnXLocation + "_" + btnToolTip;
			menu.name = menuName;

			mainButton = new QMTabButton(btnXLocation, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageURL);

			Il2CppSystem.Collections.IEnumerator enumerator = menu.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Il2CppSystem.Object obj = enumerator.Current;
				Transform btnEnum = obj.Cast<Transform>();
				if (btnEnum != null)
				{
					UnityEngine.Object.Destroy(btnEnum.gameObject);
				}
			}
			if (backbtnTextColor == null)
			{
				backbtnTextColor = Color.yellow;
			}
			// backButton = new QMSingleButton(menuName, 5, 2, "Back", () => { QuickMenuStuff.ShowQuickmenuPage("ShortcutMenu"); }, "Go Back", backbtnBackgroundColor, backbtnTextColor);
		}

		public string GetMenuName()
		{
			return menuName;
		}

		public QMTabButton GetMainButton()
		{
			return mainButton;
		}

		public QMSingleButton GetBackButton()
		{
			return backButton;
		}

		public void DestroyMe()
		{
			mainButton.DestroyMe();
			backButton.DestroyMe();
		}

		public void OpenMe()
		{
			QuickMenuStuff.ShowQuickmenuPage(menuName);
		}
	}

	public class QMSingleButton : QMButtonBase
	{
		public QMSingleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool btnHalf = false)
		{
			btnQMLoc = btnMenu.GetMenuName();
			if (btnHalf)
			{
				btnYLocation -= 0.25f;
			}
			InitButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
			if (btnHalf)
			{
				button.GetComponentInChildren<RectTransform>().sizeDelta /= new Vector2(1f, 2.0175f);
			}
		}

		public QMSingleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool btnHalf = false)
		{
			btnQMLoc = btnMenu.GetMenuName();
			if (btnHalf)
			{
				btnYLocation -= 0.25f;
			}
			InitButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
			if (btnHalf)
			{
				button.GetComponentInChildren<RectTransform>().sizeDelta /= new Vector2(1f, 2.0175f);
			}
		}

		public QMSingleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool btnHalf = false)
		{
			btnQMLoc = btnMenu;
			if (btnHalf)
			{
				btnYLocation -= 0.25f;
			}
			InitButton(btnXLocation, btnYLocation, btnText, btnAction, btnToolTip, btnBackgroundColor, btnTextColor);
			if (btnHalf)
			{
				button.GetComponentInChildren<RectTransform>().sizeDelta /= new Vector2(1f, 2.0175f);
			}
		}

		private void InitButton(float btnXLocation, float btnYLocation, string btnText, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
		{
			btnType = "SingleButton";
			button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

			initShift[0] = -1;
			initShift[1] = 0;
			SetLocation(btnXLocation, btnYLocation);
			SetButtonText(btnText);
			SetToolTip(btnToolTip);
			SetAction(btnAction);

			if (btnBackgroundColor != null)
				SetBackgroundColor((Color)btnBackgroundColor);
			else
				OrigBackground = button.GetComponentInChildren<Image>().color;

			if (btnTextColor != null)
				SetTextColor((Color)btnTextColor);
			else
				OrigText = button.GetComponentInChildren<Text>().color;

			SetActive(true);
			QMButtonAPI.allSingleButtons.Add(this);
		}

		public void SetButtonText(string buttonText)
		{
			button.GetComponentInChildren<Text>().text = buttonText;
		}

		public string GetButtonText()
		{
			return button.GetComponentInChildren<Text>().text;
		}

		public void SetAction(Action buttonAction)
		{
			button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
			if (buttonAction != null)
				button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
		}

		public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
		{
			//button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
			if (save)
				OrigBackground = buttonBackgroundColor;
			//UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
			//foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
			button.GetComponentInChildren<Button>().colors = new ColorBlock()
			{
				colorMultiplier = 1f,
				disabledColor = Color.grey,
				highlightedColor = buttonBackgroundColor * 1.5f,
				normalColor = buttonBackgroundColor / 1.5f,
				pressedColor = Color.grey * 1.5f
			};
		}

		public override void SetTextColor(Color buttonTextColor, bool save = true)
		{
			button.GetComponentInChildren<Text>().color = buttonTextColor;
			if (save)
				OrigText = buttonTextColor;
		}
	}

	public class QMToggleButton : QMButtonBase
	{
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

		private void InitButton(float btnXLocation, float btnYLocation, string btnTextOn, Action btnActionOn, string btnTextOff, Action btnActionOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColorOn = null, Color? btnTextColorOff = null, bool shouldSaveInConf = true, bool defaultPosition = false)
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
			if (defaultPosition == true)// && !ButtonSettings.Contains(this))
			{
				SetToggleState(true, false);
			}

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

		public void SetAction(Action buttonOnAction, Action buttonOffAction)
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

		public void SetToggleState(bool toggleOn, bool shouldInvoke = false)
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
				if (!toggleOn && shouldInvoke)
				{
					btnOffAction.Invoke();
					showWhenOn.ForEach(x => x.SetActive(false));
					hideWhenOn.ForEach(x => x.SetActive(true));
				}
			}
			catch { }
			if (shouldSaveInConfig)
			{
			}
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

	public class QMSingleToggleButton : QMButtonBase
	{
		private bool State { get; set; }
		private string OnText { get; set; }
		private string OffText { get; set; }
		private Color OffColor { get; set; }
		private Color OnColor { get; set; }
		private Action OffAction { get; set; }
		private Action OnAction { get; set; }

		public QMSingleToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
		{
			btnQMLoc = btnMenu.GetMenuName();
			if (btnHalf)
			{
				btnYLocation -= 0.25f;
			}
			InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
		}

		public QMSingleToggleButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
		{
			btnQMLoc = btnMenu.GetMenuName();
			if (btnHalf)
			{
				btnYLocation -= 0.25f;
			}
			InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
		}

		public QMSingleToggleButton(string btnMenu, float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
		{
			btnQMLoc = btnMenu;
			if (btnHalf)
			{
				btnYLocation -= 0.25f;
			}
			InitButton(btnXLocation, btnYLocation, btnONText, btnONAction, btnOffText, btnOFFction, btnToolTip, btnOnColor, btnOFFColor, btnBackgroundColor, position, btnHalf);
		}

		private void InitButton(float btnXLocation, float btnYLocation, string btnONText, Action btnONAction, string btnOffText, Action btnOFFAction, string btnToolTip, Color? btnOnColor = null, Color? btnOFFColor = null, Color? btnBackgroundColor = null, bool position = false, bool btnHalf = false)
		{
			btnType = "SingleToggleButton";
			button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);

			initShift[0] = -1;
			initShift[1] = 0;
			SetLocation(btnXLocation, btnYLocation);
			SetButtonText(position ? btnONText : btnOffText);
			OnText = btnONText;
			OffText = btnOffText;
			SetToolTip(btnToolTip);
			SetAction(btnONAction, btnOFFAction);
			OnAction = btnONAction;
			OffAction = btnOFFAction;
			State = position;

			if (btnBackgroundColor != null)
				SetBackgroundColor((Color)btnBackgroundColor);
			else
				OrigBackground = button.GetComponentInChildren<Image>().color;

			SetTextColor(position ? (Color)btnOnColor : (Color)btnOFFColor);
			//OrigText = button.GetComponentInChildren<Text>().color;
			OnColor = btnOnColor == null ? Color.magenta : (Color)btnOnColor;
			OffColor = btnOFFColor == null ? Color.white : (Color)btnOFFColor;
			SetActive(true);
			if (btnHalf)
			{
				SetSize(new Vector2(420, 210));
			}
			QMButtonAPI.allSingleToggleButtons.Add(this);
		}

		public void SetButtonText(string buttonText)
		{
			button.GetComponentInChildren<Text>().text = buttonText;
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

		public override void SetBackgroundColor(Color buttonBackgroundColor, bool save = true)
		{
			//button.GetComponentInChildren<UnityEngine.UI.Image>().color = buttonBackgroundColor;
			if (save)
				OrigBackground = buttonBackgroundColor;
			//UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
			//foreach (UnityEngine.UI.Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
			button.GetComponentInChildren<Button>().colors = new ColorBlock()
			{
				colorMultiplier = 1f,
				disabledColor = Color.grey,
				highlightedColor = buttonBackgroundColor * 1.5f,
				normalColor = buttonBackgroundColor / 1.5f,
				pressedColor = Color.grey * 1.5f
			};
		}

		public override void SetTextColorOff(Color buttonTextColorOff, bool save = true)
		{
			OffColor = buttonTextColorOff;
			SetTextColor(buttonTextColorOff, save);
		}

		public override void SetTextColorOn(Color buttonTextColorOn, bool save = true)
		{
			OnColor = buttonTextColorOn;
			SetTextColor(buttonTextColorOn, save);
		}

		public override void SetTextColor(Color buttonTextColor, bool save = true)
		{
			button.GetComponentInChildren<Text>().color = buttonTextColor;
			//if (save)
			//OrigText = (Color)buttonTextColor;
		}

		public void SetToggleState(bool toggleOn, bool shouldInvoke = false)
		{
			SetButtonText(toggleOn ? OnText : OffText);
			SetTextColor(toggleOn ? OnColor : OffColor);
			State = toggleOn;
			try
			{
				if (toggleOn && shouldInvoke)
				{
					OnAction.Invoke();
				}
				if (!toggleOn && shouldInvoke)
				{
					OffAction.Invoke();
				}
			}
			catch { }
		}

		public void SetSize(Vector2? size = null)
		{
			if (size == null)
			{
				// Standart Size
				button.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 420);
			}
			else
			{
				// New Size
				var Size = (Vector2)size;
				button.GetComponent<RectTransform>().sizeDelta = Size;
			}
		}
	}

	public class QMNestedButton
	{
		protected QMSingleButton mainButton;
		protected QMSingleButton backButton;
		protected string menuName;
		protected string btnQMLoc;
		protected string btnType;

		public QMNestedButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
		{
			btnQMLoc = btnMenu.GetMenuName();
			InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
		}

		public QMNestedButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
		{
			btnQMLoc = btnMenu.GetMenuName();
			InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
		}

		public QMNestedButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
		{
			btnQMLoc = btnMenu;
			InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
		}

		public void InitButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
		{
			btnType = "NestedButton";

			Transform menu = UnityEngine.Object.Instantiate(QuickMenuStuff.NestedMenuTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform);
			menuName = $"{QMButtonAPI.identifier}{btnQMLoc}_{btnXLocation}_{btnYLocation}";
			menu.name = menuName;

			mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QuickMenuStuff.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, btnTextColor, btnHalf);

			Il2CppSystem.Collections.IEnumerator enumerator = menu.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Il2CppSystem.Object obj = enumerator.Current;
				Transform btnEnum = obj.Cast<Transform>();
				if (btnEnum != null)
				{
					UnityEngine.Object.Destroy(btnEnum.gameObject);
				}
			}

			if (backbtnTextColor == null)
			{
				backbtnTextColor = Color.yellow;
			}
			QMButtonAPI.allNestedButtons.Add(this);
			backButton = new QMSingleButton(this, 5, 2, "Back", () => { QuickMenuStuff.ShowQuickmenuPage(btnQMLoc); }, "Go Back", backbtnBackgroundColor, backbtnTextColor);
		}

		public string GetMenuName()
		{
			return menuName;
		}

		public QMSingleButton GetMainButton()
		{
			return mainButton;
		}

		public QMSingleButton GetBackButton()
		{
			return backButton;
		}

		public void DestroyMe()
		{
			mainButton.DestroyMe();
			backButton.DestroyMe();
		}

		public void OpenMe()
		{
			QuickMenuStuff.ShowQuickmenuPage(menuName);
		}
	}

	// TODO : ADD TWO ACTIONS THAT CAN RUN WHEN THE SCROLL IS OPEN OR CLOSED.
	public class QMHalfScroll
	{
		public class ScrollObject
		{
			public QMButtonBase ButtonBase;
			public int Index;
		}

		public QMNestedButton BaseMenu;
		public QMSingleButton NextButton;
		public QMSingleButton BackButton;
		public QMSingleButton IndexButton;
		public List<ScrollObject> QMButtons = new List<ScrollObject>();
		private float Posx = 1;
		private float Posy = 0f;
		private int Pos = 0;
		private int Index = 0;
		private Action<QMHalfScroll> OpenAction;
		public int currentMenuIndex = 0;

		public bool ShouldChangePos = true;
		public bool AllowOverStepping = false;
		public bool IgnoreEverything = false;

		public QMHalfScroll(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action<QMHalfScroll> MenuOpenAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
		{
			BaseMenu = new QMNestedButton(btnMenu, btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
			SetAction(MenuOpenAction);
			IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
			IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
			IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
			BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
			{
				ShowMenu(currentMenuIndex - 1);
			}, "Go Back", null, null, true);
			NextButton = new QMSingleButton(BaseMenu, 5, 1.5f, "Next", delegate
			{
				ShowMenu(currentMenuIndex + 1);
			}, "Go Next", null, null, true);
		}

		public QMHalfScroll(QMNestedButton basemenu)
		{
			BaseMenu = basemenu;
			IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
			IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
			IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
			BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
			{
				ShowMenu(currentMenuIndex - 1);
			}, "Go Back", null, null, true);
			NextButton = new QMSingleButton(BaseMenu, 5, 1.5f, "Next", delegate
			{
				ShowMenu(currentMenuIndex + 1);
			}, "Go Next", null, null, true);
		}

		public void ShowMenu(int MenuIndex)
		{
			if (!AllowOverStepping && (MenuIndex < 0 || MenuIndex > Index))
				return;

			foreach (var item in QMButtons)
			{
				if (item.Index == MenuIndex)
					item.ButtonBase?.SetActive(true);
				else
					item.ButtonBase?.SetActive(false);
			}
			currentMenuIndex = MenuIndex;
			IndexButton.SetButtonText("Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString());
		}

		public void SetAction(Action<QMHalfScroll> Open, bool shouldClear = true)
		{
			try
			{
				OpenAction = Open;
				BaseMenu.GetMainButton().SetAction(new Action(() =>
				{
					if (shouldClear) Clear();
					OpenAction.Invoke(this);
					QuickMenuStuff.ShowQuickmenuPage(BaseMenu.GetMenuName());
					ShowMenu(0);
				}));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void Refresh()
		{
			Clear();
			OpenAction?.Invoke(this);
			QuickMenuStuff.ShowQuickmenuPage(BaseMenu.GetMenuName());
			ShowMenu(0);
		}

		public void DestroyMe()
		{
			foreach (var item in QMButtons)
			{
				UnityEngine.Object.Destroy(item.ButtonBase.GetGameObject());
			}
			QMButtons.Clear();
			if (BaseMenu.GetBackButton() != null)
				BaseMenu.GetBackButton().DestroyMe();
			if (IndexButton != null)
				IndexButton.DestroyMe();
			if (BackButton != null)
				BackButton.DestroyMe();
			if (NextButton != null)
				NextButton.DestroyMe();
		}

		public void Clear()
		{
			try
			{
				foreach (var item in QMButtons)
				{
					UnityEngine.Object.Destroy(item.ButtonBase.GetGameObject());
				}
				QMButtons.Clear();
				Posx = 1f;
				Posy = 0f;
				Pos = 0;
				Index = 0;
				currentMenuIndex = 0;
			}
			catch { }
		}

		public void Add(QMButtonBase Button)
		{
			if (!IgnoreEverything)
			{
				if (Posx < 6)
				{
					Posx++;
				}
				if (Posx > 5 && Posy < 2.5)
				{
					Posx = 2;
					Posy += 0.5f;
				}
				if (Pos == 24)
				{
					Posx = 2;
					Posy = 0;
					Pos = 0;
					Index++;
				}
			}
			if (!IgnoreEverything)
				Pos++;

			if (ShouldChangePos)
				Button.SetLocation(Posx, Posy);
			Button.SetActive(false);
			QMButtons.Add(new ScrollObject()
			{
				ButtonBase = Button,
				Index = Index
			});
		}

		public void AddExtraButton(QMButtonBase Button)
		{
			QMButtons.Add(new ScrollObject()
			{
				ButtonBase = Button,
				Index = Index
			});
		}

		public void Add(QMButtonBase Button, int Page, bool ShouldChangePos, float POSX = 0f, float POSY = 0f)
		{
			if (ShouldChangePos)
			{
				Button.SetLocation(POSX, POSY);
			}
			Button.SetActive(false);
			QMButtons.Add(new ScrollObject()
			{
				ButtonBase = Button,
				Index = Page
			});
			if (!IgnoreEverything)
			{
				if (Page > Index)
				{
					Index = Page;
				}
			}
		}

		public void Add(QMButtonBase Button, int Page, float POSX = 0, float POSY = 0)
		{
			if (ShouldChangePos)
				Button.SetLocation(Posx, Posy);
			Button.SetActive(false);
			QMButtons.Add(new ScrollObject()
			{
				ButtonBase = Button,
				Index = Page
			});
			if (!IgnoreEverything)
			{
				if (Page > Index)
				{
					Index = Page;
				}
			}
		}
	}

	public class QMScrollMenu
	{
		public class ScrollObject
		{
			public QMButtonBase ButtonBase;
			public int Index;
		}

		public QMNestedButton BaseMenu;
		public QMSingleButton NextButton;
		public QMSingleButton BackButton;
		public QMSingleButton IndexButton;
		public List<ScrollObject> QMButtons = new List<ScrollObject>();
		private int Posx = 1;
		private int Posy = 0;
		private int Pos = 0;
		private int Index = 0;
		private Action<QMScrollMenu> OpenAction;
		public int currentMenuIndex = 0;

		public bool ShouldChangePos = true;
		public bool AllowOverStepping = false;
		public bool IgnoreEverything = false;

		public QMScrollMenu(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, Action<QMScrollMenu> MenuOpenAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
		{
			BaseMenu = new QMNestedButton(btnMenu, btnXLocation, btnYLocation, btnText, btnToolTip, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
			SetAction(MenuOpenAction);
			IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
			IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
			IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
			BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
			{
				ShowMenu(currentMenuIndex - 1);
			}, "Go Back", null, null, true);
			NextButton = new QMSingleButton(BaseMenu, 5, 1.5f, "Next", delegate
			{
				ShowMenu(currentMenuIndex + 1);
			}, "Go Next", null, null, true);
		}

		public QMScrollMenu(QMNestedButton basemenu)
		{
			BaseMenu = basemenu;
			IndexButton = new QMSingleButton(BaseMenu, 5, 0.5f, "Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString(), delegate { }, "");
			IndexButton.GetGameObject().GetComponentInChildren<Button>().enabled = false;
			IndexButton.GetGameObject().GetComponentInChildren<Image>().enabled = false;
			BackButton = new QMSingleButton(BaseMenu, 5, 0f, "Back", delegate
			{
				ShowMenu(currentMenuIndex - 1);
			}, "Go Back", null, null, true);
			NextButton = new QMSingleButton(BaseMenu, 5, 1.5f, "Next", delegate
			{
				ShowMenu(currentMenuIndex + 1);
			}, "Go Next", null, null, true);
		}

		public void ShowMenu(int MenuIndex)
		{
			if (!AllowOverStepping && (MenuIndex < 0 || MenuIndex > Index))
				return;

			foreach (var item in QMButtons)
			{
				if (item.Index == MenuIndex)
					item.ButtonBase?.SetActive(true);
				else
					item.ButtonBase?.SetActive(false);
			}
			currentMenuIndex = MenuIndex;
			IndexButton.SetButtonText("Page:\n" + (currentMenuIndex + 1).ToString() + " of " + (Index + 1).ToString());
		}

		public void SetAction(Action<QMScrollMenu> Open, bool shouldClear = true)
		{
			try
			{
				OpenAction = Open;
				BaseMenu.GetMainButton().SetAction(new Action(() =>
				{
					if (shouldClear) Clear();
					OpenAction.Invoke(this);
					QuickMenuStuff.ShowQuickmenuPage(BaseMenu.GetMenuName());
					ShowMenu(0);
				}));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void Refresh()
		{
			Clear();
			OpenAction?.Invoke(this);
			QuickMenuStuff.ShowQuickmenuPage(BaseMenu.GetMenuName());
			ShowMenu(0);
		}

		public void DestroyMe()
		{
			foreach (var item in QMButtons)
			{
				UnityEngine.Object.Destroy(item.ButtonBase.GetGameObject());
			}
			QMButtons.Clear();
			if (BaseMenu.GetBackButton() != null)
				BaseMenu.GetBackButton().DestroyMe();
			if (IndexButton != null)
				IndexButton.DestroyMe();
			if (BackButton != null)
				BackButton.DestroyMe();
			if (NextButton != null)
				NextButton.DestroyMe();
		}

		public void Clear()
		{
			try
			{
				foreach (var item in QMButtons)
				{
					UnityEngine.Object.Destroy(item.ButtonBase.GetGameObject());
				}
				QMButtons.Clear();
				Posx = 1;
				Posy = 0;
				Pos = 0;
				Index = 0;
				currentMenuIndex = 0;
			}
			catch { }
		}

		public void Add(QMButtonBase Button)
		{
			if (!IgnoreEverything)
			{
				if (Posx < 6)
				{
					Posx++;
				}
				if (Posx > 5 && Posy < 3)
				{
					Posx = 2;
					Posy++;
				}
				if (Pos == 12)
				{
					Posx = 2;
					Posy = 0;
					Pos = 0;
					Index++;
				}
			}
			if (!IgnoreEverything)
				Pos++;

			if (ShouldChangePos)
				Button.SetLocation(Posx, Posy);
			Button.SetActive(false);
			QMButtons.Add(new ScrollObject()
			{
				ButtonBase = Button,
				Index = Index
			});
		}

		public void Add(QMButtonBase Button, int Page, float POSX = 0, float POSY = 0)
		{
			if (ShouldChangePos)
				Button.SetLocation(Posx, Posy);
			Button.SetActive(false);
			QMButtons.Add(new ScrollObject()
			{
				ButtonBase = Button,
				Index = Page
			});
			if (!IgnoreEverything)
			{
				if (Page > Index)
				{
					Index = Page;
				}
			}
		}
	}

	public class QMInfo
	{
		public GameObject TextObject;
		public GameObject InfoIconObject;
		public GameObject InfoGameObject;
		public Text Text;
		public Image Image;
		private float[] initShift = { 0, 0 };

		public QMInfo(Transform Parent, string text, float Pos_X, float Pos_Y, float Scale_X, float Scale_Y, bool infoIcon = true)
		{
			InfoGameObject = UnityEngine.Object.Instantiate(QuickMenuStuff.GetQuickMenuInstance().transform.Find("/UserInterface/QuickMenu/UserIconMenu/Info").gameObject, Parent);
			InfoGameObject.name = $"QMInfo_{Pos_X}_{Pos_Y}";
			Image = InfoGameObject.GetComponent<Image>();
			InfoIconObject = InfoGameObject.transform.Find("InfoIcon").gameObject;
			TextObject = InfoGameObject.transform.Find("Text").gameObject;
			Text = TextObject.GetComponent<Text>();
			// 420 is pushin it 1 button position to the direction
			SetPositon(new Vector2(Pos_X, Pos_Y));
			// 420 is one button. so 1680,1260 is the whole menu
			SetSize(new Vector2(Scale_X, Scale_Y));
			SetText(text);
			SetInfoIcon(infoIcon);
			QMButtonAPI.AllInfos.Add(this);
		}

		public QMInfo(QMNestedButton Parent, string text, float Pos_X, float Pos_Y, float Scale_X, float Scale_Y, bool infoIcon = true)
		{
			InfoGameObject = UnityEngine.Object.Instantiate(QuickMenuStuff.GetQuickMenuInstance().transform.Find("/UserInterface/QuickMenu/UserIconMenu/Info").gameObject,
				QuickMenuStuff.GetQuickMenuInstance().transform.Find(Parent.GetMenuName()));
			InfoGameObject.name = $"QMInfo_{Pos_X}_{Pos_Y}";
			Image = InfoGameObject.GetComponent<Image>();
			InfoIconObject = InfoGameObject.transform.Find("InfoIcon").gameObject;
			TextObject = InfoGameObject.transform.Find("Text").gameObject;
			Text = TextObject.GetComponent<Text>();
			// 420 is pushin it 1 button position to the direction
			SetPositon(new Vector2(Pos_X, Pos_Y));
			// 420 is one button. so 1680,1260 is the whole menu
			SetSize(new Vector2(Scale_X, Scale_Y));
			SetText(text);
			SetInfoIcon(infoIcon);
			QMButtonAPI.AllInfos.Add(this);
		}

		public void SetText(string text)
		{
			Text.text = text;
		}

		public void SetSize(Vector2 size)
		{
			InfoGameObject.GetComponent<RectTransform>().sizeDelta = size;
			TextObject.GetComponent<RectTransform>().sizeDelta = new Vector2(TextObject.GetComponent<RectTransform>().sizeDelta.x, size.y);
		}

		public void SetPositon(Vector2 Position)
		{
			InfoGameObject.GetComponent<RectTransform>().anchoredPosition = Position;
		}

		public void SetInfoIcon(bool state)
		{
			InfoIconObject.SetActive(state);
		}
	}

	public class QMSlider
	{
		public GameObject Slider;
		public Text label;
		public Text SliderLabel;
		private GameObject labelObj;
		private bool displayState;
		private float[] initShift = { 0, 0 };

		public QMSlider(Transform parent, string name, float x, float y, Action<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f, bool DisplayState = true)
		{
			Slider = UnityEngine.Object.Instantiate(QuickMenuStuff.GetVRCUiMInstance().GetMenuContent().transform.Find("Screens/Settings/VolumePanel/VolumeGameWorld"), parent).gameObject;
			UnityEngine.Object.Destroy(Slider.GetComponent<UiSettingConfig>());
			Slider.name = "QMSlider";
			labelObj = Slider.transform.Find("Label").gameObject;
			label = labelObj.GetComponent<Text>();
			SliderLabel = Slider.transform.Find("SliderLabel").GetComponent<Text>();
			displayState = DisplayState;
			// Day: this still needs work
			initShift[0] = -1f;
			initShift[1] = -0.5f;
			Slider.GetComponentInChildren<RectTransform>().anchorMin += new Vector2(0.06f, 0f);
			Slider.GetComponentInChildren<RectTransform>().anchorMax += new Vector2(0.1f, 0f);
			Slider.GetComponentInChildren<Slider>().onValueChanged = new Slider.SliderEvent();
			Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(evt);
			if (DisplayState)
				Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(new Action<float>((value) =>
				{
					SetSliderLabelText(Slider.GetComponentInChildren<Slider>().value.ToString("0.00"));
				}));

			SetRawPos(x, y);
			SetMaxValue(MaxValue);
			SetMinValue(MinValue);
			SetValue(defaultValue);
			SetTextLabel(name);
		}

		public QMSlider(QMNestedButton parent, string name, float x, float y, Action<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f, bool DisplayState = true)
		{
			Slider = UnityEngine.Object.Instantiate(QuickMenuStuff.GetVRCUiMInstance().GetMenuContent().transform.Find("Screens/Settings/VolumePanel/VolumeGameWorld"), QuickMenuStuff.GetQuickMenuInstance().transform.Find(parent.GetMenuName())).gameObject;
			UnityEngine.Object.Destroy(Slider.GetComponent<UiSettingConfig>());
			Slider.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
			Slider.name = "QMSlider";
			labelObj = Slider.transform.Find("Label").gameObject;
			label = labelObj.GetComponent<Text>();
			SliderLabel = Slider.transform.Find("SliderLabel").GetComponent<Text>();
			displayState = DisplayState;
			// Day: this still needs work
			initShift[0] = -1f;
			initShift[1] = -0.5f;
			Slider.GetComponentInChildren<RectTransform>().anchorMin += new Vector2(0.06f, 0f);
			Slider.GetComponentInChildren<RectTransform>().anchorMax += new Vector2(0.1f, 0f);
			Slider.GetComponentInChildren<Slider>().onValueChanged = new Slider.SliderEvent();
			Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(evt);
			if (DisplayState)
				Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(new Action<float>((value) =>
				{
					SetSliderLabelText(Slider.GetComponentInChildren<Slider>().value.ToString("0.00"));
				}));

			SetMaxValue(MaxValue);
			SetMinValue(MinValue);
			SetValue(defaultValue);
			SetTextLabel(name);
			SetRawPos(x, y);
		}

		public void SetMaxValue(float MaxValue)
		{
			Slider.GetComponentInChildren<Slider>().maxValue = MaxValue;
		}

		public void SetMinValue(float MinValue)
		{
			Slider.GetComponentInChildren<Slider>().minValue = MinValue;
		}

		public void SetPos(float SliderXLoc, float SliderYLoc)
		{
			Slider.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (SliderXLoc + initShift[0]));
			Slider.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (SliderYLoc + initShift[1]));
		}

		public void SetRawPos(float SliderXLoc, float SliderYLoc)
		{
			Slider.GetComponent<RectTransform>().anchoredPosition = new Vector2(SliderXLoc, SliderYLoc);
		}

		public void SetValue(float Value)
		{
			Slider.GetComponentInChildren<Slider>().value = Value;
			SetSliderLabelText(Value.ToString());
		}

		public void SetTextLabel(string text)
		{
			label.text = text;
		}

		public void SetSliderLabelText(string Text)
		{
			SliderLabel.text = Text;
		}

		public void SetLocalLabelPosition(float x, float y)
		{
			labelObj.transform.position = new Vector3(x, y);
		}
	}

	public class QuickMenuStuff
	{
		// Internal cache of the BoxCollider Background for the Quick Menu
		private static BoxCollider QuickMenuBackgroundReference;

		private static GameObject TabButtonReference;

		// Internal cache of the Single Button Template for the Quick Menu
		private static GameObject SingleButtonReference;

		// Internal cache of the Toggle Button Template for the Quick Menu
		private static GameObject ToggleButtonReference;

		// Internal cache of the Nested Menu Template for the Quick Menu
		private static Transform NestedButtonReference;

		// Internal cache of the QuickMenu
		private static QuickMenu quickmenuInstance;

		// Internal cache of the VRCUiManager
		private static VRCUiManager vrcuimInstance;

		// Fetch the background from the Quick Menu
		public static BoxCollider QuickMenuBackground()
		{
			if (QuickMenuBackgroundReference == null)
				QuickMenuBackgroundReference = GetQuickMenuInstance().GetComponent<BoxCollider>();
			return QuickMenuBackgroundReference;
		}

		// Fetch the Single Button Template from the Quick Menu
		public static GameObject SingleButtonTemplate()
		{
			if (SingleButtonReference == null)
				SingleButtonReference = GetQuickMenuInstance().transform.Find("ShortcutMenu/WorldsButton").gameObject;
			return SingleButtonReference;
		}

		public static GameObject TabButtonTemplate()
		{
			// var Tab1 = GameObject.Find("/UserInterface/QuickMenu/QuickModeTabs/HomeTab");
			// var Tab2 = GameObject.Find("/UserInterface/QuickMenu/QuickModeTabs/NotificationsTab");
			if (TabButtonReference == null)
				TabButtonReference = GameObject.Find("/UserInterface/QuickMenu/QuickModeTabs/HomeTab");
			return TabButtonReference;
		}

		// Fetch the Toggle Button Template from the Quick Menu
		public static GameObject ToggleButtonTemplate()
		{
			if (ToggleButtonReference == null)
			{
				ToggleButtonReference = GetQuickMenuInstance().transform.Find("UserInteractMenu/BlockButton").gameObject;
			}
			return ToggleButtonReference;
		}

		// Fetch the Nested Menu Template from the Quick Menu
		public static Transform NestedMenuTemplate()
		{
			if (NestedButtonReference == null)
			{
				NestedButtonReference = GetQuickMenuInstance().transform.Find("CameraMenu");
			}
			return NestedButtonReference;
		}

		// Fetch the Quick Menu instance
		public static QuickMenu GetQuickMenuInstance()
		{
			if (quickmenuInstance == null)
			{
				quickmenuInstance = QuickMenu.prop_QuickMenu_0;
			}
			return quickmenuInstance;
		}

		// Fetch the VRCUiManager instance
		public static VRCUiManager GetVRCUiMInstance()
		{
			if (vrcuimInstance == null)
			{
				vrcuimInstance = VRCUiManager.prop_VRCUiManager_0;
			}
			return vrcuimInstance;
		}

		// Cache the FieldInfo for getting the current page. Hope to god this works!
		private static FieldInfo currentPageGetter;

		private static GameObject shortcutMenu;
		private static GameObject userInteractMenu;

		// Show a Quick Menu page via the Page Name. Hope to god this works!
		public static void ShowQuickmenuPage(string pagename)
		{
			QuickMenu quickmenu = GetQuickMenuInstance();
			Transform pageTransform = quickmenu?.transform.Find(pagename);
			if (pageTransform == null)
			{
				Console.WriteLine("[QMStuff] pageTransform is null !");
			}

			if (currentPageGetter == null)
			{
				GameObject shortcutMenu = quickmenu.transform.Find("ShortcutMenu").gameObject;
				if (!shortcutMenu.activeInHierarchy)
					shortcutMenu = quickmenu.transform.Find("UserInteractMenu").gameObject;

				FieldInfo[] fis = Il2CppType.Of<QuickMenu>().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where((fi) => fi.FieldType == Il2CppType.Of<GameObject>()).ToArray();
				//MelonLoader.MelonModLogger.Log("[QMStuff] GameObject Fields in QuickMenu:");
				int count = 0;
				foreach (FieldInfo fi in fis)
				{
					GameObject value = fi.GetValue(quickmenu)?.TryCast<GameObject>();
					if (value == shortcutMenu && ++count == 2)
					{
						//MelonLoader.MelonModLogger.Log("[QMStuff] currentPage field: " + fi.Name);
						currentPageGetter = fi;
						break;
					}
				}
				if (currentPageGetter == null)
				{
					Console.WriteLine("[QMStuff] Unable to find field currentPage in QuickMenu");
					return;
				}
			}

			currentPageGetter.GetValue(quickmenu)?.Cast<GameObject>().SetActive(false);

			GameObject infoBar = GetQuickMenuInstance().transform.Find("QuickMenu_NewElements/_InfoBar").gameObject;
			infoBar.SetActive(pagename == "ShortcutMenu");

			QuickMenuContextualDisplay quickmenuContextualDisplay = GetQuickMenuInstance().field_Private_QuickMenuContextualDisplay_0;
			quickmenuContextualDisplay.Method_Public_Void_EnumNPublicSealedvaUnNoToUs7vUsNoUnique_0(QuickMenuContextualDisplay.EnumNPublicSealedvaUnNoToUs7vUsNoUnique.NoSelection);
			//quickmenuContextualDisplay.Method_Public_Nested0_0(QuickMenuContextualDisplay.Nested0.NoSelection);

			pageTransform.gameObject.SetActive(true);

			currentPageGetter.SetValue(quickmenu, pageTransform.gameObject);

			if (shortcutMenu == null)
				shortcutMenu = QuickMenu.prop_QuickMenu_0.transform.Find("ShortcutMenu")?.gameObject;

			if (userInteractMenu == null)
				userInteractMenu = QuickMenu.prop_QuickMenu_0.transform.Find("UserInteractMenu")?.gameObject;

			if (pagename == "ShortcutMenu")
			{
				SetIndex(0);
			}
			else if (pagename == "UserInteractMenu")
			{
				SetIndex(3);
			}
			else
			{
				SetIndex(-1);
				shortcutMenu?.SetActive(false);
				userInteractMenu?.SetActive(false);
			}
		}

		// Set the current Quick Menu index
		public static void SetIndex(int index)
		{
			GetQuickMenuInstance().field_Private_Int32_0 = index;
		}
	}
}