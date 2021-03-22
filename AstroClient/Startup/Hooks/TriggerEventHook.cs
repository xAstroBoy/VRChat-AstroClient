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

namespace AstroClient.Startup.Hooks
{
    public class TriggerEventHook : Overridables
    {
        private HarmonyInstance harmony;

        public static event EventHandler<VRC_EventDispatcherRFC_TriggerEventArgs> Event_VRC_EventDispatcherRFC_triggerEvent;



        public override void OnApplicationStart()
        {
            HookTriggerEvent();
        }


        private void HookTriggerEvent()
        {
            if (harmony == null)
            {
                harmony = HarmonyInstance.Create(BuildInfo.Name + " TriggerEventHook");
            }
            ModConsole.Log("Hooking TriggerEvent");
            var xrefs = XrefScanner.XrefScan(typeof(VRC_EventDispatcherRFC).GetMethod(nameof(VRC_EventDispatcherRFC.TriggerEvent)));
            foreach (var x in xrefs)
            {
                if (x.Type == XrefType.Method && x.TryResolve() != null && x.TryResolve().DeclaringType == typeof(VRC_EventDispatcherRFC))
                {
                    var methodToPatch = (MethodInfo)x.TryResolve();
                    harmony.Patch(methodToPatch, new HarmonyMethod(typeof(TriggerEventHook).GetMethod(nameof(TriggerEventHookEvent), BindingFlags.Public | BindingFlags.Static)));
                    break;
                }
            }
        }

        public static bool TriggerEventHookEvent(VRC_EventHandler __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
        {
            try
            {
                Event_VRC_EventDispatcherRFC_triggerEvent?.Invoke(null, new VRC_EventDispatcherRFC_TriggerEventArgs(__0, __1, __2, __3, __4));
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }


    }
}
