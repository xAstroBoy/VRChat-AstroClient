namespace AstroClient.ClientUI.QuickMenuButtons
{
    #region Imports

    using System.Reflection;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using CheetoLibrary;
    using Variables;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_HideElements : GameEvents
    {

        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Hide Elements", "Hide Elements");

            QMToggleButton removeVRCPlusToggle = new QMToggleButton(sub, 1, 0, "Remove VRCPlus", () => { ConfigManager.UI.RemoveVRCPlus = true; }, "Keep VRCPlus", () => { ConfigManager.UI.RemoveVRCPlus = false; }, "Requires Restart");
            removeVRCPlusToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlus, false);

            QMToggleButton removeReportButtonToggle = new QMToggleButton(sub, 2, 0, "Remove ReportButton", () => { ConfigManager.UI.RemoveReportButton = true; }, "Keep ReportButton", () => { ConfigManager.UI.RemoveReportButton = false; }, "Requires Restart");
            removeReportButtonToggle.SetToggleState(ConfigManager.UI.RemoveReportButton, false);

            QMToggleButton removeUserIconButtonToggle = new QMToggleButton(sub, 3, 0, "Remove UserIconButton", () => { ConfigManager.UI.RemoveUserIconButton = true; }, "Keep UserIconButton", () => { ConfigManager.UI.RemoveUserIconButton = false; }, "Requires Restart");
            removeUserIconButtonToggle.SetToggleState(ConfigManager.UI.RemoveUserIconButton, false);

            QMToggleButton removeVRCPlusMiniBannerToggle = new QMToggleButton(sub, 4, 0, "Remove VRCPlusMiniBanner", () => { ConfigManager.UI.RemoveVRCPlusMiniBanner = true; }, "Keep VRCPlusMiniBanner", () => { ConfigManager.UI.RemoveVRCPlusMiniBanner = false; }, "Requires Restart");
            removeVRCPlusMiniBannerToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlusMiniBanner, false);

            QMToggleButton removeVRCPlusBannerToggle = new QMToggleButton(sub, 1, 1, "Remove VRCPlusBanner", () => { ConfigManager.UI.RemoveVRCPlusBanner = true; }, "Keep VRCPlusBanner", () => { ConfigManager.UI.RemoveVRCPlusBanner = false; }, "Requires Restart");
            removeVRCPlusBannerToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlusBanner, false);

            QMToggleButton removeUserIconCameraButtonToggle = new QMToggleButton(sub, 2, 1, "Remove UserIconCameraButton", () => { ConfigManager.UI.RemoveUserIconCameraButton = true; }, "Keep UserIconCameraButton", () => { ConfigManager.UI.RemoveUserIconCameraButton = false; }, "Requires Restart");
            removeUserIconCameraButtonToggle.SetToggleState(ConfigManager.UI.RemoveUserIconCameraButton, false);

            QMToggleButton removeVRCPlusThankYouToggle = new QMToggleButton(sub, 3, 1, "Remove VRCPlusThankYou", () => { ConfigManager.UI.RemoveVRCPlusThankYou = true; }, "Keep VRCPlusThankYou", () => { ConfigManager.UI.RemoveVRCPlusThankYou = false; }, "Requires Restart");
            removeVRCPlusThankYouToggle.SetToggleState(ConfigManager.UI.RemoveVRCPlusThankYou, false);

            QMToggleButton removeVRCPlusMenu = new QMToggleButton(sub, 4, 1, "Remove VRCPlusMenu", () => { ConfigManager.UI.RemoveVRCPlusMenu = true; }, "Keep VRCPlusMenu", () => { ConfigManager.UI.RemoveVRCPlusMenu = false; }, "Requires Restart");
            removeVRCPlusMenu.SetToggleState(ConfigManager.UI.RemoveVRCPlusMenu, false);

            QMToggleButton removeGalleryButton = new QMToggleButton(sub, 1, 2, "Remove GalleryButton", () => { ConfigManager.UI.RemoveGalleryButton = true; }, "Keep GalleryButton", () => { ConfigManager.UI.RemoveGalleryButton = false; }, "Requires Restart");
            removeGalleryButton.SetToggleState(ConfigManager.UI.RemoveGalleryButton, false);


        }
    }
}