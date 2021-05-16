namespace AstroLoader
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Net.Sockets;

	// #TODO  Make this retreive multiple assemblies and resources
	internal class AstroNetworkLoader
	{
		internal static HandleClient Client;

		internal static List<byte[]> LibraryFiles = new List<byte[]>();
		internal static List<byte[]> MelonFiles = new List<byte[]>();
		internal static List<byte[]> ModuleFiles = new List<byte[]>();

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

			if (packetData.NetworkEventID == PacketServerType.LOADER_LIBRARY)
			{
				var data = Convert.FromBase64String(packetData.TextData);
				LibraryFiles.Add(data);
			}

			if (packetData.NetworkEventID == PacketServerType.LOADER_MELON)
			{
				var data = Convert.FromBase64String(packetData.TextData);
				MelonFiles.Add(data);
			}

			if (packetData.NetworkEventID == PacketServerType.LOADER_MODULE)
			{
				var data = Convert.FromBase64String(packetData.TextData);
				ModuleFiles.Add(data);
			}

			if (packetData.NetworkEventID == PacketServerType.LOADER_DONE)
			{
				Client.Disconnect();
				IsReady = true;
			}
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