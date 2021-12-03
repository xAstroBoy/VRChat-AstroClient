namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    using Config;
    using ESP;
    using SettingsMenu;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class SettingsMenuBtn : AstroEvents
    {

        internal static void InitButtons(QMGridTab menu)
        {
            // Main Settings Menu
            QMNestedGridMenu sub = new QMNestedGridMenu(menu, "Settings", "Settings");
            sub.GetMainButton().SetTextColor(Color.white);


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