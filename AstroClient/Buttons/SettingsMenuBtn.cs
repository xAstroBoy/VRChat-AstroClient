using AstroClient.Cheetos;
using AstroClient.GameObjectDebug;
using RubyButtonAPI;
using System;
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
            playerListToggle.setToggleState(PlayerMenuUI.ShowPlayersMenu, false);

            QMToggleButton joinLeaveToggle = new QMToggleButton(sub, 2, 0, "Join/Leave ON", () => { JoinLeaveNotifier.Enabled = true; }, "Join/Leave OFF", () => { JoinLeaveNotifier.Enabled = false; }, "Notification when someone joins/leaves");
            joinLeaveToggle.setToggleState(JoinLeaveNotifier.Enabled, false);
        }
    }
}