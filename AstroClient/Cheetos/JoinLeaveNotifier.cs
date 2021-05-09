namespace AstroClient
{
	using AstroClient.Cheetos;
	using AstroClient.ConsoleUtils;
	using DayClientML2.Utility.Extensions;
	using System.Timers;
	using VRC;

	internal class JoinLeaveNotifier : GameEvents
	{
		private static System.Timers.Timer aTimer;

		private static bool isReady = false;

		public override void OnWorldReveal(string id, string Name, string AssetURL)
		{
			SetTimer();
			isReady = false;
		}

		private static void SetTimer()
		{
			// Create a timer with a two second interval.
			aTimer = new System.Timers.Timer(5000);
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
				CheetosHelpers.SendHudNotification($"<color=cyan>Photon Join</color>: {player?.GetUsername()}");
			}
		}

		public override void OnPhotonLeft(Photon.Realtime.Player player)
		{
			ModConsole.Log($"[PHOTON] {player.GetDisplayName()} Left!");

			if (ConfigManager.General.JoinLeave && isReady)
			{
				CheetosHelpers.SendHudNotification($"<color=cyan>Photon Leave</color>: {player?.GetUsername()}");
			}
		}
	}
}