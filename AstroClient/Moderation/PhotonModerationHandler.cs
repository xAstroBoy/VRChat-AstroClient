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
            if (!BlockedYouPlayers.Contains(player))
            {
                Event_OnPlayerBlockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
                BlockedYouPlayers.Add(player);
            }
        }

        internal static void OnPlayerUnblockedYou_Invoker(Photon.Realtime.Player player)
        {
            if (BlockedYouPlayers.Contains(player))

                Event_OnPlayerUnblockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));            {
                BlockedYouPlayers.Remove(player);
            }
        }

        internal static void OnPlayerMutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (!MutedYouPlayers.Contains(player))
            {
                MutedYouPlayers.Add(player);
                Event_OnPlayerMutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
            }

        }

        internal static void OnPlayerUnmutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (MutedYouPlayers.Contains(player))
            {
                Event_OnPlayerUnmutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
                MutedYouPlayers.Remove(player);
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
