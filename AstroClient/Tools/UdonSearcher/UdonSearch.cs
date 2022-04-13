using AstroClient.Tools.Extensions;

namespace AstroClient.Tools.UdonSearcher
{
    using CustomClasses;
    using Regexes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UdonEditor;
    using UnityEngine;
    using VRC.Udon;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal static class UdonSearch
    {
        internal static List<UdonBehaviour_Cached> FindAllUdonEvents(string action, string subaction, bool Debug = false)
        {
            var gameobjects = UdonParser.WorldBehaviours;

            List<UdonBehaviour_Cached> foundEvents = new List<UdonBehaviour_Cached>();
            var behaviours = gameobjects.Where(x => x.gameObject.name == action);
            if (behaviours.Any())
            {
                foreach (var behaviour in behaviours)
                {
                    if (behaviour._eventTable.count != 0)
                    {
                        if (Debug)
                        {
                            Log.Debug($"Found Behaviour {behaviour.gameObject.name}, Searching for Action.");
                        }

                        for (int i = 0; i < behaviour._eventTable.entries.Count; i++)
                        {
                            var actionkeys = behaviour._eventTable.entries[i];
                            if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;
                            if (actionkeys.key == subaction)
                            {
                                if (Debug)
                                {
                                    Log.Debug($"Found subaction {actionkeys.key} bound in {behaviour.gameObject.name}");
                                }

                                foundEvents.Add(new UdonBehaviour_Cached(behaviour, actionkeys.key));
                            }
                        }
                    }

                    return foundEvents;
                }
            }

            return null;
        }

        internal static List<GameObject> FindAllUdonsContainingSymbols(List<string> TargetedSymbols, bool Debug = false)
        {
            return FindAllUdonsContainingSymbols(TargetedSymbols.ToArray(), Debug);
        }

        internal static List<GameObject> FindAllUdonsContainingSymbols(string[] TargetedSymbols, bool Debug = false)
        {
            
            List<GameObject> searchResult = new List<GameObject>();
            var udons = WorldUtils.UdonScripts;
            Log.Debug($"Searching for {TargetedSymbols.Length} Symbols in {udons.Length} Behaviours..");
            foreach(var item in udons)
            {
                if (item != null)
                {
                    if (!searchResult.Contains(item.gameObject))
                    {
                        if(Debug)
                        {
                            Log.Debug($"Inspecting {item.name}...");
                        }
                        var rawitem = item.ToRawUdonBehaviour();
                        if (rawitem != null)
                        {
                            if (Debug)
                            {
                                Log.Debug($"Udon Heap has  {rawitem.SymbolsDictionary.Count} Symbols!");
                            }

                            foreach (var target in TargetedSymbols)
                            {
                                if (Debug)
                                {
                                    Log.Debug($"Searching for Symbol {target} in {item.name}!");
                                }


                                if (rawitem.HasSymbol(target))
                                {
                                    if (Debug)
                                    {
                                        Log.Debug($"Found Symbol {target} in {item.name}!");
                                    }

                                    searchResult.Add(item.gameObject);
                                    break;
                                }
                            }

                        }
                    }
                }

            }

            return searchResult;
        }


        internal static UdonBehaviour_Cached FindUdonEvent(string action, string subaction, bool Debug = false)
        {
            var gameobjects = UdonParser.WorldBehaviours;
            var behaviour = gameobjects.Where(x => x.gameObject.name == action).DefaultIfEmpty(null).First();
            if (behaviour != null)
            {
                if (behaviour._eventTable.count != 0)
                {
                    if (Debug)
                    {
                        Log.Debug($"Found Behaviour {behaviour.gameObject.name}, Searching for Action.");
                    }

                    foreach (var actionkeys in behaviour._eventTable)
                    {
                        if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;
                        if (actionkeys.key.Equals(subaction))
                        {
                            if (Debug)
                            {
                                Log.Debug($"Found subaction {actionkeys.key} bound in {behaviour.gameObject.name}");
                            }

                            return new UdonBehaviour_Cached(behaviour, actionkeys.key);
                        }
                    }
                }
            }

            Log.Error($"Failed to Find {action} Having SubKey {subaction}");
            return null;
        }

        internal static UdonBehaviour_Cached FindUdonEvent(Transform parent, string action, string subaction, bool Debug = false, bool ShowError = false)
        {
            return FindUdonEvent(parent.gameObject, action, subaction, Debug, ShowError);
        }

        internal static UdonBehaviour_Cached FindUdonEvent(GameObject parent, string action, string subaction, bool Debug = false, bool ShowError = false)
        {
            var gameobjects = parent.GetComponentsInChildren<UdonBehaviour>(true);
            var behaviour = gameobjects.Where(x => x.gameObject.name == action).DefaultIfEmpty(null).First();
            if (behaviour != null)
            {
                if (behaviour._eventTable.count != 0)
                {
                    if (Debug)
                    {
                        Log.Debug($"Found Behaviour {behaviour.gameObject.name}, Searching for Action.");
                    }

                    for (int i = 0; i < behaviour._eventTable.entries.Count; i++)
                    {
                        var actionkeys = behaviour._eventTable.entries[i];
                        if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;
                        if (actionkeys.key == subaction)
                        {
                            Log.Debug($"Found subaction {actionkeys.key} bound in {behaviour.gameObject.name}");
                            return new UdonBehaviour_Cached(behaviour, actionkeys.key);
                        }
                    }
                }
            }
            if (ShowError)
            {
                Log.Error($"Failed to Find {action} Having SubKey {subaction}");
            }
            return null;
        }

        internal static UdonBehaviour_Cached FindUdonEvent(UdonBehaviour obj, string subaction, bool Debug = false)
        {
            if (obj != null)
            {
                if (obj._eventTable.count != 0)
                {
                    for (int i = 0; i < obj._eventTable.entries.Count; i++)
                    {
                        var actionkeys = obj._eventTable.entries[i];
                        if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;
                        if (actionkeys.key == subaction)
                        {
                            if (Debug)
                            {
                                Log.Debug($"Found subaction {actionkeys.key} bound in {obj.gameObject.name}");
                            }
                            return new UdonBehaviour_Cached(obj, actionkeys.key);
                        }
                    }
                }
            }

            return null;
        }

        internal static bool HasUdonEvent(UdonBehaviour obj, string subaction)
        {
            if (obj != null)
            {
                if (obj._eventTable.count != 0)
                {
                    for (int i = 0; i < obj._eventTable.entries.Count; i++)
                    {
                        var actionkeys = obj._eventTable.entries[i];
                        if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;
                        if (actionkeys.key == subaction)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        internal static bool HasUdonEvent(GameObject obj, string subaction)
        {
            var actionObjects = obj.GetComponentsInChildren<UdonBehaviour>(true);

            for (int i = 0; i < actionObjects.Count; i++)
            {
                UdonBehaviour actionobject = actionObjects[i];
                if (actionobject != null)
                {
                    for (int i1 = 0; i1 < actionobject._eventTable.entries.Count; i1++)
                    {
                        var actionkeys = actionobject._eventTable.entries[i1];
                        if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;
                        if (actionkeys.key == subaction)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        internal static UdonBehaviour_Cached FindUdonEvent(GameObject obj, string subaction, bool Debug = false)
        {
            var actionObjects = obj.GetComponentsInChildren<UdonBehaviour>(true);

            for (int i = 0; i < actionObjects.Count; i++)
            {
                UdonBehaviour actionobject = actionObjects[i];
                if (actionobject != null)
                {
                    for (int i1 = 0; i1 < actionobject._eventTable.entries.Count; i1++)
                    {
                        var actionkeys = actionobject._eventTable.entries[i1];
                        if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;
                        if (actionkeys.key == subaction)
                        {
                            if (Debug)
                            {
                                Log.Debug($"Found subaction {actionkeys.key} bound in {actionobject.gameObject.name}");
                            }
                            return new UdonBehaviour_Cached(actionobject, actionkeys.key);
                        }
                    }
                }
            }

            return null;
        }

        internal static List<UdonBehaviour_Cached> FindUdonEvents(GameObject obj, string subaction, bool Debug = false)
        {
            var result = new List<UdonBehaviour_Cached>();
            var actionObjects = obj.GetComponentsInChildren<UdonBehaviour>(true);

            for (int i = 0; i < actionObjects.Count; i++)
            {
                UdonBehaviour actionobject = actionObjects[i];
                if (actionobject != null)
                {
                    for (int i1 = 0; i1 < actionobject._eventTable.entries.Count; i1++)
                    {
                        var actionkeys = actionobject._eventTable.entries[i1];
                        if (actionkeys.key.IsNullOrEmptyOrWhiteSpace()) continue;

                        if (actionkeys.key == subaction)
                        {
                            if (Debug)
                            {
                                Log.Debug($"Found subaction {actionkeys.key} bound in {actionobject.gameObject.name}");
                            }
                            result.Add(new UdonBehaviour_Cached(actionobject, actionkeys.key));
                        }
                    }
                }
            }

            if (result.Count != 0)
            {
                return result;
            }

            return null;
        }

        internal static RawUdonBehaviour FindUdonVariableInChildrens(GameObject obj, string SymbolName)
        {
            var searchObjects = obj.GetComponentsInChildren<UdonBehaviour>(true).ToList();
            if (searchObjects.Count() != 0)
            {
                for (int i = 0; i < searchObjects.Count; i++)
                {
                    var unpackedudon = searchObjects[i].ToRawUdonBehaviour();
                    if (unpackedudon != null)
                    {
                        if(unpackedudon.HasSymbol(SymbolName))
                        {
                            return unpackedudon;
                        }
                        
                    }
                }
            }

            return null;
        }

        internal static RawUdonBehaviour FindUdonVariable(GameObject obj, string SymbolName)
        {
            var searchObjects = obj.GetComponents<UdonBehaviour>().ToList();
            if (searchObjects.Count() != 0)
            {
                for (int i = 0; i < searchObjects.Count; i++)
                {
                    var unpackedudon = searchObjects[i].ToRawUdonBehaviour();
                    if (unpackedudon != null)
                    {
                        if (unpackedudon.HasSymbol(SymbolName))
                        {
                            return unpackedudon;
                        }
                    }
                }
            }

            return null;
        }

        internal static List<string> FindUdonAvatarPedestrals()
        {
            var udons = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            var result = new List<string>();
            if (udons.Count() != 0)
            {
                for (int i3 = 0; i3 < udons.Count; i3++)
                {
                    var unpackedudon = udons[i3].ToRawUdonBehaviour();
                    if (unpackedudon != null)
                    {
                        if (unpackedudon == null || unpackedudon == null)
                        {
                            continue;
                        }

                        for (int i2 = 0; i2 < unpackedudon.IUdonSymbolTable.GetSymbols().Length; i2++)
                        {
                            string symbol = unpackedudon.IUdonSymbolTable.GetSymbols()[i2];
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
                                            case "System.String":
                                                {
                                                    var item = unpackedudon.IUdonHeap.GetHeapVariable<string>(address);
                                                    if (item != null && item.IsNotNullOrEmptyOrWhiteSpace())
                                                    {
                                                        if (item.IsAvatarID())
                                                        {
                                                            result.Add(item);
                                                        }
                                                        else
                                                        {
                                                            var ids = item.GetAllAvatarIDs();
                                                            if (ids != null)
                                                            {
                                                                if (ids.Count() != 0)
                                                                {
                                                                    for (int i = 0; i < ids.Count; i++)
                                                                    {
                                                                        string id = ids[i];
                                                                        if (id != null)
                                                                        {
                                                                            result.Add(id);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                    break;
                                                }
                                            case "System.String[]":
                                                {
                                                    var list = unpackedudon.IUdonHeap.GetHeapVariable<string[]>(address);
                                                    if (list.Count() != 0)
                                                        for (int i = 0; i < list.Length; i++)
                                                        {
                                                            string value = list[i];
                                                            if (value != null && value.IsNotNullOrEmptyOrWhiteSpace())
                                                            {
                                                                if (value.IsAvatarID())
                                                                {
                                                                    result.Add(value);
                                                                }
                                                                else
                                                                {
                                                                    var ids = value.GetAllAvatarIDs();
                                                                    if (ids.Count() != 0)
                                                                    {
                                                                        for (int i1 = 0; i1 < ids.Count; i1++)
                                                                        {
                                                                            string id = ids[i1];
                                                                            if (id != null)
                                                                            {
                                                                                result.Add(id);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }

                                                    break;
                                                }
                                            case "VRC.SDK3.Components.VRCAvatarPedestal":
                                                {
                                                    var pedestral = unpackedudon.IUdonHeap.GetHeapVariable<VRC.SDK3.Components.VRCAvatarPedestal>(address);
                                                    if (pedestral != null)
                                                    {
                                                        if (!pedestral.grantBlueprintAccess)
                                                        {
                                                            pedestral.grantBlueprintAccess = true;
                                                        }

                                                        if (pedestral.blueprintId.IsNotNullOrEmptyOrWhiteSpace() &&
                                                            pedestral.blueprintId.IsAvatarID())
                                                        {
                                                            result.Add(pedestral.blueprintId);
                                                        }
                                                    }

                                                    break;
                                                }
                                            case "VRC.SDK3.Components.VRCAvatarPedestal[]":
                                                {
                                                    var list = unpackedudon.IUdonHeap.GetHeapVariable<VRC.SDK3.Components.VRCAvatarPedestal[]>(address);
                                                    if (list != null && list.Count() != 0)
                                                    {
                                                        for (int i = 0; i < list.Length; i++)
                                                        {
                                                            var pedestral = list[i];
                                                            if (pedestral != null)
                                                            {
                                                                if (!pedestral.grantBlueprintAccess)
                                                                {
                                                                    pedestral.grantBlueprintAccess = true;
                                                                }

                                                                if (pedestral.blueprintId
                                                                        .IsNotNullOrEmptyOrWhiteSpace() &&
                                                                    pedestral.blueprintId.IsAvatarID())
                                                                {
                                                                    result.Add(pedestral.blueprintId);
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
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}