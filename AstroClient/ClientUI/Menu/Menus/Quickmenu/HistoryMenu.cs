namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    #region Imports

    using ClientResources;
    using ClientResources.Loaders;
    using Constants;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;

    #endregion Imports

    internal class HistoryMenu : AstroEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(int index)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(index, "History Menu", null, null, null, Icons.history_sprite);
            }
        }
    }
}