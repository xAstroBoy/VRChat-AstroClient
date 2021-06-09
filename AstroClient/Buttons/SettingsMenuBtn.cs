namespace AstroClient.Startup.Buttons
{
	using AstroClient.Cheetos;
	using AstroLibrary;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System.Diagnostics;
	using UnityEngine;

	internal class SettingsMenuBtn
    {
        public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            // Main Settings Menu
            QMNestedButton sub = new QMNestedButton(menu, x, y, "Settings", "Settings", null, null, null, null, btnHalf);
            sub.GetMainButton().SetTextColor(Color.cyan);

            QMSingleButton saveButton = new QMSingleButton(sub, 0, 0, "Force Save", () => { ConfigManager.Save_All(); }, "Save Config", Color.magenta, null, true);

            QMSingleToggleButton playerListToggle = new QMSingleToggleButton(sub, 1, 0, "PlayerList ON", () => { PlayerList.ShowPlayerMenu(); }, "PlayerList OFF", () => { PlayerList.HidePlayerMenu(); }, "Show/Hide PlayerList", Color.green, Color.red, null, ConfigManager.UI.ShowPlayersMenu, true);
            playerListToggle.SetToggleState(ConfigManager.UI.ShowPlayersMenu, false);

            QMSingleToggleButton joinLeaveToggle = new QMSingleToggleButton(sub, 2, 0, "Join/Leave ON", () => { ConfigManager.General.JoinLeave = true; }, "Join/Leave OFF", () => { ConfigManager.General.JoinLeave = false; }, "Notification when someone joins/leaves", Color.green, Color.red, null, ConfigManager.General.JoinLeave, true);
            joinLeaveToggle.SetToggleState(ConfigManager.General.JoinLeave, false);

            QMSingleToggleButton rpcLogToggle = new QMSingleToggleButton(sub, 3, 0, "RPC Log ON", () => { ConfigManager.General.LogRPCEvents = true; }, "RPC Log OFF", () => { ConfigManager.General.LogRPCEvents = false; }, "Log RPC events to the console", Color.green, Color.red, null, ConfigManager.General.LogRPCEvents, true);
            rpcLogToggle.SetToggleState(ConfigManager.General.LogRPCEvents, false);

            QMSingleToggleButton udonRPCToggle = new QMSingleToggleButton(sub, 4, 0, "Udon Log ON", () => { ConfigManager.General.LogUdonEvents = true; }, "Udon Log OFF", () => { ConfigManager.General.LogUdonEvents = false; }, "Log Udon RPC events to the console", Color.green, Color.red, null, ConfigManager.General.LogUdonEvents, true);
            udonRPCToggle.SetToggleState(ConfigManager.General.LogUdonEvents, false);

            QMSingleToggleButton processPriorityToggle = new QMSingleToggleButton(sub, 4, 2.5f, "Priority High", () => { Priority.CurrentPriority = ProcessPriorityClass.High; }, "Priority Normal", () => { Priority.CurrentPriority = ProcessPriorityClass.Normal; }, "Sets the process priority", Color.green, Color.red, null, Priority.CurrentPriority == ProcessPriorityClass.High, true);
            processPriorityToggle.SetToggleState(Priority.CurrentPriority == ProcessPriorityClass.High, false);

            QMSingleToggleButton TriggerEventToggle = new QMSingleToggleButton(sub, 1, 0.5f, "Trigger Log ON", () => { ConfigManager.General.LogTriggerEvents = true; }, "Trigger Log OFF", () => { ConfigManager.General.LogTriggerEvents = false; }, "Log Udon RPC events to the console", Color.green, Color.red, null, ConfigManager.General.LogTriggerEvents, true);
            TriggerEventToggle.SetToggleState(ConfigManager.General.LogTriggerEvents, false);

            QMNestedButton cameraSettings = new QMNestedButton(sub, 2, 2, "Camera", "Camera", null, null, null, null, false);
            QMSlider fovSlider = new QMSlider(Utils.QuickMenu.transform.Find(cameraSettings.GetMenuName()), "FOV", 400, -620, delegate (float value) { FOV.Set_Camera_FOV(value); }, ConfigManager.General.FOV, 140, 20, true);
            fovSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            QMSlider farClipPlaneSlider = new QMSlider(Utils.QuickMenu.transform.Find(cameraSettings.GetMenuName()), "FarClipPlane", 400, -820, delegate (float value) { CLIPPING.Set_Camera_FarClipPlane(value); }, ConfigManager.General.FarClipPlane, 9000, 1, true);
            farClipPlaneSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

            // Hide Elements Menu
            QMNestedButton subHideElements = new QMNestedButton(sub, 1, 2f, "Hide Elements", "Hide Elements", null, null, null, null, false);
            sub.GetMainButton().SetTextColor(Color.cyan);

            QMToggleButton removeVRCPlusToggle = new QMToggleButton(subHideElements, 1, 0, "Remove VRCPlus", () => { ConfigManager.UI.RemoveVRCPlus = true; }, "Keep VRCPlus", () => { ConfigManager.UI.RemoveVRCPlus = false; }, "Requires Restart");
            removeVRCPlusToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlus, false);

            QMToggleButton removeReportButtonToggle = new QMToggleButton(subHideElements, 2, 0, "Remove ReportButton", () => { ConfigManager.UI.RemoveReportButton = true; }, "Keep ReportButton", () => { ConfigManager.UI.RemoveReportButton = false; }, "Requires Restart");
            removeReportButtonToggle.SetToggleState(ConfigManager.UI.RemoveReportButton, false);

            QMToggleButton removeUserIconButtonToggle = new QMToggleButton(subHideElements, 3, 0, "Remove UserIconButton", () => { ConfigManager.UI.RemoveUserIconButton = true; }, "Keep UserIconButton", () => { ConfigManager.UI.RemoveUserIconButton = false; }, "Requires Restart");
            removeUserIconButtonToggle.SetToggleState(ConfigManager.UI.RemoveUserIconButton, false);

            QMToggleButton removeVRCPlusMiniBannerToggle = new QMToggleButton(subHideElements, 4, 0, "Remove VRCPlusMiniBanner", () => { ConfigManager.UI.RemoveVRCPlusMiniBanner = true; }, "Keep VRCPlusMiniBanner", () => { ConfigManager.UI.RemoveVRCPlusMiniBanner = false; }, "Requires Restart");
            removeVRCPlusMiniBannerToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlusMiniBanner, false);

            QMToggleButton removeVRCPlusBannerToggle = new QMToggleButton(subHideElements, 1, 1, "Remove VRCPlusBanner", () => { ConfigManager.UI.RemoveVRCPlusBanner = true; }, "Keep VRCPlusBanner", () => { ConfigManager.UI.RemoveVRCPlusBanner = false; }, "Requires Restart");
            removeVRCPlusBannerToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlusBanner, false);

            QMToggleButton removeUserIconCameraButtonToggle = new QMToggleButton(subHideElements, 2, 1, "Remove UserIconCameraButton", () => { ConfigManager.UI.RemoveUserIconCameraButton = true; }, "Keep UserIconCameraButton", () => { ConfigManager.UI.RemoveUserIconCameraButton = false; }, "Requires Restart");
            removeUserIconCameraButtonToggle.SetToggleState(ConfigManager.UI.RemoveUserIconCameraButton, false);

            QMToggleButton removeVRCPlusThankYouToggle = new QMToggleButton(subHideElements, 3, 1, "Remove VRCPlusThankYou", () => { ConfigManager.UI.RemoveVRCPlusThankYou = true; }, "Keep VRCPlusThankYou", () => { ConfigManager.UI.RemoveVRCPlusThankYou = false; }, "Requires Restart");
            removeVRCPlusThankYouToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlusThankYou, false);

            QMToggleButton removeVRCPlusMenu = new QMToggleButton(subHideElements, 4, 1, "Remove VRCPlusMenu", () => { ConfigManager.UI.RemoveVRCPlusMenu = true; }, "Keep VRCPlusMenu", () => { ConfigManager.UI.RemoveVRCPlusMenu = false; }, "Requires Restart");
            removeVRCPlusMenu.SetToggleState(ConfigManager.UI.RemoveVRCPlusMenu, false);

			QMToggleButton removeGalleryButton = new QMToggleButton(subHideElements, 1, 2, "Remove GalleryButton", () => { ConfigManager.UI.RemoveGalleryButton = true; }, "Keep GalleryButton", () => { ConfigManager.UI.RemoveGalleryButton = false; }, "Requires Restart");
			removeGalleryButton.SetToggleState(ConfigManager.UI.RemoveGalleryButton, false);

			QMNestedButton subSpoofButton = new QMNestedButton(sub, 3, 2f, "Spoofs", "Spoof Menu", null, null, null, null, false);

			QMSingleToggleButton toggleSpoofFPS = new QMSingleToggleButton(subSpoofButton, 1, 0, "FPS Spoof", () => { ConfigManager.General.SpoofFPS = true; }, "FPS Spoof", () => { ConfigManager.General.SpoofFPS = false; }, "Toggle FPS Spoofing", Color.green, Color.red, null, ConfigManager.General.SpoofFPS, false);
			toggleSpoofFPS.SetToggleState(ConfigManager.General.SpoofFPS, false);

			QMSingleToggleButton toggleSpoofPing = new QMSingleToggleButton(subSpoofButton, 2, 0, "Ping Spoof", () => { ConfigManager.General.SpoofPing = true; }, "Ping Spoof", () => { ConfigManager.General.SpoofPing = false; }, "Toggle Ping Spoofing", Color.green, Color.red, null, ConfigManager.General.SpoofPing, false);
			toggleSpoofPing.SetToggleState(ConfigManager.General.SpoofPing, false);

			new QMSingleButton(subSpoofButton, 1, 1, "Set\nFPS\nValue", () =>
			{
				CheetosHelpers.PopupCall("Set FPS Value", "Done", "Enter FPS. . .", true, delegate (string text)
				{
					float value = 0f;

					try
					{
						value = float.Parse(text);
					}
					catch
					{
						ModConsole.Error("Input value must be a float value!");
					}
					finally
					{
						ConfigManager.General.SpoofedFPS = value;
					}
				});
			}, "Input an FPS value");

			new QMSingleButton(subSpoofButton, 2, 1, "Set\nPing\nValue", () =>
			{
				CheetosHelpers.PopupCall("Set Ping Value", "Done", "Enter Ping. . .", true, delegate (string text)
				{
					short value = 0;

					try
					{
						value = short.Parse(text);
					}
					catch
					{
						ModConsole.Error("Input value must be a short value!");
					}
					finally
					{
						ConfigManager.General.SpoofedPing = value;
					}
				});
			}, "Input a Ping value");
		}
	}
}