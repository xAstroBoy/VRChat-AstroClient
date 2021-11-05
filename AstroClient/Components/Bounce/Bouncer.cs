namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;

    [RegisterComponent]
    public class Bouncer : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public Bouncer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = false;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[Bouncer Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            rb = GetComponent<Rigidbody>();
            initialVelocity = rb.velocity;
            PickupController = GetComponent<PickupController>();
            if (PickupController == null)
            {
                PickupController = gameObject.AddComponent<PickupController>();
            }
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += new Action(() => { isPaused = true; });
                VRC_AstroPickup.OnPickupUseDown += new Action(() => { IsEnabled = !IsEnabled; });
                VRC_AstroPickup.OnDrop += new Action(() => { isPaused = false; });

            }
            IsEnabled = true;
        }

        private void Update()
        {
            lastFrameVelocity = rb.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!IsEnabled || isPaused)
            {
                return;
            }
            _ = GameObjectUtils.TakeOwnershipIfNecessary(gameObject);
            if (!BounceTowardPlayer)
            {
                Bounce(collision.contacts[0].normal);
            }
            else
            {
                BounceToPlayer(collision.contacts[0].normal);
            }
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

        private void OnDestroy()
        {
            gameObject.KillForces(true);
            if (VRC_AstroPickup != null)
            {
                Destroy(VRC_AstroPickup);
            }
            PickupController.UseText = OriginalText_Use;
        }

        private Vector3 initialVelocity = new Vector3(0, 0, 0);
        private Vector3 lastFrameVelocity;
        private Rigidbody rb;
        private float minVelocity = 10f;

        // TODO : MAKE PLAYER BOUNCE  BACK SUPPORTED AS WELL
        private float bias = 0.5f;
        private float bounceVelocity = 10f;

        internal bool BounceTowardPlayer = false;
        private PickupController PickupController;
        private VRC_AstroPickup VRC_AstroPickup;
        private string OriginalText_Use;
        private bool isPaused;
        private bool _IsEnabled = true;
        internal bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                if (VRC_AstroPickup != null)
                {
                    if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        OriginalText_Use = PickupController.UseText;
                    }
                    if (value)
                    {
                        VRC_AstroPickup.UseText = "Toggle Bouncy Off";
                    }
                    else
                    {
                        VRC_AstroPickup.UseText = "Toggle Bouncy On";
                    }
                }
            }

        }
    }
}