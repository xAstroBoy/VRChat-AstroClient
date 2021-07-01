using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib.XrefScans;

namespace Blaze.Utils
{
    //[Obfuscation(Exclude = true, ApplyToMembers = true, StripAfterObfuscation = true)]
    internal static class BlazesXRefs
    {
        private static MethodInfo _OpenedQMMethod;
        private static MethodInfo _ClosedQMMethod;
        private static MethodInfo _OnPhotonPlayerJoinMethod;
        private static MethodInfo _OnPhotonPlayerLeftMethod;
        private static MethodInfo _TrustRankMethod;
        private static List<MethodInfo> _TrustRankColorMethods;

        internal static MethodInfo OpenedQMMethod
        {
            get
            {
                if (_OpenedQMMethod != null) return _OpenedQMMethod;
                return _OpenedQMMethod = typeof(QuickMenu)
                    .GetMethods()
                    .Where(m => m.Name.StartsWith("Method_Private_Void_"))
                    .Where(m => m.Name.Length <= 22)
                    .Where(m => XrefScanner.XrefScan(m)
                        .Where(x => x.Type == XrefType.Global)
                        .Select(x => x.ReadAsObject()?.ToString())
                        .Where(s => s.StartsWith("Mic"))
                        .Count() == 3)
                    .FirstOrDefault();
            }
        }

        internal static MethodInfo ClosedQMMethod
        {
            get
            {
                if (_ClosedQMMethod != null) return _ClosedQMMethod;
                return _ClosedQMMethod = typeof(QuickMenu)
                    .GetMethods()
                    .Where(m => m.Name.StartsWith("Method_Public_Void_Boolean_"))
                    .Where(m => m.Name.Length <= 29)
                    .OrderBy(m => XrefScanner.XrefScan(m).Count(x => x.Type == XrefType.Method))
                    .ElementAt(2); // you will have to change this index every time it breaks. 0, 1, or 2
            }
        }

        internal static MethodInfo TrustRankMethod
        {
            get
            {
                if (_TrustRankMethod != null) return _TrustRankMethod;
                return _TrustRankMethod = typeof(VRCPlayer).GetMethods().FirstOrDefault(it => !it.Name.Contains("PDM") 
                && it.ReturnType.ToString().Equals("System.String") 
                && it.GetParameters().Length == 1 
                && it.GetParameters()[0].ParameterType.ToString().Equals("VRC.Core.APIUser"));
            }
        }

        internal static List<MethodInfo> TrustRankColorMethods
        {
            get
            {
                if (_TrustRankColorMethods != null) return _TrustRankColorMethods;
                return _TrustRankColorMethods = typeof(VRCPlayer).GetMethods().Where(it => it.ReturnType.ToString().Equals("UnityEngine.Color")
                && it.GetParameters().Length == 1 
                && it.GetParameters()[0].ParameterType.ToString().Equals("VRC.Core.APIUser")).ToList();
            }
        }

        internal static MethodInfo OnPhotonPlayerJoinMethod
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
        internal static MethodInfo OnPhotonPlayerLeftMethod
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
    }
}
