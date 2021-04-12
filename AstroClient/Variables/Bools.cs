using AstroClient.ConsoleUtils;

namespace AstroClient.variables
{
    public class Bools
    {
        internal static bool DisableNSFWMenu = true;

#if CHEETOS
        private static bool _isDebugMode = true; 
#else
        private static bool _isDebugMode = false;
#endif


        internal static bool isDebugMode
        {
            get
            {
                return _isDebugMode;
            }
            set
            {
                _isDebugMode = value;
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

        internal static bool isCheetosMode
        {
            get
            {
#if DEBUG
                return true;
#endif
                return false;
            }
        }

        internal static bool SkipMenuChecks = true;

        // TOGGLE "Malicious" COMPONENTS
        internal static bool AllowOrbitComponent = true;

        internal static bool AllowAttackerComponent = true;

        internal static bool DisableBlackScreenFade = true;

        internal static bool SerializerEnabled;
    }
}