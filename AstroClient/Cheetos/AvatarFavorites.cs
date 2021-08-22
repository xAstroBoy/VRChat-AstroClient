namespace AstroClient.Cheetos
{
	#region Imports

	using AstroLibrary.Enums;
	using AstroLibrary.Finder;
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility;
	using DayClientML2.Utility.MenuApi;
	using UnityEngine;
	using VRC.Core;

	#endregion Imports

    public class AvatarFavorites : GameEvents
    {
        private static GameObject publicAvatarList;

        private static Il2CppSystem.Collections.Generic.List<ApiAvatar> favoriteAvatars = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();

        private static VRCList list;

		private static VRCStandaloneInputModule inputModule;

		private static string selectedID;

		public override void VRChat_OnUiManagerInit()
        {
			inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();

			// Avatar Favorite
			new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Favorite", 921f, 290f, delegate ()
            {
            }, 1.45f, 1f);

			// Avatar Unfavorite
			new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Unfavorite", 921f, 230f, delegate ()
			{
			}, 1.45f, 1f);

			publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

            list = new VRCList(publicAvatarList.transform.parent, "Astro Favorites", 0);
            list.Text.supportRichText = true;
        }

		public static void OnSelect()
		{
			// Add a check here later
			var selected = inputModule.field_Public_Selectable_0;
			if (selected != null)
			{
				var comp = selected.gameObject.GetComponent<VRCUiContentButton>();
				if (comp != null)
				{
					var id = comp.field_Public_String_0;
					if (id != string.Empty)
					{
						selectedID = inputModule.field_Public_Selectable_0.gameObject.GetComponent<VRCUiContentButton>().field_Public_String_0;
					}
				}
			}
		}

		public static void AddAvatar(AvatarData avatarData)
        {
            favoriteAvatars.Add(avatarData.ToApiAvatar());
        }
    }
}