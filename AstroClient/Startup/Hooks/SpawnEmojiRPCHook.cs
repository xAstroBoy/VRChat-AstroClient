namespace AstroClient.Startup.Hooks
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using MelonLoader;
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using UnhollowerBaseLib;


    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class SpawnEmojiRPCHook : GameEvents
    {
        internal static  event EventHandler<SpawnEmojiArgs> Event_SpawnEmojiRPC;

        internal override void ExecutePriorityPatches()
        {
            HookSpawnEmojiRPC();
        }


        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static IntPtr GetPointerPatch(string patch)
        {
            return typeof(SpawnEmojiRPCHook).GetMethod(patch, BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer();
        }



        private void HookSpawnEmojiRPC()
        {
            unsafe
            {
                try
                {
                    ModConsole.DebugLog("Hooking SpawnEmojiRPC");
                    var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils
                        .GetIl2CppMethodInfoPointerFieldForGeneratedMethod(
                            typeof(VRCPlayer).GetMethod(
                                nameof(VRCPlayer
                                    .SpawnEmojiRPC))).GetValue(null);
                    MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), GetPointerPatch(nameof(SpawnEmojiRPCPatch)));
                    _SpawnEmojiRPCDelegate = Marshal.GetDelegateForFunctionPointer<SpawnEmojiRPCDelegate>(originalMethod);
                    if (_SpawnEmojiRPCDelegate != null)
                    {
                        ModConsole.DebugLog("Hooked SpawnEmojiRPC");
                    }
                    else
                    {
                        ModConsole.Error("Failed to hook SpawnEmojiRPC!");
                    }
                }
                catch (Exception e)
                {
                    ModConsole.Error("Failed to hook SpawnEmojiRPC!, ERROR : " + e);
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpawnEmojiRPCDelegate(IntPtr thisPtr, int emoji, IntPtr PlayerPtr);

        private static SpawnEmojiRPCDelegate _SpawnEmojiRPCDelegate;

        private static void SpawnEmojiRPCPatch(IntPtr thisPtr, int emoji, IntPtr PlayerPtr)
        {
            try
            {
                if (thisPtr != IntPtr.Zero && PlayerPtr != IntPtr.Zero)
                {
                    var player = new VRCPlayer(thisPtr);

                    if (player != null)
                    {
                        Event_SpawnEmojiRPC.SafetyRaise(new SpawnEmojiArgs(player, emoji));
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.Error(e.Message);
            }
            finally
            {
                _SpawnEmojiRPCDelegate(thisPtr, emoji, PlayerPtr);
            }
        }
    }
}