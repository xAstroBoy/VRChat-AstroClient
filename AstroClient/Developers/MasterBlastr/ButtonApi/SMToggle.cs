namespace ApolloClient.API.SM;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class SMToggle
{
	protected GameObject ToggleObj;
	protected Toggle ToggleComp;
	protected TextMeshProUGUI Label;

	internal SMToggle(SMPanel panel, string label, System.Action<bool> action, string tooltip, bool defaultState = false)
	{
		Initialize(panel, label, action, tooltip, defaultState);
	}

	private void Initialize(SMPanel panel, string label, System.Action<bool> action, string tooltip, bool defaultState)
	{
		ToggleObj = Object.Instantiate(APIUtils.GetSMToggleTemplate(), panel.GetContainer());
		ToggleObj.name = $"{APIUtils.Identifier}-SMToggle-{APIUtils.RandomNumbers()}";
		ToggleComp = ToggleObj.GetComponent<Toggle>();
		ToggleComp.onValueChanged = new Toggle.ToggleEvent();
		ToggleComp.onValueChanged.AddListener(action);
		ToggleComp.Set(defaultState, false);
		Label = ToggleObj.transform.Find("LeftItemContainer/Text_MM_H3").GetComponent<TextMeshProUGUI>();
		SetLabel(label);
		SetToolTip(tooltip);
	}

	public void SetLabel(string newLabel)
	{
		Label.text = newLabel;
	}

	public void SetToolTip(string newTooltip)
	{
		ToggleObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = newTooltip;
		ToggleObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = newTooltip;
	}

	public void SetToggleState(bool newState, bool shouldInvoke)
	{
		ToggleComp.Set(newState, shouldInvoke);
	}
}
