using RubyButtonAPI;
using UnityEngine;

namespace AstroClient.Startup.Buttons
{
	internal class SettingsMenuBtn
	{
		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			// Main Settings Menu
			QMNestedButton sub = new QMNestedButton(menu, x, y, "Settings", "Settings", null, null, null, null, btnHalf);
			sub.getMainButton().setTextColor(Color.cyan);

			QMSingleToggleButton playerListToggle = new QMSingleToggleButton(sub, 1, 0, "PlayerList ON", () => { PlayerMenuUI.ShowPlayerMenu(); }, "PlayerList OFF", () => { PlayerMenuUI.HidePlayerMenu(); }, "Show/Hide PlayerList", Color.green, Color.red, null, ConfigManager.UI.ShowPlayersMenu, true);
			playerListToggle.setToggleState(ConfigManager.UI.ShowPlayersMenu, false);

			QMSingleToggleButton joinLeaveToggle = new QMSingleToggleButton(sub, 2, 0, "Join/Leave ON", () => { ConfigManager.General.JoinLeave = true; }, "Join/Leave OFF", () => { ConfigManager.General.JoinLeave = false; }, "Notification when someone joins/leaves", Color.green, Color.red, null, ConfigManager.General.JoinLeave, true);
			joinLeaveToggle.setToggleState(ConfigManager.General.JoinLeave, false);

			QMSingleToggleButton rpcLogToggle = new QMSingleToggleButton(sub, 3, 0, "RPC Log ON", () => { ConfigManager.General.LogRPCEvents = true; }, "RPC Log OFF", () => { ConfigManager.General.LogRPCEvents = false; }, "Log RPC events to the console", Color.green, Color.red, null, ConfigManager.General.LogRPCEvents, true);
			rpcLogToggle.setToggleState(ConfigManager.General.LogRPCEvents, false);

			QMSingleToggleButton udonRPCToggle = new QMSingleToggleButton(sub, 4, 0, "Udon Log ON", () => { ConfigManager.General.LogUdonEvents = true; }, "Udon Log OFF", () => { ConfigManager.General.LogUdonEvents = false; }, "Log Udon RPC events to the console", Color.green, Color.red, null, ConfigManager.General.LogUdonEvents, true);
			udonRPCToggle.setToggleState(ConfigManager.General.LogUdonEvents, false);

			QMSingleToggleButton TriggerEventToggle = new QMSingleToggleButton(sub, 1, 0.5f, "Trigger Log ON", () => { ConfigManager.General.LogTriggerEvents = true; }, "Trigger Log OFF", () => { ConfigManager.General.LogTriggerEvents = false; }, "Log Udon RPC events to the console", Color.green, Color.red, null, ConfigManager.General.LogTriggerEvents, true);
			TriggerEventToggle.setToggleState(ConfigManager.General.LogTriggerEvents, false);

			QMSlider fovSlider = new QMSlider(sub, "FOV", 1, 2, delegate (float value) { FOV.Set_Camera_FOV(value); }, 61, 140, 20, true);

			// Hide Elements Menu
			QMNestedButton subHideElements = new QMNestedButton(sub, 1, 2f, "Hide Elements", "Hide Elements", null, null, null, null, false);
			sub.getMainButton().setTextColor(Color.cyan);

			QMToggleButton removeVRCPlusToggle = new QMToggleButton(subHideElements, 1, 0, "Remove VRCPlus", () => { ConfigManager.UI.RemoveVRCPlus = true; }, "Keep VRCPlus", () => { ConfigManager.UI.RemoveVRCPlus = false; }, "Requires Restart");
			removeVRCPlusToggle.setToggleState(ConfigManager.UI.RemoveVRCPlus, false);

			QMToggleButton removeReportButtonToggle = new QMToggleButton(subHideElements, 2, 0, "Remove ReportButton", () => { ConfigManager.UI.RemoveReportButton = true; }, "Keep ReportButton", () => { ConfigManager.UI.RemoveReportButton = false; }, "Requires Restart");
			removeReportButtonToggle.setToggleState(ConfigManager.UI.RemoveReportButton, false);

			QMToggleButton removeUserIconButtonToggle = new QMToggleButton(subHideElements, 3, 0, "Remove UserIconButton", () => { ConfigManager.UI.RemoveUserIconButton = true; }, "Keep UserIconButton", () => { ConfigManager.UI.RemoveUserIconButton = false; }, "Requires Restart");
			removeUserIconButtonToggle.setToggleState(ConfigManager.UI.RemoveUserIconButton, false);

			QMToggleButton removeVRCPlusMiniBannerToggle = new QMToggleButton(subHideElements, 4, 0, "Remove VRCPlusMiniBanner", () => { ConfigManager.UI.RemoveVRCPlusMiniBanner = true; }, "Keep VRCPlusMiniBanner", () => { ConfigManager.UI.RemoveVRCPlusMiniBanner = false; }, "Requires Restart");
			removeVRCPlusMiniBannerToggle.setToggleState(ConfigManager.UI.RemoveVRCPlusMiniBanner, false);

			QMToggleButton removeVRCPlusBannerToggle = new QMToggleButton(subHideElements, 1, 1, "Remove VRCPlusBanner", () => { ConfigManager.UI.RemoveVRCPlusBanner = true; }, "Keep VRCPlusBanner", () => { ConfigManager.UI.RemoveVRCPlusBanner = false; }, "Requires Restart");
			removeVRCPlusBannerToggle.setToggleState(ConfigManager.UI.RemoveVRCPlusBanner, false);

			QMToggleButton removeUserIconCameraButtonToggle = new QMToggleButton(subHideElements, 2, 1, "Remove UserIconCameraButton", () => { ConfigManager.UI.RemoveUserIconCameraButton = true; }, "Keep UserIconCameraButton", () => { ConfigManager.UI.RemoveUserIconCameraButton = false; }, "Requires Restart");
			removeUserIconCameraButtonToggle.setToggleState(ConfigManager.UI.RemoveUserIconCameraButton, false);

			QMToggleButton removeVRCPlusThankYouToggle = new QMToggleButton(subHideElements, 3, 1, "Remove VRCPlusThankYou", () => { ConfigManager.UI.RemoveVRCPlusThankYou = true; }, "Keep VRCPlusThankYou", () => { ConfigManager.UI.RemoveVRCPlusThankYou = false; }, "Requires Restart");
			removeVRCPlusThankYouToggle.setToggleState(ConfigManager.UI.RemoveVRCPlusThankYou, false);
		}
	}
}