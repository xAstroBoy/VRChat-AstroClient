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
    using Features.Player.Movement.Exploit;
    using Startup.Buttons;
    using UnityEngine.Playables;
    using WorldLights;

    internal class MovementModule : GameEvents
    {
        internal override void OnApplicationStart()
        {

            AMUtils.AddToModsFolder("Movement Options", () =>
            {
                // TODO: Add Textures!
                CustomSubMenu.AddButton("Spawn EnderPearl", () => {AstroEnderPearl.SpawnEnderPearl(); }, null, false);
                CustomSubMenu.AddToggle("Toggle Ghost", MovementSerializer.SerializerActivated, ToggleValue => { VRChat_Map_ESP_Menu.Toggle_Trigger_ESP = ToggleValue; }, null, false);

            });

            ModConsole.Log("Movement Module is ready!", Color.Green);
        }

        

    }
}