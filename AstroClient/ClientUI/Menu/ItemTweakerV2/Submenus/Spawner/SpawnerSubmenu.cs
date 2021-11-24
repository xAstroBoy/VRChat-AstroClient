namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Spawner
{
    using System.Collections.Generic;
    using System.Linq;
    using ScrollMenus.Prefabs;
    using Selector;
    using Tools.Extensions;
    using Tools.ObjectEditor.Cloner;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class SpawnerSubmenu : Tweaker_Events
    {
        internal static void Init_SpawnerSubmenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedGridMenu(menu, x, y, "Spawner", "Spawner Menu!", null, null, null, null, btnHalf);
            _ = new QMSingleButton(main, "Spawn Clone", () => { ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }, "Instantiates a copy of The selected object.");
            _ = new QMSingleButton(main, "Kill Clones", () => { ObjectCloner.ClonedObjectsDeleter(); }, "Removes All Cloned Objects.");

            PrefabSpawnerScrollMenu.InitButtons(main);
            _ = new QMSingleButton(main, 1, 1.5f, "Kill Spawned Prefabs", () => { SpawnerSubmenu.KillSpawnedPrefabs(); }, "Removes All Prefabs Objects.", null, null, true);

            SpawnedPickupsCounter = new QMSingleButton(main, GetClonesPickupText, null, GetClonesPickupText);
            SpawnedPrefabsCounter = new QMSingleButton(main, GetSpawnedPrefabText, null, GetSpawnedPrefabText);
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            SpawnedPrefabs.Clear();
            ClonedObjects.Clear();
            UpdateSpawnedPrefabsBtn();
        }

        internal static string GetSpawnedPrefabText
        {
            get
            {
                return "Spawned Prefabs : " + SpawnedPrefabs.Count();
            }
        }

        internal static string GetClonesPickupText
        {
            get
            {
                return "Pickup Clones : " + ClonedObjects.Count();
            }
        }

        internal static void UpdateSpawnedPickupsBtn()
        {
            if (SpawnedPickupsCounter != null)
            {
                SpawnedPickupsCounter.SetButtonText(GetClonesPickupText);
                SpawnedPickupsCounter.SetToolTip(GetClonesPickupText);
            }
        }

        internal static void UpdateSpawnedPrefabsBtn()
        {
            if (SpawnedPrefabsCounter != null)
            {
                SpawnedPrefabsCounter.SetButtonText(GetSpawnedPrefabText);
                SpawnedPrefabsCounter.SetToolTip(GetSpawnedPrefabText);
            }
        }

        internal static void RegisterPrefab(GameObject obj)
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

        internal static void KillSpawnedPrefabs()
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

        internal static List<GameObject> SpawnedPrefabs = new List<GameObject>();
        internal static List<GameObject> ClonedObjects = new List<GameObject>();

        internal static QMSingleButton SpawnedPickupsCounter;
        internal static QMSingleButton SpawnedPrefabsCounter;
    }
}