namespace AstroClient.Moderation
{
    #region Imports

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

    #endregion

    internal class PhotonModerationHandler : GameEvents
    {
        #region EventHandlers
        internal static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerBlockedYou;
        internal static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnblockedYou;
        internal static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerMutedYou;
        internal static event System.EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnmutedYou;
        #endregion

        internal static void Handle_Photon_ModerationEvent_NeedToBlock(object RawData, byte code, Player PhotonSender, int PhotonID)
        {
            try
            {
                var parsedData = (RawData as Dictionary<byte, object>);
                var infoData = parsedData[245] as Dictionary<byte, object>;
                int eventType = int.Parse(infoData[0].ToString());
                if (eventType == 21)
                {
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
                                    infoData[10] = false;
                                    ModerationEventNotifier(RawData, code, PhotonPlayer, SenderID, eventType, true);
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

                                    if (!BlockedYouPlayers.Contains(BlockPlayer))
                                    {
                                        BlockedYouPlayers.Add(BlockPlayer);
                                    }
                                    blockid = -1;
                                }
                            }

                            if (MuteList.Count() != 0)
                            {
                                for (int i = 0; i < MuteList.Length; i++)
                                {
                                    int MuteID = MuteList[i];
                                    var MutePlayer = Utils.LoadBalancingPeer.GetPhotonPlayer(MuteID);

                                    if (!MutedYouPlayers.Contains(MutePlayer))
                                    {
                                        MutedYouPlayers.Add(MutePlayer);
                                    }
                                }
                            }


                        }
                    }
                }
                ModerationEventNotifier(RawData, code, PhotonSender, PhotonID, eventType, false);
            }
            catch (System.Exception e)
            {
                ModConsole.DebugError("Error in Photon Moderation EventHandler : ");
                ModConsole.DebugErrorExc(e);
            }
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
                    blockText = "[PATCHED] : ";
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
            if (!BlockedYouPlayers.Contains(player))
            {
                BlockedYouPlayers.Add(player);
                Event_OnPlayerBlockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }
        }

        private static void OnPlayerUnblockedYou_Invoker(Photon.Realtime.Player player)
        {
            if (BlockedYouPlayers.Contains(player))
            {
                BlockedYouPlayers.Remove(player);
                Event_OnPlayerUnblockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }
        }

        private static void OnPlayerMutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (!MutedYouPlayers.Contains(player))
            {
                MutedYouPlayers.Add(player);
                Event_OnPlayerMutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }

        }

        private static void OnPlayerUnmutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (MutedYouPlayers.Contains(player))
            {
                MutedYouPlayers.Remove(player);
                Event_OnPlayerUnmutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }

        }

        #region PlayerModerations
        internal override void OnRoomLeft()
        {
            BlockedYouPlayers.Clear();
            MutedYouPlayers.Clear();
        }

        internal override void OnPhotonLeft(Player player)
        {
            if (BlockedYouPlayers.Contains(player))
            {
                BlockedYouPlayers.Remove(player);
            }
            if (MutedYouPlayers.Contains(player))
            {
                MutedYouPlayers.Remove(player);
            }
        }


        internal static List<Player> BlockedYouPlayers { get; private set; } = new List<Player>();

        internal static List<Player> MutedYouPlayers { get; private set; } = new List<Player>();

        #endregion PlayerModerations


    }
}
