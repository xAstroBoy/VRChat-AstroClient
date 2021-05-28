namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroClient.GameObjectDebug;
	using DayClientML2.Utility.Extensions;
	using System;
	using System.Runtime.InteropServices;
	using UnhollowerRuntimeLib;
	using UnityEngine;
	using VRC;
	using Delegate = System.Delegate;
	using Time = UnityEngine.Time;
	using DayClientML2.Utility;
	using AstroClient.Extensions;

	public class PlayerWatcher : GameEventsBehaviour
	{
		public Delegate ReferencedDelegate;
		public IntPtr MethodInfo;
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public PlayerWatcher(IntPtr obj0) : base(obj0)
		{
			AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
			AntiGcList.Add(this);
		}

		public PlayerWatcher(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<PlayerWatcher>())
		{
			ClassInjector.DerivedConstructorBody(this);

			ReferencedDelegate = referencedDelegate;
			MethodInfo = methodInfo;
		}

		~PlayerWatcher()
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
				obj = gameObject;

				body = GetComponent<Rigidbody>();
				if (body == null)
				{
					body = obj.AddComponent<Rigidbody>();
				}
				control = GetComponent<RigidBodyController>();
				if (control == null)
				{
					control = obj.AddComponent<RigidBodyController>();
				}
				pickup = GetComponent<PickupController>();
				if (pickup == null)
				{
					pickup = obj.AddComponent<PickupController>();
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

				if (player == null)
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

			PlayerWatcherManager.Register(this);
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

					if (ApplyOnce)
					{
						SetRequiredSettings();
					}

					if (pickup.IsHeld)
					{
						if (HasRequiredSettings)
						{
							control.RestoreOriginalBody();
							HasRequiredSettings = false;
						}
						return;
					}

					if (Time.time - LastTimeCheck2 > 16.33f)
					{
						SetRequiredSettings();
						LastTimeCheck2 = Time.time;
					}

					if (!pickup.IsHeld)
					{
						if (obj.TakeOwnershipIfNeccesary())
						{
							obj.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
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
				if (obj.TakeOwnershipIfNeccesary())
				{
					control.Constraints = RigidbodyConstraints.FreezeRotation;
					obj.transform.LookAt(PositionOfBone(player, HumanBodyBones.Head).position);
					control.Constraints = RigidbodyConstraints.None;
					HasRequiredSettings = true;
				}
			}
		}



		private void OnDestroy()
		{
			control.RestoreOriginalBody();
			GameObjectUtils.RestoreOriginalLocation(obj, false);
			PlayerWatcherManager.RemoveSelf(obj);
			OnlineEditor.RemoveOwnerShip(obj);
			PlayerWatcherManager.Deregister(this);
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

		public PlayerWatcherManager Manager = null;
		public float TimerOffset = 0f;
		private float LastTimeCheck2 = 0;
		private bool HasRequiredSettings = false;
		private bool ApplyOnce = true;

		internal Player player;
		internal bool IsLockDeactivated = false;
		private GameObject obj = null;
		private Rigidbody body = null;
		private RigidBodyController control;
		private PickupController pickup;
	}
}