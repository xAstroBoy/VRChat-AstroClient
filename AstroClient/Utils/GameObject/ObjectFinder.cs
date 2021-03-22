using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using System.Collections.Generic;
using UnityEngine;

namespace AstroClient.Finder
{
    public class GameObjectFinder
    {
        public static GameObject Find(string path)
        {
            var obj = GameObject.Find(path);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                ModConsole.Warning("[WARNING (Find) ]  Gameobject on path [ " + path + " ]  is Invalid, No Object Found!");
                return null;
            }
        }

        public static List<GameObject> ListFind(string path)
        {
            List<GameObject> list = new List<GameObject>();

            var obj = GameObject.Find(path);
            if (obj != null)
            {
                foreach (var item in obj.GetComponentsInChildren<Transform>())
                {
                    list.AddGameObject(item.gameObject);
                }
                return list;
            }
            else
            {
                ModConsole.Warning("[WARNING (ListFind) ] Gameobject on path [ " + path + " ]  is Invalid, No Object Found!");
                return list;
            }
        }
    }
}