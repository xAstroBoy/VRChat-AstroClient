namespace AstroClient
{
    using UnityEngine;

    public static class SpawnedItemsHolder
    {
        private static GameObject _SpawnedItemsHolder;

        public static GameObject GetSpawnedItemsHolder()
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