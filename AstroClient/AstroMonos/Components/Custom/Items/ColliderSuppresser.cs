namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
    using ClientResources.Loaders;
    using Il2CppSystem.Collections.Generic;
    using Spawnables.ColliderSuppresserCube;
    using Spawnables.Enderpearl;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class ColliderSuppresserBehaviour : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public ColliderSuppresserBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal PickupController pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal VRC_AstroPickup PickupEvents { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal Rigidbody body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal BoxCollider collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal MeshRenderer renderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal bool Held { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } = true;
        internal bool IncludeTriggers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

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
                    if (renderer != null) renderer.material = Materials.strawberry_milshake_foam;
                }
                else
                {
                    if (renderer != null) renderer.material = Materials.strawberry;
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
                this.gameObject.IgnoreLocalPlayerCollision();
                if (renderer != null) renderer.material = Materials.strawberry;

                if (body != null)
                {
                    body.isKinematic = false;
                    body.useGravity = false;
                    body.drag = 0f;
                    body.angularDrag = 0.01f;
                }

                if (pickup != null)
                {
                    pickup.EditMode = true;
                    pickup.ForceComponent = true;
                    pickup.pickupable = true;
                }

                if (pickup.RigidBodyController != null)
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
            if (!Activated) return;
            if (collision == null) return;
            if (collision.transform.name.Contains("VRCPlayer")) return;
            if (collision.transform.root.name.Contains("VRCPlayer")) return;
            if (collision.collider == null) return;
            if (!ColliderSuppresserSphere.DeactivateCollision(collision.transform)) return;
            Log.Debug($"Deactivated Collider {collision.transform.gameObject.name} from blocking Player collision!");
            PopupUtils.QueHudMessage($"<color=#FFA500>Deactivated Collider {collision.transform.gameObject.name}</color>");
            Activated = false;
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