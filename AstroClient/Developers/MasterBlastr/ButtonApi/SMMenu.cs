namespace ApolloClient.API.SM;

using System.Linq;
using CheetoClient;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
using Color = CheetoClient.Color;

internal class SMMenu
{
	protected GameObject MenuObject;
	protected TextMeshProUGUI MenuTitleText;
	protected UIPage MenuPage;
	protected string MenuName;
	protected GameObject MainButton;
	protected GameObject BadgeObject;
	protected TextMeshProUGUI BadgeText;
	protected MenuTab MenuTabComp;
	protected Image Icon;

	internal SMMenu(string title, string tooltip, Sprite icon = null)
	{
		Initialize(title, tooltip, icon);
	}

	private void Initialize(string title, string tooltip, Sprite icon)
	{
		MenuName = $"{APIUtils.Identifier}-SMMenu-{APIUtils.RandomNumbers()}";
		MenuObject = Object.Instantiate(APIUtils.GetSMMenuTemplate(), APIUtils.GetSMMenuTemplate().transform.parent);
		MenuObject.name = MenuName;
		MenuObject.SetActive(false);
		MenuObject.transform.SetSiblingIndex(19);
		Object.DestroyImmediate(MenuObject.GetComponent<MonoBehaviour1PublicObTe_h_rOb_sObUnique>());
		MenuPage = MenuObject.AddComponent<UIPage>();
		MenuPage.field_Public_String_0 = MenuName;
		MenuPage.field_Private_Boolean_1 = true;
		MenuPage.field_Protected_MenuStateController_0 = APIUtils.SocialMenuInstance.prop_MenuStateController_0;
		MenuPage.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
		MenuPage.field_Private_List_1_UIPage_0.Add(MenuPage);
		APIUtils.SocialMenuInstance.prop_MenuStateController_0.field_Private_Dictionary_2_String_UIPage_0.Add(MenuName, MenuPage);

		var tmpList = APIUtils.SocialMenuInstance.prop_MenuStateController_0.field_Public_ArrayOf_UIPage_0.ToList();
		tmpList.Add(MenuPage);
		APIUtils.SocialMenuInstance.prop_MenuStateController_0.field_Public_ArrayOf_UIPage_0 = tmpList.ToArray();

		Transform categoryContainer = MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/Viewport/VerticalLayoutGroup");

		for (int i = 0; i < categoryContainer.childCount; i++)
		{
			Transform child = categoryContainer.GetChild(i);
			if (child == null || child.name == "DynamicSidePanel_Header")
				continue;
			Object.Destroy(child.gameObject);
		}
		MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Viewport/VerticalLayoutGroup").DestroyChildren();
		MenuTitleText = MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/Viewport/VerticalLayoutGroup/DynamicSidePanel_Header/Text_Name").GetComponent<TextMeshProUGUI>();
		SetMenuTitle(title);

		MainButton = Object.Instantiate(APIUtils.GetSMTabButtonTemplate(), APIUtils.GetSMTabButtonTemplate().transform.parent);
		MainButton.name = MenuName;
		MenuTabComp = MainButton.GetComponent<MenuTab>();
		MenuTabComp.field_Private_MenuStateController_0 = APIUtils.SocialMenuInstance.prop_MenuStateController_0;
		MenuTabComp.field_Public_String_0 = MenuName;
		MenuTabComp.GetComponent<StyleElement>().field_Private_Selectable_0 = MenuTabComp.GetComponent<Button>();
		BadgeObject = MainButton.transform.GetChild(0).gameObject;
		BadgeText = BadgeObject.GetComponentInChildren<TextMeshProUGUI>();
		MainButton.GetComponent<Button>().onClick.AddListener(new System.Action(() =>
		{
			MenuObject.SetActive(true);
			Canvas[] canvases = MenuObject.GetComponentsInChildren<Canvas>(true);
			foreach (var canvas in canvases)
				canvas.enabled = true;

			CanvasGroup[] canvasGroups = MenuObject.GetComponentsInChildren<CanvasGroup>(true);
			foreach (var canvasGroup in canvasGroups)
				canvasGroup.enabled = true;

			GraphicRaycaster[] graphicRaycasters = MenuObject.GetComponentsInChildren<GraphicRaycaster>(true);
			foreach (var gr in graphicRaycasters)
				gr.enabled = true;

			MenuTabComp.GetComponent<StyleElement>().field_Private_Selectable_0 = MenuTabComp.GetComponent<Button>();
		}));

		Icon = MainButton.transform.Find("Icon").GetComponent<Image>();
		Icon.MakeImageMoreSolid();

		Object.Destroy(MenuTitleText.transform.parent.Find("Button_Logout").gameObject);
		Object.Destroy(MenuTitleText.transform.parent.Find("Button_Exit").gameObject);
		MenuTitleText.transform.parent.Find("Separator").GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -100);
		MenuTitleText.transform.parent.GetComponent<LayoutElement>().minHeight = 100;
		var rt = MenuTitleText.transform.parent.Find("Text_Name").GetComponent<RectTransform>();
		rt.anchoredPosition = new Vector2(0, -50);
		rt.sizeDelta = new Vector2(250, 48);
		MenuTitleText.transform.parent.Find("Icon").gameObject.SetActive(false);
		MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Header_MM_H2/LeftItemContainer/Text_Title").gameObject.SetActive(false);
		var sr = MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content").GetComponent<ScrollRectEx>();
		sr.field_Public_Boolean_0 = true;
		sr.field_Private_Boolean_0 = false;
		sr.field_Private_Boolean_1 = false;
		sr.field_Private_Boolean_2 = false;

		SetToolTip(tooltip);
		if (icon != null)
		{
			SetImage(icon);
		}
	}

	public void SetImage(Sprite newImg)
	{
		MainButton.transform.Find("Icon").GetComponent<Image>().sprite = newImg;
		MainButton.transform.Find("Icon").GetComponent<Image>().overrideSprite = newImg;
		MainButton.transform.Find("Icon").GetComponent<Image>().color = Color.White;
		MainButton.transform.Find("Icon").GetComponent<Image>().m_Color = Color.White;
	}

	public void SetToolTip(string newText)
	{
		MainButton.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = newText;
	}

	public void SetMenuTitle(string newTitle)
	{
		MenuTitleText.text = newTitle;
	}

	public Transform GetCategoryButtonContainer()
	{
		return MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/Viewport/VerticalLayoutGroup");
	}

	public Transform GetCategoryChildContainer()
	{
		return MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Viewport/VerticalLayoutGroup");
	}

	public TextMeshProUGUI GetCategoryTitle()
	{
		return MenuObject.transform.Find("Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Header_MM_H2/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>();
	}
}
