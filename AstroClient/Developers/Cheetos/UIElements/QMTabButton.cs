namespace CheetoClient;

#region Imports
using System;
using UI;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VRC.UI.Elements;
#endregion

public class QMTabButton
{
	private readonly GameObject _self;

	public QMTabButton(int index, Action action, Sprite loadSprite = null)
	{
		// Evemtually move to a templates class or something
		var tabbase = Finder.Find("UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings");
		_self = UnityEngine.Object.Instantiate(tabbase, tabbase.parent, true).gameObject;
		_self.name = "CheetoTab";
		SetToolTip("CheetoClient");
		SetAction(action);
		_self.GetComponentInChildren<RectTransform>().SetSiblingIndex(index);
		_menuTab = _self.GetComponent<VRC.UI.Elements.Controls.MenuTab>();

		if (_menuTab != null)
		{
			_menuTab.field_Public_String_0 = string.Empty; // Separate it from glowing along with the template tab 
		}

		if (loadSprite != null)
		{
			_self.LoadSprite(loadSprite, "Icon");
		}
		else
		{
			_self.LoadSprite(Icons.CheetoSprite, "Icon");
		}

		SetActive(true);
	}

	public void SetActive(bool isActive)
	{
		_self.SetActive(isActive);
	}

	public void SetToolTip(string text)
	{
		_toolTip.SetToolTip(text);
	}

	public void SetAction(Action buttonAction)
	{
		_self.GetComponent<Button>().onClick.RemoveAllListeners();
		if (buttonAction != null) _self.GetComponent<Button>().onClick.AddListener(buttonAction);
	}

	public void SetGlowEffect(UIPage page)
	{
		if (_menuTab != null)
		{
			_menuTab.field_Public_String_0 = page.name;
		}
	}

	public void SetGlowEffect(string pagename)
	{
		if (_menuTab != null)
		{
			_menuTab.field_Public_String_0 = pagename;
		}
	}

	private readonly VRC.UI.Elements.Controls.MenuTab _menuTab;

	private VRC.UI.Elements.Tooltips.UiTooltip _toolTip_k;
	private VRC.UI.Elements.Tooltips.UiTooltip _toolTip
	{
		get
		{
			if (_toolTip_k == null)
			{
				var attempt1 = _self.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
				if (attempt1 == null)
				{
					attempt1 = _self.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true);
				}
				if (attempt1 == null)
				{
					attempt1 = _self.AddComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
				}
				if (attempt1 != null)
				{
					return _toolTip_k = attempt1;
				}
			}

			return _toolTip_k;
		}
	}
}