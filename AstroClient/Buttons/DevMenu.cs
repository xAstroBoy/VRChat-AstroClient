﻿namespace AstroClient.Startup.Buttons
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary;
    using RubyButtonAPI;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using UnityEngine;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    public class DevMenu : GameEvents
    {
        #region UIElements

        public static QMTabMenu SubMenu { get; private set; }

        public static QMScrollMenu MainScroller { get; private set; }

        public static QMSingleButton DisconectButton { get; private set; }

        public static QMSingleButton ReconnectButton { get; private set; }

        #endregion UIElements

        public static void InitButtons(float pos)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(pos, "Developer Menu", null, null, null, CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.repair.png"));

                DisconectButton = new QMSingleButton(SubMenu, 1, 0, "Disconnect", () => { AstroNetworkClient.Client.Disconnect(false); }, "Disconnect");
                ReconnectButton = new QMSingleButton(SubMenu, 1, 1, "Reconnect", () => { AstroNetworkClient.Client.Disconnect(true); }, "Reconnect");
            }
        }
    }
}