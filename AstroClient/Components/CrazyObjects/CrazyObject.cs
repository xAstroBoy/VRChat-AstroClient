using System;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;
using Random = UnityEngine.Random;

#region AstroClient Imports

using static AstroClient.Forces;

#endregion AstroClient Imports

namespace AstroClient.components
{
	public class CrazyObject : GameEventsBehaviour
	{
		public Delegate ReferencedDelegate;
		public IntPtr MethodInfo;
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public CrazyObject(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		public CrazyObject(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<CrazyObject>())
		{
			ClassInjector.DerivedConstructorBody(this);

			ReferencedDelegate = referencedDelegate;
			MethodInfo = methodInfo;
		}

		~CrazyObject()
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
			CrazyObjectManager.Register(this);
			obj = RigidBody.gameObject;
			OnlineEditor.TakeObjectOwnership(obj);
			pickup = GetComponent<PickupController>();
			if (pickup == null)
			{
				pickup = obj.AddComponent<PickupController>();
			}
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
		}

		public void SelfDestroy()
		{
			try
			{
				control.RestoreOriginalBody();
				OnlineEditor.RemoveOwnerShip(obj);
				CrazyObjectManager.RemoveObject(obj);
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
						OnlineEditor.RemoveOwnerShip(obj);
						HasRequiredSettings = false;
					}
					return;
				}

				if (!HasRequiredSettings)
				{
					if (!control.EditMode)
					{
						control.EditMode = true;
					}
					if (!OnlineEditor.IsLocalPlayerOwner(obj))
					{
						if (Forces.TakeOwnership)
						{
							OnlineEditor.TakeObjectOwnership(obj);
						}
						if (control != null)
						{
							control.isKinematic = false;
							control.useGravity = UseGravity;
							control.UpdateAngularDrag(0);
							control.UpdateDrag(0);
						}
					}
					else
					{
						if (control != null)
						{
							control.isKinematic = false;
							control.useGravity = UseGravity;
							control.UpdateAngularDrag(0);
							control.UpdateDrag(0);
						}
					}
					HasRequiredSettings = true;
				}

				if ((Time.time - LastTimeCheck2 > ImpulseTimer))
				{
					if (Forces.TakeOwnership)
					{
						OnlineEditor.TakeObjectOwnership(obj);
					}
					if (ShouldDoImpulseMode)
					{
						if (IsImpulseModeActive)
						{
							if (!IsDoingImpulseMode)
							{
								IsDoingImpulseMode = true;
								ApplyRelativeForce(obj, 0, ImpulseForce, 0);
								ApplyRelativeForce(obj, 0, ImpulseForce, 0);
								ApplyRelativeForce(obj, 0, ImpulseForce, 0);
								ApplyRelativeForce(obj, 0, ImpulseForce, 0);
								ApplyRelativeForce(obj, 0, ImpulseForce, 0);
								ApplyRelativeForce(obj, 0, ImpulseForce, 0);
								IsDoingImpulseMode = false;
							}
						}
						LastTimeCheck2 = Time.time;
					}
				}

				if ((Time.time - LastTimeCheck > CrazyTimer))
				{
					if (Forces.TakeOwnership)
					{
						OnlineEditor.TakeObjectOwnership(obj);
					}
					if (!IsDoingImpulseMode)
					{
						ApplyRelativeForce(obj, Random.Range(1f, 8f), 0, 0);

						SpinObject(obj, Random.Range(0f, 2f), 0, 0);

						ApplyRelativeForce(obj, 0, Random.Range(1f, 8f), 0);

						SpinObject(obj, 0, Random.Range(0f, 2f), 0);

						ApplyRelativeForce(obj, 0, 0, Random.Range(1f, 8f));

						SpinObject(obj, 0, 0, Random.Range(0f, 2f));
					}
					LastTimeCheck = Time.time;
				}
			}
			catch (Exception)
			{
			}
		}

		public CrazyObjectManager Manager = null;

		public float TimerOffset = 0f;
		private float LastTimeCheck = 0;
		private float LastTimeCheck2 = 0;

		internal float CrazyTimer = 0.04f;
		internal float ImpulseTimer = 5f;
		internal float ImpulseForce = 1.5f;
		internal bool ShouldDoImpulseMode = true;
		internal bool IsDoingImpulseMode = false;

		internal bool IsImpulseModeActive = false;
		private Rigidbody RigidBody = null;
		private GameObject obj = null;
		private RigidBodyController control;
		private PickupController pickup;
		internal bool UseGravity;
		private bool HasRequiredSettings = false;
	}
}