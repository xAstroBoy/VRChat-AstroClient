using AstroClient.components;
using AstroClient.ConsoleUtils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AstroClient.extensions
{
    public static class EspExtensions
    {
        public static List<ObjectESP> GetESPByID(this GameObject obj, string identifier)
        {

            //return obj.GetComponents<ObjectESP>().ToList().Where(x => x.ESPIdentifier == identifier).ToList();

            // TODO : REPLACE IT WITH LINQ
            List<ObjectESP> ESPs = new List<ObjectESP>();
            foreach (var comp in obj.GetComponents<ObjectESP>().ToList())
            {
                if (comp != null)
                {
                    ModConsole.DebugWarning($"Found ObjectESP bound to {comp.gameObject.name} having Identifier {comp.GetCurrentID()}");
                    if (comp.GetCurrentID() == identifier)
                    {
                        if (!ESPs.Contains(comp))
                        {
                            ESPs.Add(comp);
                        }
                    }
                }
            }
            return ESPs;
        }

        public static List<ObjectESP> GetESPByID(this List<GameObject> list, string identifier)
        {
            List<ObjectESP> ESPComp = new List<ObjectESP>();
            if (list != null)
            {
                foreach (var obj in list)
                {
                    var ESPList = GetESPByID(obj, identifier);
                    foreach (var item in ESPList)
                    {
                        if (!ESPComp.Contains(item))
                        {
                            ESPComp.Add(item);
                        }
                    }
                }
            }
            return ESPComp;
        }

        public static void DestroyESPByIdentifier(this List<GameObject> list, string identifier)
        {
            if (list != null)
            {
                foreach (var obj in list)
                {
                    DestroyESPByIdentifier(obj, identifier);
                }
            }
        }

        public static void DestroyESPByIdentifier(this GameObject obj, string identifier)
        {
            if (obj != null)
            {
                foreach (var item in GetESPByID(obj, identifier))
                {
                    UnityEngine.Object.Destroy(item);
                }
            }
        }

        // TODO : REMOVE THIS
        // MAKE GAMEOBJECTESP OBSOLETE AND NOT NEEDED ANYMORE AND IS GOING TO BE DELETED!
        public static void RegisterMurderItemEsp(this GameObject obj)
        {
            if (obj != null)
            {
                if (obj != null)
                {
                    if (!GameObjectESP.MurderESPItems.Contains(obj))
                    {
                        GameObjectESP.MurderESPItems.Add(obj);
                    }
                }
            }
        }

        public static void RegisterMurderItemEsp(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    if (!GameObjectESP.MurderESPItems.Contains(obj))
                    {
                        GameObjectESP.MurderESPItems.Add(obj);
                    }
                }
            }
        }
    }
}