#pragma warning disable CS0168

namespace AstroClient.Tools.UdonSearcher
{
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using TMPro;
    using UdonEditor;
    using UnityEngine;
    using VRC.Udon;
    using xAstroBoy;
    using xAstroBoy.Extensions;

    internal static class UdonReplacer
    {
        private static int Success { get; set; } = 0;
        private static int Failure { get; set; } = 0;

        internal static void ReplaceString(string find, string replacement)
        {
            MelonCoroutines.Start(ReplaceString_Routine(find, replacement));
        }

        private static IEnumerator ReplaceString_Routine(string find, string replacement)
        {
            Success = 0;
            Failure = 0;
            if (!find.IsNotNullOrEmptyOrWhiteSpace() || !replacement.IsNotNullOrEmptyOrWhiteSpace()) yield return null;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var udons = Finder.GetRootGameObjectsComponents<UdonBehaviour>();
            if (udons.Count() != 0)
            {
                for (int i1 = 0; i1 < udons.Count; i1++)
                {
                    UdonBehaviour udonnode = udons[i1];
                    MelonCoroutines.Start(ReplaceStringInternal(udonnode, find, replacement));
                }
                stopwatch.Stop();
                Log.Debug($"Found and replaced {Success}, containing {find} with {replacement}, Failure : {Failure}, Took : {stopwatch.ElapsedMilliseconds}ms");
            }

            yield return null;
        }

        private static IEnumerator ReplaceStringInternal(UdonBehaviour udonnode, string find, string replacement)
        {
            var unpackedudon = udonnode.ToRawUdonBehaviour();
            if (unpackedudon != null)
            {
                var symboltable = unpackedudon.IUdonSymbolTable;
                var table = symboltable.GetSymbols();
                for (int i2 = 0; i2 < table.Length; i2++)
                {
                    string symbol = table[i2];
                    if (symbol != null)
                    {
                        var address = symboltable.GetAddressFromSymbol(symbol);
                        var UnboxVariable = unpackedudon.IUdonHeap.GetHeapVariable(address);
                        if (UnboxVariable != null)
                        {
                            try
                            {
                                switch (UnboxVariable.GetIl2CppType().FullName)
                                {
                                    case "System.String":
                                        {
                                            var item = unpackedudon.IUdonHeap.GetHeapVariable<string>(address);
                                            if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                            {
                                                if (item.isMatch(find))
                                                {
                                                    var modifiedstring = item.ReplaceWholeWord(find, replacement);
                                                    //Log.Debug($"Modified a String , Original : {item}, Modified : {modifiedstring}");
                                                    UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, modifiedstring, () => { Success++; }, () => { Failure++; }, false, true);
                                                }
                                            }

                                            break;
                                        }
                                    case "System.String[]":
                                        {
                                            var list = unpackedudon.IUdonHeap.GetHeapVariable<string[]>(address).ToList();
                                            if (list.Count() != 0)
                                            {
                                                var patchedlist = new List<string>();
                                                bool modified = false;
                                                for (int i = 0; i < list.Count; i++)
                                                {
                                                    string item = list[i];
                                                    if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.isMatch(find))
                                                        {
                                                            var modifiedstring = item.ReplaceWholeWord(find, replacement);
                                                            //Log.Debug($"Modified String in Array , Original : {item}, Modified : {modifiedstring}");
                                                            patchedlist.Add(modifiedstring);
                                                            modified = true;
                                                            continue;
                                                        }
                                                    }
                                                    patchedlist.Add(item);
                                                }
                                                if (modified)
                                                {
                                                    UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), () => { Success++; }, () => { Failure++; }, false, true);
                                                }
                                            }

                                            break;
                                        }
                                    case "TMPro.TextMeshPro":
                                        {
                                            var item = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshPro>(address);
                                            if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                            {
                                                if (item.text.isMatch(find))
                                                {
                                                    var modifiedstring = item.text.ReplaceWholeWord(find, replacement);
                                                    //Log.Debug($"Modified String in TextMeshPro , Original : {item}, Modified : {modifiedstring}");

                                                    item.text = modifiedstring;
                                                    UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, item, () => { Success++; }, () =>
                                                    {
                                                        var item = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshProUGUI>(address);
                                                        if (item != null)
                                                        {
                                                            if (item.text.Equals(modifiedstring))
                                                            {
                                                                Success++;
                                                            }
                                                            else
                                                            {
                                                                Failure++;
                                                            }
                                                        }
                                                    }, false, true);
                                                }
                                            }

                                            break;
                                        }
                                    case "TMPro.TextMeshPro[]":
                                        {
                                            var list = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshPro[]>(address).ToList();
                                            if (list.Count() != 0)
                                            {
                                                var patchedlist = new List<TextMeshPro>();
                                                bool modified = false;
                                                for (int i = 0; i < list.Count; i++)
                                                {
                                                    TextMeshPro item = list[i];
                                                    if (item.text != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.text.isMatch(find))
                                                        {
                                                            var modifiedstring = item.text.ReplaceWholeWord(find, replacement);
                                                            //Log.Debug($"Modified String in TextMeshPro Array , Original : {item}, Modified : {modifiedstring}");
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
                                                    UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), () => { Success++; }, () => { Failure++; }, false, true);
                                                }
                                            }

                                            break;
                                        }

