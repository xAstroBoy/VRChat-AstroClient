using AstroClient.Cheetos;
using DayClientML2.Utility.Extensions;
using VRC;

namespace AstroClient
{
	internal class JoinLeaveNotifier : GameEvents
	{
		public override void OnPlayerJoined(Player player)
		{
			if (ConfigManager.General.JoinLeave)
			{
				CheetosHelpers.SendHudNotification($"Join: {player.DisplayName()}");
			}
		}

		public override void OnPlayerLeft(Player player)
		{
			if (ConfigManager.General.JoinLeave)
			{
				CheetosHelpers.SendHudNotification($"Leave: {player.DisplayName()}");
			}
		}
	}
}