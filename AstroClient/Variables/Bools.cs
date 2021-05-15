namespace AstroClient.variables
{
	using AstroLibrary.Console;

	public class Bools
	{
		internal static bool DisableNSFWMenu = true;

		internal static bool IsDeveloper;

		internal static bool IsDebugMode
		{
			get
			{
				return ConfigManager.General.DebugLog;
			}
			set
			{
				ConfigManager.General.DebugLog = value;
				if (Main.ToggleDebugInfo != null)
				{
					Main.ToggleDebugInfo.setToggleState(value);
				}
				if (value)
				{
					ModConsole.Log("Debug Info Enabled", System.Drawing.Color.Green);
				}
				else
				{
					ModConsole.Log("Debug Info disabled", System.Drawing.Color.Red);
				}
			}
		}

		internal static bool SkipMenuChecks = true;

		// TOGGLE "Malicious" COMPONENTS
		internal static bool AllowOrbitComponent = true;

		internal static bool AllowAttackerComponent = true;

		internal static bool DisableBlackScreenFade = true;

	}
}