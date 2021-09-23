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
    using System;
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






        public static void OnPlayerBlockedYou_Invoker(Photon.Realtime.Player player)
        {
            if (!BlockedYouPlayers.Contains(player))
            {
                Event_OnPlayerBlockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
                BlockedYouPlayers.Add(player);
            }
        }

        public static void OnPlayerUnblockedYou_Invoker(Photon.Realtime.Player player)
        {
            if (BlockedYouPlayers.Contains(player))
            {
                Event_OnPlayerUnblockedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
                BlockedYouPlayers.Remove(player);
            }
        }

        public static void OnPlayerMutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (!MutedYouPlayers.Contains(player))
            {
                Event_OnPlayerMutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
                MutedYouPlayers.Add(player);
            }

        }

        public static void OnPlayerUnmutedYou_Invoker(Photon.Realtime.Player player)
        {
            if (MutedYouPlayers.Contains(player))
            {
                Event_OnPlayerUnmutedYou.SafetyRaise(new PhotonPlayerEventArgs(player));
                MutedYouPlayers.Remove(player);
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
            if (BlockedYouPlayers.Contains(player))
            {
                BlockedYouPlayers.Remove(player);
            }
            if (MutedYouPlayers.Contains(player))
            {
                MutedYouPlayers.Remove(player);
            }
        }


        public static List<Player> BlockedYouPlayers { get; set; } = new List<Player>();

        public static List<Player> MutedYouPlayers { get; set; } = new List<Player>();

        #endregion PlayerModerations


    }
}
