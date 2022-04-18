﻿using AstroClient.xAstroBoy.Utility;

namespace AstroClient.PlayerList.Entries
{
    using System;
    using System.Text;
    using ClientAttributes;
    using Config;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using Utilities;
    using VRC;
    using VRC.Core;
    using VRC.DataModel;
    using VRCSDK2.Validation.Performance;

    [RegisterComponent]
    public class LocalPlayerEntry : PlayerEntry
    {
        public LocalPlayerEntry(IntPtr obj0) : base(obj0) { }

        // " - <color={pingcolor}>{ping}ms</color> | <color={fpscolor}>{fps}</color> | {platform} | <color={perfcolor}>{perf}</color> | {relationship} | <color={rankcolor}>{displayname}</color>"
        [HideFromIl2Cpp]
        public override string Name => "Local Player";

        public new delegate void UpdateEntryDelegate(Player player, LocalPlayerEntry entry, ref StringBuilder tempString);
        public static new UpdateEntryDelegate updateDelegate;

        [HideFromIl2Cpp]
        public override void Init(object[] parameters)
        {
            isSelf = true;
            EntryManager.localPlayerEntry = this;
            player = Player.prop_Player_0;
            apiUser = player.prop_APIUser_0;
            userId = apiUser.id;

            gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => apiUser.OpenUserInQuickMenu()));

            platform = PlayerUtils.GetPlatform(player).PadRight(2);
            // Join event runs after avatar instantiation event so perf calculations *should* be finished (also not sure if this will throw null refs so gonna release without a check and hope for the best)
            perf = (AvatarPerformanceRating)player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_AvatarPerformanceStats_0.field_Private_ArrayOf_EnumPublicSealedvaNoExGoMePoVe7v0_0[(int)AvatarPerformanceCategory.Overall];
            perfString = "<color=#" + PlayerUtils.GetPerformanceColor(perf) + ">" + PlayerUtils.ParsePerformanceText(perf) + "</color>";


            GetPlayerColor();
            EntryBase_OnConfigChanged();
        }

        internal override void OnPlayerJoined(Player player)
        {
            int highestId = 0;
            foreach (int photonId in PlayerManager.prop_PlayerManager_0.field_Private_Dictionary_2_Int32_Player_0.Keys)
                if (photonId > highestId)
                    highestId = photonId;

            highestPhotonIdLength = highestId.ToString().Length;

        }

        public override void EntryBase_OnConfigChanged()
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
            {
                updateDelegate += AddDisplayName;
            }

            GetPlayerColor();
        }
        [HideFromIl2Cpp]
        protected override void ProcessText(object[] parameters)
        {
            /*
            List<PlayerEntry> playerEntries = PlayerListMod.playerEntries.Values.ToList();
            // Get blocked things
            foreach (ApiPlayerModeration moderation in ModerationManager.prop_ModerationManager_0.field_Private_List_1_ApiPlayerModeration_0)
            {
                if (moderation.moderationType != ApiPlayerModeration.ModerationType.Block) continue;

                foreach (PlayerEntry playerEntry in playerEntries)
                {
                    if (playerEntry.youBlocked) continue;

                    if (playerEntry.player == null)
                    {
                        playerEntry.Remove();
                        continue;
                    }

                    if (playerEntry.userID == moderation.targetUserId)
                    { 
                        playerEntry.youBlocked = true;
                        MelonLoader.Log.Debug($"You have blocked {moderation.targetDisplayName}");
                        break;
                    }
                }
            }
            */
            StringBuilder tempString = new StringBuilder();

            player = Player.prop_Player_0;
            updateDelegate?.Invoke(player, this, ref tempString);

            textComponent.text = TrimExtra(tempString.ToString());
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            ownedObjects = 0;
        }


        private static void AddPing(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            entry.ping = (short)Photon.Pun.PhotonNetwork.field_Public_Static_LoadBalancingClient_0.prop_PhotonPeerPublicPo1PaTyUnique_0.RoundTripTime;  // prop_LoadBalancingPeer_0.RoundTripTime;
            tempString.Append("<color=" + PlayerUtils.GetPingColor(entry.ping) + ">");
            if (entry.ping < 9999 && entry.ping > -999)
                tempString.Append(entry.ping.ToString().PadRight(4) + "ms</color>");
            else
                tempString.Append(((double)(entry.ping / 1000)).ToString("N1").PadRight(5) + "s</color>");
            tempString.Append(separator);
        }
        private static void AddFps(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            if (entry.timeSinceLastUpdate.ElapsedMilliseconds >= 250)
            { 
                entry.fps = Mathf.Clamp((int)(1f / Time.deltaTime), -99, 999); // Clamp between -99 and 999
                entry.timeSinceLastUpdate.Restart();
            }

            tempString.Append("<color=" + PlayerUtils.GetFpsColor(entry.fps) + ">" + entry.fps.ToString().PadRight(3) + "</color>" + separator);
        }
        private static void AddPlatform(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(entry.platform + separator);
        }
        private static void AddPerf(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(entry.perfString + separator);
        }
        private static void AddJeff(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(entry.jeffString + separator);
        }
        private static void AddDistance(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append("0.0 m" + separator);
        }
        private static void AddPhotonId(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(player.prop_VRCPlayer_0.prop_PhotonView_0.field_Private_Int32_0.ToString().PadRight(highestPhotonIdLength) + separator);
        }
        private static void AddOwnedObjects(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append(entry.ownedObjects.ToString().PadRight(highestOwnedObjectsLength) + separator);
        }
        private static void AddOwnedObjectsSafe(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            int num = entry.ownedObjects;
            if (num > (int)(totalObjects * 0.75))
                tempString.Append(entry.ownedObjects.ToString().PadRight(highestOwnedObjectsLength) + separator);
            else
                tempString.Append("0".PadRight(highestOwnedObjectsLength) + separator);
        }
        private static void AddDisplayName(Player player, LocalPlayerEntry entry, ref StringBuilder tempString)
        {
            tempString.Append("<color=" + entry.playerColor + ">" + entry.apiUser.displayName + "</color>" + separator);
        }


        internal override void OnShowSocialRankChanged()
        {
            EntryManager.localPlayerEntry.GetPlayerColor();
        }

        private void GetPlayerColor()
        {
            playerColor = "";
            switch (PlayerListConfig.displayNameColorMode.Value)
            {
                case DisplayNameColorMode.None:
                case DisplayNameColorMode.FriendsOnly:
                    break;
                case DisplayNameColorMode.TrustAndFriends:
                case DisplayNameColorMode.TrustOnly:
                    playerColor = "#" + ColorUtility.ToHtmlStringRGB(VRCPlayer.Method_Public_Static_Color_APIUser_0(APIUser.CurrentUser));
                    break;
            }
            if (EntrySortManager.IsSortTypeInUse(EntrySortManager.SortType.NameColor) && playerLeftPairEntry != null)
                EntrySortManager.SortPlayer(playerLeftPairEntry);
        }
    }
}
