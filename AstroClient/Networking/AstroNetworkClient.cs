﻿using AstroClient.Cheetos;
using AstroClient.ConsoleUtils;
using AstroClient.variables;
using AstroLibrary.Networking;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;
using Console = System.Console;

namespace AstroClient
{
    internal class AstroNetworkClient
    {
        internal static HandleClient Client;

        private static Timer pingTimer;

        public static void Initialize()
        {
            //ModConsole.DebugLog("Client Connecting..");
            Connect();
            SetPingTimer();
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
            Client.Send("ping");
        }

        private static void Connect()
        {
            Client = null;
            TcpClient tcpClient = new TcpClient("craig.se", 42069);
            Client = new HandleClient
            {
                IsClient = true // Indicate that this is the client
            };

            Client.Connected += OnConnected;
            Client.Disconnected += OnDisconnect;
            Client.ReceivedText += OnTextReceived;

            Client.StartClient(tcpClient, 0);
        }

        private static void ProcessInput(object sender, string input)
        {
            ModConsole.DebugLog(input);
            string[] cmds = input.Trim().Split(':');

            if (cmds[0].Equals("exit"))
            {
                Environment.Exit(0);
            } else if (cmds[0].Equals("auth-request", StringComparison.InvariantCultureIgnoreCase))
            {
                Client.Send($"key:{KeyManager.AuthKey}");
            } else if (cmds[0].Equals("authed", StringComparison.InvariantCultureIgnoreCase))
            {
                if (cmds[1].Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    // I'm authed
                    KeyManager.IsAuthed = true;
                }
                else
                {
                    KeyManager.IsAuthed = false;
                    ModConsole.DebugLog("Failed to Auth");
                    // I'm not authed
                    Console.Beep();
                    Environment.Exit(0);
                }
            }
            else if (cmds[0].Equals("notify-dev"))
            {
                CheetosHelpers.SendHudNotification(cmds[1]);
            }
            else if (cmds[0].Equals("client-type"))
            {
                if (cmds[1].Equals("developer"))
                {
                    Bools.IsDeveloper = true;
                    ModConsole.Log("Developer Mode!");
                }
                else
                {
                    Bools.IsDeveloper = false;
                }
            }
            else if (cmds[0].Equals("ping"))
            {
                Client.Send("pong");
            }
            else if (cmds[0].Equals("pong"))
            {
            }
            else
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.DebugLog($"Unknown packet: {input}");
                }
            }
        }

        private static void OnConnected(object sender, EventArgs e)
        {
            NetworkingManager.SendClientInfo();
            ModConsole.DebugLog("Client Connected.");
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

        private static void OnTextReceived(object sender, ReceivedTextEventArgs e)
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
