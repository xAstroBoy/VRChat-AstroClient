namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    #region Imports

    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using CheetoLibrary.Utility;
    using ClientResources;
    using ClientResources.Loaders;
    using Constants;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    internal class CheetosMenu : AstroEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(int index)
        {
            if (!Bools.IsDeveloper) { return; }
            SubMenu = new QMTabMenu(index, "Cheetos Menu", null, null, null, Icons.cheetos_sprite);
        }
    }
}