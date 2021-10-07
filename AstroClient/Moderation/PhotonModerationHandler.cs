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
    using System;
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


        internal static void OnPlayerBlockedYou_Invoker(Photon.Realtime.Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();


                if (!BlockedYouPlayers.Contains(photonuserid))
                {
                    BlockedYouPlayers.Add(photonuserid);
                    Event_OnPlayerBlockedYou?.SafetyRaise(new PhotonPlayerEventArgs(player));
                }
            }

        }

        internal static void OnPlayerUnblockedYou_Invoker(Photon.Realtime.Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();

                if (BlockedYouPlayers.Contains(photonuserid))
                {
                    BlockedYouPlayers.Remove(photonuserid);
                    Event_OnPlayerUnblockedYou?.SafetyRaise(new PhotonPlayerEventArgs(player));
                }
            }

        }

        internal static void OnPlayerMutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();

                if (!MutedYouPlayers.Contains(photonuserid))
                {
                    MutedYouPlayers.Add(photonuserid);
                    Event_OnPlayerMutedYou?.SafetyRaise(new PhotonPlayerEventArgs(player));
                }
            }

        }

        internal static void OnPlayerUnmutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (player != null)
            {
                var photonuserid = player.GetUserID();

                if (MutedYouPlayers.Contains(photonuserid))
                {
                    MutedYouPlayers.Remove(photonuserid);
                    Event_OnPlayerUnmutedYou?.SafetyRaise(new PhotonPlayerEventArgs(player));
                }
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
            var photonuserid = player.GetUserID();
            if (BlockedYouPlayers.Contains(photonuserid))
            {
                BlockedYouPlayers.Remove(photonuserid);
            }
            if (MutedYouPlayers.Contains(photonuserid))
            {
                MutedYouPlayers.Remove(photonuserid);
            }
        }


        internal static List<string> BlockedYouPlayers { get; private set; } = new List<string>();

        internal static List<string> MutedYouPlayers { get; private set; } = new List<string>();

        #endregion PlayerModerations


    }
}
