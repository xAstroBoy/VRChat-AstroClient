namespace AstroClient
{
	using AstroClient.Cheetos;
	using AstroLibrary.Console;
	using DayClientML2.Utility.Extensions;
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
			// Create a timer with a two second interval.
			aTimer = new Timer(5000);
			// Hook up the Elapsed event for the timer.
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