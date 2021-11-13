namespace AstroClient.ClientUI.QuickMenuButtons
{
    #region Imports

    using System.Collections.Generic;
    using System.Reflection;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using CheetoLibrary;
    using Variables;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_Camera : GameEvents
    {

        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Camera", "Camera");

            fovSlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.FindChild(sub.GetMenuName()), "FOV", delegate (float value) { FOV.Set_Camera_FOV(value); }, "Adjust FOV", 140, 20, false, true);
            farClipPlaneSlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.FindChild(sub.GetMenuName()), "FarClipPlane", delegate(float value) { PlayerCameraEditor.PlayerCamera.farClipPlane = value; }, "Adjust Camera FarClipPlane", 999999999, 1, false, true);


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