namespace AstroClient.ClientUI.Menu.Menus
{
    #region Imports

    using ClientResources;
    using Constants;
    using xAstroBoy.AstroButtonAPI;

    #endregion Imports

    internal class HistoryMenu : AstroEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(int index)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(index, "History Menu", null, null, null, ClientResources.history_sprite);
            }
        }
    }
}