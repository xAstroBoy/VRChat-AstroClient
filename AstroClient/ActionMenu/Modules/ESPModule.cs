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
    using Startup.Buttons;
    using UnityEngine.Playables;
    using WorldLights;

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