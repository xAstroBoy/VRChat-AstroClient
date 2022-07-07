namespace CheetoClient;

#region Imports
using Behaviours;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
#endregion

public class VRCAvatarMenu
{
	private readonly GameObject _self;
	private readonly GameObject _header;
	private readonly Text _title;
	private readonly UiAvatarList _avatarList;
	private readonly UiVRCList _vrcList;

	public VRCAvatarMenu(int index, string title, int rows, bool isFavorites = false) // isFavorites is temporary until I sort a better way
	{
		_self = Object.Instantiate(Utils.QM.Templates.AvatarMenu.gameObject, Utils.QM.Templates.AvatarMenu.transform.parent, true);
		_self.name = $"AvatarMenu-{title}";
		_self.transform.SetSiblingIndex(index);
		_header = _self.transform.Find("Button").gameObject;

		if (isFavorites)
		{
			Object.Destroy(_header);
			_header = new GameObject("Header");
			_header.AddComponent<RectTransform>();
			_header.transform.SetParent(_self.transform);
			var rect = _header.GetComponent<RectTransform>();
			rect.localPosition = Vector3.zero;
			rect.localScale = Vector3.one;
			rect.sizeDelta = new Vector2(1500, 200);

			//var image = _header.AddComponent<Image>();
			//image.sprite = Icons.CheetoSprite;

			// Create the new header, fuck the old one
			_ = _header.AddComponent<HorizontalLayoutGroup>();

			var img1 = new GameObject("Icon1");
			img1.transform.parent = _header.transform;
			var s1 = img1.AddComponent<Image>();
			img1.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
			s1.sprite = Icons.CheetoSprite;

			var img2 = new GameObject("Icon2");
			img2.transform.parent = _header.transform;
			var s2 = img2.AddComponent<Image>();
			img2.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
			s2.sprite = Icons.CheetoSprite;
		}
		else
		{
			_title = _self.transform.Find("Button").transform.Find("TitleText").GetComponent<Text>();
			_title.text = title;
		}

		_avatarList = _self.GetComponent<UiAvatarList>();
		_avatarList.field_Public_Category_0 = UiAvatarList.Category.SpecificList;

		_vrcList = _self.GetComponent<UiVRCList>();
		_vrcList.clearUnseenListOnCollapse = false;
		_vrcList.usePagination = false;
		_vrcList.hideElementsWhenContracted = false;
		_vrcList.hideWhenEmpty = false;
		_vrcList.extendRows = rows;
		_vrcList.expandedHeight *= 0.5f * rows;
	}

	public void Clear()
	{
		_vrcList.field_Protected_Dictionary_2_Int32_List_1_ApiModel_0.Clear();
		RenderElement(new Il2CppSystem.Collections.Generic.List<ApiAvatar>());
	}

	public void SetText(string text)
	{
		_title.text = text;
	}

	public void RenderElement(Il2CppSystem.Collections.Generic.List<ApiAvatar> avatarList, bool hasComponent = true)
	{
		_vrcList.Method_Protected_Void_List_1_T_Int32_Boolean_VRCUiContentButton_0(avatarList);
		if (!hasComponent) return;

		UnhollowerBaseLib.Il2CppArrayBase<VRCUiContentButton> list = _vrcList.pickers.ToArray();
		for (int i = 0; i < avatarList.Count; i++)
		{
			var content = list[i];
			var comp = content.gameObject.GetComponent<CheetoAvatarPicker>();
			if (comp == null)
			{
				comp = content.gameObject.AddComponent<CheetoAvatarPicker>();
			}
			comp.SetAvatar(avatarList[i]);
		}
	}
}