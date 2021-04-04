﻿using AstroClient.ConsoleUtils;
using System.Linq;
using UnityEngine;
using VRC.Udon;
using static AstroClient.variables.CustomLists;

namespace AstroClient
{
    public static class UdonSearch
    {
        
        public static CachedUdonEvent FindUdonEvent(string action , string subaction)
        {
            var gameobjects = Resources.FindObjectsOfTypeAll<UdonBehaviour>();

            var behaviour = gameobjects.Where(x => x.gameObject.name == action).DefaultIfEmpty(null).First();
            if(behaviour != null)
            {
                ModConsole.DebugLog($"Found Behaviour {behaviour.gameObject.name}, Searching for Action.");
                foreach(var actionkeys in behaviour._eventTable)
                {
                    if(actionkeys.key == subaction)
                    {
                        ModConsole.DebugLog($"Found subaction {actionkeys.key} bound in {behaviour.gameObject.name}");
                        return new CachedUdonEvent(behaviour, actionkeys.key);
                    }
                }

            }

            return null;
        }

    }
}
