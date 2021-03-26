using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using AstroClient.components;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using System.Reflection;
using RubyButtonAPI;
using UnityEngine.UI;
using DayClientML2.Utility.Extensions;
using AstroClient.AstroUtils.ItemTweaker;
using static AstroClient.Forces;
using VRC.SDK3.Components;
using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports


namespace AstroClient.extensions
{
    public static class ListExtensions
    {
        public static void RegisterChildsInPath(this List<GameObject> Original, string path)
        {
            var list = GameObjectFinder.ListFind(path);
            if (list != null)
            {
                if (list.Count() != 0)
                {
                    foreach (var obj in list)
                    {
                        Original.AddGameObject(obj);
                    }
                }
            }
        }


        public static void AddString(this List<string> list, string text)
        {
            if (list != null && !string.IsNullOrEmpty((text)))
            {
                if (!list.Contains(text))
                {
                    list.Add(text);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to add string " + text + " because " + nameof(list).ToString() + " is null.");
                    return;
                }
                if (string.IsNullOrEmpty((text)))
                {
                    return;
                }
            }
        }

        public static void RemoveString(this List<string> list, string text)
        {
            if (list != null && !string.IsNullOrEmpty((text)))
            {
                if (list.Contains(text))
                {
                    list.Remove(text);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to remove string " + text + " because " + nameof(list).ToString() + " is null.");
                    return;
                }
                if (string.IsNullOrEmpty((text)))
                {
                    return;
                }
            }
        }

        public static void AddGameObject(this List<GameObject> list, GameObject obj)
        {
            if (list != null && obj != null)
            {
                if (!list.Contains(obj))
                {
                    list.Add(obj);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to add gameobject " + obj.name + " because " + nameof(list).ToString() + " is null.");
                    return;
                }
                if (obj == null)
                {
                    return;
                }
            }
        }

        public static void RemoveGameobject(this List<GameObject> list, GameObject obj)
        {
            if (list != null && obj != null)
            {
                if (list.Contains(obj))
                {
                    list.Remove(obj);
                }
            }
            else
            {
                if (list == null)
                {
                    ModConsole.Log("Error, failed to remove gameobject " + obj.name + " because " + nameof(list).ToString() + " is null.");
                }
                if (obj == null)
                {
                    return;
                }
            }
        }

    }
}
