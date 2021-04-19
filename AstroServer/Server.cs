using AstroLibrary.Networking;
using AstroLibrary.Serializable;
using AstroServer.DiscordBot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Timers;

namespace AstroServer
{
    internal class Server
    {
        private static readonly int _maxConnections = 1000;

        public static List<Client> Clients { get; private set; }

        private static Timer pingTimer;


        public Server()
        {
            Console.WriteLine("Starting Server");
            StartServer();
        }

        private static void StartServer()
        {
            TcpListener serverSocket = new TcpListener(new IPEndPoint(IPAddress.Any, 42069));
            serverSocket.Start();
            Console.WriteLine("Client Server Started..");

            // Key count
            Console.WriteLine($"There are {KeyManager.GetDevKeyCount()} dev keys stored.");
            Console.WriteLine($"There are {KeyManager.GetKeyCount()} valid keys stored.");

            Clients = new List<Client>();

            SetPingTimer();

            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Client client = new Client
                {
                    IsClient = true
                };

                client.Connected += Connected;
                client.Disconnected += Disconnected;
                client.ReceivedText += ReceivedText;

                client.StartClient(clientSocket, GetNewClientID());
            }
        }

        private static void SetPingTimer()
        {
            // Create a timer with a two second interval.
            pingTimer = new Timer(60000);
            // Hook up the Elapsed event for the timer. 
            pingTimer.Elapsed += OnPingEvent;
            pingTimer.AutoReset = true;
            pingTimer.Enabled = true;
        }

        private static void OnPingEvent(Object source, ElapsedEventArgs e)
        {
            SendAll("ping");
        }

        private static void ProcessInput(object sender, string input)
        {
            Client client = sender as Client;

            int index;
            string first;
            string second = string.Empty;

            if (input.Contains(":"))
            {
                index = input.IndexOf(':');
                first = input.Substring(0, index);
                second = input.Substring(index + 1);
            }
            else
            {
                first = input;
            }

            if (first.Equals("key"))
            {
                string key = second;
                Console.WriteLine("Trying to auth with: " + key);
                if (KeyManager.IsValidKey(key))
                {
                    client.Send("authed:true");
                    client.IsAuthed = true;
                    client.Key = key;
                    Console.WriteLine("Successfully Authed");

                    if (KeyManager.IsDevKey(key))
                    {
                        client.IsDeveloper = true;
                        client.Send("client-type:developer");
                        AstroBot.SendLogMessageAsync($"Developer Connected From: {client.ClientSocket.Client.RemoteEndPoint}");
                        //SendToAllDevelopers(sender, $"notify-dev:AstroClient developer connected: {client.Name}");
                    }
                    else
                    {
                        //SendToAllDevelopers(sender, $"notify-dev:AstroClient connected: {client.Name}");
                        client.Send("client-type:client");
                    }
                }
                else
                {
                    client.Send("authed:false");
                    client.Send("exit:invalid auth key");
                    client.Disconnect();
                    Console.WriteLine("Invalid Auth Key");
                }
            }
            else if (first.Equals("name"))
            {
                client.Name = second;
            }
            else if (first.Equals("userid"))
            {
                client.UserID = second;
            }
            else if (first.Equals("ping"))
            {
                client.Send("pong");
            }
            else if (first.Equals("pong"))
            {
            }
            else if (first.Equals("avatar-log"))
            {
                try
                {
                    AvatarData data = JsonConvert.DeserializeObject<AvatarData>(second);
                    AstroBot.SendLogMessageAsync($"Received avatar data for {data.ID}");
                    Console.WriteLine($"Received avatar data for {data.ID}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine($"Unknown packet: {input}");
            }
        }

        public static void SendAll(string msg)
        {
            foreach (Client client in Clients)
            {
                client.Send(msg);
            }
        }

        public static void SendToAllDevelopers(string msg)
        {
            foreach (Client client in Clients)
            {
                if (client.IsDeveloper)
                {
                    client.Send(msg);
                }
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

        private static void CheckExistingClientsWithKey(Client client)
        {
            foreach (var other in Clients)
            {
                if (client.Key.Equals(other.Key) && client.ClientID != other.ClientID)
                {
                    AstroBot.SendLogMessageAsync($"Possible key sharing from: "
                        + $"Booted: {other.Name}, {other.UserID}, {other.ClientSocket.Client.RemoteEndPoint}. \r\n " 
                        + $"Logged in: {client.Name}, {client.UserID}, {client.ClientSocket.Client.RemoteEndPoint}. \r\n " 
                        + "\r\n\r\n" +
                        $"```{client.Key}```");
                    other.Send("exit:key in use somewhere else");
                    other.Disconnect();
                }
            }
        }

        private static void Connected(object sender, EventArgs e)
        {
            Client client = sender as Client;

            Console.WriteLine($"Connecting from {client.ClientSocket.Client.RemoteEndPoint}");

            CheckExistingClientsWithKey(client);

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
