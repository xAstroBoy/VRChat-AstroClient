namespace AstroLoader
{
    using AstroLibrary.Networking;
    using System;
    using System.IO;
    using System.Net.Sockets;

    internal static class KeyManager
    {
        public static string AuthKey = string.Empty;

        public static bool IsAuthed = false;

        public static void ReadKey()
        {
            string keyPath = Environment.CurrentDirectory + @"\AstroClient\key.txt";

            if (File.Exists(keyPath))
            {
                AuthKey = File.ReadAllText(keyPath);
            }
            else
            {
                System.Console.Beep();
                Environment.Exit(0);
            }
        }
    }

    internal class AstroNetworkLoader
    {
        internal static HandleClient Client;

        internal static byte[] AssemblyFile;

        internal static bool IsReady = false;

        public static void Initialize()
        {
            Console.WriteLine("Loader Conneting..");
            Connect();
        }

        private static void Connect()
        {
            Client = null;
            TcpClient tcpClient = new TcpClient("craig.se", 42070);
            Client = new HandleClient();
            Client.IsClient = false; // Indicate that this is the loader

            Client.Connected += OnConnected;
            Client.Disconnected += OnDisconnect;
            Client.ReceivedText += OnTextReceived;
            Client.ReceivedData += OnDataReceived;

            Client.StartClient(tcpClient, 0);
        }

        private static void ProcessInput(object sender, string input)
        {
            //ModConsole.DebugLog($"Received: {input}");
            string[] cmds = input.Trim().Split(':');

            if (cmds[0].Equals("exit"))
            {
                System.Console.Beep();
                Environment.Exit(0);
            }
            else if (cmds[0].Equals("auth-request", StringComparison.InvariantCultureIgnoreCase))
            {
                Client.Send($"key:{KeyManager.AuthKey}");
                //ModConsole.DebugLog("Auth Requested");
            }
            else if (cmds[0].Equals("authed", StringComparison.InvariantCultureIgnoreCase))
            {
                if (cmds[1].Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    // I'm authed
                    KeyManager.IsAuthed = true;
                    //ModConsole.DebugLog("Successfully Authed");
                    Client.Send("gimmiedll");
                }
                else
                {
                    KeyManager.IsAuthed = false;
                    //ModConsole.DebugLog("Failed to Auth");
                    Console.Beep();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine($"Unknown packet: {input}");
            }
        }

        private static void OnConnected(object sender, EventArgs e)
        {
            //ModConsole.DebugLog("Client Connected..");
            return;
        }

        private static void OnDisconnect(object sender, EventArgs e)
        {
            
        }

        private static void OnTextReceived(object sender, ReceivedTextEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Message) && !string.IsNullOrWhiteSpace(e.Message))
                {
                    var data = e.Message;
                    ProcessInput(sender, data);
                }
                else
                {
                    Client.Disconnect();
                    //ModConsole.DebugLog("Empty request.");
                }
            }
            catch { }
        }

        private static void OnDataReceived(object sender, ReceivedDataEventArgs e)
        {
            var client = sender as HandleClient;
            AssemblyFile = e.Data;
            //Console.WriteLine("Received Assembly File Data");
            client.Send("gotdll");
            IsReady = true;
        }
    }
}
