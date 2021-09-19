namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.Udon;
    using static AstroClient.Variables.CustomLists;

    public static class UdonSearch
    {
        public static List<UdonBehaviour_Cached> FindAllUdonEvents(string action, string subaction)
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

        public static UdonBehaviour_Cached FindUdonEvent(string action, string subaction)
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

        public static UdonBehaviour_Cached FindUdonEvent(UdonBehaviour obj, string subaction)
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

        public static UdonBehaviour_Cached FindUdonEvent(GameObject obj, string subaction)
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
    }
}