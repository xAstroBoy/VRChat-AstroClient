using Harmony;
using MelonLoader;
using RubyButtonAPI;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using VRC;
using UnityEngine.UI;
using Console = CheetosConsole.Console;
using Color = System.Drawing.Color;
using AstroClient.components;
using VRC_EventHandler = VRC.SDKBase.VRC_EventHandler;
using AstroClient.ConsoleUtils;
using AstroClient.World.Hub;

namespace AstroClient
{
    public class OnAvatarSpawnArgs : EventArgs
    {

        public GameObject Avatar;
        public VRC.SDKBase.VRC_AvatarDescriptor VRC_AvatarDescriptor;
        public bool state;

        public OnAvatarSpawnArgs(GameObject avatar, VRC.SDKBase.VRC_AvatarDescriptor VRC_AvatarDescriptor, bool state)
        {
            this.Avatar = avatar;
            this.VRC_AvatarDescriptor = VRC_AvatarDescriptor;
            this.state = state;
        }
    }
}