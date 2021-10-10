namespace AstroClient.Startup.Buttons
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary;
    using AstroButtonAPI;
    using System.Reflection;
    using CheetoLibrary;

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

        internal static void InitButtons(float pos)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(pos, "Developer Menu", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.repair.png"));

                DisconectButton = new QMSingleButton(SubMenu, 1, 0, "Disconnect", () => { AstroNetworkClient.Client.Disconnect(false); }, "Disconnect");
                ReconnectButton = new QMSingleButton(SubMenu, 1, 1, "Reconnect", () => { AstroNetworkClient.Client.Disconnect(true); }, "Reconnect");
            }
        }
    }
}