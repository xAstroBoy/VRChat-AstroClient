namespace AstroClient.AvatarParametersEditor
{
    using AstroActionMenu.Api;
    using AstroLibrary.Console;
    using Startup.Buttons;
    using System.Drawing;

    internal class ESPModule : GameEvents
    {
        internal override void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("ESP Options", () =>
            {
                // TODO: Add Textures!
                CustomSubMenu.AddToggle("Toggle Player ESP", PlayerESPMenu.Toggle_Player_ESP, ToggleValue => { PlayerESPMenu.Toggle_Player_ESP = ToggleValue; }, null, false);
                CustomSubMenu.AddSubMenu("Map ESP", () =>
                {
                    CustomSubMenu.AddToggle("Toggle Pickup ESP", VRChat_Map_ESP_Menu.Toggle_Pickup_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_Pickup_ESP = ToggleValue; }, null, false);
                    CustomSubMenu.AddToggle("Toggle VRC Interactable ESP", VRChat_Map_ESP_Menu.Toggle_VRCInteractable_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_VRCInteractable_ESP = ToggleValue; }, null, false);
                    CustomSubMenu.AddToggle("Toggle Trigger ESP", VRChat_Map_ESP_Menu.Toggle_Trigger_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_Trigger_ESP = ToggleValue; }, null, false);
                    CustomSubMenu.AddToggle("Toggle Udon Behaviour ESP", VRChat_Map_ESP_Menu.Toggle_UdonBehaviour_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_UdonBehaviour_ESP = ToggleValue; }, null, false);
                }, null, false, null);
            });

            ModConsole.Log("ESP Module is ready!", Color.Green);
        }
    }
}