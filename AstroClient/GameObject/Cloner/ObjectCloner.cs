namespace AstroClient.Cloner
{
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using UnityEngine;

	public class ObjectCloner : GameEvents
    {
        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            _Holder = null;
            SpawnerSubmenu.ClonedObjects.Clear();
            SpawnerSubmenu.UpdateSpawnedPickupsBtn();
        }

        public static void ClonedObjectsDeleter()
        {
            foreach (var obj in SpawnerSubmenu.ClonedObjects)
            {
                obj.RemoveObjFromCustomLists();
                Object.DestroyImmediate(obj);
            }
            SpawnerSubmenu.ClonedObjects.Clear();

            SpawnerSubmenu.UpdateSpawnedPickupsBtn();
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
                SpawnerSubmenu.ClonedObjects.Clear();
                SpawnerSubmenu.UpdateSpawnedPickupsBtn();
                var parent = new GameObject();
                parent.name = "Cloned GameObject Holder (AstroClient)";
                parent.active = true;
                return _Holder = parent;
            }
        }

        public static void CloneGameObject(GameObject GameObject)
        {
            ModConsole.DebugLog("Found A Target GameObject  :" + GameObject.name);
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
                ModConsole.Log("Spawned A Copy Successfully!, cloned " + obj.name);
                Tweaker_Object.SetObjectToEdit(obj);
            }
            else
            {
                ModConsole.Log("Failed to clone object, is null!");
            }
        }
    }
}