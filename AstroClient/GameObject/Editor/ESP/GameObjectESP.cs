using AstroClient.components;
using AstroClient.ConsoleUtils;
using AstroClient.Variables;
using RubyButtonAPI;
using System.Collections.Generic;
using UnityEngine;
using Exception = System.Exception;

namespace AstroClient
{
    public class GameObjectESP : GameEvents
    {
        public static void AddESPToTriggers()
        {
            var items = WorldUtils.GetAllWorldTriggers();
            try
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        if (WorldUtils.GetWorldID() == WorldIds.SnoozeScaryMaze5)
                        {
                            if (item.name == "The Doctor Watcher Activate")
                            {
                                ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                                continue;
                            }
                            if (item.name == "Teddy Watcher Activate")
                            {
                                ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                                continue;
                            }
                            if (item.name == "Kill Trigger For Maze Part 2")
                            {
                                ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                                continue;
                            }
                            if (item.name == "Kill Trigger For Maze")
                            {
                                ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name);
                                continue;
                            }
                            if (item.transform.parent != null && item.transform.parent.gameObject != null)
                            {
                                if (item.transform.parent.gameObject.name == "Do Something Easter Egg")
                                {
                                    if (item.name == "Area Trigger")
                                    {
                                        ModConsole.DebugWarning("Skipped ESP Trigger : " + item.name + " With parent : " + item.transform.parent.gameObject.name);
                                        continue;
                                    }
                                }
                            }

                            item.AddComponent<ObjectESP>();
                        }
                        else
                        {
                            item.AddComponent<ObjectESP>();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public static void RemoveESPToTriggers()
        {
            var items = WorldUtils.GetAllWorldTriggers();
            try
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        var ESP = item.GetComponent<ObjectESP>();
                        if (ESP != null)
                        {
                            UnityEngine.Object.Destroy(ESP);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public static void AddESPToMurderProps()
        {
            isMurderItemsESPActivated = true;
            try
            {
                foreach (var item in MurderESPItems)
                {
                    if (item != null)
                    {
                        item.AddComponent<ObjectESP>();
                    }
                }
            }
            catch (Exception) { }
        }

        public static void RemoveESPToMurderProps()
        {
            isMurderItemsESPActivated = false;
            try
            {
                foreach (var item in MurderESPItems)
                {
                    if (item != null)
                    {
                        var ESP = item.GetComponent<ObjectESP>();
                        if (ESP != null)
                        {
                            UnityEngine.Object.Destroy(ESP);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public static void RemoveESPToPickups()
        {
            var items = WorldUtils.GetAllWorldPickups();
            try
            {
                foreach (var item in items)
                {
                    var ESP = item.GetComponent<ObjectESP>();
                    if (ESP != null)
                    {
                        UnityEngine.Object.Destroy(ESP);
                    }
                }
            }
            catch (Exception) { }
        }

        public static void AddESPToPickups()
        {
            var items = WorldUtils.GetAllWorldPickups();
            try
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        item.AddComponent<ObjectESP>();
                    }
                }
            }
            catch (Exception) { }
        }

        public override void OnLevelLoaded()
        {
            if (TriggerESPToggler != null)
            {
                TriggerESPToggler.setToggleState(false);
            }
            if (Murder4ESPtoggler != null)
            {
                Murder4ESPtoggler.setToggleState(false);
            }
            if (Murder2ESPtoggler != null)
            {
                Murder2ESPtoggler.setToggleState(false);
            }
            TriggerESPItems.Clear();
            MurderESPItems.Clear();
        }

        public static bool isMurderItemsESPActivated = false;
        public static List<GameObject> TriggerESPItems = new List<GameObject>();
        public static List<GameObject> MurderESPItems = new List<GameObject>();

        public static QMToggleButton TriggerESPToggler;
        public static QMSingleToggleButton Murder2ESPtoggler;
        public static QMSingleToggleButton Murder4ESPtoggler;
    }
}