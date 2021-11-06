namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroUdons;
    using CustomMono;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class EnderPearlBehaviour : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public EnderPearlBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

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

                if (renderer != null)
                {
                    renderer.material.color = Ender;
                }

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
                    if (!pickup.RigidBodyController.EditMode)
                    {
                        pickup.RigidBodyController.EditMode = true;
                    }

                    if (!pickup.RigidBodyController.Forced_Rigidbody)
                    {
                        pickup.RigidBodyController.Forced_Rigidbody = true;
                    }

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


        private void OnDrop()
        {
            Held = false;
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

        private void OnCollisionEnter(Collision collision)
        {
            if (Held) return;
            if (collision.transform.name.Contains("VRCPlayer"))
            {
                return;
            }
            foreach (ContactPoint contact in collision.contacts)
            {
                ModConsole.DebugLog(contact.point.ToString() + "Point To Teleport To");
                Vector3 position = new Vector3(contact.point.x, contact.point.y, contact.point.z);
                Utils.CurrentUser.gameObject.transform.position = position;
                gameObject.DestroyMeLocal();
                break;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            ModConsole.DebugLog("No longer in contact with " + other.transform.name);
        }


        internal PickupController pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal VRC_AstroPickup PickupEvents { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal Rigidbody body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal BoxCollider collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal MeshRenderer renderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal static bool Held { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private static Color Ender { [HideFromIl2Cpp] get; } = new Color(0f, 2f, 0f, 0.4f);
    }
}