namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus.ScrollMenus;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class SpawnerSubmenu : Tweaker_Events
    {
        public static void Init_SpawnerSubmenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "Spawner", "Spawner Menu!", null, null, null, null, btnHalf);
            new QMSingleButton(main, 1, 0, "Spawn Clone", () => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }, "Instantiates a copy of The selected object.", null, null, true);
            new QMSingleButton(main, 1, 0.5f, "Kill Clones", () => { Cloner.ObjectCloner.ClonedObjectsDeleter(); }, "Removes All Cloned Objects.", null, null, true);

            PrefabSpawnerScrollMenu.Init_PrefabSpawnerQMScroll(main, 1, 1f, true);
            new QMSingleButton(main, 1, 1.5f, "Kill Spawned Prefabs", () => { SpawnerSubmenu.KillSpawnedPrefabs(); }, "Removes All Prefabs Objects.", null, null, true);

            SpawnedPickupsCounter = new QMSingleButton(main, 4, 0, GetClonesPickupText, null, GetClonesPickupText, null, Color.cyan, true);
            SpawnedPrefabsCounter = new QMSingleButton(main, 4, 0.5f, GetSpawnedPrefabText, null, GetSpawnedPrefabText, null, Color.cyan, true);
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            SpawnedPrefabs.Clear();
            ClonedObjects.Clear();
            UpdateSpawnedPrefabsBtn();
        }

        public static string GetSpawnedPrefabText
        {
            get
            {
                return "Spawned Prefabs : " + SpawnedPrefabs.Count();
            }
        }

        public static string GetClonesPickupText
        {
            get
            {
                return "Pickup Clones : " + ClonedObjects.Count();
            }
        }

        public static void UpdateSpawnedPickupsBtn()
        {
            if (SpawnedPickupsCounter != null)
            {
                SpawnedPickupsCounter.SetButtonText(GetClonesPickupText);
                SpawnedPickupsCounter.SetToolTip(GetClonesPickupText);
            }
        }

        public static void UpdateSpawnedPrefabsBtn()
        {
            if (SpawnedPrefabsCounter != null)
            {
                SpawnedPrefabsCounter.SetButtonText(GetSpawnedPrefabText);
                SpawnedPrefabsCounter.SetToolTip(GetSpawnedPrefabText);
            }
        }

        public static void RegisterPrefab(GameObject obj)
        {
            if (obj != null)
            {
                if (!SpawnedPrefabs.Contains(obj))
                {
                    SpawnedPrefabs.Add(obj);
                }
                UpdateSpawnedPrefabsBtn();
            }
        }

        public static void KillSpawnedPrefabs()
        {
            foreach (var prefab in SpawnedPrefabs)
            {
                if (prefab != null)
                {
                    if (!prefab.DestroyMeOnline())
                    {
                        prefab.DestroyMeLocal();
                    }
                }
            }
            SpawnedPrefabs.Clear();
            UpdateSpawnedPrefabsBtn();
        }

        public static List<GameObject> SpawnedPrefabs = new List<GameObject>();
        public static List<GameObject> ClonedObjects = new List<GameObject>();

        public static QMSingleButton SpawnedPickupsCounter;
        public static QMSingleButton SpawnedPrefabsCounter;
    }
}