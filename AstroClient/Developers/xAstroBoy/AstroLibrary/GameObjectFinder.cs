﻿namespace AstroClient.xAstroBoy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Utility;

    public static class Finder
    {
        // Todo : Make it split the root, find it first, then use transform.find to get the rest, to bypass Gameobject.find being unable to find inactive childs
        public static GameObject Find(string path)
        {
            var obj = GameObject.Find(path);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                Log.Error($"[ERROR (Find) ]  Gameobject on path [ {path} ]  is Invalid, No Object Found!");
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
                    GameObject obj = Finder.RootSceneObjects[i];
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
                                    if (!results.Contains(component))
                                    {
                                        results.Add(component);
                                    }
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
                                if (!results.Contains(component))
                                {
                                    results.Add(component);
                                }
                            }
                        }
                    }
                }
                return results;
            }
            catch (Exception e)
            {
                Log.Error("Error parsing Components from Root Objects");
                Log.Exception(e);
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
            }
            Log.Warn($"[WARNING (FindRootSceneObject) ]  Root Gameobject name [ {name} ]  is Invalid, No Object Found!");
            return null;
        }


        public static GameObject FindObject(this GameObject gameobject, string path, bool DontWarn = false)
        {
            if (gameobject == null) return null;
            var obj = gameobject.transform.Find(path);
            if (obj == null)
            {
                if (!DontWarn)
                {
                    Log.Warn($"[WARNING (FindObject) ]  Transform {gameobject.name} Doesnt have a object in path [ {path} ] !");
                }
                return null;
            }

            return obj.gameObject;
        }


        public static Transform FindObject(this Transform transform, string path, bool DontWarn = false)
        {
            if (transform == null) return null;
            var obj = transform.Find(path);
            if (obj == null)
            {
                if (!DontWarn)
                {
                    Log.Warn($"[WARNING (FindObject) ]  Transform {transform.name} Doesnt have a object in path [ {path} ] !");
                }
                return null;
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
                Log.Warn($"[WARNING (ListFind) ] Gameobject on path [ {path} ]  is Invalid, No Object Found!");
                return list;
            }
        }

        /// <summary>
        /// fixed With knah's UIX Inactive finder.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Transform InactiveFind(string path)
        {
            Transform obj = UnityUtils.FindInactiveObjectInActiveRoot(path);

            if (obj == null)
            {
                Log.Warn($"[WARNING (InactiveFind) ]  Gameobject on path [ {path} ]  is Invalid, No Object Found!");
                return null;
            }
            return obj;
        }

    }
}