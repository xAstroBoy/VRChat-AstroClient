namespace AstroClient
{
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;

    internal class JoinLeaveNotifier : GameEvents
    {
        private static bool isReady = false;

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            isReady = false;
            MiscUtils.DelayFunction(5, () => { isReady = true; });
        }

        public override void OnPhotonJoined(Photon.Realtime.Player player)
        {
            if (player == null) throw new ArgumentNullException();
            ModConsole.Log($"[PHOTON] {player.GetDisplayName()} Joined!");

            if (ConfigManager.General.JoinLeave && isReady)
            {
                CheetosHelpers.SendHudNotification($"<color=cyan>[PHOTON]</color> {player.GetDisplayName()} <color=green>Joined</color>!");
            }
        }

        public override void OnPhotonLeft(Photon.Realtime.Player player)
        {
            if (player == null) { throw new ArgumentNullException(); }
            ModConsole.Log($"[PHOTON] {player.GetDisplayName()} Left!");

            if (ConfigManager.General.JoinLeave && isReady)
            {
                CheetosHelpers.SendHudNotification($"<color=cyan>[PHOTON]</color> {player.GetDisplayName()} <color=red>Left</color>!");
            }
        }
    }
}