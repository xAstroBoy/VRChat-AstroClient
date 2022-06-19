using AstroClient.Cheetos;
using AstroClient.Config;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.ClientUI.QuickMenuGUI.SettingsMenu
{
    #region Imports

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_Performance : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Performance", "Performance Settings");

            QMToggleButton highPriorityToggle = new QMToggleButton(sub, "Priority High", () => { HighPriority.IsEnabled = true; }, "Priority Normal", () => { HighPriority.IsEnabled = false; }, "Sets the process priority");
            highPriorityToggle.SetToggleState(HighPriority.IsEnabled, false);

            QMToggleButton frameUnlimiterToggle = new QMToggleButton(sub,  "FrameUnlimiter", () => { FrameUnlimiter.IsEnabled = true; }, () => { FrameUnlimiter.IsEnabled = false; }, "Unlimit the games framerate");
            frameUnlimiterToggle.SetToggleState(FrameUnlimiter.IsEnabled, false);

            QMToggleButton AllowPerformanceScanner = new QMToggleButton(sub, "Performance Scanner", () => { ConfigManager.Performance.AllowPerformanceScanner = true; }, () => { ConfigManager.Performance.AllowPerformanceScanner = false; }, "Disable VRChat Avatar Scanning.");
            AllowPerformanceScanner.SetToggleState(ConfigManager.Performance.AllowPerformanceScanner, false);

        }
    }
}