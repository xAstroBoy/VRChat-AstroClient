namespace AstroClient.ClientUI.Menu.SettingsMenu
{
    #region Imports

    using System.Collections.Generic;
    using Cheetos.CameraStuff;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;
    using xAstroBoy.UIPaths;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_Camera : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Camera", "Camera");

            fovSlider = new QMSlider(sub.ButtonsMenu.transform, "FOV", delegate (float value) { FOV.Set_Camera_FOV(value); }, "Adjust FOV", 140, 20, true, true);
            farClipPlaneSlider = new QMSlider(sub.ButtonsMenu.transform, "FarClipPlane", delegate (float value) { PlayerCameraEditor.PlayerCamera.farClipPlane = value; }, "Adjust Camera FarClipPlane", 999999999, 1, false, true);
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (farClipPlaneSlider != null)
            {
                farClipPlaneSlider.SetValue(PlayerCameraEditor.PlayerCamera.farClipPlane);
            }
        }

        private static QMSlider farClipPlaneSlider;
        private static QMSlider fovSlider;
    }
}