using System.Collections.Generic;
using AstroClient.Cheetos.CameraStuff;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.UIPaths;

namespace AstroClient.ClientUI.QuickMenuGUI.SettingsMenu
{
    #region Imports

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_Camera : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Camera", "Camera");

            fovSlider = new QMSlider(sub.ButtonsMenu.transform, "FOV", delegate (float value) { FOV.Set_Camera_FOV(value); }, "Adjust FOV", 140, 20, true, true);
            farClipPlaneSlider = new QMSlider(sub.ButtonsMenu.transform, "FarClipPlane", delegate (float value) { PlayerCameraEditor.PlayerCamera.farClipPlane = value; }, "Adjust Camera FarClipPlane", 999999999, 1, false, true);
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            PlayerCameraEditor.PlayerCamera.farClipPlane *= 5f;
            FarClipPlaneSetting = PlayerCameraEditor.PlayerCamera.farClipPlane;
            if (farClipPlaneSlider != null)
            {
                farClipPlaneSlider.SetValue(PlayerCameraEditor.PlayerCamera.farClipPlane);
            }
            PlayerCameraEditor.PlayerCamera.nearClipPlane = 0.001f;
        }

        internal static void RestoreFarClipPlane()
        {
            PlayerCameraEditor.PlayerCamera.farClipPlane = FarClipPlaneSetting;
        }


        private static float FarClipPlaneSetting = 0f;
        private static QMSlider farClipPlaneSlider;
        private static QMSlider fovSlider;
    }
}