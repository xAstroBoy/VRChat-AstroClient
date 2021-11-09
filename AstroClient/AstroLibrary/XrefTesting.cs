namespace DayClientML2.Utility
{
    using System;
    using System.Linq;
    using System.Reflection;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using UnhollowerRuntimeLib.XrefScans;
    using UnityEngine;

    public static class XrefTesting
    {
        public static MethodInfo OnPhotonPlayerJoinMethod
        {
            get
            {
                if (_OnPhotonPlayerJoinMethod != null)
                {
                    return _OnPhotonPlayerJoinMethod;
                }
                return _OnPhotonPlayerJoinMethod = typeof(NetworkManager).GetMethods().Single(delegate (MethodInfo it)
                {
                    if (it.ReturnType == typeof(void) && it.GetParameters().Length == 1 && it.GetParameters()[0].ParameterType == typeof(Photon.Realtime.Player))
                    {
                        return XrefScanner.XrefScan(it).Any(jt =>
                        {
                            if (jt.Type == XrefType.Global)
                            {
                                Il2CppSystem.Object @object = jt.ReadAsObject();
                                if (@object != null)
                                {
                                    if (@object.ToString().Contains("Enter"))
                                    {
                                        ModConsole.DebugLog($"[Debug] Found [JOIN] Method! [{it.Name} with {@object.ToString()}]");
                                        _OnPhotonPlayerJoinMethod = it;
                                        return true;
                                    }
                                }
                                return false;
                            }
                            return false;
                        });
                    }
                    return false;
                });
            }
        }

        private static MethodInfo _OnPhotonPlayerJoinMethod;

        public static MethodInfo OnPhotonPlayerLeftMethod
        {
            get
            {
                if (_OnPhotonPlayerLeftMethod != null)
                {
                    return _OnPhotonPlayerLeftMethod;
                }
                return _OnPhotonPlayerLeftMethod = typeof(NetworkManager).GetMethods().Single(delegate (MethodInfo it)
                {
                    if (it.ReturnType == typeof(void) && it.GetParameters().Length == 1 && it.GetParameters()[0].ParameterType == typeof(Photon.Realtime.Player))
                    {
                        return XrefScanner.XrefScan(it).Any(jt =>
                        {
                            if (jt.Type == XrefType.Global
                            )
                            {
                                Il2CppSystem.Object @object = jt.ReadAsObject();
                                if (@object != null)
                                {
                                    if (@object.ToString().Contains("Left"))
                                    {
                                        ModConsole.DebugLog($"[Debug] Found [Left] Method! [{it.Name} with {@object.ToString()}]");
                                        _OnPhotonPlayerLeftMethod = it;
                                        return true;
                                    }
                                }
                                return false;
                            }
                            return false;
                        });
                    }
                    return false;
                });
            }
        }

        private static MethodInfo _OnPhotonPlayerLeftMethod;

        public static MethodInfo ShowScreenMethod
        {
            get
            {
                if (_ShowScreenMethod != null)
                {
                    return _ShowScreenMethod;
                }
                return _ShowScreenMethod = typeof(VRCUiManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single(delegate (MethodInfo it)
                {
                    if (it.ReturnType == typeof(VRCUiPage) && it.GetParameters().Length == 1 && it.GetParameters()[0].ParameterType == typeof(VRCUiPage))
                    {
                        return XrefScanner.XrefScan(it).Any(jt =>
                        {
                            if (jt.Type == XrefType.Global)
                            {
                                Il2CppSystem.Object @object = jt.ReadAsObject();
                                return (@object?.ToString()) == "Screen Not Found - ";
                            }
                            return false;
                        });
                    }
                    return false;
                });
            }
        }

        private static MethodInfo _ShowScreenMethod;

        public static MethodInfo IsRoomAuthor
        {
            get
            {
                if (_IsRoomAuthor != null)
                {
                    return _IsRoomAuthor;
                }
                return _IsRoomAuthor = typeof(RoomManager).GetMethods().Single(delegate (MethodInfo it)
                {
                    if (it.ReturnType == typeof(bool) && it.GetParameters().Length == 0)
                    {
                        return XrefScanner.XrefScan(it).Any(jt =>
                        {
                            if (jt.Type == XrefType.Method
                            && jt.TryResolve() != null
                            && jt.TryResolve().IsPublic
                            && !jt.TryResolve().IsStatic
                            )
                            {
                                ModConsole.Log($"[Debug] Found IsRoomAuthor Method! [{jt.TryResolve().DeclaringType.Name}.{jt.TryResolve().Name}] in [{it.Name}]");
                                _IsRoomAuthor = it;
                            }
                            return false;
                        });
                    }
                    return false;
                });
            }
        }

        private static MethodInfo _IsRoomAuthor;

        public static MethodInfo DestroyPortal
        {
            get
            {
                if (_destroyportal == null)
                {
                    try
                    {
                        return _destroyportal = typeof(PortalInternal).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single(delegate (MethodInfo it)
                        {
                            if (it.ReturnType == typeof(void) && it.GetParameters().Length == 0)
                            {
                                return XrefScanner.XrefScan(it).Any(jt =>
                               {
                                   if (jt.Type == XrefType.Global)
                                   {
                                       Il2CppSystem.Object @object = jt.ReadAsObject();
                                       return (@object?.ToString()).Contains("DestroyPortal");
                                   }
                                   if (jt.Type == XrefType.Method
                                   && jt.TryResolve() != null
                                   && jt.TryResolve().GetParameters().Length == 2
                                   && jt.TryResolve().GetParameters()[1].ParameterType == typeof(PortalInternal)
                                   && jt.TryResolve().IsStatic
                                   )
                                   {
                                       _destroyportal = it;
                                       ModConsole.Log($"[Debug] Found Destroy Portal Method! [{jt.TryResolve().DeclaringType.Name}.{jt.TryResolve().Name}] in [{it.Name}]");
                                       return true;
                                   }
                                   return false;
                               });
                            }
                            return false;
                        });
                    }
                    catch
                    {
                    }
                    if (_destroyportal == null)
                    {
                        ModConsole.Error($"[Debug] Didnt Find Destroy Portal Method!");
                    }
                }
                return _destroyportal;
            }
        }

        private static MethodInfo _destroyportal;

        public static MethodInfo OpenQuickMenu
        {
            get
            {
                if (_openquickmenu == null)
                {
                    try
                    {
                        var xrefs = XrefScanner.XrefScan(typeof(QuickMenu).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single(delegate (MethodInfo it)
                        {
                            if (it.ReturnType == typeof(void) && it.GetParameters().Length == 1 && it.GetParameters()[0].ParameterType == typeof(bool))
                            {
                                return XrefScanner.XrefScan(it).Any(jt =>
                                {
                                    if (jt.Type == XrefType.Method
                                    && jt.TryResolve() != null
                                    && jt.TryResolve().GetParameters().Length == 1
                                    && jt.TryResolve().GetParameters()[0].ParameterType == typeof(bool)
                                    && jt.TryResolve().IsStatic == true
                                    )
                                    {
                                        ModConsole.DebugLog($"[Debug] Found Open QuickMenu Method! [{jt.TryResolve().DeclaringType.Name}.{jt.TryResolve().Name}] in [{it.Name}]");
                                        _openquickmenu = it;
                                        //return true;
                                    }
                                    return false;
                                });
                            }
                            return false;
                        }));
                        if (_openquickmenu == null)
                        {
                            ModConsole.Error($"[Debug] Didnt Find OpenQuickMenu Method!");
                        }
                    }
                    catch
                    {
                    }
                }
                return _openquickmenu;
            }
        }

        private static MethodInfo _openquickmenu;

        public static MethodInfo CloseQuickMenu
        {
            get
            {
                if (_closequickmenu == null)
                {
                    try
                    {
                        var xrefs = XrefScanner.XrefScan(typeof(QuickMenu).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single(delegate (MethodInfo it)
                        {
                            if (it.ReturnType == typeof(void) && it.GetParameters().Length == 0)
                            {
                                return XrefScanner.XrefScan(it).Any(jt =>
                                {
                                    if (jt.Type == XrefType.Method && jt.TryResolve() != null
                                    && jt.TryResolve().GetParameters().Length == 1
                                    && jt.TryResolve().GetParameters()[0].ParameterType == typeof(QuickMenuContextualDisplay.QuickMenuContext)
                                    && jt.TryResolve().ReflectedType == typeof(QuickMenuContextualDisplay)
                                    && jt.TryResolve().IsStatic == false
                                    )
                                    {
                                        ModConsole.DebugLog($"[Debug] Found Close QuickMenu Method! [{jt.TryResolve().DeclaringType.Name}.{jt.TryResolve().Name}] in [{it.Name}]");
                                        _closequickmenu = it;
                                        //return true;
                                    }
                                    return false;
                                });
                            }
                            return false;
                        }));
                        if (_closequickmenu == null)
                        {
                            ModConsole.Error($"[Debug] Didnt Find Close QuickMenu Method!");
                        }
                    }
                    catch
                    {
                    }
                }
                return _closequickmenu;
            }
        }

        private static MethodInfo _closequickmenu;

        public static MethodInfo SetupQuickmenuForDesktopOrHMD
        {
            get
            {
                if (_SetupQuickmenuForDesktopOrHMD == null)
                {
                    try
                    {
                        var xrefs = XrefScanner.XrefScan(typeof(QuickMenu).GetMethods(BindingFlags.Instance).Single(delegate (MethodInfo it)
                        {
                            //if (it.ReturnType == typeof(void) && it.GetParameters().Length == 1 && it.GetParameters()[0].ParameterType == typeof(bool))
                            if (it.ReturnType == typeof(void))
                            {
                                return XrefScanner.XrefScan(it).Any(jt =>
                                {
                                    if (jt.Type == XrefType.Method && jt.TryResolve() != null
                                    && jt.TryResolve().GetParameters().Length == 1
                                    && jt.TryResolve().GetParameters()[0].ParameterType == typeof(Vector3)
                                    )
                                    {
                                        ModConsole.DebugLog($"[Debug] Found Setup QuickMenu Method! [{jt.TryResolve().DeclaringType.Name}.{jt.TryResolve().Name}] in [{it.Name}]");
                                        _SetupQuickmenuForDesktopOrHMD = it;
                                        //return true;
                                    }
                                    return false;
                                });
                            }
                            return false;
                        }));
                        if (_SetupQuickmenuForDesktopOrHMD == null)
                        {
                            ModConsole.Error($"[Debug] Didnt Find Setup QuickMenu Method!");
                        }
                    }
                    catch
                    {
                    }
                }
                return _SetupQuickmenuForDesktopOrHMD;
            }
        }

        private static MethodInfo _SetupQuickmenuForDesktopOrHMD;

        public static MethodInfo PlaceUiMethod
        {
            get
            {
                if (_placeUi == null)
                {
                    try
                    {
                        var xrefs = XrefScanner.XrefScan(typeof(VRCUiManager).GetMethod(nameof(VRCUiManager.LateUpdate)));
                        foreach (var x in xrefs)
                        {
                            if (x.Type == XrefType.Method && x.TryResolve() != null &&
                                x.TryResolve().GetParameters().Length == 1 &&
                                x.TryResolve().GetParameters()[0].ParameterType == typeof(bool))
                            {
                                ModConsole.DebugLog($"[Debug] Found PlaceUI Method! [{x.TryResolve().DeclaringType.Name}.{x.TryResolve().Name}] in [{nameof(VRCUiManager.LateUpdate)}");
                                _placeUi = (MethodInfo)x.TryResolve();
                                break;
                            }
                        };
                    }
                    catch
                    {
                    }
                }
                return _placeUi;
            }
        }

        private static MethodInfo _placeUi;

        public static AlignTrackingToPlayerDelegate GetAlignTrackingToPlayerDelegate
        {
            get
            {
                if (alignTrackingToPlayerMethod == null)
                {
                    alignTrackingToPlayerMethod = typeof(VRCPlayer).GetMethods(BindingFlags.Instance | BindingFlags.Public).
                        First((MethodInfo m) => m.ReturnType == typeof(void)
                        && m.GetParameters().Length == 0
                        && m.XRefScanForMethod("get_Transform", null)
                        && m.XRefScanForMethod(null, "Player")
                        && m.XRefScanForMethod("Vector3_Quaternion", "VRCPlayer")
                        && m.XRefScanForMethod(null, "VRCTrackingManager")
                        && m.XRefScanForMethod(null, "InputStateController"));
                }
                return (AlignTrackingToPlayerDelegate)Delegate.CreateDelegate(typeof(AlignTrackingToPlayerDelegate), PlayerUtils.GetVRCPlayer(), alignTrackingToPlayerMethod);
            }
        }

        private static MethodInfo alignTrackingToPlayerMethod;

        public delegate void AlignTrackingToPlayerDelegate();

        private static ResetLastPositionAction ResetLastPositionAct
        {
            get
            {
                if (ourResetLastPositionAction != null)
                {
                    return ourResetLastPositionAction;
                }
                //XrefScanMethodDb.RegisterType<Transform>();
                MethodInfo method = typeof(InputStateController).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Single((MethodInfo it) =>
                XrefScanner.XrefScan(it).Any((XrefInstance jt) =>
                jt.Type == XrefType.Method
                && jt.TryResolve() != null
                && jt.TryResolve().Name == "get_transform"));

                ourResetLastPositionAction = (ResetLastPositionAction)Delegate.CreateDelegate(typeof(ResetLastPositionAction), method);
                return ourResetLastPositionAction;
            }
        }

        private static ResetLastPositionAction ourResetLastPositionAction;

        private delegate void ResetLastPositionAction(InputStateController @this);

        public static void ResetLastPosition(this InputStateController instance)
        {
            ResetLastPositionAct(instance);
        }

        private static RagDollAction RagDollMethod
        {
            get
            {
                if (ourRagDollAction != null)
                {
                    return ourRagDollAction;
                }
                //XrefScanMethodDb.RegisterType<Transform>();
                MethodInfo method = typeof(RagdollController).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single((MethodInfo it) =>
                XrefScanner.XrefScan(it).Any((XrefInstance jt) =>
                jt.Type == XrefType.Method
                && jt.TryResolve() != null
                && jt.TryResolve().GetParameters().Length == 1
                && jt.TryResolve().GetParameters()[0].ParameterType == typeof(bool)
                && jt.TryResolve().ReflectedType == typeof(IkController)
                ));
                ModConsole.Log($"[Debug] Found RagDoll Method! {method.Name}");
                ourRagDollAction = (RagDollAction)Delegate.CreateDelegate(typeof(RagdollController), method);
                return ourRagDollAction;
            }
        }

        private static RagDollAction ourRagDollAction;

        private delegate void RagDollAction(RagdollController @this);

        public static void RagDoll(this RagdollController instance)
        {
            RagDollMethod(instance);
        }

        private static EndRagDollAction EndRagDollMethod
        {
            get
            {
                if (ourRagDollAction != null)
                {
                    return ourEndRagDollAction;
                }
                MethodInfo method = typeof(RagdollController).GetMethods(BindingFlags.Instance | BindingFlags.Public).Single((MethodInfo it) =>
                XrefScanner.XrefScan(it).Any((XrefInstance jt) =>
                jt.Type == XrefType.Method
                && jt.TryResolve() != null
                && jt.TryResolve().GetParameters().Length == 0
                && jt.TryResolve().ReflectedType == typeof(IkController)
                ));
                ModConsole.Log($"[Debug] Found EndRagDoll Method! {method.Name}");
                ourEndRagDollAction = (EndRagDollAction)Delegate.CreateDelegate(typeof(RagdollController), method);
                return ourEndRagDollAction;
            }
        }

        private static EndRagDollAction ourEndRagDollAction;

        private delegate void EndRagDollAction(RagdollController @this);

        public static void EndRagDoll(this RagdollController instance)
        {
            EndRagDollMethod(instance);
        }
    }
}