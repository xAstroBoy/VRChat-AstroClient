using AstroClient.ClientActions;
using AstroClient.Config;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.ClientUI.QuickMenuGUI.SettingsMenu
{
    #region Imports

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_LogsMenu : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Log Settings", "toggle Events Logs");

            QMToggleButton joinLeaveToggle = new QMToggleButton(sub,  "Join/Leave", () =>
            {
                ConfigManager.General.JoinLeave = true;
                ConfigEventActions.JoinLeaveNotifier_PropertyChanged.SafetyRaiseWithParams(true);

            }, () =>
            {
                ConfigManager.General.JoinLeave = false;
                ConfigEventActions.JoinLeaveNotifier_PropertyChanged.SafetyRaiseWithParams(false);
            }, "Notification when someone joins/leaves");

            joinLeaveToggle.SetToggleState(ConfigManager.General.JoinLeave, false);

            QMToggleButton rpcLogToggle = new QMToggleButton(sub,  "RPC Log", () => { ConfigManager.General.LogRPCEvents = true; }, () => { ConfigManager.General.LogRPCEvents = false; }, "Log RPC events to the console");
            rpcLogToggle.SetToggleState(ConfigManager.General.LogRPCEvents, false);

            QMToggleButton TriggerEventsLog = new QMToggleButton(sub,  "Trigger Log", () => { ConfigManager.General.LogTriggerEvents = true; }, () => { ConfigManager.General.LogTriggerEvents = false; }, "Log Udon RPC events to the console");
            TriggerEventsLog.SetToggleState(ConfigManager.General.LogTriggerEvents, false);

            QMToggleButton udonRPCToggle = new QMToggleButton(sub,  "Udon Log", () => { ConfigManager.General.LogUdonEvents = true; }, () => { ConfigManager.General.LogUdonEvents = false; }, "Log Udon RPC events to the console");
            udonRPCToggle.SetToggleState(ConfigManager.General.LogUdonEvents, false);

            QMToggleButton UdonCustomEventsToggle = new QMToggleButton(sub, "Udon Custom Events Log", () => { ConfigManager.General.LogUdonCustomEvents = true; }, () => { ConfigManager.General.LogUdonCustomEvents = false; }, "Log Udon Custom Events to the console");
            UdonCustomEventsToggle.SetToggleState(ConfigManager.General.LogUdonCustomEvents, false);

            QMToggleButton UdonCustomRPCToggle = new QMToggleButton(sub, "Udon Custom Program RPC Log", () => { ConfigManager.General.LogUdonProgramRPCvents = true; }, () => { ConfigManager.General.LogUdonProgramRPCvents = false; }, "Log Udon Custom RPC to the console");
            UdonCustomRPCToggle.SetToggleState(ConfigManager.General.LogUdonProgramRPCvents, false);

            QMToggleButton UnityLogsToggle = new QMToggleButton(sub, "Unity Messages", () => { ConfigManager.General.LogUnityMessages = true; }, () => { ConfigManager.General.LogUnityMessages = false; }, "Log Unity Messages to the console");
            UnityLogsToggle.SetToggleState(ConfigManager.General.LogUnityMessages, false);

            QMToggleButton UnityWarningsToggle = new QMToggleButton(sub, "Unity Warnings", () => { ConfigManager.General.LogUnityWarnings = true; }, () => { ConfigManager.General.LogUnityWarnings = false; }, "Log Unity Warnings Messages to the console");
            UnityWarningsToggle.SetToggleState(ConfigManager.General.LogUnityWarnings, false);

            QMToggleButton UnityErrorsToggle = new QMToggleButton(sub, "Unity Errors", () => { ConfigManager.General.LogUnityErrors = true; }, () => { ConfigManager.General.LogUnityErrors = false; }, "Log Unity Errors Messages to the console");
            UnityErrorsToggle.SetToggleState(ConfigManager.General.LogUnityErrors, false);

            QMToggleButton EventLogToggle = new QMToggleButton(sub,  "Event Log", () => { ConfigManager.General.LogEvents = true; }, () => { ConfigManager.General.LogEvents = false; }, "Log Events to the console");
            EventLogToggle.SetToggleState(ConfigManager.General.LogEvents, false);


        }

    }
}