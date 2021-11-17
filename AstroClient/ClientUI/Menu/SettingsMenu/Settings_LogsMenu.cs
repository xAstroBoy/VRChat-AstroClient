namespace AstroClient.ClientUI.Menu.SettingsMenu
{
    #region Imports

    using Config;
    using xAstroBoy.AstroButtonAPI;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_LogsMenu : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Log Settings", "toggle Events Logs");

            QMToggleButton joinLeaveToggle = new QMToggleButton(sub, 2, 0, "Join/Leave", () => { ConfigManager.General.JoinLeave = true; }, () => { ConfigManager.General.JoinLeave = false; }, "Notification when someone joins/leaves");
            joinLeaveToggle.SetToggleState(ConfigManager.General.JoinLeave, false);

            QMToggleButton rpcLogToggle = new QMToggleButton(sub, 3, 0, "RPC Log", () => { ConfigManager.General.LogRPCEvents = true; }, () => { ConfigManager.General.LogRPCEvents = false; }, "Log RPC events to the console");
            rpcLogToggle.SetToggleState(ConfigManager.General.LogRPCEvents, false);

            QMToggleButton TriggerEventsLog = new QMToggleButton(sub, 4, 0.5f, "Trigger Log", () => { ConfigManager.General.LogTriggerEvents = true; }, () => { ConfigManager.General.LogTriggerEvents = false; }, "Log Udon RPC events to the console");
            TriggerEventsLog.SetToggleState(ConfigManager.General.LogTriggerEvents, false);

            QMToggleButton udonRPCToggle = new QMToggleButton(sub, 4, 0, "Udon Log", () => { ConfigManager.General.LogUdonEvents = true; }, () => { ConfigManager.General.LogUdonEvents = false; }, "Log Udon RPC events to the console");
            udonRPCToggle.SetToggleState(ConfigManager.General.LogUdonEvents, false);

            QMToggleButton eventLogTottle = new QMToggleButton(sub, 4, 0.5f, "Event Log", () => { ConfigManager.General.LogEvents = true; }, () => { ConfigManager.General.LogEvents = false; }, "Log Events to the console");
            eventLogTottle.SetToggleState(ConfigManager.General.LogEvents, false);
        }
    }
}