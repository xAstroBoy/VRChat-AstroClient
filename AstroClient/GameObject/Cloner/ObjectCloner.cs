using UnityEngine;

#region AstroClient Imports

using static AstroClient.variables.GlobalLists;
using AstroClient.ConsoleUtils;
using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.extensions;
using AstroClient.ItemTweaker;

#endregion AstroClient Imports

namespace AstroClient.Cloner
{
    public class ObjectCloner : Overridables
    {
        public override void OnLevelLoaded()
        {
            _Holder = null;
            ClonedObjects.Clear();
            ItemTweakerMain.UpdateSpawnedPickupsBtn();
        }

        public static void ClonedObjectsDeleter()
        {
            foreach (var obj in ClonedObjects)
            {
                obj.RemoveObjFromCustomLists();
                UnityEngine.Object.DestroyImmediate(obj);
            }
            ClonedObjects.Clear();

            ItemTweakerMain.UpdateSpawnedPickupsBtn();
        }

        private static GameObject _Holder;

        private static GameObject GetClonedHolder()
        {
            if (_Holder != null)
            {
                return _Holder;
            }
            else
            {
                ClonedObjects.Clear();
                ItemTweakerMain.UpdateSpawnedPickupsBtn();
                var parent = new GameObject();
                parent.name = "Cloned GameObject Holder (AstroClient)";
                parent.active = true;
                return _Holder = parent;
            }
        }

        public static void CloneGameObject(GameObject GameObject)
        {
            ModConsole.DebugLog("Found A Target GameObject  :" + GameObject.name);
            var obj = NetworkManager.Instantiate(GameObject);
            if (obj != null)
            {
                obj.transform.SetParent(GetClonedHolder().transform);
                if (!obj.active)
                {
                    obj.SetActive(true);
                }
                if (!ClonedObjects.Contains(obj))
                {
                    ClonedObjects.Add(obj);
                    ItemTweakerMain.UpdateSpawnedPickupsBtn();
                }
                ModConsole.Log("Spawned A Copy Successfully!, cloned " + obj.name);
                Tweaker_Object.SetObjectToEdit(obj.transform);
            }
            else
            {
                ModConsole.Log("Failed to clone object, is null!");
            }
        }
    }
}