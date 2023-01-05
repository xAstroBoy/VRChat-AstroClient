using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;

namespace AstroClient.Moderation
{
    using Photon.Realtime;
    using xAstroBoy.Utility;

    internal class ModerationNotifier : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerBlockedYou += OnPlayerBlockedYou;
            ClientEventActions.OnPlayerUnblockedYou += OnPlayerUnblockedYou;
            ClientEventActions.OnPlayerMutedYou += OnPlayerMutedYou;
            ClientEventActions.OnPlayerUnmutedYou += OnPlayerUnmutedYou;

        }

        private void OnPlayerBlockedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} blocked you!");
                NewHudNotifier.WriteHudMessage($"{PhotonUtils.GetDisplayName(player)} blocked you!");
            }
        }

        private void OnPlayerUnblockedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} unblocked you!");
                NewHudNotifier.WriteHudMessage($"{PhotonUtils.GetDisplayName(player)} unblocked you!");
            }
        }

        private void OnPlayerMutedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} muted you!");
                NewHudNotifier.WriteHudMessage($"{PhotonUtils.GetDisplayName(player)} muted you!");
            }
        }

        private void OnPlayerUnmutedYou(Player player)
        {
            if (player != null)
            {
                Log.Write($"{PhotonUtils.GetDisplayName(player)} unmuted you!");
                NewHudNotifier.WriteHudMessage($"{PhotonUtils.GetDisplayName(player)} unmuted you!");
            }
        }
    }
}