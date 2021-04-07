using RubyButtonAPI;
using UnityEngine;

namespace AstroClient.Startup.Buttons
{
    internal class SettingsMenuBtn
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            QMNestedButton sub = new QMNestedButton(menu, x, y, "Settings", "Settings", null, null, null, null, btnHalf);
            sub.getMainButton().setTextColor(Color.cyan);

            QMSingleToggleButton playerListToggle = new QMSingleToggleButton(sub, 1, 0, "PlayerList ON", () => { PlayerMenuUI.ShowPlayerMenu(); }, "PlayerList OFF", () => { PlayerMenuUI.HidePlayerMenu(); }, "Show/Hide PlayerList", Color.green, Color.red, null, ConfigManager.UI.ShowPlayersMenu, true);
            playerListToggle.setToggleState(ConfigManager.UI.ShowPlayersMenu, false);

            QMSingleToggleButton joinLeaveToggle = new QMSingleToggleButton(sub, 2, 0, "Join/Leave ON", () => { ConfigManager.General.JoinLeave = true; }, "Join/Leave OFF", () => { ConfigManager.General.JoinLeave = false; }, "Notification when someone joins/leaves", Color.green, Color.red, null, ConfigManager.General.JoinLeave, true);
            joinLeaveToggle.setToggleState(ConfigManager.General.JoinLeave, false);

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