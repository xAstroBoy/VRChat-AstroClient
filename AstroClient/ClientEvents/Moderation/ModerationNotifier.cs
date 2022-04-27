namespace AstroClient.Moderation
{
    using Photon.Realtime;
    using xAstroBoy.Utility;

    internal class ModerationNotifier : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            
        }

        private void OnPlayerBlockedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} blocked you!");
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} blocked you!");
            }
        }

        private void OnPlayerUnblockedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} unblocked you!");
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} unblocked you!");
            }
        }

        private void OnPlayerMutedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} muted you!");
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} muted you!");
            }
        }

        private void OnPlayerUnmutedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} unmuted you!");
                PopupUtils.QueHudMessage($"{PhotonUtils.GetDisplayName(player)} unmuted you!");
            }
        }
    }
}