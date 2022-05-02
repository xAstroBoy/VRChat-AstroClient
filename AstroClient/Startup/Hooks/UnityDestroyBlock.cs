
using System.Collections.Generic;
using AstroClient.ClientActions;
using Boo.Lang.Compiler.Ast;

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


    // This will act as Shield for worlds that tends to destroy Udon components to prevent Udon exploiters from accessing them.
    /// <summary>
    /// THE MAJORITY OF THE TIMES, THIS NEEDS TO STAY DEACTIVATED!
    /// </summary>
    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class UnityDestroyBlock : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeave;
        }

        private void OnRoomLeave()
        {
            if(MonitorDestroyingEvent)
            {
                GameObjectsPathsToNotDestroy.Clear();
                OnDestroyBlocked = null;
                MonitorDestroyingEvent = false;
            }
        }


        private static AstroPatch OnDestroyBlock_1 { get; set; }
        private static AstroPatch OnDestroyBlock_2 { get; set; }
        private static AstroPatch OnDestroyBlock_3 { get; set; }
        private static AstroPatch OnDestroyBlock_4 { get; set; }

        private static List<string> GameObjectsPathsToNotDestroy { get; set; } = new List<string>();

        internal static Action<string> OnDestroyBlocked { get; set; }

        internal static void AddBlock(string Path)
        {
            if(!GameObjectsPathsToNotDestroy.Contains(Path))
            {
                GameObjectsPathsToNotDestroy.Add(Path);
            }
        }

        internal static void AddBlock(GameObject obj)
        {
            if (obj != null)
            {
                AddBlock(obj.transform);
            }

        }

        internal static void AddBlock(Transform obj)
        {
            if (obj != null)
            {
                AddBlock(GetPath(obj));
            }
        }


        internal static void RemoveBlock(string Path)
        {
            if (!GameObjectsPathsToNotDestroy.Contains(Path))
            {
                GameObjectsPathsToNotDestroy.Add(Path);
            }
        }

        internal static void RemoveBlock(GameObject obj)
        {
            if (obj != null)
            {
                RemoveBlock(obj.transform);
            }

        }

        internal static void RemoveBlock(Transform obj)
        {
            if (obj != null)
            {
                RemoveBlock(GetPath(obj));
            }
        }


        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UnityDestroyBlock).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            OnDestroyBlock_1 = new AstroPatch(typeof(UnityEngine.Object).GetMethod(nameof(UnityEngine.Object.Destroy), new Type[1] { typeof(UnityEngine.Object) }), GetPatch(nameof(MonitoredDestroy)));
            OnDestroyBlock_2 = new AstroPatch(typeof(UnityEngine.Object).GetMethod(nameof(UnityEngine.Object.Destroy), new Type[2] { typeof(UnityEngine.Object), typeof(float) }), GetPatch(nameof(MonitoredDestroy)));
            OnDestroyBlock_3 = new AstroPatch(typeof(UnityEngine.Object).GetMethod(nameof(UnityEngine.Object.DestroyImmediate), new Type[1] { typeof(UnityEngine.Object) }), GetPatch(nameof(MonitoredDestroy)));
            OnDestroyBlock_4 = new AstroPatch(typeof(UnityEngine.Object).GetMethod(nameof(UnityEngine.Object.DestroyImmediate), new Type[2] { typeof(UnityEngine.Object), typeof(bool) }), GetPatch(nameof(MonitoredDestroy)));
            Log.Warn("Those events will be unpatched now, as it will break the game.");
            MonitorDestroyingEvent = false; // Deactivate the patches, as we have confirmation of patching success.
        }

        private static bool MonitoredDestroy(UnityEngine.Object __0)
        {
            if (!MonitorDestroyingEvent) return true;
            if (__0 != null)
            {
                var il2Cpptype = __0.GetIl2CppType().FullName;

                switch (il2Cpptype)
                {
                    case "UnityEngine.GameObject":
                        {
                            var obj = __0.Cast<UnityEngine.GameObject>();
                            if (obj != null)
                            {
                                var path = GetPath(obj);
                                if (GameObjectsPathsToNotDestroy.Contains(path))
                                {
                                    Log.Debug($"Blocked Destroy : {path}");
                                    if(OnDestroyBlocked != null)
                                    {
                                        OnDestroyBlocked.SafetyRaiseWithParams(path);
                                    }
                                    return false;
                                }
                                if (!path.StartsWith("/UserInterface"))
                                {
                                    if (ReportEvent)
                                    {
                                        Log.Debug($"Destroyed : {path}");
                                    }
                                }
                            }
                            return true;
                        }
                    case "UnityEngine.Transform":
                        {
                            var obj = __0.Cast<UnityEngine.Transform>();
                            if (obj != null)
                            {
                                var path = GetPath(obj);
                                if (GameObjectsPathsToNotDestroy.Contains(path))
                                {
                                    Log.Debug($"Blocked Destroy : {path}");
                                    if (OnDestroyBlocked != null)
                                    {
                                        OnDestroyBlocked.SafetyRaiseWithParams(path);
                                    }
                                    return false;
                                }
                                if (!path.StartsWith("/UserInterface"))
                                {
                                    if (ReportEvent)
                                    {
                                        Log.Debug($"Destroyed : {path}");
                                    }
                                }
                            }
                            return true;
                        }
                    default:
                        return true;
                }
            }

            return true;
        }

        private static string GetPath(GameObject obj)
        {
           return GetPath(obj.transform);
        }
        private static string GetPath(Transform current)
        {
            if (current.parent == null)
                return "/" + current.name;
            return GetPath(current.parent) + "/" + current.name;
        }
        private static bool _MonitorDestroyingEvent = true; // Default is true, as the patches will be on.

        internal static bool ReportEvent = false;

        internal static bool MonitorDestroyingEvent
        {
            get => _MonitorDestroyingEvent;
            set
            {
                if(_MonitorDestroyingEvent != value)
                {
                    if(value)
                    {
                        OnDestroyBlock_1.Patch();
                        OnDestroyBlock_2.Patch();
                        OnDestroyBlock_3.Patch();
                        OnDestroyBlock_4.Patch();

                    }
                    else
                    {
                        OnDestroyBlock_1.Unpatch();
                        OnDestroyBlock_2.Unpatch();
                        OnDestroyBlock_3.Unpatch();
                        OnDestroyBlock_4.Unpatch();

                    }

                }
                _MonitorDestroyingEvent = value;
            }
        }

    }
}