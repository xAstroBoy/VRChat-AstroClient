namespace CheetoClient;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheetoLabel : CheetoElement
{
	private readonly TextMeshProUGUI _text;

	public CheetoLabel(Transform parent, string text, int size = 40, Color? color = null, bool center = false) : base(QMTemplates.VolumeLabel.gameObject, parent)
	{
		try
		{
			Self.name = $"CL-{ID}";
			_text = Self.FindUIObject("Text_Title").GetComponent<TextMeshProUGUI>();
			_text.text = text;
			_text.fontSize = size;
			_text.alignment = center ? TextAlignmentOptions.Center : TextAlignmentOptions.MidlineLeft;
			_text.MakeTextMoreSolid();
			//var rect = _self.GetComponent<RectTransform>();
			//rect.anchoredPosition = new Vector2(0f, -48f);
			var layout = Self.GetComponent<LayoutElement>();
			layout.preferredHeight = 64f;
			layout.minHeight = 64f;

			var container = Self.FindUIObject("LeftItemContainer");
			var ric = Self.FindUIObject("RightItemContainer");
			ric.SetActive(false);
			var group = container.GetComponent<HorizontalLayoutGroup>();
			group.padding.left = 64;

			if (color.HasValue)
			{
				SetColor(color.Value);
			}
		}
		catch
		{
			Log.Error("0x034B");
		}
	}

	public void SetText(string text)
	{
		_text.text = text;
	}

	public void SetColor(Color color)
	{
		_text.faceColor = color;
	}
}