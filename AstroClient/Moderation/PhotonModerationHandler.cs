namespace AstroClient.Moderation
{

    using AstroClient.Variables;
    using AstroClientCore.Events;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using ExitGames.Client.Photon;
    using Harmony;
    using Photon.Realtime;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using UnityEngine;
    using VRC.SDKBase;


    public class PhotonModerationHandler : GameEvents
    {
        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerBlockedYou;

        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnblockedYou;

        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerMutedYou;

        public static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnmutedYou;


        public static bool Handle_Photon_ModerationEvent(EventData Event)
        {
            if (Event == null)
            {
                return true;
            }
            object rawData = Serialization.FromIL2CPPToManaged<object>(Event.Parameters);
            var code = Event.Code;
            var parsedData = (rawData as Dictionary<byte, object>);
            var infoData = parsedData[245] as Dictionary<byte, object>;
            int eventType = int.Parse(infoData[0].ToString());
            var photon = Utils.LoadBalancingPeer.GetPhotonPlayer(Event.sender);
            var sender = Event.sender;
            switch (eventType)
            {
                case 21: // 10 blocked, 11 muted

                    if (infoData[10] != null && infoData[11] != null)
                    {
                        // If Key 1 exists then this is a direct moderation
                        if (infoData.ContainsKey(1))
                        {
                            int SenderID = int.Parse(infoData[1].ToString());
                            var PhotonPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(SenderID);
                            bool Blocked = bool.Parse(infoData[10].ToString());
                            bool Muted = bool.Parse(infoData[11].ToString());
                            if (PhotonPlayer != null)
                            {

                                if (Blocked)
                                {
                                    OnPlayerBlockedYou_Invoker(PhotonPlayer);
                                }
                                else
                                {
                                    OnPlayerUnblockedYou_Invoker(PhotonPlayer);
                                }
                                if (Muted)
                                {
                                    OnPlayerMutedYou_Invoker(PhotonPlayer);
                                }
                                else
                                {
                                    OnPlayerUnmutedYou_Invoker(PhotonPlayer);
                                }

                                if (Blocked) // AntiBlock.
                                {
                                    ModerationEventNotifier(Event, code, PhotonPlayer, SenderID, eventType, true);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            // It sends the Arrays when the Block and Mute Event happen fast.
                            // if 10 is an Array it has all the PhotonIds that Blocked You
                            // if 11 is an Array it has all the PhotonIds that Muted You
                            var BlockedList = infoData[10] as int[];
                            var MuteList = infoData[11] as int[];

                            if (BlockedList.Count() != 0)
                            {
                                for (int i = 0; i < BlockedList.Length; i++)
                                {
                                    int blockid = BlockedList[i];
                                    var BlockPlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(blockid);

                                    if (BlockPlayer != null)
                                    {
                                        OnPlayerBlockedYou_Invoker(BlockPlayer);
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            ModerationEventNotifier(Event, code, photon, sender, eventType, true);
            return true;
        }


        private static void ModerationEventNotifier(object data, byte code, Player photon, int sender, int EventType, bool isBlocked)
        {
            if (ConfigManager.General.LogEvents)
            {

                StringBuilder line = new StringBuilder();
                StringBuilder prefix = new StringBuilder();

                prefix.Append($"[Event ({code})] ");

                line.Append($"from: ({sender}) ");
                if (WorldUtils.IsInWorld && photon != null)
                {
                    line.Append($"'{photon.GetDisplayName()}'");
                }
                else
                {
                    line.Append($"'NULL' ");
                }
                string blockText = string.Empty;
                if (isBlocked)
                {
                    blockText = "[BLOCKED] : ";
                }
                PopupUtils.QueHudMessage($"{blockText}Moderation Event: {EventType}");
                if (ConfigManager.General.LogEvents)
                {
                    line.Append($"\n{Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented)}");
                    ModConsole.Log($"{blockText}{prefix.ToString()}{line.ToString()}");
                }
                line.Clear();
            }
        }
    



        private static void OnPlayerBlockedYou_Invoker(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();
            if (!BlockedYouPlayers.Contains(userID))
            {
                BlockedYouPlayers.Add(userID);
                ModConsole.Log($"{player.GetDisplayName()} blocked you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} blocked you!");
                Event_OnPlayerBlockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }
        }

        private static void OnPlayerUnblockedYou_Invoker(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();
            if (BlockedYouPlayers.Contains(userID))
            {
                BlockedYouPlayers.Remove(userID);
                ModConsole.Log($"{player.GetDisplayName()} unblocked you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} unblocked you!");
                Event_OnPlayerUnblockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }
        }

        private static void OnPlayerMutedYou_Invoker(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();

            if (!MutedYouPlayers.Contains(userID))
            {
                MutedYouPlayers.Add(userID);
                ModConsole.Log($"{player.GetDisplayName()} muted you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} muted you!");
                Event_OnPlayerMutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }

        }

        private static void OnPlayerUnmutedYou_Invoker(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();
            if (MutedYouPlayers.Contains(userID))
            {
                MutedYouPlayers.Remove(userID);
                ModConsole.Log($"{player.GetDisplayName()} unmuted you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} unmuted you!");
                Event_OnPlayerUnmutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }

        }

        #region PlayerModerations
        public override void OnRoomLeft()
        {
            BlockedYouPlayers.Clear();
            MutedYouPlayers.Clear();
        }

        public override void OnPhotonLeft(Player player)
        {
            var userID = player.GetUserID();
            if (BlockedYouPlayers.Contains(userID))
            {
                BlockedYouPlayers.Remove(userID);
            }
            if (MutedYouPlayers.Contains(userID))
            {
                MutedYouPlayers.Remove(userID);
            }
        }


        public static List<string> BlockedYouPlayers { get; private set; } = new List<string>();

        public static List<string> MutedYouPlayers { get; private set; } = new List<string>();

        #endregion PlayerModerations


    }
}
