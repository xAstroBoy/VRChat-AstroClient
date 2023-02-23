using System;
using System.Collections.Generic;
using AstroClient.Cheetos.CameraStuff;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.UIPaths;
using AstroClient.xAstroBoy.Utility;

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

            //fovSlider = new QMSlider(sub.ButtonsMenu.transform, "FOV", delegate (float value) { FOV.Set_Camera_FOV(value); }, "Adjust FOV", 140, 20, true, true);
            //farClipPlaneSlider = new QMSlider(sub.ButtonsMenu.transform, "FarClipPlane", delegate (float value) { Set_FarClipPlane(value); }, "Adjust Camera FarClipPlane", 999999999, 1, false, true);
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            //PlayerCameraEditor.PlayerCamera.farClipPlane *= 5f;
            FarClipPlaneSetting = PlayerCameraEditor.PlayerCamera.farClipPlane;
            NearClipPlaneSetting = PlayerCameraEditor.PlayerCamera.nearClipPlane;

            //if (farClipPlaneSlider != null)
            //{
            //    farClipPlaneSlider.SetValue(PlayerCameraEditor.PlayerCamera.farClipPlane);
            //}
            //MiscUtils.DelayFunction(5f, ()=>
            //{
            //PlayerCameraEditor.PlayerCamera.nearClipPlane = 1E-06f;
            //});
        }
        internal static void Increase_FarClipPlane(int amount)
        {
            PlayerCameraEditor.PlayerCamera.farClipPlane += amount;
            //if (farClipPlaneSlider != null)
            //{
            //    farClipPlaneSlider.SetValue(PlayerCameraEditor.PlayerCamera.farClipPlane);
            //}

            OnCameraPropertyChanged.SafetyRaise();
        }

        internal static void Set_FarClipPlane(float amount)
        {
            PlayerCameraEditor.PlayerCamera.farClipPlane = amount;
            //if (farClipPlaneSlider != null)
            //{
            //    farClipPlaneSlider.SetValue(PlayerCameraEditor.PlayerCamera.farClipPlane);
            //}

            OnCameraPropertyChanged.SafetyRaise();
        }
        internal static void Set_nearClipPlane(float amount)
        {
            PlayerCameraEditor.PlayerCamera.nearClipPlane = amount;
            OnCameraPropertyChanged.SafetyRaise();
        }


        internal static void RestoreFarClipPlane()
        {
            PlayerCameraEditor.PlayerCamera.farClipPlane = FarClipPlaneSetting;
            OnCameraPropertyChanged.SafetyRaise();

        }
        internal static void RestoreNearClipPlane()
        {
            PlayerCameraEditor.PlayerCamera.nearClipPlane = NearClipPlaneSetting;
            OnCameraPropertyChanged.SafetyRaise();
        }


        private static float NearClipPlaneSetting = 0f;

        private static float FarClipPlaneSetting = 0f;
        //private static QMSlider farClipPlaneSlider;
        //private static QMSlider fovSlider;

        internal static Action OnCameraPropertyChanged { get; set; }

    }
}