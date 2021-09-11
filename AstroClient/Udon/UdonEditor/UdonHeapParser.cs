﻿namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System.Collections.Generic;
    using VRC.Udon.Common.Interfaces;

    public static class UdonHeapParser
    {
        public static object? Udon_Parse_System_object(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_System_object(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<object> Udon_Parse_System_Object_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_System_Object_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static object[] Udon_Parse_System_Object_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_System_Object_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static bool? Udon_Parse_Boolean(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Boolean(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<bool> Udon_Parse_Boolean_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Boolean_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static bool[] Udon_Parse_Boolean_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Boolean_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static float? Udon_Parse_single(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_single(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<float> Udon_Parse_single_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_single_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static float[] Udon_Parse_single_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_single_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static string Udon_Parse_string(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_string(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<string> Udon_Parse_string_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_string_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static string[] Udon_Parse_string_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_string_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint? Udon_Parse_UInt32(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UInt32(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<uint> Udon_Parse_UInt32_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UInt32_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint[] Udon_Parse_UInt32_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UInt32_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static int? Udon_Parse_Int32(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Int32(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<int> Udon_Parse_Int32_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Int32_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static int[] Udon_Parse_Int32_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Int32_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static long? Udon_Parse_Int64(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Int64(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<long> Udon_Parse_Int64_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Int64_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static long[] Udon_Parse_Int64_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Int64_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static char? Udon_Parse_Char(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Char(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<char> Udon_Parse_Char_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Char_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static char[] Udon_Parse_Char_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Char_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint? Udon_Parse_uint(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_uint(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<uint> Udon_Parse_uint_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_uint_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint[] Udon_Parse_uint_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_uint_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Color? Udon_Parse_Color(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Color(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Color> Udon_Parse_Color_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Color_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Color[] Udon_Parse_Color_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Color_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Material Udon_Parse_Material(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Material(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Material> Udon_Parse_Material_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Material_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Material[] Udon_Parse_Material_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Material_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.MeshRenderer Udon_Parse_MeshRenderer(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_MeshRenderer(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.MeshRenderer> Udon_Parse_MeshRenderer_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_MeshRenderer_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.MeshRenderer[] Udon_Parse_MeshRenderer_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_MeshRenderer_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.ParticleSystem Udon_Parse_ParticleSystem(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_ParticleSystem(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.ParticleSystem> Udon_Parse_ParticleSystem_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_ParticleSystem_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.ParticleSystem[] Udon_Parse_ParticleSystem_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_ParticleSystem_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Transform Udon_Parse_Transform(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Transform(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Transform> Udon_Parse_Transform_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Transform_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Transform[] Udon_Parse_Transform_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Transform_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.GameObject Udon_Parse_GameObject(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_GameObject(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.GameObject> Udon_Parse_GameObject_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_GameObject_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.GameObject[] Udon_Parse_GameObject_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_GameObject_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Vector3? Udon_Parse_Vector3(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Vector3(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Vector3> Udon_Parse_Vector3_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Vector3_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Vector3[] Udon_Parse_Vector3_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Vector3_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Quaternion? Udon_Parse_Quaternion(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Quaternion(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Quaternion> Udon_Parse_Quaternion_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Quaternion_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Quaternion[] Udon_Parse_Quaternion_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Quaternion_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioSource Udon_Parse_AudioSource(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_AudioSource(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.AudioSource> Udon_Parse_AudioSource_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_AudioSource_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioSource[] Udon_Parse_AudioSource_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_AudioSource_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.UI.Text Udon_Parse_UnityEngine_UI_Text(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Text(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.UI.Text> Udon_Parse_UnityEngine_UI_Text_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Text_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.UI.Text[] Udon_Parse_UnityEngine_UI_Text_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Text_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioClip Udon_Parse_AudioClip(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_AudioClip(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.AudioClip> Udon_Parse_AudioClip_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_AudioClip_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioClip[] Udon_Parse_AudioClip_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_AudioClip_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.HumanBodyBones? Udon_Parse_HumanBodyBones(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_HumanBodyBones(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.SDKBase.VRCPlayerApi Udon_Parse_VRCPlayerApi(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRCPlayerApi(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<VRC.SDKBase.VRCPlayerApi> Udon_Parse_VRCPlayerApi_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRCPlayerApi_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.SDKBase.VRCPlayerApi[] Udon_Parse_VRCPlayerApi_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRCPlayerApi_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.Udon.UdonBehaviour Udon_Parse_UdonBehaviour(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UdonBehaviour(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.Udon.Common.Interfaces.NetworkEventTarget? Udon_Parse_NetworkEventTarget(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_NetworkEventTarget(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static TMPro.TextMeshPro Udon_Parse_TextMeshPro(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TextMeshPro(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static TMPro.TextMeshProUGUI Udon_Parse_TextMeshProUGUI(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TextMeshProUGUI(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<TMPro.TextMeshProUGUI> Udon_Parse_TextMeshProUGUI_List(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TextMeshProUGUI_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static TMPro.TextMeshProUGUI[] Udon_Parse_TextMeshProUGUI_Array(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TextMeshProUGUI_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static bool? Udon_Parse_Boolean(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Boolean();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<bool> Udon_Parse_Boolean_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Boolean();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static bool[] Udon_Parse_Boolean_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Boolean();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static float? Udon_Parse_single(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Single();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<float> Udon_Parse_single_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Single();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static float[] Udon_Parse_single_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Single();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static string Udon_Parse_string(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_String();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<string> Udon_Parse_string_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_String();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static string[] Udon_Parse_string_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_String();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint? Udon_Parse_UInt32(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UInt32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<uint> Udon_Parse_UInt32_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UInt32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint[] Udon_Parse_UInt32_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UInt32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static object Udon_Parse_System_object(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_System_Object();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<object> Udon_Parse_System_Object_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_System_Object();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static object[] Udon_Parse_System_Object_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_System_Object();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static int? Udon_Parse_Int32(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Int32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<int> Udon_Parse_Int32_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Int32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static int[] Udon_Parse_Int32_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Int32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static long? Udon_Parse_Int64(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Int64();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<long> Udon_Parse_Int64_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Int64();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static long[] Udon_Parse_Int64_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Int64();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static char? Udon_Parse_Char(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Char();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<char> Udon_Parse_Char_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Char();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static char[] Udon_Parse_Char_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Char();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint? Udon_Parse_uint(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UInt32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<uint> Udon_Parse_uint_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UInt32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static uint[] Udon_Parse_uint_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UInt32();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Color? Udon_Parse_Color(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Color();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Color> Udon_Parse_Color_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Color();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Color[] Udon_Parse_Color_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Color();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Material Udon_Parse_Material(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Material();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Material> Udon_Parse_Material_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Material();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Material[] Udon_Parse_Material_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Material();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.MeshRenderer Udon_Parse_MeshRenderer(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_MeshRenderer();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.MeshRenderer> Udon_Parse_MeshRenderer_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_MeshRenderer();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.MeshRenderer[] Udon_Parse_MeshRenderer_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_MeshRenderer();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.ParticleSystem Udon_Parse_ParticleSystem(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_ParticleSystem();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.ParticleSystem> Udon_Parse_ParticleSystem_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_ParticleSystem();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.ParticleSystem[] Udon_Parse_ParticleSystem_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_ParticleSystem();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Transform Udon_Parse_Transform(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Transform();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Transform> Udon_Parse_Transform_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Transform();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Transform[] Udon_Parse_Transform_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Transform();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.GameObject Udon_Parse_GameObject(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_GameObject();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.GameObject> Udon_Parse_GameObject_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_GameObject();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.GameObject[] Udon_Parse_GameObject_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_GameObject();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Vector3? Udon_Parse_Vector3(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Vector3();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Vector3> Udon_Parse_Vector3_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Vector3();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Vector3[] Udon_Parse_Vector3_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Vector3();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Quaternion? Udon_Parse_Quaternion(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Quaternion();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.Quaternion> Udon_Parse_Quaternion_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Quaternion();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.Quaternion[] Udon_Parse_Quaternion_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Quaternion();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioSource Udon_Parse_AudioSource(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_AudioSource();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.AudioSource> Udon_Parse_AudioSource_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_AudioSource();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioSource[] Udon_Parse_AudioSource_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_AudioSource();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.UI.Text Udon_Parse_UnityEngine_UI_Text(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_UI_Text();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.UI.Text> Udon_Parse_UnityEngine_UI_Text_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_UI_Text();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.UI.Text[] Udon_Parse_UnityEngine_UI_Text_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_UI_Text();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioClip Udon_Parse_AudioClip(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_AudioClip();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<UnityEngine.AudioClip> Udon_Parse_AudioClip_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_AudioClip();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.AudioClip[] Udon_Parse_AudioClip_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_AudioClip();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static UnityEngine.HumanBodyBones? Udon_Parse_HumanBodyBones(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_HumanBodyBones();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.SDKBase.VRCPlayerApi Udon_Parse_VRCPlayerApi(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRCPlayerApi();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<VRC.SDKBase.VRCPlayerApi> Udon_Parse_VRCPlayerApi_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRCPlayerApi();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.SDKBase.VRCPlayerApi[] Udon_Parse_VRCPlayerApi_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRCPlayerApi();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.Udon.UdonBehaviour Udon_Parse_UdonBehaviour(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UdonBehaviour();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static VRC.Udon.Common.Interfaces.NetworkEventTarget? Udon_Parse_NetworkEventTarget(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_NetworkEventTarget();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static TMPro.TextMeshPro Udon_Parse_TextMeshPro(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_TextMeshPro();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static TMPro.TextMeshProUGUI Udon_Parse_TextMeshProUGUI(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_TextMeshProUGUI();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static List<TMPro.TextMeshProUGUI> Udon_Parse_TextMeshProUGUI_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_TextMeshProUGUI();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        public static TMPro.TextMeshProUGUI[] Udon_Parse_TextMeshProUGUI_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_TextMeshProUGUI();
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }
    }
}