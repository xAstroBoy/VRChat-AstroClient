using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.Menus.Quickmenu;
using AstroClient.ClientUI.QuickMenuGUI.SettingsMenu;
using AstroClient.Spawnables.ColliderSuppresserCube;
using AstroClient.Spawnables.Flashlight;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.Tools.ObjectEditor;
using AstroClient.Tools.World;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.UIPaths;
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

                CustomSubMenu.AddSubMenu("Player Camera Controls", () =>
                {
                    CustomSubMenu.AddButton("Reset FarClipPlane", () => { Settings_Camera.RestoreFarClipPlane(); }, null);
                    CustomSubMenu.AddButton("Reset NearClipPlane", () => { Settings_Camera.RestoreNearClipPlane(); }, null);

                    CustomSubMenu.AddButton("Increase FarClipPlane of 100", () => { Settings_Camera.Increase_FarClipPlane(100); }, null);
                    CustomSubMenu.AddButton("Increase FarClipPlane of 1000", () => { Settings_Camera.Increase_FarClipPlane(1000); }, null);
                    CustomSubMenu.AddButton("Increase FarClipPlane of 10000", () => { Settings_Camera.Increase_FarClipPlane(10000); }, null);
                    CustomSubMenu.AddButton("Set FarClipPlane to 999999999f", () => { Settings_Camera.Set_FarClipPlane(999999999f); }, null);


                    CustomSubMenu.AddButton("Set NearClipPlane to 0.000001f", () => { Settings_Camera.Set_nearClipPlane(1E-06f); }, null);

                }, null);

                CustomSubMenu.AddSubMenu("Collider Disabler", () =>
                {
                    CustomSubMenu.AddButton("Spawn Collider Disabler Sphere", () => { ColliderSuppresserSphere.SpawnSphere(); },  null);
                    CustomSubMenu.AddButton("Revert Collider Disabler Edits", () => { ColliderSuppresserSphere.FixAndRevertColliderEdits(); },  null);
                }, null);


                CustomSubMenu.AddSubMenu("Lighting Controls", () =>
                {
                    CustomSubMenu.AddButton("Clear Light source template", () => { Astro_Flashlight.ClearTemplate(); },  null);
                    CustomSubMenu.AddButton("Get Light source template", () => { Astro_Flashlight.GetLightTemplate(); },  null);

                    CustomSubMenu.AddToggle("Toggle Fullbright (RenderSettings)", LightControlMenu.FullbrightByRender, ToggleValue => { LightControlMenu.FullbrightByRender = ToggleValue; },  null);
                    CustomSubMenu.AddToggle("Toggle RenderSettings Fog", RenderSettings.fog, ToggleValue => { LightControlMenu.ToggleFog(ToggleValue); },  null);
                    CustomSubMenu.AddToggle("Toggle Fullbright (Head)", LightControlMenu.IsHeadLightActive, ToggleValue => { LightControlMenu.IsHeadLightActive = ToggleValue; },  null);

                    CustomSubMenu.AddButton("Spawn Flashlight", () => { Astro_Flashlight.SpawnFlashlight(); },  null);
                    CustomSubMenu.AddToggle("Flashlight Golden Skin", Astro_Flashlight.isGoldenFlashlight, ToggleValue => { Astro_Flashlight.isGoldenFlashlight = ToggleValue; },  null);
                    CustomSubMenu.AddButton("Destroy Flashlights", () => { Astro_Flashlight.DestroyAllFlashLights(); },  null);
                }, null);

                CustomSubMenu.AddSubMenu("Pickups Controls", () =>
                {
                    CustomSubMenu.AddButton("Revert Pickup Edits", () =>
                    {
                        WorldUtils_Old.Get_Pickups().Pickup_RestoreOriginalProperties();
                    }, null);

                    CustomSubMenu.AddButton("Restore Original pickups pos", () =>
                    {
                        GameObjectMenu.TeleportPickupsToTheirDefaultPosition(false);
                    },  null);
                    CustomSubMenu.AddButton("Restore Original pickups pos & Revert Rigidbody Edits", () =>
                    {
                        GameObjectMenu.TeleportPickupsToTheirDefaultPosition(true);
                    },  null);
                    CustomSubMenu.AddButton("Enable World Gravity On kinematic Pickups", () =>
                    {
                        ObjectMiscOptions.DisablePickupKinematic(true);
                    },  null);
                    CustomSubMenu.AddButton("Enable Gravity 0G On kinematic Pickups", () =>
                    {
                        ObjectMiscOptions.DisablePickupKinematic(false);
                    },  null);
                    CustomSubMenu.AddButton("Enable World Gravity on All Pickups", () =>
                    {
                        ObjectMiscOptions.SetGravityOnWorldPickups(true);
                    },  null);
                    CustomSubMenu.AddButton("Disable Gravity on All Pickups", () =>
                    {
                        ObjectMiscOptions.SetGravityOnWorldPickups(false);
                    },  null);
                    CustomSubMenu.AddButton("Pickup Hulk Toss", () =>
                    {
                        WorldUtils_Old.Get_Pickups().Pickup_Set_ThrowVelocityBoostScale(9.5f);
                    }, null);


                }, null);
            });

            Log.Write("World Module is ready!", Color.Green);
        }
    }
}