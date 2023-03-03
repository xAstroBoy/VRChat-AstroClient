using AstroClient.ClientActions;
using AstroClient.xAstroBoy;
using VRC.SDKBase;
using VRC.SDKBase.Validation.Performance;

namespace AstroClient.PlayerList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AstroClient;
    using Config;
    using Entries;
    using MelonLoader;
    using UnityEngine;
    using Utilities;
    using VRC;
    using VRC.Core;
    using VRC.DataModel;
    using Object = UnityEngine.Object;


    internal class EntryManager : AstroEvents
    {
        internal static LocalPlayerEntry localPlayerEntry = null;

        public static List<PlayerEntry> playerEntries = new List<PlayerEntry>(); // This will not be sorted
        public static List<PlayerLeftPairEntry> playerLeftPairsEntries = new List<PlayerLeftPairEntry>();
        public static Dictionary<string, PlayerLeftPairEntry> NameToEntryTable = new Dictionary<string, PlayerLeftPairEntry>();
        public static List<EntryBase> generalInfoEntries = new List<EntryBase>();
        public static List<EntryBase> entries = new List<EntryBase>();
        

        public class deferredAvInstantiate
        {
            public VRCAvatarManager player;
            public ApiAvatar avatar;
            public GameObject gameObject;
            public int numAttempts;

            public deferredAvInstantiate(VRCAvatarManager a, ApiAvatar b, GameObject c) 
            {
                this.player = a;
                this.avatar = b;
                this.gameObject = c;
                this.numAttempts = 0;
            }
        }

        public static Dictionary<string, deferredAvInstantiate> AvInstBacklog = new Dictionary<string, deferredAvInstantiate>();

        private static bool _NeedUpdateEvent = false;
        private static bool NeedUpdateEvent
        {
            get => _NeedUpdateEvent;
            set
            {
                if(_NeedUpdateEvent != value)
                {
                    if(value)
                    {
                        ClientEventActions.OnUpdate += OnUpdate;
                    }
                    else
                    {
                        ClientEventActions.OnUpdate -= OnUpdate;
                    }
                }
                _NeedUpdateEvent = value;
            }
        }

        internal static void OnQuickMenuOpen()
        {
            NeedUpdateEvent = true;
        }
        internal static void OnQuickMenuClose()
        {
            NeedUpdateEvent = false;
        }
        internal static void OnBigMenuOpen()
        {
            NeedUpdateEvent = false;
        }
        internal static void OnBigMenuClose()
        {
            NeedUpdateEvent = false;
        }


        public static void Init()
        {
            PlayerListConfig.fontSize.OnValueChanged += (oldValue, newValue) => SetFontSize(newValue);
            ConfigEventActions.OnPlayerListConfigChanged += OnConfigChanged;
            ClientEventActions.OnPlayerJoin += OnPlayerJoined;
            ClientEventActions.OnSceneLoaded += OnSceneLoaded;
            ClientEventActions.OnEnterWorld += OnEnterWorld;
            ClientEventActions.OnAvatarInstantiated += OnAvatarInstantiated;
            ClientEventActions.OnAvatarDownloadProgress += OnavatarDownloadProgress;
            ClientEventActions.OnPlayerLeft += OnPlayerLeft;

            // this will handle OnUpdate Subscription .
            ClientEventActions.OnQuickMenuOpen += OnQuickMenuOpen;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
            ClientEventActions.OnBigMenuOpen += OnBigMenuOpen;
            ClientEventActions.OnBigMenuClose += OnBigMenuClose;


            MelonCoroutines.Start(EntryRefreshEnumerator());
        }

        private static void OnPlayerJoined(Player player)
        {
            if (player.name.Contains("Local") && player.prop_APIUser_0 == null)
                player.prop_APIUser_0 = APIUser.CurrentUser;

            if (NameToEntryTable.ContainsKey(player.prop_APIUser_0.id))
                return; // If already in list

            if (player.name.Contains("Local"))
            {
                if (localPlayerEntry != null)
                    return;

                GameObject template = Object.Instantiate(PlayerList_Constants.playerListLayout.transform.FindObject("Template").gameObject, PlayerList_Constants.playerListLayout.transform);
                template.SetActive(true);

                LeftSidePlayerEntry leftSidePlayerEntry = EntryBase.CreateInstance<LeftSidePlayerEntry>(template.transform.FindObject("LeftPart").gameObject);
                EntryBase.CreateInstance<LocalPlayerEntry>(template.transform.FindObject("RightPart").gameObject);
                AddPlayerLeftPairEntry(EntryBase.CreateInstance<PlayerLeftPairEntry>(template, new object[] { leftSidePlayerEntry, localPlayerEntry }));
            }
            else
            {
                GameObject template = Object.Instantiate(PlayerList_Constants.playerListLayout.transform.FindObject("Template").gameObject, PlayerList_Constants.playerListLayout.transform);
                template.SetActive(true);

                LeftSidePlayerEntry leftSidePlayerEntry = EntryBase.CreateInstance<LeftSidePlayerEntry>(template.transform.FindObject("LeftPart").gameObject);
                PlayerEntry playerEntry = EntryBase.CreateInstance<PlayerEntry>(template.transform.FindObject("RightPart").gameObject, new object[] { player });
                AddPlayerLeftPairEntry(EntryBase.CreateInstance<PlayerLeftPairEntry>(template, new object[] { leftSidePlayerEntry, playerEntry }));
            }
        }

        private static IEnumerator EntryRefreshEnumerator()
        {
            while (playerEntries.Count == 0)
                yield return null;

            int i = -1;
            while (true)
            {
                i += 1;
                if (i >= playerEntries.Count)
                {
                    i = 0;
                    if (playerEntries.Count == 0)
                    {
                        yield return null;
                        continue;
                    }
                }

                try
                {
                    if (playerEntries[i].player == null)
                    {
                        playerEntries[i].playerLeftPairEntry.Remove();
                        continue;
                    }

                    if (playerEntries[i].timeSinceLastUpdate.ElapsedMilliseconds > 100)
                        PlayerEntry.UpdateEntry(playerEntries[i].player.prop_PlayerNet_0, playerEntries[i]);
                }
                catch (Exception ex)
                {
                   Log.Error(ex.ToString());
                }

                yield return null;
            }
        }
        private static void OnUpdate()
        {
            RefreshAllEntries();
        }

        private static void OnSceneLoaded(int buildIndex, string sceneName)
        {
            for (int i = playerEntries.Count - 1; i >= 0; i--)
                playerEntries[i].playerLeftPairEntry.Remove();
            localPlayerEntry?.EntryBase_OnSceneWasLoaded();
        }

        private static void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            foreach (EntryBase entry in entries)
                entry.EntryBase_OnInstanceChange(world, instance);
            RefreshLeftPlayerEntries(0, 0, true);
        }
        public static void OnConfigChanged()
        {
            foreach (EntryBase entry in entries)
                entry.EntryBase_OnConfigChanged();
        }


        private static void OnAvatarInstantiated(VRCAvatarManager player, ApiAvatar avatar, GameObject gameObject)
        {
            //Log.WriteMsg("EM: OnAvInst");
            /*foreach (EntryBase entry in playerEntries)
                entry.OnAvatarInstantiated(player, avatar, gameObject);
            localPlayerEntry?.OnAvatarInstantiated(player, avatar, gameObject);*/

            //There's a race condition, sometimes an avatar instantiated event will happen before a player join event.
            //If the player hasn't been added to the idToEntryTable yet, we'll add the information to a backlog to call when the player has been added.
            string playerid = player.field_Private_VRCPlayer_0.prop_Player_0.prop_APIUser_0?.id;
            if (!NameToEntryTable.TryGetValue(player.field_Private_VRCPlayer_0.prop_Player_0.prop_APIUser_0?.id, out PlayerLeftPairEntry entry))
            {
                //Log.WriteMsg("EM: Key not found in dict: " + player.field_Private_VRCPlayer_0.prop_Player_0.prop_APIUser_0?.displayName);
                if (!AvInstBacklog.ContainsKey(playerid))
                    AvInstBacklog.Add(playerid,  new deferredAvInstantiate(player, avatar, gameObject));
                return;
            }
            try
            {
                entry.playerEntry.EntryBase_OnAvatarInstantiated(player, avatar, gameObject);
            }
            catch
            {
                if (!AvInstBacklog.ContainsKey(playerid))
                    AvInstBacklog.Add(playerid, new deferredAvInstantiate(player, avatar, gameObject));
                return;
            }
            ProcessAvatarInstantiateBacklog();
        }

        private static void OnavatarDownloadProgress(AvatarLoadingBar loadingBar, float downloadPercentage, long fileSize)
        {
            foreach (EntryBase entry in playerEntries)
                entry.EntryBase_OnAvatarDownloadProgressed(loadingBar, downloadPercentage, fileSize);
            localPlayerEntry?.EntryBase_OnAvatarDownloadProgressed(loadingBar, downloadPercentage, fileSize);
        }

        
        public static void ProcessAvatarInstantiateBacklog()
        {
            if (AvInstBacklog.Count != 0)
            {
               Log.Write("Addressing Backlog. Size: " + AvInstBacklog.Count.ToString());
                var keys = new string[AvInstBacklog.Count];
                AvInstBacklog.Keys.CopyTo(keys, 0);
                foreach (var key in keys)
                {
                    
                    if (NameToEntryTable.TryGetValue(key, out PlayerLeftPairEntry e))
                    {
                        try
                        {
                            e.playerEntry.EntryBase_OnAvatarInstantiated(AvInstBacklog[key].player, AvInstBacklog[key].avatar, AvInstBacklog[key].gameObject);
                            AvInstBacklog.Remove(key);
                        }
                        catch
                        {
                            //Log.WriteMsg("OAI Failed!");
                            AvInstBacklog[key].numAttempts++;
                        }
                    }
                    else
                    {
                        AvInstBacklog[key].numAttempts++;

                        if (AvInstBacklog[key].numAttempts > 2)
                        {
                           Log.Write("Max attempts exceeded for backlog entry");
                            AvInstBacklog.Remove(key);
                        }
                    }
                }
                //AvInstBacklog.Clear();
            }
        }
        public static void CleanUpHungAOI()
        {
            foreach (PlayerEntry entry in playerEntries)
            {
                if ((entry.perf == PerformanceRating.None) && ((entry.perfString == "100% ") || (entry.perfString == "?¿?¿?")))
                {
                    AvInstBacklog.Add(entry.userId, new deferredAvInstantiate(null, null, null));
                }
                
            }
            ProcessAvatarInstantiateBacklog();

        }

        private static void OnPlayerLeft(Player player)
        {
            

            if (player.prop_APIUser_0 == null)
            {
               Log.Error("Null Player Left!");
                return;
            }
            if (player.prop_APIUser_0.IsSelf)
                return;
            //Log.WriteMsg("OPL: Removing " + player.field_Private_APIUser_0.displayName);
            if (!NameToEntryTable.TryGetValue(player.prop_APIUser_0.id, out PlayerLeftPairEntry entry))
                return;

            entry.Remove();

            RefreshLeftPlayerEntries(0, 0, true);
        }

        public static void AddGeneralInfoEntries()
        {
            Log.Write("Adding List Entries...");

            Log.Debug("Adding PlayerList Header.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<PlayerListHeaderEntry>(PlayerList_Constants.playerListLayout.transform.FindObject("Header").gameObject, includeConfig: true));

            Log.Debug("Adding PlayerList RoomTime.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<RoomTimeEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("RoomTime").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList SystemTime12Hr.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<SystemTime12HrEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("SystemTime12Hr").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList SystemTime24Hr.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<SystemTime24HrEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("SystemTime24Hr").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList GameVersion.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<GameVersionEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("GameVersion").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList CoordinatePosition.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<CoordinatePositionEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("CoordinatePosition").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList WorldName.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<WorldNameEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("WorldName").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList WorldAuthor.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<WorldAuthorEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("WorldAuthor").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList InstanceMaster.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<InstanceMasterEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("InstanceMaster").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList InstanceCreator.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<InstanceCreatorEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("InstanceCreator").gameObject, includeConfig: true));
            Log.Debug("Adding PlayerList WorldInfo.");
            AddGeneralInfoEntry(EntryBase.CreateInstance<WorldInfoEntry>(PlayerList_Constants.generalInfoLayout.transform.FindObject("RiskyFuncAllowed").gameObject, includeConfig: true));
        }
        public static void AddEntry(EntryBase entry)
        {
            if (entry.textComponent != null)
                entry.textComponent.fontSize = PlayerListConfig.fontSize.Value;
            entries.Add(entry);
        }
        public static void AddPlayerLeftPairEntry(PlayerLeftPairEntry entry)
        {
            playerLeftPairsEntries.Add(entry);
            //idToEntryTable.Add(entry.playerEntry.userId, entry);
            if (!entry.playerEntry.isSelf)
                playerEntries.Add(entry.playerEntry);
            AddEntry(entry);
            AddEntry(entry.leftSidePlayerEntry);
            AddEntry(entry.playerEntry);

            entry.playerEntry.gameObject.SetActive(true);
            EntrySortManager.SortPlayer(entry);

            RefreshLeftPlayerEntries(0, 0, true);
        }
        public static void AddGeneralInfoEntry(EntryBase entry)
        {
            AddEntry(entry);
            generalInfoEntries.Add(entry);
        }
        public static void RefreshLeftPlayerEntries(int oldCount, int newCount, bool bypassCount = false)
        {
            // If new digit reached (like 9 - 10)
            if (oldCount.ToString().Length != newCount.ToString().Length || bypassCount)
                foreach (var item in playerLeftPairsEntries)
                    if (item != null)
                    { 
                        item.leftSidePlayerEntry.CalculateLeftPart();
                    }
        }
        public static void RefreshPlayerEntries(bool bypassActive = false)
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0 == null || Player.prop_Player_0 == null || Player.prop_Player_0.gameObject == null || Player.prop_Player_0.prop_VRCPlayerApi_0 == null || (!MenuManager.playerList.active && !bypassActive)) return;
            if (playerEntries == null) return;
            if (playerEntries.Count == 0) return; 
            foreach (PlayerEntry entry in playerEntries)
                PlayerEntry.UpdateEntry(entry.player.prop_PlayerNet_0, entry, bypassActive);
            localPlayerEntry.Refresh();
        }
        public static void RefreshGeneralInfoEntries()
        {
            foreach (EntryBase entry in generalInfoEntries)
                entry.Refresh();
        }
        public static void RefreshAllEntries()
        {            
            // Dont refresh if the local player gameobject has been deleted or if the playerlist is hidden
            if (RoomManager.field_Internal_Static_ApiWorld_0 == null || Player.prop_Player_0 == null || !MenuManager.playerList.active) return;
            
            localPlayerEntry?.Refresh();
            RefreshGeneralInfoEntries();
        }

        public static void SetFontSize(int fontSize)
        {
           // MenuManager.fontSizeLabel.TextComponent.text = $"{fontSize}";
            foreach (EntryBase entry in entries)
                if (entry.textComponent != null)
                    entry.textComponent.fontSize = fontSize;
        }
    }

}
