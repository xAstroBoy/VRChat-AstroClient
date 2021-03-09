using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.ConsoleUtils;
using System;
using System.Runtime.InteropServices;
using UnhollowerBaseLib.Attributes;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC.SDKBase;
using VRCSDK2;
using static AstroClient.AstroUtils.ItemTweaker.ItemTweakerMain;


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
                if (Sync.field_Private_Rigidbody_0 != null)
                {
                    ModConsole.DebugLog($"Backupping from Sync.field_Private_Rigidbody_0 properties for object  {obj.name}");
                    
                    if (Sync.field_Private_Rigidbody_0.useGravity != OrigUseGravity)
                    {
                        OrigUseGravity = Sync.field_Private_Rigidbody_0.useGravity;
                    }
                    if (Sync.field_Private_Rigidbody_0.useGravity != useGravity)
                    {
                        useGravity = Sync.field_Private_Rigidbody_0.useGravity;
                    }

                    if (Sync.field_Private_Rigidbody_0.isKinematic != OrigKinematic)
                    {
                        OrigKinematic = Sync.field_Private_Rigidbody_0.isKinematic;
                    }
                    if (Sync.field_Private_Rigidbody_0.isKinematic != isKinematic)
                    {
                        isKinematic = Sync.field_Private_Rigidbody_0.isKinematic;
                    }


                    if (Sync.field_Private_Rigidbody_0.constraints != OrigConstraints)
                    {
                        OrigConstraints = Sync.field_Private_Rigidbody_0.constraints;
                    }
                    if (Sync.field_Private_Rigidbody_0.constraints != Constraints)
                    {
                        Constraints = Sync.field_Private_Rigidbody_0.constraints;
                    }

                    if (Sync.field_Private_Rigidbody_0.detectCollisions != OrigDetectCollisions)
                    {
                        OrigDetectCollisions = Sync.field_Private_Rigidbody_0.detectCollisions;
                    }
                    if (Sync.field_Private_Rigidbody_0.detectCollisions != DetectCollisions)
                    {
                        DetectCollisions = Sync.field_Private_Rigidbody_0.detectCollisions;
                    }

                    if (Sync.field_Private_Rigidbody_0.drag != OrigDrag)
                    {
                        OrigDrag = Sync.field_Private_Rigidbody_0.drag;
                    }
                    if (Sync.field_Private_Rigidbody_0.drag != Drag)
                    {
                        Drag = Sync.field_Private_Rigidbody_0.drag;
                    }

                    if (Sync.field_Private_Rigidbody_0.angularDrag != OrigAngularDrag)
                    {
                        OrigAngularDrag = Sync.field_Private_Rigidbody_0.angularDrag;
                    }
                    if (Sync.field_Private_Rigidbody_0.angularDrag != AngularDrag)
                    {
                        AngularDrag = Sync.field_Private_Rigidbody_0.angularDrag;
                    }
                }
            }
            else
            {
                ModConsole.DebugLog($"Backupping from RigidBody properties for object  {obj.name}");
                OrigKinematic = RigidBody.isKinematic;
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
                Sync.field_Private_Rigidbody_0.useGravity = OrigUseGravity;
                Sync.field_Private_Rigidbody_0.isKinematic = OrigKinematic;
                Sync.field_Private_Rigidbody_0.constraints = OrigConstraints;
                Sync.field_Private_Rigidbody_0.detectCollisions = OrigDetectCollisions;
                Sync.field_Private_Rigidbody_0.drag = OrigDrag;
                Sync.field_Private_Rigidbody_0.angularDrag = OrigAngularDrag;
            }
            RefreshEdits();
            EditMode = false;
        }

        // Update is called once per frame
        public void Update()
        {
            try
            {

                //if (RigidBody == null)
                //{
                //    RigidBody = obj.AddComponent<Rigidbody>();
                //    BackupBasicBody();
                //}
                //if (objsync == null)
                //{
                //    objsync = obj.AddComponent<VRC_ObjectSync>();
                //}
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
                if (obj == HandsUtils.GameObjectToEdit)
                {
                    if (ItemTweakerMain.ProtectionInteractor != null)
                    {
                        ItemTweakerMain.ProtectionInteractor.setToggleState(PreventOthersFromGrabbing);
                    }
                }

                if (obj == HandsUtils.GameObjectToEdit)
                {
                    if (!Forces.UpdateFreezeAllConstraints(Constraints))
                    {
                        Forces.UpdatePositionConstraints(Constraints);
                        Forces.UpdateRotationSection(Constraints);
                    }
                }

                if (EditMode)
                {

                    // TEST WITHOUT THIS, IF IT WORKS AND IS LIVE, THEN THE REST IS USELESS.
                    //if (RigidBody != null)
                    //{
                    //    if (RigidBody.useGravity != useGravity)
                    //    {
                    //        RigidBody.useGravity = useGravity;
                    //    }
                    //    if (RigidBody.isKinematic != isKinematic)
                    //    {
                    //        RigidBody.isKinematic = isKinematic;
                    //    }
                    //    if (RigidBody.constraints != Constraints)
                    //    {
                    //        RigidBody.constraints = Constraints;
                    //    }

                    //    if (RigidBody.detectCollisions != DetectCollisions)
                    //    {
                    //        RigidBody.detectCollisions = DetectCollisions;
                    //    }
                    //    if (RigidBody.drag != Drag)
                    //    {
                    //        RigidBody.drag = Drag;
                    //    }
                    //    if (RigidBody.angularDrag != AngularDrag)
                    //    {
                    //        RigidBody.angularDrag = AngularDrag;
                    //    }
                    //}
                    //if (objsync != null)
                    //{
                    //    if (objsync.useGravity != useGravity)
                    //    {
                    //        objsync.useGravity = useGravity;
                    //    }
                    //    if (objsync.isKinematic != isKinematic)
                    //    {
                    //        objsync.isKinematic = isKinematic;
                    //    }
                    //}
                    if (Sync != null)
                    {
                        if (Sync.field_Private_Rigidbody_0.useGravity != useGravity)
                        {
                            Sync.field_Private_Rigidbody_0.useGravity = useGravity;
                            RefreshEdits();
                        }
                        if (Sync.field_Private_Rigidbody_0.isKinematic != isKinematic)
                        {
                            Sync.field_Private_Rigidbody_0.isKinematic = isKinematic;
                            RefreshEdits();
                        }
                        if (Sync.field_Private_Rigidbody_0.constraints != Constraints)
                        {
                            Sync.field_Private_Rigidbody_0.constraints = Constraints;
                            RefreshEdits();
                        }
                        if (Sync.field_Private_Rigidbody_0.detectCollisions != DetectCollisions)
                        {
                            Sync.field_Private_Rigidbody_0.detectCollisions = DetectCollisions;
                             RefreshEdits();
                        }
                        if (Sync.field_Private_Rigidbody_0.drag != Drag)
                        {
                            Sync.field_Private_Rigidbody_0.drag = Drag;
                             RefreshEdits();
                        }
                        if (Sync.field_Private_Rigidbody_0.angularDrag != AngularDrag)
                        {
                            Sync.field_Private_Rigidbody_0.angularDrag = AngularDrag;
                             RefreshEdits();
                        }
                    }
                }
                else
                {
                    if (Sync != null)
                    {
                        if (Sync.field_Private_Rigidbody_0.useGravity != OrigUseGravity)
                        {
                            OrigUseGravity = Sync.field_Private_Rigidbody_0.useGravity;
                        }
                        if (Sync.field_Private_Rigidbody_0.useGravity != useGravity)
                        {
                            useGravity = Sync.field_Private_Rigidbody_0.useGravity;
                        }

                        if (Sync.field_Private_Rigidbody_0.isKinematic != OrigKinematic)
                        {
                            OrigKinematic = Sync.field_Private_Rigidbody_0.isKinematic;
                        }
                        if (Sync.field_Private_Rigidbody_0.isKinematic != isKinematic)
                        {
                            isKinematic = Sync.field_Private_Rigidbody_0.isKinematic;
                        }


                        if (Sync.field_Private_Rigidbody_0.constraints != OrigConstraints)
                        {
                            OrigConstraints = Sync.field_Private_Rigidbody_0.constraints;
                        }
                        if (Sync.field_Private_Rigidbody_0.constraints != Constraints)
                        {
                            Constraints = Sync.field_Private_Rigidbody_0.constraints;
                        }

                        if (Sync.field_Private_Rigidbody_0.detectCollisions != OrigDetectCollisions)
                        {
                            OrigDetectCollisions = Sync.field_Private_Rigidbody_0.detectCollisions;
                        }
                        if (Sync.field_Private_Rigidbody_0.detectCollisions != DetectCollisions)
                        {
                            DetectCollisions = Sync.field_Private_Rigidbody_0.detectCollisions;
                        }

                        if (Sync.field_Private_Rigidbody_0.drag != OrigDrag)
                        {
                            OrigDrag = Sync.field_Private_Rigidbody_0.drag;
                        }
                        if (Sync.field_Private_Rigidbody_0.drag != Drag)
                        {
                            Drag = Sync.field_Private_Rigidbody_0.drag;
                        }

                        if (Sync.field_Private_Rigidbody_0.angularDrag != OrigAngularDrag)
                        {
                            OrigAngularDrag = Sync.field_Private_Rigidbody_0.angularDrag;
                        }
                        if (Sync.field_Private_Rigidbody_0.angularDrag != AngularDrag)
                        {
                            AngularDrag = Sync.field_Private_Rigidbody_0.angularDrag;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                ModConsole.DebugError($"RigidBodyController assigned to  {obj.name} thrown a exception {e}");
            }
        }

        [HideFromIl2Cpp]

        internal void RefreshEdits()
        {
            if (Sync != null)
            {
                Sync.Method_Public_Void_PDM_3();
            }
            else
            {
                ModConsole.DebugError($"Failed to refresh {obj.name} SyncPhysic properties!");
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