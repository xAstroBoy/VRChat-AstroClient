namespace Blaze.API
{
	using UnityEngine;
	using UnityEngine.UI;
	using VRC.Core;

	public class SMList
	{
		public GameObject GameObject;
		public UiVRCList UiVRCList;
		public Text Text;

		public SMList(Transform parent, string name, int Position = 0)
		{
			GameObject = UnityEngine.Object.Instantiate<GameObject>(PublicAvatarList.gameObject, parent);
			GameObject.GetComponent<UiAvatarList>().field_Public_EnumNPublicSealedvaInPuMiFaSpClPuLiCrUnique_0 = UiAvatarList.EnumNPublicSealedvaInPuMiFaSpClPuLiCrUnique.SpecificList;
			UiVRCList = GameObject.GetComponent<UiVRCList>();
			Text = GameObject.transform.Find("Button").GetComponentInChildren<Text>();
			GameObject.transform.SetSiblingIndex(Position);

			UiVRCList.clearUnseenListOnCollapse = false;
			UiVRCList.usePagination = false;
			UiVRCList.hideElementsWhenContracted = false;
			UiVRCList.hideWhenEmpty = false;
			UiVRCList.field_Protected_Dictionary_2_Int32_List_1_ApiModel_0.Clear();

			GameObject.SetActive(true);
			GameObject.name = name;
			Text.text = name;
		}

		private static GameObject PublicAvatarList = GameObject.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

		public void RenderElement(Il2CppSystem.Collections.Generic.List<ApiAvatar> AvatarList)
		{
			UiVRCList.Method_Protected_Void_List_1_T_Int32_Boolean_VRCUiContentButton_0<ApiAvatar>(AvatarList, 0, true);
		}
	}
}
