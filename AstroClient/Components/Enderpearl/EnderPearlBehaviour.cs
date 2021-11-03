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
    public class EnderPearlBehaviour : MonoBehaviour
    {
        public EnderPearlBehaviour(IntPtr ptr)
            : base(ptr)
        {
        }

        internal void Start()
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

        internal void Update()
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

        internal PickupController pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal RigidBodyController body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal BoxCollider collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal MeshRenderer renderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal static bool Held { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal static float Time { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private static Color Ender { [HideFromIl2Cpp] get; } = new Color(0f, 2f, 0f, 0.4f);
    }
}