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

    [RegisterComponent]
    public class PlayerWatcher : GameEventsBehaviour
    {
        public PlayerWatcher(IntPtr ptr) : base(ptr)
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
                pickup = GetComponent<PickupController>();
                if (pickup == null)
                {
                    pickup = gameObject.AddComponent<PickupController>();
                }
                HasRequiredSettings = false;

                if (GetComponent<PickupController>() == null)
                {
                    ModConsole.Warning("PlayerWatcher : Object Still Has No PickupController (Probably Udon World) , Watcher Will be broken!");
                }

                if (GetComponent<RigidBodyController>() == null)
                {
                    ModConsole.Warning("PlayerWatcher : Object Still Has No RigidBody (Probably Udon World) , Watcher Will be broken!");
                }

                if (TargetPlayer == null)
                {
                    ModConsole.Error("PlayerWatcher : , Player Is not registered!");
                }

                if (this == null)
                {
                    ModConsole.Error("PlayerWatcher : Is This actually supposed to be null?");
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

                    if (ApplyOnce)
                    {
                        SetRequiredSettings();
                    }

                    if (Time.time - LastTimeCheck2 > 16.33f)
                    {
                        SetRequiredSettings();
                        LastTimeCheck2 = Time.time;
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
                        if (Time.time - LastTimeCheck > 0.05f)
                        {
                            if (!pickup.IsHeld)
                            {
                                if (!gameObject.IsOwner())
                                {
                                    gameObject.TakeOwnership();
                                }

                                gameObject.transform.LookAt(BonesUtils.Get_Player_Bone_Transform(TargetPlayer, HumanBodyBones.Head).position);
                            }

                            LastTimeCheck = Time.time;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void SetRequiredSettings()
        {
            if (!HasRequiredSettings)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }
                if (!gameObject.IsOwner())
                {
                    gameObject.TakeOwnership();
                }
                control.constraints = RigidbodyConstraints.FreezeRotation;
                control.constraints = RigidbodyConstraints.None;
                HasRequiredSettings = true;
            }
        }

        private void OnDestroy()
        {
            control.RestoreOriginalBody();
            GameObjectMenu.RestoreOriginalLocation(gameObject, false);
            OnlineEditor.RemoveOwnerShip(gameObject);
        }

        internal float TimerOffset = 0f;
        private float LastTimeCheck2 = 0;
        private float LastTimeCheck = 0;
        private bool HasRequiredSettings = false;
        private bool ApplyOnce = true;

        internal Player TargetPlayer;
        internal bool IsLockDeactivated = false;
        private Rigidbody body = null;
        private RigidBodyController control;
        private PickupController pickup;
    }
}