﻿namespace AstroClient.Components
{
    using AstroLibrary.Extensions;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Forces;
    using Random = UnityEngine.Random;

    public class RocketObject : GameEventsBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public RocketObject(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public RocketObject(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<RocketObject>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~RocketObject()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        // Use this for initialization
        private void Start()
        {
            RigidBody = GetComponent<Rigidbody>();
            RocketManager.Register(this);
            obj = RigidBody.gameObject;
            OnlineEditor.TakeObjectOwnership(obj);
            control = GetComponent<RigidBodyController>();

            if (control == null)
            {
                control = obj.AddComponent<RigidBodyController>();
                HasRequiredSettings = false;
            }
            else
            {
                HasRequiredSettings = false;
            }

            pickup = GetComponent<PickupController>();
            if (pickup == null)
            {
                pickup = obj.AddComponent<PickupController>();
            }
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (Time.time - LastTimeCheck > RocketTimer)
                {
                    if (pickup.IsHeld)
                    {
                        if (HasRequiredSettings)
                        {
                            OnlineEditor.RemoveOwnerShip(obj);
                            control.RestoreOriginalBody();
                            HasRequiredSettings = false;
                        }
                    }
                    else
                    {
                        if (!HasRequiredSettings)
                        {
                            if (!control.EditMode)
                            {
                                control.EditMode = true;
                            }
                            if (!obj.IsOwner())
                            {
                                obj.TakeOwnership();
                            }

                            if (control != null)
                            {
                                control.isKinematic = false;
                                control.useGravity = UseGravity;
                                control.angularDrag = 0;
                                control.drag = 0;
                            }
                            HasRequiredSettings = true;
                        }
                        if (!pickup.IsHeld)
                        {
                            if (obj.IsOwner())
                            {
                                if (!ShouldBeAlwaysUp)
                                {
                                    ApplyRelativeForce(obj, 0, Random.Range(1f, 10f), 0);
                                }
                                else
                                {
                                    ApplyForce(obj, 0, Random.Range(1f, 10f), 0);
                                }
                            }
                            else
                            {
                                obj.TakeOwnership();
                            }
                        }
                    }
                    LastTimeCheck = Time.time;
                }
            }
            catch (Exception)
            {
            }
        }

        private void OnDestroy()
        {
            try
            {
                control.RestoreOriginalBody();
                OnlineEditor.RemoveOwnerShip(obj);
                RocketManager.RemoveObject(obj);
            }
            catch
            {
            }
        }

        public RocketManager Manager = null;

        public float UpdateTimer = 2f;
        public float TimerOffset = 0f;
        private float LastTimeCheck = 0;
        internal float RocketTimer = 0.07f;

        internal bool ShouldBeAlwaysUp = false;
        internal bool UseGravity = false;
        private Rigidbody RigidBody = null;
        private GameObject obj = null;
        private RigidBodyController control;
        private PickupController pickup;
        private bool HasRequiredSettings;
    }
}