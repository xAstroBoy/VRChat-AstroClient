namespace AstroClient.Components
{
    using AstroClient.GameObjectDebug;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using VRC;
    using Delegate = System.Delegate;
    using Time = UnityEngine.Time;

    public class PlayerAttacker : GameEventsBehaviour
    {
        public PlayerAttacker(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();



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

                if (TargetPlayer == null)
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

        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (IsLockDeactivated)
                {
                    if (TargetPlayer == null)
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
                                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                                    ApplyForceX();
                                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                                    ApplyForceY();
                                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                                    ApplyForceZ();
                                    gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
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

                    control.constraints = RigidbodyConstraints.FreezeRotation;
                    control.useGravity = false;
                    control.drag = Drag;
                    HasUpdatedDrag = false;
                    HasUpdatedKinematic = false;
                    if (control != null)
                    {
                        control.constraints = RigidbodyConstraints.FreezeRotation;
                        control.isKinematic = false;
                        control.useGravity = false;
                    }

                    HasRequiredSettings = true;
                }
            }
        }

        private void OnDestroy()
        {
            control.RestoreOriginalBody();
            GameObjectMenu.RestoreOriginalLocation(gameObject, false);
            OnlineEditor.RemoveOwnerShip(gameObject);
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

        private float Movementforce = 0.04f; // DEFAULT 0.04f
        internal float TimerOffset = 0f;
        private float LastTimeCheck = 0;
        private float LastTimeCheck2 = 0;
        private float Drag = 0.3f;
        private bool HasUpdatedDrag = false;

        internal Player TargetPlayer;
        internal bool IsLockDeactivated = false;
        private Rigidbody body = null;
        private RigidBodyController control;
        private PickupController pickup;
        private bool HasUpdatedKinematic;
        private bool HasRequiredSettings = false;

        private bool ApplyOnce = true;
    }
}