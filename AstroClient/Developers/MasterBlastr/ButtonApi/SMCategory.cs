namespace ApolloClient.API.SM;

using TMPro;
using UnityEngine;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Tooltips;

internal class SMCategory
{
	protected GameObject ButtonObj;
	protected GameObject ContainerObj;
	protected TextMeshProUGUI ButtonText;
	protected SMMenu Menu;

	internal SMCategory(SMMenu menu, string btnText, string tooltip)
	{
		Initialize(menu, btnText, tooltip);
	}

	private void Initialize(SMMenu menu, string btnText, string tooltip)
	{
		var numb = APIUtils.RandomNumbers();
		Menu = menu;
		ButtonObj = Object.Instantiate(APIUtils.GetSMCategoryButtonTemplate(), menu.GetCategoryButtonContainer());
		ButtonObj.name = $"{APIUtils.Identifier}-CategoryBtn-{numb}";
		ButtonObj.transform.Find("Icon").gameObject.SetActive(false);
		ButtonText = ButtonObj.transform.Find("Mask/Text_Name").GetComponent<TextMeshProUGUI>();
		SetButtonText(btnText);

		ContainerObj = Object.Instantiate(APIUtils.GetSMCategoryContainerTemplate(), menu.GetCategoryChildContainer());
		ContainerObj.name = $"{APIUtils.Identifier}-CatetgoryChild-{numb}";
		ContainerObj.transform.DestroyChildren();

		var rbs = ButtonObj.GetComponent<RadioButtonSelector>();
		rbs.field_Public_String_0 = $"{APIUtils.Identifier}-CatetgoryChild-{numb}";
		rbs.field_Public_TextMeshProUGUI_0 = menu.GetCategoryTitle();
		rbs.field_Public_GameObject_1 = ContainerObj;

		SetTooltipText(tooltip);
	}

	public void SetButtonText(string newText)
	{
		ButtonText.text = newText;
	}

	public void SetTooltipText(string newToolTip)
	{
		ButtonObj.GetComponent<UiTooltip>().field_Public_String_0 = newToolTip;
		ButtonObj.GetComponent<UiTooltip>().field_Public_String_1 = newToolTip;
	}

	public Transform GetContainer()
	{
		return ContainerObj.transform;
	}

	public SMMenu GetMenu()
	{
		return Menu;
	}
}
