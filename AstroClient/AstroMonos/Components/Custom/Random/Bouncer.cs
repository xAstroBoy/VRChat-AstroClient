namespace AstroClient.AstroMonos.Components.Custom.Random
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class Bouncer : AstroMonoBehaviour
    {
        private bool _IsEnabled = true;
        public List<AstroMonoBehaviour> AntiGcList;

        private bool DebugMode = false;

        public Bouncer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal Vector3 initialVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new(0, 0, 0);
        internal Vector3 lastFrameVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Rigidbody rb { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float minVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10f;
        
        //TODO : MAKE PLAYER BOUNCE  BACK SUPPORTED AS WELL
        internal float bias { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.5f;
        
        internal float bounceVelocity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10f;
        
        internal bool BounceTowardPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        internal PickupController PickupController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroPickup VRC_AstroPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal string OriginalText_Use { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal bool isPaused { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool IsEnabled
        {
            [HideFromIl2Cpp] get => _IsEnabled;
            [HideFromIl2Cpp]
            set
            {
                _IsEnabled = value;
                if (VRC_AstroPickup != null)
                {
                    if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace()) OriginalText_Use = PickupController.UseText;
                    if (value)
                        VRC_AstroPickup.UseText = "Toggle Bouncy Off";
                    else
                        VRC_AstroPickup.UseText = "Toggle Bouncy On";
                }
            }
        }

        // Use this for initialization
        internal void Start()
        {
            rb = GetComponent<Rigidbody>();
            initialVelocity = rb.velocity;
            PickupController = GetComponent<PickupController>();
            if (PickupController == null) PickupController = gameObject.AddComponent<PickupController>();
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += () => { isPaused = true; };
                VRC_AstroPickup.OnPickupUseDown += () => { IsEnabled = !IsEnabled; };
                VRC_AstroPickup.OnDrop += () => { isPaused = false; };
            }

            IsEnabled = true;
        }

        private void Update()
        {
            lastFrameVelocity = rb.velocity;
        }

        private void OnDestroy()
        {
            gameObject.KillForces();
            if (VRC_AstroPickup != null) Destroy(VRC_AstroPickup);
            PickupController.UseText = OriginalText_Use;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!IsEnabled || isPaused) return;
            _ = GameObjectUtils.TakeOwnershipIfNecessary(gameObject);
            if (!BounceTowardPlayer)
                Bounce(collision.contacts[0].normal);
            else
                BounceToPlayer(collision.contacts[0].normal);
        }

        private void Debug(string msg)
        {
            if (DebugMode) Log.Debug($"[Bouncer Debug] : {msg}");
        }

        private void Bounce(Vector3 collisionNormal)
        {
            var speed = lastFrameVelocity.magnitude;
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

            Debug("Out Direction: " + direction);
            rb.velocity = direction * Mathf.Max(speed, minVelocity);
        }

        private void BounceToPlayer(Vector3 collisionNormal)
        {
            var speed = lastFrameVelocity.magnitude;
            var bounceDirection = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
            var directionToPlayer = PlayerUtils.GetPlayer().GetVRCPlayer().transform.position - transform.position;

            var direction = Vector3.Lerp(bounceDirection, directionToPlayer, bias);

            Debug("Out Direction: " + direction);
            rb.velocity = direction * bounceVelocity;
        }
    }
}