                                    case "TMPro.TextMeshProUGUI":
                                        {
                                            var item = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshProUGUI>(address);
                                            if (item != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                            {
                                                if (item.text.isMatch(find))
                                                {
                                                    var modifiedstring = item.text.ReplaceWholeWord(find, replacement);
                                                    //Log.Debug($"Modified String in TextMeshProUGUI , Original : {item}, Modified : {modifiedstring}");

                                                    item.text = modifiedstring;
                                                    UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, item, () => { Success++; }, () =>
                                                    {
                                                        var item = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshProUGUI>(address);
                                                        if (item != null)
                                                        {
                                                            if (item.text.Equals(modifiedstring))
                                                            {
                                                                Success++;
                                                            }
                                                            else
                                                            {
                                                                Failure++;
                                                            }
                                                        }
                                                    }, false, true);
                                                }
                                            }

                                            break;
                                        }
                                    case "TMPro.TextMeshProUGUI[]":
                                        {
                                            var list = unpackedudon.IUdonHeap.GetHeapVariable<TextMeshProUGUI[]>(address).ToList();
                                            if (list.Count() != 0)
                                            {
                                                var patchedlist = new List<TextMeshProUGUI>();
                                                bool modified = false;
                                                for (int i = 0; i < list.Count; i++)
                                                {
                                                    TextMeshProUGUI item = list[i];
                                                    if (item.text != null && item.text.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.text.isMatch(find))
                                                        {
                                                            var modifiedstring = item.text.ReplaceWholeWord(find, replacement);
                                                            //Log.Debug($"Modified String in TextMeshProUGUI Array , Original : {item}, Modified : {modifiedstring}");
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
                                                    UdonHeapEditor.PatchHeap(unpackedudon.IUdonHeap, address, patchedlist.ToArray(), () => { Success++; }, () => { Failure++; }, false, true);
                                                }
                                            }

                                            break;
                                        }

                                    // TODO: Figure how to edit it .
                                    case "UnityEngine.TextAsset":
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
                                                            Success++;
                                                            Log.Debug("Patched TextAsset!");
                                                        }
                                                        else
                                                        {
                                                            Log.Debug("Failure to Patch TextAsset");
                                                            Failure++;
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Log.Exception(e);
                                                    }
                                                }
                                            }

                                            break;
                                        }
                                    case "UnityEngine.TextAsset[]":
                                        {
                                            var list = unpackedudon.IUdonHeap.GetHeapVariable<TextAsset[]>(address).ToList();
                                            if (list == null)
                                            {
                                                Failure++;
                                                break;
                                            }
                                            if (list.Count() != 0)
                                            {
                                                for (int i = 0; i < list.Count; i++)
                                                {
                                                    TextAsset item = list[i];
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
                                                                    Success++;
                                                                    Log.Debug("Patched TextAsset!");
                                                                }
                                                                else
                                                                {
                                                                    Log.Debug("Failure to Patch TextAsset");
                                                                    Failure++;
                                                                }

                                                                //var RebuiltTextAsset = new TextAsset(TextAsset.CreateOptions.CreateNativeObject, patchedstr);
                                                                //patchedlist.Add(RebuiltTextAsset);
                                                                //result++;
                                                                //modified = true;
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                Log.Exception(e);
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
                            catch 
                            {
                                Failure++;
                                //Log.Exception(e);
                            }
                        }
                    }
                }
            }
            yield return null;
        }

        internal static void ReplaceString(this UdonBehaviour udonnode, string find, string replacement)
        {
            Success = 0;
            Failure = 0;
            var stopwatch = new Stopwatch();
            MelonCoroutines.Start(ReplaceStringInternal(udonnode, find, replacement));
            stopwatch.Stop();
            if (Success != 0 || Failure != 0)
            {
                Log.Debug($"Found and replaced {Success}, containing {find} with {replacement}, Failure : {Failure}, Took : {stopwatch.ElapsedMilliseconds}ms");
            }
        }

    }
}