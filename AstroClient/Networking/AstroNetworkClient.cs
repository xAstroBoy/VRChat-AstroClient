namespace AstroClient
{
	#region Imports

	using AstroClient.Cheetos;
	using AstroClient.Components;
	using AstroLibrary.Console;
	using AstroClient.variables;
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;
	using Newtonsoft.Json;
	using System;
	using System.Diagnostics;
	using System.Net.Sockets;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Timers;
	using UnityEngine;
	using VRC;
	using Timer = System.Timers.Timer;

	#endregion

	internal class AstroNetworkClient
	{
		internal static HandleClient Client;

		private static Timer pingTimer;

		public static void Initialize()
		{
			ModConsole.Log("Client Connecting..");
			Connect();
			SetPingTimer();
		}

		private static void SetPingTimer()
		{
			pingTimer = new Timer(10000);
			pingTimer.Elapsed += OnPingEvent;
			pingTimer.AutoReset = true;
			pingTimer.Enabled = true;
		}

		private static void OnPingEvent(object source, ElapsedEventArgs e)
		{
			Client.Send(new PacketData(PacketClientType.KEEP_ALIVE));
		}

		private static void Connect()
		{
			Client = null;
			TcpClient tcpClient = new TcpClient("client.craig.se", 42069);

			Client = new HandleClient
			{
				IsClient = true // Indicate that this is the client
			};

			Client.Connected += OnConnected;
			Client.Disconnected += OnDisconnect;
			Client.ReceivedPacket += OnPacketReceived;

			Client.StartClient(tcpClient, 0);
		}

		private static void ProcessInput(PacketData packetData)
		{
			if (packetData.NetworkEventID != PacketServerType.KEEP_ALIVE && packetData.NetworkEventID != PacketServerType.AVATAR_RESULT)
			{
				ModConsole.Log($"TCP Event {packetData.NetworkEventID} Received.");
			}

			if (packetData.NetworkEventID == PacketServerType.EXIT)
			{

				Process.GetCurrentProcess().Close();
			}

			if (packetData.NetworkEventID == PacketServerType.CONNECTED)
			{
				Client.Send(new PacketData(PacketClientType.AUTH, KeyManager.AuthKey));
			}

			if (packetData.NetworkEventID == PacketServerType.DISCONNECT)
			{
				Client.Disconnect();
			}

			if (packetData.NetworkEventID == PacketServerType.AUTH_FAIlED)
			{
				ModConsole.Error("Failed to authenticate!");
				Console.Beep();
				Console.ReadLine();
				Process.GetCurrentProcess().Close();
			}

			if (packetData.NetworkEventID == PacketServerType.AUTH_SUCCESS)
			{
				KeyManager.IsAuthed = true;
			}

			if (packetData.NetworkEventID == PacketServerType.ENABLE_DEVELOPER)
			{
				Bools.IsDeveloper = true;
				ModConsole.Log("Developer Mode!");
			}

			if (packetData.NetworkEventID == PacketServerType.ADD_TAG)
			{
				var tagData = JsonConvert.DeserializeObject<TagData>(packetData.TextData);
				Player player;
				if (LocalPlayerUtils.GetSelfPlayer().UserID().Equals(tagData.UserID))
				{
					ModConsole.Log("Wants to add tag to self");
					player = LocalPlayerUtils.GetSelfPlayer();
				}
				else
				{
					ModConsole.Log("Wants to add tag to someone else");
					player = WorldUtils.Get_Player_By_ID(tagData.UserID);
				}
				if (player != null)
				{
					SpawnTag(player, tagData.Text, Color.white, Color.cyan);
				}
				else
				{
					ModConsole.Log($"Player ({tagData.UserID}) returned null");
				}
			}

			if (packetData.NetworkEventID == PacketServerType.NOTIFY)
			{
				CheetosHelpers.SendHudNotification(packetData.TextData);
			}

			if (packetData.NetworkEventID == PacketServerType.DEBUG)
			{
				ModConsole.DebugLog(packetData.TextData);
			}

			if (packetData.NetworkEventID == PacketServerType.LOG)
			{
				ModConsole.Log(packetData.TextData);
			}

			if (packetData.NetworkEventID == PacketServerType.AVATAR_RESULT)
			{
				var avatarData = JsonConvert.DeserializeObject<AvatarData>(packetData.TextData);
				AvatarSearch.AddAvatar(avatarData);
			}

			if (packetData.NetworkEventID == PacketServerType.AVATAR_RESULT_DONE)
			{
				AvatarSearch.Done();
			}
		}

		// You gotta delay it, let's delay it to some seconds
		private static void SpawnTag(Player player, string text, Color TextColor, Color Tagcolor)
		{
			MiscUtility.DelayFunction(1f, () =>
			{
				if (player != null)
				{
					SingleTag tag = SingleTagsUtils.AddSingleTag(player);
					if (tag != null)
					{
						tag.Label_Text = text;
						tag.Label_TextColor = TextColor;
						tag.Tag_Color = Tagcolor;
					}
				}
				else
				{
					ModConsole.Error("Player for setting tag from server was null!");
				}
			});
		}

		private static void OnConnected(object sender, EventArgs e)
		{
			NetworkingManager.SendClientInfo();
			ModConsole.DebugLog("Client Connected.");
			return;
		}

		private static void OnDisconnect(object sender, EventArgs e)
		{
			Task.Run(() =>
			{
				for (; ; )
				{
					ModConsole.DebugError("Lost connection to server, retrying in 5 seconds...");
					Thread.Sleep(5000);
					try { Connect(); break; } catch { }
				}
			});
		}

		private static void OnPacketReceived(object sender, ReceivedPacketEventArgs e)
		{
			ProcessInput(e.Data);
		}
	}
}