namespace AstroClient
{
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System.Collections.Generic;
    using System.Timers;

    internal class JoinLeaveNotifier : GameEvents
    {
        private static Timer aTimer;

        private static bool isReady = false;

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            SetTimer();
            isReady = false;
        }

        private static void SetTimer()
        {
            aTimer = new Timer(5000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            isReady = true;
        }

        public override void OnPhotonJoined(Photon.Realtime.Player player)
        {
            ModConsole.Log($"[PHOTON] {player.GetDisplayName()} Joined!");

            if (ConfigManager.General.JoinLeave && isReady)
            {
                CheetosHelpers.SendHudNotification($"<color=cyan>[PHOTON]</color> {player.GetDisplayName()} <color=green>Joined</color>!");
            }
        }

        public override void OnPhotonLeft(Photon.Realtime.Player player)
        {
            ModConsole.Log($"[PHOTON] {player.GetDisplayName()} Left!");

            if (ConfigManager.General.JoinLeave && isReady)
            {
                CheetosHelpers.SendHudNotification($"<color=cyan>[PHOTON]</color> {player.GetDisplayName()} <color=red>Left</color>!");
            }
        }
    }
}