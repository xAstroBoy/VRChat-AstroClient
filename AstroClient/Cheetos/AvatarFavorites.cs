namespace AstroClient.Cheetos
{
    #region Imports

    using AstroLibrary.Console;
    using AstroLibrary.Enums;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using CheetoLibrary;
    using DayClientML2.Utility;
    using DayClientML2.Utility.MenuApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.Core;

    #endregion Imports

    internal class AvatarFavorites : GameEvents
    {
        private static GameObject publicAvatarList;

        private static Il2CppSystem.Collections.Generic.List<ApiAvatar> favoriteAvatars = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();

        private static VRCList list;

        private static VRCStandaloneInputModule inputModule;

        private static string selectedID;

        private static bool initialized;

        internal override void VRChat_OnUiManagerInit()
        {
            inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();

            // Avatar Favorite
            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Favorite", 921f, 290f, delegate ()
              {
                  var selected = PlayerUtils.GetPlayer().prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_1.id;
                  AddToFavorites(selected);
              }, 1.45f, 1f);

            // Avatar Unfavorite
            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Unfavorite", 921f, 230f, delegate ()
              {
                  DeleteFromFavorites(selectedID);
              }, 1.45f, 1f);

            publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

            list = new VRCList(publicAvatarList.transform.parent, "Astro Favorites", 0);
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!initialized)
            {
                RefreshList();
                initialized = true;
            }
        }

        internal override void OnShowScreen(VRCUiPage page)
        {
            if (page.name == "Avatar")
            {
                MiscUtils.DelayFunction(0.1f, () =>
                {
                    AvatarSearch.DumpDone(); // Refresh Avatar Pedestal Dump
                    RefreshList();
                    ModConsole.DebugLog("Refreshed Avatar Lists");
                });
            }
        }

        internal static void RefreshList()
        {
            favoriteAvatars.Clear();
            for (int i = 0; i < AstroClient.ConfigManager.Favorites.Avatars.Count; i++)
            {
                AstroNetworkingLibrary.Serializable.AvatarData avatarData = AstroClient.ConfigManager.Favorites.Avatars[i];
                favoriteAvatars.Add(avatarData.ToApiAvatar());
            }

            list.Text.supportRichText = true;
            list.UiVRCList.expandedHeight *= 2f;
            list.UiVRCList.extendRows = 4;
            list.UiVRCList.startExpanded = false;
            list.RenderElement(favoriteAvatars);

            list.Text.text = $"<color=cyan>Astro Favorites</color> <color=yellow>{favoriteAvatars.Count}</color>";
        }

        internal static void OnSelect()
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

        internal static void AddToFavorites(string avatarID)
        {
            if (!AstroClient.ConfigManager.Favorites.Avatars.FindAll(a => a.AvatarID == avatarID).Any())
            {
                new ApiAvatar { id = avatarID }.Fetch(new Action<ApiContainer>(model =>
                {
                    AstroClient.ConfigManager.Favorites.Avatars.Add(model.Model.Cast<ApiAvatar>().GetAvatarData());
                    ModConsole.DebugLog($"Avatar Favorited: {avatarID}");
                    AstroClient.ConfigManager.Save_Favorites();
                    RefreshList();
                }));
            }
            else
            {
                ModConsole.Warning($"Avatar already favorited!");
            }
        }

        internal static void DeleteFromFavorites(string avatarID)
        {
            if (AstroClient.ConfigManager.Favorites.Avatars.Remove(AstroClient.ConfigManager.Favorites.Avatars.Where(a => a.AvatarID == avatarID).FirstOrDefault()))
            {
                ModConsole.DebugLog($"Avatar Unfavorited: {avatarID}");
                AstroClient.ConfigManager.Save_Favorites();
                RefreshList();
            }
        }
    }
}