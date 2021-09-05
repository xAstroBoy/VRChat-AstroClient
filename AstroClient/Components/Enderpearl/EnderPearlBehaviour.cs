namespace AstroClient
{
    using System;
    using AstroClient.Components;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using UnityEngine;

    internal class EnderPearlBehaviour : MonoBehaviour
    {

        public EnderPearlBehaviour(IntPtr ptr)
            : base(ptr)
        {
        }

        public void Start()
        {
            pickup = gameObject.GetOrAddComponent<PickupController>();
            body = gameObject.GetOrAddComponent<RigidBodyController>();
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
            if (body != null)
            {
                body.EditMode = true;
                body.Forced_Rigidbody = true;
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
                pickup.ThrowVelocityBoostScale = 5.5f;
            }
        }

        public void Update()
        {
            Time += UnityEngine.Time.deltaTime;
            if (Time > 0.3f)
            {
                if (pickup.IsHeld)
                {
                    Held = true;
                }
                if (body.isKinematic)
                {
                    body.isKinematic = false;
                }
                if (Held)
                {
                    body.useGravity = true;
                    collider.isTrigger = false;
                }
                Time = 0f;
            }
        }

        public void OnDisable()
        {
            Held = false;
        }

        public void OnEnable()
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
                    MelonLogger.Msg(contact.point.ToString() + "Point To Tp To");
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


        internal PickupController pickup { get; private set; }
        internal RigidBodyController body { get; private set; }
        internal BoxCollider collider { get; private set; }
        internal MeshRenderer renderer { get; private set; }
        internal static bool Held { get; private set; }
        internal static float Time { get; private set; }
        private static Color Ender { get; } = new Color(0f, 2f, 0f, 0.4f);

    }
}
