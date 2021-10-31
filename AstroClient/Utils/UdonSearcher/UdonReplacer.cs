namespace AstroClient.Udon
{
    using System;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using Il2CppSystem.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using TMPro;
    using UnityEngine;
    using VRC.Udon;

    internal static class UdonReplacer
    {
        internal static void ReplaceString(string find, string replacement)
        {
            if (!find.IsNotNullOrEmptyOrWhiteSpace() || !replacement.IsNotNullOrEmptyOrWhiteSpace()) return;
            var udons = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            int result = 0;
            var reg = new Regex();
            if (udons.Count() != 0)
            {
                foreach (var udonnode in udons)
                {
                    var unpackedudon = udonnode.DisassembleUdonBehaviour();
                    if (unpackedudon != null)
                    {
                        foreach (var symbol in unpackedudon.IUdonSymbolTable.GetSymbols())
                        {
                            if (symbol != null)
                            {
                                var address = unpackedudon.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                                var UnboxVariable = unpackedudon.IUdonHeap.GetHeapVariable(address);
                                if (UnboxVariable != null)
                                {
                                    try
                                    {
                                        switch (UnboxVariable.GetIl2CppType().FullName)
                                        {
                                            case UdonTypes_String.System_String:
                                                {
                                                    var item = UnboxVariable.Unpack_String();
                                                    if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.isMatch(find))
                                                        {
                                                            result++;
                                                            var modifiedstring = item.ReplaceWholeWord(find, replacement);
                                                            //ModConsole.DebugLog($"Modified a String , Original : {item}, Modified : {modifiedstring}");
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, modifiedstring, true);
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.System_String_Array:
                                                {
                                                    var list = UnboxVariable.Unpack_List_String();
                                                    if (list.Count() != 0)
                                                    {
                                                        var patchedlist = new List<string>();
                                                        bool modified = false;
                                                        foreach (var item in list)
                                                        {
                                                            if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                                            {
                                                                if (item.Equals(find, StringComparison.InvariantCultureIgnoreCase))
                                                                {
                                                                    result++;
                                                                    var modifiedstring = item.ReplaceWholeWord(find, replacement);
                                                                    //ModConsole.DebugLog($"Modified String in Array , Original : {item}, Modified : {modifiedstring}");
                                                                    patchedlist.Add(modifiedstring);
                                                                    modified = true;
                                                                    continue;
                                                                }
                                                            }
                                                            patchedlist.Add(item);
                                                        }
                                                        if (modified)
                                                        {
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), true);
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.TMPro_TextMeshPro:
                                                {
                                                    var item = UnboxVariable.Unpack_TextMeshPro();
                                                    if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.text.isMatch(find))
                                                        {
                                                            result++;
                                                            var modifiedstring = item.text.ReplaceWholeWord(find, replacement);
                                                            //ModConsole.DebugLog($"Modified String in TextMeshPro , Original : {item}, Modified : {modifiedstring}");

                                                            item.text = modifiedstring;
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, item, true);
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.TMPro_TextMeshPro_Array:
                                                {
                                                    var list = UnboxVariable.Unpack_List_TextMeshPro();
                                                    if (list.Count() != 0)
                                                    {
                                                        var patchedlist = new List<TextMeshPro>();
                                                        bool modified = false;
                                                        foreach (var item in list)
                                                        {
                                                            if (item.text != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                            {
                                                                if (item.text.isMatch(find))
                                                                {
                                                                    result++;
                                                                    var modifiedstring = item.text.ReplaceWholeWord(find, replacement);
                                                                    //ModConsole.DebugLog($"Modified String in TextMeshPro Array , Original : {item}, Modified : {modifiedstring}");
                                                                    item.text = modifiedstring;
                                                                    patchedlist.Add(item);
                                                                    modified = true;
                                                                    continue;
                                                                }
                                                            }
                                                            patchedlist.Add(item);
                                                        }
                                                        if (modified)
                                                        {
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), true);
                                                        }
                                                    }

                                                    break;
                                                }
                                            // TODO: Figure how to edit it .
                                            case UdonTypes_String.UnityEngine_TextAsset:
                                                {
                                                    var item = UnboxVariable.Unpack_TextAsset();
                                                    if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.text.isMatch(find))
                                                        {
                                                            var patchedstr = item.text.ReplaceWholeWord(find, replacement);
                                                            result++;
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedstr, true);

                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.UnityEngine_TextAsset_Array:
                                                {
                                                    var list = UnboxVariable.Unpack_List_TextAsset();
                                                    if (list.Count() != 0)
                                                    {
                                                        var patchedlist = new List<string>();
                                                        bool modified = false;
                                                        foreach (var item in list)
                                                        {
                                                            if (item.text != null &&
                                                                item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                            {
                                                                if (item.text.isMatch(find))
                                                                {
                                                                    result++;
                                                                    var patchedstr = item.text.ReplaceWholeWord(find, replacement);
                                                                    patchedlist.Add(patchedstr);
                                                                    modified = true;
                                                                }
                                                                else
                                                                {
                                                                    patchedlist.Add(item.text);
                                                                }
                                                            }
                                                        }

                                                        if (modified)
                                                        {
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), true);
                                                        }
                                                    }

                                                    break;
                                                }
                                            default:
                                                continue;
                                        }
                                    }
                                    catch (System.Exception e)
                                    {
                                        ModConsole.DebugErrorExc(e);
                                    }
                                }
                            }
                        }
                    }
                }
                ModConsole.DebugLog($"Found and replaced {result}, containing {find} with {replacement}");
            }
        }
    }
}