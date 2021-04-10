namespace AstroServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;

    internal class Server
    {
        private static readonly int _maxConnections = 1000;

        internal static List<Client> Clients { get; private set; }

        internal Server()
        {
            Console.WriteLine("Starting Server");
            StartServer();
        }

        private void StartServer()
        {
            TcpListener serverSocket = new TcpListener(new IPEndPoint(IPAddress.Any, 42069));
            serverSocket.Start();
            Console.WriteLine("Server Started.");

            Clients = new List<Client>();
            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Client client = new Client();

                client.Connected += Connected;
                client.Disconnected += Disconnected;
                client.Received += Received;

                client.LoggedIn += LoggedIn;

                client.StartClient(clientSocket, GetNewClientID());
            }
        }

        private static void ProcessInput(object sender, string input)
        {
            Client client = sender as Client;
        }

        public void SendAll(string msg)
        {
            foreach (Client client in Clients)
            {
                client.Send(msg);
            }
        }

        private static void LoggedIn(object sender, EventArgs e)
        {
            Client client = sender as Client;
            //SendAll($"Client {client.ClientID}: Logged In as {client.Name}");
            Console.WriteLine($"Client {client.ClientID}: Logged In as {client.Name}");
        }

        private static void Disconnected(object sender, EventArgs e)
        {
            Client client = sender as Client;
            if (Clients.Contains(client))
            {
                //Settings.AuthenticatedUsers.Remove(client);
                Clients.Remove(client);
                //Console.WriteLine($"Client removed: {client.ClientID}");
            }

            //SendAll($"Client Disconnected: {client.ClientID} of {Clients.Count} / {_maxConnections}");
            Console.WriteLine($"Client Disconnected: {client.ClientID} of {Clients.Count} / {_maxConnections}");
        }

        internal static int GetNewClientID()
        {
            int i = 0;
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

        private static void Connected(object sender, EventArgs e)
        {
            Client client = sender as Client;

            if (Clients.Count < _maxConnections)
            {
                if (!Clients.Contains(client))
                {
                    Clients.Add(client);
                    Console.WriteLine($"Client added: {client.ClientID} / {Clients.Count}");
                    //client.Send("ping".ConvertToBytes());
                    //client.SendEncrypted("Test from Server..");
                }
                Console.WriteLine($"Client Connected: {client.ClientID} / {Clients.Count}");
            }
            else
            {
                Console.WriteLine($"Client Failed - Too Many Connections: {client.ClientID} / {Clients.Count}");
                client.Disconnect();
            }
        }

        private static void Received(object sender, ReceivedTextEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Message) && !string.IsNullOrWhiteSpace(e.Message))
            {
                var data = e.Message;
                //if (e.Message.EndsWith("=")) // Data is likely encrypted since encrypted data ends with =
                //{
                //    data = Framework.Decrypt(e.Message);
                //}
                //else
                //{
                //    data = e.Message;
                //}
                Console.WriteLine($"Received {e.ClientID}: {data} \n");
                ProcessInput(sender, data);
            }
            else
            {
                Console.WriteLine("Empty request.");
            }
        }
    }
}
