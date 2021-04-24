using AstroClient.Cheetos;
using AstroClient.components;
using AstroClient.Components;
using AstroClient.ConsoleUtils;
using AstroClient.variables;
using AstroLibrary.Networking;
using DayClientML2.Utility;
using DayClientML2.Utility.Extensions;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using VRC;
using Console = System.Console;
using Timer = System.Timers.Timer;

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
            pingTimer = new Timer(2000);
            // Hook up the Elapsed event for the timer.
            pingTimer.Elapsed += OnPingEvent;
            pingTimer.AutoReset = true;
            pingTimer.Enabled = true;
        }

        private static void OnPingEvent(System.Object source, ElapsedEventArgs e)
        {
            Client.Send("ping");
        }

        private static void Connect()
        {
            Client = null;
            //TcpClient tcpClient = new TcpClient("craig.se", 42069);

            TcpClient tcpClient = new TcpClient();
            var result = tcpClient.BeginConnect("craig.se", 42069, null, null);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));

            if (!success)
            {
                ModConsole.Error("Failed to connect..");
                return;
                //throw new Exception("Failed to connect.");
            }

            tcpClient.EndConnect(result);

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

            if (first.Equals("exit"))
            {
                Environment.Exit(0);
            }
            else if (first.Equals("auth-request", StringComparison.InvariantCultureIgnoreCase))
            {
                Client.Send($"key:{KeyManager.AuthKey}");
            }
            else if (first.Equals("authed", StringComparison.InvariantCultureIgnoreCase))
            {
                if (second.Equals("true", StringComparison.InvariantCultureIgnoreCase))
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
            else if (first.Equals("notify-dev"))
            {
                CheetosHelpers.SendHudNotification(second);
            }
            else if (first.Equals("client-type"))
            {
                if (second.Equals("developer"))
                {
                    Bools.IsDeveloper = true;
                    ModConsole.Log("Developer Mode!");
                }
                else
                {
                    Bools.IsDeveloper = false;
                }
            }
            else if (first.Equals("ping"))
            {
                Client.Send("pong");
            }
            else if (first.Equals("pong"))
            {
            }
            else if (first.Equals("add-tag"))
            {
                string[] info = second.Split(',');
                Player player;
                if (LocalPlayerUtils.GetSelfPlayer().UserID().Equals(info[0]))
                {
                    ModConsole.DebugLog("Wants to add tag to self");
                    player = LocalPlayerUtils.GetSelfPlayer();
                }
                else
                {
                    ModConsole.DebugLog("Wants to add tag to someone else");
                    player = WorldUtils.GetPlayerByID(info[0]);
                }
                if (player != null)
                {
                    SpawnTag(player, info[1], Color.white, Color.blue);
                }
                else
                {
                    ModConsole.DebugLog($"Player ({info[0]}) returned null");
                }
            }
            else
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.DebugLog($"Unknown packet: {input}");
                }
            }
        }

        // You gotta delay it, let's delay it to some seconds
        private static void SpawnTag(Player player, string text, Color TextColor, Color Tagcolor)
        {
            MiscUtility.DelayFunction(0.5f, new Action(() =>
            {
                if (player != null)
                {
        
                     SingleTag tag = SingleTagsUtils.AddSingleTag(player);
                    if (tag != null)
                    {
                        tag.Label_Text = text;
                        tag.Label_TextColor = TextColor;
                        tag.Tag_Color = Tagcolor;
                    }
                }
                else
                {
                    ModConsole.Error("Player for setting tag from server was null!");
                }
            }));

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
                    if (Client.ShouldReconnect)
                    {
                        ModConsole.DebugError("Lost connection to server, retrying in 60 seconds...");
                        Thread.Sleep(60000);
                        try { Connect(); break; } catch { }
                    }
                    else
                    {
                        break;
                    }
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