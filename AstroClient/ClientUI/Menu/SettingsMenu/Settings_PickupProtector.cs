namespace AstroClient.ClientUI.Menu.SettingsMenu
{
    #region Imports

    using CheetoLibrary.Utility;
    using Config;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_PickupProtector : AstroEvents
    {
        private static QMToggleButton ToggleRespawnPickupOnPlayerDenied { get; set; }
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Pickup Protector", "Pickup Protector Options");

            ToggleRespawnPickupOnPlayerDenied = new QMToggleButton(sub, "Respawn Pickup On Blocked Grab", () => { RespawnPickupToDefaultPos = true; }, () => { RespawnPickupToDefaultPos = false; }, "Make PickupProtector Respawn the Pickup instead of temporarily freeze in position");
            ToggleRespawnPickupOnPlayerDenied.SetToggleState(RespawnPickupToDefaultPos);
        }

        internal static bool _RespawnPickupToDefaultPos = true;

        internal static bool RespawnPickupToDefaultPos
        {
            get
            {
                return _RespawnPickupToDefaultPos;
            }
            set
            {
                _RespawnPickupToDefaultPos = value;
                ToggleRespawnPickupOnPlayerDenied.SetToggleState(value);
            }
        }

    }
}