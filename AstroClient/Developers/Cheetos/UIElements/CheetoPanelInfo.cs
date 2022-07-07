namespace CheetoClient;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;

public class CheetoPanelInfo : CheetoElement
{
	private readonly TextMeshProUGUI _text;

	public CheetoPanelInfo(Transform parent, string title) : base(Utils.QM.Templates.PanelInfo.gameObject, parent)
	{
		Self.name = $"CHI-{ID}";

		var titleObject = Self.FindUIObject("Text_H4");
		_text = titleObject.GetComponent<TextMeshProUGUI>();
		_text.enabled = true;
		_text.text = title;
		_text.richText = true;
		_text.color = new UnityEngine.Color(0.6f, 0.6f, 0f, 1f);
		titleObject.GetComponentInChildren<StyleElement>().enabled = true;

		Self.FindUIObject("Icon_Info").GetComponentInChildren<RawImage>().enabled = true;
		Self.GetComponent<Image>().enabled = true;
		Self.GetComponent<StyleElement>().enabled = true;
	}

	public void SetText(string text)
	{
		_text.text = text;
	}
}