namespace CheetoClient;

using System;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class CheetoSMHeaderButton : CheetoElement
{
	private readonly ImageAdvanced _image;
	private readonly Button _button;

	public CheetoSMHeaderButton(Transform parent, string tooltip, Sprite sprite = null) : base(QMTemplates.SMHeaderButton.gameObject, parent)
	{
		Self.name = $"CSMHB-{ID}";
		Self.SetActive(true);
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
