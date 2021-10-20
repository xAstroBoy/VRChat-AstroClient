namespace AstroLibrary.Finder
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public static class GameObjectFinder
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
                ModConsole.DebugWarning($"[WARNING (Find) ]  Gameobject on path [ {path} ]  is Invalid, No Object Found!");
                return null;
            }
        }

        public static List<GameObject> RootSceneObjects => SceneManager.GetActiveScene().GetRootGameObjects().ToList();

        public static List<GameObject> RootSceneObjects_WithoutAvatars => SceneManager.GetActiveScene().GetRootGameObjects().Where(x => !x.gameObject.name.Contains("VRCPlayer")).ToList();

        public static List<T> GetRootGameObjectsComponents<T>(bool IncludeInactive = true, bool IncludeAvatarComponents = false) where T : Component
        {
            try
            {
                var results = new List<T>();
                for (int i = 0; i < RootSceneObjects.Count; i++)
                {
                    GameObject obj = GameObjectFinder.RootSceneObjects[i];
                    if (!IncludeAvatarComponents)
                    {
                        if (!obj.name.Contains("VRCPlayer"))
                        {
                            var objects = obj.GetComponentsInChildren<T>(IncludeInactive);
                            if (objects.Count != 0)
                            {
                                for (int i1 = 0; i1 < objects.Count; i1++)
                                {
                                    T component = objects[i1];
                                    results.Add(component);
                                }
                            }
                        }
                    }
                    else
                    {
                        var objects = obj.GetComponentsInChildren<T>(IncludeInactive);
                        if (objects.Count != 0)
                        {
                            for (int i1 = 0; i1 < objects.Count; i1++)
                            {
                                T component = objects[i1];
                                results.Add(component);
                            }
                        }
                    }
                }
                return results;

            }
            catch (Exception e)
            {
                ModConsole.Error("Error parsing Components from Root Objects");
                ModConsole.Exception(e);
                return null;
            }
            return null;
        }

        public static GameObject FindRootSceneObject(string name)
        {
            var list = SceneManager.GetActiveScene().GetRootGameObjects();

            for (int i = 0; i < list.Count; i++)
            {
                var obj = list[i];
                if (obj != null && obj.name.Equals(name))
                {
                    return obj;
                }
                else
                {
                    ModConsole.DebugWarning($"[WARNING (FindRootSceneObject) ]  Root Gameobject name [ {name} ]  is Invalid, No Object Found!");
                }
            }

            return null;
        }


        public static Transform FindObject(this Transform transform, string path)
        {
            Transform obj = transform.Find(path);

            if (obj == null)
            {
                ModConsole.DebugWarning($"[WARNING (FindObject) ]  Transform {transform.name} Doesnt have a object in path [ {path} ] !");
            }

            return obj;
        }

        public static List<GameObject> ListFind(string path)
        {
            List<GameObject> list = new List<GameObject>();

            var obj = GameObject.Find(path);
            if (obj != null)
            {
                UnhollowerBaseLib.Il2CppArrayBase<Transform> list1 = obj.GetComponentsInChildren<Transform>();
                for (int i = 0; i < list1.Count; i++)
                {
                    Transform item = list1[i];
                    list.AddGameObject(item.gameObject);
                }
                return list;
            }
            else
            {
                ModConsole.DebugWarning($"[WARNING (ListFind) ] Gameobject on path [ {path} ]  is Invalid, No Object Found!");
                return list;
            }
        }

        /// <summary>
        /// This is obsolete.
        /// Use root object finder, then find the object from there
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [Obsolete("Use root object finder, then find the object from there")]
        public static GameObject InactiveFind(string path)
        {
            UnhollowerBaseLib.Il2CppArrayBase<GameObject> list = Resources.FindObjectsOfTypeAll<GameObject>();
            for (int i = 0; i < list.Count; i++)
            {
                GameObject gameObj = list[i];
                if (GetGameObjectPath(gameObj).Equals(path))
                {
                    ModConsole.Log($"FOUND: {GetGameObjectPath(gameObj)}");
                    return gameObj;
                }
            }
            ModConsole.DebugWarning($"[WARNING (InactiveFind) ]  Gameobject on path [ {path} ]  is Invalid, No Object Found!");
            return null;
        }

        public static string GetGameObjectPath(GameObject obj)
        {
            string path = $"/{obj.name}";
            for (; obj.transform.parent != null;)
            {
                obj = obj.transform.parent.gameObject;
                path = $"/{obj.name}{path}";
            }
            return path;
        }
    }
}