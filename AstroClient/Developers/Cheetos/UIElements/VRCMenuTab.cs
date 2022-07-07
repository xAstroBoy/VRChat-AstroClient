namespace CheetoClient;

using System;
using UnityEngine;
using UnityEngine.UI;

public class VRCMenuTab
{
	private readonly GameObject _self;
	private readonly Text _text;
	private readonly GameObject _menu;
	private readonly VRCUiPageTab _tab;

	public VRCMenuTab(int index, string title, Action action)
	{
		var tabbase = Finder.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab");
		_self = UnityEngine.Object.Instantiate(tabbase.gameObject, tabbase.parent, true);
		_self.transform.SetSiblingIndex(index);
		_text = _self.transform.Find("Button").Find("Text").GetComponent<Text>();
		_tab = _self.GetComponent<VRCUiPageTab>();

		SetText(title);

		_menu = new VRCMenu().Self;

		if (_tab == null)
		{
			Log.Warn("VRCUiPageTab is null");
		}
		else
		{
			_tab.field_Public_String_1 = $"UserInterface/MenuContent/Screens/TestMenu"; // Eventually fetch this, errored on me
		}
		//_tab.field_Public_String_0 = "CHEETO";

		SetAction(action);

	}

	public void ShowMe()
	{
		Log.Debug($"Showing menu: {_menu.name}");
		Utils.Instances.VRCUiManager.ShowScreenButton(_menu.name);
	}

	public void SetText(string text)
	{
		_self.name = $"VRCMenuTab_{text}";
		_text.text = text;
	}

	public void SetAction(Action action)
	{
		_self.transform.Find("Button").GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
		_self.transform.Find("Button").GetComponent<Button>().onClick.AddListener(action);
	}
}