namespace CheetoClient;

using System;
using UnityEngine;
using UnityEngine.UI;

public class VRCButton
{

	private readonly GameObject _self;
	private readonly Text _text;

	public VRCButton(Transform parent, string title, Action action)
	{
		_self = UnityEngine.Object.Instantiate(Finder.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab")).gameObject;
		_self.transform.SetParent(parent);
		_text = _self.transform.Find("Button").Find("Text").GetComponent<Text>();
		var rect = _self.GetComponent<RectTransform>();
		rect.sizeDelta = new Vector2(200, 200);
		rect.localPosition = Vector3.zero;
		rect.localScale = Vector3.one;
		rect.anchoredPosition = new Vector2(0, 0);

		_text.text = title;

		SetAction(action);
	}

	public void SetAction(Action action)
	{
		_self.transform.Find("Button").GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
		_self.transform.Find("Button").GetComponent<Button>().onClick.AddListener(action);
	}

	public void SetState(bool v)
	{
		_text.color = !v ? (UnityEngine.Color) (Color32) Color.Red : (UnityEngine.Color) (Color32) Color.White;
	}
}