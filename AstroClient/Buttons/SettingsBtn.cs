﻿using AstroClient.GameObjectDebug;
using RubyButtonAPI;
using System;
using UnityEngine;

namespace AstroClient.Startup.Buttons
{
    internal class SettingsBtn
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            QMNestedButton sub = new QMNestedButton(menu, x, y, "Settings", "Settings", null, null, null, null, btnHalf);
            sub.getMainButton().setTextColor(Color.cyan);

            QMToggleButton playerListToggle = new QMToggleButton(sub, 1, 0, "PlayerList ON", () => { PlayerListUI.ShowPlayerList(); }, "PlayerList OFF", () => { PlayerListUI.HidePlayerList(); }, "Show/Hide PlayerList");
            playerListToggle.setToggleState(PlayerListUI.Instance.showPlayersButton, false);
        }
    }
}