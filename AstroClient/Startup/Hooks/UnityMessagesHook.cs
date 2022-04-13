
namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using System.Linq;
    using AstroClient.xAstroBoy.Extensions;
    using UnityEngine;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class UnityMessagesHook : AstroEvents
    {

        internal static event Action<string> Event_OnUnityLog;
        internal static event Action<string> Event_OnUnityWarning;
        internal static event Action<string> Event_OnUnityError;

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UnityMessagesHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(Debug).GetMethods().First(x => x.Name == "Log" && x.GetParameters().Length == 1), GetPatch(nameof(Debug)));
            new AstroPatch(typeof(Debug).GetMethods().First(x => x.Name == "LogWarning" && x.GetParameters().Length == 1), GetPatch(nameof(DebugWarning)));
            new AstroPatch(typeof(Debug).GetMethods().First(x => x.Name == "LogError" && x.GetParameters().Length == 1), GetPatch(nameof(DebugError)));
        }

        private static void Debug(ref Il2CppSystem.Object __0)
        {
            if (__0 == null) return;
            var msg = Il2CppSystem.Convert.ToString(__0);
            if (msg.IsNullOrEmptyOrWhiteSpace()) return;
            Event_OnUnityLog.SafetyRaiseWithParams(msg);
        }
        private static void DebugWarning(ref Il2CppSystem.Object __0)
        {
            if (__0 == null) return;
            var msg = Il2CppSystem.Convert.ToString(__0);
            if (msg.IsNullOrEmptyOrWhiteSpace()) return;
            Event_OnUnityWarning.SafetyRaiseWithParams(msg);
        }

        private static void DebugError(ref Il2CppSystem.Object __0)
        {
            if (__0 == null) return;
            var msg = Il2CppSystem.Convert.ToString(__0);
            if (msg.IsNullOrEmptyOrWhiteSpace()) return;
            Event_OnUnityError.SafetyRaiseWithParams(msg);

        }


    }
}