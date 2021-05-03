namespace AstroClient
{
	using AstroClient.ConsoleUtils;
	using AstroClient.variables;
	using Photon.Pun;
	using RubyButtonAPI;
	using System.Diagnostics;
	using System.IO;
	using UnityEngine;

	/// <summary>
	/// Cheeto's temporary UI for new/wip features
	/// </summary>
	public class CheetosUI : GameEvents
	{
		public QMNestedButton MainButton { get; private set; }

		public QMScrollMenu MainScroller { get; private set; }

		public QMSingleButton CloseButton { get; private set; }

		public QMSingleButton RestartButton { get; private set; }

		public QMSingleButton DisconectButton { get; private set; }

		public QMSingleButton ReconnectButton { get; private set; }

		public override void VRChat_OnUiManagerInit()
		{
			MainButton = new QMNestedButton("ShortcutMenu", 5, 3, "Admin Menu", "AstroClient's Admin Menu", null, null, null, null, true);
			MainScroller = new QMScrollMenu(MainButton);
			CloseButton = new QMSingleButton(MainButton, 0, 0, "Close Game", () => { Process.GetCurrentProcess().Kill(); }, "Close the game");
			RestartButton = new QMSingleButton(MainButton, 0, 1, "Restart Game", () =>
			{
				Process.Start(Directory.GetParent(Application.dataPath) + "\\VRChat.exe");
				Process.GetCurrentProcess().Kill();
			}, "Restart the game");
			DisconectButton = new QMSingleButton(MainButton, 1, 0, "Disconnect", () => { AstroNetworkClient.Client.Disconnect(false); }, "Disconnect");
			ReconnectButton = new QMSingleButton(MainButton, 1, 1, "Reconnect", () => { AstroNetworkClient.Client.Disconnect(true); }, "Reconnect");
			ReconnectButton = new QMSingleButton(MainButton, 3, 2, "Photon", () => { PrintPhotonPlayers(); }, "Photon");

			if (!Bools.IsDeveloper)
			{
				MainButton.getMainButton().setActive(false);
			}
		}

		public void PrintPhotonPlayers()
		{
			//var room = PhotonNetwork.field_Private_Static_Room_0;

			//if (room == null)
			//{
			//	ModConsole.Log("Room was null");
			//	return;
			//}

			//var players = room.prop_Dictionary_2_Int32_Player_0;

			//if (players == null)
			//{
			//	ModConsole.Log("Players was null");
			//	return;
			//}

			//foreach (var player in players)
			//{
			//	ModConsole.Log($"Key: {player.Key}");
			//	//ModConsole.Log($"Value: {player.Value}");
			//}
		}

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
		}
	}
}