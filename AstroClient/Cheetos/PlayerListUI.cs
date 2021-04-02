namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Management.Instrumentation;
    using UnityEngine;
    using VRC;

    public class PlayerListUI : Overridables
    {
        public static PlayerListUI Instance { get; private set; }

        public bool showPlayerList { get; set; } = true;

        public bool showPlayersButton { get; set; } = true;

        private QMSingleButton playersButton;

        private Dictionary<string, QMSingleButton> playerButtons { get; } = new Dictionary<string, QMSingleButton>();

        private readonly Color InstanceMasterColor = Color.cyan; // Light Blue

        public static void Initialize()
        {
            if (Instance == null)
            {
                Instance = new PlayerListUI();
            }

            Instance.playersButton = new QMSingleButton("ShortcutMenu", -2, -1f, "Players", () => { Instance.PlayerListToggle(); }, "Show/Hide player list", null, null, true);
            Instance.playersButton.setActive(Instance.showPlayersButton);

            if (Instance.showPlayerList)
            {
                Instance.playersButton.setTextColor(UnityEngine.Color.green);
            }
            else
            {
                Instance.playersButton.setTextColor(UnityEngine.Color.red);
            }
        }

        public override void OnWorldReveal()
        {
            InitializeButtons();
        }

        /// <summary>
        /// Stop doing this, add to the list rather than refresh all of it -- Cheetos
        /// </summary>
        /// <param name="player"></param>
        public override void OnPlayerJoined(Player player)
        {
            InitializeButtons();
        }

        /// <summary>
        /// Stop doing this, remove from the list rather than refresh all of it -- Cheetos
        /// </summary>
        /// <param name="player"></param>
        public override void OnPlayerLeft(Player player)
        {
            InitializeButtons();
        }

        private void AddButton(Player player)
        {

        }

        private void RemoveButton(Player player)
        {

        }

        private void LobbyOwnerCheck()
        {

        }

        private void InitializeButtons()
        {
            var players = WorldUtils.GetAllPlayers0();
            var temp_list = new List<Player>();

            foreach (var player in players)
            {
                if (player.GetIsMaster())
                {
                    temp_list.Insert(0, player);
                } else
                {
                    temp_list.Add(player);
                }
            }

            float yPos_start = -0.5f;
            float yPos_max = 5f;
            float yPos = yPos_start;
            float xPos = -2f;

            ResetButtons();
            foreach (var player in temp_list)
            {
                var playerAPI = player.GetVRCPlayerApi();
                var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, player.DisplayName(), () => { SelectPlayer(player); }, $"Select {player.DisplayName()}", null, null, true);

                if (player.GetIsMaster())
                {
                    playerButton.setTextColor(InstanceMasterColor);
                }

                var rank = player.GetAPIUser().GetRankEnum();

                if (rank != null)
                {
                    if (rank == PlayerExtensions.RankType.Moderator || rank == PlayerExtensions.RankType.Admin)
                    {
                        var uiManager = VRCUiManager.prop_VRCUiManager_0;
                        PopupManager.QueHudMessage(uiManager, $"Warning {player.DisplayName()} is an admin/moderator!");

                        playerButton.setTextColor(UnityEngine.Color.yellow);
                        playerButton.setBackgroundColor(UnityEngine.Color.yellow);
                    }
                }

                playerButton.setActive(showPlayerList);
                playerButtons.Add(player.UserID(), playerButton);

                yPos += 0.5f;
                if (yPos >= yPos_max)
                {
                    yPos = yPos_start;
                    xPos -= 1f;
                }
            }
        }

        private void ResetButtons()
        {
            foreach(var keyValuePair in playerButtons)
            {
                keyValuePair.Value.DestroyMe();
            }
            playerButtons.Clear();
        }

        private void SelectPlayer(Player player)
        {
            QuickMenuStuff.GetQuickMenuInstance().SelectPlayer(player.GetVRCPlayer());
        }

        private void PlayerListToggle()
        {
            showPlayerList = !showPlayerList;
            if (showPlayerList)
            {
                playersButton.setTextColor(UnityEngine.Color.green);
            }
            else
            {
                playersButton.setTextColor(UnityEngine.Color.red);
            }

            foreach (var keyValuePair in playerButtons)
            {
                keyValuePair.Value.setActive(showPlayerList);
            }
        }

        public static void ShowPlayerList()
        {
            Instance.showPlayersButton = true;
            Instance.playersButton.setTextColor(UnityEngine.Color.red);

            Instance.playersButton.setActive(true);

            foreach (var keyValuePair in Instance.playerButtons)
            {
                keyValuePair.Value.setActive(true);
            }
        }

        public static void HidePlayerList()
        {
            Instance.showPlayersButton = false;
            Instance.playersButton.setTextColor(UnityEngine.Color.red);

            Instance.playersButton.setActive(false);

            foreach (var keyValuePair in Instance.playerButtons)
            {
                keyValuePair.Value.setActive(false);
            }

            Instance.Save();
        }
    }
}
