namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using System;
    using Tools.ObjectEditor;
    using xAstroBoy.AstroButtonAPI;

    internal class WatcherUserMenu : AstroEvents
    {

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Watchers", "Watchers Control");
            _ = new QMSingleButton(menu, "All Pickups Watch player.", new Action(ObjectMiscOptions.AllWorldPickupsWatchTarget), "Make the victim feel observed.");
            _ = new QMSingleButton(menu, "Remove\nPlayer (bound) Watchers", new Action(ObjectMiscOptions.RemoveAllWatchersPlayer), "Removes any Watchers bound to this player."); 
        }
    }
}