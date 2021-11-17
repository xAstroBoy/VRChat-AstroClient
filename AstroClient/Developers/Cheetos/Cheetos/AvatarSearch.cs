namespace AstroClient.Cheetos
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
    using Il2CppSystem.Collections.Generic;
    using MelonLoader;
    using Networking;
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
        internal static SearchTypes SearchType = SearchTypes.ALL;

        internal static bool IsSearching;

        internal static bool IsDumping = false;

        private static GameObject publicAvatarList;

        private static List<ApiAvatar> foundAvatars = new List<ApiAvatar>();

        private static List<ApiAvatar> worldAvatars = new List<ApiAvatar>();

        private static VRCList searchList;

        private static VRCList worldList;

        private static Stopwatch stopwatch = new Stopwatch();

        private static Stopwatch stopwatch2 = new Stopwatch();

        private static MenuButton searchTypeButton;

        private static MenuButton deleteButton;

        private static VRCStandaloneInputModule inputModule;

        private static string selectedID;

        private static string lastSearchQuery;

        private static SearchTypes lastSearchType;

        internal enum SearchTypes
        {
            ALL,
            PUBLIC,
            PRIVATE
        }

        internal override void VRChat_OnQuickMenuInit()
        {
            inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();

            // Avatar Search
            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Search", 921f, 470f, delegate { CheetoUtils.PopupCall("Astro Avatar Search", "Search", "Enter Avatar name. . .", false, delegate(string text) { Search(SearchType, text); }); }, 1.45f, 1f);

            searchTypeButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "All", 921f, 410f, delegate
            {
                if (SearchType == SearchTypes.ALL)
                {
                    SearchType = SearchTypes.PRIVATE;
                }
                else if (SearchType == SearchTypes.PRIVATE)
                {
                    SearchType = SearchTypes.PUBLIC;
                }
                else if (SearchType == SearchTypes.PUBLIC)
                {
                    SearchType = SearchTypes.ALL;
                }

                UpdateButtons();
            }, 1.45f, 1f);

            if (Bools.IsDeveloper)
            {
                deleteButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Delete From Database", 921f, 350f, delegate
                {
                    ModConsole.Log($"Sent Avatar Deletion For: {selectedID}");
                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_DELETE, selectedID));
                }, 1.45f, 1f);
            }

            publicAvatarList = GameObjectFinder.Find("/UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Public Avatar List");

            searchList = new VRCList(publicAvatarList.transform.parent, "Astro Search Results", 1);
            searchList.Text.supportRichText = true;

            worldList = new VRCList(publicAvatarList.transform.parent, "Astro Pedestal Results", 2);
            worldList.Text.supportRichText = true;
        }

        internal override void OnWorldReveal(string id, string Name, System.Collections.Generic.List<string> tags, string AssetURL, string AuthorName)
        {
            MiscUtils.DelayFunction(0.5f, () => { PedestalDump(); });
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

        internal static void Search(SearchTypes searchType, string query)
        {
            if (!IsSearching)
            {
                stopwatch.Start();

                lastSearchQuery = query;
                lastSearchType = searchType;

                // Refresh UI
                foundAvatars.Clear();
                NetworkingManager.AvatarSearch(searchType, query);

                IsSearching = true;
                _ = MelonCoroutines.Start(SearchLoop());
            }
        }

        internal static IEnumerator SearchLoop()
        {
            for (;;)
            {
                yield return new WaitForSeconds(0.025f);
                if (!IsSearching)
                {
                    SearchDone();
                    yield break;
                }
            }
        }

        internal static void PedestalDump()
        {
            stopwatch2.Start();

            // Refresh UI
            worldAvatars.Clear();

            var avatars = WorldUtils_Old.GetAvatarsFromPedestals();
            if (avatars != null && avatars.AnyAndNotNull())
            {
                for (int i = 0; i < avatars.Count; i++)
                {
                    ApiAvatar avatar = avatars[i];
                    worldAvatars.Add(avatar);
                    if (AstroNetworkClient.Client != null)
                    {
                        if (AstroNetworkClient.Client.IsConnected)
                        {
                            if (avatar != null)
                            {
                                var avatarData = new AvatarData
                                {
                                    AssetURL = avatar.assetUrl,
                                    AuthorID = avatar.authorId,
                                    AuthorName = avatar.authorName,
                                    Description = avatar.description,
                                    AvatarID = avatar.id,
                                    ImageURL = avatar.imageUrl,
                                    ThumbnailURL = avatar.thumbnailImageUrl,
                                    Name = avatar.name,
                                    ReleaseStatus = avatar.releaseStatus,
                                    Version = avatar.version,
                                    SupportedPlatforms = avatar.supportedPlatforms.ToString()
                                };
                                if (avatarData != null)
                                {
                                    var json = JsonConvert.SerializeObject(avatarData);
                                    AstroNetworkClient.Client.Send(new PacketData(PacketClientType.AVATAR_DATA, json));
                                }
                            }
                        }
                    }
                }
            }

            DumpDone();
        }

        internal static void DumpDone()
        {
            worldList.Text.supportRichText = true;
            worldList.UiVRCList.expandedHeight *= 2f;
            worldList.UiVRCList.extendRows = 4;
            worldList.UiVRCList.startExpanded = false;

            worldList.RenderElement(worldAvatars);

            stopwatch2.Stop();
            ModConsole.DebugLog($"Avatar Pedestals Completed: found {worldAvatars.Count} avatars, took {stopwatch2.ElapsedMilliseconds}ms");
            worldList.Text.text = $"<color=cyan>Astro Pedestal</color> Found: <color=yellow>{worldAvatars.Count}</color>";
        }

        internal static void SearchDone()
        {
            IsSearching = false;
            stopwatch.Stop();
            searchList.Text.supportRichText = true;
            searchList.UiVRCList.expandedHeight *= 2f;
            searchList.UiVRCList.extendRows = 4;
            searchList.UiVRCList.startExpanded = false;
            //Utils.VRCUiManager.ShowScreen(currPageAvatar);

            for (int i = 0; i < foundAvatars.Count; i++)
            {
                var avatar = foundAvatars[i];
                if (avatar != null && avatar.releaseStatus.ToLower().Equals("private")) avatar.name = $"<color=red>[P]</color> {avatar.name}";
            }

            searchList.RenderElement(foundAvatars);

            searchList.Text.text = $"<color=cyan>Astro Search</color> Found: <color=yellow>{foundAvatars.Count}</color> in {stopwatch.ElapsedMilliseconds}ms";
            ModConsole.DebugLog($"Avatar Search Completed: found {foundAvatars.Count} avatars in {stopwatch.ElapsedMilliseconds}ms");
        }

        internal static void AddAvatar(AvatarData avatarData)
        {
            foundAvatars.Add(avatarData.ToApiAvatar());
        }

        private static void UpdateButtons()
        {
            searchTypeButton.SetText(Enum.GetName(typeof(SearchTypes), SearchType).ToLower().ToUppercaseFirstCharacterOnly());
        }
    }
}