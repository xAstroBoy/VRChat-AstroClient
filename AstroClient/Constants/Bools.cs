namespace AstroClient.Constants
{
    using ClientUI.Menu;
    using ClientUI.Menu.Wings;
    using Config;

    internal class Bools
    {
        internal static bool AntiPortal;

        internal static bool BlockRPC;

        internal static bool BlockUdon;

        internal static bool IsDeveloperAndDebug
        {
            get
            {
                return IsDeveloper && IsDebugMode;
            }
        }

        internal static bool IsDeveloper;

        internal static bool IsBetaTester;

        internal static bool IsDebugMode
        {
            get
            {
                return ConfigManager.General.DebugLog;
            }
            set
            {
                ModConsole.DebugMode = value;
                ConfigManager.General.DebugLog = value;
                if (UIInitializer.ToggleDebugInfo != null)
                {
                    UIInitializer.ToggleDebugInfo.SetToggleState(value);
                }

                if (MainClientWings.WingDebugButton != null)
                {
                    MainClientWings.WingDebugButton.SetToggleState(value);
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