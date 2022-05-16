using AstroClient.ClientActions;

namespace AstroClient.AstroMonos.Components.Malicious
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.ObjectEditor;
    using AstroUdons;
    using ClientAttributes;
    using System;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class PlayerAttacker : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        private bool _DisableCollisions = false;

        internal bool Disablecollisions
        {
            [HideFromIl2Cpp]
            get => _DisableCollisions;
            [HideFromIl2Cpp]
            set
            {
                _DisableCollisions = value;
                HasRequiredSettings = true;
            }
        }

        private bool _HasSubscribed = false;

        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnPlayerLeft += OnPlayerLeft;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerLeft -= OnPlayerLeft;
                    }
                }
                _HasSubscribed = value;
            }
        }

        public PlayerAttacker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        private void Start()
        {
            RigidBodyController = gameObject.GetOrAddComponent<RigidBodyController>();
            body = RigidBodyController.Rigidbody;
            if (body == null)
            {
                body = GetComponent<Rigidbody>();
                body ??= gameObject.AddComponent<Rigidbody>();
            }
            PickupController = gameObject.GetOrAddComponent<PickupController>();
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += new Action(() => { isPaused = true; });
                VRC_AstroPickup.OnDrop += new Action(() => { isPaused = false; });
            }
            gameObject.TakeOwnership();
            HasSubscribed = true;
        }

        private void Update()
        {
            if (TargetPlayer == null) return;
            if (isPaused || isHeld)
            {
                if (HasRequiredSettings) HasRequiredSettings = false;
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
            if (!HasRequiredSettings) HasRequiredSettings = true;
            if (isCurrentOwner)
            {
                gameObject.transform.LookAt(HeadTransform.position);
                ApplyForceX();
                gameObject.transform.LookAt(HeadTransform.position);
                ApplyForceY();
                gameObject.transform.LookAt(HeadTransform.position);
                ApplyForceZ();
                gameObject.transform.LookAt(HeadTransform.position);
            }

            //AttackerTimeCheck = Time.time;
            //}
        }

        private Transform _HeadTransform;

        private Transform HeadTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (_HeadTransform == null)
                {
                    return _HeadTransform = TargetPlayer.Get_Player_Bone_Transform(HumanBodyBones.Head);
                }
                return _HeadTransform;
            }
        }

        private void ApplyForceX()
        {
            if (body != null && TargetPlayer.transform != null)
            {
                if (body.transform.position.x <= HeadTransform.position.x) body.AddForce(Movementforce, 0, 0, ForceMode.Impulse);
                else if (gameObject.transform.position.x >= HeadTransform.position.x) body.AddForce(-Movementforce, 0, 0, ForceMode.Impulse);
                else if (gameObject.transform.position.x == HeadTransform.position.x) return;
            }
        }

        private void ApplyForceY()
        {
            if (body != null && TargetPlayer.transform != null)
            {
                if (gameObject.transform.position.y <= HeadTransform.position.y) body.AddForce(0, Movementforce, 0, ForceMode.Impulse);
                else if (gameObject.transform.position.y >= HeadTransform.position.y) body.AddForce(0, -Movementforce, 0, ForceMode.Impulse);
                else if (gameObject.transform.position.y == HeadTransform.position.y) return;
            }
        }

        private void ApplyForceZ()
        {
            if (body != null && TargetPlayer.transform != null)
            {
                if (gameObject.transform.position.z <= HeadTransform.position.z) body.AddForce(0, 0, Movementforce, ForceMode.Impulse);
                else if (gameObject.transform.position.z >= HeadTransform.position.z) body.AddForce(0, 0, -Movementforce, ForceMode.Impulse);
                else if (gameObject.transform.position.z == HeadTransform.position.z) return;
            }
        }

        private void OnPlayerLeft(Player player)
        {
            if (TargetPlayer.Equals(player)) Destroy(this);
        }

        private void OnDestroy()
        {
            try
            {
                HasSubscribed = false;
                RigidBodyController.RestoreOriginalBody();
                if (VRC_AstroPickup != null) Destroy(VRC_AstroPickup);
                if (!isHeld) GameObjectMenu.RestoreOriginalLocation(gameObject, false);
            }
            catch { }
        }

        private float CheckisOwnerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0;

        private float CheckisOwnerDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 16f;
        private bool CheckisOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        private bool isCurrentOwner
        {
            [HideFromIl2Cpp]
            get
            {
                if (CheckisOwner) return gameObject.TryTakeOwnership();
                else return true;
            }
        }

        private bool isHeld => PickupController.IsHeld;

        private bool _HasRequiredSettings = false;

        private bool HasRequiredSettings
        {
            [HideFromIl2Cpp]
            get => _HasRequiredSettings;
            [HideFromIl2Cpp]
            set
            {
                if (value.Equals(_HasRequiredSettings)) return; // Do Nothing.
                _HasRequiredSettings = value;
                if (value)
                {
                    if (RigidBodyController != null)
                    {
                        RigidBodyController.EditMode = true;
                        RigidBodyController.useGravity = false;
                        RigidBodyController.drag = 0.3f;
                        RigidBodyController.constraints = RigidbodyConstraints.FreezeRotation;
                        RigidBodyController.isKinematic = false;
                        if (Disablecollisions)
                        {
                            RigidBodyController.detectCollisions = false;
                        }
                    }
                }
                else
                {
                    RigidBodyController.RestoreOriginalBody();
                    RigidBodyController.EditMode = false;
                }
            }
        }

        private Rigidbody RigidBody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private RigidBodyController RigidBodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PickupController PickupController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup VRC_AstroPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float AttackerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0;
        private float Movementforce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.04f; // DEFAULT 0.04f
        private bool isPaused { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Rigidbody body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        internal Player TargetPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}