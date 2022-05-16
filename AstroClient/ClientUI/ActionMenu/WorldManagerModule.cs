using AstroClient.ClientActions;
using AstroClient.ClientUI.Menu.Menus.Quickmenu;
using AstroClient.Spawnables.Flashlight;
using AstroClient.Tools.ObjectEditor;
using UnityEngine;

namespace AstroClient.ClientUI.ActionMenu
{
    using Gompoc.ActionMenuAPI.Api;
    using System.Drawing;

    internal class WorldManagerModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("World Control", () =>
            {


                CustomSubMenu.AddSubMenu("Lighting Controls", () =>
                {
                    CustomSubMenu.AddButton("Clear Light source template", () => { Astro_Flashlight.ClearTemplate(); }, null, false);
                    CustomSubMenu.AddButton("Get Light source template", () => { Astro_Flashlight.GetLightTemplate(); }, null, false);

                    CustomSubMenu.AddToggle("Toggle Fullbright (RenderSettings)", LightControlMenu.FullbrightByRender, ToggleValue => { LightControlMenu.FullbrightByRender = ToggleValue; }, null, false);
                    CustomSubMenu.AddToggle("Toggle RenderSettings Fog", RenderSettings.fog, ToggleValue => { LightControlMenu.ToggleFog(ToggleValue); }, null, false);
                    CustomSubMenu.AddToggle("Toggle Fullbright (Head)", LightControlMenu.IsHeadLightActive, ToggleValue => { LightControlMenu.IsHeadLightActive = ToggleValue; }, null, false);

                    CustomSubMenu.AddButton("Spawn Flashlight", () => { Astro_Flashlight.SpawnFlashlight(); }, null, false);
                    CustomSubMenu.AddToggle("Flashlight Golden Skin", Astro_Flashlight.isGoldenFlashlight, ToggleValue => { Astro_Flashlight.isGoldenFlashlight = ToggleValue; }, null, false);
                    CustomSubMenu.AddButton("Destroy Flashlights", () => { Astro_Flashlight.DestroyAllFlashLights(); }, null, false);
                }, null, false, null);

                CustomSubMenu.AddSubMenu("Pickups Controls", () =>
                {

                    CustomSubMenu.AddButton("Restore Original pickups pos", () =>
                    {
                        GameObjectMenu.TeleportPickupsToTheirDefaultPosition(false);
                    }, null, false);
                    CustomSubMenu.AddButton("Restore Original pickups pos & Revert Rigidbody Edits", () =>
                    {
                        GameObjectMenu.TeleportPickupsToTheirDefaultPosition(true);
                    }, null, false);
                    CustomSubMenu.AddButton("Enable World Gravity On kinematic Pickups", () =>
                    {
                        ObjectMiscOptions.DisablePickupKinematic(true);
                    }, null, false);
                    CustomSubMenu.AddButton("Enable Gravity 0G On kinematic Pickups", () =>
                    {
                        ObjectMiscOptions.DisablePickupKinematic(false);
                    }, null, false);
                    CustomSubMenu.AddButton("Enable World Gravity on All Pickups", () =>
                    {
                        ObjectMiscOptions.SetGravityOnWorldPickups(true);
                    }, null, false);
                    CustomSubMenu.AddButton("Disable Gravity on All Pickups", () =>
                    {
                        ObjectMiscOptions.SetGravityOnWorldPickups(false);
                    }, null, false);

                }, null, false, null);
            });

            Log.Write("World Module is ready!", Color.Green);
        }
    }
}