﻿namespace AstroClient
{
	#region Imports

	using AstroClient.Cheetos;
	using Cinemachine;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using MelonLoader;
	using RubyButtonAPI;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using UnityEngine;
	using VRC;

	#endregion

	public partial class PlayerList : GameEvents
	{
		private static QMSingleButton playersButton;

		public static List<QMSingleButton> PlayerButtons { get; } = new List<QMSingleButton>();

		private static readonly Color InstanceMasterColor = Color.cyan;

		private static readonly Color FriendColor = Color.green;

		private static readonly Color ModeratorColor = Color.yellow;

		private static readonly Color SelfColor = Color.magenta;

		private static float RefreshTime;

		private static Mutex refreshMutex;

		public static bool IsReady
		{
			get
			{
				return Utils.LoadBalancingPeer != null && Utils.LoadBalancingPeer.prop_Room_0 != null && Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0 != null;
			}
		}

		public override void VRChat_OnUiManagerInit()
		{
			refreshMutex = new Mutex();
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

		public override void OnLateUpdate()
		{
			if (RefreshTime >= 30f)
			{
				RefreshButtons();
				RefreshTime = 0;
			}
			else
			{
				RefreshTime += 1f * Time.deltaTime;
			}
		}

		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			MiscUtility.DelayFunction(2f, () => { RefreshButtons(); RefreshTime = 0f; });
		}

		public override void OnPhotonJoined(Photon.Realtime.Player player)
		{

			MiscUtility.DelayFunction(2f, () => { RefreshButtons(); RefreshTime = 0f; });
		}

		public override void OnPhotonLeft(Photon.Realtime.Player player)
		{
			RefreshButtons();
			RefreshTime = 0f;
		}

		private void RefreshButtons()
		{
			if (IsReady)
			{
				refreshMutex.WaitOne();
				var players = new List<PlayerListData>();

				foreach (var keyValuePair in Utils.LoadBalancingPeer.prop_Room_0.prop_Dictionary_2_Int32_Player_0)
				{
					players.Add(new PlayerListData(keyValuePair.value));
				}

				ResetButtons();
				var temp_list = players.OrderBy(p => p.IsMaster).ThenBy(p => p.IsSelf).ThenBy(p => p.IsFriend).ThenBy(p => p.GetIsInvisible()).ThenByDescending(p => p.RankType).Reverse().ToArray();

				MelonCoroutines.Start(CreateButtons(temp_list));
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

				yield return null;
			}
			refreshMutex.ReleaseMutex();
			yield break;
		}

		public static void CreateButton(PlayerListData player, float xPos, float yPos)
		{
			var playerButton = new QMSingleButton("ShortcutMenu", xPos, yPos, $"{player.Prefix}{player.Name}", () => { if (player.Player != null) { SelectPlayer(player.Player); } }, "", player.Color, player.Color, true);
			playerButton.SetResizeTextForBestFit(true);

			playerButton.SetActive(ConfigManager.UI.ShowPlayersList);
			if (ConfigManager.UI.ShowPlayersMenu != true)
			{
				playerButton.SetActive(false);
			}
			PlayerButtons.Add(playerButton);
		}

		private void ResetButtons()
		{
			foreach (var button in PlayerButtons)
			{
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

			foreach (var button in PlayerButtons)
			{
				button.SetActive(ConfigManager.UI.ShowPlayersList);
			}
		}

		public static void ShowPlayerMenu()
		{
			ConfigManager.UI.ShowPlayersMenu = true;
			playersButton.SetTextColor(Color.green);

			playersButton.SetActive(true);

			foreach (var button in PlayerButtons)
			{
				button.SetActive(true);
			}
		}

		public static void HidePlayerMenu()
		{
			ConfigManager.UI.ShowPlayersMenu = false;
			playersButton.SetTextColor(Color.red);

			playersButton.SetActive(false);

			foreach (var button in PlayerButtons)
			{
				button.SetActive(false);
			}
		}
	}
}