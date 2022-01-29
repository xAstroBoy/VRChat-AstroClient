namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using System.Collections.Generic;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using AstroUdons;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;
    using NotImplementedException = System.NotImplementedException;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class SuperTowerDefense_TowerCollisionFixer : AstroMonoBehaviour
    {
        private Il2CppSystem.Collections.Generic.List<Object> AntiGarbageCollection = new();

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

        private List<string> CollidersNamesToIgnore { get; } = new List<string> { "InterTowerCollider" };

        private void OnCollisionEnter(Collision other)
        {
            //ModConsole.DebugLog($"Detected A collision between {this.gameObject.name} and {other.collider.gameObject.name} with collider name  {other.collider.name}");
            if (CollidersNamesToIgnore.Contains(other.collider.name))
            {
                foreach (var collider in CurrentColliders)
                {
                    Physics.IgnoreCollision(collider, other.collider, true);
                }
            }
        }

    }
}