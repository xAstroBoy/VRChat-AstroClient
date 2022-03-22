﻿namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using VRC.Udon.Common.Interfaces;


    [Obsolete("Switch to UdonVariable System Or enchance RawUdonBehaviour as well to support it!")]

    internal static class UdonHeapParser
    {
        internal static object? Udon_Parse_System_object(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<object> Udon_Parse_System_Object_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static object[] Udon_Parse_System_Object_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static bool? Udon_Parse_Boolean(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<bool> Udon_Parse_Boolean_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static bool[] Udon_Parse_Boolean_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static float? Udon_Parse_single(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<float> Udon_Parse_single_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static float[] Udon_Parse_single_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static string Udon_Parse_string(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<string> Udon_Parse_string_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static string[] Udon_Parse_string_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static uint? Udon_Parse_UInt32(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<uint> Udon_Parse_UInt32_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static uint[] Udon_Parse_UInt32_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static int? Udon_Parse_Int32(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<int> Udon_Parse_Int32_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static int[] Udon_Parse_Int32_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static long? Udon_Parse_Int64(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<long> Udon_Parse_Int64_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static long[] Udon_Parse_Int64_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static char? Udon_Parse_Char(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<char> Udon_Parse_Char_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static char[] Udon_Parse_Char_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static byte? Udon_Parse_Byte(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Byte(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<byte> Udon_Parse_Byte_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Byte_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static byte[] Udon_Parse_Byte_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Byte_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static uint? Udon_Parse_uint(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<uint> Udon_Parse_uint_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static uint[] Udon_Parse_uint_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Color? Udon_Parse_Color(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.Color> Udon_Parse_Color_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Color[] Udon_Parse_Color_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Material Udon_Parse_Material(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.Material> Udon_Parse_Material_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Material[] Udon_Parse_Material_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.MeshRenderer Udon_Parse_MeshRenderer(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.MeshRenderer> Udon_Parse_MeshRenderer_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.MeshRenderer[] Udon_Parse_MeshRenderer_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Component Udon_Parse_Component(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Component(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Component> Udon_Parse_Component_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Component_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Component[] Udon_Parse_Component_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Component_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Sprite Udon_Parse_Sprite(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Sprite(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Sprite> Udon_Parse_Sprite_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Sprite_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Sprite[] Udon_Parse_Sprite_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Sprite_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Rigidbody Udon_Parse_Rigidbody(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Rigidbody(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Rigidbody> Udon_Parse_Rigidbody_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Rigidbody_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Rigidbody[] Udon_Parse_Rigidbody_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Rigidbody_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }



        internal static UnityEngine.ParticleSystem Udon_Parse_ParticleSystem(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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



        internal static List<UnityEngine.ParticleSystem> Udon_Parse_ParticleSystem_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.ParticleSystem[] Udon_Parse_ParticleSystem_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.BoxCollider Udon_Parse_BoxCollider(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_BoxCollider(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.BoxCollider> Udon_Parse_BoxCollider_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_BoxCollider_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.BoxCollider[] Udon_Parse_BoxCollider_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_BoxCollider_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static UnityEngine.Transform Udon_Parse_Transform(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.Transform> Udon_Parse_Transform_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Transform[] Udon_Parse_Transform_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.GameObject Udon_Parse_GameObject(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.GameObject> Udon_Parse_GameObject_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.GameObject[] Udon_Parse_GameObject_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Vector3? Udon_Parse_Vector3(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.Vector3> Udon_Parse_Vector3_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Vector3[] Udon_Parse_Vector3_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Quaternion? Udon_Parse_Quaternion(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.Quaternion> Udon_Parse_Quaternion_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.Quaternion[] Udon_Parse_Quaternion_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.AudioSource Udon_Parse_AudioSource(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.AudioSource> Udon_Parse_AudioSource_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.AudioSource[] Udon_Parse_AudioSource_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.UI.Text Udon_Parse_UnityEngine_UI_Text(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.UI.Text> Udon_Parse_UnityEngine_UI_Text_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.UI.Text[] Udon_Parse_UnityEngine_UI_Text_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.AudioClip Udon_Parse_AudioClip(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<UnityEngine.AudioClip> Udon_Parse_AudioClip_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.AudioClip[] Udon_Parse_AudioClip_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.HumanBodyBones? Udon_Parse_HumanBodyBones(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static VRC.SDKBase.VRCPlayerApi Udon_Parse_VRCPlayerApi(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<VRC.SDKBase.VRCPlayerApi> Udon_Parse_VRCPlayerApi_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static VRC.SDKBase.VRCPlayerApi[] Udon_Parse_VRCPlayerApi_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static VRC.Udon.UdonBehaviour Udon_Parse_UdonBehaviour(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static VRC.Udon.Common.Interfaces.NetworkEventTarget? Udon_Parse_NetworkEventTarget(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static TMPro.TextMeshPro Udon_Parse_TextMeshPro(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static TMPro.TextMeshProUGUI Udon_Parse_TextMeshProUGUI(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static List<TMPro.TextMeshProUGUI> Udon_Parse_TextMeshProUGUI_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static TMPro.TextMeshProUGUI[] Udon_Parse_TextMeshProUGUI_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
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

        internal static UnityEngine.CapsuleCollider Udon_Parse_CapsuleCollider(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_CapsuleCollider(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.CapsuleCollider> Udon_Parse_CapsuleCollider_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_CapsuleCollider_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.CapsuleCollider[] Udon_Parse_CapsuleCollider_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_CapsuleCollider_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }
        internal static UnityEngine.SphereCollider Udon_Parse_SphereCollider(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_SphereCollider(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.SphereCollider> Udon_Parse_SphereCollider_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_SphereCollider_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.SphereCollider[] Udon_Parse_SphereCollider_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_SphereCollider_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static UnityEngine.Collider Udon_Parse_Collider(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Collider(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Collider> Udon_Parse_Collider_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Collider_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Collider[] Udon_Parse_Collider_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Collider_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static UnityEngine.MeshCollider Udon_Parse_MeshCollider(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_MeshCollider(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.MeshCollider> Udon_Parse_MeshCollider_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_MeshCollider_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.MeshCollider[] Udon_Parse_MeshCollider_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_MeshCollider_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Animator Udon_Parse_Animator(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Animator(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Animator> Udon_Parse_Animator_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Animator_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Animator[] Udon_Parse_Animator_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Animator_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }
        internal static UnityEngine.LineRenderer Udon_Parse_LineRenderer(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_LineRenderer(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.LineRenderer> Udon_Parse_LineRenderer_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_LineRenderer_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.LineRenderer[] Udon_Parse_LineRenderer_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_LineRenderer_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static UnityEngine.RaycastHit? Udon_Parse_RaycastHit(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RaycastHit(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.RaycastHit> Udon_Parse_RaycastHit_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RaycastHit_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.RaycastHit[] Udon_Parse_RaycastHit_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RaycastHit_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.RectTransform Udon_Parse_RectTransform(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RectTransform(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.RectTransform> Udon_Parse_RectTransform_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RectTransform_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.RectTransform[] Udon_Parse_RectTransform_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RectTransform_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Camera Udon_Parse_Camera(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Camera(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Camera> Udon_Parse_Camera_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Camera_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Camera[] Udon_Parse_Camera_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Camera_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }
        internal static UnityEngine.KeyCode? Udon_Parse_KeyCode(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_KeyCode(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.KeyCode> Udon_Parse_KeyCode_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_KeyCode_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.KeyCode[] Udon_Parse_KeyCode_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_KeyCode_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Rect? Udon_Parse_Rect(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Rect(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Rect> Udon_Parse_Rect_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Rect_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Rect[] Udon_Parse_Rect_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Rect_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Texture2D Udon_Parse_Texture2D(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Texture2D(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Texture2D> Udon_Parse_Texture2D_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Texture2D_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Texture2D[] Udon_Parse_Texture2D_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Texture2D_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.AI.NavMeshAgent Udon_Parse_UnityEngine_AI_NavMeshAgent(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_AI_NavMeshAgent(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.AI.NavMeshAgent> Udon_Parse_UnityEngine_AI_NavMeshAgent_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_AI_NavMeshAgent_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.AI.NavMeshAgent[] Udon_Parse_UnityEngine_AI_NavMeshAgent_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_AI_NavMeshAgent_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.AI.NavMeshHit? Udon_Parse_UnityEngine_AI_NavMeshHit(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_AI_NavMeshHit(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.AI.NavMeshHit> Udon_Parse_UnityEngine_AI_NavMeshHit_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_AI_NavMeshHit_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.AI.NavMeshHit[] Udon_Parse_UnityEngine_AI_NavMeshHit_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_AI_NavMeshHit_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.Toggle Udon_Parse_UnityEngine_UI_Toggle(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Toggle(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.UI.Toggle> Udon_Parse_UnityEngine_UI_Toggle_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Toggle_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.Toggle[] Udon_Parse_UnityEngine_UI_Toggle_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Toggle_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }
        internal static UnityEngine.UI.Image Udon_Parse_UnityEngine_UI_Image(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Image(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.UI.Image> Udon_Parse_UnityEngine_UI_Image_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Image_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.Image[] Udon_Parse_UnityEngine_UI_Image_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Image_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.Button Udon_Parse_UnityEngine_UI_Button(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Button(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.UI.Button> Udon_Parse_UnityEngine_UI_Button_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Button_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.Button[] Udon_Parse_UnityEngine_UI_Button_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Button_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }
        internal static VRC.SDK3.Components.VRCAvatarPedestal Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.VRCAvatarPedestal> Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCAvatarPedestal[] Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }
        internal static VRC.SDK3.Components.VRCPickup Udon_Parse_VRC_SDK3_Components_VRCPickup(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_VRCPickup(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.VRCPickup> Udon_Parse_VRC_SDK3_Components_VRCPickup_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_VRCPickup_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCPickup[] Udon_Parse_VRC_SDK3_Components_VRCPickup_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_VRCPickup_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static double? Udon_Parse_double(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_double(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<double> Udon_Parse_double_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_double_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static double[] Udon_Parse_double_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_double_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static System.TimeSpan? Udon_Parse_TimeSpan(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TimeSpan(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<System.TimeSpan> Udon_Parse_TimeSpan_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TimeSpan_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static System.TimeSpan[] Udon_Parse_TimeSpan_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TimeSpan_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Mesh Udon_Parse_Mesh(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Mesh(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Mesh> Udon_Parse_Mesh_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Mesh_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Mesh[] Udon_Parse_Mesh_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Mesh_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Texture Udon_Parse_Texture(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Texture(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Texture> Udon_Parse_Texture_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Texture_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Texture[] Udon_Parse_Texture_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Texture_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.ReflectionProbe Udon_Parse_ReflectionProbe(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_ReflectionProbe(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.ReflectionProbe> Udon_Parse_ReflectionProbe_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_ReflectionProbe_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.ReflectionProbe[] Udon_Parse_ReflectionProbe_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_ReflectionProbe_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.TextAsset Udon_Parse_TextAsset(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TextAsset(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.TextAsset> Udon_Parse_TextAsset_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TextAsset_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.TextAsset[] Udon_Parse_TextAsset_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_TextAsset_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }



        internal static UnityEngine.UI.Slider Udon_Parse_UnityEngine_UI_Slider(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Slider(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.UI.Slider> Udon_Parse_UnityEngine_UI_Slider_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Slider_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.Slider[] Udon_Parse_UnityEngine_UI_Slider_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_Slider_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }



        internal static UnityEngine.UI.ScrollRect Udon_Parse_UnityEngine_UI_ScrollRect(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_ScrollRect(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.UI.ScrollRect> Udon_Parse_UnityEngine_UI_ScrollRect_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_ScrollRect_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.ScrollRect[] Udon_Parse_UnityEngine_UI_ScrollRect_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_ScrollRect_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCObjectPool Udon_Parse_VRC3_SDK3_VRCObjectPool(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC3_SDK3_VRCObjectPool(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.InputField Udon_Parse_UnityEngine_UI_InputField(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_InputField(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.UI.InputField> Udon_Parse_UnityEngine_UI_InputField_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_InputField_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.UI.InputField[] Udon_Parse_UnityEngine_UI_InputField_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_UnityEngine_UI_InputField_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static VRC.Udon.Common.SerializationResult? Udon_Parse_VRC_Udon_Common_SerializationResult(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_Udon_Common_SerializationResult(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.Udon.Common.SerializationResult> Udon_Parse_VRC_Udon_Common_SerializationResult_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_Udon_Common_SerializationResult_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.Udon.Common.SerializationResult[] Udon_Parse_VRC_Udon_Common_SerializationResult_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_Udon_Common_SerializationResult_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static VRC.SDKBase.VRCUrl Udon_Parse_VRC_SDKBase_VRCUrl(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDKBase_VRCUrl(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.SDKBase.VRCUrl> Udon_Parse_VRC_SDKBase_VRCUrl_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDKBase_VRCUrl_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDKBase.VRCUrl[] Udon_Parse_VRC_SDKBase_VRCUrl_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDKBase_VRCUrl_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static VRC.SDK3.Components.Video.VideoError? Udon_Parse_VRC_SDK3_Components_Video_VideoError(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_Video_VideoError(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.Video.VideoError> Udon_Parse_VRC_SDK3_Components_Video_VideoError_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_Video_VideoError_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDK3.Components.Video.VideoError[] Udon_Parse_VRC_SDK3_Components_Video_VideoError_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_VRC_SDK3_Components_Video_VideoError_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }



        internal static VRC.SDK3.Components.VRCUrlInputField VRC_SDK3_Components_VRCUrlInputField(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Components_VRCUrlInputField(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.SDK3.Components.VRCUrlInputField> VRC_SDK3_Components_VRCUrlInputField_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Components_VRCUrlInputField_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDK3.Components.VRCUrlInputField[] VRC_SDK3_Components_VRCUrlInputField_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Components_VRCUrlInputField_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }



        internal static VRC.SDK3.Video.Components.VRCUnityVideoPlayer VRC_SDK3_Video_Components_VRCUnityVideoPlayer(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Video_Components_VRCUnityVideoPlayer(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.SDK3.Video.Components.VRCUnityVideoPlayer> VRC_SDK3_Video_Components_VRCUnityVideoPlayer_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Video_Components_VRCUnityVideoPlayer_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDK3.Video.Components.VRCUnityVideoPlayer[] VRC_SDK3_Video_Components_VRCUnityVideoPlayer_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Video_Components_VRCUnityVideoPlayer_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }


        internal static VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer> VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[] VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }



        internal static VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer();
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

        internal static List<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer> VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer();
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

        internal static VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[] VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer();
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

        internal static VRC.SDK3.Video.Components.VRCUnityVideoPlayer VRC_SDK3_Video_Components_VRCUnityVideoPlayer(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_SDK3_Video_Components_VRCUnityVideoPlayer();
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

        internal static List<VRC.SDK3.Video.Components.VRCUnityVideoPlayer> VRC_SDK3_Video_Components_VRCUnityVideoPlayer_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_SDK3_Video_Components_VRCUnityVideoPlayer();
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

        internal static VRC.SDK3.Video.Components.VRCUnityVideoPlayer[] VRC_SDK3_Video_Components_VRCUnityVideoPlayer_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_SDK3_Video_Components_VRCUnityVideoPlayer();
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

        internal static VRC.SDK3.Components.VRCUrlInputField VRC_SDK3_Components_VRCUrlInputField(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_SDK3_Components_VRCUrlInputField();
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

        internal static List<VRC.SDK3.Components.VRCUrlInputField> VRC_SDK3_Components_VRCUrlInputField_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_SDK3_Components_VRCUrlInputField();
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

        internal static VRC.SDK3.Components.VRCUrlInputField[] VRC_SDK3_Components_VRCUrlInputField_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_SDK3_Components_VRCUrlInputField();
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
        internal static VRC.SDK3.Components.Video.VideoError? Udon_Parse_VRC_SDK3_Components_Video_VideoError(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_SDK3_Components_Video_VideoError();
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

        internal static List<VRC.SDK3.Components.Video.VideoError> Udon_Parse_VRC_SDK3_Components_Video_VideoError_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_SDK3_Components_Video_VideoError();
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

        internal static VRC.SDK3.Components.Video.VideoError[] Udon_Parse_VRC_SDK3_Components_Video_VideoError_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_SDK3_Components_Video_VideoError();
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

        internal static VRC.SDKBase.VRCUrl Udon_Parse_VRC_SDKBase_VRCUrl(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_SDKBase_VRCUrl();
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

        internal static List<VRC.SDKBase.VRCUrl> Udon_Parse_VRC_SDKBase_VRCUrl_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_SDKBase_VRCUrl();
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

        internal static VRC.SDKBase.VRCUrl[] Udon_Parse_VRC_SDKBase_VRCUrl_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_SDKBase_VRCUrl();
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

        internal static VRC.Udon.Common.SerializationResult? Udon_Parse_VRC_Udon_Common_SerializationResult(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_Udon_Common_SerializationResult();
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

        internal static List<VRC.Udon.Common.SerializationResult> Udon_Parse_VRC_Udon_Common_SerializationResult_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_Udon_Common_SerializationResult();
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

        internal static VRC.Udon.Common.SerializationResult[] Udon_Parse_VRC_Udon_Common_SerializationResult_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_Udon_Common_SerializationResult();
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

        internal static UnityEngine.UI.InputField Udon_Parse_UnityEngine_UI_InputField(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_UI_InputField();
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

        internal static List<UnityEngine.UI.InputField> Udon_Parse_UnityEngine_UI_InputField_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_UI_InputField();
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

        internal static UnityEngine.UI.InputField[] Udon_Parse_UnityEngine_UI_InputField_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_UI_InputField();
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

        internal static UnityEngine.UI.ScrollRect Udon_Parse_UnityEngine_UI_ScrollRect(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_UI_ScrollRect();
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

        internal static List<UnityEngine.UI.ScrollRect> Udon_Parse_UnityEngine_UI_ScrollRect_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_UI_ScrollRect();
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

        internal static UnityEngine.UI.ScrollRect[] Udon_Parse_UnityEngine_UI_ScrollRect_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_UI_ScrollRect();
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
        internal static UnityEngine.UI.Slider Udon_Parse_UnityEngine_UI_Slider(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_UI_Slider();
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

        internal static List<UnityEngine.UI.Slider> Udon_Parse_UnityEngine_UI_Slider_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_UI_Slider();
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

        internal static UnityEngine.UI.Slider[] Udon_Parse_UnityEngine_UI_Slider_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_UI_Slider();
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
        internal static UnityEngine.TextAsset Udon_Parse_TextAsset(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_TextAsset();
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

        internal static List<UnityEngine.TextAsset> Udon_Parse_TextAsset_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_TextAsset();
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

        internal static UnityEngine.TextAsset[] Udon_Parse_TextAsset_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_TextAsset();
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

        internal static UnityEngine.ReflectionProbe Udon_Parse_ReflectionProbe(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_ReflectionProbe();
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

        internal static List<UnityEngine.ReflectionProbe> Udon_Parse_ReflectionProbe_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_ReflectionProbe();
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

        internal static UnityEngine.ReflectionProbe[] Udon_Parse_ReflectionProbe_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_ReflectionProbe();
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


        internal static UnityEngine.RenderTexture Udon_Parse_RenderTexture(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RenderTexture(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.RenderTexture> Udon_Parse_RenderTexture_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RenderTexture_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.RenderTexture[] Udon_Parse_RenderTexture_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_RenderTexture_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }



        internal static UnityEngine.RenderTexture Udon_Parse_RenderTexture(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_RenderTexture();
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

        internal static List<UnityEngine.RenderTexture> Udon_Parse_RenderTexture_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_RenderTexture();
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

        internal static UnityEngine.RenderTexture[] Udon_Parse_RenderTexture_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_RenderTexture();
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


        internal static UnityEngine.Texture Udon_Parse_Texture(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Texture();
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

        internal static List<UnityEngine.Texture> Udon_Parse_Texture_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Texture();
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

        internal static UnityEngine.Texture[] Udon_Parse_Texture_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Texture();
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

        internal static UnityEngine.Mesh Udon_Parse_Mesh(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Mesh();
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

        internal static List<UnityEngine.Mesh> Udon_Parse_Mesh_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Mesh();
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

        internal static UnityEngine.Mesh[] Udon_Parse_Mesh_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Mesh();
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


        internal static System.TimeSpan? Udon_Parse_TimeSpan(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_TimeSpan();
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

        internal static List<System.TimeSpan> Udon_Parse_TimeSpan_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_TimeSpan();
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

        internal static System.TimeSpan[] Udon_Parse_TimeSpan_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_TimeSpan();
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


        internal static double? Udon_Parse_double(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Double();
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


        internal static List<double> Udon_Parse_double_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Double();
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

        internal static double[] Udon_Parse_double_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Double();
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


        internal static VRC.SDK3.Components.VRCPickup Udon_Parse_VRC_SDK3_Components_VRCPickup(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_SDK3_Components_VRCPickup();
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

        internal static List<VRC.SDK3.Components.VRCPickup> Udon_Parse_VRC_SDK3_Components_VRCPickup_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_SDK3_Components_VRCPickup();
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

        internal static VRC.SDK3.Components.VRCPickup[] Udon_Parse_VRC_SDK3_Components_VRCPickup_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_SDK3_Components_VRCPickup();
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




        internal static VRC.SDK3.Components.VRCAvatarPedestal Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_VRC_SDK3_Components_VRCAvatarPedestal();
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

        internal static List<VRC.SDK3.Components.VRCAvatarPedestal> Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_VRC_SDK3_Components_VRCAvatarPedestal();
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

        internal static VRC.SDK3.Components.VRCAvatarPedestal[] Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_VRC_SDK3_Components_VRCAvatarPedestal();
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


        internal static UnityEngine.UI.Button Udon_Parse_UnityEngine_UI_Button(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_UI_Button();
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

        internal static List<UnityEngine.UI.Button> Udon_Parse_UnityEngine_UI_Button_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_UI_Button();
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

        internal static UnityEngine.UI.Button[] Udon_Parse_UnityEngine_UI_Button_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_UI_Button();
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



        internal static ushort? Udon_Parse_System_UInt16(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_System_UInt16(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<ushort> Udon_Parse_System_UInt16_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_System_UInt16_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static ushort[] Udon_Parse_System_UInt16_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_System_UInt16_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static ushort? Udon_Parse_System_UInt16(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UInt16();
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

        internal static List<ushort> Udon_Parse_System_UInt16_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UInt16();
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

        internal static ushort[] Udon_Parse_System_UInt16_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UInt16();
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




        internal static UnityEngine.UI.Image Udon_Parse_UnityEngine_UI_Image(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_UI_Image();
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

        internal static List<UnityEngine.UI.Image> Udon_Parse_UnityEngine_UI_Image_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_UI_Image();
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

        internal static UnityEngine.UI.Image[] Udon_Parse_UnityEngine_UI_Image_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_UI_Image();
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


        internal static UnityEngine.UI.Toggle Udon_Parse_UnityEngine_UI_Toggle(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_UI_Toggle();
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

        internal static List<UnityEngine.UI.Toggle> Udon_Parse_UnityEngine_UI_Toggle_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_UI_Toggle();
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

        internal static UnityEngine.UI.Toggle[] Udon_Parse_UnityEngine_UI_Toggle_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_UI_Toggle();
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




        internal static UnityEngine.AI.NavMeshHit? Udon_Parse_UnityEngine_AI_NavMeshHit(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_AI_NavMeshHit();
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

        internal static List<UnityEngine.AI.NavMeshHit> Udon_Parse_UnityEngine_AI_NavMeshHit_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_AI_NavMeshHit();
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

        internal static UnityEngine.AI.NavMeshHit[] Udon_Parse_UnityEngine_AI_NavMeshHit_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_AI_NavMeshHit();
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



        internal static UnityEngine.AI.NavMeshAgent Udon_Parse_UnityEngine_AI_NavMeshAgent(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_UnityEngine_AI_NavMeshAgent();
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

        internal static List<UnityEngine.AI.NavMeshAgent> Udon_Parse_UnityEngine_AI_NavMeshAgent_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_UnityEngine_AI_NavMeshAgent();
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

        internal static UnityEngine.AI.NavMeshAgent[] Udon_Parse_UnityEngine_AI_NavMeshAgent_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_UnityEngine_AI_NavMeshAgent();
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



        internal static UnityEngine.Texture2D Udon_Parse_Texture2D(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Texture2D();
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

        internal static List<UnityEngine.Texture2D> Udon_Parse_Texture2D_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Texture2D();
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

        internal static UnityEngine.Texture2D[] Udon_Parse_Texture2D_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Texture2D();
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




        internal static UnityEngine.Rect? Udon_Parse_Rect(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Rect();
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

        internal static List<UnityEngine.Rect> Udon_Parse_Rect_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Rect();
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

        internal static UnityEngine.Rect[] Udon_Parse_Rect_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Rect();
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





        internal static UnityEngine.KeyCode? Udon_Parse_KeyCode(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_KeyCode();
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

        internal static List<UnityEngine.KeyCode> Udon_Parse_KeyCode_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_KeyCode();
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

        internal static UnityEngine.KeyCode[] Udon_Parse_KeyCode_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_KeyCode();
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


        internal static UnityEngine.Camera Udon_Parse_Camera(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Camera();
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

        internal static List<UnityEngine.Camera> Udon_Parse_Camera_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Camera();
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

        internal static UnityEngine.Camera[] Udon_Parse_Camera_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Camera();
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





        internal static UnityEngine.RectTransform Udon_Parse_RectTransform(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_RectTransform();
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

        internal static List<UnityEngine.RectTransform> Udon_Parse_RectTransform_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_RectTransform();
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

        internal static UnityEngine.RectTransform[] Udon_Parse_RectTransform_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_RectTransform();
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




        internal static UnityEngine.RaycastHit? Udon_Parse_RaycastHit(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_RaycastHit();
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

        internal static List<UnityEngine.RaycastHit> Udon_Parse_RaycastHit_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_RaycastHit();
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

        internal static UnityEngine.RaycastHit[] Udon_Parse_RaycastHit_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_RaycastHit();
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


        internal static UnityEngine.LineRenderer Udon_Parse_LineRenderer(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_LineRenderer();
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

        internal static List<UnityEngine.LineRenderer> Udon_Parse_LineRenderer_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_LineRenderer();
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

        internal static UnityEngine.LineRenderer[] Udon_Parse_LineRenderer_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_LineRenderer();
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





        internal static UnityEngine.LayerMask? Udon_Parse_LayerMask(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_LayerMask(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.LayerMask> Udon_Parse_LayerMask_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_LayerMask_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.LayerMask[] Udon_Parse_LayerMask_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_LayerMask_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.LayerMask? Udon_Parse_LayerMask(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_LayerMask();
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

        internal static List<UnityEngine.LayerMask> Udon_Parse_LayerMask_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_LayerMask();
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

        internal static UnityEngine.LayerMask[] Udon_Parse_LayerMask_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_LayerMask();
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





        internal static UnityEngine.Animator Udon_Parse_Animator(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Animator();
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

        internal static List<UnityEngine.Animator> Udon_Parse_Animator_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Animator();
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

        internal static UnityEngine.Animator[] Udon_Parse_Animator_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Animator();
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





        internal static UnityEngine.MeshCollider Udon_Parse_MeshCollider(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_MeshCollider();
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


        internal static UnityEngine.Collider Udon_Parse_Collider(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Collider();
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



        internal static UnityEngine.Bounds? Udon_Parse_Bounds(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Bounds(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static List<UnityEngine.Bounds> Udon_Parse_Bounds_List(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Bounds_List(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Bounds[] Udon_Parse_Bounds_Array(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse_Bounds_Array(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return null;
        }

        internal static UnityEngine.Bounds? Udon_Parse_Bounds(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Bounds();
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

        internal static List<UnityEngine.Bounds> Udon_Parse_Bounds_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Bounds();
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

        internal static UnityEngine.Bounds[] Udon_Parse_Bounds_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Bounds();
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


        internal static List<UnityEngine.MeshCollider> Udon_Parse_MeshCollider_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_MeshCollider();
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

        internal static UnityEngine.MeshCollider[] Udon_Parse_MeshCollider_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_MeshCollider();
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

        internal static List<UnityEngine.Collider> Udon_Parse_Collider_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Collider();
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

        internal static UnityEngine.Collider[] Udon_Parse_Collider_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Collider();
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


        internal static UnityEngine.SphereCollider Udon_Parse_SphereCollider(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_SphereCollider();
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

        internal static List<UnityEngine.SphereCollider> Udon_Parse_SphereCollider_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_SphereCollider();
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

        internal static UnityEngine.SphereCollider[] Udon_Parse_SphereCollider_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_SphereCollider();
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


        internal static UnityEngine.CapsuleCollider Udon_Parse_CapsuleCollider(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_CapsuleCollider();
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

        internal static List<UnityEngine.CapsuleCollider> Udon_Parse_CapsuleCollider_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_CapsuleCollider();
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

        internal static UnityEngine.CapsuleCollider[] Udon_Parse_CapsuleCollider_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_CapsuleCollider();
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




        internal static bool? Udon_Parse_Boolean(IUdonHeap heap, uint address)
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

        internal static List<bool> Udon_Parse_Boolean_List(IUdonHeap heap, uint address)
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

        internal static bool[] Udon_Parse_Boolean_Array(IUdonHeap heap, uint address)
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

        internal static float? Udon_Parse_single(IUdonHeap heap, uint address)
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

        internal static List<float> Udon_Parse_single_List(IUdonHeap heap, uint address)
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

        internal static float[] Udon_Parse_single_Array(IUdonHeap heap, uint address)
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

        internal static string Udon_Parse_string(IUdonHeap heap, uint address)
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

        internal static List<string> Udon_Parse_string_List(IUdonHeap heap, uint address)
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

        internal static string[] Udon_Parse_string_Array(IUdonHeap heap, uint address)
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

        internal static uint? Udon_Parse_UInt32(IUdonHeap heap, uint address)
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

        internal static List<uint> Udon_Parse_UInt32_List(IUdonHeap heap, uint address)
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

        internal static uint[] Udon_Parse_UInt32_Array(IUdonHeap heap, uint address)
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

        internal static object Udon_Parse_System_object(IUdonHeap heap, uint address)
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

        internal static List<object> Udon_Parse_System_Object_List(IUdonHeap heap, uint address)
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

        internal static object[] Udon_Parse_System_Object_Array(IUdonHeap heap, uint address)
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

        internal static int? Udon_Parse_Int32(IUdonHeap heap, uint address)
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

        internal static List<int> Udon_Parse_Int32_List(IUdonHeap heap, uint address)
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

        internal static int[] Udon_Parse_Int32_Array(IUdonHeap heap, uint address)
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

        internal static long? Udon_Parse_Int64(IUdonHeap heap, uint address)
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

        internal static List<long> Udon_Parse_Int64_List(IUdonHeap heap, uint address)
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

        internal static long[] Udon_Parse_Int64_Array(IUdonHeap heap, uint address)
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

        internal static char? Udon_Parse_Char(IUdonHeap heap, uint address)
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

        internal static List<char> Udon_Parse_Char_List(IUdonHeap heap, uint address)
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

        internal static char[] Udon_Parse_Char_Array(IUdonHeap heap, uint address)
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

        internal static byte? Udon_Parse_Byte(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Byte();
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

        internal static List<byte> Udon_Parse_Byte_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Byte();
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

        internal static byte[] Udon_Parse_Byte_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Byte();
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

        internal static uint? Udon_Parse_uint(IUdonHeap heap, uint address)
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

        internal static List<uint> Udon_Parse_uint_List(IUdonHeap heap, uint address)
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

        internal static uint[] Udon_Parse_uint_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Color? Udon_Parse_Color(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.Color> Udon_Parse_Color_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Color[] Udon_Parse_Color_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Material Udon_Parse_Material(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.Material> Udon_Parse_Material_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Material[] Udon_Parse_Material_Array(IUdonHeap heap, uint address)
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


        internal static UnityEngine.Component Udon_Parse_Component(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Component();
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

        internal static List<UnityEngine.Component> Udon_Parse_Component_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Component();
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

        internal static UnityEngine.Component[] Udon_Parse_Component_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Component();
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


        internal static UnityEngine.BoxCollider Udon_Parse_BoxCollider(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_BoxCollider();
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

        internal static List<UnityEngine.BoxCollider> Udon_Parse_BoxCollider_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_BoxCollider();
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

        internal static UnityEngine.BoxCollider[] Udon_Parse_BoxCollider_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_BoxCollider();
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


        internal static UnityEngine.Sprite Udon_Parse_Sprite(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Sprite();
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

        internal static List<UnityEngine.Sprite> Udon_Parse_Sprite_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Sprite();
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

        internal static UnityEngine.Sprite[] Udon_Parse_Sprite_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Sprite();
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


        internal static UnityEngine.MeshRenderer Udon_Parse_MeshRenderer(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.MeshRenderer> Udon_Parse_MeshRenderer_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.MeshRenderer[] Udon_Parse_MeshRenderer_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.ParticleSystem Udon_Parse_ParticleSystem(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.ParticleSystem> Udon_Parse_ParticleSystem_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.ParticleSystem[] Udon_Parse_ParticleSystem_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Transform Udon_Parse_Transform(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.Transform> Udon_Parse_Transform_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Transform[] Udon_Parse_Transform_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.GameObject Udon_Parse_GameObject(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.GameObject> Udon_Parse_GameObject_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.GameObject[] Udon_Parse_GameObject_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Vector3? Udon_Parse_Vector3(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.Vector3> Udon_Parse_Vector3_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Vector3[] Udon_Parse_Vector3_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Quaternion? Udon_Parse_Quaternion(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.Quaternion> Udon_Parse_Quaternion_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.Quaternion[] Udon_Parse_Quaternion_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.AudioSource Udon_Parse_AudioSource(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.AudioSource> Udon_Parse_AudioSource_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.AudioSource[] Udon_Parse_AudioSource_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.UI.Text Udon_Parse_UnityEngine_UI_Text(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.UI.Text> Udon_Parse_UnityEngine_UI_Text_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.UI.Text[] Udon_Parse_UnityEngine_UI_Text_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.AudioClip Udon_Parse_AudioClip(IUdonHeap heap, uint address)
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

        internal static List<UnityEngine.AudioClip> Udon_Parse_AudioClip_List(IUdonHeap heap, uint address)
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

        internal static UnityEngine.AudioClip[] Udon_Parse_AudioClip_Array(IUdonHeap heap, uint address)
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

        internal static UnityEngine.HumanBodyBones? Udon_Parse_HumanBodyBones(IUdonHeap heap, uint address)
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

        internal static VRC.SDKBase.VRCPlayerApi Udon_Parse_VRCPlayerApi(IUdonHeap heap, uint address)
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

        internal static List<VRC.SDKBase.VRCPlayerApi> Udon_Parse_VRCPlayerApi_List(IUdonHeap heap, uint address)
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

        internal static VRC.SDKBase.VRCPlayerApi[] Udon_Parse_VRCPlayerApi_Array(IUdonHeap heap, uint address)
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

        internal static VRC.Udon.UdonBehaviour Udon_Parse_UdonBehaviour(IUdonHeap heap, uint address)
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

        internal static VRC.Udon.Common.Interfaces.NetworkEventTarget? Udon_Parse_NetworkEventTarget(IUdonHeap heap, uint address)
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

        internal static TMPro.TextMeshPro Udon_Parse_TextMeshPro(IUdonHeap heap, uint address)
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

        internal static TMPro.TextMeshProUGUI Udon_Parse_TextMeshProUGUI(IUdonHeap heap, uint address)
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

        internal static List<TMPro.TextMeshProUGUI> Udon_Parse_TextMeshProUGUI_List(IUdonHeap heap, uint address)
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

        internal static TMPro.TextMeshProUGUI[] Udon_Parse_TextMeshProUGUI_Array(IUdonHeap heap, uint address)
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
        internal static VRC.SDK3.Components.VRCObjectPool Udon_Parse_VRC3_SDK3_VRCObjectPool(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_SDK3_VRCObjectPool();
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

        internal static UnityEngine.Rigidbody Udon_Parse_Rigidbody(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Rigidbody();
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

        internal static List<UnityEngine.Rigidbody> Udon_Parse_Rigidbody_List(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_List_Rigidbody();
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

        internal static UnityEngine.Rigidbody[] Udon_Parse_Rigidbody_Array(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable(address);
                if (value != null)
                {
                    var result = value.Unpack_Array_Rigidbody();
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