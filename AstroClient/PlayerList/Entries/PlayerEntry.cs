﻿using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Tools.ObjectEditor.Online;
using AstroClient.xAstroBoy.Utility;
using Photon.Pun;
using VRC.SDKBase;
using VRC.SDKBase.Validation.Performance;

namespace AstroClient.PlayerList.Entries
{
    using Cheetos;
    using ClientAttributes;
    using Config;
    using HarmonyLib;
    using Il2CppSystem.Collections;
    using MelonLoader;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using Utilities;
    using VRC.Core;
    using Player = VRC.Player;

    [RegisterComponent]
    public class PlayerEntry : EntryBase
    {
        public PlayerEntry(IntPtr obj0) : base(obj0)
        {
        }

        // - <color={pingcolor}>{ping}ms</color> | <color={fpscolor}>{fps}</color> | {platform} | <color={perfcolor}>{perf}</color> | {relationship} | <color={rankcolor}>{displayname}</color>
        [HideFromIl2Cpp]
        public override string Name => "Player";

        public bool isSelf = false;

        public PlayerLeftPairEntry playerLeftPairEntry;

        public Player player;
        public APIUser apiUser;
        public string userId;

        // public PlayerNet playerNet;
        protected string platform;

        public static string separator = " | ";

        private static bool spoofFriend;
        protected static int highestPhotonIdLength = 0;

        public VRC.SDKBase.Validation.Performance.PerformanceRating perf;
        public string perfString;
        public string jeffString;
        public int ping;
        public int fps;
        public float distance;
        public bool isFriend;
        public string playerColor;
        public int partyFouls = 0;

        private static AstroPatch isFriendWithPatch;
        
        public readonly Stopwatch timeSinceLastUpdate = Stopwatch.StartNew();

        public delegate void UpdateEntryDelegate(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString);

        public static UpdateEntryDelegate updateDelegate { get; set; }
        private static bool _HasSubscribedGeneralEvents = false;

