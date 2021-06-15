namespace AstroClient.Startup.Buttons
{
	#region Imports

	using AstroClient.Variables;
	using AstroLibrary;
	using RubyButtonAPI;
	using System.Reflection;

	#endregion Imports

	public class AdminMenu : GameEvents
    {
        public static QMTabMenu SubMenu { get; private set; }

        public static void InitButtons(float pos)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(pos, "Admin Menu", null, null, null, CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.badge.png"));
            }
        }
    }
}