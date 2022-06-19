using System;
using AstroClient.AstroMonos.Components.Tools.PickupBlocker;
using AstroClient.Constants;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.ClientUI.QuickMenuGUI.Menus.UserMenu
{
    internal class PickupProtector : AstroEvents
    {

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            if (Bools.IsDeveloper)
            {
                var submenu = new QMNestedGridMenu(menu, "Pickup Protector", "Allow or prevent people from interacting with pickups!");
                _ = new QMSingleButton(submenu, 0, 0, "Deny Pickups to Player.", new Action(() => { PickupBlocker.RegisterPlayer(QuickMenuUtils.SelectedUser); }), "Block Pickups from being used by this player!.", null, null, true);
                _ = new QMSingleButton(submenu, 0, 0.5f, "Re-allow Pickups to Player.", new Action(() => { PickupBlocker.RemovePlayer(QuickMenuUtils.SelectedUser); }), "Block Pickups from being used by this player!.", null, null, true);
            }
        }
    }
}