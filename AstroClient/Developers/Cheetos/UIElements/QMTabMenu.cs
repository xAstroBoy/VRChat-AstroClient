namespace CheetoClient;

#region Imports

using UI;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using CameraMenu = MonoBehaviour1PublicBuToBuGaTMBuGaBuGaBuUnique;

#endregion

public class QMTabMenu
{
	private readonly string _name;
	private readonly GameObject _nested;
	private readonly GameObject _menu;
	private readonly QMTabButton _main;
	private readonly UIPage _page;

	public QMTabMenu(int index, string tooltipText, Sprite loadSprite = null)
	{
		try
		{
			_name = $"CheetoTabMenu-{index}_{tooltipText}";

			_nested = Object.Instantiate(Utils.QM.Templates.NestedMenu.gameObject, Utils.QM.Templates.NestedPages, true);
			_menu = _nested.FindUIObject("VerticalLayoutGroup");
			_nested.ToggleScrollRectOnExistingMenu(true);

			var viewport = _menu.transform.parent.gameObject;
			viewport.GetComponent<RectMask2D>().enabled = true;

			Object.Destroy(_nested.GetComponentInChildren<GridLayoutGroup>());
			Object.Destroy(_nested.GetComponentInChildren<CameraMenu>());
			Object.Destroy(_nested.FindUIObject("Panel_Info"));
			Object.Destroy(_nested.FindUIObject("Button_PhotosFolder"));
			Object.Destroy(_nested.FindUIObject("Button_QM_Expand"));

			//var panel = new QMPanelInfo(_nested.transform, "This client is a WIP");

			var ric = _nested.FindUIObject("RightItemContainer");
			if (TempGlobals.Authentication.Info.IsDeveloper)
			{
				UIManager.HeaderDeveloperButton = new CheetoHeaderButton(ric.transform, "Developer", Icons.CopSprite);
			}
			UIManager.HeaderInfoButton = new CheetoHeaderButton(ric.transform, "Info", Icons.InfoSprite);
			UIManager.HeaderSettingsButton = new CheetoHeaderButton(ric.transform, "Settings", Icons.SettingsSprite);

			System.Collections.Generic.List<Transform> list = _menu.transform.GetChildren();
			for (int i = 0; i < list.Count; i++)
			{
				Transform item = list[i];
				Object.Destroy(item.gameObject);
			}
			_page = _nested.GenerateQuickMenuPage(_name);

			_nested.name = _name;
			_nested.NewText("Text_Title").text = tooltipText;
			_nested.SetActive(false);
			_nested.CleanButtonsNestedMenu();

			_main = new QMTabButton(index, () => { ShowMe(); }, loadSprite);
			_main.SetToolTip(tooltipText);
			_main.SetGlowEffect(_page);
		}
		catch
		{
			Log.Error("0x11B");
		}
	}

	public GameObject GetArea()
	{
		return _menu;
	}

	public string GetName()
	{
		return _name;
	}

	public void ShowMe()
	{
		Utils.QM.ShowPage(_name);
	}
}