namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AstroNetworkClient
    {
        internal static HandleClient Client;

        public static void Initialize()
        {
            ModConsole.DebugLog("Client Conneting..");
            Connect();
        }

        private static void Connect()
        {
            Client = null;
            TcpClient tcpClient = new TcpClient("craig.se", 42069);
            Client = new HandleClient();

            Client.Connected += OnConnected;
            Client.Disconnected += OnDisconnect;
            Client.Received += OnReceived;

            Client.StartClient(tcpClient, 0);
        }

        private static void ProcessInput(object sender, string input)
        {
            ModConsole.DebugLog($"Received: {input}");
            string[] cmds = input.Trim().Split(':');

            if (cmds[0].Equals("exit"))
            {
                //Environment.Exit(0);
            } else if (cmds[0].Equals("auth-request", StringComparison.InvariantCultureIgnoreCase))
            {
                Client.Send("key:12345");
                ModConsole.DebugLog("Auth Requested");
            } else if (cmds[0].Equals("authed", StringComparison.InvariantCultureIgnoreCase))
            {
                if (cmds[1].Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    // I'm authed
                    ModConsole.DebugLog("Successfully Authed");
                }
                else
                {
                    ModConsole.DebugLog("Failed to Auth");
                    Console.Beep();
                    // I'm not authed
                    //Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine($"Unknown packet: {input}");
            }
        }

        private static void OnConnected(object sender, EventArgs e)
        {
            ModConsole.DebugLog("Client Connected..");
            return;
        }

        private static void OnDisconnect(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (; ; )
                {
                    ModConsole.DebugError("Lost connection to server, retrying in 10 seconds...");
                    Thread.Sleep(10000);
                    try { Connect(); break; } catch { }
                }
            });
        }

        private static void OnReceived(object sender, ReceivedTextEventArgs e)
        {
            Task.Run(() =>
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
                        ModConsole.DebugLog("Empty request.");
                    }
                }
                catch { }
            });
        }
    }
}
