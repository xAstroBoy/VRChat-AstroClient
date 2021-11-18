﻿namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Spawner
{
    using System.Collections.Generic;
    using System.Linq;
    using ScrollMenus.Prefabs;
    using Selector;
    using Tools.Extensions;
    using Tools.ObjectEditor.Cloner;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;

    internal class SpawnerSubmenu : Tweaker_Events
    {
        internal static void Init_SpawnerSubmenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var main = new QMNestedButton(menu, x, y, "Spawner", "Spawner Menu!", null, null, null, null, btnHalf);
            _ = new QMSingleButton(main, 1, 0, "Spawn Clone", () => { ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }, "Instantiates a copy of The selected object.", null, null, true);
            _ = new QMSingleButton(main, 1, 0.5f, "Kill Clones", () => { ObjectCloner.ClonedObjectsDeleter(); }, "Removes All Cloned Objects.", null, null, true);

            PrefabSpawnerScrollMenu.InitButtons(main, 1, 1f, true);
            _ = new QMSingleButton(main, 1, 1.5f, "Kill Spawned Prefabs", () => { SpawnerSubmenu.KillSpawnedPrefabs(); }, "Removes All Prefabs Objects.", null, null, true);

            SpawnedPickupsCounter = new QMSingleButton(main, 4, 0, GetClonesPickupText, null, GetClonesPickupText, null, Color.cyan, true);
            SpawnedPrefabsCounter = new QMSingleButton(main, 4, 0.5f, GetSpawnedPrefabText, null, GetSpawnedPrefabText, null, Color.cyan, true);
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