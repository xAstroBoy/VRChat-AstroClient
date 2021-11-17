namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using System;
    using AstroMonos.Components.Malicious;
    using Constants;
    using Tools.ObjectEditor;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class OrbitUserMenu : AstroEvents
    {

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            if (Bools.AllowOrbitComponent)
            {
                var submenu = new QMNestedGridMenu(menu, "Orbit Options", "Orbit Selected player Options");
                _ = new QMSingleButton(menu, "All\nPickups\nOrbits around \nplayer.", new Action(ObjectMiscOptions.AllWorldPickupsOrbitsOnTarget), "Make that dirty pickup thief regret stealing from you.");
                _ = new QMSingleButton(menu, "Remove\nPlayer (bound) Orbiting Items", new Action(ObjectMiscOptions.RemoveAllOrbitPlayer), "Removes any Orbiting Items bound to this player.");
                var newOrbitToggle = new QMToggleButton(menu, "Cheetos\nOrbit", () => { OrbitManager.OrbitPlayer(QuickMenuUtils.SelectedPlayer); }, "Cheetos\nOrbit", () => { OrbitManager.DisableOrbit(); }, "Cheetos' WIP Orbit");
            }
        }
    }
}