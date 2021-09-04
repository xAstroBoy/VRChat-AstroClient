namespace AstroClient
{
    #region Imports

    using AstroClient.Cheetos;
    using AstroClient.Components;
    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using Blaze.API;
    using Blaze.Utils;
    using MelonLoader;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Timers;
    using UnityEngine;
    using VRC;
    using Timer = System.Timers.Timer;

    #endregion Imports

    internal class AstroNetworkClient
    {
        internal static HandleClient Client;

        private static Timer pingTimer;

        public static void Initialize()
        {
            KeyManager.ReadKey();
            ModConsole.Log("Client Connecting..");

            Connect();
            SetPingTimer();
        }

        private static void SetPingTimer()
        {
            pingTimer = new Timer(10000);
            pingTimer.Elapsed += OnPingEvent;
            pingTimer.AutoReset = true;
            pingTimer.Enabled = true;
        }

        private static void OnPingEvent(object source, ElapsedEventArgs e)
        {
            Client.Send(new PacketData(PacketClientType.KEEP_ALIVE));
        }

        private static void Connect()
        {
            Client = null;
            TcpClient tcpClient = new TcpClient("client.craig.se", 42069);

            Client = new HandleClient
            {
                IsClient = true // Indicate that this is the client
            };

            Client.Connected += OnConnected;
            Client.Disconnected += OnDisconnect;
            Client.ReceivedPacket += OnPacketReceived;

            Client.StartClient(tcpClient, 0);
        }

        internal static void TriggerKeysharing()
        {
            for (int i = 0; i < 100; i++)
            {
                MelonLogger.Error("ASTROCLIENT KEYSHARING DETECTED");
                ModConsole.Error("ASTROCLIENT KEYSHARING DETECTED");
            }

            Environment.Exit(0);
        }

        private static void ProcessInput(PacketData packetData)
        {
            var networkEventID = packetData.NetworkEventID;

            if (networkEventID != PacketServerType.KEEP_ALIVE && networkEventID != PacketServerType.AVATAR_RESULT)
            {
                ModConsole.DebugLog($"TCP Event {packetData.NetworkEventID} Received.");
            }

            switch (networkEventID)
            {
                case PacketServerType.EXIT:
                    for (int i = 0; i < 100; i++)
                    {
                        MelonLogger.Error("ASTROCLIENT KEYSHARING DETECTED");
                        ModConsole.Error("ASTROCLIENT KEYSHARING DETECTED");
                    }

                    Environment.Exit(0);
                    break;

                case PacketServerType.CONNECTED:
                    Client.Send(new PacketData(PacketClientType.AUTH, KeyManager.AuthKey));
                    break;

                case PacketServerType.DISCONNECT:
                    Client.Disconnect();
                    break;

                case PacketServerType.AUTH_FAIlED:
                    ModConsole.Error("Failed to authenticate!");
                    Client.ShouldReconnect = false;
                    KeyManager.IsAuthed = false;
                    break;

                case PacketServerType.AUTH_SUCCESS:
                    KeyManager.IsAuthed = true;
                    break;

                case PacketServerType.ENABLE_DEVELOPER:
                    Bools.IsDeveloper = true;
                    ModConsole.Log("Developer Mode!");
                    break;

                case PacketServerType.ENABLE_UDON:
                    NetworkingManager.HasUdon = true;
                    break;

                case PacketServerType.CONNECTION_FINISHED:
                    NetworkingManager.IsReady = true;
                    break;
                case PacketServerType.ADD_TAG:
                    //var tagData = JsonConvert.DeserializeObject<TagData>(packetData.TextData);
                    //Player player;
                    //if (PlayerUtils.GetPlayer().GetUserID().Equals(tagData.UserID))
                    //{
                    //    ModConsole.Log("Wants to add tag to self");
                    //    player = PlayerUtils.GetPlayer();
                    //}
                    //else
                    //{
                    //    ModConsole.Log("Wants to add tag to someone else");
                    //    player = WorldUtils_Old.Get_Player_By_ID(tagData.UserID);
                    //}
                    //if (player != null)
                    //{
                    //    player.GetComponent<NamePlates>().AddTag(tagData.Text, Color.yellow);
                    //    // Temporary solution for applying developer status
                    //    if (tagData.Text.Equals("AstroClient Developer"))
                    //    {
                    //        player.GetComponent<NamePlates>().SetDeveloper(true);
                    //    }
                    //    //new BlazeTag(player, tagData.Text, Color.yellow);
                    //}
                    //else
                    //{
                    //    ModConsole.Log($"Player ({tagData.UserID}) returned null");
                    //}
                    break;

                case PacketServerType.NOTIFY:
                    CheetosHelpers.SendHudNotification(packetData.TextData);
                    break;

                case PacketServerType.DEBUG:
                    ModConsole.DebugLog(packetData.TextData);
                    break;

                case PacketServerType.LOG:
                    ModConsole.Log(packetData.TextData);
                    break;

                case PacketServerType.AVATAR_RESULT:
                    {
                        AvatarSearch.AddAvatar(JsonConvert.DeserializeObject<AvatarData>(packetData.TextData));
                        break;
                    }

                case PacketServerType.AVATAR_RESULT_DONE:
                    AvatarSearch.IsSearching = false;
                    break;

                case PacketServerType.KEEP_ALIVE:
                    // No need to do anything here, we only catch this because it's a valid packet type.
                    break;

                default:
                    ModConsole.Error($"Received an unknown packet type {networkEventID} from the server, perhaps you need to update?");
                    break;
            }
        }

        // You gotta delay it, let's delay it to some seconds
        private static void SpawnTag(Player player, string text, Color TextColor, Color Tagcolor)
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
        }

        private static void OnConnected(object sender, EventArgs e)
        {
            NetworkingManager.SendClientInfo();
            ModConsole.Log("Client Connected.");
            return;
        }

        private static void OnDisconnect(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                for (; ; )
                {
                    ModConsole.Error("Lost connection to server, retrying in 5 seconds...");
                    Thread.Sleep(5000);
                    try { Connect(); break; } catch { }
                }
            });
        }

        private static void OnPacketReceived(object sender, ReceivedPacketEventArgs e)
        {
            ProcessInput(e.Data);
        }
    }
}