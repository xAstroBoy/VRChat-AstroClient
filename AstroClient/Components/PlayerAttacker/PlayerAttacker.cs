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
    public class PlayerAttacker : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerAttacker(IntPtr obj0) : base(obj0)
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
            //if (Time.time - AttackerTimeCheck > 0.6f)
            //{
                if (!HasRequiredSettings)
                {
                    HasRequiredSettings = true;
                }
                if (isCurrentOwner)
                {
                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                    ApplyForceX();
                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                    ApplyForceY();
                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                    ApplyForceZ();
                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                }

                //AttackerTimeCheck = Time.time;
            //}
        }

        private void ApplyForceX()
        {
            if (body != null && TargetPlayer.transform != null)
            {
                if (body.transform.position.x <= BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.x)
                {
                    body.AddForce(Movementforce, 0, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.x >= BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.x)
                {
                    body.AddForce(-Movementforce, 0, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.x == BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.x)
                {
                    return;
                }
            }
        }

        private void ApplyForceY()
        {
            if (body != null && TargetPlayer.transform != null)
            {
                if (gameObject.transform.position.y <= BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.y)
                {
                    body.AddForce(0, Movementforce, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.y >= BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.y)
                {
                    body.AddForce(0, -Movementforce, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.y == BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.y)
                {
                    return;
                }
            }
        }

        private void ApplyForceZ()
        {
            if (body != null && TargetPlayer.transform != null)
            {
                if (gameObject.transform.position.z <= BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.z)
                {
                    body.AddForce(0, 0, Movementforce, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.z >= BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.z)
                {
                    body.AddForce(0, 0, -Movementforce, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.z == BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position.z)
                {
                    return;
                }
            }
        }

        internal override void OnPlayerLeft(Player player)
        {
            if (TargetPlayer.Equals(player))
            {
                Destroy(this);
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
                        RigidBodyController.useGravity = false;
                        RigidBodyController.drag = 0.3f;
                        RigidBodyController.constraints = RigidbodyConstraints.FreezeRotation;
                        RigidBodyController.isKinematic = false;
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
        private float AttackerTimeCheck { get; set; } = 0;

        private float Movementforce { get; set; } = 0.04f; // DEFAULT 0.04f

        private bool isPaused { get; set; }
        private Rigidbody body { get; set; } = null;

        internal Player TargetPlayer { get; set; }
    }
}