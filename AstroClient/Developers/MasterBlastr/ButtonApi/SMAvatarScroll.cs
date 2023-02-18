namespace ApolloCore.API.SM;

using ApolloClient.API;
using CheetoClient;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using static MonoBehaviourPublicOb1ObILSt1ILAcIn1Unique;

// Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Header_MM_H2/RightItemContainer

public enum SMMenuType
{
	Favorites,
	Search
}

public class SMAvatarScroll
{
	protected GameObject Button;
	protected MonoBehaviour1PublicGa_c_nGaTeObTeObTeGaUnique Component;
	protected string TitleText;

	public SMAvatarScroll(string btnText, Sprite icon = null, SMMenuType type = SMMenuType.Favorites)
	{
		Initialize(btnText, icon, type);
	}

	private void Initialize(string btnText, Sprite icon, SMMenuType type)
	{
		Button = Object.Instantiate(APIUtils.GetSMAvatarBtnTemplate(), APIUtils.GetSMAvatarBtnTemplate().transform.parent);
		Button.name = $"Apollo-Avatar-Button-{APIUtils.RandomNumbers()}";
		Button.transform.Find("Mask/Text_Name").GetComponent<TextMeshProUGUI>().text = btnText;
		Button.transform.SetSiblingIndex(5);
		Component = Button.GetComponent<MonoBehaviour1PublicGa_c_nGaTeObTeObTeGaUnique>();
		Component.Method_Private_Void_Boolean_0(false);
		Button.GetComponent<Button>().onClick.AddListener(new System.Action(() =>
		{
			APIUtils.SocialMenuInstance.transform.Find("Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Header_MM_H2/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>().text = btnText;
		}));
		if (icon != null)
			Button.transform.Find("Icon").GetComponent<ImageAdvanced>().overrideSprite = Icons.CheetoSprite;
		else
			Button.transform.Find("Icon").gameObject.SetActive(false);

		// Create Header Button
		if (type == SMMenuType.Search)
		{
			// GET RIC
			var ric = APIUtils.SocialMenuInstance.transform.Find("Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation/ScrollRect_Content/Header_MM_H2/RightItemContainer");
			var SMHeaderButton = new CheetoSMHeaderButton(ric, "Avatar Search", Icons.CheetoSprite);
			SMHeaderButton.SetAction(() =>
			{
				InternalUIManager.RunKeyBoardPopup("Avatar Name", $"Avatar Name", "Search", null,
				(result) =>
				{
					NetworkingManager.SendAvatarSearch(result);
				}, null);
				VRCUiManager.field_Private_Static_VRCUiManager_0.HideScreen("MenuKeyboard");
				//InternalUIManager.HideCurrentPopUp();
			});
		}

		Il2CppSystem.Collections.Generic.List<Object1PublicOb1BoObStBoDaStBo1Unique> renderList = new();
		Il2CppSystem.Collections.IList ilist = renderList.Cast<Il2CppSystem.Collections.IList>();
		Component.field_Public_Object_0 = new ValueTypePublicSealed1StObInObObUnique()
		{
			field_Public_Object_0 = new Object3NPublicObSiInSiSiUnique
			{
				prop_TYPE_0 = ilist
			},
		};

		APIUtils.AvatarScrolls.Add(this);
	}

	public GameObject GetGameObject()
	{
		return Button;
	}

	public string GetButtonText()
	{
		return Button.transform.Find("Mask/Text_Name").GetComponent<TextMeshProUGUI>().text;
	}

	public MonoBehaviour1PublicGa_c_nGaTeObTeObTeGaUnique GetComponent()
	{
		return Component;
	}

	public ValueTypePublicSealed1StObInObObUnique GetValueTypeObject()
	{
		return Component.field_Public_Object_0.Cast<ValueTypePublicSealed1StObInObObUnique>();
	}

	public bool IsStringInterfaceNull()
	{
		return GetValueTypeObject().field_Public_InterfacePublicAbstractTYVoTYTYUnique_1_String_0 == null;
	}

	public void SetStringInterface(InterfacePublicAbstractTYVoTYTYUnique<string> newStringInterface)
	{
		GetValueTypeObject().field_Public_InterfacePublicAbstractTYVoTYTYUnique_1_String_0 = newStringInterface;
	}

	public void SetTitleText(string newTitleText)
	{
		GetValueTypeObject().field_Public_InterfacePublicAbstractTYVoTYTYUnique_1_String_0.prop_TYPE_0 = newTitleText;
	}

	public void RefreshList()
	{
		APIUtils.AvatarScrollContentInstance.Method_Private_Void_PDM_0();
	}

	private IEnumerator WaitForSeconds(float seconds, System.Action action)
	{
		yield return new WaitForSeconds(seconds);
		action.Invoke();
		yield break;
	}

	public void SetAvatars(List<ApiAvatar> avatarList, bool setCounter = false)
	{
		Il2CppSystem.Collections.Generic.List<Object1PublicOb1BoObStBoDaStBo1Unique> renderList = new();
		Il2CppSystem.Collections.IList ilist = renderList.Cast<Il2CppSystem.Collections.IList>();
		foreach (var avi in avatarList)
		{
			ilist.Add(new Object1PublicOb1BoObStBoDaStBo1Unique()
			{
				field_Protected_TYPE_0 = avi,
				prop_TYPE_0 = avi,
			});
		}
		GetValueTypeObject().field_Public_Object_0 = new Object3NPublicObSiInSiSiUnique
		{
			prop_TYPE_0 = ilist
		};
		RefreshList();
		if (setCounter)
		{
			if (avatarList.Count > 0)
			{
				Component.Method_Private_Void_Boolean_0(true);
				Button.transform.Find("Count_BG/Text_Number").GetComponent<TextMeshProUGUI>().text = avatarList.Count.ToString(); ;
			}
			else
			{
				Component.Method_Private_Void_Boolean_0(false);
			}
		}
	}

	public void SelectList()
	{
		//Component.Method_Private_Void_PDM_3();
		Button.GetComponent<Button>().onClick.Invoke();
	}

	public void ClearList()
	{
		Il2CppSystem.Collections.Generic.List<Object1PublicOb1BoObStBoDaStBo1Unique> renderList = new();
		GetValueTypeObject().field_Public_Object_0 = renderList;
	}

	public void SelectScroll()
	{
		Component.Method_Private_Void_PDM_3();
	}
}
