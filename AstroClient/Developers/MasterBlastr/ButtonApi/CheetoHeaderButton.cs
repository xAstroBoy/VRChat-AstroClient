namespace CheetoClient;

using System;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class CheetoHeaderButton : CheetoElement
{
	private readonly ImageAdvanced _image;
	private readonly Button _button;

	public CheetoHeaderButton(Transform parent, string tooltip, Sprite sprite = null) : base(QMTemplates.ExpandButton.gameObject, parent)
	{
		Self.gameObject.name = $"CHB-{ID}";
		Self.gameObject.SetActive(true);
		//Utils.QM.Fixer.EnableButtonComponents(Self);

		_image = Self.FindUIObject("Icon").GetComponent<ImageAdvanced>();
		_image.MakeImageMoreSolid();

		_button = Self.GetComponent<Button>();
		ToolTip.SetToolTip(tooltip);

		if (sprite != null)
		{
			SetIcon(sprite);
		}
	}

	public void SetColor(Color color)
	{
		_image.color = color;
	}

	public void SetIcon(Sprite sprite)
	{
		_image.overrideSprite = sprite;
	}

	public void SetAction(Action action)
	{
		_button.onClick.RemoveAllListeners();
		_button.onClick.AddListener(action);
	}
}
