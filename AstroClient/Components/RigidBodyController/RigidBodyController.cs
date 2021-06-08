namespace AstroClient.Components
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Extensions;
	using AstroLibrary.Console;
	using System;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC.SDK3.Components;
	using SyncPhysics = SyncPhysics;

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

                Internal_Sync = obj.GetComponent<SyncPhysics>();
                BackupBasicBody();
                EditMode = false;
            }
            catch { }
        }

        private void BackupBasicBody()
        {
            if (Internal_Sync != null)
            {
                if (Internal_Sync.GetRigidBody() != null)
                {
                    ModConsole.DebugLog($"Backupping from Sync.GetRigidBody() properties for object  {obj.name}");

                    if (Internal_Sync.GetRigidBody().useGravity != OrigUseGravity)
                    {
                        OrigUseGravity = Internal_Sync.GetRigidBody().useGravity;
                    }
                    if (Internal_Sync.GetRigidBody().useGravity != useGravity)
                    {
                        useGravity = Internal_Sync.GetRigidBody().useGravity;
                    }

                    if (Internal_Sync.GetRigidBody().isKinematic != OrigKinematic)
                    {
                        OrigKinematic = Internal_Sync.GetRigidBody().isKinematic;
                    }
                    if (Internal_Sync.GetRigidBody().isKinematic != isKinematic)
                    {
                        isKinematic = Internal_Sync.GetRigidBody().isKinematic;
                    }

                    if (Internal_Sync.GetRigidBody().constraints != OrigConstraints)
                    {
                        OrigConstraints = Internal_Sync.GetRigidBody().constraints;
                    }
                    if (Internal_Sync.GetRigidBody().constraints != Constraints)
                    {
                        Constraints = Internal_Sync.GetRigidBody().constraints;
                    }

                    if (Internal_Sync.GetRigidBody().detectCollisions != OrigDetectCollisions)
                    {
                        OrigDetectCollisions = Internal_Sync.GetRigidBody().detectCollisions;
                    }
                    if (Internal_Sync.GetRigidBody().detectCollisions != DetectCollisions)
                    {
                        DetectCollisions = Internal_Sync.GetRigidBody().detectCollisions;
                    }

                    if (Internal_Sync.GetRigidBody().drag != OrigDrag)
                    {
                        OrigDrag = Internal_Sync.GetRigidBody().drag;
                    }
                    if (Internal_Sync.GetRigidBody().drag != Drag)
                    {
                        Drag = Internal_Sync.GetRigidBody().drag;
                    }

                    if (Internal_Sync.GetRigidBody().angularDrag != OrigAngularDrag)
                    {
                        OrigAngularDrag = Internal_Sync.GetRigidBody().angularDrag;
                    }
                    if (Internal_Sync.GetRigidBody().angularDrag != AngularDrag)
                    {
                        AngularDrag = Internal_Sync.GetRigidBody().angularDrag;
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
            if (Internal_Sync != null)
            {
                if (Internal_Sync.GetRigidBody() != null)
                {
                    Internal_Sync.GetRigidBody().useGravity = OrigUseGravity;
                    Internal_Sync.GetRigidBody().isKinematic = OrigKinematic;
                    Internal_Sync.GetRigidBody().constraints = OrigConstraints;
                    Internal_Sync.GetRigidBody().detectCollisions = OrigDetectCollisions;
                    Internal_Sync.GetRigidBody().drag = OrigDrag;
                    Internal_Sync.GetRigidBody().angularDrag = OrigAngularDrag;
                }
            }
            Internal_Sync.RefreshProperties();
            EditMode = false;
        }

        // Update is called once per frame
        public void Update()
        {
            try
            {
                try
                {
					#region SyncPhysic Force (Broken, It makes Objects ungrabbable)
					//if (Forced_SyncPhysic)
					//{
					//    if (Internal_Sync == null)
					//    {
					//        Internal_Sync = obj.AddComponent<SyncPhysics>();
					//    }

					//    if (Internal_Sync.field_Private_Rigidbody_0 == null)
					//    {
					//        if (obj.GetComponent<Rigidbody>() != null && Internal_Sync.field_Private_Rigidbody_0 == null)
					//        {
					//            ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody in SyncPhysic as is Null..");
					//            Internal_Sync.field_Private_Rigidbody_0 = obj.GetComponent<Rigidbody>();
					//            return;
					//        }

					//        if (obj.GetComponentInChildren<Rigidbody>() != null && Internal_Sync.field_Private_Rigidbody_0 == null)
					//        {
					//            ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody in SyncPhysic as is Null..");
					//            Internal_Sync.field_Private_Rigidbody_0 = obj.GetComponentInChildren<Rigidbody>();
					//            return;
					//        }
					//        if (obj.GetComponentInChildren<Rigidbody>() == null && obj.GetComponent<Rigidbody>() == null && Internal_Sync.field_Private_Rigidbody_0 == null)
					//        {
					//            ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Spawned Rigidbody in SyncPhysic as is Null..");
					//            body = obj.AddComponent<Rigidbody>();
					//            Internal_Sync.field_Private_Rigidbody_0 = body;
					//            body.isKinematic = true;
					//            return;
					//        }

					//        if (Internal_Sync.field_Private_VRC_Pickup_0 == null)
					//        {
					//            if (obj.GetComponent<VRC.SDKBase.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
					//            {
					//                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
					//                Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponent<VRC.SDKBase.VRC_Pickup>();
					//                return;
					//            }

					//            if (obj.GetComponentInChildren<VRC.SDKBase.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
					//            {
					//                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
					//                Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponentInChildren<VRC.SDKBase.VRC_Pickup>();
					//                return;
					//            }
					//            if (obj.GetComponent<VRCSDK2.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
					//            {
					//                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
					//                Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponent<VRCSDK2.VRC_Pickup>();
					//                return;
					//            }

					//            if (obj.GetComponentInChildren<VRCSDK2.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
					//            {
					//                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
					//                Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponentInChildren<VRCSDK2.VRC_Pickup>();
					//                return;
					//            }
					//        }
					//    }
					//}
					#endregion


					// TODO: Better Check and structure
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

                            if (obj.GetComponentInChildren<Rigidbody>() != null && Internal_Sync.field_Private_Rigidbody_0 == null)
                            {
                                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody..");
                                body = obj.GetComponentInChildren<Rigidbody>();
                                body.isKinematic = true;
                                return;
                            }
                            if (obj.GetComponentInChildren<Rigidbody>() == null && obj.GetComponent<Rigidbody>() == null && Internal_Sync.field_Private_Rigidbody_0 == null)
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


				Run_OnRigidbodyControllerOnUpdate();

                if (EditMode)
                {
                    if (Internal_Sync != null)
                    {
                        if (Internal_Sync.GetRigidBody() != null)
                        {
                            if (Internal_Sync.GetRigidBody().useGravity != useGravity)
                            {
                                Internal_Sync.GetRigidBody().useGravity = useGravity;
								Internal_Sync.RefreshProperties();
								
							}
                            if (Internal_Sync.GetRigidBody().isKinematic != isKinematic)
                            {
                                Internal_Sync.GetRigidBody().isKinematic = isKinematic;
								Internal_Sync.RefreshProperties();
								
							}
                            if (Internal_Sync.GetRigidBody().constraints != Constraints)
                            {
                                Internal_Sync.GetRigidBody().constraints = Constraints;
								Internal_Sync.RefreshProperties();
								
							}
                            if (Internal_Sync.GetRigidBody().detectCollisions != DetectCollisions)
                            {
                                Internal_Sync.GetRigidBody().detectCollisions = DetectCollisions;
								Internal_Sync.RefreshProperties();
								
							}
                            if (Internal_Sync.GetRigidBody().drag != Drag)
                            {
                                Internal_Sync.GetRigidBody().drag = Drag;
								Internal_Sync.RefreshProperties();
								
							}
                            if (Internal_Sync.GetRigidBody().angularDrag != AngularDrag)
                            {
                                Internal_Sync.GetRigidBody().angularDrag = AngularDrag;
								Internal_Sync.RefreshProperties();
								
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
                    if (Internal_Sync != null)
                    {
                        if (Internal_Sync.GetRigidBody() != null)
                        {
                            if (Internal_Sync.GetRigidBody().useGravity != OrigUseGravity)
                            {
								OrigUseGravity = Internal_Sync.GetRigidBody().useGravity;
								
							}
                            if (Internal_Sync.GetRigidBody().useGravity != useGravity)
                            {
								useGravity = Internal_Sync.GetRigidBody().useGravity;
								
							}

                            if (Internal_Sync.GetRigidBody().isKinematic != OrigKinematic)
                            {
								OrigKinematic = Internal_Sync.GetRigidBody().isKinematic;
								
							}
                            if (Internal_Sync.GetRigidBody().isKinematic != isKinematic)
                            {
								isKinematic = Internal_Sync.GetRigidBody().isKinematic;
								
							}

                            if (Internal_Sync.GetRigidBody().constraints != OrigConstraints)
                            {
								OrigConstraints = Internal_Sync.GetRigidBody().constraints;
								
							}
                            if (Internal_Sync.GetRigidBody().constraints != Constraints)
                            {
								Constraints = Internal_Sync.GetRigidBody().constraints;
								
							}

                            if (Internal_Sync.GetRigidBody().detectCollisions != OrigDetectCollisions)
                            {
								OrigDetectCollisions = Internal_Sync.GetRigidBody().detectCollisions;
								
							}
                            if (Internal_Sync.GetRigidBody().detectCollisions != DetectCollisions)
                            {
								DetectCollisions = Internal_Sync.GetRigidBody().detectCollisions;
								
							}

                            if (Internal_Sync.GetRigidBody().drag != OrigDrag)
                            {
								OrigDrag = Internal_Sync.GetRigidBody().drag;
								
							}
                            if (Internal_Sync.GetRigidBody().drag != Drag)
                            {
								Drag = Internal_Sync.GetRigidBody().drag;
								
							}

                            if (Internal_Sync.GetRigidBody().angularDrag != OrigAngularDrag)
                            {
								OrigAngularDrag = Internal_Sync.GetRigidBody().angularDrag;
								
							}
                            if (Internal_Sync.GetRigidBody().angularDrag != AngularDrag)
                            {
								AngularDrag = Internal_Sync.GetRigidBody().angularDrag;
								
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
            return AngularDrag == newdrag;
        }

        [HideFromIl2Cpp]
        internal bool UpdateDrag(float newdrag)
        {
            Drag = newdrag;
            return Drag == newdrag;
        }

        [HideFromIl2Cpp]
        internal bool UpdateKinematic(bool Kinematic)
        {
            isKinematic = Kinematic;
            return isKinematic == Kinematic;
        }

        [HideFromIl2Cpp]
        internal void OverrideInternalKinematic(bool Kinematic)
        {
            OrigKinematic = Kinematic;
        }

        internal Rigidbody GetRigidbody()
        {
            return body;
        }

        internal SyncPhysics Get_SyncPhysics()
        {
            return Internal_Sync;
        }

        internal void Respawn_Item()
        {
            if (!obj.isOwner())
            {
                obj.TakeOwnership();
            }
            Internal_Sync.RespawnItem();
        }


		private void Run_OnRigidBodyPropertyChanged()
		{
			OnRigidBodyPropertyChanged?.Invoke();
		}

		private void Run_OnRigidbodyControllerOnUpdate()
		{
			OnRigidbodyControllerOnUpdate?.Invoke();
		}


		internal void SetRigidBodyPropertyChanged(Action action)
		{
			OnRigidBodyPropertyChanged += action;
		}

		internal void SetOnRigidbodyControllerOnUpdate(Action action)
		{
			OnRigidbodyControllerOnUpdate += action;
		}


		internal void RemoveActionEvents()
		{
			OnRigidBodyPropertyChanged = null;
			OnRigidbodyControllerOnUpdate = null;
		}


		private event Action? OnRigidbodyControllerOnUpdate;


		private event Action? OnRigidBodyPropertyChanged;

		[HideFromIl2Cpp]
		internal SyncPhysics Internal_Sync { get; private set; } = null;

        private GameObject obj = null;
        private Rigidbody body = null;
		private bool _EditMode = false;

		private bool _OrigKinematic = false;
		private bool _OrigUseGravity = false;
		private bool _OrigDetectCollisions = true;
		private float _OrigDrag = 0f;
		private float _OrigAngularDrag = 0f;
		private RigidbodyConstraints _OrigConstraints;


		private bool _Forced_RigidBody;
		private bool _useGravity = false;
		private bool _isKinematic = false;
		private bool _PreventOthersFromGrabbing = false;
		private bool _DetectCollisions = true;
		private float _Drag = 0f;
		private float _AngularDrag = 0f;

		private RigidbodyConstraints _Constraints;

		private bool OrigKinematic
		{
			get
			{
				return _OrigKinematic;
			}
			set
			{
				_OrigKinematic = value;

			}
		}
		private bool OrigUseGravity
		{
			get
			{
				return _OrigUseGravity;
			}
			set
			{
				_OrigUseGravity = value;
			}
		}
		private bool OrigDetectCollisions
		{
			get
			{
				return _OrigDetectCollisions;
			}
			set
			{
				_OrigDetectCollisions = value;
			}
		}
		private float OrigDrag
		{
			get
			{
				return _OrigDrag;
			}
			set
			{
				_OrigDrag = value;
			}
		}
		private float OrigAngularDrag
		{
			get
			{
				return _OrigAngularDrag;
			}
			set
			{
				_OrigAngularDrag = value;
			}
		}
		private RigidbodyConstraints OrigConstraints
		{
			get
			{
				return _OrigConstraints;
			}
			set
			{
				_OrigConstraints = value;
			}
		}

		internal bool EditMode
		{
			get
			{
				return _EditMode;
			}
			set
			{
				_EditMode = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal bool Forced_RigidBody
		{
			get
			{
				return _Forced_RigidBody;
			}
			set
			{
				_Forced_RigidBody = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal bool useGravity
		{
			get
			{
				return _useGravity;
			}
			set
			{
				_useGravity = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal bool isKinematic
		{
			get
			{
				return _isKinematic;
			}
			set
			{
				_isKinematic = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal bool PreventOthersFromGrabbing
		{
			get
			{
				return _PreventOthersFromGrabbing;
			}
			set
			{
				_PreventOthersFromGrabbing = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal bool DetectCollisions
		{
			get
			{
				return _DetectCollisions;
			}
			set
			{
				_DetectCollisions = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal float Drag
		{
			get
			{
				return _Drag;
			}
			set
			{
				_Drag = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal float AngularDrag
		{
			get
			{
				return _AngularDrag;
			}
			set
			{
				_AngularDrag = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}
		internal RigidbodyConstraints Constraints
		{
			get
			{
				return _Constraints;
			}
			set
			{
				_Constraints = value;
				Run_OnRigidBodyPropertyChanged();
			}
		}

	}
}