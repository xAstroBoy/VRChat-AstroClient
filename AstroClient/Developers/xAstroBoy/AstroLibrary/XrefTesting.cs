using VRC.UI.Elements;

namespace AstroClient.xAstroBoy
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Extensions;
    using UnhollowerRuntimeLib.XrefScans;
    using UnityEngine;
    using Utility;

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
                                    if (@object.ToString().Contains("OnPlayerEnteredRoom"))
                                    {
                                        Log.Debug($"[Debug] Found [JOIN] Method! [{it.Name} with {@object.ToString()}]");
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
                                    if (@object.ToString().Contains("OnPlayerLeftRoom"))
                                    {
                                        Log.Debug($"[Debug] Found [Left] Method! [{it.Name} with {@object.ToString()}]");
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
                                Log.Write($"[Debug] Found IsRoomAuthor Method! [{jt.TryResolve().DeclaringType.Name}.{jt.TryResolve().Name}] in [{it.Name}]");
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
                                       Log.Write($"[Debug] Found Destroy Portal Method! [{jt.TryResolve().DeclaringType.Name}.{jt.TryResolve().Name}] in [{it.Name}]");
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
                        Log.Error($"[Debug] Didnt Find Destroy Portal Method!");
                    }
                }
                return _destroyportal;
            }
        }

        private static MethodInfo _destroyportal;

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



    }
}