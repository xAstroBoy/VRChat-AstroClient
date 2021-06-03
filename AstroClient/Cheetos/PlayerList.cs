namespace AstroClient
{
	using AstroLibrary.Console;
	#region Imports

	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using UnityEngine;
	using VRC;

	#endregion

	public partial class PlayerList : GameEvents
	{
		private static QMSingleButton playersButton;

		public static Dictionary<string, QMSingleButton> PlayerButtons { get; } = new Dictionary<string, QMSingleButton>();

		private static readonly Color InstanceMasterColor = Color.cyan;

		private static readonly Color FriendColor = Color.green;

		private static readonly Color ModeratorColor = Color.yellow;

		private static readonly Color SelfColor = Color.magenta;

		public override void VRChat_OnUiManagerInit()
		{
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
		}

		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			MiscUtility.DelayFunction(2f, () => { RefreshButtons(); });
		}

		public override void OnPhotonJoined(Photon.Realtime.Player player)
		{

			MiscUtility.DelayFunction(2f, () => { RefreshButtons(); });
		}

		public override void OnPhotonLeft(Photon.Realtime.Player player)
		{
			RefreshButtons();
		}

		private void RefreshButtons()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			var photonPlayers = Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0;
			var players = new List<PlayerListData>();

			Stopwatch stopwatch3 = new Stopwatch();
			stopwatch3.Start();

			foreach (var player in photonPlayers)
			{
				players.Add(new PlayerListData(player.value));
			}

			stopwatch3.Stop();

			float yPos_start = -0.5f;
			float yPos_max = 5f;
			float yPos = yPos_start;
			float xPos = -1f + ConfigManager.UI.PlayerListOffset;

			ResetButtons();

			Stopwatch stopwatch4 = new Stopwatch();
			stopwatch4.Start();

			var temp_list = players.OrderBy(p => p.IsMaster).ThenBy(p => p.IsSelf).ThenBy(p => p.IsFriend).ThenBy(p => p.RankType).Reverse().ToArray();

			stopwatch4.Stop();

			Stopwatch stopwatch2 = new Stopwatch();
			stopwatch2.Start();

			for (int i = 0; i < temp_list.Length; i++)
			{
				var player = temp_list[i];
				var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, $"{player.Prefix}{player.Name}", () => { if (player.Player != null) { SelectPlayer(player.Player); } }, "", player.Color, player.Color, true);
				playerButton.SetResizeTextForBestFit(true);

				playerButton.SetActive(ConfigManager.UI.ShowPlayersList);
				if (ConfigManager.UI.ShowPlayersMenu != true)
				{
					playerButton.SetActive(false);
				}
				PlayerButtons.Add(player.UserID, playerButton);

				yPos += 0.5f;
				if (yPos >= yPos_max)
				{
					yPos = yPos_start;
					xPos -= 1f;
				}
			}

			stopwatch2.Stop();
			stopwatch.Stop();

			ModConsole.Log($"PlayerList Temp List Created: {stopwatch3.ElapsedMilliseconds}ms");
			ModConsole.Log($"PlayerList Temp List Ordered: {stopwatch4.ElapsedMilliseconds}ms");
			ModConsole.Log($"PlayerList Buttons Created: {stopwatch2.ElapsedMilliseconds}ms");
			ModConsole.Log($"PlayerList Refreshed: {stopwatch.ElapsedMilliseconds}ms");
		}

		private void ResetButtons()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.DestroyMe();
			}
			PlayerButtons.Clear();

			stopwatch.Stop();
			ModConsole.Log($"PlayerList ResetButtons: {stopwatch.ElapsedMilliseconds}ms");
		}

		private void SelectPlayer(Player player)
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

			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.SetActive(ConfigManager.UI.ShowPlayersList);
			}
		}

		public static void ShowPlayerMenu()
		{
			ConfigManager.UI.ShowPlayersMenu = true;
			playersButton.SetTextColor(Color.green);

			playersButton.SetActive(true);

			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.SetActive(true);
			}
		}

		public static void HidePlayerMenu()
		{
			ConfigManager.UI.ShowPlayersMenu = false;
			playersButton.SetTextColor(Color.red);

			playersButton.SetActive(false);

			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.SetActive(false);
			}
		}
	}
}