namespace AstroClient
{
    using DayClientML2.Utility.Extensions;
    using VRC;

    internal class JoinLeaveNotifier : GameEvents
    {
        public override void OnPlayerJoined(Player player)
        {
            if (ConfigManager.General.JoinLeave)
            {
                var uiManager = VRCUiManager.prop_VRCUiManager_0;
                PopupManager.QueHudMessage(uiManager, $"Join: {player.DisplayName()}");
            }
        }

        public override void OnPlayerLeft(Player player)
        {
            if (ConfigManager.General.JoinLeave)
            {
                var uiManager = VRCUiManager.prop_VRCUiManager_0;
                PopupManager.QueHudMessage(uiManager, $"Leave: {player.DisplayName()}");
            }
        }
    }
}
