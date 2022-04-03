using System.Collections.Generic;

namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using AstroEventArgs;
    using Constants;
    using MelonLoader;
    using Tools.Extensions;
    using UnhollowerBaseLib;
    using xAstroBoy.Utility;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class OnWorldRevealHook : AstroEvents
    {
        internal static event Action<string, string, List<string>, string, string> Event_OnWorldReveal;

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            if (Bools.IsDeveloper)
                ModConsole.DebugLog($"Scene Name: {sceneName}");
        }

        internal override void ExecutePriorityPatches()
        {
            HookFadeTo();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static IntPtr GetPointerPatch(string patch)
        {
            return typeof(OnWorldRevealHook).GetMethod(patch, BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer();
        }

        private static void HookFadeTo()
        {
            unsafe
            {
                ModConsole.DebugLog("Hooking FadeTo");
                var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(typeof(VRCUiManager).GetMethod(nameof(VRCUiManager.Method_Public_Void_String_Single_Action_1))).GetValue(null);
                MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), GetPointerPatch(nameof(FadeToPatch)));
                _fadeToDelegate = Marshal.GetDelegateForFunctionPointer<FadeToDelegate>(originalMethod);
                if (_fadeToDelegate != null)
                {
                    ModConsole.DebugLog("Hooked OnFadeTo");
                }
                else
                {
                    ModConsole.Error("Failed to hook OnFadeTo!");
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void FadeToDelegate(IntPtr thisPtr, IntPtr fadeTypePtr, float duration, IntPtr action);

        private static FadeToDelegate _fadeToDelegate;

        private static void FadeToPatch(IntPtr thisPtr, IntPtr fadeTypePtr, float duration, IntPtr action)
        {
            try
            {
                if (thisPtr != IntPtr.Zero && fadeTypePtr != IntPtr.Zero)
                {
                    string fadeType = IL2CPP.Il2CppStringToManaged(fadeTypePtr);
                    ModConsole.DebugLog("FadeType Called : " + fadeType + " With duration : " + duration);
                    if (fadeType.Equals("BlackFade") && duration.Equals(0f) &&
                        RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
                    {
                        Event_OnWorldReveal.SafetyRaise(WorldUtils.WorldID, WorldUtils.WorldName, WorldUtils.WorldTags, WorldUtils.AuthorName, WorldUtils.AssetURL);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                _fadeToDelegate(thisPtr, fadeTypePtr, duration, action);
            }
        }
    }
}