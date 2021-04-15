using AstroLibrary.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace AstroServer
{
    [Serializable]
    internal class UserData // #TODO Make this work
    {
        public string Name = string.Empty;

        public string Key = string.Empty;

        public string Discord = string.Empty;
    }

    internal class Server
    {
        private static readonly int _maxConnections = 1000;

        internal static List<Client> Clients { get; private set; }

        internal Server()
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
            Console.WriteLine($"There are {GetDevKeyCount()} dev keys stored.");
            Console.WriteLine($"There are {GetKeyCount()} valid keys stored.");

            Clients = new List<Client>();
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

        private static int GetDevKeyCount()
        {
            return File.ReadAllLines("/root/devs.txt").Length;
        }

        private static int GetKeyCount()
        {
            return File.ReadAllLines("/root/keys.txt").Length;
        }

        private static bool IsDevKey(string authKey)
        {
            foreach (var key in File.ReadLines("/root/devs.txt"))
            {
                if (key.Equals(authKey))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsValidKey(string authKey)
        {
            foreach (var key in File.ReadLines("/root/devs.txt"))
            {
                if (key.Equals(authKey))
                {
                    return true;
                }
            }
            foreach (var key in File.ReadLines("/root/keys.txt"))
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
            string[] cmds = input.Split(":");

            if (cmds[0].Equals("key"))
            {
                string key = cmds[1];
                Console.WriteLine("Trying to auth with: " + key);
                if (IsValidKey(key))
                {
                    client.Send("authed:true");
                    client.IsAuthed = true;
                    client.Key = key;
                    Console.WriteLine("Successfully Authed");

                    if (IsDevKey(key))
                    {
                        client.IsDeveloper = true;
                        //SendToAllDevelopers(sender, $"notify-dev:AstroClient developer connected: {client.Name}");
                    }
                    else
                    {
                        //SendToAllDevelopers(sender, $"notify-dev:AstroClient connected: {client.Name}");
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
            else if (cmds[0].Equals("name"))
            {
                client.Name = cmds[1];
            }
            else if (cmds[0].Equals("userid"))
            {
                client.UserID = cmds[1];
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
                    other.Send("exit:key in use somewhere else");
                    other.Disconnect();
                }
            }
        }

        private static void Connected(object sender, EventArgs e)
        {
            Client client = sender as Client;

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
