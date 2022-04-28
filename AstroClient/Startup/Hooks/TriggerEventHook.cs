﻿using AstroClient.ClientActions;

namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Reflection;
    
    using Cheetos;
    using Config;
    using HarmonyLib;
    using Tools.Extensions;
    using UnhollowerRuntimeLib.XrefScans;
    using VRC.SDKBase;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class TriggerEventHook : AstroEvents
    {


        internal override void ExecutePriorityPatches()
        {
            HookTriggerEvent();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(TriggerEventHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private void HookTriggerEvent()
        {
            Log.Debug("Hooking TriggerEvent");
            var xrefs = XrefScanner.XrefScan(typeof(VRC_EventDispatcherRFC).GetMethod(nameof(VRC_EventDispatcherRFC.TriggerEvent)));
            foreach (var x in xrefs)
            {
                if (x.Type == XrefType.Method && x.TryResolve() != null && x.TryResolve().DeclaringType == typeof(VRC_EventDispatcherRFC))
                {
                    var methodToPatch = (MethodInfo)x.TryResolve();
                    new AstroPatch(methodToPatch, GetPatch(nameof(TriggerEventHookEvent)));
                    break;
                }
            }
        }

        private static bool TriggerEventHookEvent(VRC_EventHandler __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
        {
            try
            {
                if (ConfigManager.General.LogTriggerEvents)
                {
                    string eventhandler = string.Empty;
                    string vrcevent = string.Empty;

                    eventhandler = __0 != null ? __0.ToString() : "null";
                    vrcevent = __1.ParameterObject != null ? __1.ParameterObject.name : "null";

                    if (!vrcevent.ToLower().Equals("uspeak")) // Ignore USPEAK.
                    {
                        Log.Debug($"Event : VRC_EventHandler : {eventhandler}, VrcEvent : {vrcevent}, VrcBroadcastType : {__2}, UnknownInt : {__3}, UnknownFloat : {__4}");
                    }
                }

                ClientEventActions.VRC_EventDispatcherRFC_triggerEvent.SafetyRaiseWithParams(__0, __1, __2, __3, __4);
                return true;
            }
            catch { }
            {
                return true;
            }
        }
    }
}