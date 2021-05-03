namespace AstroClient
{
	using AstroClient.ConsoleUtils;
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
			playersButton = new QMSingleButton("ShortcutMenu", -1 + ConfigManager.UI.PlayerListOffset, -1f, "Players", () => { PlayerListToggle(); }, "Show/Hide player list", null, null, true);
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
			RefreshButtons();
		}

		/// <summary>
		/// Stop doing this, add to the list rather than refresh all of it -- Cheetos
		/// </summary>
		/// <param name="player"></param>
		public override void OnPlayerJoined(Player player)
		{
			RefreshButtons();
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
			RefreshButtons();
		}

		public override void OnPhotonJoined(Photon.Realtime.Player player)
		{
			ModConsole.Log($"[PHOTON] {player.GetDisplayName()} [{player.field_Private_Int32_0}] -> Joined!");
		}

		public override void OnPhotonLeft(Photon.Realtime.Player player)
		{
			ModConsole.Log($"[PHOTON] {player.GetDisplayName()} [{player.field_Private_Int32_0}] -> Left!");
		}

		private bool IsInvisible(Player player)
		{
			var photonPlayers = Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0;

			foreach (var kvp in photonPlayers)
			{
				var players = WorldUtils.GetAllPlayers0();

				if (!players.Contains(kvp.Value.GetPlayer()))
				{
					//CheetosHelpers.SendHudNotification($"Player: {player.DisplayName()} is invisible!");
					return true;
				}
			}
			return false;
		}

		private void RefreshButtons()
		{
			var photonPlayers = Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0;
			var players = new List<Player>();

			foreach (var kvp in photonPlayers)
			{
				players.Add(kvp.Value.GetPlayer());
			}

			var temp_list = players.OrderBy(p => p.GetIsMaster()).ThenBy(p => p.GetAPIUser().IsSelf).ThenBy(p => p.GetAPIUser().isFriend);

			float yPos_start = -0.5f;
			float yPos_max = 5f;
			float yPos = yPos_start;
			float xPos = -1f + ConfigManager.UI.PlayerListOffset;

			ResetButtons();
			foreach (var player in temp_list.Reverse())
			{
				var playerAPI = player.GetVRCPlayerApi();

				if (player == null || playerAPI == null)
				{
					return;
				}
				var streamer = GameObject.Find("UserInterface/MenuContent/Screens/Settings/ComfortSafetyPanel/StreamerModeToggle").GetComponent<UnityEngine.UI.Toggle>().isOn;

				var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, player.DisplayName(), () => { SelectPlayer(player); }, $"Select {player.DisplayName()}", null, null, true);

				var rank = player.GetAPIUser().GetRankEnum();

				if (playerAPI.isMaster)
				{
					if (streamer == true && player.GetAPIUser().IsSelf)
					{
						playerButton.setButtonText("Vrchat User");
						playerButton.setTextColor(InstanceMasterColor);
					}
					else
					{
                        playerButton.setTextColor(InstanceMasterColor);
					}
					}
				else if (player.GetAPIUser().IsSelf)
				{
					if (streamer == true)
					{
						playerButton.setButtonText("Vrchat User");
						playerButton.setTextColor(SelfColor);
						playerButton.setBackgroundColor(SelfColor);
					}
					else
					{
						playerButton.setTextColor(SelfColor);
						playerButton.setBackgroundColor(SelfColor);
					}
				}
				else if (player.GetAPIUser().GetIsFriend())
				{
					playerButton.setBackgroundColor(FriendColor);
					playerButton.setTextColor(FriendColor);
				}

				//if (IsInvisible(player))
				//{
				//	playerButton.setButtonText($"[Invis]\n{playerButton.getButtonText()}");
				//	playerButton.setBackgroundColor(Color.black);
				//}

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