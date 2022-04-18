﻿namespace AstroClient.PlayerList
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
        public static Dictionary<string, PlayerLeftPairEntry> idToEntryTable = new Dictionary<string, PlayerLeftPairEntry>();
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

        public static void Init()
        {
            PlayerListConfig.fontSize.OnValueChanged += (oldValue, newValue) => SetFontSize(newValue);
            PlayerListConfig.OnConfigChanged += OnConfigChanged;
            MelonCoroutines.Start(EntryRefreshEnumerator());
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
                    Log.Exception(ex);
                }

                yield return null;
            }
        }
        internal override void OnUpdate()
        {
            RefreshAllEntries();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            for (int i = playerEntries.Count - 1; i >= 0; i--)
                playerEntries[i].playerLeftPairEntry.Remove();
        }


        internal override void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            RefreshLeftPlayerEntries(0, 0, true);
        }

        public static void OnConfigChanged()
        {
            for (int i = 0; i < entries.Count; i++)
            {
                entries[i].OnConfigChanged();
            }
        }
        public static void CleanUpHungAOI()
        {
            foreach (PlayerEntry entry in playerEntries)
            {
                if ((entry.perf == AvatarPerformanceRating.None) && ((entry.perfString == "100% ") || (entry.perfString == "?¿?¿?")))
                {
                    AvInstBacklog.Add(entry.userId, new deferredAvInstantiate(null, null, null));
                }

            }
        }


        internal override void OnPlayerJoined(Player player)
        {
            if (player.name.Contains("Local") && player.prop_APIUser_0 == null)
                player.prop_APIUser_0 = APIUser.CurrentUser;

            if (idToEntryTable.ContainsKey(player.prop_APIUser_0.id))
                return; // If already in list

            if (player.name.Contains("Local"))
            {
                if (localPlayerEntry != null)
                    return;

                GameObject template = Object.Instantiate(PlayerList_Constants.playerListLayout.transform.Find("Template").gameObject, PlayerList_Constants.playerListLayout.transform);
                template.SetActive(true);

                LeftSidePlayerEntry leftSidePlayerEntry = EntryBase.CreateInstance<LeftSidePlayerEntry>(template.transform.Find("LeftPart").gameObject);
                EntryBase.CreateInstance<LocalPlayerEntry>(template.transform.Find("RightPart").gameObject);
                AddPlayerLeftPairEntry(EntryBase.CreateInstance<PlayerLeftPairEntry>(template, new object[] { leftSidePlayerEntry, localPlayerEntry }));
            }
            else
            {
                GameObject template = Object.Instantiate(PlayerList_Constants.playerListLayout.transform.Find("Template").gameObject, PlayerList_Constants.playerListLayout.transform);
                template.SetActive(true);

                LeftSidePlayerEntry leftSidePlayerEntry = EntryBase.CreateInstance<LeftSidePlayerEntry>(template.transform.Find("LeftPart").gameObject);
                PlayerEntry playerEntry = EntryBase.CreateInstance<PlayerEntry>(template.transform.Find("RightPart").gameObject, new object[] { player });
                AddPlayerLeftPairEntry(EntryBase.CreateInstance<PlayerLeftPairEntry>(template, new object[] { leftSidePlayerEntry, playerEntry }));
            }
            //ProcessAvatarInstantiateBacklog();
        }




        internal override void OnPlayerLeft(Player player)
        {
            if (player.prop_APIUser_0 == null)
            {
                Log.Error("Null Player Left!");
                return;
            }
            if (player.prop_APIUser_0.IsSelf)
                return;
            //Log.Debug("OPL: Removing " + player.field_Private_APIUser_0.displayName);
            if (!idToEntryTable.TryGetValue(player.prop_APIUser_0.id, out PlayerLeftPairEntry entry))
                return;

            entry.Remove();

            RefreshLeftPlayerEntries(0, 0, true);
        }


        internal override void VRChat_OnUiManagerInit()
        {
            InitiateMenuEntries();
        }

        internal static void InitiateMenuEntries()
        {
            try
            {
            Log.Debug("Adding List Entries...");
            AddGeneralInfoEntry(EntryBase.CreateInstance<PlayerListHeaderEntry>(PlayerList_Constants.playerListLayout.transform.Find("Header").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<RoomTimeEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("RoomTime").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<SystemTime12HrEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("SystemTime12Hr").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<SystemTime24HrEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("SystemTime24Hr").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<GameVersionEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("GameVersion").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<CoordinatePositionEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("CoordinatePosition").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<WorldNameEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("WorldName").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<WorldAuthorEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("WorldAuthor").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<InstanceMasterEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("InstanceMaster").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<InstanceCreatorEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("InstanceCreator").gameObject, includeConfig: true));
            AddGeneralInfoEntry(EntryBase.CreateInstance<RiskyFuncAllowedEntry>(PlayerList_Constants.generalInfoLayout.transform.Find("RiskyFuncAllowed").gameObject, includeConfig: true));
            }
            catch(Exception e)
            {
                Log.Exception(e);
            }
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
            {
                for (int i = 0; i < playerLeftPairsEntries.Count; i++)
                {
                    PlayerLeftPairEntry playerLeftPairEntry = playerLeftPairsEntries[i];
                    playerLeftPairEntry.leftSidePlayerEntry.CalculateLeftPart();
                }
            }
        }

        public static void RefreshPlayerEntries(bool bypassActive = false)
        {
            if (RoomManager.field_Internal_Static_ApiWorld_0 == null || Player.prop_Player_0 == null || Player.prop_Player_0.gameObject == null || Player.prop_Player_0.prop_VRCPlayerApi_0 == null || (!MenuManager.playerList.active && !bypassActive)) return;

            for (int i = 0; i < playerEntries.Count; i++)
            {
                PlayerEntry entry = playerEntries[i];
                PlayerEntry.UpdateEntry(entry.player.prop_PlayerNet_0, entry, bypassActive);
            }

            localPlayerEntry.Refresh();
        }

        public static void RefreshGeneralInfoEntries()
        {
            for (int i = 0; i < generalInfoEntries.Count; i++)
            {
                generalInfoEntries[i].Refresh();
            }
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
            for (int i = 0; i < entries.Count; i++)
            {
                EntryBase entry = entries[i];
                if (entry.textComponent != null)
                    entry.textComponent.fontSize = fontSize;
            }
        }
    }
}
