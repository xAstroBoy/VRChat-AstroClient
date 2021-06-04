namespace AstroClient.Components
{
	using AstroClient.Extensions;
	using System;
	using System.Runtime.InteropServices;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using static AstroClient.Forces;

	public class ObjectSpinner : GameEventsBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ObjectSpinner(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
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

		private void OnDestroy()
		{
			try
			{
				control.RestoreOriginalBody();
				OnlineEditor.RemoveOwnerShip(obj);
				ObjectSpinnerManager.RemoveObject(obj);
			}
			catch
			{
			}
		}

		// Update is called once per frame
		private void Update()
        {
            try
            {
                if (pickup.IsHeld)
                {
                    if (HasRequiredSettings)
                    {
                        control.RestoreOriginalBody();
                        HasRequiredSettings = false;
                    }
                    return;
                }

                if (Time.time - LastTimeCheck > SpinnerTimer)
                {
                    if (!HasRequiredSettings)
                    {
                        if (!control.EditMode)
                        {
                            control.EditMode = true;
                        }
                        if (!pickup.IsHeld)
                        {
                            if (control != null)
                            {
                                control.isKinematic = false;
                                control.UpdateAngularDrag(0);
                                control.UpdateDrag(0);
                            }
                            HasRequiredSettings = true;
                        }
                    }
                    if (!pickup.IsHeld)
                    {
                        if (!obj.isOwner())
                        {
                            obj.TakeOwnership();
                        }
                        SpinObject(obj, ForceX, 0, 0);
                        SpinObject(obj, 0, ForceY, 0);
                        SpinObject(obj, 0, 0, ForceZ);
                    }

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