namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetos;
    using Config;
    using HarmonyLib;
    using Tools.Extensions;
    using UnhollowerRuntimeLib.XrefScans;
    using VRC.SDKBase;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class WorldTriggerHook : AstroEvents
    {

        internal static bool SendTriggerToEveryone = false;

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
            new AstroPatch(typeof(VRC_EventHandler).GetMethod(nameof(VRC_EventHandler.InternalTriggerEvent)), GetPatch(nameof(OnEventDataSentPatch)));
        }


        private static bool OnEventDataSentPatch(ref VRC_EventHandler.VrcBroadcastType __1)
        {
            if (SendTriggerToEveryone == true && (__1 != VRC_EventHandler.VrcBroadcastType.Always || __1 != VRC_EventHandler.VrcBroadcastType.AlwaysBufferOne || __1 != VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered))
            {
                __1 = VRC_EventHandler.VrcBroadcastType.Always;
            }
            return true;
        }

    }
}