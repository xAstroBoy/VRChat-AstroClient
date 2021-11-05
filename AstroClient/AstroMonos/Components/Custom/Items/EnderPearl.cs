using UnhollowerBaseLib.Attributes;

namespace AstroClient
{
    using AstroClient.Components;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System;
    using UnityEngine;

    [RegisterComponent]
    public class EnderPearlBehaviour : AstroPickup
    {
        public EnderPearlBehaviour(IntPtr ptr)
            : base(ptr)
        {
        }

        internal void Start()
        {
            collider = gameObject.GetOrAddComponent<BoxCollider>();
            renderer = gameObject.GetOrAddComponent<MeshRenderer>();
            if (collider != null)
            {
                collider.size = new Vector3(1f, 1f, 1f);
                collider.isTrigger = true;
            }
            if (renderer != null)
            {
                renderer.material.color = Ender;
            }
            if (RigidBodyProperties != null)
            {
                RigidBodyProperties.Forced_Rigidbody = true;
                RigidBodyProperties.isKinematic = false;
                RigidBodyProperties.useGravity = false;
                RigidBodyProperties.drag = 0f;
                RigidBodyProperties.angularDrag = 0.01f;
            }
            if (PickupProperties != null)
            {
                PickupProperties.pickupable = true;
                PickupProperties.ThrowVelocityBoostScale = 5.5f;
            }
        }

        internal override void OnDrop()
        {
            Held = false;
        }

        internal override void OnPickup()
        {
            Held = true;
        }

        internal void Update()
        {
            Time += UnityEngine.Time.deltaTime;
            if (Time > 0.3f)
            {
                if (RigidBodyProperties.isKinematic)
                {
                    RigidBodyProperties.isKinematic = false;
                }
                if (!Held)
                {
                    RigidBodyProperties.useGravity = true;
                    collider.isTrigger = false;
                }
                Time = 0f;
            }
        }

        internal void OnDisable()
        {
            Held = false;
        }

        internal void OnEnable()
        {
            Held = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.name.Contains("VRCPlayer"))
            {
                return;
            }
            foreach (ContactPoint contact in collision.contacts)
            {
                if (Held)
                {
                    break;
                }
                else
                {
                    ModConsole.DebugLog(contact.point.ToString() + "Point To Teleport To");
                    Vector3 position = new Vector3(contact.point.x, contact.point.y, contact.point.z);
                    Utils.CurrentUser.gameObject.transform.position = position;
                    gameObject.DestroyMeLocal();
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            ModConsole.DebugLog("No longer in contact with " + other.transform.name);
        }

        private void OnDestroy()
        {
            Held = false;
        }

        internal BoxCollider collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal MeshRenderer renderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal static bool Held { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal static float Time { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private static Color Ender { [HideFromIl2Cpp] get; } = new Color(0f, 2f, 0f, 0.4f);
    }
}