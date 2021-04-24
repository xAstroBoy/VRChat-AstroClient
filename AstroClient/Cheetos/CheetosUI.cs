using AstroClient.variables;
using RubyButtonAPI;
using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace AstroClient
{
    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    public class CheetosUI : GameEvents
    {
        public QMNestedButton MainButton { get; private set; }

        public QMScrollMenu MainScroller { get; private set; }

        public QMSingleButton CloseButton { get; private set; }

        public QMSingleButton RestartButton { get; private set; }

        public QMSingleButton DisconectButton { get; private set; }

        public QMSingleButton ReconnectButton { get; private set; }

        public override void VRChat_OnUiManagerInit()
        {
            MainButton = new QMNestedButton("ShortcutMenu", 5, 3, "Admin Menu", "AstroClient's Admin Menu", null, null, null, null, true);
            MainScroller = new QMScrollMenu(MainButton);
            CloseButton = new QMSingleButton(MainButton, 0, 0, "Close Game", () => { Process.GetCurrentProcess().Kill(); }, "Close the game");
            RestartButton = new QMSingleButton(MainButton, 0, 1, "Restart Game", () =>
            {
                Process.Start(Directory.GetParent(Application.dataPath) + "\\VRChat.exe");
                Process.GetCurrentProcess().Kill();
            }, "Restart the game");
            DisconectButton = new QMSingleButton(MainButton, 1, 0, "Disconnect", () => { AstroNetworkClient.Client.Disconnect(false); }, "Disconnect");
            ReconnectButton = new QMSingleButton(MainButton, 1, 1, "Reconnect", () => { AstroNetworkClient.Client.Disconnect(true); }, "Reconnect");

            if (!Bools.IsDeveloper)
            {
                MainButton.getMainButton().setActive(false);
            }
        }

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
        }
    }
}