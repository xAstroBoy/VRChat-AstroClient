﻿namespace AstroClient.Cheetos
{
    using System.Collections.Generic;
    using Config;
    using Photon.Realtime;
    using xAstroBoy.Utility;

    internal class JoinLeaveNotifier : AstroEvents
    {
        private static bool isReady;

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            isReady = false;
            MiscUtils.DelayFunction(5, () => { isReady = true; });
        }

        internal override void OnPhotonJoined(Player player)
        {
            ModConsole.Log($"[PHOTON] {player.GetDisplayName()} Joined!");

            if (ConfigManager.General.JoinLeave && isReady)
            {
                PopupUtils.QueHudMessage($"<color=cyan>[PHOTON]</color> {player.GetDisplayName()} <color=green>Joined</color>!");
            }
        }

        internal override void OnPhotonLeft(Player player)
        {
            ModConsole.Log($"[PHOTON] {player.GetDisplayName()} Left!");

            if (ConfigManager.General.JoinLeave && isReady)
            {
                PopupUtils.QueHudMessage($"<color=cyan>[PHOTON]</color> {player.GetDisplayName()} <color=red>Left</color>!");
            }
        }
    }
}