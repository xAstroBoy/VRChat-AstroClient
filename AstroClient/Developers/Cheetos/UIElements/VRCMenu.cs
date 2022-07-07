namespace CheetoClient;

using System;
using UnityEngine;

public class VRCMenu
{
	public readonly GameObject Self;
	private readonly VRCUiPage _page;

	public VRCMenu()
	{
		var menubase = Finder.Find("UserInterface/MenuContent/Screens/Settings");
		Self = UnityEngine.Object.Instantiate(menubase.gameObject, menubase.parent, true);

		_page = Self.GetComponent<VRCUiPageSettings>();
		_page.enabled = true;

		_page.field_Public_Action_0 = new Action(() =>
		{
			Self.active = true;
			Self.SetActive(true);
			Self.GetComponent<VRCUiPageSettings>().enabled = true;
			Self.GetComponent<VRCUiPageSettings>().field_Protected_Boolean_0 = true;
			_page.enabled = true;
			_page.field_Protected_Boolean_0 = true;
		});

		System.Collections.Generic.List<Transform> list = Self.transform.GetChildren();
		for (int i = 0; i < list.Count; i++)
		{
			Transform child = list[i];
			if (!child.name.ToLower().Contains("title"))
			{
				UnityEngine.Object.Destroy(child.gameObject);
			}
		}
		Self.name = "TestMenu";
	}
}