        private static bool HasSubscribedGeneralEvents
        {
            [HideFromIl2Cpp]
            get => _HasSubscribedGeneralEvents;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribedGeneralEvents != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnSetupFlagsReceived += OnSetupFlagsReceived;
                        ClientEventActions.OnQuickMenuOpen += OnQuickMenuOpen;
                        ClientEventActions.OnFriended += OnFriended;
                        ClientEventActions.OnUnfriended += OnUnfriended;
                    }
                    else
                    {
                        ClientEventActions.OnSetupFlagsReceived -= OnSetupFlagsReceived;
                        ClientEventActions.OnQuickMenuOpen -= OnQuickMenuOpen;
                        ClientEventActions.OnFriended -= OnFriended;
                        ClientEventActions.OnUnfriended -= OnUnfriended;
                    }
                }
                _HasSubscribedGeneralEvents = value;
            }
        }
    

        public static void EntryInit()
        {
            ConfigEventActions.OnPlayerListConfigChanged += OnStaticConfigChanged;
            HasSubscribedGeneralEvents = true;
            if (isFriendWithPatch == null)
            {
                isFriendWithPatch = new AstroPatch(typeof(APIUser).GetMethod(nameof(APIUser.IsFriendsWith)), new HarmonyMethod(typeof(PlayerEntry).GetMethod(nameof(OnIsFriend), BindingFlags.NonPublic | BindingFlags.Static)));
            }
        }

        internal static void OnStaticConfigChanged()
        {
            updateDelegate = null;
            if (PlayerListConfig.pingToggle.Value)
                updateDelegate += AddPing;
            if (PlayerListConfig.fpsToggle.Value)
                updateDelegate += AddFps;
            if (PlayerListConfig.platformToggle.Value)
                updateDelegate += AddPlatform;
            if (PlayerListConfig.perfToggle.Value)
                updateDelegate += AddPerf;
            if (PlayerListConfig.jeffToggle.Value)
                updateDelegate += AddJeff;
            if (PlayerListConfig.distanceToggle.Value)
                updateDelegate += AddDistance;
            if (PlayerListConfig.photonIdToggle.Value)
                updateDelegate += AddPhotonId;
            if (PlayerListConfig.ownedObjectsToggle.Value)
            {
                updateDelegate += AddOwnedObjects;
            }
            if (PlayerListConfig.displayNameToggle.Value)
                updateDelegate += AddDisplayName;
            if (PlayerListConfig.distanceToggle.Value && EntrySortManager.IsSortTypeInUse(EntrySortManager.SortType.Distance) || PlayerListConfig.pingToggle.Value && EntrySortManager.IsSortTypeInUse(EntrySortManager.SortType.Ping))
                updateDelegate += (PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString) => EntrySortManager.SortPlayer(entry.playerLeftPairEntry);

            if (PlayerListConfig.condensedText.Value)
                separator = "|";
            else
                separator = " | ";

            EntryManager.RefreshPlayerEntries();
        }
        private static void OnQuickMenuOpen()
        {
            foreach (var item in EntryManager.playerLeftPairsEntries)
            {
                if (item != null)
                {
                    item.playerEntry.GetPlayerColor(false);
                }
            }
            EntrySortManager.SortAllPlayers();
            EntryManager.RefreshPlayerEntries();
        }

        [HideFromIl2Cpp]
        public override void Init(object[] parameters)
        {
            player = (Player)parameters[0];
            apiUser = player.prop_APIUser_0;
            userId = apiUser.id;

            platform = platform = PlayerUtils.GetPlatform(player).PadRight(2);
            perf = VRC.SDKBase.Validation.Performance.PerformanceRating.None;
            perfString = "<color=#" + PlayerUtils.GetPerformanceColor(perf) + ">" + PlayerUtils.ParsePerformanceText(perf) + "</color>";
            jeffString = "<color=#FFFF00>Unknown </color>";
            partyFouls = 1;

            gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => apiUser.OpenUserInQuickMenu()));

            isFriend = APIUser.IsFriendsWith(apiUser.id);
            /*GetPlayerColor();
            if (player.prop_PlayerNet_0 != null)
                UpdateEntry(player.prop_PlayerNet_0, this, true);*/
            GetPlayerColor(false);
        }



        
        public override void EntryBase_OnConfigChanged()
        {
            GetPlayerColor(false);
            if (EntrySortManager.IsSortTypeInUse(EntrySortManager.SortType.Distance))
                EntrySortManager.SortPlayer(playerLeftPairEntry);
        }

        public override void EntryBase_OnAvatarInstantiated(VRCAvatarManager manager, ApiAvatar avatar, GameObject gameObject)
        {
            //This will throw an exception if it's not initialized, so it's handled where called instead.
            //Vector3 bsize = player.prop_VRCPlayer_0.field_Private_VRCAvatarManager_0.prop_AvatarPerformanceStats_0.field_Public_Nullable_1_Bounds_0.GetValueOrDefault().m_Extents;
            //JEFF time
            apiUser = player.prop_APIUser_0;
            userId = apiUser.id;
            /*if (manager.field_Private_VRCPlayer_0.prop_Player_0.prop_APIUser_0?.id != userId)
            {
               Log.Write("PE: OnAvInst: Bailed due to userId mismatch");
                return;
            }*/

            //manager

            perf = (VRC.SDKBase.Validation.Performance.PerformanceRating)player.GetVRCPlayer().GetAvatarManager().prop_AvatarPerformanceStats_0._performanceRatingCache[(int)AvatarPerformanceCategory.Overall];
            List<string> perfdeets = player.prop_VRCPlayer_0.field_Private_VRCAvatarManager_0.prop_AvatarPerformanceStats_0.ToString().Split('\n').ToList();
            int.TryParse(Regex.Match(perfdeets.FirstOrDefault(x => x.Contains("Poly Count")), @"\d+").Value, out int polycount);
            int.TryParse(Regex.Match(perfdeets.FirstOrDefault(x => x.Contains("Skinned Mesh Count")), @"\d+").Value, out int skinnedmeshcount);
            int.TryParse(Regex.Match(perfdeets.LastOrDefault(x => x.Contains("Mesh Count")), @"\d+").Value, out int meshcount);
            int.TryParse(Regex.Match(perfdeets.FirstOrDefault(x => x.Contains("Material Count")), @"\d+").Value, out int matcount);
            GroupCollection boundAxes = Regex.Match(perfdeets.FirstOrDefault(x => x.Contains("Bounds")), @"Extents: \(([\d.]+), ([\d.]+), ([\d.]+)\)").Groups;
            int.TryParse(boundAxes[0].Value, out int boundx);
            int.TryParse(boundAxes[1].Value, out int boundy);
            int.TryParse(boundAxes[2].Value, out int boundz);
            Vector3 bsize = new Vector3(boundx, boundy, boundz);

            partyFouls = 0;
            string failReasons = "";
            if (polycount > PlayerListConfig.polyLimit.Value)
            {
                partyFouls++;
                failReasons += "Py";
            }
            else failReasons += "  ";
            if ((meshcount + skinnedmeshcount) > PlayerListConfig.meshLimit.Value)
            {
                partyFouls++;
                failReasons += "Me";
            }
            else failReasons += "  ";
            if (matcount > PlayerListConfig.matLimit.Value)
            {
                partyFouls++;
                failReasons += "Mt";
            }
            else failReasons += "  ";
            if (bsize.magnitude > PlayerListConfig.boundsMagLimit.Value) //10x10x10 cube.
            {
                partyFouls++;
                failReasons += "Bd";
            }
            else failReasons += "  ";

            perfString = "<color=#" + PlayerUtils.GetPerformanceColor(perf) + ">" + PlayerUtils.ParsePerformanceText(perf) + "</color>";

            //PyMsMtBd
            if (partyFouls == 0) jeffString = "<color=#00FF00>   OK   </color>";
            else
            {
                jeffString = "<color=#FF0000>" + failReasons + "</color>";
                partyFouls++;
            }

            if (player.GetPlayerNet() != null)
                UpdateEntry(player.GetPlayerNet(), this, true);

            if (EntrySortManager.IsSortTypeInUse(EntrySortManager.SortType.AvatarPerf) || EntrySortManager.IsSortTypeInUse(EntrySortManager.SortType.Jeff))
                EntrySortManager.SortPlayer(playerLeftPairEntry);
        }

        [HideFromIl2Cpp]
        public override void EntryBase_OnAvatarDownloadProgressed(AvatarLoadingBar loadingBar, float downloadPercentage, long fileSize)
        {
            if (loadingBar.field_Public_PlayerNameplate_0.field_Private_VRCPlayer_0.prop_Player_0.prop_APIUser_0?.id != userId)
                return;

            perf = VRC.SDKBase.Validation.Performance.PerformanceRating.None;

            if (downloadPercentage < 1)
            {
                perfString = ((downloadPercentage * 100).ToString("N1") + "%").PadRight(5);
                partyFouls = 1;
                if (PlayerListConfig.perfToggle.Value)
                    jeffString = "<color=#888888> Loading</color>";
                else
                {
                    string col = ((int)(downloadPercentage * 100) + 70).ToString("X");
                    col = col + col + col;
                    jeffString = "<color=#" + col + ">  " + ((downloadPercentage * 100).ToString("N1") + "%").PadRight(6) + "</color>";
                }
            }
            else
            {
                perfString = "100% ";
                partyFouls = 1;
                jeffString = "<color=#AAAAAA> Loaded </color>";
            }
        }

        private static void OnSetupFlagsReceived(VRCPlayer vrcPlayer, Hashtable SetupFlagType)
        {
            try
            {
                if (SetupFlagType.ContainsKey("showSocialRank"))
                    EntryManager.NameToEntryTable[vrcPlayer.prop_Player_0.prop_APIUser_0.id].playerEntry.GetPlayerColor();
            }
            catch { }
        }

        public static void UpdateEntry(PlayerNet playerNet, PlayerEntry entry, bool bypassActive = false)
        {
            // bruh atleast some nullchecks?
            if (playerNet == null) return;
            if (entry == null) return;

            entry.timeSinceLastUpdate.Restart();

            // Update values but not text even if playerlist not active and before decode
            entry.distance = (entry.player.transform.position - Player.prop_Player_0.transform.position).magnitude;
            entry.fps = MelonUtils.Clamp((int)(1000f / playerNet.field_Private_Byte_0), -99, 999);
            entry.ping = playerNet.prop_VRCPlayer_0.prop_Int16_0;
            if (!(MenuManager.playerList.active || !bypassActive))
                return;

            StringBuilder tempString = new StringBuilder();

            //
            try
            {
                updateDelegate?.Invoke(playerNet, entry, ref tempString);
            }
            catch (Exception ex)
            {
                Log.Error($"Errored while updating {entry.apiUser.displayName}'s entry:\n{ex}");
            }

            entry.textComponent.text = entry.TrimExtra(tempString.ToString());
        }

        private static bool OnIsFriend(ref bool __result)
        {
            if (spoofFriend)
            {
                __result = false;
                spoofFriend = false;
                return false;
            }
            return true;
        }

        protected static void AddPing(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append("<color=" + PlayerUtils.GetPingColor(entry.ping) + ">");
            if (entry.ping < 9999 && entry.ping > -999)
                tempString.Append(entry.ping.ToString().PadRight(4) + "ms</color>");
            else
                tempString.Append(((double)(entry.ping / 1000)).ToString("N1").PadRight(5) + "s</color>");
            tempString.Append(separator);
        }

        protected static void AddFps(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append("<color=" + PlayerUtils.GetFpsColor(entry.fps) + ">");
            if (entry.fps == 0)
                tempString.Append("?¿?</color>");
            else
                tempString.Append(entry.fps.ToString().PadRight(3) + "</color>");
            tempString.Append(separator);
        }

        private static void AddPlatform(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(entry.platform + separator);
        }

        private static void AddPerf(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(entry.perfString + separator);
        }

        private static void AddJeff(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(entry.jeffString + separator);
        }

        private static void AddDistance(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            if (entry.distance < 100)
            {
                tempString.Append(entry.distance.ToString("N1").PadRight(4) + "m");
            }
            else if (entry.distance < 10000)
            {
                tempString.Append((entry.distance / 1000).ToString("N1").PadRight(3) + "km");
            }
            else if (entry.distance < 999900)
            {
                tempString.Append((entry.distance / 1000).ToString("N0").PadRight(3) + "km");
            }
            else
            {
                tempString.Append((entry.distance / 9.461e+15).ToString("N2").PadRight(3) + "ly"); // If its too large for kilometers ***just convert to light years***
            }
            tempString.Append(separator);
        }

        private static void AddPhotonId(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(playerNet.GetPhotonView().field_Private_Int32_0.ToString().PadRight(highestPhotonIdLength) + separator);
        }

        private static void AddOwnedObjects(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(PlayerList_OwnerCountHelper.GetOwnedObjectCount(entry.apiUser) + separator);
        }

        private static void AddDisplayName(PlayerNet playerNet, PlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append("<color=" + entry.playerColor + ">" + entry.apiUser.displayName + "</color>" + separator);
        }

        private static void OnFriended(APIUser user)
        {
            foreach (PlayerEntry entry in EntryManager.playerEntries)
                if (entry.userId == user.id)
                    entry.isFriend = true;
        }

        private static void OnUnfriended(string userId)
        {
            foreach (PlayerEntry entry in EntryManager.playerEntries)
                if (entry.userId == userId)
                    entry.isFriend = false;
        }

        [HideFromIl2Cpp]
        private void GetPlayerColor(bool shouldSort = true)
        {
            playerColor = "";
            switch (PlayerListConfig.displayNameColorMode.Value)
            {
                case DisplayNameColorMode.TrustAndFriends:
                    playerColor = "#" + ColorUtility.ToHtmlStringRGB(VRCPlayer.Method_Public_Static_Color_APIUser_0(apiUser));
                    break;

                case DisplayNameColorMode.None:
                    break;

                case DisplayNameColorMode.TrustOnly:
                    // ty bono for this (https://github.com/ddakebono/)
                    spoofFriend = true;
                    playerColor = "#" + ColorUtility.ToHtmlStringRGB(VRCPlayer.Method_Public_Static_Color_APIUser_0(apiUser));
                    break;

                case DisplayNameColorMode.FriendsOnly:
                    if (APIUser.IsFriendsWith(apiUser.id))
                        playerColor = "#" + ColorUtility.ToHtmlStringRGB(VRCPlayer.Method_Public_Static_Color_APIUser_0(apiUser));
                    break;
            }
            if (EntrySortManager.IsSortTypeInUse(EntrySortManager.SortType.NameColor) && shouldSort)
                EntrySortManager.SortPlayer(playerLeftPairEntry);
        }

        [HideFromIl2Cpp]
        protected string TrimExtra(string tempString)
        {
            if (tempString.Length > 0)
                if (PlayerListConfig.condensedText.Value)
                    tempString = tempString.Remove(tempString.Length - 1, 1);
                else
                    tempString = tempString.Remove(tempString.Length - 3, 3);

            return tempString;
        }

        public enum DisplayNameColorMode
        {
            TrustAndFriends,
            TrustOnly,
            FriendsOnly,
            None
        }
    }
}