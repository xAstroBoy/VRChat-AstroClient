﻿namespace AstroClient.Cheetos
{
    #region Imports

    using System;
    using System.Linq;
    using AstroNetworkingLibrary.Serializable;
    using CheetoLibrary;
    using CheetoLibrary.Menu.MenuApi;
    using Il2CppSystem.Collections.Generic;
    using Tools.AvatarPreviewUtils;
    using UnityEngine;
    using VRC.Core;
    using xAstroBoy;
    using xAstroBoy.Utility;
    using ConfigManager = Config.ConfigManager;

    #endregion Imports

    internal class AvatarFavorites : AstroEvents
    {
        private static GameObject publicAvatarList;

        private static List<ApiAvatar> favoriteAvatars = new List<ApiAvatar>();

        private static VRCList list;

        private static VRCStandaloneInputModule inputModule;

        private static string selectedID;

        private static bool initialized;

        internal override void VRChat_OnQuickMenuInit()
        {
            inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();

            // Avatar Favorite
            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Favorite", 921f, 290f, delegate
            {
                var selected = PlayerUtils.GetPlayer().prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_1.id;
                AddToFavorites(selected);
            }, 1.45f, 1f);

            // Avatar Unfavorite
            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Unfavorite", 921f, 230f, delegate { DeleteFromFavorites(selectedID); }, 1.45f, 1f);

            publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

            list = new VRCList(publicAvatarList.transform.parent, "Astro Favorites");

            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Spawn Preview Avatar", 921f, 170f, delegate { AvatarPreviewer.ClonePreviewAvatar(); }, 1.45f, 1f);
            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Remove Preview Avatars", 921f, 110f, delegate { AvatarPreviewer.DeleteAllClonedAvatars(); }, 1.45f, 1f);

        }

        internal override void OnWorldReveal(string id, string Name, System.Collections.Generic.List<string> tags, string AssetURL, string AuthorName)
        {
            if (!initialized)
            {
                //RefreshList();
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
            for (int i = 0; i < ConfigManager.Favorites.Avatars.Count; i++)
            {
                AvatarData avatarData = ConfigManager.Favorites.Avatars[i];
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
            if (!ConfigManager.Favorites.Avatars.FindAll(a => a.AvatarID == avatarID).Any())
            {
                new ApiAvatar { id = avatarID }.Fetch(new Action<ApiContainer>(model =>
                {
                    ConfigManager.Favorites.Avatars.Add(model.Model.Cast<ApiAvatar>().GetAvatarData());
                    ModConsole.DebugLog($"Avatar Favorited: {avatarID}");
                    ConfigManager.Save_Favorites();
                    RefreshList();
                }));
            }
            else
            {
                ModConsole.Warning("Avatar already favorited!");
            }
        }

        internal static void DeleteFromFavorites(string avatarID)
        {
            if (ConfigManager.Favorites.Avatars.Remove(ConfigManager.Favorites.Avatars.Where(a => a.AvatarID == avatarID).FirstOrDefault()))
            {
                ModConsole.DebugLog($"Avatar Unfavorited: {avatarID}");
                ConfigManager.Save_Favorites();
                RefreshList();
            }
        }
    }
}