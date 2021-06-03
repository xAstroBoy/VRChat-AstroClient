namespace AstroClient.Startup.Buttons
{
	#region Imports

	using AstroClient.variables;
	using RubyButtonAPI;

	#endregion Imports

	public class AdminMenu : GameEvents
	{
		public static QMTabMenu SubMenu { get; private set; }

		public static void InitButtons(float pos)
		{
			if (Bools.IsDeveloper)
			{
				SubMenu = new QMTabMenu(pos, "Admin Menu", null, null, null, "AstroClient.Resources.badge.png");
			}
		}
	}
}