using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Spawner;
using AstroClient.xAstroBoy.Utility;
using HarmonyLib;

namespace AstroClient.Tools.ObjectEditor.Cloner
{
    using Extensions;
    using UnityEngine;

    internal class ObjectCloner : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnRoomLeft()
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
            Log.Debug($"Found A Target GameObject  :{GameObject.name}");
            var obj = GameObject.InstantiateObject();
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
                    var listener = obj.GetOrAddComponent<GameObjectListener>();
                    if (listener != null)
                    {
                        listener.OnDestroyed += () =>
                        {
                            if (SpawnerSubmenu.ClonedObjects.Contains(obj))
                            {
                                SpawnerSubmenu.ClonedObjects.Remove(obj);
                            }
                            SpawnerSubmenu.UpdateSpawnedPickupsBtn();
                        };
                    }

                    SpawnerSubmenu.UpdateSpawnedPickupsBtn();
                }
                Log.Write($"Spawned A Copy Successfully!, cloned {obj.name}");
                Tweaker_Object.SetObjectToEdit(obj);
            }
            else
            {
                Log.Write("Failed to clone object, is null!");
            }
        }
    }
}