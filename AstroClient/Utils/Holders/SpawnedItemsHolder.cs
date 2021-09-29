namespace AstroClient
{
    using UnityEngine;

    internal static  class SpawnedItemsHolder
    {
        private static GameObject _SpawnedItemsHolder;

        internal static  GameObject GetSpawnedItemsHolder()
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
    }
}