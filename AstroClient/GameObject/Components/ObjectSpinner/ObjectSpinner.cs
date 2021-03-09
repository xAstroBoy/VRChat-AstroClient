using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC.SDKBase;

#region AstroClient Imports

using static AstroClient.Forces;

#endregion AstroClient Imports

namespace AstroClient.components
{
    public class ObjectSpinner : MonoBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public ObjectSpinner(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        public ObjectSpinner(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ObjectSpinner>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~ObjectSpinner()
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
            RigidBody = GetComponent<Rigidbody>();
            ObjectSpinnerManager.Register(this);
            obj = RigidBody.gameObject;
            OnlineEditor.TakeObjectOwnership(obj);
            control = GetComponent<RigidBodyController>();
            pickup = GetComponent<PickupController>();
            if (pickup == null)
            {
                pickup = obj.AddComponent<PickupController>();
            }
            if (control == null)
            {
                control = obj.AddComponent<RigidBodyController>();
                HasRequiredSettings = false;
            }
            else
            {
                HasRequiredSettings = false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SelfDestroy()
        {
            try
            {
                control.RestoreOriginalBody();
                OnlineEditor.RemoveOwnerShip(obj);
                ObjectSpinnerManager.RemoveObject(obj);
                DestroyImmediate(this);
            }
            catch (Exception)
            {
            }
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (pickup.isHeld)
                {
                    if (HasRequiredSettings)
                    {
                        control.RestoreOriginalBody();
                        HasRequiredSettings = false;
                    }
                    return;
                }

                if ((Time.time - LastTimeCheck > SpinnerTimer))
                {
                    if (!HasRequiredSettings)
                    {
                        if (!control.EditMode)
                        {
                            control.EditMode = true;
                        }
                        if (!OnlineEditor.IsLocalPlayerOwner(obj))
                        {
                            OnlineEditor.TakeObjectOwnership(obj);
                            if (control != null)
                            {
                                control.isKinematic = false;
                                control.UpdateAngularDrag(0);
                                control.UpdateDrag(0);
                            }
                        }
                        else
                        {
                            if (control != null)
                            {
                                control.isKinematic = false;
                                control.UpdateAngularDrag(0);
                                control.UpdateDrag(0);
                            }
                        }
                        HasRequiredSettings = true;
                    }

                    if (Forces.TakeOwnership)
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                    SpinObject(obj, ForceX, 0, 0);
                    SpinObject(obj, 0, ForceY, 0);
                    SpinObject(obj, 0, 0, ForceZ);


                    LastTimeCheck = Time.time;
                }
            }
            catch (Exception)
            {
            }
        }

        public ObjectSpinnerManager Manager = null;

        public float TimerOffset = 0f;

        private float LastTimeCheck = 0;

        internal float ForceX;
        internal float ForceY;
        internal float ForceZ;
        internal float SpinnerTimer = 0.03f;
        private bool HasRequiredSettings = false;
        private Rigidbody RigidBody = null;
        private GameObject obj = null;
        private RigidBodyController control;
        private PickupController pickup;
    }
}