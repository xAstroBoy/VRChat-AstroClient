﻿namespace AstroClient.ClientUI.Menu.SettingsMenu
{
    #region Imports

    using Cheetos;
    using xAstroBoy.AstroButtonAPI;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_Performance : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Performance", "Performance Settings");

            QMToggleButton highPriorityToggle = new QMToggleButton(sub, 1, 0f, "Priority High", () => { HighPriority.IsEnabled = true; }, "Priority Normal", () => { HighPriority.IsEnabled = false; }, "Sets the process priority");
            highPriorityToggle.SetToggleState(HighPriority.IsEnabled, false);

            QMToggleButton frameUnlimiterToggle = new QMToggleButton(sub, 2, 0f, "FrameUnlimiter\nOn", () => { FrameUnlimiter.IsEnabled = true; }, "FrameUnlimiter\nOff", () => { FrameUnlimiter.IsEnabled = false; }, "Unlimit the games framerate");
            frameUnlimiterToggle.SetToggleState(FrameUnlimiter.IsEnabled, false);
        }
    }
}