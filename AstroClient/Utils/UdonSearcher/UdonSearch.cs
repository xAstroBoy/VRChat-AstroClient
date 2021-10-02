namespace AstroClient
{
    using AstroClient.Udon;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.Udon;
    using static AstroClient.Variables.CustomLists;

    internal static class UdonSearch
    {
        internal static List<UdonBehaviour_Cached> FindAllUdonEvents(string action, string subaction)
        {
            var gameobjects = WorldUtils.UdonScripts;

            List<UdonBehaviour_Cached> foundEvents = new List<UdonBehaviour_Cached>();
            var behaviours = gameobjects.Where(x => x.gameObject.name == action);
            if (behaviours.Any())
            {
                foreach (var behaviour in behaviours)
                {
                    if (behaviour._eventTable.count != 0)
                    {
                        ModConsole.DebugLog($"Found Behaviour {behaviour.gameObject.name}, Searching for Action.");
                        foreach (var actionkeys in behaviour._eventTable)
                        {
                            if (actionkeys.key == subaction)
                            {
                                ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {behaviour.gameObject.name}");
                                foundEvents.Add(new UdonBehaviour_Cached(behaviour, actionkeys.key));
                            }
                        }
                    }
                    return foundEvents;
                }
            }

            return null;
        }

        internal static UdonBehaviour_Cached FindUdonEvent(string action, string subaction)
        {
            var gameobjects = WorldUtils.UdonScripts;

            var behaviour = gameobjects.Where(x => x.gameObject.name == action).DefaultIfEmpty(null).First();
            if (behaviour != null)
            {
                if (behaviour._eventTable.count != 0)
                {
                    ModConsole.DebugLog($"Found Behaviour {behaviour.gameObject.name}, Searching for Action.");
                    foreach (var actionkeys in behaviour._eventTable)
                    {
                        if (actionkeys.key == subaction)
                        {
                            ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {behaviour.gameObject.name}");
                            return new UdonBehaviour_Cached(behaviour, actionkeys.key);
                        }
                    }
                }
            }

            return null;
        }

        internal static UdonBehaviour_Cached FindUdonEvent(UdonBehaviour obj, string subaction)
        {
            if (obj != null)
            {
                if (obj._eventTable.count != 0)
                {
                    foreach (var actionkeys in obj._eventTable)
                    {
                        if (actionkeys.key == subaction)
                        {
                            ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {obj.gameObject.name}");
                            return new UdonBehaviour_Cached(obj, actionkeys.key);
                        }
                    }
                }
            }
            return null;
        }

        internal static UdonBehaviour_Cached FindUdonEvent(GameObject obj, string subaction)
        {
            var actionObjects = obj.GetComponentsInChildren<UdonBehaviour>(true);

            for (int i = 0; i < actionObjects.Count; i++)
            {
                UdonBehaviour actionobject = actionObjects[i];
                if (actionobject != null)
                {
                    foreach (var actionkeys in actionobject._eventTable)
                    {
                        if (actionkeys.key == subaction)
                        {
                            ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {actionobject.gameObject.name}");
                            return new UdonBehaviour_Cached(actionobject, actionkeys.key);
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
                                                                    foreach (var id in ids)
                                                                    {
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
                                            case UdonTypes_String.System_String_Array:
                                                {
                                                    var list = UnboxVariable.Unpack_List_String();
                                                    if (list.Count() != 0)
                                                        foreach (var value in list)
                                                        {
                                                            {
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
                                                                            foreach (var id in ids)
                                                                            {
                                                                                if (id != null)
                                                                                {
                                                                                    result.Add(id);
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                }

                                                            }
                                                        }
                                                    break;
                                                }
                                            case UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal:
                                                {
                                                    var pedestral = UnboxVariable.Unpack_VRC_SDK3_Components_VRCAvatarPedestal();
                                                    if (pedestral != null)
                                                    {
                                                        if(!pedestral.grantBlueprintAccess)
                                                        {
                                                            pedestral.grantBlueprintAccess = true;
                                                        }
                                                        if (pedestral.blueprintId.IsNotNullOrEmptyOrWhiteSpace() && pedestral.blueprintId.IsAvatarID())
                                                        {
                                                            result.Add(pedestral.blueprintId);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal_Array:
                                                {
                                                    var list = UnboxVariable.Unpack_List_VRC_SDK3_Components_VRCAvatarPedestal();
                                                    if (list != null && list.Count != 0)
                                                    {

                                                        foreach (var pedestral in list)
                                                        {
                                                            if (pedestral != null)
                                                            {
                                                                if (!pedestral.grantBlueprintAccess)
                                                                {
                                                                    pedestral.grantBlueprintAccess = true;
                                                                }
                                                                if (pedestral.blueprintId.IsNotNullOrEmptyOrWhiteSpace() && pedestral.blueprintId.IsAvatarID())
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
