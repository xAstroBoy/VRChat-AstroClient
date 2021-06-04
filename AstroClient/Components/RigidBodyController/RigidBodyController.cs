namespace AstroClient.Components
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Extensions;
	using AstroClient.ItemTweaker;
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
                    if (Forced_SyncPhysic)
                    {
                        if (Internal_Sync == null)
                        {
                            Internal_Sync = obj.AddComponent<SyncPhysics>();
                        }

                        if (Internal_Sync.field_Private_Rigidbody_0 == null)
                        {
                            if (obj.GetComponent<Rigidbody>() != null && Internal_Sync.field_Private_Rigidbody_0 == null)
                            {
                                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody in SyncPhysic as is Null..");
                                Internal_Sync.field_Private_Rigidbody_0 = obj.GetComponent<Rigidbody>();
                                return;
                            }

                            if (obj.GetComponentInChildren<Rigidbody>() != null && Internal_Sync.field_Private_Rigidbody_0 == null)
                            {
                                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Rigidbody in SyncPhysic as is Null..");
                                Internal_Sync.field_Private_Rigidbody_0 = obj.GetComponentInChildren<Rigidbody>();
                                return;
                            }
                            if (obj.GetComponentInChildren<Rigidbody>() == null && obj.GetComponent<Rigidbody>() == null && Internal_Sync.field_Private_Rigidbody_0 == null)
                            {
                                ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} Spawned Rigidbody in SyncPhysic as is Null..");
                                body = obj.AddComponent<Rigidbody>();
                                Internal_Sync.field_Private_Rigidbody_0 = body;
                                body.isKinematic = true;
                                return;
                            }

                            if (Internal_Sync.field_Private_VRC_Pickup_0 == null)
                            {
                                if (obj.GetComponent<VRC.SDKBase.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
                                {
                                    ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
                                    Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponent<VRC.SDKBase.VRC_Pickup>();
                                    return;
                                }

                                if (obj.GetComponentInChildren<VRC.SDKBase.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
                                {
                                    ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
                                    Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponentInChildren<VRC.SDKBase.VRC_Pickup>();
                                    return;
                                }
                                if (obj.GetComponent<VRCSDK2.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
                                {
                                    ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
                                    Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponent<VRCSDK2.VRC_Pickup>();
                                    return;
                                }

                                if (obj.GetComponentInChildren<VRCSDK2.VRC_Pickup>() != null && Internal_Sync.field_Private_VRC_Pickup_0 == null)
                                {
                                    ModConsole.DebugLog($"RigidBodyController : Bound Object {obj.name} VRC_Pickup in SyncPhysic as is Null..");
                                    Internal_Sync.field_Private_VRC_Pickup_0 = obj.GetComponentInChildren<VRCSDK2.VRC_Pickup>();
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
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    if (ItemTweakerMain.ProtectionInteractor != null)
                    {
                        ItemTweakerMain.ProtectionInteractor.SetToggleState(PreventOthersFromGrabbing);
                    }

                    if (!Forces.UpdateFreezeAllConstraints(Constraints))
                    {
                        Forces.UpdatePositionConstraints(Constraints);
                        Forces.UpdateRotationSection(Constraints);
                    }
                    if (obj.transform != null)
                    {
                        ItemTweakerMain.CurrentObjectCoordsBtn.SetButtonText($"X: {obj.transform.position.x} \n Y: {obj.transform.position.y} \n Z: {obj.transform.position.z}");
                    }
                }

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

        [HideFromIl2Cpp]
        internal SyncPhysics Internal_Sync { get; private set; } = null;

        private GameObject obj = null;
        private Rigidbody body = null;
        private VRCObjectSync SDK3Sync = null;
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