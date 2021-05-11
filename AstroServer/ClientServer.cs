﻿namespace AstroServer
{
	#region Imports
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using AstroServer.DiscordBot;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading.Tasks;
	using System.Timers;
	#endregion

	internal class ClientServer
	{
		private static readonly int maxConnections = 1000;

		public static List<Client> Clients { get; private set; }

		private static Timer pingTimer;

		public ClientServer()
		{
			Console.WriteLine("Starting Client Server..");
			Clients = new List<Client>();
			StartServer();
		}

		private static void StartServer()
		{
			TcpListener serverSocket = new TcpListener(new IPEndPoint(IPAddress.Any, 42069));
			serverSocket.Start();
			Console.WriteLine("Client Server Started..");

			// Key count
			Console.WriteLine($"There are {KeyManager.GetDevKeyCount()} dev keys stored.");
			Console.WriteLine($"There are {KeyManager.GetKeyCount()} valid keys stored.");

			SetPingTimer();
			Task task = new Task(() =>
			{
				while (true)
				{
					TcpClient clientSocket = serverSocket.AcceptTcpClient();
					Client client = new Client
					{
						IsClient = true
					};

					client.Connected += OnConnected;
					client.Disconnected += OnDisconnected;
					client.ReceivedPacket += OnReceivedPacket;

					client.StartClient(clientSocket, GetNewClientID());
				}
			});
			task.Start();
		}

		private static void SetPingTimer()
		{
			pingTimer = new Timer(10000);
			pingTimer.Elapsed += OnPingEvent;
			pingTimer.AutoReset = true;
			pingTimer.Enabled = true;
		}

		private static void DoChecks()
		{
			foreach (Client client in Clients)
			{
				if (client == null)
				{
					Console.WriteLine("Null client found!");
				}
			}
		}

		private static void OnPingEvent(object source, ElapsedEventArgs e)
		{
			DoChecks();
			SendAll(new PacketData(PacketServerType.KEEP_ALIVE));
		}

		private static void ProcessInput(object sender, PacketData packetData)
		{
			if (packetData.NetworkEventID != PacketClientType.KEEP_ALIVE)
			{
				Console.WriteLine($"TCP Event {packetData.NetworkEventID} Received.");
			}

			Client client = sender as Client;

			if (packetData.NetworkEventID == PacketClientType.AUTH)
			{
				string key = packetData.TextData;

				if (KeyManager.IsValidKey(key))
				{
					client.IsAuthed = true;
					client.Key = key;

					client.Send(new PacketData(PacketServerType.AUTH_SUCCESS));

					if (KeyManager.IsDevKey(key))
					{
						client.IsDeveloper = true;
						client.Send(new PacketData(PacketServerType.ENABLE_DEVELOPER));
						client.Send(new PacketData(PacketServerType.LOG, "Server sent this!"));
					}
				}
				else
				{
					client.Send(new PacketData(PacketServerType.AUTH_FAIlED));
					client.Send(new PacketData(PacketServerType.EXIT));
					client.Disconnect();
				}
			}

			if (packetData.NetworkEventID == PacketClientType.DISCONNECT)
			{
				client.Disconnect();
			}

			if (packetData.NetworkEventID == PacketClientType.SEND_PLAYER_NAME)
			{
				client.Name = packetData.TextData;
			}

			if (packetData.NetworkEventID == PacketClientType.SEND_PLAYER_USERID)
			{
				client.UserID = packetData.TextData;
			}

			if (packetData.NetworkEventID == PacketClientType.WORLD_JOIN)
			{
				client.InstanceID = packetData.TextData;
				InstanceManager.InstanceJoined(client);
			}

			//if (first.Equals("key"))
			//{
			//	string key = second;
			//	Console.WriteLine("Trying to auth with: " + key);
			//	if (KeyManager.IsValidKey(key))
			//	{
			//		client.Send("authed:true");
			//		client.IsAuthed = true;
			//		client.Key = key;
			//		Console.WriteLine("Successfully Authed");
			//		client.DiscordID = KeyManager.GetKeysDiscordOwner(key);

			//		CheckExistingClientsWithKey(client);

			//		if (KeyManager.IsDevKey(key))
			//		{
			//			client.IsDeveloper = true;
			//			client.Send("client-type:developer");
			//		}
			//		else
			//		{
			//			client.Send("client-type:client");
			//		}
			//		AstroBot.SendLoggedInLog(client);
			//	}
			//	else
			//	{
			//		client.Send("authed:false");
			//		client.Send("exit:invalid auth key");
			//		client.Disconnect();
			//		Console.WriteLine("Invalid Auth Key");
			//	}
			//}

			//else if (first.Equals("test"))
			//{
			//	Console.WriteLine(input);
			//}
			//else if (first.Equals("player-info"))
			//{
			//	//Console.WriteLine($"Received (player-info) for {second} from {client.UserID}");
			//	//var other = Clients.Where(c => c.UserID.Equals(second)).First();
			//	//if (other == null)
			//	//{
			//	//    Console.WriteLine("player-info other was null");
			//	//    return;
			//	//}
			//	//if (other.IsDeveloper)
			//	//{
			//	//    Console.WriteLine("Sending developer tag");
			//	//    client.Send($"add-tag:{other.UserID},AstroClient Developer");
			//	//}
			//	//else
			//	//{
			//	//    Console.WriteLine("Sending client tag");
			//	//    client.Send($"add-tag:{other.UserID},AstroClient");
			//	//}
			//}
			//else if (first.Equals("avatar-log"))
			//{
			//	try
			//	{
			//		Console.WriteLine(second + Environment.NewLine);
			//		AvatarData data = JsonConvert.DeserializeObject<AvatarData>(second);
			//		AstroBot.SendLogMessageAsync($"Received avatar data for {data.ID} \r\n " +
			//			$"{data.AssetURL} \r\n" +
			//			$"{data.ReleaseStatus} \r\n" +
			//			$"{data.ImageURL} \r\n" +
			//			$"{data.Version} \r\n" +
			//			$"{data.AuthorID} \r\n" +
			//			$"{data.AuthorName} \r\n" +
			//			$"{data.Description} \r\n" +
			//			$"{data.ThumbnailURL} \r\n" +
			//			$"{data.Name}");
			//		Console.WriteLine($"Received avatar data for {data.ID}");
			//	}
			//	catch (Exception e)
			//	{
			//		Console.WriteLine(e.Message);
			//	}
			//}
			//else
			//{
			//	Console.WriteLine($"Unknown packet: {input}");
			//}
		}

		public static void SendAll(PacketData packetData)
		{
			foreach (Client client in Clients)
			{
				client.Send(packetData);
			}
		}

		public static void SendToAllDevelopers(PacketData packetData)
		{
			foreach (Client client in Clients)
			{
				if (client.IsDeveloper)
				{
					client.Send(packetData);
				}
			}
		}

		private static void OnDisconnected(object sender, EventArgs e)
		{
			Client client = sender as Client;
			if (Clients.Contains(client))
			{
				Clients.Remove(client);
			}
			Console.WriteLine($"Client Disconnected: {client.ClientID} of {Clients.Count} / {maxConnections}");
		}

		internal static int GetNewClientID()
		{
			int i = 1;
			while (true)
			{
				IEnumerable<Client> result = Clients.Where(client => client.ClientID == i);
				if (!result.Any())
				{
					return i;
				}
				i++;
			}
		}

		private static void CheckExistingClientsWithKey(Client client)
		{
			foreach (var other in Clients)
			{
				if (client.Key.Equals(other.Key) && client.ClientID != other.ClientID)
				{
					AstroBot.SendKeyshareLog(client, other);
					//other.Send("exit:key in use somewhere else");
					other.Send(new PacketData(PacketServerType.EXIT, "Key in use somewhere else"));
					other.Disconnect();
				}
			}
		}

		private static void OnConnected(object sender, EventArgs e)
		{
			Client client = sender as Client;

			Console.WriteLine($"Connecting from {client.ClientSocket.Client.RemoteEndPoint}");

			if (Clients.Count < maxConnections)
			{
				if (!Clients.Contains(client))
				{
					Clients.Add(client);
					Console.WriteLine($"Client added: {client.ClientID} / {Clients.Count}");
					client.Send(new PacketData(PacketServerType.CONNECTED));
				}
				Console.WriteLine($"Client Connected: {client.ClientID} / {Clients.Count}");
			}
			else
			{
				Console.WriteLine($"Client Failed - Too Many Connections: {client.ClientID} / {Clients.Count}");
				client.Disconnect();
			}
		}

		private static void OnReceivedPacket(object sender, ReceivedPacketEventArgs e)
		{
			ProcessInput(sender, e.Data);
		}
	}
}