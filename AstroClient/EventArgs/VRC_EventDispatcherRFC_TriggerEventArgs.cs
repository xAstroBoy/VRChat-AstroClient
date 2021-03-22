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
    public class VRC_EventDispatcherRFC_TriggerEventArgs : EventArgs
    {

        public VRC_EventHandler VRC_EventHandler;
        public VRC_EventHandler.VrcEvent VrcEvent;
        public VRC_EventHandler.VrcBroadcastType VrcBroadcastType;
        public int UnknownInt;
        public float UnknownFloat;

        public VRC_EventDispatcherRFC_TriggerEventArgs(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
        {
            this.VRC_EventHandler = VRC_EventHandler;
            this.VrcEvent = VrcEvent;
            this.VrcBroadcastType = VrcBroadcastType;
            this.UnknownInt = UnknownInt;
            this.UnknownFloat = UnknownFloat;
        }
    }
}