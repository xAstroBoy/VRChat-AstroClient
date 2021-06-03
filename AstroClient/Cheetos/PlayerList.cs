namespace AstroClient
{
	#region Imports

	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using System.Collections.Generic;
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
			MiscUtility.DelayFunction(2f, () => { RefreshButtons(); });
		}

		private void RefreshButtons()
		{
			var photonPlayers = Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0;
			var players = new List<PlayerListData>();

			foreach (var player in photonPlayers)
			{
				players.Add(new PlayerListData(player.value));
			}
			
			var temp_list = players.OrderBy(p => p.IsMaster).ThenBy(p => p.IsSelf).ThenBy(p => p.IsFriend).ThenBy(p => p.RankType);

			float yPos_start = -0.5f;
			float yPos_max = 5f;
			float yPos = yPos_start;
			float xPos = -1f + ConfigManager.UI.PlayerListOffset;

			ResetButtons();
			foreach (var player in temp_list.Reverse())
			{
				var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, $"{player.Prefix}{player.Name}", () => { if (player.Player != null) { SelectPlayer(player.Player); } }, "", player.Color, player.Color, true);
				playerButton.SetResizeTextForBestFit(true);

				yPos += 0.5f;
				if (yPos >= yPos_max)
				{
					yPos = yPos_start;
					xPos -= 1f;
				}

				playerButton.SetActive(ConfigManager.UI.ShowPlayersList);
				if (ConfigManager.UI.ShowPlayersMenu != true)
				{
					playerButton.SetActive(false);
				}
				PlayerButtons.Add(player.UserID, playerButton);
			}
		}

		private void ResetButtons()
		{
			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.DestroyMe();
			}
			PlayerButtons.Clear();
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