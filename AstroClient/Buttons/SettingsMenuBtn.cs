﻿using RubyButtonAPI;
using UnityEngine;

namespace AstroClient.Startup.Buttons
{
    internal class SettingsMenuBtn
    {
        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            QMNestedButton sub = new QMNestedButton(menu, x, y, "Settings", "Settings", null, null, null, null, btnHalf);
            sub.getMainButton().setTextColor(Color.cyan);

            QMToggleButton playerListToggle = new QMToggleButton(sub, 1, 0, "PlayerList ON", () => { PlayerMenuUI.ShowPlayerMenu(); }, "PlayerList OFF", () => { PlayerMenuUI.HidePlayerMenu(); }, "Show/Hide PlayerList");
            playerListToggle.setToggleState(ConfigManager.Configuration.ShowPlayersMenu, false);

            QMToggleButton joinLeaveToggle = new QMToggleButton(sub, 2, 0, "Join/Leave ON", () => { ConfigManager.Configuration.JoinLeave = true; }, "Join/Leave OFF", () => { ConfigManager.Configuration.JoinLeave = false; }, "Notification when someone joins/leaves");
            joinLeaveToggle.setToggleState(ConfigManager.Configuration.JoinLeave, false);
        }
    }
}