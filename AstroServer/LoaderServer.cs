namespace AstroServer
{
	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading.Tasks;

	internal class LoaderServer
	{
		private static readonly int maxConnections = 1000;

		internal static List<Client> Clients { get; private set; }

		internal LoaderServer()
		{
			Console.WriteLine("Starting Loader Server..");
			Clients = new List<Client>();
			StartServer();
		}

		private static void StartServer()
		{
			TcpListener serverSocket = new TcpListener(new IPEndPoint(IPAddress.Any, 42070));
			serverSocket.Start();
			Console.WriteLine("Loader Server Started.");

			Task task = new Task(() =>
			{
				while (true)
				{
					TcpClient clientSocket = serverSocket.AcceptTcpClient();
					Client client = new Client
					{
						IsClient = false
					};

					client.Connected += Connected;
					client.Disconnected += Disconnected;
					client.ReceivedPacket += OnReceivedPacket;

					client.StartClient(clientSocket, GetNewClientID());
				}
			});
			task.Start();
		}

		public static List<string> Libraries = new List<string>()
		{
			"/AstroClient/Libs/AstroLibrary.dll"
		};

		public static List<string> Melons = new List<string>()
		{
			"/AstroClient/DontTouchMyClient.dll",
			"/AstroClient/AstroClient.dll"
		};

		public static List<string> Modules = new List<string>()
		{
			"/AstroClient/Module/AstroTestModule.dll"
		};

		private static void ProcessInput(object sender, PacketData packetData)
		{
			if (packetData.NetworkEventID != PacketServerType.KEEP_ALIVE)
			{
				Console.WriteLine($"TCP Event {packetData.NetworkEventID} Received.");
			}

			Client client = sender as Client;

			if (packetData.NetworkEventID == PacketClientType.AUTH)
			{
				string key = packetData.TextData;

				if (KeyManager.IsKeyValid(key))
				{
					client.IsAuthed = true;
					client.Key = key;
					client.DiscordID = KeyManager.GetKeysDiscordOwner(key);

					client.Send(new PacketData(PacketServerType.AUTH_SUCCESS));

					if (KeyManager.IsDevKey(key))
					{
						client.IsDeveloper = true;
					}
				}
				else
				{
					client.Send(new PacketData(PacketServerType.AUTH_FAIlED));
					client.Send(new PacketData(PacketServerType.EXIT));
					client.Disconnect();
				}
			}

			if (packetData.NetworkEventID == PacketClientType.GET_RESOURCES)
			{
				foreach (var libPath in Libraries)
				{
					try
					{
						var path = Environment.CurrentDirectory + libPath;
						byte[] data = File.ReadAllBytes(path);
						var converted = Convert.ToBase64String(data);
						client.Send(new PacketData(PacketServerType.LOADER_LIBRARY, converted));
					}
					catch (Exception e)
					{
						Console.WriteLine($"Failed to send: {e.Message}");
					}
				}

				foreach (var libPath in Melons)
				{
					try
					{
						var path = Environment.CurrentDirectory + libPath;
						byte[] data = File.ReadAllBytes(path);
						var converted = Convert.ToBase64String(data);
						client.Send(new PacketData(PacketServerType.LOADER_MELON, converted));
					}
					catch (Exception e)
					{
						Console.WriteLine($"Failed to send: {e.Message}");
					}
				}

				foreach (var libPath in Modules)
				{
					try
					{
						var path = Environment.CurrentDirectory + libPath;
						byte[] data = File.ReadAllBytes(path);
						var converted = Convert.ToBase64String(data);
						client.Send(new PacketData(PacketServerType.LOADER_MODULE, converted));
					}
					catch (Exception e)
					{
						Console.WriteLine($"Failed to send: {e.Message}");
					}
				}

				client.Send(new PacketData(PacketServerType.LOADER_DONE));
			}

			//Client client = sender as Client;
			//string[] cmds = input.Split(":");

			//if (cmds[0].Equals("gimmiedll") && client.IsAuthed)
			//{
			//	var path = Environment.CurrentDirectory + "/AstroClient/AstroClient.dll";
			//	byte[] data = File.ReadAllBytes(path);
			//	client.Send(data, 1001);
			//}
			//else if (cmds[0].Equals("gotdll"))
			//{
			//	client.Disconnect();
			//	Console.WriteLine($"DLL Sent");
			//	client.IsReady = true;
			//}
			//else if (cmds[0].Equals("key"))
			//{
			//	string key = cmds[1];
			//	Console.WriteLine("Trying to auth with: " + key);
			//	if (KeyManager.IsValidKey(key))
			//	{
			//		client.Send("authed:true");
			//		client.IsAuthed = true;
			//		client.Key = key;
			//		Console.WriteLine("Successfully Authed");
			//	}
			//	else
			//	{
			//		client.Send("authed:false");
			//		client.Send("exit:invalid auth key");
			//		client.Disconnect();
			//		Console.WriteLine("Invalid Auth Key");
			//	}
			//}
			//else
			//{
			//	Console.WriteLine($"Unknown packet: {input}");
			//}
		}

		public static void SendAll(string msg)
		{
			foreach (Client client in Clients)
			{
				//client.Send(msg);
			}
		}

		private static void Disconnected(object sender, EventArgs e)
		{
			Client client = sender as Client;
			if (Clients.Contains(client))
			{
				Clients.Remove(client);
			}
			Console.WriteLine($"Loader Disconnected: {client.ClientID} of {Clients.Count} / {maxConnections}");
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
					//other.Send("exit:key in use somewhere else");
					other.Disconnect();
				}
			}
		}

		private static void Connected(object sender, EventArgs e)
		{
			Client client = sender as Client;

			CheckExistingClientsWithKey(client);

			if (Clients.Count < maxConnections)
			{
				if (!Clients.Contains(client))
				{
					Clients.Add(client);
					Console.WriteLine($"Loader added: {client.ClientID} / {Clients.Count}");
					client.Send(new PacketData(PacketServerType.CONNECTED));
				}
				Console.WriteLine($"Loader Connected: {client.ClientID} / {Clients.Count}");
			}
			else
			{
				Console.WriteLine($"Loader Failed - Too Many Connections: {client.ClientID} / {Clients.Count}");
				client.Disconnect();
			}
		}

		private static void OnReceivedPacket(object sender, ReceivedPacketEventArgs e)
		{
			ProcessInput(sender, e.Data);
		}
	}
}