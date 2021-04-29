namespace AstroClient
{
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;

	public class PlayerMenuUI : GameEvents
	{
		private static QMSingleButton playersButton;

		public static Dictionary<string, QMSingleButton> PlayerButtons { get; } = new Dictionary<string, QMSingleButton>();

		private static readonly Color InstanceMasterColor = Color.cyan;

		private static readonly Color FriendColor = Color.green;

		private static readonly Color ModeratorColor = Color.yellow;

		private static readonly Color SelfColor = Color.magenta;

		public override void VRChat_OnUiManagerInit()
		{
			playersButton = new QMSingleButton("ShortcutMenu", -2, -1f, "Players", () => { PlayerListToggle(); }, "Show/Hide player list", null, null, true);
			playersButton.setActive(ConfigManager.UI.ShowPlayersMenu);

			if (ConfigManager.UI.ShowPlayersList)
			{
				playersButton.setTextColor(Color.green);
			}
			else
			{
				playersButton.setTextColor(Color.red);
			}
		}

		public override void OnWorldReveal(string id, string name, string asseturl)
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
			if (AstroNetworkClient.Client != null && AstroNetworkClient.Client.IsConnected)
			{
				AstroNetworkClient.Client.Send($"player-info:{player.UserID()}");
			}
		}

		/// <summary>
		/// Stop doing this, remove from the list rather than refresh all of it -- Cheetos
		/// </summary>
		/// <param name="player"></param>
		public override void OnPlayerLeft(Player player)
		{
			InitializeButtons();
		}

		private void InitializeButtons()
		{
			var players = WorldUtils.GetAllPlayers0();
			var temp_list = players.OrderBy(p => p.GetIsMaster()).ThenBy(p => p.GetAPIUser().IsSelf).ThenBy(p => p.GetAPIUser().isFriend);

			float yPos_start = -0.5f;
			float yPos_max = 5f;
			float yPos = yPos_start;
			float xPos = -2f;

			ResetButtons();
			foreach (var player in temp_list.Reverse())
			{
				var playerAPI = player.GetVRCPlayerApi();
				var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, player.DisplayName(), () => { SelectPlayer(player); }, $"Select {player.DisplayName()}", null, null, true);

				var rank = player.GetAPIUser().GetRankEnum();

				if (player.GetIsMaster())
				{
					playerButton.setTextColor(InstanceMasterColor);
				}
				else if (player.GetAPIUser().IsSelf)
				{
					playerButton.setTextColor(SelfColor);
					playerButton.setBackgroundColor(SelfColor);
				}
				else if (player.GetAPIUser().isFriend)
				{
					playerButton.setBackgroundColor(FriendColor);
					playerButton.setTextColor(FriendColor);
				}

				if (rank != null)
				{
					if (rank == PlayerExtensions.RankType.Moderator || rank == PlayerExtensions.RankType.Admin)
					{
						var uiManager = VRCUiManager.prop_VRCUiManager_0;
						PopupManager.QueHudMessage(uiManager, $"Warning {player.DisplayName()} is an admin/moderator!");

						playerButton.setTextColor(ModeratorColor);
						playerButton.setBackgroundColor(ModeratorColor);
					}
				}

				playerButton.setActive(ConfigManager.UI.ShowPlayersList);
				if (ConfigManager.UI.ShowPlayersMenu != true)
				{
					playerButton.setActive(false);
				}
				PlayerButtons.Add(player.UserID(), playerButton);

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
				playersButton.setTextColor(Color.green);
			}
			else
			{
				playersButton.setTextColor(Color.red);
			}

			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.setActive(ConfigManager.UI.ShowPlayersList);
			}
		}

		public static void ShowPlayerMenu()
		{
			ConfigManager.UI.ShowPlayersMenu = true;
			playersButton.setTextColor(Color.green);

			playersButton.setActive(true);

			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.setActive(true);
			}
		}

		public static void HidePlayerMenu()
		{
			ConfigManager.UI.ShowPlayersMenu = false;
			playersButton.setTextColor(Color.red);

			playersButton.setActive(false);

			foreach (var keyValuePair in PlayerButtons)
			{
				keyValuePair.Value.setActive(false);
			}
		}
	}
}