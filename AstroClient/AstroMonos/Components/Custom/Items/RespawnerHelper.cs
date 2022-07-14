namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using AstroClient.AstroMonos.AstroUdons;
    using AstroClient.AstroMonos.Components.Tools;
    using AstroClient.ClientResources.Loaders;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using System;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class RespawnerHelper : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public RespawnerHelper(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal PickupController pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal VRC_AstroPickup PickupEvents { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal Rigidbody body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal BoxCollider collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal MeshRenderer renderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal bool Held { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } = true;

        private bool _Activated { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool Activated
        {
            [HideFromIl2Cpp]
            get
            {
                return _Activated;
            }
            [HideFromIl2Cpp]
            set
            {
                _Activated = value;
                if (value)
                {
                    if (renderer != null) renderer.material = Materials.waffle;
                }
                else
                {
                    if (renderer != null) renderer.material = Materials.chocolate;
                }
            }
        }

        //private static Color Ender { [HideFromIl2Cpp] get; } = new(0f, 2f, 0f, 0.4f);

        private void Start()
        {
            try
            {
                body = gameObject.GetOrAddComponent<Rigidbody>();
                pickup = gameObject.GetOrAddComponent<PickupController>();
                renderer = gameObject.GetOrAddComponent<MeshRenderer>();
                PickupEvents = gameObject.AddComponent<VRC_AstroPickup>();
                gameObject.IgnoreLocalPlayerCollision();
                if (renderer != null) renderer.material = Materials.chocolate;

                if (body != null)
                {
                    body.isKinematic = false;
                    body.useGravity = false;
                }

                if (pickup != null)
                {
                    pickup.EditMode = true;
                    pickup.ForceComponent = true;
                    pickup.pickupable = true;
                }

                if (pickup != null && pickup.RigidBodyController != null)
                {
                    if (!pickup.RigidBodyController.EditMode) pickup.RigidBodyController.EditMode = true;

                    if (!pickup.RigidBodyController.Forced_Rigidbody) pickup.RigidBodyController.Forced_Rigidbody = true;

                    pickup.RigidBodyController.Override_UseGravity(false);
                    pickup.RigidBodyController.Override_isKinematic(false);
                }

                if (PickupEvents != null)
                {
                    PickupEvents.ForcePickupComponent = true;
                    PickupEvents.OnDrop += OnDrop;
                    PickupEvents.OnPickup += OnPickup;
                    PickupEvents.OnPickupUseDown += OnPickupUseDown;
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
        }

        private void Update()
        {
            // Animates main texture scale in a funky way!
            float scaleX = Mathf.Cos(Time.time) * 0.5f + 1;
            float scaleY = Mathf.Sin(Time.time) * 0.5f + 1;
            renderer.material.SetTextureScale("_MainTex", new Vector2(scaleX, scaleY));
        }
        private void OnCollisionEnter(Collision collision)
        {
            OnColliderHit(collision.collider, false);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnColliderHit(other, true);
        }

        private void OnColliderHit(Collider collision, bool isTriggerHit)
        {
            if (!Activated) return;
            if (collision == null) return;
            if (collision.transform.name.Contains("VRCPlayer")) return;
            if (collision.transform.root.name.Contains("VRCPlayer")) return;
            if (isTriggerHit)
            {
                // verify if a renderer is present, anything with a renderer can be selected if is a trigger.
                if (!collider.gameObject.HasComponent<Renderer>())
                {
                    return;
                }

            }
            var Respawner = collision.gameObject.GetGetInChildrens_OrParent<Respawner>();
            if (Respawner == null) return;
            Respawner.Respawn();
        }

        private void OnColliderHit(Collider collision)
        {
            if (!Activated) return;
            if (collision.transform.name.Contains("VRCPlayer")) return;
            if (collision.transform.root.name.Contains("VRCPlayer")) return;
            var Respawner = collision.gameObject.GetGetInChildrens_OrParent<Respawner>();
            if (Respawner == null) return;
            Respawner.Respawn();
        }

        private void OnDrop()
        {
            Held = false;
        }

        private void OnPickup()
        {
            Held = true;
        }

        private void OnPickupUseDown()
        {
            if (Held)
            {
                Activated = !Activated;
            }
        }
    }
}