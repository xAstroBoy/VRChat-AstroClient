﻿namespace AstroClient.Cheetos
{
    #region Imports

    using System;
    using System.Collections;
    using System.Diagnostics;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using CheetoLibrary;
    using CheetoLibrary.Menu.MenuApi;
    using CheetoLibrary.Utility;
    using Constants;
    using FavCat;
    using FavCat.Database.Stored;
    using FavCat.Modules;
    using Il2CppSystem.Collections.Generic;
    using MelonLoader;
    using Newtonsoft.Json;
    using Tools.World;
    using UnityEngine;
    using VRC.Core;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class AvatarSearch : AstroEvents
    {
        //internal static SearchTypes SearchType = SearchTypes.ALL;

        //internal static bool IsSearching;

        internal static bool IsDumping = false;

        private static GameObject publicAvatarList;

        //private static List<ApiAvatar> foundAvatars = new List<ApiAvatar>();

        private static List<string> worldAvatarsids = new List<string>();

        //private static VRCList searchList;

        //private static VRCList worldList;

        //private static Stopwatch stopwatch = new Stopwatch();

        private static Stopwatch stopwatch2 = new Stopwatch();

        //private static MenuButton searchTypeButton;

        //private static MenuButton deleteButton;

        //private static VRCStandaloneInputModule inputModule;

        //private static string selectedID;

        //private static string lastSearchQuery;

        //private static SearchTypes lastSearchType;

        //internal enum SearchTypes
        //{
        //    ALL,
        //    PUBLIC,
        //    PRIVATE
        //}

        internal override void VRChat_OnQuickMenuInit()
        {
            //inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();

            ////// Avatar Search
            ////_ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Search", 921f, 470f, delegate { CheetoUtils.PopupCall("Astro Avatar Search", "Search", "Enter Avatar name. . .", false, delegate (string text) { Search(SearchType, text); }); }, 1.45f, 1f);

            ////searchTypeButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "All", 921f, 410f, delegate
            ////{
            ////    if (SearchType == SearchTypes.ALL)
            ////    {
            ////        SearchType = SearchTypes.PRIVATE;
            ////    }
            ////    else if (SearchType == SearchTypes.PRIVATE)
            ////    {
            ////        SearchType = SearchTypes.PUBLIC;
            ////    }
            ////    else if (SearchType == SearchTypes.PUBLIC)
            ////    {
            ////        SearchType = SearchTypes.ALL;
            ////    }

            ////    UpdateButtons();
            ////}, 1.45f, 1f);

            //publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

            //worldList = new VRCList(publicAvatarList.transform.parent, "Astro Pedestal Results", 0);
            //worldList.Text.supportRichText = true;
            //_ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Get World Avatars", 921f, 470f, delegate
            //{
            //    ShowAvatarsOnFavcat();
            //});

        }

        internal override void OnWorldReveal(string id, string Name, System.Collections.Generic.List<string> tags, string AssetURL, string AuthorName)
        {
            MiscUtils.DelayFunction(0.1f, () => { PedestalDump(); });
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

        //internal static void Search(SearchTypes searchType, string query)
        //{
        //    if (!IsSearching)
        //    {
        //        stopwatch.Start();

        //        lastSearchQuery = query;
        //        lastSearchType = searchType;

        //        // Refresh UI
        //        foundAvatars.Clear();

        //        IsSearching = true;
        //        _ = MelonCoroutines.Start(SearchLoop());
        //    }
        //}

        //internal static IEnumerator SearchLoop()
        //{
        //    for (; ; )
        //    {
        //        yield return new WaitForSeconds(0.025f);
        //        if (!IsSearching)
        //        {
        //            SearchDone();
        //            yield break;
        //        }
        //    }
        //}
        internal override void OnShowScreen(VRCUiPage page)
        {
            if (page.name == "Avatar")
            {
                MiscUtils.DelayFunction(0.1f, () =>
                {
                    AvatarSearch.ShowAvatarsOnFavcat(); // Refresh Avatar Pedestal Dump (and highlight it)
                    ModConsole.DebugLog("Refreshed Avatar Lists");
                });
            }
        }

        internal static void PedestalDump()
        {
            stopwatch2.Start();

            // Refresh UI
            worldAvatarsids.Clear();

            var avatars = WorldUtils_Old.GetAvatarsFromPedestals();
            if (avatars != null && avatars.AnyAndNotNull())
            {
                for (int i = 0; i < avatars.Count; i++)
                {
                    string id = avatars[i];
                    worldAvatarsids.Add(id);
                }
            }

            stopwatch2.Stop();
            ModConsole.DebugLog($"Avatar Pedestals Completed: found {worldAvatarsids.Count} avatars, took {stopwatch2.ElapsedMilliseconds}ms");

        }

        internal override void OnRoomLeft()
        {
            _WorldPedestralAvatars.Clear();
        }

        private static System.Collections.Generic.List<StoredAvatar> _WorldPedestralAvatars = new System.Collections.Generic.List<StoredAvatar>();
        internal static System.Collections.Generic.List<StoredAvatar> WorldPedestralAvatars
        {
            get
            {
                if (_WorldPedestralAvatars.Count == 0)
                {
                    foreach (var item in worldAvatarsids)
                    {
                        AvatarModule.GetStoredFromID(item, (avatar) =>
                        {
                            if (avatar != null)
                            {
                                _WorldPedestralAvatars.Add(avatar);
                            }
                        });

                    }
                    return _WorldPedestralAvatars;
                }

                return _WorldPedestralAvatars;

            }
        }

        //private StoredCategory _WorldPedestralCategory;
        //private StoredCategory WorldPedestralCategory
        //{
        //    get
        //    {
        //        if (_WorldPedestralCategory == null)
        //        {
        //            _WorldPedestralCategory = AvatarModule.GetOrCreateCustomCategory("World Pedestal (AstroClient)");

        //        }

        //        return WorldPedestralCategory;
        //    }
        //}

        static void ShowAvatarsOnFavcat()
        {

            // TODO : make Favcat have custom categories that can be controlled from here.
            AvatarModule.AcceptRemoteResults(WorldPedestralAvatars);
            AvatarModule.SetSearchHeaderText($"<color=#E0E300>World Pedestal (AstroClient)</color>");

        }

    }
}