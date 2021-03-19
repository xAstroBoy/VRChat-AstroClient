using AstroClient.ConsoleUtils;
using DayClientML2.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace DayClientML2.Utility.ColorUtility
{
    internal class UIColor
    {
        public static Transform UIRoot { get; private set; }
        public static Transform ActionMenu { get; private set; }

        public static void ChangeActionMenu(Color color)
        {
            UIRoot = QuickMenu.prop_QuickMenu_0.transform.parent;
            ActionMenu = UIRoot?.Find("ActionMenu");
            // action menu main background left
            var tmp2 = ActionMenu.Find("MenuL/ActionMenu/Main/Background")?.GetComponent<PedalGraphic>();
            if (tmp2 != null) tmp2.color = color;

            // action menu main background right
            tmp2 = ActionMenu.Find("MenuR/ActionMenu/Main/Background")?.GetComponent<PedalGraphic>();
            if (tmp2 != null) tmp2.color = color;

            // action menu main background left
            tmp2 = ActionMenu.Find("MenuL/ActionMenu/RadialPuppetMenu/Container/Background")?.GetComponent<PedalGraphic>();
            if (tmp2 != null) tmp2.color = color;

            // action menu main background right
            tmp2 = ActionMenu.Find("MenuR/ActionMenu/RadialPuppetMenu/Container/Background")?.GetComponent<PedalGraphic>();
            if (tmp2 != null) tmp2.color = color;
        }

        public static void HighlightColor(Color highlightcolor)
        {
            if (Resources.FindObjectsOfTypeAll<HighlightsFXStandalone>().Count != 0)
            {
                Resources.FindObjectsOfTypeAll<HighlightsFXStandalone>().FirstOrDefault().highlightColor = highlightcolor;
            }
        }
		//public static void ApplyIfApplicable(Color color)
		//{
		//	Color color2 = new Color(color.r, color.g, color.b, 0.7f);
		//	new Color(color.r / 0.75f, color.g / 0.75f, color.b / 0.75f);
		//	Color color3 = new Color(color.r / 0.75f, color.g / 0.75f, color.b / 0.75f, 0.9f);
		//	Color color4 = new Color(color.r / 2.5f, color.g / 2.5f, color.b / 2.5f);
		//	Color color5 = new Color(color.r / 2.5f, color.g / 2.5f, color.b / 2.5f, 0.9f);
		//	if (normalColorImage == null || normalColorImage.Count == 0)
		//	{
		//		normalColorImage = new List<Image>();
		//		GameObject menuContent = Utils.VRCUiManager.GetMenuContent();
		//		normalColorImage.Add(menuContent.transform.Find("Screens/Settings_Safety/_Description_SafetyLevel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Custom/ON").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_None/ON").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Normal/ON").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Maxiumum/ON").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/InputKeypadPopup/Rectangle/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/InputKeypadPopup/InputField").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/StandardPopupV2/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/StandardPopup/InnerDashRing").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/StandardPopup/RingGlow").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/UpdateStatusPopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/InputPopup/InputField").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/UpdateStatusPopup/Popup/InputFieldStatus").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/AdvancedSettingsPopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/AddToPlaylistPopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/BookmarkFriendPopup/Popup/Panel (2)").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/EditPlaylistPopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/PerformanceSettingsPopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/AlertPopup/Lighter").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/RoomInstancePopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/ReportWorldPopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/ReportUserPopup/Popup/Panel").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Popups/SearchOptionsPopup/Popup/Panel (1)").GetComponent<Image>());
		//		normalColorImage.Add(menuContent.transform.Find("Screens/UserInfo/User Panel/Panel (1)").GetComponent<Image>());
		//		foreach (Transform transform in from x in menuContent.GetComponentsInChildren<Transform>(true)
		//										where x.name.Contains("Panel_Header")
		//										select x)
		//		{
		//			foreach (Image item in transform.GetComponentsInChildren<Image>())
		//			{
		//				normalColorImage.Add(item);
		//			}
		//		}
		//		foreach (Transform transform2 in from x in menuContent.GetComponentsInChildren<Transform>(true)
		//										 where x.name.Contains("Handle")
		//										 select x)
		//		{
		//			foreach (Image item2 in transform2.GetComponentsInChildren<Image>())
		//			{
		//				normalColorImage.Add(item2);
		//			}
		//		}
		//		try
		//		{
		//			normalColorImage.Add(menuContent.transform.Find("Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Panel_Backdrop").GetComponent<Image>());
		//			normalColorImage.Add(menuContent.transform.Find("Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Left").GetComponent<Image>());
		//			normalColorImage.Add(menuContent.transform.Find("Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Right").GetComponent<Image>());
		//		}
		//		catch (Exception)
		//		{
		//			new Exception();
		//		}
		//	}
		//	if (dimmerColorImage == null || dimmerColorImage.Count == 0)
		//	{
		//		dimmerColorImage = new List<Image>();
		//		GameObject menuContent2 = Utils.VRCUiManager.GetMenuContent();
		//		dimmerColorImage.Add(menuContent2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Custom/ON/TopPanel_SafetyLevel").GetComponent<Image>());
		//		dimmerColorImage.Add(menuContent2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_None/ON/TopPanel_SafetyLevel").GetComponent<Image>());
		//		dimmerColorImage.Add(menuContent2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Normal/ON/TopPanel_SafetyLevel").GetComponent<Image>());
		//		dimmerColorImage.Add(menuContent2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Maxiumum/ON/TopPanel_SafetyLevel").GetComponent<Image>());
		//		foreach (Transform transform3 in from x in menuContent2.GetComponentsInChildren<Transform>(true)
		//										 where x.name.Contains("Fill")
		//										 select x)
		//		{
		//			foreach (Image item3 in transform3.GetComponentsInChildren<Image>())
		//			{
		//				dimmerColorImage.Add(item3);
		//			}
		//		}
		//	}
		//	if (darkerColorImage == null || darkerColorImage.Count == 0)
		//	{
		//		darkerColorImage = new List<Image>();
		//		GameObject menuContent3 = Utils.VRCUiManager.GetMenuContent();
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/InputKeypadPopup/Rectangle").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/StandardPopupV2/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/StandardPopup/Rectangle").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/StandardPopup/MidRing").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/UpdateStatusPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/AdvancedSettingsPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/AddToPlaylistPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/BookmarkFriendPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/EditPlaylistPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/PerformanceSettingsPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/RoomInstancePopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/RoomInstancePopup/Popup/BorderImage (1)").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/ReportWorldPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/ReportUserPopup/Popup/BorderImage").GetComponent<Image>());
		//		darkerColorImage.Add(menuContent3.transform.Find("Popups/SearchOptionsPopup/Popup/BorderImage").GetComponent<Image>());
		//		foreach (Transform transform4 in from x in menuContent3.GetComponentsInChildren<Transform>(true)
		//										 where x.name.Contains("Background")
		//										 select x)
		//		{
		//			foreach (Image item4 in transform4.GetComponentsInChildren<Image>())
		//			{
		//				darkerColorImage.Add(item4);
		//			}
		//		}
		//	}
		//	if (normalColorText == null || normalColorText.Count == 0)
		//	{
		//		normalColorText = new List<Text>();
		//		GameObject menuContent4 = Utils.VRCUiManager.GetMenuContent();
		//		foreach (Text item5 in menuContent4.transform.Find("Popups/InputPopup/Keyboard/Keys").GetComponentsInChildren<Text>(true))
		//		{
		//			normalColorText.Add(item5);
		//		}
		//		foreach (Text item6 in menuContent4.transform.Find("Popups/InputKeypadPopup/Keyboard/Keys").GetComponentsInChildren<Text>(true))
		//		{
		//			normalColorText.Add(item6);
		//		}
		//	}
		//	foreach (Image image in normalColorImage)
		//	{
		//		image.color = color2;
		//	}
		//	foreach (Image image2 in dimmerColorImage)
		//	{
		//		image2.color = color3;
		//	}
		//	foreach (Image image3 in darkerColorImage)
		//	{
		//		image3.color = color5;
		//	}
		//	foreach (Text text in normalColorText)
		//	{
		//		text.color = color;
		//	}
		//	//if (setupSkybox && loadingBackground != null)
		//	//{
		//	//	loadingBackground.GetComponent<MeshRenderer>().material.SetColor("_Tint", new Color(color.r / 2.5f, color.g / 2.5f, color.b / 2.5f, color.a));
		//	//}
		//	ColorBlock colors = new ColorBlock
		//	{
		//		colorMultiplier = 1f,
		//		disabledColor = Color.grey,
		//		highlightedColor = color * 1.5f,
		//		normalColor = color / 1.5f,
		//		pressedColor = Color.grey * 1.5f,
		//		fadeDuration = 0.1f
		//	};
		//	color.a = 0.9f;
		//	if (Resources.FindObjectsOfTypeAll<HighlightsFXStandalone>().Count != 0)
		//	{
		//		Resources.FindObjectsOfTypeAll<HighlightsFXStandalone>().FirstOrDefault<HighlightsFXStandalone>().highlightColor = color;
		//	}
		//	try
		//	{
		//		if (ButtonsConfig.Instance.Colors.EnableMenuColor)
		//		{
		//			using (IEnumerator<Image> enumerator2 = UnityEngine.Object.FindObjectOfType<HudVoiceIndicator>().transform.GetComponentsInChildren<Image>().GetEnumerator())
		//			{
		//				while (enumerator2.MoveNext())
		//				{
		//					Image image4 = enumerator2.Current;
		//					if (image4.gameObject.name != "PushToTalkKeybd" && image4.gameObject.name != "PushToTalkXbox")
		//					{
		//						image4.color = color;
		//					}
		//				}
		//				goto IL_E99;
		//			}
		//		}
		//		foreach (Image image5 in UnityEngine.Object.FindObjectOfType<HudVoiceIndicator>().transform.GetComponentsInChildren<Image>())
		//		{
		//			if (image5.gameObject.name != "PushToTalkKeybd" && image5.gameObject.name != "PushToTalkXbox")
		//			{
		//				image5.color = Color.red;
		//			}
		//		}
		//	IL_E99:
		//		foreach (HudVoiceIndicator hudVoiceIndicator in UnityEngine.Object.FindObjectsOfType<HudVoiceIndicator>())
		//		{
		//			hudVoiceIndicator.transform.Find("VoiceDotDisabled").GetComponent<FadeCycleEffect>().enabled = false;
		//		}
		//	}
		//	catch (Exception)
		//	{
		//		new Exception();
		//	}
		//	if (Utils.VRCUiManager.GetMenuContent() != null)
		//	{
		//		GameObject gameObject = Utils.VRCUiManager.GetMenuContent();
		//		try
		//		{
		//			Transform transform5 = gameObject.transform.Find("Popups/InputPopup");
		//			color4.a = 0.8f;
		//			transform5.Find("Rectangle").GetComponent<Image>().color = color4;
		//			color4.a = 0.5f;
		//			color.a = 0.8f;
		//			transform5.Find("Rectangle/Panel").GetComponent<Image>().color = color;
		//			color.a = 0.5f;
		//			Transform transform6 = gameObject.transform.Find("Backdrop/Header/Tabs/ViewPort/Content/Search");
		//			transform6.Find("SearchTitle").GetComponent<Text>().color = color;
		//			transform6.Find("InputField").GetComponent<Image>().color = color;
		//		}
		//		catch (Exception ex2)
		//		{
		//			ModConsole.Error(ex2.ToString());
		//		}
		//		try
		//		{
		//			ColorBlock colors2 = new ColorBlock
		//			{
		//				colorMultiplier = ButtonsConfig.Instance.Colors.ColorMultiply,
		//				disabledColor = Color.grey,
		//				highlightedColor = color4,
		//				normalColor = color,
		//				pressedColor = Color.gray,
		//				fadeDuration = 0.1f
		//			};
		//			gameObject.GetComponentsInChildren<Transform>(true).FirstOrDefault((Transform x) => x.name == "Row:4 Column:0").GetComponent<Button>().colors = colors;
		//			color.a = 0.5f;
		//			color4.a = 1f;
		//			colors2.normalColor = color4;
		//			foreach (Slider slider in gameObject.GetComponentsInChildren<Slider>(true))
		//			{
		//				slider.colors = colors2;
		//			}
		//			color4.a = 0.5f;
		//			colors2.normalColor = color;
		//			foreach (Button button in gameObject.GetComponentsInChildren<Button>(true))
		//			{
		//				button.colors = colors;
		//			}
		//			gameObject = GameObject.Find("QuickMenu");
		//			foreach (Button button2 in gameObject.GetComponentsInChildren<Button>(true))
		//			{
		//				if (button2.transform.parent.name != "SocialNotifications" 
		//					//&& button2.gameObject.name != Modules.UI.QuickMenu.MainMenu.getMainButton().getGameObject().name
		//					&& button2.transform.parent.parent.name != "EmojiMenu")
		//				{
		//					button2.colors = colors;
		//				}
		//			}
		//			foreach (UiToggleButton uiToggleButton in gameObject.GetComponentsInChildren<UiToggleButton>(true))
		//			{
		//				foreach (Image image6 in uiToggleButton.GetComponentsInChildren<Image>(true))
		//				{
		//					image6.color = color;
		//				}
		//			}
		//			foreach (Slider slider2 in gameObject.GetComponentsInChildren<Slider>(true))
		//			{
		//				slider2.colors = colors2;
		//				foreach (Image image7 in slider2.GetComponentsInChildren<Image>(true))
		//				{
		//					image7.color = color;
		//				}
		//			}
		//			foreach (Toggle toggle in gameObject.GetComponentsInChildren<Toggle>(true))
		//			{
		//				toggle.colors = colors2;
		//				foreach (Image image8 in toggle.GetComponentsInChildren<Image>(true))
		//				{
		//					image8.color = color;
		//				}
		//			}
		//		}
		//		catch (Exception)
		//		{
		//			new Exception();
		//		}
		//		foreach (Text text2 in Utils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT").GetComponentsInChildren<Text>(true))
		//		{
		//			if (text2.transform.name == "Text" && text2.transform.parent.name != "AvatarImage")
		//			{
		//				text2.color = new Color(color.r * 1.25f, color.g * 1.25f, color.b * 1.25f);
		//			}
		//		}
		//	}
		//}

		private static List<Image> normalColorImage = new List<Image>();

		private static List<Image> dimmerColorImage = new List<Image>();

		private static List<Image> darkerColorImage = new List<Image>();

		private static List<Text> normalColorText = new List<Text>();

		public static GameObject sexysex = Utils.QuickMenu.transform.Find("/UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient/SkyCube_Baked").gameObject;
    }
}