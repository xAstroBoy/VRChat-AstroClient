namespace CheetoClient;

#region Imports
using System.Collections.Generic;
#endregion

public class QMUserMenu
{
	private readonly List<string> objects = new()
	{
		"UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Remote/ScrollRect/Viewport/VerticalLayoutGroup",
		"UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup"
	};

	private readonly List<CheetoGrid> _grids = new();

	public QMUserMenu()
	{
		for (int i = 0; i < objects.Count; i++)
		{
			string obj = objects[i];
			var go = Finder.Find(obj).gameObject;
			var foldout = new CheetoFoldout(go.transform, "CheetoClient Actions");
			var grid = new CheetoGrid(go.transform);
			_grids.Add(grid);
			var button = new CheetoButton(grid.Self.transform, new ElementOptions("Force Clone", "Force Clone Selected Users Avatar", ElementOptions.ButtonTypes.REGULAR,
				() => ForceClone()));
			foldout.AddChild(grid);
		}
	}

	public void Add(CheetoElement element, CheetoElement element2)
	{
		element.Self.transform.SetParent(_grids[0].Self.transform);
		element2.Self.transform.SetParent(_grids[1].Self.transform);
	}

	public void ForceClone()
	{
		var selected = Utils.QM.SelectedPlayer;

		if (selected != null)
		{
			Utils.Player.ChangeAvatar(selected.GetApiAvatar());
		}
	}
}
