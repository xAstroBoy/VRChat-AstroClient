namespace AstroClient.ClientUI.ActionMenuButtons
{
    using AstroActionMenu.Api;
    using AstroLibrary.Console;
    using UnityEngine;
    using WorldLights;
    using Color = System.Drawing.Color;

    internal class ActionLightsMenu : GameEvents
    {
        internal override void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Lights Option", () =>
            {
                // TODO: Add Textures!
                CustomSubMenu.AddToggle("Toggle Fullbright (RenderSettings)", LightControl.FullbrightByRender, ToggleValue => { LightControl.FullbrightByRender = ToggleValue; }, null, false);
                CustomSubMenu.AddToggle("Toggle RenderSettings Fog", RenderSettings.fog, ToggleValue => { LightControl.ToggleFog(ToggleValue); }, null, false);
                CustomSubMenu.AddToggle("Toggle Fullbright (Head)", LightControl.IsHeadLightActive, ToggleValue => { LightControl.IsHeadLightActive = ToggleValue; }, null, false);
                CustomSubMenu.AddButton("Spawn Flashlight", () => { Astro_Flashlight.SpawnFlashlight(); }, null, false);
                CustomSubMenu.AddButton("Destroy Flashlights", () => { Astro_Flashlight.DestroyAllFlashLights(); }, null, false);
            });

            ModConsole.Log("Lights Module Editor is ready!", Color.Green);
        }
    }
}