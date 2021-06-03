namespace AstroServer
{
	#region Imports

	using AstroNetworkingLibrary;
	using AstroNetworkingLibrary.Serializable;
	using AstroServer.DiscordBot;
	using AstroServer.Serializable;
	using MongoDB.Entities;
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

		private static void OnPingEvent(object source, ElapsedEventArgs e)
		{
			SendAll(new PacketData(PacketServerType.KEEP_ALIVE));
		}

		private static void ProcessInputAsync(object sender, PacketData packetData)
		{
			var networkEventID = packetData.NetworkEventID;

			if (networkEventID != PacketClientType.KEEP_ALIVE)
			{
				Console.WriteLine($"TCP Event {packetData.NetworkEventID} Received.");
			}

			Client client = sender as Client;

			switch (networkEventID)
			{
				case PacketClientType.AUTH:
					{
						client.Key = packetData.TextData;

						if (KeyManager.IsKeyValid(client.Key))
						{
							CheckExistingClientsWithKey(client);
							client.IsAuthed = true;
							client.DiscordID = KeyManager.GetKeysDiscordOwner(client.Key);

							client.Data = KeyManager.GetAccountData(client.Key);
							client.Send(new PacketData(PacketServerType.AUTH_SUCCESS));

							if (KeyManager.IsDevKey(client.Key))
							{
								client.Data.IsDeveloper = true;
								client.Send(new PacketData(PacketServerType.ENABLE_DEVELOPER));
							}

							if (client.Data.HasUdon)
							{
								client.Send(new PacketData(PacketServerType.ENABLE_UDON));
							}

							AstroBot.SendLoggedInLog(client);
						}
						else
						{
							client.Send(new PacketData(PacketServerType.AUTH_FAIlED));
							AstroBot.SendLoggedInFailedLog(client, "Invalid Key");
						}

						client.Send(new PacketData(PacketServerType.CONNECTION_FINISHED));
						break;
					}

				case PacketClientType.DISCONNECT:
					client.Disconnect();
					break;
				case PacketClientType.SEND_PLAYER_NAME:
					client.Name = packetData.TextData;
					break;
				case PacketClientType.SEND_PLAYER_USERID:
					client.UserID = packetData.TextData;
					break;
				case PacketClientType.WORLD_JOIN:
					client.InstanceID = packetData.TextData;
					InstanceManager.InstanceJoined(client);
					break;
				case PacketClientType.AVATAR_DATA:
					{
						var avatarData = Newtonsoft.Json.JsonConvert.DeserializeObject<AvatarData>(packetData.TextData);
						bool save = false;

						AvatarDataEntity avatarDataEntity = avatarData.GetAvatarDataEntity();
						var found = DB.Find<AvatarDataEntity>().OneAsync(avatarData.AvatarID).GetAwaiter().GetResult();

						if (found != null)
						{
							if (found.Version > avatarData.Version || !found.SupportedPlatforms.Equals(avatarData.SupportedPlatforms) || !found.ReleaseStatus.Equals(avatarData.ReleaseStatus))
							{
								save = true;
							}
						}
						else
						{
							save = true;
						}

						if (save)
						{
							avatarDataEntity.ID = avatarData.AvatarID;
							avatarDataEntity.SaveAsync().GetAwaiter().GetResult();
							Console.WriteLine($"Received New/Updated AvatarData: {avatarData.Name}, {avatarData.AvatarID}");
						}

						break;
					}

				case PacketClientType.AVATAR_SEARCH_TYPE:
					{
						client.Temp.SearchType = int.Parse(packetData.TextData);
						break;
					}

				case PacketClientType.AVATAR_SEARCH:
					{
						List<AvatarDataEntity> found = DB.Find<AvatarDataEntity>().ManyAsync(a => a.Name.ToLower().Contains(packetData.TextData.ToLower())).GetAwaiter().GetResult();
						List<AvatarDataEntity> toSend = new List<AvatarDataEntity>();

						Console.WriteLine($"Avatar Search: {client.Temp.SearchType}, {packetData.TextData.ToLower()}");

						if (found.Any())
						{
							toSend.AddRange(found.Where(avatar => (client.Temp.SearchType == 0) || (client.Temp.SearchType == 1 && avatar.ReleaseStatus.ToLower().Equals("public")) || (client.Temp.SearchType == 2 && avatar.ReleaseStatus.ToLower().Equals("private"))));
							int i = 0;
							foreach (var avatar in toSend)
							{
								if (i < 1000)
								{
									client.Send(new PacketData(PacketServerType.AVATAR_RESULT, Newtonsoft.Json.JsonConvert.SerializeObject(avatar.GetAvatarData())));
								}
								else
								{
									break;
								}
								i++;
							}
						}

						client.Send(new PacketData(PacketServerType.AVATAR_RESULT_DONE, toSend.Count.ToString()));
						break;
					}

				case PacketClientType.AVATAR_REPORT:
					{
						break;
					}

				case PacketClientType.AVATAR_DELETE:
					{
						var id = packetData.TextData;

						if (client.Data.IsDeveloper)
						{
							DB.Find<AvatarDataEntity>().OneAsync(id).GetAwaiter().GetResult().DeleteAsync().GetAwaiter().GetResult();
							Console.WriteLine($"DEVELOPER COMMAND: {client.Data.Name} deleted avatar: {id}");
						}
						else
						{
							Console.WriteLine($"WARNING: {client.Data.Name} tried to delete: {id}");
						}
						break;
					}

				case PacketClientType.KEEP_ALIVE:
					// No need to do anything here, we only catch this because it's a valid packet type.
					break;
				default:
					Console.WriteLine($"Received unknown packet type {networkEventID}");
					break;
			}
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
				if (client.Data.IsDeveloper)
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
			ProcessInputAsync(sender, e.Data);
		}
	}
}