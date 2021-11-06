namespace AstroClient.Cloner
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using ItemTweakerV2.Selector;
    using ItemTweakerV2.Submenus;
    using UnityEngine;

    internal class ObjectCloner : GameEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            _holder = null;
            SpawnerSubmenu.ClonedObjects.Clear();
            SpawnerSubmenu.UpdateSpawnedPickupsBtn();
        }

        internal static void ClonedObjectsDeleter()
        {
            foreach (var obj in SpawnerSubmenu.ClonedObjects)
            {
                obj.RemoveObjFromCustomLists();
                Object.DestroyImmediate(obj);
            }
            SpawnerSubmenu.ClonedObjects.Clear();

            SpawnerSubmenu.UpdateSpawnedPickupsBtn();
        }

        private static GameObject _holder;

        private static GameObject GetClonedHolder()
        {
            if (_holder != null)
            {
                return _holder;
            }
            else
            {
                SpawnerSubmenu.ClonedObjects.Clear();
                SpawnerSubmenu.UpdateSpawnedPickupsBtn();
                var parent = new GameObject
                {
                    name = "Cloned GameObject Holder (AstroClient)",
                    active = true
                };
                return _holder = parent;
            }
        }

        internal static void CloneGameObject(GameObject GameObject)
        {
            ModConsole.DebugLog($"Found A Target GameObject  :{GameObject.name}");
            var obj = Object.Instantiate(GameObject);
            if (obj != null)
            {
                obj.transform.SetParent(GetClonedHolder().transform);
                if (!obj.active)
                {
                    obj.SetActive(true);
                }
                if (!SpawnerSubmenu.ClonedObjects.Contains(obj))
                {
                    SpawnerSubmenu.ClonedObjects.Add(obj);
                    SpawnerSubmenu.UpdateSpawnedPickupsBtn();
                }
                ModConsole.Log($"Spawned A Copy Successfully!, cloned {obj.name}");
                Tweaker_Object.SetObjectToEdit(obj);
            }
            else
            {
                ModConsole.Log("Failed to clone object, is null!");
            }
        }
    }
}