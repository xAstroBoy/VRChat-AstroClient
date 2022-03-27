using System.Windows.Forms.DataVisualization.Charting;
#pragma warning disable CS0168

namespace AstroClient.Tools.UdonSearcher
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Extensions;
    using Il2CppSystem.Text.RegularExpressions;
    using MelonLoader;
    using TMPro;
    using UdonEditor;
    using UnityEngine;
    using VRC.Udon;
    using xAstroBoy;
    using xAstroBoy.Extensions;

    internal static class UdonReplacer
    {

        internal static void ReplaceString(string find, string replacement)
        {
            MelonCoroutines.Start(ReplaceString_Routine(find, replacement));
        }




        private static IEnumerator ReplaceString_Routine(string find, string replacement)
        {

            if (!find.IsNotNullOrEmptyOrWhiteSpace() || !replacement.IsNotNullOrEmptyOrWhiteSpace()) yield return null;
        int success = 0;
       int Failed  = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
            var udons = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            var reg = new Regex();
            if (udons.Count() != 0)
            {
                foreach (var udonnode in udons)
                {
                    var unpackedudon = udonnode.ToRawUdonBehaviour();
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
                                                    var item = unpackedudon.IUdonHeap.GetHeapVariable<string>(address);
                                                    if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.isMatch(find))
                                                        {
                                                            var modifiedstring = item.ReplaceWholeWord(find, replacement);
                                                            //ModConsole.DebugLog($"Modified a String , Original : {item}, Modified : {modifiedstring}");
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, modifiedstring, () => { success++; }, () => { Failed++; });
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.System_String_Array:
                                                {
                                                    var list = unpackedudon.IUdonHeap.GetHeapVariable<string[]>(address).ToList();
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
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), () => { success++; }, () => { Failed++; });
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.TMPro_TextMeshPro:
                                                {
                                                    var item = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshPro>(address);
                                                    if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.text.isMatch(find))
                                                        {
                                                            var modifiedstring = item.text.ReplaceWholeWord(find, replacement);
                                                            //ModConsole.DebugLog($"Modified String in TextMeshPro , Original : {item}, Modified : {modifiedstring}");

                                                            item.text = modifiedstring;
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, item, () => { success++; }, () => { Failed++; });
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.TMPro_TextMeshPro_Array:
                                                {
                                                    var list = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshPro[]>(address).ToList();
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
                                                            UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), () => { success++; }, () => { Failed++; });
                                                        }
                                                    }

                                                    break;
                                                }
                                            // TODO: Figure how to edit it .
                                            case UdonTypes_String.UnityEngine_TextAsset:
                                                {
                                                    var item = unpackedudon.IUdonHeap.GetHeapVariable<TextAsset>(address);
                                                    if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.text.isMatch(find))
                                                        {
                                                            //unsupported++;
                                                            try
                                                            {
                                                                var patchedstr = item.text.ReplaceWholeWord(find, replacement);
                                                                //var RebuiltTextAsset = new TextAsset(TextAsset.CreateOptions.CreateNativeObject, patchedstr);
                                                                //result++;
                                                                //UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, RebuiltTextAsset, true);
                                                                TextAsset.Internal_CreateInstance(item, patchedstr);
                                                                if (item.text.Equals(patchedstr))
                                                                {
                                                                    success++;
                                                                    ModConsole.DebugLog("Patched TextAsset!");
                                                                }
                                                                else
                                                                {
                                                                    ModConsole.DebugLog("Failed to Patch TextAsset");
                                                                    Failed++;
                                                                }

                                                            }
                                                            catch (Exception e)
                                                            {
                                                                ModConsole.ErrorExc(e);
                                                            }
                                                        }
                                                    }

                                                    break;
                                                }
                                            case UdonTypes_String.UnityEngine_TextAsset_Array:
                                                {
                                                    var list = unpackedudon.IUdonHeap.GetHeapVariable<TextAsset[]>(address).ToList();
                                                    if (list == null)
                                                    {
                                                        Failed++;
                                                        break;
                                                    }
                                                    if (list.Count() != 0)
                                                    {
                                                        foreach (var item in list)
                                                        {
                                                            if (item.text != null &&
                                                                item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                            {
                                                                if (item.text.isMatch(find))
                                                                {

                                                                    try
                                                                    {
                                                                        var patchedstr = item.text.ReplaceWholeWord(find, replacement);
                                                                        TextAsset.Internal_CreateInstance(item, patchedstr);
                                                                        if (item.text.Equals(patchedstr))
                                                                        {
                                                                            success++;
                                                                            ModConsole.DebugLog("Patched TextAsset!");
                                                                        }
                                                                        else
                                                                        {
                                                                            ModConsole.DebugLog("Failed to Patch TextAsset");
                                                                            Failed++;
                                                                        }

                                                                        //var RebuiltTextAsset = new TextAsset(TextAsset.CreateOptions.CreateNativeObject, patchedstr);
                                                                        //patchedlist.Add(RebuiltTextAsset);
                                                                        //result++;
                                                                        //modified = true;
                                                                    }

                                                                    catch (Exception e)
                                                                    {
                                                                        ModConsole.ErrorExc(e);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                    break;
                                                }
                                            default:
                                                continue;
                                        }
                                    }
                                    // TODO : Make a better parser using the same approach (WIP)
                                    catch (Exception e)
                                    {
                                        Failed++;
                                        //ModConsole.DebugErrorExc(e);
                                    }
                                }
                            }
                        }
                    }
                }
                stopwatch.Stop();
                ModConsole.DebugLog($"Found and replaced {success}, containing {find} with {replacement}, Failed : {Failed}, Took : {stopwatch.ElapsedMilliseconds}ms");
            }

            yield return null;
        }
    }
}