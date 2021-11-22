namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using System;
    using Tools.ObjectEditor;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;

    internal class WatcherUserMenu : AstroEvents
    {

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Watchers", "Watchers Control");
            _ = new QMSingleButton(submenu, "All Pickups Watch player.", new Action(ObjectMiscOptions.AllWorldPickupsWatchTarget), "Make the victim feel observed.");
            _ = new QMSingleButton(submenu, "Remove\nPlayer (bound) Watchers", new Action(ObjectMiscOptions.RemoveAllWatchersPlayer), "Removes any Watchers bound to this player."); 
        }
    }
}