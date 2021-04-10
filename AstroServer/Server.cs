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

        internal static Dictionary<string, string> AuthKeys = new Dictionary<string, string>();

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

            // Load AuthKeys, eventually going to use a database or something
            AuthKeys.Add("12345", "Test Key");

            // Key count
            Console.WriteLine($"There are {AuthKeys.Count} valid keys stored.");

            Clients = new List<Client>();
            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Client client = new Client();

                client.Connected += Connected;
                client.Disconnected += Disconnected;
                client.Received += Received;

                client.StartClient(clientSocket, GetNewClientID());
            }
        }

        private static void ProcessInput(object sender, string input)
        {
            Client client = sender as Client;

            string[] cmds = input.Trim().Split(":");

            if (cmds[0].Equals("key", StringComparison.Ordinal))
            {
                string key = cmds[1];
                Console.WriteLine("Trying to auth with: " + key);
                if (AuthKeys.ContainsKey(key))
                {
                    client.Send("authed:true");
                    client.IsAuthed = true;
                    client.Key = key;
                    Console.WriteLine("Successfully Authed");
                } else
                {
                    client.Send("authed:false");
                    client.Send("exit:invalid auth key");
                    client.Disconnect();
                    Console.WriteLine("Invalig Auth Key");
                }
            }
        }

        public void SendAll(string msg)
        {
            foreach (Client client in Clients)
            {
                client.Send(msg);
            }
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

        private static void Connected(object sender, EventArgs e)
        {
            Client client = sender as Client;

            if (Clients.Count < _maxConnections)
            {
                if (!Clients.Contains(client))
                {
                    Clients.Add(client);
                    Console.WriteLine($"Client added: {client.ClientID} / {Clients.Count}");
                    client.Send("auth-request");
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
