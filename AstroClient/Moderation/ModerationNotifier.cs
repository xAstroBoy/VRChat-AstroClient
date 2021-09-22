using AstroLibrary.Console;
using AstroLibrary.Utility;
using Photon.Realtime;

namespace AstroClient.Moderation
{
    public class ModerationNotifier : GameEvents
    {
        public override void OnPlayerBlockedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log(PhotonUtils.GetDisplayName(player) + " blocked you!", null);
                PopupUtils.QueHudMessage(PhotonUtils.GetDisplayName(player) + " blocked you!");
            }
        }

        public override void OnPlayerUnblockedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log(PhotonUtils.GetDisplayName(player) + " unblocked you!", null);
                PopupUtils.QueHudMessage(PhotonUtils.GetDisplayName(player) + " unblocked you!");
            }
        }

        public override void OnPlayerMutedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log(PhotonUtils.GetDisplayName(player) + " muted you!", null);
                PopupUtils.QueHudMessage(PhotonUtils.GetDisplayName(player) + " muted you!");
            }
        }

        public override void OnPlayerUnmutedYou(Player player)
        {
            if (player != null)
            {
                ModConsole.Log(PhotonUtils.GetDisplayName(player) + " unmuted you!", null);
                PopupUtils.QueHudMessage(PhotonUtils.GetDisplayName(player) + " unmuted you!");
            }
        }
    }
}