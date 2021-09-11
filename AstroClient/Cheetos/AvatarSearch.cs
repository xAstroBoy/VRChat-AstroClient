namespace AstroClient.Cheetos
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Enums;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using DayClientML2.Utility;
    using DayClientML2.Utility.MenuApi;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using UnityEngine;
    using VRC.Core;

    #endregion Imports

    public class AvatarResult : VRCUiContentButton
    {
        public string AvatarID = string.Empty;
    }

    public class AvatarSearch : GameEvents
    {
        public static SearchTypes SearchType = SearchTypes.ALL;

        public static bool IsSearching = false;

        public static bool IsDumping = false;

        private static GameObject publicAvatarList;

        private static Il2CppSystem.Collections.Generic.List<ApiAvatar> foundAvatars = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();

        private static Il2CppSystem.Collections.Generic.List<ApiAvatar> worldAvatars = new Il2CppSystem.Collections.Generic.List<ApiAvatar>();

        private static VRCList searchList;

        private static VRCList worldList;

        private static Stopwatch stopwatch;

        private static Stopwatch stopwatch2;

        private static MenuButton searchTypeButton;

        private static MenuButton deleteButton;

        private static VRCStandaloneInputModule inputModule;

        private static string selectedID;

        private static string lastSearchQuery;

        private static SearchTypes lastSearchType;

        public enum SearchTypes
        {
            ALL,
            PUBLIC,
            PRIVATE
        }

        public override void VRChat_OnUiManagerInit()
        {
            inputModule = GameObject.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();

            // Avatar Search
            _ = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Astro Search", 921f, 470f, delegate ()
              {
                  CheetosHelpers.PopupCall("Astro Avatar Search", "Search", "Enter Avatar name. . .", false, delegate (string text)
                  {
                      Search(SearchType, text);
                  });
              }, 1.45f, 1f);

            searchTypeButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "All", 921f, 410f, delegate ()
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
                deleteButton = new MenuButton(MenuType.AvatarMenu, MenuButtonType.AvatarFavButton, "Delete From Database", 921f, 350f, delegate ()
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

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            PedestalDump();
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

        public static void Search(SearchTypes searchType, string query)
        {
            if (!IsSearching)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();

                lastSearchQuery = query;
                lastSearchType = searchType;

                // Refresh UI
                foundAvatars.Clear();
                NetworkingManager.AvatarSearch(searchType, query);

                IsSearching = true;
                _ = MelonLoader.MelonCoroutines.Start(SearchLoop());
            }
        }

        public static IEnumerator SearchLoop()
        {
            if (!IsSearching) yield break;

            for (; ; )
            {
                yield return new WaitForEndOfFrame();
                if (!IsSearching)
                {
                    SearchDone();
                    yield break;
                }
            }
        }

        public static void PedestalDump()
        {
            stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            // Refresh UI
            worldAvatars.Clear();

            var avatars = WorldUtils_Old.GetAvatarsFromPedestals();

            if (avatars.AnyAndNotNull())
            {
                foreach (var avatar in avatars)
                {
                    worldAvatars.Add(avatar);

                    if (avatar != null)
                    {
                        var avatarData = new AvatarData()
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

            DumpDone();
        }

        public static void DumpDone()
        {
            worldList.Text.supportRichText = true;
            worldList.UiVRCList.expandedHeight *= 2f;
            worldList.UiVRCList.extendRows = 4;
            worldList.UiVRCList.startExpanded = false;

            worldList.RenderElement(worldAvatars);

            stopwatch2.Stop();
            ModConsole.Log($"Avatar Pedestals Completed: found {worldAvatars.Count} avatars, took {stopwatch2.ElapsedMilliseconds}ms");
            worldList.Text.text = $"<color=cyan>Astro Pedestal</color> Found: <color=yellow>{worldAvatars.Count}</color>";
        }

        public static void SearchDone()
        {
            IsSearching = false;
            stopwatch.Stop();
            searchList.Text.supportRichText = true;
            searchList.UiVRCList.expandedHeight *= 2f;
            searchList.UiVRCList.extendRows = 4;
            searchList.UiVRCList.startExpanded = false;
            //Utils.VRCUiManager.ShowScreen(currPageAvatar);

            foreach (var avatar in foundAvatars.ToArray().Where(a => a.releaseStatus.ToLower().Equals("private")))
            {
                avatar.name = $"<color=red>[P]</color> {avatar.name}";
            }

            searchList.RenderElement(foundAvatars);

            searchList.Text.text = $"<color=cyan>Astro Search</color> Found: <color=yellow>{foundAvatars.Count}</color> in {stopwatch.ElapsedMilliseconds}ms";
            ModConsole.Log($"Avatar Search Completed: found {foundAvatars.Count} avatars in {stopwatch.ElapsedMilliseconds}ms");
        }

        public static void AddAvatar(AvatarData avatarData)
        {
            foundAvatars.Add(avatarData.ToApiAvatar());
        }

        private static void UpdateButtons()
        {
            searchTypeButton.SetText(System.Enum.GetName(typeof(SearchTypes), SearchType).ToLower().ToUppercaseFirstCharacterOnly());
        }
    }
}