namespace CheetoClient;

#region Imports
using System;
using UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class CheetoWingButton : CheetoElement
{
	private readonly Button _button;
	private readonly Image _icon;
	private readonly Transform _container;
	private readonly TextMeshProUGUI _text;

	public CheetoWingButton(ElementOptions options, ElementStyle style = null) : base(Utils.QM.Templates.WingButton.gameObject, Utils.QM.Templates.WingButton.gameObject.transform.parent)
	{
		Self.name = $"CWB-{ID}";
		_button = Self.GetComponent<Button>();
		_container = Self.transform.Find("Container");
		_icon = _container.Find("Icon").GetComponent<Image>();
		_icon.MakeImageMoreSolid();
		if (options.PrimaryAction != null)
		{
			SetAction(options.PrimaryAction);
		}
		if (style != null && style.Icon != null)
		{
			//SetIcon(style.Icon);
		}
		_text = _container.Find("Text_QM_H3").GetComponent<TextMeshProUGUI>();
		_text.MakeTextMoreSolid();
		SetText(options.Title);
	}

	public void SetText(string text)
	{
		_text.text = text;
	}

	public void SetIcon(Sprite sprite)
	{
		_icon.overrideSprite = sprite;
	}

	public void SetAction(Action action)
	{
		_button.onClick.RemoveAllListeners();
		_button.onClick.AddListener(action);
	}
}
