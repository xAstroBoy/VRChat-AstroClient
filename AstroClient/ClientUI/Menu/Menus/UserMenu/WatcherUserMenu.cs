namespace AstroClient.ClientUI.Menu.Menus.UserMenu
{
    using Tools.ObjectEditor;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class WatcherUserMenu : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Watchers", "Watchers Control");
            _ = new QMSingleButton(submenu, "All Pickups Watch player.", ObjectMiscOptions.AllWorldPickupsWatchTarget, "Make the victim feel observed.");
            _ = new QMSingleButton(submenu, "Remove\nPlayer (bound) Watchers", ObjectMiscOptions.RemoveAllWatchersPlayer, "Removes any Watchers bound to this player.");
        }
    }
}