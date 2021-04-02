namespace AstroClient.Cheetos
{
    using DayClientML2.Utility.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC;

    internal class JoinLeaveNotifier : Overridables
    {
        public static bool Enabled = false;

        // Perhaps a sound would be nice

        public override void OnPlayerJoined(Player player)
        {
            if (Enabled)
            {
                var uiManager = VRCUiManager.prop_VRCUiManager_0;
                PopupManager.QueHudMessage(uiManager, $"Join: {player.DisplayName()}");
            }
        }

        public override void OnPlayerLeft(Player player)
        {
            if (Enabled)
            {
                var uiManager = VRCUiManager.prop_VRCUiManager_0;
                PopupManager.QueHudMessage(uiManager, $"Leave: {player.DisplayName()}");
            }
        }
    }
}
