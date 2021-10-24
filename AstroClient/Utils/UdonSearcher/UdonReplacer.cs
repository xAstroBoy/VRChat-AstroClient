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
    using VRC.Udon;

    internal static class UdonReplacer
    {


        internal static void ReplaceString(string find, string replace)
        {
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
                                    var Il2CppType = UnboxVariable.GetIl2CppType();
                                    string FullName = Il2CppType.FullName;
                                    try
                                    {
                                        switch (FullName)
                                        {
                                            case UdonTypes_String.System_String:
                                                {
                                                    var item = UnboxVariable.Unpack_String();
                                                    if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.ToLower().Equals(find.ToLower()) || item.ToLower().Contains(find.ToLower()))
                                                        {
                                                            result++;
                                                            var patch = item.Replace(find, replace);
                                                            ModConsole.DebugLog("Found a single string match!");
                                                            UdonHeapEditor.PatchHeap(unpackedudon, symbol, patch, true);

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
                                                        foreach (var value in list)
                                                        {
                                                            if (value != null && value.IsNotNullOrEmptyOrWhiteSpace())
                                                            {
                                                                if (value.ToLower().Equals(find.ToLower()) || value.ToLower().Contains(find.ToLower()))
                                                                {
                                                                    result++;
                                                                    var patched = value.Replace(find, replace);
                                                                    patchedlist.Add(patched);
                                                                    modified = true;
                                                                    ModConsole.DebugLog("Found a match in a Array!");
                                                                }
                                                                else
                                                                {
                                                                    patchedlist.Add(value);
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
                                            case UdonTypes_String.TMPro_TextMeshPro:
                                            {
                                                    var item = UnboxVariable.Unpack_TextMeshPro();
                                                    if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.text.ToLower().Equals(find.ToLower()) || item.text.ToLower().Contains(find.ToLower()))
                                                        {
                                                            result++;
                                                            item.text = item.text.Replace(find, replace);
                                                            ModConsole.DebugLog("Found a single string match!");

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
                                                    foreach (var value in list)
                                                    {
                                                        if (value.text != null && value.text.IsNotNullOrEmptyOrWhiteSpace())
                                                        {
                                                            if (value.text.ToLower().Equals(find.ToLower()) || value.text.ToLower().Contains(find.ToLower()))
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
                                                        UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), true);
                                                    }
                                                }


                                                break;
                                            }
                                            default:
                                                continue;
                                        }
                                    }
                                    catch
                                    {
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