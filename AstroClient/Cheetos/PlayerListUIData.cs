namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using VRC.Udon.Wrapper.Modules;

    public class PlayerListUIData : SaveData
    {
        public bool showPlayerList = true;
        public bool showPlayersButton = true;
    }

    /// <summary>
    /// This is a temporary name/place for this class and contents.
    /// Everything in it should be moved eventually.
    /// </summary>
    public class PlayerListUI : Overridables
    {
        private QMSingleButton playersButton;

        private List<QMSingleButton> playerButtons { get; } = new List<QMSingleButton>();

        private bool showPlayerList = true;

        private bool showPlayersButton = true; // Make this a setting eventually, in case they run Plagues POS

        private readonly Color InstanceMasterColor = Color.cyan; // Light Blue

        public override void VRChat_OnUiManagerInit()
        {
            playersButton = new QMSingleButton("ShortcutMenu", -2, -1f, "Players", () => { PlayerListToggle(); }, "Show/Hide player list", null, null, true);
            playersButton.setActive(showPlayersButton);

            if (showPlayerList)
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

        public override void OnPlayerJoined(Player player)
        {
            PopulateButtons();
        }

        public override void OnPlayerLeft(Player player)
        {
            PopulateButtons();
        }

        private void PopulateButtons()
        {
            // If there's a better way to fetch all of the players, lemme know lol
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
                        ModConsole.Warning($"WARNING: There's a moderator or admin in your lobby! {player.DisplayName()}");
                        playerButton.setTextColor(UnityEngine.Color.yellow);
                        playerButton.setBackgroundColor(UnityEngine.Color.yellow);
                    }
                }

                playerButton.setActive(showPlayerList);
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
            showPlayerList = !showPlayerList;
            if (showPlayerList)
            {
                playersButton.setTextColor(UnityEngine.Color.green);
            } else
            {
                playersButton.setTextColor(UnityEngine.Color.red);
            }

            foreach (var playerButton in playerButtons)
            {
                playerButton.setActive(showPlayerList);
            }
        }

        public void SetPlayerButtonActive(bool b)
        {
            showPlayersButton = b;
            playersButton.setActive(b);
        }
    }
}
