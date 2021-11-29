namespace AstroClient.Moderation
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using AstroEventArgs;
    using Photon.Realtime;
    using Tools.Extensions;
    using xAstroBoy.Utility;

    #endregion

    internal class PhotonModerationHandler : AstroEvents
    {
        internal static void OnPlayerBlockedYou_Invoker(Player player)
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

        internal static void OnPlayerUnblockedYou_Invoker(Player player)
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

        internal static void OnPlayerMutedYou_Invoker(Player player)
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

        internal static void OnPlayerUnmutedYou_Invoker(Player player)
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

        #region EventHandlers

        internal static event EventHandler<PhotonPlayerEventArgs> Event_OnPlayerBlockedYou;
        internal static event EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnblockedYou;
        internal static event EventHandler<PhotonPlayerEventArgs> Event_OnPlayerMutedYou;
        internal static event EventHandler<PhotonPlayerEventArgs> Event_OnPlayerUnmutedYou;

        #endregion

        #region PlayerModerations

        internal override void OnRoomLeft()
        {
            BlockedYouPlayers.Clear();
            MutedYouPlayers.Clear();
        }

        internal override void OnPhotonLeft(Player player)
        {
            var photonuserid = player.GetUserID();
            if (BlockedYouPlayers.Contains(photonuserid)) BlockedYouPlayers.Remove(photonuserid);
            if (MutedYouPlayers.Contains(photonuserid)) MutedYouPlayers.Remove(photonuserid);
        }


        internal static List<string> BlockedYouPlayers { get; } = new();

        internal static List<string> MutedYouPlayers { get; } = new();

        #endregion PlayerModerations
    }
}