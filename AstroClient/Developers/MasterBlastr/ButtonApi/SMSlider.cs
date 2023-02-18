namespace ApolloClient.API.SM;

using TMPro;
using UnityEngine;
using VRC.UI.Elements.Utilities;

internal class SMSlider
{
	protected GameObject SliderObj;
	protected TextMeshProUGUI Label;
	protected TextMeshProUGUI PercentageLabel;
	protected SnapSlider Slider;
	protected float Min;
	protected float Max;

	internal SMSlider(SMPanel panel, string label, float min, System.Action<float> action, float max, float current, string tooltip)
	{
		Initialize(panel, label, min, action, max, current, tooltip);
	}

	private void Initialize(SMPanel panel, string label, float min, System.Action<float> action, float max, float current, string tooltip)
	{
		SliderObj = Object.Instantiate(APIUtils.GetSMSliderTemplate(), panel.GetContainer());
		SliderObj.name = $"{APIUtils.Identifier}-SMSlider-{APIUtils.RandomNumbers()}";

		Min = min;
		Max = max;
		Label = SliderObj.transform.Find("LeftItemContainer/Text_MM_H3").GetComponent<TextMeshProUGUI>();
		SetLabel(label);
		PercentageLabel = SliderObj.transform.Find("RightItemContainer/Text_MM_H3").GetComponent<TextMeshProUGUI>();
		SetToolTip(tooltip);

		Slider = SliderObj.transform.Find("RightItemContainer/Slider").GetComponent<SnapSlider>();
		Slider.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
		Slider.wholeNumbers = false;
		Slider.minValue = Min;
		Slider.maxValue = Max;
		Slider.Set(current, false);
		PercentageLabel.text = $"{(int) (current / max * 100)}%";
		Slider.onValueChanged.AddListener(new System.Action<float>(owo =>
		{
			PercentageLabel.text = $"{(int) (owo / max * 100)}%";
			action?.Invoke(owo);
		}));
		Slider.transform.parent.Find("Button_MM_Mute").gameObject.SetActive(false);
	}

	public void SetToolTip(string newTooltip)
	{
		SliderObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = newTooltip;
		SliderObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = newTooltip;
	}

	public void SetLabel(string newLabel)
	{
		Label.text = newLabel;
	}
}
