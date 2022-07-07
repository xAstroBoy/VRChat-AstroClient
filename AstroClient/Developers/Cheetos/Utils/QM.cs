 using AstroClient.xAstroBoy;
 using AstroClient.xAstroBoy.AstroButtonAPI.Tools;

 namespace CheetoClient.Utils;

using UnityEngine;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;

/// <summary>
/// Various utilities for the Quick Menu.
/// </summary>
public static partial class QM
{

	#region Private Variables

	private static QuickMenu _instance;
	private static SelectedUserMenuQM _selectedUserMenuQM;
	private static MenuStateController _controller;
	private static Transform _transform;
	private static Transform _interface;

	#endregion

	public static QuickMenu Instance
	{
		get
		{
			return _instance ??= (Finder.Find("UserInterface/Canvas_QuickMenu(Clone)")?.GetComponent<QuickMenu>());
		}
	}

	public static MenuStateController Controller
	{
		get
		{
			if (_controller == null)
			{
				var Buttons = Instance.GetComponentsInChildren<MenuStateController>(true);
				for (int i = 0; i < Buttons.Count; i++)
				{
					MenuStateController button = Buttons[i];
					if (button.name == "Canvas_QuickMenu(Clone)")
					{
						_controller = button;
						break;
					}
				}
			}

			return _controller;
		}
	}

	public static Transform Transform
	{
		get
		{
			return Interface != null ? (_transform ??= Interface.Find("Canvas_QuickMenu(Clone)")) : null;
		}
	}

	public static Transform Interface
	{
		get
		{
			return _interface ??= GameObject.Find("UserInterface").transform;
		}
	}

	internal static SelectedUserMenuQM SelectedUserMenuQM
	{
		get
		{
			if (_selectedUserMenuQM == null) _selectedUserMenuQM = Transform.gameObject.FindUIObject("Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>();
			return _selectedUserMenuQM;
		}
	}

	// Maybe move this later
	public static VRC.Player SelectedPlayer => SelectedUserMenuQM.GetSelectedPlayer();

	public static void ShowPage(string pagename)
	{
		Controller.ShowTabContent(pagename);
	}
}