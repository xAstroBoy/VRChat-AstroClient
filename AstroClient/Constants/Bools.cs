using AstroClient.ClientUI.QuickMenuGUI;
using AstroClient.ClientUI.QuickMenuGUI.Wings;

namespace AstroClient.Constants
{
    using Config;

    internal class Bools
    {
        internal static bool AntiPortal{ get; set; }

        internal static bool BlockRPC{ get; set; }

        internal static bool BlockUdon{ get; set; }

        internal static bool IsDeveloperAndDebug
        {
            get
            {
                return IsDeveloper && IsDebugMode;
            }
        }

        internal static bool IsDeveloper { get; set; } = true;

        internal static bool IsBetaTester{ get; set; }

        internal static bool IsDebugMode
        {
            get
            {
                return ConfigManager.General.DebugLog;
            }
            set
            {
                Log.DebugMode = value;
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
                    Log.Write("Debug Info Enabled", System.Drawing.Color.Green);
                }
                else
                {
                    Log.Write("Debug Info disabled", System.Drawing.Color.Red);
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