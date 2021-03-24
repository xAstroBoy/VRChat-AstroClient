namespace AstroClient.Cheetos
{
    using AstroClient.ConsoleUtils;
    using DayClientML2.Utility.Extensions;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;
    using VRC.SDKBase;
    using VRC.Udon.Wrapper.Modules;

    /// <summary>
    /// This is a temporary name/place for this class and contents.
    /// Everything in it should be moved eventually.
    /// </summary>
    public class CheetoUI : Overridables
    {
        private QMSingleButton showPlayersButton;

        private List<QMSingleButton> playerButtons { get; } = new List<QMSingleButton>();

        private bool showPlayerList = true; // Make this a setting eventually, in case they run Plagues POS

        public override void VRChat_OnUiManagerInit()
        {
            showPlayersButton = new QMSingleButton("ShortcutMenu", -1, 0, "Players", () => { PlayerListToggle(); }, "Show/Hide player list", null, null, true);

            if (showPlayerList)
            {
                showPlayersButton.setTextColor(UnityEngine.Color.green);
            }
            else
            {
                showPlayersButton.setTextColor(UnityEngine.Color.red);
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

            float yPos_start = 0.5f;
            float yPos_max = 3f;
            float yPos = yPos_start;
            float xPos = -1f;

            ResetButtons();
            foreach (var player in temp_list)
            {
                //ModConsole.DebugLog($"Player Button Created {player.DisplayName()}, {xPos}, {yPos}");
                var playerAPI = player.GetVRCPlayerApi();

                var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, player.DisplayName(), () => { SelectPlayer(player); }, $"Select {player.DisplayName()}", null, null, true);

                if (player.GetIsMaster())
                {
                    playerButton.setTextColor(UnityEngine.Color.blue);
                }

                var rank = player.GetAPIUser().GetRankEnum();

                if (rank == PlayerExtensions.RankType.Moderator || rank == PlayerExtensions.RankType.Admin)
                {
                    ModConsole.Warning($"WARNING: There's a moderator or admin in your lobby! {player.DisplayName()}");
                    playerButton.setTextColor(UnityEngine.Color.yellow);
                    playerButton.setBackgroundColor(UnityEngine.Color.yellow);
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
                showPlayersButton.setTextColor(UnityEngine.Color.green);
            } else
            {
                showPlayersButton.setTextColor(UnityEngine.Color.red);
            }

            foreach (var playerButton in playerButtons)
            {
                playerButton.setActive(showPlayerList);
            }
        }
    }
}
