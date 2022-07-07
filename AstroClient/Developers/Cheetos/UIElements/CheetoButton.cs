using AstroClient;
using AstroClient.Developers.Cheetos.UIElements;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using VRC.UI.Core;

namespace CheetoClient;

#region Imports
using System;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Tooltips;
#endregion

/// <summary>
/// A standard button, also used as a base class for other elements
/// </summary>
public class CheetoButton : CheetoElement
{
	private readonly TextMeshProUGUI _text;
	private readonly Image _icon;
	private readonly RectTransform _rect;
	private readonly UiTooltip _tooltip;
	private readonly ElementOptions _options;
	private bool _state;

	public CheetoButton(CheetoElement parent, ElementOptions options, ElementStyle style = null) : this(parent.Self.transform, options, style)
	{
	}

	public CheetoButton(Transform parent, ElementOptions options, ElementStyle style = null) : base(Utils.QM.Templates.SingleButton.gameObject, parent)
	{
		try
		{
			Self.name = $"CB-{ID}";
			_options = options;
			Utils.QM.Fixer.EnableButtonComponents(Self);
			_text = Self.GetComponentInChildren<TextMeshProUGUI>(true);
			_icon = Self.transform.Find("Icon").GetComponent<Image>();
			_rect = Self.GetComponent<RectTransform>();
			_tooltip = Self.GetComponent<UiTooltip>();
			if (_tooltip == null)
			{
				_tooltip = Self.AddComponent<UiTooltip>();
			}
			_text.MakeTextMoreSolid();

			#region Styles
			if (style == null)
			{
				style = StyleManager.DefaultButtonStyle;
			}

			if (style.Icon != null)
			{
				SetIcon(style.Icon);
			}
			else
			{
				_icon.gameObject.SetActive(false);
				_text.rectTransform.anchoredPosition += new Vector2(0, 50);
				_text.fontSize = 30f;
			}

			if (options.Type == ElementOptions.ButtonTypes.NESTED)
			{
				var badge = Self.FindUIObject("Badge_MMJump");
				badge.SetActive(true);
				var image = badge.GetComponent<Image>();
				image.MakeImageMoreSolid();
				image.color = (Color32) Cheetah.Color.CheetoOrange;
			}

			_text.faceColor = style.Color != null ? (Color32) style.Color.Value : (Color32) StyleManager.DefaultButtonStyle.Color.Value;
			#endregion

			if (options.Type == ElementOptions.ButtonTypes.TOGGLE)
			{
				SetAction(() =>
				{
					Toggle();
				});
			}
			else
			{
				if (options.PrimaryAction != null)
				{
					SetAction(options.PrimaryAction);
				}
			}

			SetButtonText(options.Title);
			SetToolTip(options.ToolTip);
		}
		catch
		{
			Log.Error("0x016B");
		}
	}

	public void SetState(bool state, bool invoke = false)
	{
		_state = state;
		if (_state)
		{
			if (invoke) _options.PrimaryAction?.Invoke();
			SetTextColor(Cheetah.Color.Crayola.Original.Green);
			SetButtonText($"{_options.Title}");
		}
		else
		{
			if (invoke) _options.SecondaryAction?.Invoke();
			SetTextColor(Cheetah.Color.Crayola.Original.DarkVenetianRed);
			SetButtonText($"{_options.Title}");
		}
	}

	public void SetColor(Color color)
	{
		_text.faceColor = color;
	}

	public void SetText(string value)
	{
		_text.text = value;
	}

	public bool Toggle()
	{
		_state = !_state;
		SetState(_state, true);
		return _state;
	}

	public void SetButtonText(string text)
	{
		if (Self == null || _text == null) return;
		_text.text = text;
	}

	public void SetToolTip(string text)
	{
		_tooltip.field_Public_String_0 = text;
		_tooltip.field_Public_String_1 = text;
	}

	public void SetIcon(Sprite sprite)
	{
		if (_icon == null) return;
		_icon.overrideSprite = sprite;
		_icon.MakeImageMoreSolid();
	}

	public void SetTextColor(Color color)
	{
		_text.faceColor = color;
	}

	public void SetAction(Action action)
	{
		Self.GetComponent<Button>().onClick.RemoveAllListeners();
		Self.GetComponent<Button>().onClick.AddListener(action);
	}
}