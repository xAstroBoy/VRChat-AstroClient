using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;

namespace CheetoClient.UIElements;

using TMPro;
using UI;
using UnityEngine;
using VRC.UI.Elements;
using Color = Cheetah.Color;

public class CheetahNetIndicator // TODO: Inherit from CheetoElement
{
	private readonly GameObject _self;
	private readonly GameObject _panel;
	private readonly TextMeshProUGUI _text;

	public CheetahNetIndicator()
	{
		var window = Finder.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window").gameObject;
		var go = Finder.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMNotificationsArea/DebugInfoPanel").gameObject;
		_self = Object.Instantiate(go);
		_panel = _self.transform.Find("Panel").gameObject;
		var rect = _panel.GetComponent<RectTransform>();
		rect.localPosition = new Vector3(-500, 0, 0);
		_text = _self.FindUIObject("Text_FPS").GetComponent<TextMeshProUGUI>();
		var textRect = _self.FindUIObject("Text_FPS").GetComponent<RectTransform>();
		textRect.sizeDelta = new Vector2(500f, 0f);
		textRect.transform.localPosition = new Vector3(-50f, 0f, 0f);
		Object.Destroy(_self.FindUIObject("Text_Ping"));
		_text.text = "CheetahNet: N/A";
		_text.MakeTextMoreSolid();
		_text.autoSizeTextContainer = true;
		SetColor(Color.CheetoOrange);

		_self.name = "CheetahNetIndicator";
		Object.Destroy(_self.GetComponent<DebugInfoPanel>());
		_self.transform.parent = window.transform;
		_self.transform.position = go.transform.position;
		_self.transform.localPosition = new Vector3(600f, 563f, 0f);
		_self.SetActive(true);
	}

	internal void SetActive(bool active)
	{
		_self.SetActive(active);
	}

	public void SetText(string text)
	{
		_text.text = text;
	}

	public void SetColor(Color color)
	{
		_text.color = Color.White; // Removes blue tint
		_text.faceColor = color;
	}
}