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
    public class SuperTowerDefense_TowerSkipCollider : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_TowerSkipCollider(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal VRC_AstroPickup CustomPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private bool isHeld { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private List<Collider> CurrentColliders { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new();
        private SuperTowerDefense_TowerPickupEditor CurrentTowerProperties { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private void Start()
        {

            if (CustomPickup == null) CustomPickup = gameObject.AddComponent<VRC_AstroPickup>();

            if (CustomPickup != null)
            {
                CustomPickup.OnPickup += OnPickup;
                CustomPickup.OnDrop += onDrop;
            }

            if (CurrentTowerProperties == null) CurrentTowerProperties = gameObject.GetOrAddComponent<SuperTowerDefense_TowerPickupEditor>();


            foreach (var collider in gameObject.GetComponentsInChildren<Collider>(true))
            {
                if (!CurrentColliders.Contains(collider))
                {
                    CurrentColliders.Add(collider);
                }
            }

        }


        private void OnPickup()
        {
            isHeld = true;
        }

        private void onDrop()
        {
            isHeld = false;
        }

        private void Update()
        {
            if (!isHeld) return;
            PatchTower();
        }

        private void PatchTower()
        {
            CurrentTowerProperties.__0_validPlacement_Boolean = true;
            CurrentTowerProperties.previouslyValidPlacement = true;
            CurrentTowerProperties.__0_intnl_returnValSymbol_Boolean = true;
            CurrentTowerProperties.__3_intnl_SystemBoolean = true;


            CurrentTowerProperties.__70_intnl_SystemBoolean = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!isHeld) return;
            if (other.collider.name.StartsWith("TowerMiniGun") && other.collider.name.EndsWith("(Clone)") ||
                other.collider.name.StartsWith("TowerRocketLauncher") && other.collider.name.EndsWith("(Clone)") ||
                other.collider.name.StartsWith("TowerSlow") && other.collider.name.EndsWith("(Clone)") ||
                other.collider.name.StartsWith("TowerLance") && other.collider.name.EndsWith("(Clone)") ||
                other.collider.name.StartsWith("TowerRadar") && other.collider.name.EndsWith("(Clone)") ||
                other.collider.name.StartsWith("TowerCannon") && other.collider.name.EndsWith("(Clone)"))
            {
                foreach (var collider in CurrentColliders)
                {
                    Physics.IgnoreCollision(collider, other.collider, true);
                }

                PatchTower();
            }
        }


        private void OnDestroy()
        {
            Destroy(CustomPickup);

        }
    }
}