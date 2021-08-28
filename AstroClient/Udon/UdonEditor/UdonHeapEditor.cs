namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using VRC.Udon.Common.Interfaces;

    public static class UdonHeapEditor
    {
        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, bool value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, Single value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, string value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, string[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UInt32 value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, Int32 value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, Int64 value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, char value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, char[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Color value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Material value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.MeshRenderer value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.ParticleSystem value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Transform value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.GameObject value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.GameObject[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Vector3 value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.Quaternion value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AudioSource value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.AudioClip[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.UI.Text value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, UnityEngine.HumanBodyBones value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDKBase.VRCPlayerApi value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.SDKBase.VRCPlayerApi[] value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.Udon.UdonBehaviour value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, VRC.Udon.Common.Interfaces.NetworkEventTarget value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, TMPro.TextMeshPro value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(DisassembledUdonBehaviour UnpackedUdonBehaviour, string symbol, TMPro.TextMeshProUGUI value, bool verify = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, verify);
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, TMPro.TextMeshProUGUI value, bool verify = false)
        {
            if (heap != null && address != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_TextMeshProUGUI();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, bool value, bool verify = false)
        {
            if (heap != null && address != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Boolean();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, Single value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Single();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, string value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_String();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, string[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_String();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UInt32 value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UInt32();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, Int32 value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Int32();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, Int64 value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Int64();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, char value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Char();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, char[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_Char();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Color value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Color();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Material value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Material();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.MeshRenderer value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_MeshRenderer();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.ParticleSystem value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_ParticleSystem();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Transform value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Transform();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.GameObject value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_GameObject();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.GameObject[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_GameObject();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Vector3 value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Vector3();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Quaternion value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Quaternion();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AudioSource value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_AudioSource();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AudioClip[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_AudioClip();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Text value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Text();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.HumanBodyBones value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_HumanBodyBones();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCPlayerApi value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_VRCPlayerApi();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCPlayerApi[] value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_Array_VRCPlayerApi();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.UdonBehaviour value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_UdonBehaviour();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.Common.Interfaces.NetworkEventTarget value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CppObject_Unmanaged(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_NetworkEventTarget();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }

        public static void PatchHeap(IUdonHeap heap, uint address, TMPro.TextMeshPro value, bool verify = false)
        {
            if (heap != null)
            {
                var converted = UdonConverter.Generate_Il2CPPObject_Il2cppObjectBase(value);
                heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
                if (verify)
                {
                    var result = heap.GetHeapVariable(address).Unpack_TextMeshPro();
                    if (result == value)
                    {
                        ModConsole.DebugLog($"Heap Patch Applied.");
                    }
                    else
                    {
                        ModConsole.DebugLog($"Heap Patch Failed.");
                    }
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
            }
        }
    }
}