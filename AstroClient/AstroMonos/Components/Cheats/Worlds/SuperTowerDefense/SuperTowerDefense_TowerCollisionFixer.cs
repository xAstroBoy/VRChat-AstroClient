using AstroClient.ClientActions;

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
    public class SuperTowerDefense_TowerCollisionFixer : MonoBehaviour
    {
        private Il2CppSystem.Collections.Generic.List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_TowerCollisionFixer(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        void OnDestroy()
        {
            HasSubscribed = false;
        }

        private void OnRoomLeft()
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
            HasSubscribed = true;
        }

        private List<string> CollidersNamesToIgnore { get; } = new List<string> { "InterTowerCollider" };

        private void OnCollisionEnter(Collision other)
        {
            //Log.Debug($"Detected A collision between {this.gameObject.name} and {other.collider.gameObject.name} with collider name  {other.collider.name}");
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