namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using RubyButtonAPI;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC;

    public class PlayerListUIData : SaveData
    {
        public bool showPlayerList = true;
        public bool showPlayersButton = true;
    }

    public class PlayerListUI : Overridables
    {
        public PlayerListUIData saveData = new PlayerListUIData();

        private QMSingleButton playersButton;

        private List<QMSingleButton> playerButtons { get; } = new List<QMSingleButton>();

        private readonly Color InstanceMasterColor = Color.cyan; // Light Blue

        public override void VRChat_OnUiManagerInit()
        {
            playersButton = new QMSingleButton("ShortcutMenu", -2, -1f, "Players", () => { PlayerListToggle(); }, "Show/Hide player list", null, null, true);
            playersButton.setActive(saveData.showPlayersButton);

            if (saveData.showPlayerList)
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
            PopulateButtons();
        }

        /// <summary>
        /// Stop doing this, add to the list rather than refresh all of it -- Cheetos
        /// </summary>
        /// <param name="player"></param>
        public override void OnPlayerJoined(Player player)
        {
            PopulateButtons();
        }

        /// <summary>
        /// Stop doing this, remove from the list rather than refresh all of it -- Cheetos
        /// </summary>
        /// <param name="player"></param>
        public override void OnPlayerLeft(Player player)
        {
            PopulateButtons();
        }

        private void PopulateButtons()
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
                        // Stop printing to the console, it's not useful, use Days code to display a notification somehow.
                        // However this needs to be done after the button refresh fix -- Cheetos
                        ModConsole.Warning($"WARNING: There's a moderator or admin in your lobby! {player.DisplayName()}");
                        playerButton.setTextColor(UnityEngine.Color.yellow);
                        playerButton.setBackgroundColor(UnityEngine.Color.yellow);
                    }
                }

                playerButton.setActive(saveData.showPlayerList);
                playerButtons.Add(playerButton);

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
            foreach(var button in playerButtons)
            {
                button.DestroyMe();
            }
            playerButtons.Clear();
        }

        private void SelectPlayer(Player player)
        {
            QuickMenuStuff.GetQuickMenuInstance().SelectPlayer(player.GetVRCPlayer());
        }

        private void PlayerListToggle()
        {
            saveData.showPlayerList = !saveData.showPlayerList;
            if (saveData.showPlayerList)
            {
                playersButton.setTextColor(UnityEngine.Color.green);
            } else
            {
                playersButton.setTextColor(UnityEngine.Color.red);
            }

            foreach (var playerButton in playerButtons)
            {
                playerButton.setActive(saveData.showPlayerList);
            }

            saveData.Save();
        }
    }
}
