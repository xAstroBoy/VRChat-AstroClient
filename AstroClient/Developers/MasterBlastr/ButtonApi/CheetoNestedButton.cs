namespace CheetoClient;

using System;
using global::CheetoClient.QM;
using UIElements;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using Object = UnityEngine.Object;

public class CheetoNestedButton
{
	private readonly string _name;
	private readonly CheetoButton _mainButton;
	private readonly GameObject _back;
	private readonly GameObject _nested;
	private readonly GameObject _menu;
	private readonly UIPage _page;

	private readonly System.Random _random = new();

	public CheetoNestedButton(Transform parent, string parentMenu, string buttonText, string title, string tooltipText, Sprite sprite = null, Color? color = null)
	{
		try
		{
			_name = $"CNB-{_random.Next(9)}{_random.Next(9)}{_random.Next(9)}{_random.Next(9)}-{buttonText}-{title}";
			_nested = Object.Instantiate(QMTemplates.NestedMenu.gameObject, QMTemplates.NestedPages, true);

			_back = _nested.FindUIObject("Button_Back");
			_back.SetActive(true);
			_back.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
			_back.GetComponent<Button>().onClick.AddListener(new Action(() => QMUtils.ShowPage(parentMenu)));

			_menu = _nested.FindUIObject("VerticalLayoutGroup");
			_nested.ToggleScrollRectOnExistingMenu(true);

			var viewport = _menu.transform.parent.gameObject;
			viewport.GetComponent<RectMask2D>().enabled = true;

			Object.Destroy(_menu.GetComponentInChildren<GridLayoutGroup>());
			Object.Destroy(_nested.GetComponentInChildren<CameraMenu>());
			Object.Destroy(_nested.FindUIObject("Buttons"));
			Object.Destroy(_nested.FindUIObject("Panel_Info"));
			Object.Destroy(_nested.FindUIObject("Button_PhotosFolder"));
			Object.Destroy(_nested.FindUIObject("Button_QM_Expand"));

			//var ric = _nested.FindUIObject("RightItemContainer");
			//var hb1 = new CheetoHeaderButton(ric.transform);
			//hb1.SetIcon(Icons.SettingsSprite);
			//var hb2 = new CheetoHeaderButton(ric.transform);
			//hb2.SetIcon(Icons.CheetoSprite);

			//_panel = new QMPanelInfo(_nested.transform, "WIP");
			_menu.transform.DestroyChildren();

			_page = _nested.GenerateQuickMenuPage(_name);
			_nested.name = _name;
			var textTitle = _nested.NewText("Text_Title");
			textTitle.text = title;
			textTitle.transform.localPosition = new Vector3(0, 0, 0);

			_nested.SetActive(false);
			_nested.CleanButtonsNestedMenu();

			_mainButton = new CheetoButton(parent, new ElementOptions(buttonText, tooltipText, ElementOptions.ButtonTypes.NESTED, () => QMUtils.ShowPage(_name)), new ElementStyle(sprite, color));
			_mainButton.SetToolTip(tooltipText);
		}
		catch
		{
			Log.Error("0x015B");
		}
	}

	public void SetText(string value)
	{
		_mainButton.SetText(value);
	}

	public void SetColor(Color color)
	{
		_mainButton.SetColor(color);
	}

	public string GetName()
	{
		return _name;
	}

	public GameObject GetArea()
	{
		return _menu;
	}

	public void SetPanelText(string text)
	{
		//_panel.SetText(text);
	}

	public GameObject GameObject => _mainButton.Self;
}
