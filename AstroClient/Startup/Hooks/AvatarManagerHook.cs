﻿namespace AstroClient.Startup.Hooks
{
    using AstroClientCore.Events;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using MelonLoader;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using UnhollowerBaseLib;
    using UnityEngine;
    using VRC.Core;
    using Object = UnityEngine.Object;

    internal class AvatarManagerHook : GameEvents
    {
        internal static  event EventHandler<OnAvatarSpawnArgs> Event_OnAvatarSpawn;

        internal override void OnApplicationStart() => HookAvatarManager();

        private void HookAvatarManager()
        {
            var matchingMethods = typeof(AssetManagement)
    .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly).Where(it =>
        it.Name.StartsWith("Method_Public_Static_Object_Object_Vector3_Quaternion_Boolean_Boolean_Boolean_") && it.GetParameters().Length == 6).ToList();

            for (int i = 0; i < matchingMethods.Count; i++)
            {
                MethodInfo matchingMethod = matchingMethods[i];
                unsafe
                {
                    var originalMethodPointer = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(matchingMethod).GetValue(null);

                    ObjectInstantiateDelegate originalInstantiateDelegate = null;

                    ObjectInstantiateDelegate replacement = (assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer) =>
                        ObjectInstantiatePatch(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer, originalInstantiateDelegate);

                    ourPinnedDelegates.Add(replacement);

                    MelonUtils.NativeHookAttach((IntPtr)(&originalMethodPointer), Marshal.GetFunctionPointerForDelegate(replacement));

                    originalInstantiateDelegate = Marshal.GetDelegateForFunctionPointer<ObjectInstantiateDelegate>(originalMethodPointer);
                }
            }

            Type[] array = typeof(VRCAvatarManager).GetNestedTypes();
            for (int i = 0; i < array.Length; i++)
            {
                Type nestedType = array[i];
                var moveNext = nestedType.GetMethod("MoveNext");
                if (moveNext == null) continue;
                var avatarManagerField = nestedType.GetProperties().SingleOrDefault(it => it.PropertyType == typeof(VRCAvatarManager));
                if (avatarManagerField == null) continue;

                var fieldOffset = (int)IL2CPP.il2cpp_field_get_offset((IntPtr)UnhollowerUtils
                    .GetIl2CppFieldInfoPointerFieldForGeneratedFieldAccessor(avatarManagerField.GetMethod)
                    .GetValue(null));

                unsafe
                {
                    var originalMethodPointer = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(moveNext).GetValue(null);

                    //originalMethodPointer = XrefScannerLowLevel.JumpTargets(originalMethodPointer).First();

                    VoidDelegate originalDelegate = null;

                    void TaskMoveNextPatch(IntPtr taskPtr, IntPtr nativeMethodInfo)
                    {
                        var avatarManager = *(IntPtr*)(taskPtr + fieldOffset - 16);
                        using (new AvatarManagerCookie(new VRCAvatarManager(avatarManager)))
                            originalDelegate(taskPtr, nativeMethodInfo);
                    }

                    var patchDelegate = new VoidDelegate(TaskMoveNextPatch);
                    ourPinnedDelegates.Add(patchDelegate);

                    MelonUtils.NativeHookAttach((IntPtr)(&originalMethodPointer), Marshal.GetFunctionPointerForDelegate(patchDelegate));
                    originalDelegate = Marshal.GetDelegateForFunctionPointer<VoidDelegate>(originalMethodPointer);
                }
            }

            ModConsole.Log("Hooked VRCAvatarManager");
        }

        private static IntPtr ObjectInstantiatePatch(IntPtr assetPtr, Vector3 pos, Quaternion rot,
    byte allowCustomShaders, byte isUI, byte validate, IntPtr nativeMethodPointer, ObjectInstantiateDelegate originalInstantiateDelegate)
        {
            if (AvatarManagerCookie.CurrentManager == null || assetPtr == IntPtr.Zero)
            {
                return originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);
            }

            var avatarManager = AvatarManagerCookie.CurrentManager;
            var vrcPlayer = avatarManager.field_Private_VRCPlayer_0;
            if (vrcPlayer == null) return originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);

            //if (vrcPlayer == VRCPlayer.field_Internal_Static_VRCPlayer_0) // never apply to self
            //	return originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);

            var go = new Object(assetPtr).TryCast<GameObject>();
            if (go == null)
                return originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);

            var wasActive = go.activeSelf;
            go.SetActive(false);
            var result = originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);
            go.SetActive(wasActive);
            if (result == IntPtr.Zero) return result;
            var instantiated = new GameObject(result);
            try
            {
                ModConsole.Log("Attempting to invoke avatar spawning..");
                OnAvatarSpawnEvent(AvatarManagerCookie.CurrentManager, instantiated);
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"Exception when cleaning avatar: {ex}");
            }

            return result;
        }

        private static List<object> ourPinnedDelegates = new List<object>();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr ObjectInstantiateDelegate(IntPtr assetPtr, Vector3 pos, Quaternion rot, byte allowCustomShaders, byte isUI, byte validate, IntPtr nativeMethodPointer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VoidDelegate(IntPtr thisPtr, IntPtr nativeMethodInfo);

        private readonly struct AvatarManagerCookie : IDisposable
        {
            internal static VRCAvatarManager CurrentManager;
            private readonly VRCAvatarManager myLastManager;

            public AvatarManagerCookie(VRCAvatarManager avatarManager)
            {
                myLastManager = CurrentManager;
                CurrentManager = avatarManager;
            }

            public void Dispose()
            {
                CurrentManager = myLastManager;
            }
        }

        private static void OnAvatarSpawnEvent(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
            Event_OnAvatarSpawn.SafetyRaise(new OnAvatarSpawnArgs(VRCAvatarManager, Avatar));
        }
    }
}