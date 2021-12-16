namespace AstroClient.ClientUI.Menu.SettingsMenu
{
    #region Imports

    using Config;
    using LoadingScreen.Settings;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_LoadingScreen : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Loading Screen", "Loading Screen");

            ModSoundsToggleBtn = new QMToggleButton(sub, "Custom Loading Screen Sounds", () => { BetterLoadingScreenSettings.ModSounds = true; }, () => { BetterLoadingScreenSettings.ModSounds = false; }, "Loading Screen Custom Sound", null, null, null, BetterLoadingScreenSettings.ModSounds);
            WarpTunnelToggleBtn = new QMToggleButton(sub, "Custom Warp Tunnel", () => { BetterLoadingScreenSettings.WarpTunnel = true; }, () => { BetterLoadingScreenSettings.WarpTunnel = false; }, "Toggle Warp Tunnel", null, null, null, BetterLoadingScreenSettings.WarpTunnel);
            ShowLoadingMessagesToggleBtn = new QMToggleButton(sub, "Show Loading messages", () => { BetterLoadingScreenSettings.ShowLoadingMessages = true; }, () => { BetterLoadingScreenSettings.ShowLoadingMessages = false; }, "Show Loading Messages from VRChat.", null, null, null, BetterLoadingScreenSettings.ShowLoadingMessages);
            VRCLogoToggleBtn = new QMToggleButton(sub, "Custom Show VRChat Logo", () => { BetterLoadingScreenSettings.VRCLogo = true; }, () => { BetterLoadingScreenSettings.VRCLogo = false; }, "Show VRChat Logo", null, null, null, BetterLoadingScreenSettings.VRCLogo);
            SecretMemeToggleBtn = new QMToggleButton(sub, "Easter Egg", () => { BetterLoadingScreenSettings.SecretMeme = true; }, () => { BetterLoadingScreenSettings.SecretMeme = false; }, "Easter Egg (this is supposed to be shown on 4th april)", null, null, null, BetterLoadingScreenSettings.SecretMeme);

        }
        internal static QMToggleButton ModSoundsToggleBtn { get; set; }
        internal static QMToggleButton WarpTunnelToggleBtn { get; set; }
        internal static QMToggleButton ShowLoadingMessagesToggleBtn { get; set; }
        internal static QMToggleButton VRCLogoToggleBtn { get; set; }
        internal static QMToggleButton SecretMemeToggleBtn { get; set; }

    }
}