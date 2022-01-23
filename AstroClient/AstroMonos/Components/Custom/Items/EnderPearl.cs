namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
    using ClientResources.Loaders;
    using Il2CppSystem.Collections.Generic;
    using Spawnables.Enderpearl;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class EnderPearlBehaviour : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        public EnderPearlBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal PickupController pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal VRC_AstroPickup PickupEvents { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal Rigidbody body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal BoxCollider collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal MeshRenderer renderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal static bool Held { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } = true;
        //private static Color Ender { [HideFromIl2Cpp] get; } = new(0f, 2f, 0f, 0.4f);

        private void Start()
        {
            try
            {
                body = gameObject.GetOrAddComponent<Rigidbody>();
                pickup = gameObject.GetOrAddComponent<PickupController>();
                collider = gameObject.GetOrAddComponent<BoxCollider>();
                renderer = gameObject.GetOrAddComponent<MeshRenderer>();
                PickupEvents = gameObject.AddComponent<VRC_AstroPickup>();
                if (collider != null)
                {
                    collider.size = new Vector3(1f, 1f, 1f);
                    collider.isTrigger = true;
                }
                this.gameObject.IgnoreLocalPlayerCollision();
                if (renderer != null) renderer.material = SelectedMat;

                if (body != null)
                {
                    body.isKinematic = true;
                    body.useGravity = false;
                    body.drag = 0f;
                    body.angularDrag = 0.01f;
                }

                if (pickup != null)
                {
                    pickup.EditMode = true;
                    pickup.ForceComponent = true;
                    pickup.pickupable = true;
                    pickup.ThrowVelocityBoostScale = 5.5f;
                }

                if (pickup.RigidBodyController != null)
                {
                    if (!pickup.RigidBodyController.EditMode) pickup.RigidBodyController.EditMode = true;

                    if (!pickup.RigidBodyController.Forced_Rigidbody) pickup.RigidBodyController.Forced_Rigidbody = true;

                    pickup.RigidBodyController.isKinematic = true;
                    pickup.RigidBodyController.useGravity = false;
                    pickup.RigidBodyController.drag = 0f;
                    pickup.RigidBodyController.angularDrag = 0.01f;
                }

                if (PickupEvents != null)
                {
                    PickupEvents.OnDrop += OnDrop;
                    PickupEvents.OnPickup += OnPickup;
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (Held) return;
            if (collision.transform.name.Contains("VRCPlayer")) return;
            foreach (var contact in collision.contacts)
            {
                ModConsole.DebugLog(contact.point.ToString() + "Point To Teleport To");
                var position = new Vector3(contact.point.x, contact.point.y, contact.point.z);
                GameInstances.CurrentUser.gameObject.transform.position = position;
                gameObject.DestroyMeLocal();
                break;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            ModConsole.DebugLog("No longer in contact with " + other.transform.name);
        }

        private void OnDrop()
        {
            Held = false;
        }

        private Material SelectedMat
        {
            get
            {
                if (AstroEnderPearl.isStrawberryMatOn)
                {
                    return Materials.strawberry;
                }
                if (AstroEnderPearl.isStrawberryMilshakeFoamMatOn)
                {
                    return Materials.strawberry_milshake_foam;
                }
                if (AstroEnderPearl.isCoralMatOn)
                {
                    return Materials.coral_001;
                }

                if (AstroEnderPearl.isChocolateMatOn)
                {
                    return Materials.chocolate;
                }

                if (AstroEnderPearl.isCrystalMatOn)
                {
                    return Materials.crystal_003;
                }

                if (AstroEnderPearl.isCoffeeMatOn)
                {
                    return Materials.coffee_grains_001;
                }

                if (AstroEnderPearl.UnusedBool)
                {
                    return Materials.crystal_003;
                }

                return Materials.crystal_003;
            }
        }
        private void OnPickup()
        {
            if (pickup.RigidBodyController != null)
            {
                pickup.RigidBodyController.isKinematic = false;
                pickup.RigidBodyController.useGravity = true;
            }

            body.isKinematic = false;
            body.useGravity = true;
            collider.isTrigger = false;
            Held = true;
        }
    }
}