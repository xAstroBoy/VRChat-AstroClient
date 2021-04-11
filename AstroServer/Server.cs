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

        internal static List<string> AuthKeys = new List<string>();

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

            // Cheetos Key
            AuthKeys.Add("KeXYLwEwyPsYT4IrSbWWrupYqjzT8C3VEWN2uWb1DpjjB1kcoOJICsbmjnXRmeRzjxoXcuX6CCWZVwltPGTWGE2AFJENcYA1EWh7FRXCvMS66u75LIZeWl5Gd8XqKnyR8YFlKw9U2cAXTZhjovlQvy94Up1VbM5PP3IhdAIKpSBlOBTcrgCz7tTTx81gcwslOLJW6P61");
            
            // Astro's Key
            AuthKeys.Add("hQhe2Y2mcVkfUSJbBcfZSO5WLMaiBzzXL4v9aA3Ze1fxOx9CHgwcp8akxeenKcHIsALBBRgVyVt2v7jCp8gOTLe6CgJpIYyarZpBGIlPzC66peQyMnw58OXcHDUXbNW6P6oMIPYpjICJwY2QW1MARvCW48x8v09EdcOzpHOPx3JFeCOdCwKCxPubaZWmTmNpwPF0EMdV");

            // Key count
            Console.WriteLine($"There are {AuthKeys.Count} valid keys stored.");

            Clients = new List<Client>();
            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Client client = new Client();

                client.Connected += Connected;
                client.Disconnected += Disconnected;
                client.ReceivedText += ReceivedText;

                client.StartClient(clientSocket, GetNewClientID());
            }
        }

        private static bool IsValidKey(string authKey)
        {
            foreach (string key in AuthKeys)
            {
                if (key.Equals(authKey))
                {
                    return true;
                }
            }
            return false;
        }

        private static void ProcessInput(object sender, string input)
        {
            Client client = sender as Client;

            Console.WriteLine($"Received: {input}");
            string[] cmds = input.Split(":");

            if (cmds[0].Equals("key"))
            {
                string key = cmds[1];
                Console.WriteLine("Trying to auth with: " + key);
                //if (key.Equals("12345", StringComparison.InvariantCultureIgnoreCase))
                if (IsValidKey(key))
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
            else
            {
                Console.WriteLine($"Unknown packet: {input}");
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

        private static void ReceivedText(object sender, ReceivedTextEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Message) && !string.IsNullOrWhiteSpace(e.Message))
            {
                var data = e.Message;
                ProcessInput(sender, data);
            }
            else
            {
                Console.WriteLine("Empty request.");
            }
        }
    }
}
