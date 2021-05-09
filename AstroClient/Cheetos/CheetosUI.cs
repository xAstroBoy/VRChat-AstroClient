namespace AstroClient
{
	#region Imports

	using AstroClient.Cheetos;
	using AstroClient.ConsoleUtils;
	using AstroClient.variables;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using MelonLoader;
	using RubyButtonAPI;
	using System;
	using System.Collections;
	using System.Linq;
	using System.Threading;
	using Transmtn.DTO.Notifications;
	using VRC.SDKBase;
	using static VRC.SDKBase.VRC_EventHandler;

	#endregion Imports

	/// <summary>
	/// Cheeto's temporary UI for new/wip features
	/// </summary>
	public class CheetosUI : GameEvents
	{
		public QMNestedButton MainButton { get; private set; }

		public QMScrollMenu MainScroller { get; private set; }

		public override void VRChat_OnUiManagerInit()
		{
			if (Bools.IsDeveloper)
			{
				MainButton = new QMNestedButton("ShortcutMenu", 5, 4, "Cheetos Menu", "AstroClient's Admin Menu", null, null, null, null, true);
				MainScroller = new QMScrollMenu(MainButton);
				new QMSingleButton(MainButton, 1, 0, "Friend Everyone", () => { DoFriendEveryone(); }, "Friend Everyone!");
				new QMSingleButton(MainButton, 1, 1, "Test #2", () => { Test2(); }, "Don't Do It!");
				new QMSingleButton(MainButton, 1, 2, "Test #3", () => { Test3(); }, "Don't Do It!");
				new QMSingleButton(MainButton, 3, 1, "Create Button", () => { CreateButton(); }, ":3");
				new QMSingleButton(MainButton, 3, 2, "Photon", () => { PrintPhotonPlayers(); }, "Photon");
				new QMSingleButton(MainButton, 4, 0, "RPC Test #1", () => { RPCClapTest1(); }, "RPC");
				new QMSingleButton(MainButton, 4, 1, "RPC Test #2", () => { RPCClapTest2(); }, "RPC");
				new QMSingleButton(MainButton, 4, 2, "RPC Test #3", () => { RPCClapTest3(); }, "RPC");
			}
		}

		private void Test3()
		{
		}

		private void Test2()
		{
			MiscFunc.InviteALLFriends();
		}

		private void DoFriendEveryone()
		{
			MelonCoroutines.Start(FriendEveryone());
		}

		private IEnumerator FriendEveryone()
		{
			var players = WorldUtils.GetAllPlayers0();

			int count = 0;
			foreach (var player in players)
			{
				if (!player.GetAPIUser().GetIsFriend() && !player.UserID().Equals(LocalPlayerUtils.GetSelfPlayer().UserID()))
				{
					try
					{
						MiscUtility.DelayFunction(2 * count, () =>
						{
							Notification xx = FriendRequest.Create(player.UserID());
							VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0.prop_Api_0.PostOffice.Send(xx);
							CheetosHelpers.SendHudNotification($"Friend Request Sent: {player.DisplayName()}");
						});
						count++;
					}
					catch (Exception e)
					{
						ModConsole.Error(e.Message);
					}
				}
				yield return null;
			}
			CheetosHelpers.SendHudNotification("Done Sending Friend Requests!");
			yield break;
		}

		private void CreateButton()
		{
			var buttonPosition = LocalPlayerUtils.CenterOfPlayer();
			var buttonRotation = LocalPlayerUtils.GetSelfPlayer().gameObject.transform.rotation;
			ButtonCreator.Create("Test", buttonPosition, buttonRotation, () => { ModConsole.Log("TestButton Clicked"); });
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
			handler.TriggerEvent(new VrcEvent
			{
				EventType = VrcEventType.SendRPC,
				Name = "SendRPC",
				ParameterObject = handler.gameObject,
				ParameterInt = Utils.LocalPlayer.playerId,
				ParameterFloat = 0f,
				ParameterString = "UdonSyncRunProgramAsRPC",
				ParameterBoolOp = VrcBooleanOp.Unused,
				ParameterBytes = Networking.EncodeParameters(new Il2CppSystem.Object[] { msg })
			}, VrcBroadcastType.AlwaysUnbuffered, VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject, 0f);
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
			handler = UnityEngine.Object.FindObjectOfType<VRC_EventHandler>();
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