﻿namespace AstroClient.Moderation
{
    using Photon.Realtime;
    using xAstroBoy.Utility;

    internal class ModerationNotifier : AstroEvents
    {
        internal override void OnPlayerBlockedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log($"{PhotonUtils.GetDisplayName(player)} blocked you!", null);
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} blocked you!");
            }
        }

        internal override void OnPlayerUnblockedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log($"{PhotonUtils.GetDisplayName(player)} unblocked you!", null);
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} unblocked you!");
            }
        }

        internal override void OnPlayerMutedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log($"{PhotonUtils.GetDisplayName(player)} muted you!", null);
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} muted you!");
            }
        }

        internal override void OnPlayerUnmutedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log($"{PhotonUtils.GetDisplayName(player)} unmuted you!", null);
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} unmuted you!");
            }
        }
    }
}