namespace AstroInjector
{
    #region Imports

    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Sockets;

    #endregion

    // #TODO  Make this retreive multiple resources
    internal class AstroNetworkLoader
    {
        internal static HandleClient Client;

        internal static List<byte[]> LibraryFiles = new List<byte[]>();
        internal static List<byte[]> MelonFiles = new List<byte[]>();
        internal static List<byte[]> ModuleFiles = new List<byte[]>();

        internal static bool IsReady = false;

        internal static void Initialize()
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
                Client.Send(new PacketData(PacketClientType.CONNECTED, JsonConvert.SerializeObject(KeyManager.Data)));
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
                Console.WriteLine("Asking for resources..");
                Client.Send(new PacketData(PacketClientType.GET_RESOURCES));
            }

            if (packetData.NetworkEventID == PacketServerType.LOADER_LIBRARY)
            {
                Console.WriteLine("Received: Library");
                var data = Convert.FromBase64String(packetData.TextData);
                LibraryFiles.Add(data);
                Client.Send(new PacketData(PacketClientType.GOT_RESOURCE));
            }

            if (packetData.NetworkEventID == PacketServerType.LOADER_MELON)
            {
                Console.WriteLine("Received: Melon");
                var data = Convert.FromBase64String(packetData.TextData);
                MelonFiles.Add(data);
                Client.Send(new PacketData(PacketClientType.GOT_RESOURCE));
            }

            if (packetData.NetworkEventID == PacketServerType.LOADER_MODULE)
            {
                Console.WriteLine("Received: Module");
                var data = Convert.FromBase64String(packetData.TextData);
                ModuleFiles.Add(data);
                Client.Send(new PacketData(PacketClientType.GOT_RESOURCE));
            }

            if (packetData.NetworkEventID == PacketServerType.DEBUG)
            {
                Console.WriteLine(packetData.TextData);
            }

            if (packetData.NetworkEventID == PacketServerType.LOADER_DONE)
            {
                Console.WriteLine("Loader Done?");
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