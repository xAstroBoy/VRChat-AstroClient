namespace AstroClient.Components
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroLibrary.Console;
	using AstroClient.ItemTweaker;
	using AstroClient.SyncPhysicExt;
	using System;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using SyncPhysics = MonoBehaviour1PublicPiOb1ObBoRiBoNuObRiUnique;

	public class RigidBodyController : GameEventsBehaviour
	{
		public RigidBodyController(IntPtr ptr) : base(ptr)
		{
		}

		// Use this for initialization
		public void Start()
		{
			try
			{
				obj = gameObject;
				body = obj.GetComponent<Rigidbody>();
				if (body == null)
				{
					body = obj.GetComponentInChildren<Rigidbody>();
				}

				Sync = obj.GetComponent<SyncPhysics>();
				BackupBasicBody();
				EditMode = false;
			}
			catch { }
		}

		private void BackupBasicBody()
		{
			if (Sync != null)
			{
				if (Sync.GetRigidBody() != null)
				{
					ModConsole.DebugLog($"Backupping from Sync.GetRigidBody() properties for object  {obj.name}");

					if (Sync.GetRigidBody().useGravity != OrigUseGravity)
					{
						OrigUseGravity = Sync.GetRigidBody().useGravity;
					}
					if (Sync.GetRigidBody().useGravity != useGravity)
					{
						useGravity = Sync.GetRigidBody().useGravity;
					}

					if (Sync.GetRigidBody().isKinematic != OrigKinematic)
					{
						OrigKinematic = Sync.GetRigidBody().isKinematic;
					}
					if (Sync.GetRigidBody().isKinematic != isKinematic)
					{
						isKinematic = Sync.GetRigidBody().isKinematic;
					}

					if (Sync.GetRigidBody().constraints != OrigConstraints)
					{
						OrigConstraints = Sync.GetRigidBody().constraints;
					}
					if (Sync.GetRigidBody().constraints != Constraints)
					{
						Constraints = Sync.GetRigidBody().constraints;
					}

					if (Sync.GetRigidBody().detectCollisions != OrigDetectCollisions)
					{
						OrigDetectCollisions = Sync.GetRigidBody().detectCollisions;
					}
					if (Sync.GetRigidBody().detectCollisions != DetectCollisions)
					{
						DetectCollisions = Sync.GetRigidBody().detectCollisions;
					}

					if (Sync.GetRigidBody().drag != OrigDrag)
					{
						OrigDrag = Sync.GetRigidBody().drag;
					}
					if (Sync.GetRigidBody().drag != Drag)
					{
						Drag = Sync.GetRigidBody().drag;
					}

					if (Sync.GetRigidBody().angularDrag != OrigAngularDrag)
					{
						OrigAngularDrag = Sync.GetRigidBody().angularDrag;
					}
					if (Sync.GetRigidBody().angularDrag != AngularDrag)
					{
						AngularDrag = Sync.GetRigidBody().angularDrag;
					}
				}
				else
				{
					OrigKinematic = true;
				}
			}
			else
			{
				ModConsole.DebugLog($"Backupping from RigidBody properties for object  {obj.name}");
				OrigUseGravity = body.useGravity;
				OrigDetectCollisions = body.detectCollisions;
				OrigConstraints = body.constraints;
				OrigDrag = body.drag;
				OrigAngularDrag = body.angularDrag;
				isKinematic = body.isKinematic;
				useGravity = body.useGravity;
				DetectCollisions = body.detectCollisions;
				AngularDrag = body.angularDrag;
				Drag = body.drag;
				Constraints = body.constraints;
			}
			EditMode = false;
		}

		internal void RestoreOriginalBody()
		{
			isKinematic = OrigKinematic;
			useGravity = OrigUseGravity;
			DetectCollisions = OrigDetectCollisions;
			UpdateAngularDrag(OrigAngularDrag);
			UpdateDrag(OrigDrag);
			Constraints = OrigConstraints;
			if (Sync != null)
			{
				if (Sync.GetRigidBody() != null)
				{
					Sync.GetRigidBody().useGravity = OrigUseGravity;
					Sync.GetRigidBody().isKinematic = OrigKinematic;
					Sync.GetRigidBody().constraints = OrigConstraints;
					Sync.GetRigidBody().detectCollisions = OrigDetectCollisions;
					Sync.GetRigidBody().drag = OrigDrag;
					Sync.GetRigidBody().angularDrag = OrigAngularDrag;
				}
			}
			Sync.RefreshProperties();
			EditMode = false;
		}

		// Update is called once per frame
		public void Update()
		{
			try
			{
				try
				{
					if (Forced_SyncPhysic)
					{
						if (Sync == null)
						{
							Sync = obj.AddComponent<SyncPhysics>();
						}

						if (Sync.field_Private_Rigidbody_0 == null)
						{
							if (obj.GetComponent<Rigidbody>() != null && Sync.field_Private_Rigidbody_0 == null)
							{
								ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody in SyncPhysic as is Null..");
								Sync.field_Private_Rigidbody_0 = obj.GetComponent<Rigidbody>();
								return;
							}

							if (obj.GetComponentInChildren<Rigidbody>() != null && Sync.field_Private_Rigidbody_0 == null)
							{
								ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody in SyncPhysic as is Null..");
								Sync.field_Private_Rigidbody_0 = obj.GetComponentInChildren<Rigidbody>();
								return;
							}
							if (obj.GetComponentInChildren<Rigidbody>() == null && obj.GetComponent<Rigidbody>() == null && Sync.field_Private_Rigidbody_0 == null)
							{
								ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Spawned Rigidbody in SyncPhysic as is Null..");
								body = obj.AddComponent<Rigidbody>();
								Sync.field_Private_Rigidbody_0 = body;
								body.isKinematic = true;
								return;
							}

							if(Sync.field_Private_VRC_Pickup_0 == null)
							{
								if (obj.GetComponent<VRC.SDKBase.VRC_Pickup>() != null && Sync.field_Private_VRC_Pickup_0 == null)
								{
									ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
									Sync.field_Private_VRC_Pickup_0 = obj.GetComponent<VRC.SDKBase.VRC_Pickup>();
									return;
								}

								if (obj.GetComponentInChildren<VRC.SDKBase.VRC_Pickup>() != null && Sync.field_Private_VRC_Pickup_0 == null)
								{
									ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
									Sync.field_Private_VRC_Pickup_0 = obj.GetComponentInChildren<VRC.SDKBase.VRC_Pickup>();
									return;
								}
								if (obj.GetComponent<VRCSDK2.VRC_Pickup>() != null && Sync.field_Private_VRC_Pickup_0 == null)
								{
									ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
									Sync.field_Private_VRC_Pickup_0 = obj.GetComponent<VRCSDK2.VRC_Pickup>();
									return;
								}

								if (obj.GetComponentInChildren<VRCSDK2.VRC_Pickup>() != null && Sync.field_Private_VRC_Pickup_0 == null)
								{
									ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
									Sync.field_Private_VRC_Pickup_0 = obj.GetComponentInChildren<VRCSDK2.VRC_Pickup>();
									return;
								}
							}
						}
					}

					if (Forced_RigidBody)
					{
						if (body == null)
						{
							if (obj.GetComponent<Rigidbody>() != null && body == null)
							{
								ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody..");
								body = obj.GetComponent<Rigidbody>();
								body.isKinematic = true;
								return;
							}

							if (obj.GetComponentInChildren<Rigidbody>() != null && Sync.field_Private_Rigidbody_0 == null)
							{
								ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody..");
								body = obj.GetComponentInChildren<Rigidbody>();
								body.isKinematic = true;
								return;
							}
							if (obj.GetComponentInChildren<Rigidbody>() == null && obj.GetComponent<Rigidbody>() == null && Sync.field_Private_Rigidbody_0 == null)
							{
								ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Spawned Rigidbody..");
								body = obj.AddComponent<Rigidbody>();
								body.isKinematic = true;
								return;
							}
						}
					}
				}
				catch (Exception)
				{
					ModConsole.DebugError($"RigidBodyController : Failed to Bind a Rigidbody to Object {obj.name}, Retrying...");
					return;
				}

				if (PreventOthersFromGrabbing)
				{
					if (!OnlineEditor.IsLocalPlayerOwner(obj))
					{
						OnlineEditor.TakeObjectOwnership(obj);
					}
				}
				if (Tweaker_Object.CurrentSelectedObject == obj)
				{
					if (ItemTweakerMain.ProtectionInteractor != null)
					{
						ItemTweakerMain.ProtectionInteractor.setToggleState(PreventOthersFromGrabbing);
					}

					if (!Forces.UpdateFreezeAllConstraints(Constraints))
					{
						Forces.UpdatePositionConstraints(Constraints);
						Forces.UpdateRotationSection(Constraints);
					}
					if (obj.transform != null)
					{
						ItemTweakerMain.CurrentObjectCoordsBtn.setButtonText($"X: {obj.transform.position.x} \n Y: {obj.transform.position.y} \n Z: {obj.transform.position.z}");
					}
				}

				if (EditMode)
				{
					if (Sync != null)
					{
						if (Sync.GetRigidBody() != null)
						{
							if (Sync.GetRigidBody().useGravity != useGravity)
							{
								Sync.GetRigidBody().useGravity = useGravity;
								Sync.RefreshProperties();
							}
							if (Sync.GetRigidBody().isKinematic != isKinematic)
							{
								Sync.GetRigidBody().isKinematic = isKinematic;
								Sync.RefreshProperties();
							}
							if (Sync.GetRigidBody().constraints != Constraints)
							{
								Sync.GetRigidBody().constraints = Constraints;
								Sync.RefreshProperties();
							}
							if (Sync.GetRigidBody().detectCollisions != DetectCollisions)
							{
								Sync.GetRigidBody().detectCollisions = DetectCollisions;
								Sync.RefreshProperties();
							}
							if (Sync.GetRigidBody().drag != Drag)
							{
								Sync.GetRigidBody().drag = Drag;
								Sync.RefreshProperties();
							}
							if (Sync.GetRigidBody().angularDrag != AngularDrag)
							{
								Sync.GetRigidBody().angularDrag = AngularDrag;
								Sync.RefreshProperties();
							}
						}
					}

					if (body != null)
					{
						if (body.useGravity != useGravity)
						{
							body.useGravity = useGravity;
						}
						if (body.isKinematic != isKinematic)
						{
							body.isKinematic = isKinematic;
						}
						if (body.constraints != Constraints)
						{
							body.constraints = Constraints;
						}
						if (body.detectCollisions != DetectCollisions)
						{
							body.detectCollisions = DetectCollisions;
						}
						if (body.drag != Drag)
						{
							body.drag = Drag;
						}
						if (body.angularDrag != AngularDrag)
						{
							body.angularDrag = AngularDrag;
						}
					}
				}
				else
				{
					if (Sync != null)
					{
						if (Sync.GetRigidBody() != null)
						{
							if (Sync.GetRigidBody().useGravity != OrigUseGravity)
							{
								OrigUseGravity = Sync.GetRigidBody().useGravity;
							}
							if (Sync.GetRigidBody().useGravity != useGravity)
							{
								useGravity = Sync.GetRigidBody().useGravity;
							}

							if (Sync.GetRigidBody().isKinematic != OrigKinematic)
							{
								OrigKinematic = Sync.GetRigidBody().isKinematic;
							}
							if (Sync.GetRigidBody().isKinematic != isKinematic)
							{
								isKinematic = Sync.GetRigidBody().isKinematic;
							}

							if (Sync.GetRigidBody().constraints != OrigConstraints)
							{
								OrigConstraints = Sync.GetRigidBody().constraints;
							}
							if (Sync.GetRigidBody().constraints != Constraints)
							{
								Constraints = Sync.GetRigidBody().constraints;
							}

							if (Sync.GetRigidBody().detectCollisions != OrigDetectCollisions)
							{
								OrigDetectCollisions = Sync.GetRigidBody().detectCollisions;
							}
							if (Sync.GetRigidBody().detectCollisions != DetectCollisions)
							{
								DetectCollisions = Sync.GetRigidBody().detectCollisions;
							}

							if (Sync.GetRigidBody().drag != OrigDrag)
							{
								OrigDrag = Sync.GetRigidBody().drag;
							}
							if (Sync.GetRigidBody().drag != Drag)
							{
								Drag = Sync.GetRigidBody().drag;
							}

							if (Sync.GetRigidBody().angularDrag != OrigAngularDrag)
							{
								OrigAngularDrag = Sync.GetRigidBody().angularDrag;
							}
							if (Sync.GetRigidBody().angularDrag != AngularDrag)
							{
								AngularDrag = Sync.GetRigidBody().angularDrag;
							}
						}
					}

					if (body != null)
					{
						if (body.useGravity != OrigUseGravity)
						{
							OrigUseGravity = body.useGravity;
						}
						if (body.useGravity != useGravity)
						{
							useGravity = body.useGravity;
						}

						if (body.isKinematic != OrigKinematic)
						{
							OrigKinematic = body.isKinematic;
						}
						if (body.isKinematic != isKinematic)
						{
							isKinematic = body.isKinematic;
						}

						if (body.constraints != OrigConstraints)
						{
							OrigConstraints = body.constraints;
						}
						if (body.constraints != Constraints)
						{
							Constraints = body.constraints;
						}

						if (body.detectCollisions != OrigDetectCollisions)
						{
							OrigDetectCollisions = body.detectCollisions;
						}
						if (body.detectCollisions != DetectCollisions)
						{
							DetectCollisions = body.detectCollisions;
						}

						if (body.drag != OrigDrag)
						{
							OrigDrag = body.drag;
						}
						if (body.drag != Drag)
						{
							Drag = body.drag;
						}

						if (body.angularDrag != OrigAngularDrag)
						{
							OrigAngularDrag = body.angularDrag;
						}
						if (body.angularDrag != AngularDrag)
						{
							AngularDrag = body.angularDrag;
						}
					}
				}
			}
			catch (Exception e)
			{
				ModConsole.DebugError($"RigidBodyController assigned to  {obj.name} thrown a exception {e}");
			}
		}

		[HideFromIl2Cpp]
		internal bool UpdateAngularDrag(float newdrag)
		{
			AngularDrag = newdrag;
			if (AngularDrag == newdrag)
			{
				return true;
			}
			return false;
		}

		[HideFromIl2Cpp]
		internal bool UpdateDrag(float newdrag)
		{
			Drag = newdrag;
			if (Drag == newdrag)
			{
				return true;
			}
			return false;
		}

		[HideFromIl2Cpp]
		internal bool UpdateKinematic(bool Kinematic)
		{
			isKinematic = Kinematic;
			if (isKinematic == Kinematic)
			{
				return true;
			}
			return false;
		}

		[HideFromIl2Cpp]
		internal void OverrideInternalKinematic(bool Kinematic)
		{
			OrigKinematic = Kinematic;
		}

		[HideFromIl2Cpp]
		internal SyncPhysics Internal_Sync
		{
			get
			{
				return Sync;
			}
		}

		private GameObject obj = null;
		private SyncPhysics Sync = null;
		private Rigidbody body = null;

		internal bool EditMode = false;

		private bool OrigKinematic = false;
		private bool OrigUseGravity = false;
		private bool OrigDetectCollisions = true;
		private float OrigDrag = 0f;
		private float OrigAngularDrag = 0f;
		private RigidbodyConstraints OrigConstraints;

		internal bool Forced_SyncPhysic;
		internal bool Forced_RigidBody;

		internal bool useGravity = false;
		internal bool isKinematic = false;
		internal bool PreventOthersFromGrabbing = false;
		internal bool DetectCollisions = true;
		internal float Drag = 0f;
		internal float AngularDrag = 0f;

		internal RigidbodyConstraints Constraints;
	}
}