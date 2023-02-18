namespace ApolloClient.API.SM;

using System;
using CheetoClient;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

internal class SMPanel
{
	protected GameObject PanelObject;
	protected TextMeshProUGUI Title;

	internal SMPanel(SMCategory category, string title)
	{
		Initialize(category, title);
	}

	private void Initialize(SMCategory category, string title)
	{
		try
		{
			PanelObject = Object.Instantiate(APIUtils.GetSMPanelTemplate(), category.GetContainer());
			PanelObject.name = $"{APIUtils.Identifier}-SMPanel-{APIUtils.RandomNumbers()}";

			var itemsContainer = PanelObject.transform.Find("Settings_Panel_1/VerticalLayoutGroup");
			for (int i = 0; i < itemsContainer.childCount; i++)
			{
				Transform child = itemsContainer.GetChild(i);
				if (child == null || child.name == "Background_Info")
					continue;
				Object.Destroy(child.gameObject);
			}

			//Title = PanelObject.transform.Find("Header/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>();
			//SetTitle(title);
			//GetContainer().GetComponent<VerticalLayoutGroup>().padding.top = 16;
		}
		catch (Exception ex)
		{
			Log.Exception(ex, "SMCategory Failed to Initialize");
		}
	}

	public void SetTitle(string newTitle)
	{
		Title.text = newTitle;
	}

	public Transform GetContainer()
	{
		return PanelObject.transform.Find("Settings_Panel_1/VerticalLayoutGroup");
	}
}
