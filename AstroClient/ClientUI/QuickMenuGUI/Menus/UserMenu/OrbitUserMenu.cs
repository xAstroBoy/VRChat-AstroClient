using System;
using AstroClient.AstroMonos.Components.Malicious;
using AstroClient.Constants;
using AstroClient.Tools.ObjectEditor;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.ClientUI.QuickMenuGUI.Menus.UserMenu
{
    internal class OrbitUserMenu : AstroEvents
    {

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            if (Bools.AllowOrbitComponent)
            {
                var submenu = new QMNestedGridMenu(menu, "Orbit Options", "Orbit Selected player Options");
                _ = new QMSingleButton(submenu, "All\nPickups\nOrbits around \nplayer.", new Action(ObjectMiscOptions.AllWorldPickupsOrbitsOnTarget), "Make that dirty pickup thief regret stealing from you.");
                _ = new QMSingleButton(submenu, "Remove\nPlayer (bound) Orbiting Items", new Action(ObjectMiscOptions.RemoveAllOrbitPlayer), "Removes any Orbiting Items bound to this player.");
                var newOrbitToggle = new QMToggleButton(submenu, "Cheetos\nOrbit", () => { OrbitManager.OrbitPlayer(QuickMenuUtils.SelectedPlayer); }, "Cheetos\nOrbit", () => { OrbitManager.DisableOrbit(); }, "Cheetos' WIP Orbit");
            }
        }
    }
}