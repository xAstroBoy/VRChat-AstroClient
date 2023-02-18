namespace CheetoClient;

using ApolloClient.API;
using ApolloClient.API.SM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class SMTest
{
	protected GameObject ToggleObj;
	protected Toggle ToggleComp;
	protected TextMeshProUGUI Label;

	internal SMTest(SMPanel panel) : this(panel.GetContainer())
	{
	}

	internal SMTest(Transform parent)
	{
		ToggleObj = Object.Instantiate(SMTemplates.Test.gameObject, parent);
		ToggleObj.name = $"{APIUtils.Identifier}-SMTest-{APIUtils.RandomNumbers()}";
	}
}
