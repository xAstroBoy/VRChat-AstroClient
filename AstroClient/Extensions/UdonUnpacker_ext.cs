namespace AstroLibrary.Extensions
{
    using AstroClient;
    using AstroClient.Udon;
    using AstroLibrary.Console;
    using Il2CppSystem;
    using System.Collections.Generic;
    using System.Linq;
    using UnhollowerBaseLib;
    using UnityEngine;

    public static class UdonUnpacker_ext
    {
        public static string Unpack_String(this Il2CppSystem.Object obj)
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

        public static string[] Unpack_Array_String(this Il2CppSystem.Object obj)
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

        public static List<string> Unpack_List_String(this Il2CppSystem.Object obj)
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

        public static bool? Unpack_Boolean(this Il2CppSystem.Object obj)
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

        public static bool[] Unpack_Array_Boolean(this Il2CppSystem.Object obj)
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

        public static List<bool> Unpack_List_Boolean(this Il2CppSystem.Object obj)
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

        public static float? Unpack_Single(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Single)
                {
                    return obj.Unbox<System.Single>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        public static float[] Unpack_Array_Single(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Single_Array)
                {
                    var array = Il2CppArrayBase<System.Single>.WrapNativeGenericArrayPointer(obj.Pointer);
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

        public static List<float> Unpack_List_Single(this Il2CppSystem.Object obj)
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

        public static char? Unpack_Char(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Char)
                {
                    return obj.Unbox<System.Char>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        public static char[] Unpack_Array_Char(this Il2CppSystem.Object obj)
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

        public static List<char> Unpack_List_Char(this Il2CppSystem.Object obj)
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

        public static byte? Unpack_Byte(this Il2CppSystem.Object obj)
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

        public static byte[] Unpack_Array_Byte(this Il2CppSystem.Object obj)
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

        public static List<byte> Unpack_List_Byte(this Il2CppSystem.Object obj)
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

        public static long? Unpack_Int64(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Int64)
                {
                    return obj.Unbox<System.Int64>();
                }
                else
                {
                    ModConsole.DebugWarning($"Incompatible Type Detected!:  {obj.GetIl2CppType().FullName}");
                }
            }
            return null;
        }

        public static long[] Unpack_Array_Int64(this Il2CppSystem.Object obj)
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

        public static List<long> Unpack_List_Int64(this Il2CppSystem.Object obj)
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

        public static uint? Unpack_UInt32(this Il2CppSystem.Object obj)
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

        public static uint[] Unpack_Array_UInt32(this Il2CppSystem.Object obj)
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

        public static List<uint> Unpack_List_UInt32(this Il2CppSystem.Object obj)
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

        public static int? Unpack_Int32(this Il2CppSystem.Object obj)
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

        public static int[] Unpack_Array_Int32(this Il2CppSystem.Object obj)
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

        public static List<int> Unpack_List_Int32(this Il2CppSystem.Object obj)
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

        public static Color? Unpack_Color(this Il2CppSystem.Object obj)
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

        public static Color[] Unpack_Array_Color(this Il2CppSystem.Object obj)
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

        public static List<Color> Unpack_List_Color(this Il2CppSystem.Object obj)
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

        public static Transform Unpack_Transform(this Il2CppSystem.Object obj)
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

        public static Transform[] Unpack_Array_Transform(this Il2CppSystem.Object obj)
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

        public static List<Transform> Unpack_List_Transform(this Il2CppSystem.Object obj)
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

        public static GameObject Unpack_GameObject(this Il2CppSystem.Object obj)
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

        public static VRC.SDKBase.VRCPlayerApi Unpack_VRCPlayerApi(this Il2CppSystem.Object obj)
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

        public static VRC.Udon.UdonBehaviour Unpack_UdonBehaviour(this Il2CppSystem.Object obj)
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

        public static VRC.Udon.UdonBehaviour[] Unpack_Array_UdonBehaviour(this Il2CppSystem.Object obj)
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

        public static List<VRC.Udon.UdonBehaviour> Unpack_List_UdonBehaviour(this Il2CppSystem.Object obj)
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

        public static Material Unpack_Material(this Il2CppSystem.Object obj)
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

        public static Material[] Unpack_Array_Material(this Il2CppSystem.Object obj)
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

        public static List<Material> Unpack_List_Material(this Il2CppSystem.Object obj)
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

        public static Vector3? Unpack_Vector3(this Il2CppSystem.Object obj)
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

        public static Vector3[] Unpack_Array_Vector3(this Il2CppSystem.Object obj)
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

        public static List<Vector3> Unpack_List_Vector3(this Il2CppSystem.Object obj)
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

        public static Quaternion? Unpack_Quaternion(this Il2CppSystem.Object obj)
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

        public static Quaternion[] Unpack_Array_Quaternion(this Il2CppSystem.Object obj)
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

        public static List<Quaternion> Unpack_List_Quaternion(this Il2CppSystem.Object obj)
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

        public static HumanBodyBones? Unpack_HumanBodyBones(this Il2CppSystem.Object obj)
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

        public static HumanBodyBones[] Unpack_Array_HumanBodyBones(this Il2CppSystem.Object obj)
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

        public static List<HumanBodyBones> Unpack_List_HumanBodyBones(this Il2CppSystem.Object obj)
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

        public static VRC.Udon.Common.Interfaces.NetworkEventTarget? Unpack_NetworkEventTarget(this Il2CppSystem.Object obj)
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

        public static VRC.Udon.Common.Interfaces.NetworkEventTarget[] Unpack_Array_NetworkEventTarget(this Il2CppSystem.Object obj)
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

        public static List<VRC.Udon.Common.Interfaces.NetworkEventTarget> Unpack_List_NetworkEventTarget(this Il2CppSystem.Object obj)
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



        public static object Unpack_System_Object(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Object)
                {
                    var result = Serialization.FromIL2CPPToManaged<System.Object>(obj);
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

        public static object[] Unpack_Array_System_Object(this Il2CppSystem.Object obj)
        {
            if (obj != null)
            {
                if (obj.GetIl2CppType().FullName == UdonTypes_String.System_Object_Array)
                {
                    var array = Serialization.FromIL2CPPToManaged<System.Object[]>(obj);
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

        public static List<object> Unpack_List_System_Object(this Il2CppSystem.Object obj)
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

        public static TMPro.TextMeshPro Unpack_TextMeshPro(this Il2CppSystem.Object obj)
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

        public static TMPro.TextMeshPro[] Unpack_Array_TextMeshPro(this Il2CppSystem.Object obj)
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

        public static List<TMPro.TextMeshPro> Unpack_List_TextMeshPro(this Il2CppSystem.Object obj)
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

        public static AudioSource Unpack_AudioSource(this Il2CppSystem.Object obj)
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

        public static AudioSource[] Unpack_Array_AudioSource(this Il2CppSystem.Object obj)
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

        public static List<AudioSource> Unpack_List_AudioSource(this Il2CppSystem.Object obj)
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

        public static UnityEngine.UI.Text Unpack_UnityEngine_UI_Text(this Il2CppSystem.Object obj)
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

        public static UnityEngine.UI.Text[] Unpack_Array_UnityEngine_UI_Text(this Il2CppSystem.Object obj)
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

        public static List<UnityEngine.UI.Text> Unpack_List_UnityEngine_UI_Text(this Il2CppSystem.Object obj)
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

        public static TMPro.TextMeshProUGUI Unpack_TextMeshProUGUI(this Il2CppSystem.Object obj)
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

        public static TMPro.TextMeshProUGUI[] Unpack_Array_TextMeshProUGUI(this Il2CppSystem.Object obj)
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

        public static List<TMPro.TextMeshProUGUI> Unpack_List_TextMeshProUGUI(this Il2CppSystem.Object obj)
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

        public static MeshRenderer Unpack_MeshRenderer(this Il2CppSystem.Object obj)
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

        public static MeshRenderer[] Unpack_Array_MeshRenderer(this Il2CppSystem.Object obj)
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

        public static List<MeshRenderer> Unpack_List_MeshRenderer(this Il2CppSystem.Object obj)
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

        public static GameObject[] Unpack_Array_GameObject(this Il2CppSystem.Object obj)
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

        public static List<GameObject> Unpack_List_GameObject(this Il2CppSystem.Object obj)
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

        public static VRC.SDKBase.VRCPlayerApi[] Unpack_Array_VRCPlayerApi(this Il2CppSystem.Object obj)
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

        public static List<VRC.SDKBase.VRCPlayerApi> Unpack_List_VRCPlayerApi(this Il2CppSystem.Object obj)
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

        public static AudioClip Unpack_AudioClip(this Il2CppSystem.Object obj)
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

        public static AudioClip[] Unpack_Array_AudioClip(this Il2CppSystem.Object obj)
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

        public static List<AudioClip> Unpack_List_AudioClip(this Il2CppSystem.Object obj)
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

        public static ParticleSystem Unpack_ParticleSystem(this Il2CppSystem.Object obj)
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

        public static ParticleSystem[] Unpack_Array_ParticleSystem(this Il2CppSystem.Object obj)
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

        public static List<ParticleSystem> Unpack_List_ParticleSystem(this Il2CppSystem.Object obj)
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
    }
}