namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using UdonEditor;
    using UnhollowerBaseLib;
    using UnityEngine;

    internal static class UdonUnpacker_ext
    {
        internal static string Unpack_String(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_String)
                {
                    var result = Serialization.FromIL2CPPToManaged<string>(obj);
                    if (!string.IsNullOrEmpty(result) && !string.IsNullOrWhiteSpace(result))
                    {
                        return result;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static string[] Unpack_Array_String(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_String_Array)
                {
                    var array = Serialization.FromIL2CPPToManaged<string[]>(obj);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<string> Unpack_List_String(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_String_Array)
                {
                    return obj.Unpack_Array_String()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static bool? Unpack_Boolean(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Boolean)
                {
                    return obj.Unbox<bool>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static bool[] Unpack_Array_Boolean(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Boolean_Array)
                {
                    var array = Il2CppArrayBase<bool>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<bool> Unpack_List_Boolean(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Boolean_Array)
                {
                    return obj.Unpack_Array_Boolean()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static float? Unpack_Single(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Single)
                {
                    return obj.Unbox<float>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static float[] Unpack_Array_Single(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Single_Array)
                {
                    var array = Il2CppArrayBase<float>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<float> Unpack_List_Single(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Single_Array)
                {
                    return obj.Unpack_Array_Single()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static ushort? Unpack_UInt16(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_UInt16)
                {
                    return obj.Unbox<ushort>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static ushort[] Unpack_Array_UInt16(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_UInt16_Array)
                {
                    var array = Il2CppArrayBase<ushort>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<ushort> Unpack_List_UInt16(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_UInt16_Array)
                {
                    return obj.Unpack_Array_UInt16()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static System.TimeSpan? Unpack_TimeSpan(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_TimeSpan)
                {
                    return obj.Unbox<System.TimeSpan>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static System.TimeSpan[] Unpack_Array_TimeSpan(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_TimeSpan_Array)
                {
                    var array = Il2CppArrayBase<System.TimeSpan>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<System.TimeSpan> Unpack_List_TimeSpan(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_TimeSpan_Array)
                {
                    return obj.Unpack_Array_TimeSpan()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static double? Unpack_Double(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Double)
                {
                    return obj.Unbox<double>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static double[] Unpack_Array_Double(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Double_Array)
                {
                    var array = Il2CppArrayBase<double>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<double> Unpack_List_Double(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Double_Array)
                {
                    return obj.Unpack_Array_Double()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }



        internal static char? Unpack_Char(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Char)
                {
                    return obj.Unbox<char>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static char[] Unpack_Array_Char(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Char_Array)
                {
                    var array = Il2CppArrayBase<char>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<char> Unpack_List_Char(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Char_Array)
                {
                    return obj.Unpack_Array_Char()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static byte? Unpack_Byte(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Byte)
                {
                    return obj.Unbox<byte>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static byte[] Unpack_Array_Byte(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Byte_Array)
                {
                    var array = Il2CppArrayBase<byte>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<byte> Unpack_List_Byte(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Byte_Array)
                {
                    return obj.Unpack_Array_Byte()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static long? Unpack_Int64(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Int64)
                {
                    return obj.Unbox<long>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static long[] Unpack_Array_Int64(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Int64_Array)
                {
                    var array = Il2CppArrayBase<long>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<long> Unpack_List_Int64(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Int64_Array)
                {
                    return obj.Unpack_Array_Int64()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static uint? Unpack_UInt32(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Uint32)
                {
                    return obj.Unbox<uint>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static uint[] Unpack_Array_UInt32(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Uint32_Array)
                {
                    var array = Il2CppArrayBase<uint>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<uint> Unpack_List_UInt32(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Uint32_Array)
                {
                    return obj.Unpack_Array_UInt32()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static int? Unpack_Int32(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Int32)
                {
                    return obj.Unbox<int>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static int[] Unpack_Array_Int32(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Int32_Array)
                {
                    var array = Il2CppArrayBase<int>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<int> Unpack_List_Int32(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Int32_Array)
                {
                    return obj.Unpack_Array_Int32()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Color? Unpack_Color(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Color)
                {
                    return obj.Unbox<UnityEngine.Color>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Color[] Unpack_Array_Color(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Color_Array)
                {
                    var array = Il2CppArrayBase<Color>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Color> Unpack_List_Color(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Color_Array)
                {
                    return obj.Unpack_Array_Color()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Transform Unpack_Transform(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Transform)
                {
                    return obj.Cast<UnityEngine.Transform>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Transform[] Unpack_Array_Transform(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Transform_Array)
                {
                    var array = Il2CppArrayBase<Transform>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Transform> Unpack_List_Transform(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Transform_Array)
                {
                    return obj.Unpack_Array_Transform()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static GameObject Unpack_GameObject(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_GameObject)
                {
                    return obj.Cast<GameObject>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDKBase.VRCPlayerApi Unpack_VRCPlayerApi(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDKBase_VRCPlayerApi)
                {
                    return obj.Cast<VRC.SDKBase.VRCPlayerApi>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.Udon.UdonBehaviour Unpack_UdonBehaviour(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_UdonBehaviour)
                {
                    return obj.Cast<VRC.Udon.UdonBehaviour>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.Udon.UdonBehaviour[] Unpack_Array_UdonBehaviour(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_UdonBehaviour_Array)
                {
                    var array = Il2CppArrayBase<VRC.Udon.UdonBehaviour>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.Udon.UdonBehaviour> Unpack_List_UdonBehaviour(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_UdonBehaviour_Array)
                {
                    return obj.Unpack_Array_UdonBehaviour()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Material Unpack_Material(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Material)
                {
                    return obj.Cast<UnityEngine.Material>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Material[] Unpack_Array_Material(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Material_Array)
                {
                    var array = Il2CppArrayBase<Material>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Material> Unpack_List_Material(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Material_Array)
                {
                    return obj.Unpack_Array_Material()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Vector3? Unpack_Vector3(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Vector3)
                {
                    return obj.Unbox<UnityEngine.Vector3>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Vector3[] Unpack_Array_Vector3(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Vector3_Array)
                {
                    var array = Il2CppArrayBase<Vector3>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Vector3> Unpack_List_Vector3(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Vector3_Array)
                {
                    return obj.Unpack_Array_Vector3()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Quaternion? Unpack_Quaternion(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Quaternion)
                {
                    return obj.Unbox<UnityEngine.Quaternion>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Quaternion[] Unpack_Array_Quaternion(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Quaternion_Array)
                {
                    var array = Il2CppArrayBase<Quaternion>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Quaternion> Unpack_List_Quaternion(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Quaternion_Array)
                {
                    return obj.Unpack_Array_Quaternion()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static HumanBodyBones? Unpack_HumanBodyBones(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_HumanBodyBones)
                {
                    return obj.Unbox<UnityEngine.HumanBodyBones>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static HumanBodyBones[] Unpack_Array_HumanBodyBones(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_HumanBodyBones_Array)
                {
                    var array = Il2CppArrayBase<HumanBodyBones>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<HumanBodyBones> Unpack_List_HumanBodyBones(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_HumanBodyBones_Array)
                {
                    return obj.Unpack_Array_HumanBodyBones()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.Udon.Common.Interfaces.NetworkEventTarget? Unpack_NetworkEventTarget(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget)
                {
                    return obj.Unbox<VRC.Udon.Common.Interfaces.NetworkEventTarget>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.Udon.Common.Interfaces.NetworkEventTarget[] Unpack_Array_NetworkEventTarget(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget_Array)
                {
                    var array = Il2CppArrayBase<VRC.Udon.Common.Interfaces.NetworkEventTarget>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.Udon.Common.Interfaces.NetworkEventTarget> Unpack_List_NetworkEventTarget(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget_Array)
                {
                    return obj.Unpack_Array_NetworkEventTarget()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }



        internal static object Unpack_System_Object(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Object)
                {
                    var result = Serialization.FromIL2CPPToManaged<object>(obj);
                    if (result != null)
                    {
                        return result;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static object[] Unpack_Array_System_Object(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Object_Array)
                {
                    var array = Serialization.FromIL2CPPToManaged<object[]>(obj);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<object> Unpack_List_System_Object(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Object_Array)
                {
                    return obj.Unpack_Array_System_Object()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static TMPro.TextMeshPro Unpack_TextMeshPro(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.TMPro_TextMeshPro)
                {
                    return obj.Cast<TMPro.TextMeshPro>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static TMPro.TextMeshPro[] Unpack_Array_TextMeshPro(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.TMPro_TextMeshPro_Array)
                {
                    var array = Il2CppArrayBase<TMPro.TextMeshPro>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<TMPro.TextMeshPro> Unpack_List_TextMeshPro(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.TMPro_TextMeshPro_Array)
                {
                    return obj.Unpack_Array_TextMeshPro()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static AudioSource Unpack_AudioSource(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AudioSource)
                {
                    return obj.Cast<UnityEngine.AudioSource>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static AudioSource[] Unpack_Array_AudioSource(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AudioSource_Array)
                {
                    var array = Il2CppArrayBase<AudioSource>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<AudioSource> Unpack_List_AudioSource(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AudioSource_Array)
                {
                    return obj.Unpack_Array_AudioSource()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Text Unpack_UnityEngine_UI_Text(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Text)
                {
                    return obj.Cast<UnityEngine.UI.Text>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Text[] Unpack_Array_UnityEngine_UI_Text(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Text_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.Text>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.UI.Text> Unpack_List_UnityEngine_UI_Text(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Text_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_Text()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static TMPro.TextMeshProUGUI Unpack_TextMeshProUGUI(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == "TMPro.TextMeshProUGUI")
                {
                    return obj.Cast<TMPro.TextMeshProUGUI>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static TMPro.TextMeshProUGUI[] Unpack_Array_TextMeshProUGUI(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.TMPro_TextMeshProUGUI_Array)
                {
                    var array = Il2CppArrayBase<TMPro.TextMeshProUGUI>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<TMPro.TextMeshProUGUI> Unpack_List_TextMeshProUGUI(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.TMPro_TextMeshProUGUI_Array)
                {
                    return obj.Unpack_Array_TextMeshProUGUI()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static MeshRenderer Unpack_MeshRenderer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_MeshRenderer)
                {
                    return obj.Cast<UnityEngine.MeshRenderer>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static MeshRenderer[] Unpack_Array_MeshRenderer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_MeshRenderer_Array)
                {
                    var array = Il2CppArrayBase<MeshRenderer>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<MeshRenderer> Unpack_List_MeshRenderer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_MeshRenderer_Array)
                {
                    return obj.Unpack_Array_MeshRenderer()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static BoxCollider Unpack_BoxCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_BoxCollider)
                {
                    return obj.Cast<UnityEngine.BoxCollider>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static BoxCollider[] Unpack_Array_BoxCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_BoxCollider_Array)
                {
                    var array = Il2CppArrayBase<BoxCollider>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<BoxCollider> Unpack_List_BoxCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_BoxCollider_Array)
                {
                    return obj.Unpack_Array_BoxCollider()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static Sprite Unpack_Sprite(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Sprite)
                {
                    return obj.Cast<UnityEngine.Sprite>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Sprite[] Unpack_Array_Sprite(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Sprite_Array)
                {
                    var array = Il2CppArrayBase<Sprite>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Sprite> Unpack_List_Sprite(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Sprite_Array)
                {
                    return obj.Unpack_Array_Sprite()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Component Unpack_Component(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Component)
                {
                    return obj.Cast<UnityEngine.Component>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Component[] Unpack_Array_Component(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Component_Array)
                {
                    var array = Il2CppArrayBase<Component>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Component> Unpack_List_Component(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Component_Array)
                {
                    return obj.Unpack_Array_Component()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static Rigidbody Unpack_Rigidbody(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Rigidbody)
                {
                    return obj.Cast<UnityEngine.Rigidbody>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Rigidbody[] Unpack_Array_Rigidbody(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Rigidbody_Array)
                {
                    var array = Il2CppArrayBase<Rigidbody>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Rigidbody> Unpack_List_Rigidbody(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Rigidbody_Array)
                {
                    return obj.Unpack_Array_Rigidbody()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static CapsuleCollider Unpack_CapsuleCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_CapsuleCollider)
                {
                    return obj.Cast<UnityEngine.CapsuleCollider>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static CapsuleCollider[] Unpack_Array_CapsuleCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_CapsuleCollider_Array)
                {
                    var array = Il2CppArrayBase<CapsuleCollider>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<CapsuleCollider> Unpack_List_CapsuleCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_CapsuleCollider_Array)
                {
                    return obj.Unpack_Array_CapsuleCollider()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static SphereCollider Unpack_SphereCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_SphereCollider)
                {
                    return obj.Cast<UnityEngine.SphereCollider>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static SphereCollider[] Unpack_Array_SphereCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_SphereCollider_Array)
                {
                    var array = Il2CppArrayBase<SphereCollider>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<SphereCollider> Unpack_List_SphereCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_SphereCollider_Array)
                {
                    return obj.Unpack_Array_SphereCollider()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static MeshCollider Unpack_MeshCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_MeshCollider)
                {
                    return obj.Cast<UnityEngine.MeshCollider>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Collider Unpack_Collider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Collider)
                {
                    return obj.Cast<UnityEngine.Collider>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static Collider[] Unpack_Array_Collider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Collider_Array)
                {
                    var array = Il2CppArrayBase<Collider>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Collider> Unpack_List_Collider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Collider_Array)
                {
                    return obj.Unpack_Array_Collider()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static MeshCollider[] Unpack_Array_MeshCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_MeshCollider_Array)
                {
                    var array = Il2CppArrayBase<MeshCollider>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<MeshCollider> Unpack_List_MeshCollider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_MeshCollider_Array)
                {
                    return obj.Unpack_Array_MeshCollider()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Texture Unpack_Texture(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Texture)
                {
                    return obj.Cast<UnityEngine.Texture>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Texture[] Unpack_Array_Texture(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Texture_Array)
                {
                    var array = Il2CppArrayBase<Texture>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Texture> Unpack_List_Texture(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Texture_Array)
                {
                    return obj.Unpack_Array_Texture()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static ReflectionProbe Unpack_ReflectionProbe(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_ReflectionProbe)
                {
                    return obj.Cast<UnityEngine.ReflectionProbe>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static ReflectionProbe[] Unpack_Array_ReflectionProbe(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_ReflectionProbe_Array)
                {
                    var array = Il2CppArrayBase<ReflectionProbe>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<ReflectionProbe> Unpack_List_ReflectionProbe(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_ReflectionProbe_Array)
                {
                    return obj.Unpack_Array_ReflectionProbe()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static RenderTexture Unpack_RenderTexture(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RenderTexture)
                {
                    return obj.Cast<UnityEngine.RenderTexture>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static RenderTexture[] Unpack_Array_RenderTexture(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RenderTexture_Array)
                {
                    var array = Il2CppArrayBase<RenderTexture>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<RenderTexture> Unpack_List_RenderTexture(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RenderTexture_Array)
                {
                    return obj.Unpack_Array_RenderTexture()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }



        internal static TextAsset Unpack_TextAsset(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_TextAsset)
                {
                    return obj.Cast<UnityEngine.TextAsset>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static TextAsset[] Unpack_Array_TextAsset(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_TextAsset_Array)
                {
                    var array = Il2CppArrayBase<TextAsset>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<TextAsset> Unpack_List_TextAsset(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_TextAsset_Array)
                {
                    return obj.Unpack_Array_TextAsset()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }



        internal static Mesh Unpack_Mesh(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Mesh)
                {
                    return obj.Cast<UnityEngine.Mesh>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Mesh[] Unpack_Array_Mesh(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Mesh_Array)
                {
                    var array = Il2CppArrayBase<Mesh>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Mesh> Unpack_List_Mesh(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Mesh_Array)
                {
                    return obj.Unpack_Array_Mesh()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static Animator Unpack_Animator(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Animator)
                {
                    return obj.Cast<UnityEngine.Animator>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Animator[] Unpack_Array_Animator(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Animator_Array)
                {
                    var array = Il2CppArrayBase<Animator>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Animator> Unpack_List_Animator(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Animator_Array)
                {
                    return obj.Unpack_Array_Animator()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static LineRenderer Unpack_LineRenderer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_LineRenderer)
                {
                    return obj.Cast<UnityEngine.LineRenderer>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static LineRenderer[] Unpack_Array_LineRenderer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_LineRenderer_Array)
                {
                    var array = Il2CppArrayBase<LineRenderer>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<LineRenderer> Unpack_List_LineRenderer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_LineRenderer_Array)
                {
                    return obj.Unpack_Array_LineRenderer()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static KeyCode? Unpack_KeyCode(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_KeyCode)
                {
                    return obj.Unbox<UnityEngine.KeyCode>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static KeyCode[] Unpack_Array_KeyCode(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_KeyCode_Array)
                {
                    var array = Il2CppArrayBase<KeyCode>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<KeyCode> Unpack_List_KeyCode(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_KeyCode_Array)
                {
                    return obj.Unpack_Array_KeyCode()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Texture2D Unpack_Texture2D(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Texture2D)
                {
                    return obj.Cast<UnityEngine.Texture2D>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Texture2D[] Unpack_Array_Texture2D(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Texture2D_Array)
                {
                    var array = Il2CppArrayBase<Texture2D>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Texture2D> Unpack_List_Texture2D(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Texture2D_Array)
                {
                    return obj.Unpack_Array_Texture2D()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Rect? Unpack_Rect(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Rect)
                {
                    return obj.Unbox<UnityEngine.Rect>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Rect[] Unpack_Array_Rect(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Rect_Array)
                {
                    var array = Il2CppArrayBase<Rect>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Rect> Unpack_List_Rect(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Rect_Array)
                {
                    return obj.Unpack_Array_Rect()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static Camera Unpack_Camera(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Camera)
                {
                    return obj.Cast<UnityEngine.Camera>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static Camera[] Unpack_Array_Camera(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Camera_Array)
                {
                    var array = Il2CppArrayBase<Camera>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Camera> Unpack_List_Camera(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Camera_Array)
                {
                    return obj.Unpack_Array_Camera()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static RectTransform Unpack_RectTransform(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RectTransform)
                {
                    return obj.Cast<UnityEngine.RectTransform>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static RectTransform[] Unpack_Array_RectTransform(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RectTransform_Array)
                {
                    var array = Il2CppArrayBase<RectTransform>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<RectTransform> Unpack_List_RectTransform(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RectTransform_Array)
                {
                    return obj.Unpack_Array_RectTransform()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static RaycastHit? Unpack_RaycastHit(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RaycastHit)
                {
                    return obj.Unbox<UnityEngine.RaycastHit>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static RaycastHit[] Unpack_Array_RaycastHit(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RaycastHit_Array)
                {
                    var array = Il2CppArrayBase<RaycastHit>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<RaycastHit> Unpack_List_RaycastHit(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_RaycastHit_Array)
                {
                    return obj.Unpack_Array_RaycastHit()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static LayerMask? Unpack_LayerMask(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_LayerMask)
                {
                    return obj.Unbox<UnityEngine.LayerMask>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static LayerMask[] Unpack_Array_LayerMask(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_LayerMask_Array)
                {
                    var array = Il2CppArrayBase<LayerMask>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<LayerMask> Unpack_List_LayerMask(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_LayerMask_Array)
                {
                    return obj.Unpack_Array_LayerMask()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static Bounds? Unpack_Bounds(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Bounds)
                {
                    return obj.Unbox<UnityEngine.Bounds>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }



        internal static Bounds[] Unpack_Array_Bounds(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Bounds_Array)
                {
                    var array = Il2CppArrayBase<Bounds>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<Bounds> Unpack_List_Bounds(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_Bounds_Array)
                {
                    return obj.Unpack_Array_Bounds()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static GameObject[] Unpack_Array_GameObject(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_GameObject_Array)
                {
                    var array = Il2CppArrayBase<GameObject>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<GameObject> Unpack_List_GameObject(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_GameObject_Array)
                {
                    return obj.Unpack_Array_GameObject()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDKBase.VRCPlayerApi[] Unpack_Array_VRCPlayerApi(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDKBase_VRCPlayerApi_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDKBase.VRCPlayerApi>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDKBase.VRCPlayerApi> Unpack_List_VRCPlayerApi(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDKBase_VRCPlayerApi_Array)
                {
                    return obj.Unpack_Array_VRCPlayerApi()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static AudioClip Unpack_AudioClip(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AudioClip)
                {
                    return obj.Cast<UnityEngine.AudioClip>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static AudioClip[] Unpack_Array_AudioClip(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AudioClip_Array)
                {
                    var array = Il2CppArrayBase<AudioClip>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<AudioClip> Unpack_List_AudioClip(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AudioClip_Array)
                {
                    return obj.Unpack_Array_AudioClip()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static ParticleSystem Unpack_ParticleSystem(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_ParticleSystem)
                {
                    return obj.Cast<UnityEngine.ParticleSystem>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static ParticleSystem[] Unpack_Array_ParticleSystem(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_ParticleSystem_Array)
                {
                    var array = Il2CppArrayBase<ParticleSystem>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<ParticleSystem> Unpack_List_ParticleSystem(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_ParticleSystem_Array)
                {
                    return obj.Unpack_Array_ParticleSystem()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static UnityEngine.AI.NavMeshAgent Unpack_UnityEngine_AI_NavMeshAgent(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AI_NavMeshAgent)
                {
                    return obj.Cast<UnityEngine.AI.NavMeshAgent>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.AI.NavMeshAgent[] Unpack_Array_UnityEngine_AI_NavMeshAgent(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AI_NavMeshAgent_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.AI.NavMeshAgent>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.AI.NavMeshAgent> Unpack_List_UnityEngine_AI_NavMeshAgent(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AI_NavMeshAgent_Array)
                {
                    return obj.Unpack_Array_UnityEngine_AI_NavMeshAgent()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static UnityEngine.AI.NavMeshHit? Unpack_UnityEngine_AI_NavMeshHit(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AI_NavMeshHit)
                {
                    return obj.Unbox<UnityEngine.AI.NavMeshHit>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.AI.NavMeshHit[] Unpack_Array_UnityEngine_AI_NavMeshHit(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AI_NavMeshHit_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.AI.NavMeshHit>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.AI.NavMeshHit> Unpack_List_UnityEngine_AI_NavMeshHit(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_AI_NavMeshHit_Array)
                {
                    return obj.Unpack_Array_UnityEngine_AI_NavMeshHit()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static UnityEngine.UI.ScrollRect Unpack_UnityEngine_UI_ScrollRect(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_ScrollRect)
                {
                    return obj.Cast<UnityEngine.UI.ScrollRect>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.ScrollRect[] Unpack_Array_UnityEngine_UI_ScrollRect(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_ScrollRect_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.ScrollRect>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.UI.ScrollRect> Unpack_List_UnityEngine_UI_ScrollRect(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_ScrollRect_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_ScrollRect()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.InputField Unpack_UnityEngine_UI_InputField(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_InputField)
                {
                    return obj.Cast<UnityEngine.UI.InputField>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.InputField[] Unpack_Array_UnityEngine_UI_InputField(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_InputField_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.InputField>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDKBase.VRCUrl Unpack_VRC_SDKBase_VRCUrl(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDKBase_VRCUrl)
                {
                    return obj.Cast<VRC.SDKBase.VRCUrl>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDKBase.VRCUrl[] Unpack_Array_VRC_SDKBase_VRCUrl(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDKBase_VRCUrl_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDKBase.VRCUrl>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDKBase.VRCUrl> Unpack_List_VRC_SDKBase_VRCUrl(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDKBase_VRCUrl_Array)
                {
                    return obj.Unpack_Array_VRC_SDKBase_VRCUrl()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static VRC.SDK3.Video.Components.VRCUnityVideoPlayer Unpack_VRC_SDK3_Video_Components_VRCUnityVideoPlayer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Video_Components_VRCUnityVideoPlayer)
                {
                    return obj.Cast<VRC.SDK3.Video.Components.VRCUnityVideoPlayer>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Video.Components.VRCUnityVideoPlayer[] Unpack_Array_VRC_SDK3_Video_Components_VRCUnityVideoPlayer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Video_Components_VRCUnityVideoPlayer_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDK3.Video.Components.VRCUnityVideoPlayer>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDK3.Video.Components.VRCUnityVideoPlayer> Unpack_List_VRC_SDK3_Video_Components_VRCUnityVideoPlayer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Video_Components_VRCUnityVideoPlayer_Array)
                {
                    return obj.Unpack_Array_VRC_SDK3_Video_Components_VRCUnityVideoPlayer()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer Unpack_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer)
                {
                    return obj.Cast<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[] Unpack_Array_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer> Unpack_List_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_Array)
                {
                    return obj.Unpack_Array_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCUrlInputField Unpack_VRC_SDK3_Components_VRCUrlInputField(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCUrlInputField)
                {
                    return obj.Cast<VRC.SDK3.Components.VRCUrlInputField>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCUrlInputField[] Unpack_Array_VRC_SDK3_Components_VRCUrlInputField(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCUrlInputField_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDK3.Components.VRCUrlInputField>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.VRCUrlInputField> Unpack_List_VRC_SDK3_Components_VRCUrlInputField(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCUrlInputField_Array)
                {
                    return obj.Unpack_Array_VRC_SDK3_Components_VRCUrlInputField()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Components.Video.VideoError? Unpack_VRC_SDK3_Components_Video_VideoError(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_Video_VideoError)
                {
                    return obj.Unbox<VRC.SDK3.Components.Video.VideoError>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }



        internal static VRC.SDK3.Components.Video.VideoError[] Unpack_Array_VRC_SDK3_Components_Video_VideoError(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_Video_VideoError_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDK3.Components.Video.VideoError>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.Video.VideoError> Unpack_List_VRC_SDK3_Components_Video_VideoError(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_Video_VideoError_Array)
                {
                    return obj.Unpack_Array_VRC_SDK3_Components_Video_VideoError()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }



        internal static VRC.Udon.Common.SerializationResult? Unpack_VRC_Udon_Common_SerializationResult(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_Common_SerializationResult)
                {
                    return obj.Unbox<VRC.Udon.Common.SerializationResult>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.Udon.Common.SerializationResult[] Unpack_Array_VRC_Udon_Common_SerializationResult(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_Common_SerializationResult_Array)
                {
                    var array = Il2CppArrayBase<VRC.Udon.Common.SerializationResult>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.Udon.Common.SerializationResult> Unpack_List_VRC_Udon_Common_SerializationResult(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_Udon_Common_SerializationResult_Array)
                {
                    return obj.Unpack_Array_VRC_Udon_Common_SerializationResult()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


        internal static List<UnityEngine.UI.InputField> Unpack_List_UnityEngine_UI_InputField(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_InputField_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_InputField()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static UnityEngine.UI.Slider Unpack_UnityEngine_UI_Slider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Slider)
                {
                    return obj.Cast<UnityEngine.UI.Slider>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Slider[] Unpack_Array_UnityEngine_UI_Slider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Slider_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.Slider>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.UI.Slider> Unpack_List_UnityEngine_UI_Slider(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Slider_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_Slider()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static UnityEngine.UI.Toggle Unpack_UnityEngine_UI_Toggle(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Toggle)
                {
                    return obj.Cast<UnityEngine.UI.Toggle>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Toggle[] Unpack_Array_UnityEngine_UI_Toggle(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Toggle_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.Toggle>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.UI.Toggle> Unpack_List_UnityEngine_UI_Toggle(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Toggle_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_Toggle()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Image Unpack_UnityEngine_UI_Image(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Image)
                {
                    return obj.Cast<UnityEngine.UI.Image>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Image[] Unpack_Array_UnityEngine_UI_Image(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Image_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.Image>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.UI.Image> Unpack_List_UnityEngine_UI_Image(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Image_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_Image()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Button Unpack_UnityEngine_UI_Button(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Button)
                {
                    return obj.Cast<UnityEngine.UI.Button>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.Button[] Unpack_Array_UnityEngine_UI_Button(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Button_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.Button>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.UI.Button> Unpack_List_UnityEngine_UI_Button(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_Button_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_Button()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }
        internal static UnityEngine.UI.RawImage Unpack_UnityEngine_UI_RawImage(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_RawImage)
                {
                    return obj.Cast<UnityEngine.UI.RawImage>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static UnityEngine.UI.RawImage[] Unpack_Array_UnityEngine_UI_RawImage(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_RawImage_Array)
                {
                    var array = Il2CppArrayBase<UnityEngine.UI.RawImage>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<UnityEngine.UI.RawImage> Unpack_List_UnityEngine_UI_RawImage(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.UnityEngine_UI_RawImage_Array)
                {
                    return obj.Unpack_Array_UnityEngine_UI_RawImage()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCAvatarPedestal Unpack_VRC_SDK3_Components_VRCAvatarPedestal(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal)
                {
                    return obj.Cast<VRC.SDK3.Components.VRCAvatarPedestal>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCAvatarPedestal[] Unpack_Array_VRC_SDK3_Components_VRCAvatarPedestal(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDK3.Components.VRCAvatarPedestal>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.VRCAvatarPedestal> Unpack_List_VRC_SDK3_Components_VRCAvatarPedestal(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal_Array)
                {
                    return obj.Unpack_Array_VRC_SDK3_Components_VRCAvatarPedestal()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCPickup Unpack_VRC_SDK3_Components_VRCPickup(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCPickup)
                {
                    return obj.Cast<VRC.SDK3.Components.VRCPickup>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCPickup[] Unpack_Array_VRC_SDK3_Components_VRCPickup(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCPickup_Array)
                {
                    var array = Il2CppArrayBase<VRC.SDK3.Components.VRCPickup>.WrapNativeGenericArrayPointer(obj.Pointer);
                    if (array != null && array.Count() != 0)
                    {
                        return array;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.VRCPickup> Unpack_List_VRC_SDK3_Components_VRCPickup(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.VRC_SDK3_Components_VRCPickup_Array)
                {
                    return obj.Unpack_Array_VRC_SDK3_Components_VRCPickup()?.ToList();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }


    }
}