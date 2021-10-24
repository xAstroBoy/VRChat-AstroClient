namespace AstroClient.Udon
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using System.Linq;
    using VRC.Udon;

    internal static class UdonReplacer
    {


        internal static void ReplaceString(string find, string replace)
        {
            var udons = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            var result = new List<string>();
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
                                                        if (item.ToLower().Equals(find.ToLower()))
                                                        {
                                                            result.Add(item);
                                                            var patch = item.Replace(find, replace);
                                                            UdonHeapEditor.PatchHeap(unpackedudon, symbol, patch, true);
                                                        }
                                                        else
                                                        {
                                                            if (item.ToLower().Contains(find.ToLower()))
                                                            {
                                                                result.Add(item);
                                                                var patch = item.Replace(find, replace);
                                                                UdonHeapEditor.PatchHeap(unpackedudon, symbol, patch, true);
                                                            }
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.System_String_Array:
                                                {
                                                    var list = UnboxVariable.Unpack_List_String();
                                                    if (list.Count() != 0)
                                                    {
                                                        bool modified = false;
                                                        foreach (var value in list)
                                                        {
                                                            if (value != null && value.IsNotNullOrEmptyOrWhiteSpace())
                                                            {
                                                                if (value.ToLower().Equals(find.ToLower()))
                                                                {
                                                                    result.Add(value);
                                                                    var patch = value.Replace(find, replace);
                                                                    modified = true;
                                                                }
                                                                else
                                                                {
                                                                    if (value.ToLower().Contains(find.ToLower()))
                                                                    {
                                                                        result.Add(value);
                                                                        var patch = value.Replace(find, replace);
                                                                        modified = true;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (modified)
                                                        {
                                                            UdonHeapEditor.PatchHeap(unpackedudon, symbol, list.ToArray(), true);
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
                ModConsole.DebugLog($"Found and replaced {result.Count}, containing {find} with {replace}");
            }
        }
    }
}