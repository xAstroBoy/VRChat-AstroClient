namespace CheetoClient;

using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class CheetoHeaderButton : CheetoElement
{
	private readonly Image _image;
	private readonly Button _button;

	public CheetoHeaderButton(Transform parent, string tooltip, Sprite sprite = null) : base(Utils.QM.Templates.ExpandButton.gameObject, parent)
	{
		Self.gameObject.name = $"CHB-{ID}";
		Utils.QM.Fixer.EnableButtonComponents(Self);

		_image = Self.FindUIObject("Icon").GetComponent<Image>();
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
