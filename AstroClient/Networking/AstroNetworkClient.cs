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
            string[] cmds = input.Trim().Split(':');

            if (cmds[0].Equals("exit"))
            {
                //Environment.Exit(0);
            }
            if (cmds[0].Equals("auth-request"))
            {
                Client.Send("key:12345");
                ModConsole.DebugLog("Auth Requested");
            }
            else if (cmds[0].Equals("authed"))
            {
                if (cmds[1].Equals("true"))
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
                    Console.WriteLine("Lost connection to server, retrying in 10 seconds...");
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
                        //Console.WriteLine($"Received {e.ClientID}: {e.Message} \n");
                        ModConsole.DebugLog($"Received: {data}");
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
