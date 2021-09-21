namespace AstroClient.Moderation
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using Photon.Realtime;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhotonModerationHandler : GameEvents
    {
        public override void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();
            if (!BlockedYouPlayers.Contains(userID))
            {
                BlockedYouPlayers.Add(userID);
                ModConsole.Log($"{player.GetDisplayName()} blocked you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} blocked you!");
            }
        }

        public override void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();
            if (BlockedYouPlayers.Contains(userID))
            {
                BlockedYouPlayers.Remove(userID);
                ModConsole.Log($"{player.GetDisplayName()} unblocked you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} unblocked you!");
            }
        }

        public override void OnPlayerMutedYou(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();

            if (!MutedYouPlayers.Contains(userID))
            {
                MutedYouPlayers.Add(userID);
                ModConsole.Log($"{player.GetDisplayName()} muted you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} muted you!");
            }

        }

        public override void OnPlayerUnmutedYou(Photon.Realtime.Player player)
        {
            string userID = player.GetUserID();
            if (MutedYouPlayers.Contains(userID))
            {
                MutedYouPlayers.Remove(userID);
                ModConsole.Log($"{player.GetDisplayName()} unmuted you!");
                PopupUtils.QueHudMessage($"{player.GetDisplayName()} unmuted you!");
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
