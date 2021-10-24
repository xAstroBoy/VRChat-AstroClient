namespace AstroClient.Udon
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using System.Linq;
    using Il2CppSystem;
    using TMPro;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC.Udon;
    using Object = Il2CppSystem.Object;

    internal static class UdonReplacer
    {


        internal static void ReplaceString(string find, string replace)
        {
            if (!find.IsNotNullOrEmptyOrWhiteSpace()) return;

            var udons = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            int result = 0;
            if (udons.Count() != 0)
            {
                foreach (var behaviour in udons)
                {
                    var unpackedudon = behaviour.DisassembleUdonBehaviour();
                    if (unpackedudon != null)
                    {
                        if (unpackedudon == null || unpackedudon == null)
                        {
                            continue;
                        }

                        foreach (var symbol in unpackedudon.IUdonSymbolTable.GetSymbols())
                        {
                            if (symbol != null)
                            {
                                var address = unpackedudon.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                                var UnboxVariable = unpackedudon.IUdonHeap.GetHeapVariable(address);
                                if (UnboxVariable != null)
                                {
                                    var ObjectType = UnboxVariable.GetIl2CppType();
                                    if (ObjectType == null) continue;
                                    try
                                    {

                                        if (ObjectType.Equals(Il2CppType.Of<System.String>()))
                                        {
                                            var item = UnboxVariable.Unpack_String();
                                            if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                            {
                                                if (item.ToLower().Equals(find.ToLower()) ||
                                                    item.ToLower().Contains(find.ToLower()))
                                                {
                                                    result++;
                                                    var patch = item.Replace(find, replace);
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol, item, true);

                                                }
                                            }

                                        }
                                        else if (ObjectType.Equals(Il2CppType.Of<System.String[]>()))
                                        {
                                            var list = UnboxVariable.Unpack_List_String();
                                            if (list.Count() != 0)
                                            {
                                                var patchedlist = new List<string>();
                                                bool modified = false;
                                                foreach (var value in list)
                                                {
                                                    if (value != null && value.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (value.ToLower().Equals(find.ToLower()) ||
                                                            value.ToLower().Contains(find.ToLower()))
                                                        {
                                                            result++;
                                                            var patched = value.Replace(find, replace);
                                                            patchedlist.Add(patched);
                                                            modified = true;
                                                        }
                                                        else
                                                        {
                                                            patchedlist.Add(value);
                                                        }
                                                    }
                                                }

                                                if (modified)
                                                {
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol,
                                                        patchedlist.ToArray(), true);
                                                }
                                            }
                                        }
                                        else if (ObjectType.Equals(Il2CppType.Of<TMPro.TextMeshPro>()))
                                        {
                                            var item = UnboxVariable.Unpack_TextMeshPro();
                                            if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                            {
                                                if (item.text.ToLower().Equals(find.ToLower()) ||
                                                    item.text.ToLower().Contains(find.ToLower()))
                                                {
                                                    result++;
                                                    item.text = item.text.Replace(find, replace);
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol, item, true);

                                                }
                                            }

                                        }

                                        else if (ObjectType.Equals(Il2CppType.Of<TMPro.TextMeshPro[]>()))
                                        {
                                            var list = UnboxVariable.Unpack_List_TextMeshPro();
                                            if (list.Count() != 0)
                                            {
                                                var patchedlist = new List<TextMeshPro>();
                                                bool modified = false;
                                                foreach (var value in list)
                                                {
                                                    if (value.text != null && value.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (value.text.ToLower().Equals(find.ToLower()) ||
                                                            value.text.ToLower().Contains(find.ToLower()))
                                                        {
                                                            result++;
                                                            value.text = value.text.Replace(find, replace);
                                                            patchedlist.Add(value);
                                                            modified = true;
                                                        }
                                                        else
                                                        {
                                                            patchedlist.Add(value);
                                                        }
                                                    }
                                                }

                                                if (modified)
                                                {
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol,
                                                        patchedlist.ToArray(), true);
                                                }
                                            }
                                        }
                                        else if (ObjectType.Equals(Il2CppType.Of<UnityEngine.UI.Text>()))
                                        {
                                            var item = UnboxVariable.Unpack_UnityEngine_UI_Text();
                                            if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                            {
                                                if (item.text.ToLower().Equals(find.ToLower()) ||
                                                    item.text.ToLower().Contains(find.ToLower()))
                                                {
                                                    result++;
                                                    item.text = item.text.Replace(find, replace);
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol, item, true);

                                                }
                                            }

                                        }

                                        else if (ObjectType.Equals(Il2CppType.Of<UnityEngine.UI.Text[]>()))
                                        {
                                            var list = UnboxVariable.Unpack_List_UnityEngine_UI_Text();
                                            if (list.Count() != 0)
                                            {
                                                var patchedlist = new List<UnityEngine.UI.Text>();
                                                bool modified = false;
                                                foreach (var value in list)
                                                {
                                                    if (value.text != null &&
                                                        value.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (value.text.ToLower().Equals(find.ToLower()) ||
                                                            value.text.ToLower().Contains(find.ToLower()))
                                                        {
                                                            result++;
                                                            value.text = value.text.Replace(find, replace);
                                                            patchedlist.Add(value);
                                                            modified = true;
                                                        }
                                                        else
                                                        {
                                                            patchedlist.Add(value);
                                                        }
                                                    }
                                                }

                                                if (modified)
                                                {
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol,
                                                        patchedlist.ToArray(), true);
                                                }

                                            }
                                        }

                                        else if (ObjectType.Equals(Il2CppType.Of<UnityEngine.TextAsset>()))
                                        {
                                            ModConsole.DebugLog("Found Single TextAsset");
                                            var item = UnboxVariable.Unpack_TextAsset();
                                            if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                            {
                                                if (item.text.ToLower().Equals(find.ToLower()) ||
                                                    item.text.ToLower().Contains(find.ToLower()))
                                                {
                                                    var patchedtext = item.text.Replace(find, replace);
                                                    var patchedvalue =
                                                        new UnityEngine.TextAsset(TextAsset.CreateOptions.None,
                                                            patchedtext);
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol, patchedvalue, true);
                                                    result++;

                                                }
                                            }

                                            break;
                                        }

                                        else if (ObjectType.Equals(Il2CppType.Of<UnityEngine.TextAsset[]>()))
                                        {
                                            ModConsole.DebugLog("Found Single TextAsset");
                                            var list = UnboxVariable.Unpack_List_TextAsset();
                                            if (list.Count() != 0)
                                            {
                                                var patchedlist = new List<UnityEngine.TextAsset>();
                                                bool modified = false;
                                                foreach (var value in list)
                                                {
                                                    if (value.text != null &&
                                                        value.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (value.text.ToLower().Equals(find.ToLower()) ||
                                                            value.text.ToLower().Contains(find.ToLower()))
                                                        {
                                                            result++;
                                                            var patchedtext = value.text.Replace(find, replace);
                                                            var patchedvalue =
                                                                new UnityEngine.TextAsset(TextAsset.CreateOptions.None,
                                                                    patchedtext);
                                                            patchedlist.Add(patchedvalue);
                                                            modified = true;
                                                        }
                                                        else
                                                        {
                                                            patchedlist.Add(value);
                                                        }
                                                    }
                                                }

                                                if (modified)
                                                {
                                                    UdonHeapEditor.PatchHeap(unpackedudon, symbol,
                                                        patchedlist.ToArray(), true);
                                                }
                                            }
                                        }
                                    }

                                    catch

                                        (System.Exception e)
                                    {
                                        ModConsole.DebugErrorExc(e);
                                    }
                                }
                            }
                        }
                    }
                }
                ModConsole.DebugLog($"Found and replaced {result}, containing {find} with {replace}");
            }
        }
    }
}