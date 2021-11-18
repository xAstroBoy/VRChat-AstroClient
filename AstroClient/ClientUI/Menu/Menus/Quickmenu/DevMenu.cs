namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    #region Imports

    using ClientResources;
    using ClientResources.Loaders;
    using Constants;
    using Networking;
    using xAstroBoy.AstroButtonAPI;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class DevMenu : AstroEvents
    {
        #region UIElements

        internal static QMTabMenu SubMenu { get; private set; }

        internal static QMScrollMenu MainScroller { get; private set; }

        internal static QMSingleButton DisconectButton { get; private set; }

        internal static QMSingleButton ReconnectButton { get; private set; }

        #endregion UIElements

        internal static void InitButtons(int index)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(index, "Developer Menu", null, null, null, Icons.repair_sprite);

                DisconectButton = new QMSingleButton(SubMenu, 1, 0, "Disconnect", () => { AstroNetworkClient.Client.Disconnect(false); }, "Disconnect");
                ReconnectButton = new QMSingleButton(SubMenu, 1, 1, "Reconnect", () => { AstroNetworkClient.Client.Disconnect(true); }, "Reconnect");
            }
        }
    }
}