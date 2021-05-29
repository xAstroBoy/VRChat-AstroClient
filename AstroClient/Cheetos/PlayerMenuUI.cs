namespace AstroClient
{
	using AstroClient.Cheetos;
	using AstroLibrary.Console;
	using DayClientML2.Utility;
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

		private bool IsInvisible(Player player)
		{
			var players = WorldUtils.Get_Players();

			foreach (var o in players)
			{
				if (o.UserID().Equals(player.UserID()))
				{
					return false;
				}
			}

			return true;
		}

		private void RefreshButtons()
		{
			var photonPlayers = Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0;
			var players = new List<Player>();

			foreach (var kvp in photonPlayers)
			{
				if (kvp.value.GetPlayer() != null)
				{
					players.Add(kvp.Value.GetPlayer());
				}
			}

			var temp_list = players.OrderBy(p => p.GetIsMaster()).ThenBy(p => p.GetAPIUser().IsSelf).ThenBy(p => p.GetAPIUser().GetIsFriend());

			float yPos_start = -0.5f;
			float yPos_max = 5f;
			float yPos = yPos_start;
			float xPos = -1f + ConfigManager.UI.PlayerListOffset;

			ResetButtons();
			foreach (var player in temp_list.Reverse())
			{
				if (player == null || player.GetVRCPlayerApi() == null)
				{
					ModConsole.Error($"Photon Player Was Null");
					break;
				}

				var prefix = string.Empty;
				var streamer = GameObject.Find("UserInterface/MenuContent/Screens/Settings/ComfortSafetyPanel/StreamerModeToggle").GetComponent<UnityEngine.UI.Toggle>().isOn;

				var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, player.DisplayName(), () => { SelectPlayer(player); }, $"Select {player.DisplayName()}", null, null, true);
				playerButton.SetResizeTextForBestFit(true);

				if (IsInvisible(player))
				{
					prefix += "<color=silver>[INVISIBLE]</color>";
					//playerButton.setButtonText($"[Invis]\n{playerButton.getButtonText()}");
					playerButton.SetBackgroundColor(Color.black);
				}
				else
				{
					var playerAPI = player.GetVRCPlayerApi();
					var rank = player.GetAPIUser().GetRankEnum();
					playerButton.SetBackgroundColor(player.GetAPIUser().GetRankColor());

					if (playerAPI.isMaster)
					{
						if (streamer == true && player.GetAPIUser().IsSelf)
						{
							playerButton.SetButtonText("Vrchat User");
							//playerButton.setTextColor(InstanceMasterColor);
						}
						else
						{
							prefix += "<color=cyan>[IM]</color>";
							//playerButton.setTextColor(InstanceMasterColor);
						}
					}
					else if (player.GetAPIUser().IsSelf)
					{
						if (streamer == true)
						{
							playerButton.SetButtonText("Vrchat User");
							//playerButton.setTextColor(SelfColor);
							//playerButton.setBackgroundColor(SelfColor);
						}
						else
						{
							//playerButton.setTextColor(SelfColor);
							//playerButton.setBackgroundColor(SelfColor);
						}
					}
					else if (player.GetAPIUser().GetIsFriend())
					{
						prefix += "<color=green>[F]</color>";
						//playerButton.setBackgroundColor(FriendColor);
						//playerButton.setTextColor(FriendColor);
					}

					if (player.GetIsInVR())
					{
						prefix += "<color=silver>[VR]</color>";
					}
					else
					{
						prefix += "<color=silver>[PC]</color>";
					}

					if (player.GetVRCPlayer().GetIsDANGER())
					{
						prefix += "<color=red>[DANGER]</color>";
						//playerButton.setTextColor(ModeratorColor);
						//playerButton.setBackgroundColor(ModeratorColor);
					}

					playerButton.SetTextColor(player.GetAPIUser().GetRankColor());
				}

				playerButton.SetActive(ConfigManager.UI.ShowPlayersList);
				if (ConfigManager.UI.ShowPlayersMenu != true)
				{
					playerButton.SetActive(false);
				}

				if (prefix != string.Empty)
				{
					prefix += "\n";
				}

				playerButton.SetButtonText(prefix + player.DisplayName());
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