namespace AstroClient
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AstroNetworkClient
    {
        internal static HandleClient Client;

        public AstroNetworkClient()
        {
            Connect();
        }

        private void Connect()
        {
            Client = null;
            TcpClient tcpClient = new TcpClient("localhost", 42069);
            Client = new HandleClient();

            Client.Connected += OnConnected;
            Client.Disconnected += OnDisconnect;
            Client.Received += OnReceived;

            Client.StartClient(tcpClient, 0);
        }

        private void OnConnected(object sender, EventArgs e)
        {
            int i = 0;

            StringBuilder stringBuilder = new StringBuilder();
            while (i < 99)
            {
                stringBuilder.Append("junk");
                i++;
            }
            stringBuilder.Append("[end]");

            Client.Send(stringBuilder.ToString());
            return;
            Task.Run(() =>
            {
                Console.WriteLine("Connected to server.");
                Client.Send("Auth");
            });
        }

        private void OnDisconnect(object sender, EventArgs e)
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

        private void OnReceived(object sender, ReceivedTextEventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(e.Message) && !string.IsNullOrWhiteSpace(e.Message))
                    {
                        var data = e.Message;
                        //Console.WriteLine($"Received {e.ClientID}: {e.Message} \n");
                        Console.WriteLine($"Received: {data}");
                    }
                    else
                    {
                        Client.Disconnect();
                        Console.WriteLine("Empty request.");
                    }
                }
                catch { }
            });
        }
    }
}
