namespace AstroClient.Startup.Hooks
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using Harmony;
    using System;
    using System.Reflection;
    using UnhollowerRuntimeLib.XrefScans;
    using VRC_EventHandler = VRC.SDKBase.VRC_EventHandler;

    public class TriggerEventHook : GameEvents
    {
        private HarmonyLib.Harmony harmony;

        public static event EventHandler<VRC_EventDispatcherRFC_TriggerEventArgs> Event_VRC_EventDispatcherRFC_triggerEvent;

        public override void ExecutePriorityPatches()
        {
            HookTriggerEvent();
        }

        private void HookTriggerEvent()
        {
            if (harmony == null)
            {
                harmony = new HarmonyLib.Harmony(BuildInfo.Name + " TriggerEventHook");
            }
            ModConsole.DebugLog("Hooking TriggerEvent");
            var xrefs = XrefScanner.XrefScan(typeof(VRC_EventDispatcherRFC).GetMethod(nameof(VRC_EventDispatcherRFC.TriggerEvent)));
            foreach (var x in xrefs)
            {
                if (x.Type == XrefType.Method && x.TryResolve() != null && x.TryResolve().DeclaringType == typeof(VRC_EventDispatcherRFC))
                {
                    var methodToPatch = (MethodInfo)x.TryResolve();
                    _ = harmony.Patch(methodToPatch, new HarmonyMethod(typeof(TriggerEventHook).GetMethod(nameof(TriggerEventHookEvent), BindingFlags.Public | BindingFlags.Static)));
                    break;
                }
            }
        }

        public static bool TriggerEventHookEvent(VRC_EventHandler __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
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
                        ModConsole.DebugLog($"Event : VRC_EventHandler : {eventhandler}, VrcEvent : {vrcevent}, VrcBroadcastType : {__2}, UnknownInt : {__3}, UnknownFloat : {__4}");
                    }
                }

                Event_VRC_EventDispatcherRFC_triggerEvent.SafetyRaise(new VRC_EventDispatcherRFC_TriggerEventArgs(__0, __1, __2, __3, __4));
                return true;
            }
            catch { }
            {
                return true;
            }
        }
    }
}