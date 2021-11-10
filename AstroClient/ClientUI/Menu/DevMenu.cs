namespace AstroClient.ClientUI.QuickMenuButtons
{
    #region Imports

    using System.Reflection;
    using AstroButtonAPI;
    using CheetoLibrary;
    using Variables;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class DevMenu : GameEvents
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
                SubMenu = new QMTabMenu(index, "Developer Menu", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.repair.png"));

                DisconectButton = new QMSingleButton(SubMenu, 1, 0, "Disconnect", () => { AstroNetworkClient.Client.Disconnect(false); }, "Disconnect");
                ReconnectButton = new QMSingleButton(SubMenu, 1, 1, "Reconnect", () => { AstroNetworkClient.Client.Disconnect(true); }, "Reconnect");
            }
        }
    }
}