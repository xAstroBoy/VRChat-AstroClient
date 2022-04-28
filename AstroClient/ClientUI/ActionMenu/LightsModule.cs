using AstroClient.ClientActions;

namespace AstroClient.ClientUI.ActionMenu
{
    using Gompoc.ActionMenuAPI.Api;
    using Menu.Menus;
    using Menu.Menus.Quickmenu;
    using Spawnables.Flashlight;
    using UnityEngine;
    using Color = System.Drawing.Color;

    internal class ActionLightsMenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Lights Option", () =>
            {
                // TODO: Add Textures!
                CustomSubMenu.AddButton("Clear Light source template", () => { Astro_Flashlight.ClearTemplate(); }, null, false);
                CustomSubMenu.AddButton("Get Light source template", () => { Astro_Flashlight.GetLightTemplate(); }, null, false);

                CustomSubMenu.AddToggle("Toggle Fullbright (RenderSettings)", LightControlMenu.FullbrightByRender, ToggleValue => { LightControlMenu.FullbrightByRender = ToggleValue; }, null, false);
                CustomSubMenu.AddToggle("Toggle RenderSettings Fog", RenderSettings.fog, ToggleValue => { LightControlMenu.ToggleFog(ToggleValue); }, null, false);
                CustomSubMenu.AddToggle("Toggle Fullbright (Head)", LightControlMenu.IsHeadLightActive, ToggleValue => { LightControlMenu.IsHeadLightActive = ToggleValue; }, null, false);

                CustomSubMenu.AddButton("Spawn Flashlight", () => { Astro_Flashlight.SpawnFlashlight(); }, null, false);
                CustomSubMenu.AddToggle("Flashlight Golden Skin", Astro_Flashlight.isGoldenFlashlight, ToggleValue => { Astro_Flashlight.isGoldenFlashlight = ToggleValue; }, null, false);
                CustomSubMenu.AddButton("Destroy Flashlights", () => { Astro_Flashlight.DestroyAllFlashLights(); }, null, false);
            });

            Log.Write("Lights Module Editor is ready!", Color.Green);
        }
    }
}