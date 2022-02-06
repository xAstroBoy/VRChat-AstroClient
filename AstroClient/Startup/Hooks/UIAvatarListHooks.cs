namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Linq;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetos;
    using Config;
    using Harmony;
    using Tools.Extensions;
    using UnhollowerRuntimeLib.XrefScans;
    using VRC.SDKBase;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class UIAvatarListHooks : AstroEvents
    {

        internal static event EventHandler<VRC_EventDispatcherRFC_TriggerEventArgs> Event_VRC_EventDispatcherRFC_triggerEvent;

        internal override void ExecutePriorityPatches()
        {
            HookTriggerEvent();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UIAvatarListHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private void HookTriggerEvent()
        {
            ModConsole.DebugLog("Hooking TriggerEvent");

            // t.BaseType == typeof(UiVRCList)
            // Type t.Name == "UiUserList";
            // MethodInfo m.Name.Contains("APIUser");
            // MethodInfo  m.Name.Contains("FriendGroups");
            // 
            // ??
            // m.ReturnType == typeof(void)
            // m.GetParameters()[0].ParameterType == typeof(VRCUiContentButton)
            // m.GetParameters().Length == 2
            //  m.GetParameters()[1].ParameterType == typeof(Il2CppSystem.Object);

            //var xrefs = XrefScanner.XrefScan(typeof(UiAvatarList).GetMethods().Where()
            //foreach (var x in xrefs)
            //{
            //    if (x.Type == XrefType.Method && x.TryResolve() != null && x.TryResolve().DeclaringType == typeof(VRC_EventDispatcherRFC))
            //    {
            //        var methodToPatch = (MethodInfo)x.TryResolve();
            //        new AstroPatch(methodToPatch, GetPatch(nameof(TriggerEventHookEvent)));
            //        break;
            //    }
            //}
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