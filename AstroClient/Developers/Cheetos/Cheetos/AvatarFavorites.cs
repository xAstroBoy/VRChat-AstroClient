namespace AstroClient.Cheetos
{
    #region Imports

    using System;
    using System.Linq;
    using AstroNetworkingLibrary.Serializable;
    using CheetoLibrary;
    using CheetoLibrary.Menu.MenuApi;
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using Tools.Player;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using xAstroBoy;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;
    using ConfigManager = Config.ConfigManager;

    #endregion Imports

    internal class AvatarFavorites : AstroEvents
    {

        private static VRCStandaloneInputModule inputModule;

        private static string selectedID;

        private static bool initialized;

        internal override void VRChat_OnQuickMenuInit()
        {
            //inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();
            //// Avatar Favorite
            //_ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Favorite", 921f, 290f, delegate
            //{
            //    var selected = PlayerUtils.GetPlayer().prop_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_1.id;
            //    AddToFavorites(selected);
            //}, 1.45f, 1f);

            //// Avatar Unfavorite
            //_ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Local clone Avatar", 921f, 230f, delegate { UserInterfaceObjects.AvatarPreviewBase_MainAvatar.GetComponentInChildren<SimpleAvatarPedestal>().field_Internal_ApiAvatar_0.CloneLocalAvatar(); }, 1.45f, 1f);

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

        //internal static void OnSelect()
        //{
        //    // Add a check here later
        //    var selected = inputModule.field_Public_Selectable_0;
        //    if (selected != null)
        //    {
        //        var comp = selected.gameObject.GetComponent<VRCUiContentButton>();
        //        if (comp != null)
        //        {
        //            var id = comp.field_Public_String_0;
        //            if (id != string.Empty)
        //            {
        //                selectedID = inputModule.field_Public_Selectable_0.gameObject.GetComponent<VRCUiContentButton>().field_Public_String_0;
        //            }
        //        }
        //    }
        //}

    }
}