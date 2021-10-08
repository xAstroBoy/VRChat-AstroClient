namespace AstroClient.Components
{
    using AstroClient.GameObjectDebug;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
    using VRC;
    using Time = UnityEngine.Time;

    [RegisterComponent]
    public class PlayerWatcher : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerWatcher(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        private void Start()
        {
            RigidBodyController = GetComponent<RigidBodyController>();
            if (RigidBodyController == null)
            {
                RigidBodyController = gameObject.AddComponent<RigidBodyController>();
            }
            body = RigidBodyController.Rigidbody;
            if (body == null)
            {
                body = GetComponent<Rigidbody>();
                if (body == null)
                {
                    body = gameObject.AddComponent<Rigidbody>();
                }
            }
            PickupController = GetComponent<PickupController>();
            if (PickupController == null)
            {
                PickupController = gameObject.AddComponent<PickupController>();
            }
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += new Action(() => { isPaused = true; });
                VRC_AstroPickup.OnDrop += new Action(() => { isPaused = false; });
            }
        }

        internal override void OnPlayerLeft(Player player)
        {
            if (TargetPlayer.Equals(player))
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            if (TargetPlayer == null) return;
            if (isPaused || isHeld)
            {
                if (HasRequiredSettings)
                {
                    HasRequiredSettings = false;
                }
                return;
            }
            if (!CheckisOwner)
            {
                if (Time.time - CheckisOwnerTimeCheck > CheckisOwnerDelay)
                {
                    CheckisOwner = true;
                    CheckisOwnerTimeCheck = Time.time;
                }
            }
            if (Time.time - WatcherTimeCheck > 0.005f)
            {
                if (!HasRequiredSettings)
                {
                    HasRequiredSettings = true;
                }
                if (isCurrentOwner)
                {
                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                }

                WatcherTimeCheck = Time.time;
            }
        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                if (gameObject.IsOwner())
                {
                    OnlineEditor.RemoveOwnerShip(gameObject);
                }
                if (VRC_AstroPickup != null)
                {
                    Destroy(VRC_AstroPickup);
                }
                if (!isHeld)
                {
                    GameObjectMenu.RestoreOriginalLocation(gameObject, false);
                }
            }
            catch { }
        }

        private float CheckisOwnerTimeCheck { get; set; } = 0;

        private float CheckisOwnerDelay { get; set; } = 16f;
        private bool CheckisOwner { get; set; } = false;

        private bool isCurrentOwner
        {
            get
            {
                if (CheckisOwner)
                {
                    if (!gameObject.IsOwner())
                    {
                        gameObject.TakeOwnership();
                    }
                    return gameObject.IsOwner();
                }
                else
                {
                    return true;
                }
            }
        }

        private bool isHeld => PickupController.IsHeld;

        private bool _HasRequiredSettings = false;

        private bool HasRequiredSettings
        {
            get => _HasRequiredSettings;
            set
            {
                if (value.Equals(_HasRequiredSettings))
                {
                    return; // Do Nothing.
                }
                _HasRequiredSettings = value;
                if (value)
                {
                    if (RigidBodyController != null)
                    {
                        if (!RigidBodyController.EditMode)
                        {
                            RigidBodyController.EditMode = true;
                        }
                        RigidBodyController.constraints = RigidbodyConstraints.FreezeRotation;
                        RigidBodyController.constraints = RigidbodyConstraints.None;
                    }
                }
                else
                {
                    RigidBodyController.RestoreOriginalBody();
                    RigidBodyController.EditMode = false;
                }
            }
        }

        private Rigidbody RigidBody { get; set; } = null;
        private RigidBodyController RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }
        private VRC_AstroPickup VRC_AstroPickup { get; set; }
        private float WatcherTimeCheck { get; set; } = 0;

        private float Movementforce { get; set; } = 0.04f; // DEFAULT 0.04f

        private bool isPaused { get; set; }
        private Rigidbody body { get; set; } = null;

        internal Player TargetPlayer { get; set; }
    }
}