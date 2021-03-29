using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public static GameObject InactiveFind(string name)
        {
            foreach (GameObject gameObj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                //ModConsole.DebugLog($"SPAM: {GetGameObjectPath(gameObj)}");
                if (GetGameObjectPath(gameObj).Equals(name))
                {
                    return gameObj;
                }
            }
            return null;
        }

        public static string GetGameObjectPath(GameObject obj)
        {
            string path = "/" + obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                path = "/" + obj.name + path;
            }
            return path;
        }

        /**
        public static GameObject InactiveFind(string search)
        {
            GameObject result = null;
            foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (root.name.Equals(search)) return root;

                result = FindRecursive(root, search);

                if (result) break;
            }

            return result;
        }

        private static GameObject FindRecursive(GameObject obj, string search)
        {
            GameObject result = null;
            foreach (Transform child in obj.transform)
            {
                if (child.name.Equals(search)) {
                    return child.gameObject;
                }

                result = FindRecursive(child.gameObject, search);

                if (result) break;
            }

            return result;
        }
        **/
    }
}