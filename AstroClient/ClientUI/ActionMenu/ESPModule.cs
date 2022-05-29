using AstroClient.ClientActions;

namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using Gompoc.ActionMenuAPI.Api;
    using Menu.ESP;

    internal class ESPModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("ESP Options", () =>
            {
                // TODO: Add Textures!
                CustomSubMenu.AddToggle("Toggle Player ESP", PlayerESPMenu.Toggle_Player_ESP, ToggleValue => { PlayerESPMenu.Toggle_Player_ESP = ToggleValue; },  null);
                CustomSubMenu.AddSubMenu("Map ESP", () =>
                {
                    CustomSubMenu.AddToggle("Toggle Pickup ESP", VRChat_Map_ESP_Menu.Toggle_Pickup_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_Pickup_ESP = ToggleValue; },  null);
                    CustomSubMenu.AddToggle("Toggle VRC Interactable ESP", VRChat_Map_ESP_Menu.Toggle_VRCInteractable_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_VRCInteractable_ESP = ToggleValue; },  null);
                    CustomSubMenu.AddToggle("Toggle Trigger ESP", VRChat_Map_ESP_Menu.Toggle_Trigger_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_Trigger_ESP = ToggleValue; },  null);
                    CustomSubMenu.AddToggle("Toggle Udon Behaviour ESP", VRChat_Map_ESP_Menu.Toggle_UdonBehaviour_ESP, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_UdonBehaviour_ESP = ToggleValue; },  null);
                }, null);
            });

            Log.Write("ESP Module is ready!", Color.Green);
        }
    }
}