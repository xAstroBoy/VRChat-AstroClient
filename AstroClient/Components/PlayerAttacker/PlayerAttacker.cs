namespace AstroClient.Components
{
	using AstroClient.GameObjectDebug;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using System;
	using System.Runtime.InteropServices;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using VRC;
	using Delegate = System.Delegate;
	using Time = UnityEngine.Time;

	public class PlayerAttacker : GameEventsBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerAttacker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public PlayerAttacker(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<PlayerAttacker>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~PlayerAttacker()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        // Use this for initialization
        private void Start()
        {
            try
            {
                body = GetComponent<Rigidbody>();
                if (body == null)
                {
                    body = gameObject.AddComponent<Rigidbody>();
                }
                control = GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = gameObject.AddComponent<RigidBodyController>();
                }
                HasRequiredSettings = false;

                pickup = GetComponent<PickupController>();
                if (pickup == null)
                {
                    pickup = gameObject.AddComponent<PickupController>();
                }

                if (GetComponent<RigidBodyController>() == null)
                {
                    ModConsole.Warning("PlayerAttacker : Object Still Has No RigidBodyController (Probably Udon World) , Attacker Will be broken!");
                }

                if (GetComponent<PickupController>() == null)
                {
                    ModConsole.Warning("PlayerAttacker : Object Still Has No PickupController (Probably Udon World) , Attacker Will be broken!");
                }

                if (player == null)
                {
                    ModConsole.Error("PlayerAttacker : ERROR , Player Is not registered!");
                }

                if (this == null)
                {
                    ModConsole.Error("PlayerAttacker : Is This actually supposed to be null?");
                }
            }
            catch
            { }

            PlayerAttackerManager.Register(this);
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (IsLockDeactivated)
                {
                    if (player == null)
                    {
                        Destroy(this);
                        return;
                    }

                    if (pickup.IsHeld)
                    {
                        if (HasRequiredSettings)
                        {
                            control.RestoreOriginalBody();
                            HasRequiredSettings = false;
                        }
                    }
                    else
                    {
                        if (!pickup.IsHeld)
                        {
                            if (!gameObject.IsOwner())
                            {
                                gameObject.TakeOwnership();
                            }
                        }

                        if (Time.time - LastTimeCheck > 0.9f)
                        {
                            ApplyRequiredSettings();

                            if (!HasUpdatedDrag)
                            {
                                HasUpdatedDrag = control.UpdateDrag(Drag);
                            }

                            if (!HasUpdatedKinematic)
                            {
                                HasUpdatedKinematic = control.UpdateKinematic(false);
                            }
                            LastTimeCheck = Time.time;
                        }
                        else
                        {
                            if (!pickup.IsHeld)
                            {
                                if (Time.time - LastTimeCheck2 > 0.06f)
                                {
                                    gameObject.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
                                    ApplyForceX();
                                    gameObject.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
                                    ApplyForceY();
                                    gameObject.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
                                    ApplyForceZ();
                                    gameObject.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void ApplyRequiredSettings()
        {
            if (!HasRequiredSettings)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                if (!pickup.IsHeld)
                {
                    if (!gameObject.IsOwner())
                    {
                        gameObject.TakeOwnership();
                    }

                    control.Constraints = RigidbodyConstraints.FreezeRotation;
                    control.UseGravity = false;
                    control.UpdateDrag(Drag);
                    HasUpdatedDrag = false;
                    HasUpdatedKinematic = false;
                    if (control != null)
                    {
                        control.Constraints = RigidbodyConstraints.FreezeRotation;
                        control.IsKinematic = false;
                        control.UseGravity = false;
                    }

                    HasRequiredSettings = true;
                }
            }
        }

        private void OnDestroy()
        {
            control.RestoreOriginalBody();
            GameObjectUtils.RestoreOriginalLocation(gameObject, false);
            PlayerAttackerManager.RemoveSelf(gameObject);
            OnlineEditor.RemoveOwnerShip(gameObject);
            PlayerAttackerManager.Deregister(this);
        }

        private void ApplyForceX()
        {
            if (body != null && player.transform != null)
            {
                if (body.transform.position.x <= PositionOfBone(player, HumanBodyBones.Head).position.x)
                {
                    body.AddForce(Movementforce, 0, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.x >= PositionOfBone(player, HumanBodyBones.Head).position.x)
                {
                    body.AddForce(-Movementforce, 0, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.x == PositionOfBone(player, HumanBodyBones.Head).position.x)
                {
                    return;
                }
            }
        }

        private void ApplyForceY()
        {
            if (body != null && player.transform != null)
            {
                if (gameObject.transform.position.y <= PositionOfBone(player, HumanBodyBones.Head).position.y)
                {
                    body.AddForce(0, Movementforce, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.y >= PositionOfBone(player, HumanBodyBones.Head).position.y)
                {
                    body.AddForce(0, -Movementforce, 0, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.y == PositionOfBone(player, HumanBodyBones.Head).position.y)
                {
                    return;
                }
            }
        }

        private void ApplyForceZ()
        {
            if (body != null && player.transform != null)
            {
                if (gameObject.transform.position.z <= PositionOfBone(player, HumanBodyBones.Head).position.z)
                {
                    body.AddForce(0, 0, Movementforce, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.z >= PositionOfBone(player, HumanBodyBones.Head).position.z)
                {
                    body.AddForce(0, 0, -Movementforce, ForceMode.Impulse);
                }
                else if (gameObject.transform.position.z == PositionOfBone(player, HumanBodyBones.Head).position.z)
                {
                    return;
                }
            }
        }

        public static Transform PositionOfBone(Player player, HumanBodyBones bone)
        {
            Transform bonePosition = player.transform;
            VRCAvatarManager avatarManager = player.GetVRCPlayer().prop_VRCAvatarManager_0;
            if (!avatarManager)
                return bonePosition;
            Animator animator = avatarManager.field_Private_Animator_0;
            if (!animator)
                return bonePosition;
            Transform boneTransform = animator.GetBoneTransform(bone);
            if (!boneTransform)
                return bonePosition;

            return boneTransform;
        }

        public PlayerAttackerManager Manager = null;
        private float Movementforce = 0.04f; // DEFAULT 0.04f
        public float TimerOffset = 0f;
        private float LastTimeCheck = 0;
        private float LastTimeCheck2 = 0;
        private float Drag = 0.3f;
        private bool HasUpdatedDrag = false;

        internal Player player;
        internal bool IsLockDeactivated = false;
        private Rigidbody body = null;
        private RigidBodyController control;
        private PickupController pickup;
        private bool HasUpdatedKinematic;
        private bool HasRequiredSettings = false;

        private bool ApplyOnce = true;
    }
}