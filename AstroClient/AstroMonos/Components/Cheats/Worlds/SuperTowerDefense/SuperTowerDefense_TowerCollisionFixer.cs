namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using WorldModifications.Modifications;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;
    using NotImplementedException = System.NotImplementedException;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class SuperTowerDefense_TowerCollisionFixer : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_TowerCollisionFixer(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private List<Collider> CurrentColliders { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new();

        private void Start()
        {

            foreach (var collider in gameObject.GetComponentsInChildren<Collider>(true))
            {
                if (!CurrentColliders.Contains(collider))
                {
                    CurrentColliders.Add(collider);
                }
            }

            foreach (var collider in gameObject.GetComponentsInParent<Collider>(true))
            {
                if (!CurrentColliders.Contains(collider))
                {
                    CurrentColliders.Add(collider);
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.name.StartsWith("TowerMiniGun") && other.collider.name.EndsWith("Grabbable (0)") ||
                other.collider.name.StartsWith("TowerRocketLauncher") && other.collider.name.EndsWith("Grabbable (0)") ||
                other.collider.name.StartsWith("TowerSlow") && other.collider.name.EndsWith("Grabbable (0)") ||
                other.collider.name.StartsWith("TowerLance") && other.collider.name.EndsWith("Grabbable (0)") ||
                other.collider.name.StartsWith("TowerRadar") && other.collider.name.EndsWith("Grabbable (0)") ||
                other.collider.name.StartsWith("TowerCannon") && other.collider.name.EndsWith("Grabbable (0)") ||

                other.collider.name.StartsWith("TowerMiniGun") && other.collider.name.EndsWith("Grabbable (1)") ||
                other.collider.name.StartsWith("TowerRocketLauncher") && other.collider.name.EndsWith("Grabbable (1)") ||
                other.collider.name.StartsWith("TowerSlow") && other.collider.name.EndsWith("Grabbable (1)") ||
                other.collider.name.StartsWith("TowerLance") && other.collider.name.EndsWith("Grabbable (1)") ||
                other.collider.name.StartsWith("TowerRadar") && other.collider.name.EndsWith("Grabbable (1)") ||
                other.collider.name.StartsWith("TowerCannon") && other.collider.name.EndsWith("Grabbable (1)"))
            {
                foreach (var collider in CurrentColliders)
                {
                    Physics.IgnoreCollision(collider, other.collider, true);
                }
            }
        }

    }
}