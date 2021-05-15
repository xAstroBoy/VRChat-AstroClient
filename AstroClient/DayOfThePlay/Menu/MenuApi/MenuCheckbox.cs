namespace DayClientML2.Utility
{
	using AstroClient;
	using AstroLibrary.Console;
	using System;
	using UnityEngine;
	using UnityEngine.UI;
	using Object = UnityEngine.GameObject;

	internal class MenuCheckbox
	{
		// public MenuCheckbox();
		// Find("Screens/Settings/ComfortSafetyPanel/PersonalSpaceToggle")

		public void SetActive(bool isActive)
		{
			Checkbox.gameObject.SetActive(isActive);
		}

		public MenuCheckbox(Transform parent, string text, float XPos, float YPos, bool Checked, Action<bool> act, bool Interactable = true)
		{
			try
			{
				//GameObject.Find("UserInterface/MenuContent/Screens/Settings/OtherOptionsPanel/DesktopReticle/Label").AddComponent<ContentSizeFitter>();
				//GameObject.Find("UserInterface/MenuContent/Screens/Settings/OtherOptionsPanel/DesktopReticle/Label").GetComponent<ContentSizeFitter>().horizontalFit = (ContentSizeFitter.FitMode)2;
				//GameObject.Find("UserInterface/MenuContent/Screens/Settings/OtherOptionsPanel/DesktopReticle/Label").GetComponent<RectTransform>().transform.right = new Vector2(0, 50f);
				//GameObject.Find("UserInterface/MenuContent/Screens/Settings/OtherOptionsPanel/DesktopReticle/Label").GetComponent<RectTransform>().offsetMax = new Vector2(25, 21.5f);
				Checkbox = Object.Instantiate(Object.Find("UserInterface/MenuContent/Screens/Settings/OtherOptionsPanel/DesktopReticle"), parent, false);
				Object.DestroyImmediate(Checkbox.GetComponent<UiSettingConfig>());
				Checkbox.name = "Check_" + text + BuildInfo.Name;
				Checkbox.GetComponent<RectTransform>().anchoredPosition = new Vector2(XPos, YPos);
				Text = Checkbox.GetComponentInChildren<Text>();
				//Text.horizontalOverflow = (HorizontalWrapMode)2; //
				Text.text = text;
				Toggle = Checkbox.GetComponent<Toggle>();
				Toggle.Set(Checked);
				Toggle.group = new ToggleGroup();
				Toggle.name = "Check_" + text;
				Toggle.onValueChanged = new Toggle.ToggleEvent();
				Toggle.onValueChanged.AddListener(act);
				SetInteractable(true);
			}
			catch (Exception)
			{
				ModConsole.DebugLog("[<color=#FF0000>Error</color>] <color=#59D365>Error Occurred in Checkbox API</color>");
			}
		}

		public void SetToggleState(bool state, bool ShouldInvoke = false)
		{
			Toggle.Set(state, ShouldInvoke);
			Toggle.isOn = state;
		}

		public void SetPosition(float xPos, float YPos)
		{
			Checkbox.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, YPos);
		}

		public void SetPosition(float xPos, float YPos, float ZPos)
		{
			Checkbox.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(xPos, YPos, ZPos);
		}

		public void SetInteractable(bool State)
		{
			Toggle.interactable = State;
		}

		public Text Text;
		public Toggle Toggle;
		public Object Checkbox;
	}
}