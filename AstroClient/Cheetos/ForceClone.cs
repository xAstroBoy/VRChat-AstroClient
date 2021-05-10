namespace AstroClient.Cheetos
{
	using DayClientML2.Utility;
	using DayClientML2.Utility.Extensions;

	public static class ForceClone
	{
		internal static void ClonePlayer()
		{
			var player = QuickMenu.prop_QuickMenu_0.SelectedPlayer();

			if (player != null)
			{
				MiscFunc.ChangeAvatar(player.GetApiAvatar().id);
			}
		}
	}
}
