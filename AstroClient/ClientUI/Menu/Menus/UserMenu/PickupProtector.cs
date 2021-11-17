namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using System;
    using AstroMonos;
    using Constants;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class PickupProtector : AstroEvents
    {

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            if (Bools.IsDeveloper)
            {
                var submenu = new QMNestedGridMenu(menu, "Pickup Protector", "Allow or prevent people from interacting with pickups!");
                _ = new QMSingleButton(submenu, 0, 0, "Deny Pickups to Player.", new Action(() => { PickupBlocker.RegisterPlayer(QuickMenuUtils.SelectedPlayer); }), "Block Pickups from being used by this player!.", null, null, true);
                _ = new QMSingleButton(submenu, 0, 0.5f, "Re-allow Pickups to Player.", new Action(() => { PickupBlocker.RemovePlayer(QuickMenuUtils.SelectedPlayer); }), "Block Pickups from being used by this player!.", null, null, true);
            }
        }
    }
}