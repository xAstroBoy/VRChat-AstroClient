namespace AstroClient
{
    using AstroLibrary.Extensions;
    using UnityEngine;

    internal static class SpawnedItemsHolder
    {
        private static GameObject _SpawnedItemsHolder;

        internal static GameObject GetSpawnedItemsHolder()
        {
            if (_SpawnedItemsHolder != null)
            {
                return _SpawnedItemsHolder;
            }
            else
            {
                var parent = new GameObject
                {
                    name = "Spawned GameObject Holder (AstroClient)",
                    active = true
                };
                return _SpawnedItemsHolder = parent;
            }
        }

        private static GameObject _DoNotDestroyHolder;

        internal static GameObject GetDoNotDestroySpawnedItemsHolder()
        {
            if (_DoNotDestroyHolder != null)
            {
                return _DoNotDestroyHolder;
            }
            else
            {
                var parent = new GameObject
                {
                    name = "Dont Destroy (Spawned GameObject Holder (AstroClient))",
                    active = true
                };
                parent.Set_DontDestroyOnLoad();
                return _DoNotDestroyHolder = parent;
            }
        }


    }
}