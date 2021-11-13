namespace AstroClient.ClientUI.QuickMenuButtons
{
    using System.Collections.Generic;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using CheetoLibrary;
    using Cheetos;
    using ESP;
    using UnityEngine;

    internal class SettingsMenuBtn : GameEvents
    {

        internal static void InitButtons(QMGridTab menu, float x, float y, bool btnHalf)
        {
            // Main Settings Menu
            QMNestedGridMenu sub = new QMNestedGridMenu(menu, x, y, "Settings", "Settings", null, null, null, null, btnHalf);
            sub.GetMainButton().SetTextColor(Color.cyan);


            Settings_LogsMenu.InitButtons(sub);
            //QMSingleToggleButton playerListToggle = new QMSingleToggleButton(sub, 1, 0, "PlayerList ON", () => { PlayerList.ShowPlayerMenu(); }, "PlayerList OFF", () => { PlayerList.HidePlayerMenu(); }, "Show/Hide PlayerList", Color.green, Color.red, null, ConfigManager.UI.ShowPlayersMenu, true);
            //playerListToggle.SetToggleState(ConfigManager.UI.ShowPlayersMenu, false);

            // Performance Menu

            Settings_Performance.InitButtons(sub);

            // Other

            // Hide Elements Menu
            Settings_HideElements.InitButtons(sub);

            Settings_Camera.InitButtons(sub);

            Settings_Spoofs.InitButtons(sub);
            // Fly and ESP
            //FlightMenu.InitButtons(sub, 1f, 1.5f, true);
            PlayerESPMenu.InitButtons(sub);


            // Nameplate Toggle
            var toggleNameplates = new QMToggleButton(sub, "Nameplates", () => { ConfigManager.UI.NamePlates = true; }, () => { ConfigManager.UI.NamePlates = false; }, "Nameplates");
            toggleNameplates.SetToggleState(ConfigManager.UI.NamePlates, false);

            // KeyBind Toggle
            var toggleKeyBinds = new QMToggleButton(sub, "KeyBinds", () => { ConfigManager.General.KeyBinds = true; }, () => { ConfigManager.General.KeyBinds = false; }, "KeyBinds");
            toggleKeyBinds.SetToggleState(ConfigManager.General.KeyBinds, false);

           
            QMSingleButton saveButton = new QMSingleButton(sub, 0, 0, "Save Config", () => { ConfigManager.SaveAll(); }, "Save Config", Color.magenta, null, true);


        }





    }
}