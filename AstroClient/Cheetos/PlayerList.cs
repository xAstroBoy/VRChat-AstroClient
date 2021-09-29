namespace AstroClient
{
    using AstroLibrary.Console;
    #region Imports

    using AstroLibrary.Utility;
    using MelonLoader;
    using RubyButtonAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using UnityEngine;
    using VRC;

    #endregion Imports

    internal partial class PlayerList : GameEvents
    {
        private static QMSingleButton playersButton;

        private static QMSingleButton refreshButton;

        internal static  List<QMSingleButton> PlayerButtons { get; } = new List<QMSingleButton>();

        private static readonly Color InstanceMasterColor = Color.cyan;

        private static readonly Color FriendColor = Color.green;

        private static readonly Color ModeratorColor = Color.yellow;

        private static readonly Color SelfColor = Color.magenta;

        private static float RefreshTime;

        private static Mutex refreshMutex = new Mutex();

        internal override void VRChat_OnUiManagerInit()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            refreshButton = new QMSingleButton("ShortcutMenu", -1 + ConfigManager.UI.PlayerListOffset, -1.5f, "Refresh", () => { RefreshButtons(); }, "Refresh player list", null, null, true);
            refreshButton.SetActive(ConfigManager.UI.ShowPlayersMenu);

            playersButton = new QMSingleButton("ShortcutMenu", -1 + ConfigManager.UI.PlayerListOffset, -1f, "Players", () => { PlayerListToggle(); }, "Show/Hide player list", null, null, true);
            playersButton.SetActive(ConfigManager.UI.ShowPlayersMenu);

            if (ConfigManager.UI.ShowPlayersList)
            {
                playersButton.SetTextColor(Color.green);
            }
            else
            {
                playersButton.SetTextColor(Color.red);
            }

            stopwatch.Stop();
            Console.WriteLine($"Playerlist Created: {stopwatch.ElapsedMilliseconds}ms");
        }

        internal override void OnLateUpdate()
        {
            //if (ConfigManager.UI.ShowPlayersList && ConfigManager.UI.ShowPlayersMenu)
            //{
            //	if (RefreshTime >= 16f)
            //	{
            //		RefreshButtons();
            //		RefreshTime = 0;
            //	}
            //	else
            //	{
            //		RefreshTime += 1f * Time.deltaTime;
            //	}
            //}
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            //MiscUtility.DelayFunction(2f, () => { RefreshButtons(); RefreshTime = 0f; });
        }

        internal override void OnPhotonJoined(Photon.Realtime.Player player)
        {
            if (player == null) throw new ArgumentNullException();
            //MiscUtility.DelayFunction(2f, () => { RefreshButtons(); RefreshTime = 0f; });
        }

        internal override void OnPhotonLeft(Photon.Realtime.Player player)
        {
            if (player == null) { throw new ArgumentNullException(); }
            //RefreshButtons();
            //RefreshTime = 0f;
        }

        private void RefreshButtons()
        {
            if (WorldUtils.IsInWorld && ConfigManager.UI.ShowPlayersList && ConfigManager.UI.ShowPlayersMenu)
            {
                _ = refreshMutex.WaitOne();
                var players = new List<PlayerListData>();

                foreach (var keyValuePair in Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0)
                {
                    players.Add(new PlayerListData(keyValuePair.value));
                }

                ResetButtons();
                var temp_list = players.OrderBy(p => p.IsMaster).ThenBy(p => p.IsSelf).ThenBy(p => p.IsFriend).ThenBy(p => p.GetIsInvisible()).ThenByDescending(p => p.RankType).Reverse().ToArray();

                _ = MelonCoroutines.Start(CreateButtons(temp_list));
            }
        }

        private IEnumerator CreateButtons(PlayerListData[] players)
        {
            float yPos_start = -0.5f;
            float yPos_max = 5f;
            float yPos = yPos_start;
            float xPos = -1f + ConfigManager.UI.PlayerListOffset;

            for (int i = 0; i < players.Length; i++)
            {
                var player = players[i];
                CreateButton(player, xPos, yPos);

                yPos += 0.5f;
                if (yPos >= yPos_max)
                {
                    yPos = yPos_start;
                    xPos -= 1f;
                }

                yield return new WaitForSeconds(0.001f);
            }
            refreshMutex.ReleaseMutex();
            yield break;
        }

        internal static  void CreateButton(PlayerListData player, float xPos, float yPos)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, $"{player.Prefix}{player.Name}", () => { if (player.Player != null) { SelectPlayer(player.Player); } }, "", player.Color, player.Color, true);
            playerButton.SetResizeTextForBestFit(true);

            playerButton.SetActive(ConfigManager.UI.ShowPlayersList);
            if (!ConfigManager.UI.ShowPlayersMenu)
            {
                playerButton.SetActive(false);
            }
            PlayerButtons.Add(playerButton);

            stopwatch.Stop();
            ModConsole.Log($"Button Created: {player.Name} - {stopwatch.ElapsedMilliseconds}ms");
        }

        private void ResetButtons()
        {
            for (int i = 0; i < PlayerButtons.Count; i++)
            {
                QMSingleButton button = PlayerButtons[i];
                button.DestroyMe();
            }
            PlayerButtons.Clear();
        }

        private static void SelectPlayer(Player player)
        {
            QuickMenuStuff.GetQuickMenuInstance().SelectPlayer(player.GetVRCPlayer());
        }

        private void PlayerListToggle()
        {
            ConfigManager.UI.ShowPlayersList = !ConfigManager.UI.ShowPlayersList;
            if (ConfigManager.UI.ShowPlayersList)
            {
                playersButton.SetTextColor(Color.green);
            }
            else
            {
                playersButton.SetTextColor(Color.red);
            }

            for (int i = 0; i < PlayerButtons.Count; i++)
            {
                QMSingleButton button = PlayerButtons[i];
                button.SetActive(ConfigManager.UI.ShowPlayersList);
            }
        }

        internal static  void ShowPlayerMenu()
        {
            ConfigManager.UI.ShowPlayersMenu = true;
            playersButton.SetTextColor(Color.green);

            refreshButton.SetActive(true);
            playersButton.SetActive(true);

            for (int i = 0; i < PlayerButtons.Count; i++)
            {
                QMSingleButton button = PlayerButtons[i];
                button.SetActive(true);
            }
        }

        internal static  void HidePlayerMenu()
        {
            ConfigManager.UI.ShowPlayersMenu = false;
            playersButton.SetTextColor(Color.red);

            refreshButton.SetActive(false);
            playersButton.SetActive(false);

            for (int i = 0; i < PlayerButtons.Count; i++)
            {
                QMSingleButton button = PlayerButtons[i];
                button.SetActive(false);
            }
        }
    }
}