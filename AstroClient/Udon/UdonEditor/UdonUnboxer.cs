namespace AstroClient.Udon
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Text;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;

    public static class UdonUnboxer
    {
        public static void UnboxUdonToConsole(UdonBehaviour udonnode)
        {
            if (udonnode != null)
            {

                var unpackedudon = udonnode.DisassembleUdonBehaviour();
                if (unpackedudon != null)
                {
                    System.Console.Clear();
                    ModConsole.Log($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..", System.Drawing.Color.Orange);
                    foreach (var symbol in unpackedudon.IUdonSymbolTable.GetSymbols())
                    {
                        if (symbol != null)
                        {
                            var address = unpackedudon.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                            var UnboxVariable = unpackedudon.IUdonHeap.GetHeapVariable(address);
                            if (UnboxVariable != null)
                            {
                                var Il2CppType = UnboxVariable.GetIl2CppType();
                                var unpackedsymbol = UnboxUdonHeap(UnboxVariable);
                                ModConsole.Log($"[Udon Unboxer] : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}", System.Drawing.Color.Gold);

                            }
                        }
                    }
                }
            }

        }

        public static string UnboxUdonToString(UdonBehaviour udonnode)
        {
            if (udonnode != null)
            {
                StringBuilder builder = new StringBuilder();
                var unpackedudon = udonnode.DisassembleUdonBehaviour();
                if (unpackedudon != null)
                {
                    builder.AppendLine($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..");
                    foreach (var symbol in unpackedudon.IUdonSymbolTable.GetSymbols())
                    {
                        if (symbol != null)
                        {
                            var address = unpackedudon.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                            var UnboxVariable = unpackedudon.IUdonHeap.GetHeapVariable(address);
                            if (UnboxVariable != null)
                            {
                                var Il2CppType = UnboxVariable.GetIl2CppType();
                                var unpackedsymbol = UnboxUdonHeap(UnboxVariable);
                                builder.AppendLine($"[Udon Unboxer] : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}");

                            }
                        }
                    }
                }
                return builder.ToString();
            }
            return null;
        }

        private static string UnboxUdonHeap(Il2CppSystem.Object obj)
        {
            try
            {
                string FullName = obj.GetIl2CppType().FullName;
                if (obj != null)
                {
                    if (FullName == "System.String")
                    {
                        var result = obj.Unpack_String();
                        if (result != null)
                        {
                            return result;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "System.String[]")
                    {
                        var list = obj.Unpack_List_String();
                        if (list != null && list.Count != 0)
                        {
                            string translated = "";
                            foreach (var item in list)
                            {
                                translated += item + Environment.NewLine;
                            }
                            return translated;
                        }
                        else
                        {
                            return $"empty {FullName}";
                        }
                    }
                    else if (FullName == "System.UInt32")
                    {
                        var result = obj.Unpack_UInt32();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "System.Int32")
                    {
                        var result = obj.Unpack_Int32();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "System.Int64")
                    {
                        var result = obj.Unpack_Int64();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "System.Char")
                    {
                        var result = obj.Unpack_Char();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "System.Char[]")
                    {
                        var list = obj.Unpack_List_Char();
                        if (list != null && list.Count != 0)
                        {
                            string translated = "";
                            foreach (var item in list)
                            {
                                if (item != null)
                                {
                                    translated += item + Environment.NewLine;
                                }
                            }
                            return translated;
                        }
                        else
                        {
                            return $"empty {FullName}";
                        }
                    }
                    else if (FullName == "System.Single")
                    {
                        var result = obj.Unpack_Single();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName} (float)";
                    }
                    else if (FullName == "System.Boolean")
                    {
                        var result = obj.Unpack_Boolean();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "System.Object")
                    {
                        var result = obj.Unpack_System_Object();
                        if (result != null)
                        {
                            return result.GetType().FullName;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.Color")
                    {
                        var result = obj.Unpack_Color();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.Material")
                    {
                        var result = obj.Unpack_Material();
                        if (result != null)
                        {
                            return result.name;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.MeshRenderer")
                    {
                        var result = obj.Unpack_MeshRenderer();
                        if (result != null)
                        {
                            return result.name;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.ParticleSystem")
                    {
                        var result = obj.Unpack_ParticleSystem();
                        if (result != null)
                        {
                            return result.name;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.Transform")
                    {
                        var result = obj.Unpack_Transform();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.GameObject")
                    {
                        var result = obj.Unpack_GameObject();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.GameObject[]")
                    {
                        var list = obj.Unpack_List_GameObject();
                        if (list != null && list.Count != 0)
                        {
                            string translated = "";
                            foreach (var item in list)
                            {
                                if (item != null)
                                {
                                    translated += item.name + Environment.NewLine;
                                }
                            }
                            return translated;
                        }
                        else
                        {
                            return $"empty {FullName}";
                        }
                    }
                    else if (FullName == "UnityEngine.AudioClip[]")
                    {
                        var list = obj.Unpack_List_AudioClip();
                        if (list != null && list.Count != 0)
                        {
                            string translated = "";
                            foreach (var item in list)
                            {
                                if (item != null)
                                {
                                    translated += item.name + Environment.NewLine;
                                }
                            }
                            return translated;
                        }
                        else
                        {
                            return $"empty {FullName}";
                        }
                    }
                    else if (FullName == "UnityEngine.Vector3")
                    {
                        var result = obj.Unpack_Vector3();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.Quaternion")
                    {
                        var result = obj.Unpack_Quaternion();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.AudioSource")
                    {
                        var result = obj.Unpack_AudioSource();
                        if (result != null)
                        {
                            return result.name;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.UI.Text")
                    {
                        var result = obj.Unpack_AudioSource();
                        if (result != null)
                        {
                            return result.name;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "UnityEngine.HumanBodyBones")
                    {
                        var result = obj.Unpack_HumanBodyBones();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "VRC.SDKBase.VRCPlayerApi")
                    {
                        var result = obj.Unpack_VRCPlayerApi();
                        if (result != null)
                        {
                            return result.displayName;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "VRC.SDKBase.VRCPlayerApi[]")
                    {
                        var list = obj.Unpack_List_VRCPlayerApi();
                        if (list != null && list.Count != 0)
                        {
                            string translated = "";
                            foreach (var item in list)
                            {
                                if (item != null)
                                {
                                    translated += item.displayName + Environment.NewLine;
                                }
                            }
                            return translated;
                        }
                        else
                        {
                            return $"empty {FullName}";
                        }
                    }
                    else if (FullName == "VRC.Udon.UdonBehaviour")
                    {
                        var result = obj.Unpack_UdonBehaviour();
                        if (result != null)
                        {
                            return result.name;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "VRC.Udon.Common.Interfaces.NetworkEventTarget")
                    {
                        var result = obj.Unpack_NetworkEventTarget();
                        if (result.HasValue && result != null)
                        {
                            return result.Value.ToString();
                        }
                        return "empty NetworkEventTarget";
                    }
                    else if (FullName == "TMPro.TextMeshPro")
                    {
                        var result = obj.Unpack_TextMeshPro();
                        if (result != null)
                        {
                            return result.text;
                        }
                        return $"empty {FullName}";
                    }
                    else if (FullName == "TMPro.TextMeshProUGUI")
                    {
                        var result = obj.Unpack_TextMeshProUGUI();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                        return $"empty {FullName}";
                    }

                    return $"Not Supported Yet {FullName}";
                }
                return "Null";
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
                return $"Error Unboxing {obj.GetIl2CppType().FullName}";
            }

        }
    }
}