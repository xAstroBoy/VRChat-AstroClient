﻿namespace AstroServer
{
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    internal class ContentServer
    {
        private static readonly int maxConnections = 1000;

        internal static List<Client> Clients { get; private set; }

        internal ContentServer()
        {
            Console.WriteLine("Starting Content Server..");
            Clients = new List<Client>();
            StartServer();
        }

        private static void StartServer()
        {
            TcpListener serverSocket = new TcpListener(new IPEndPoint(IPAddress.Any, 42070));
            serverSocket.Start();
            Console.WriteLine("Content Server Started.");

            Console.WriteLine($"InjectorHash: {GetInjectorHash().GetByteArrayAsString()}");

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

        public static string InjectorPath = "/Client/AstroInjector.dll";

        public static List<string> Libraries = new List<string>()
        {
            "/Client/Public/Libs/AstroLibrary.dll"
        };

        public static List<string> BetaLibraries = new List<string>()
        {
            "/Client/Beta/Libs/AstroLibrary.dll"
        };

        public static List<string> Melons = new List<string>()
        {
            //"/AstroClient/DontTouchMyClient.dll",
            //"/AstroClient/AstroClientCore.dll",
            "/Client/Public/AstroClient.dll"
        };

        public static List<string> BetaMelons = new List<string>()
        {
            //"/AstroClient/DontTouchMyClient.dll",
            //"/AstroClient/AstroClientCore.dll",
            "/Client/Beta/AstroClient.dll"
        };

        public static List<string> Modules = new List<string>()
        {
            //"/AstroClient/Module/AstroTestModule.dll"
        };

        private static byte[] GetInjectorHash()
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                var stream = File.OpenRead(Environment.CurrentDirectory + InjectorPath);
                stream.Position = 0;
                return mySHA256.ComputeHash(stream);
            }
        }

        private static void ProcessInput(object sender, PacketData packetData)
        {
            var networkEventID = packetData.NetworkEventID;

            if (packetData.NetworkEventID != PacketServerType.KEEP_ALIVE)
            {
                Console.WriteLine($"TCP Event {packetData.NetworkEventID} Received.");
            }

            Client client = sender as Client;

            switch (networkEventID)
            {
                case PacketClientType.CONNECTED:
                    {
                        string key = packetData.TextData;

                        if (AccountManager.IsKeyValid(key))
                        {
                            client.IsAuthed = true;
                            client.Key = key;
                            client.DiscordID = AccountManager.GetKeysDiscordOwner(key);

                            client.Data = AccountManager.GetAccountData(key);
                            client.Send(new PacketData(PacketServerType.AUTH_SUCCESS));
                        }
                        else
                        {
                            client.Send(new PacketData(PacketServerType.AUTH_FAIlED));
                            client.Send(new PacketData(PacketServerType.EXIT));
                            client.Disconnect();
                        }

                        break;
                    }

                case PacketClientType.GET_RESOURCES:
                    {
                        var currentMelons = new List<string>();
                        var currentLibraries = new List<string>();
                        var currentModules = Modules;

                        if (client.Data.IsBeta)
                        {
                            currentMelons = BetaMelons;
                            currentLibraries = BetaLibraries;
                            Console.WriteLine("Content Type: Beta Tester");
                        }
                        else
                        {
                            currentMelons = Melons;
                            currentLibraries = Libraries;
                            Console.WriteLine("Content Type: Public");
                        }

                        foreach (var libPath in currentLibraries)
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

                        foreach (var libPath in currentMelons)
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

                        foreach (var libPath in currentModules)
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
                        break;
                    }

                default:
                    Console.WriteLine($"Unknown packet type received: {networkEventID}");
                    break;
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