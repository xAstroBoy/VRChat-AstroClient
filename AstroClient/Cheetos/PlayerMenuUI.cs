namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Management.Instrumentation;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;

    public class PlayerMenuUI : Overridables
    {
        public static string SpoofedName = string.Empty;

        public static bool ShowPlayersMenu = true;

        public static bool ShowPlayersList = true;

        private static QMSingleButton playersButton;

        public static Dictionary<string, QMSingleButton> playerButtons { get; } = new Dictionary<string, QMSingleButton>();

        private static readonly Color InstanceMasterColor = Color.cyan; // Light Blue

        public override void VRChat_OnUiManagerInit()
        {
            playersButton = new QMSingleButton("ShortcutMenu", -2, -1f, "Players", () => { PlayerListToggle(); }, "Show/Hide player list", null, null, true);
            playersButton.setActive(ShowPlayersMenu);

            if (ShowPlayersList)
            {
                playersButton.setTextColor(UnityEngine.Color.green);
            }
            else
            {
                playersButton.setTextColor(UnityEngine.Color.red);
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
            var selfID = LocalPlayerUtils.GetSelfPlayer().UserID();
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

                playerButton.setActive(ShowPlayersList);
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
            ShowPlayersList = !ShowPlayersList;
            if (ShowPlayersList)
            {
                playersButton.setTextColor(UnityEngine.Color.green);
            }
            else
            {
                playersButton.setTextColor(UnityEngine.Color.red);
            }

            foreach (var keyValuePair in playerButtons)
            {
                keyValuePair.Value.setActive(ShowPlayersList);
            }
        }

        public static void ShowPlayerMenu()
        {
            ShowPlayersMenu = true;
            playersButton.setTextColor(UnityEngine.Color.red);

            playersButton.setActive(true);

            foreach (var keyValuePair in playerButtons)
            {
                keyValuePair.Value.setActive(true);
            }
        }

        public static void HidePlayerMenu()
        {
            ShowPlayersMenu = false;
            playersButton.setTextColor(UnityEngine.Color.red);

            playersButton.setActive(false);

            foreach (var keyValuePair in playerButtons)
            {
                keyValuePair.Value.setActive(false);
            }
        }
    }
}
