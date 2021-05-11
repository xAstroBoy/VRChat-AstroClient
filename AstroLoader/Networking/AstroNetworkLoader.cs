namespace AstroLoader
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Net.Sockets;

	// TODO: Make this retreive multiple assemblies and resources
	internal class AstroNetworkLoader
	{
		internal static HandleClient Client;

		internal static List<byte[]> LibraryFiles;
		internal static List<byte[]> MelonFiles;
		internal static List<byte[]> ModuleFiles;

		internal static bool IsReady = false;

		public static void Initialize()
		{
			Console.WriteLine("Loader Connecting..");
			Connect();
		}

		private static void Connect()
		{
			Client = null;
			TcpClient tcpClient = new TcpClient("client.craig.se", 42070);

			Client = new HandleClient
			{
				IsClient = false // Indicate that this is the loader
			};

			Client.Connected += OnConnected;
			Client.Disconnected += OnDisconnect;
			Client.ReceivedPacket += OnPacketReceived;

			Client.StartClient(tcpClient, 0);
		}

		private static void ProcessInput(object sender, PacketData packetData)
		{
			if (packetData.NetworkEventID != PacketServerType.KEEP_ALIVE)
			{
				Console.WriteLine($"TCP Event {packetData.NetworkEventID} Received.");
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
				Console.Beep();
				Console.ReadLine();
				Process.GetCurrentProcess().Close();
			}

			if (packetData.NetworkEventID == PacketServerType.AUTH_SUCCESS)
			{
				KeyManager.IsAuthed = true;
				Client.Send(new PacketData(PacketClientType.GET_RESOURCES));
			}

			if (packetData.NetworkEventID == PacketServerType.LOADER_DONE)
			{
				Client.Disconnect();
				IsReady = true;
			}

			//ModConsole.DebugLog($"Received: {input}");
			//string[] cmds = input.Trim().Split(':');

			//if (cmds[0].Equals("exit"))
			//{
			//	System.Console.Beep();
			//	Environment.Exit(0);
			//}
			//else if (cmds[0].Equals("auth-request", StringComparison.InvariantCultureIgnoreCase))
			//{
			//	Client.Send($"key:{KeyManager.AuthKey}");
			//	//ModConsole.DebugLog("Auth Requested");
			//}
			//else if (cmds[0].Equals("authed", StringComparison.InvariantCultureIgnoreCase))
			//{
			//	if (cmds[1].Equals("true", StringComparison.InvariantCultureIgnoreCase))
			//	{
			//		// I'm authed
			//		KeyManager.IsAuthed = true;
			//		//ModConsole.DebugLog("Successfully Authed");
			//		Client.Send("gimmiedll");
			//	}
			//	else
			//	{
			//		KeyManager.IsAuthed = false;
			//		//ModConsole.DebugLog("Failed to Auth");
			//		Console.Beep();
			//		Environment.Exit(0);
			//	}
			//}
			//else
			//{
			//	Console.WriteLine($"Unknown packet: {input}");
			//}
		}

		private static void OnConnected(object sender, EventArgs e)
		{
			Console.WriteLine("Loader Connected..");
			return;
		}

		private static void OnDisconnect(object sender, EventArgs e)
		{
		}

		private static void OnPacketReceived(object sender, ReceivedPacketEventArgs e)
		{
			ProcessInput(sender, e.Data);
		}
	}
}