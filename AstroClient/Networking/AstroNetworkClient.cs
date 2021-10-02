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
    using Blaze.Utils;
    using MelonLoader;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Timers;
    using UnityEngine;
    using VRC;
    using PopupUtils = AstroLibrary.Utility.PopupUtils;
    using Timer = System.Timers.Timer;

    #endregion Imports

    internal class AstroNetworkClient
    {
        internal static HandleClient Client;

        private static Timer pingTimer;

        internal static void Initialize()
        {
            KeyManager.ReadKey();
            ModConsole.Log("Client Connecting..");

            Connect();
        }

        private static IEnumerator PingLoop()
        {
            for(; Client.IsConnected;)
            {
                Client.Send(new PacketData(PacketClientType.KEEP_ALIVE));
                yield return new WaitForSeconds(5f);
            }
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
            MelonCoroutines.Start(PingLoop());
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
                    Client.Send(new PacketData(PacketClientType.CONNECTED, KeyManager.AuthKey));
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

                case PacketServerType.ENABLE_BETATESTER:
                    Bools.IsBetaTester = true;
                    ModConsole.Log("Beta Tester Mode!");
                    break;

                case PacketServerType.ENABLE_UDON:
                    NetworkingManager.HasUdon = true;
                    break;

                case PacketServerType.CONNECTION_FINISHED:
                    NetworkingManager.IsReady = true;
                    break;

                case PacketServerType.ADD_TAG:
                    //MiscUtils.DelayFunction(2f, () =>
                    //{
                    //    if (ConfigManager.UI.NamePlates)
                    //    {
                    //        var tagData = JsonConvert.DeserializeObject<TagData>(packetData.TextData);
                    //        Player player;
                    //        if (PlayerUtils.Player.GetUserID().Equals(tagData.UserID))
                    //        {
                    //            ModConsole.Log("Wants to add tag to self");
                    //            player = PlayerUtils.Player;
                    //        }
                    //        else
                    //        {
                    //            ModConsole.Log("Wants to add tag to someone else");
                    //            player = WorldUtils_Old.Get_Player_By_ID(tagData.UserID);
                    //        }
                    //        if (player != null)
                    //        {
                    //            //player.GetComponent<CheetoNameplate>().AddTag(tagData.Text, Color.yellow);
                    //            // Temporary solution for applying developer status
                    //            if (tagData.Text.Equals("AstroClient Developer"))
                    //            {
                    //                player.GetComponent<CheetoNameplate>().SetDeveloper(true);
                    //            }
                    //            //new BlazeTag(player, tagData.Text, Color.yellow);
                    //        }
                    //        else
                    //        {
                    //            ModConsole.Log($"Player ({tagData.UserID}) returned null");
                    //        }
                    //    }
                    //});
                    break;

                case PacketServerType.NOTIFY:
                    PopupUtils.QueHudMessage(packetData.TextData);
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


        private static void OnConnected(object sender, EventArgs e)
        {
            ModConsole.Log("Client Connected.");
            return;
        }

        private static void OnDisconnect(object sender, EventArgs e)
        {
            MelonCoroutines.Start(TryReconnect());
        }

        private static IEnumerator TryReconnect()
        {
            for (; ; )
            {
                try
                {
                    Connect();
                    yield break;
                }
                catch { }

                ModConsole.Log("Client reconnection attempt in 5 seconds..");
                yield return new WaitForSeconds(5f);
            }
        }

        private static void OnPacketReceived(object sender, ReceivedPacketEventArgs e)
        {
            ProcessInput(e.Data);
        }
    }
}