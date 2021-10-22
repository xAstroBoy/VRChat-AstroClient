using MelonLoader;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using VRC.Playables;
using VRC.SDKBase;
using VRC;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace AstroClient.AvatarParametersEditor
{
    using System.Drawing;
    using ActionMenu;
    using AstroActionMenu.Api;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using CheetoLibrary;
    using Components;
    using UnityEngine.Playables;
    using WorldLights;

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
                CustomSubMenu.AddButton("Spawn Flashlight", () => {Astro_Flashlight.SpawnFlashlight(); }, null, false);
                CustomSubMenu.AddButton("Destroy Flashlights", () => {Astro_Flashlight.DestroyAllFlashLights(); }, null, false);
            });

            ModConsole.Log("Lights Module Editor is ready!", Color.Green);
        }

        

    }
}