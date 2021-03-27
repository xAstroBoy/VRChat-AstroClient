using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.ConsoleUtils;
using AstroClient.ItemTweaker;
using AstroClient.SyncPhysicExt;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.components
{
    public class RigidBodyController : MonoBehaviour
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
                RigidBody = GetComponent<Rigidbody>();
                Sync = GetComponent<SyncPhysics>();

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
            }
            else
            {
                ModConsole.DebugLog($"Backupping from RigidBody properties for object  {obj.name}");
                OrigKinematic = true;
                OrigUseGravity = RigidBody.useGravity;
                OrigDetectCollisions = RigidBody.detectCollisions;
                OrigConstraints = RigidBody.constraints;
                OrigDrag = RigidBody.drag;
                OrigAngularDrag = RigidBody.angularDrag;
                isKinematic = RigidBody.isKinematic;
                useGravity = RigidBody.useGravity;
                DetectCollisions = RigidBody.detectCollisions;
                AngularDrag = RigidBody.angularDrag;
                Drag = RigidBody.drag;
                Constraints = RigidBody.constraints;
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
                if (ForcedMode)
                {
                    if (Sync == null)
                    {
                        Sync = obj.AddComponent<SyncPhysics>();
                    }
                }
                if (PreventOthersFromGrabbing)
                {
                    if (!OnlineEditor.IsLocalPlayerOwner(obj))
                    {
                        OnlineEditor.TakeObjectOwnership(obj);
                    }
                }
                if (obj.transform == Tweaker_Object.CurrentSelectedObject)
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
                    else
                    {
                        if (Sync.GetRigidBody() == null)
                        {
                            ModConsole.DebugLog($"Adding New Rigidbody to : {obj.name}, Due to Sync RigidBody Being null!");
                            Sync.SpawnRigidBody();
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
                    else
                    {
                        if (Sync.GetRigidBody() == null)
                        {
                            ModConsole.DebugLog($"Adding New Rigidbody to : {obj.name}, Due to Sync RigidBody Being null!");
                            Sync.SpawnRigidBody();
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
        private Rigidbody RigidBody = null;

        internal bool EditMode = false;

        private bool OrigKinematic = false;
        private bool OrigUseGravity = false;
        private bool OrigDetectCollisions = true;
        private float OrigDrag = 0f;
        private float OrigAngularDrag = 0f;
        private RigidbodyConstraints OrigConstraints;

        internal bool ForcedMode;

        internal bool useGravity = false;
        internal bool isKinematic = false;
        internal bool PreventOthersFromGrabbing = false;
        internal bool DetectCollisions = true;
        internal float Drag = 0f;
        internal float AngularDrag = 0f;

        internal RigidbodyConstraints Constraints;
    }
}