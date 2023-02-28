using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Effects;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Player;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Tether;
using AstroClient.ClientAttributes;
using AstroClient.ClientResources.Loaders;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Controller
{
    [RegisterComponent]
    internal class VRTetherPrefabController : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();
        public VRTetherPrefabController(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }


        internal TetherProperties Properties { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal TrackedObject HeadRig { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal TetherController LeftController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal VRC_AstroPickup LeftTetherPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal TetherPickupInput LeftTetherPickupInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal ExampleLineRenderer LeftLineRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal ExampleAnimator LeftAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal TetherController RightController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal VRC_AstroPickup RightTetherPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal TetherPickupInput RightTetherPickupInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal ExampleLineRenderer RightLineRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal ExampleAnimator RightAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal void Start()
        {
            if (Root != null)
            {
                Properties = Root.GetOrAddComponent<TetherProperties>();

                if (Root_HeadRig != null)
                {
                    HeadRig = Root_HeadRig.GetOrAddComponent<TrackedObject>();
                    if (HeadRig != null)
                    {
                        HeadRig.vrEnabled = true;
                        HeadRig.vrEnabledObject = Root_HeadRig_EnableParent.gameObject;
                        HeadRig.trackingType = VRCPlayerApi.TrackingDataType.Head;
                    }
                }

                if (Root_LeftTetherPickup_Forward_Controller != null)
                {
                    LeftController = Root_LeftTetherPickup_Forward_Controller.GetOrAddComponent<TetherController>();
                    if (LeftController != null)
                    {
                        LeftController.properties = Properties;
                    }
                }
                if (Root_LeftTetherPickup != null)
                {
                    LeftTetherPickup = Root_LeftTetherPickup.GetOrAddComponent<VRC_AstroPickup>();
                    if (LeftTetherPickup != null)
                    {
                        LeftTetherPickup.PickupController.ForceComponent = true;
                        LeftTetherPickup.PickupController.MomentumTransferMethod = ForceMode.Force;
                        LeftTetherPickup.PickupController.DisallowTheft = false;
                        LeftTetherPickup.PickupController.ExactGun = Root_LeftTetherPickup;
                        LeftTetherPickup.PickupController.orientation = VRC_Pickup.PickupOrientation.Gun;
                        LeftTetherPickup.PickupController.AutoHold = VRC_Pickup.AutoHoldMode.Yes;
                        LeftTetherPickup.interactText = "";
                        LeftTetherPickup.PickupController.UseText = "Grapple";
                        LeftTetherPickup.PickupController.ThrowVelocityBoostMinSpeed = 1f;
                        LeftTetherPickup.PickupController.ThrowVelocityBoostScale = 1f;
                        LeftTetherPickup.PickupController.proximity = 0.5f;

                        LeftTetherPickupInput = Root_LeftTetherPickup.GetOrAddComponent<TetherPickupInput>();
                        if (LeftTetherPickupInput != null)
                        {
                            LeftTetherPickupInput.hasReturnPoint = true;
                            LeftTetherPickupInput.returnPoint = Root_HeadRig_EnableParent_LeftReturnPoint;
                            LeftTetherPickupInput.pickup = LeftTetherPickup;
                            LeftTetherPickupInput.controller = LeftController;
                            LeftTetherPickupInput.RegisterPickupEvents();

                        }


                    }
                    if(Root_LeftTetherPickup_Forward_Line != null)
                    {
                        LeftLineRenderer = Root_LeftTetherPickup_Forward_Line.GetOrAddComponent<ExampleLineRenderer>();
                         if(LeftLineRenderer != null)
                         {
                            LeftLineRenderer.controller = LeftController;

                        }
                    }
                    if(Root_LeftTetherPickup_Forward_TetherRing != null)
                    {
                        LeftAnimator = Root_LeftTetherPickup_Forward_TetherRing.GetOrAddComponent<ExampleAnimator>();
                         if(LeftAnimator != null)
                         {
                            LeftAnimator.controller = LeftController;
                            LeftAnimator.animator = Root_LeftTetherPickup_Forward_TetherRing.GetComponent<Animator>();
                            if (Root_LeftTetherPickup_Forward_HitSpark != null)
                            {
                                LeftAnimator.endPoint = Root_LeftTetherPickup_Forward_HitSpark.gameObject;
                                LeftAnimator.particles = Root_LeftTetherPickup_Forward_HitSpark.GetComponent<ParticleSystem>();
                                LeftAnimator.hitSound = Root_LeftTetherPickup_Forward_HitSpark.GetComponent<AudioSource>();
                                LeftAnimator.heldSound = Root_LeftTetherPickup_Forward_TetherRing_Lock.GetComponent<AudioSource>();
                                LeftAnimator.unwindSound = Root_LeftTetherPickup_Forward_TetherRing_Unwind.GetComponent<AudioSource>();
                                LeftAnimator.unwindPitchLow = 0.5f;
                                LeftAnimator.unwindPitchHigh = 1f;
                            }
                        }

                    }
                }
                if (Root_RightTetherPickup_Forward_Controller != null)
                {
                    RightController = Root_RightTetherPickup_Forward_Controller.GetOrAddComponent<TetherController>();
                    if (RightController != null)
                    {
                        RightController.properties = Properties;
                    }
                }
                if (Root_RightTetherPickup != null)
                {
                    RightTetherPickup = Root_RightTetherPickup.GetOrAddComponent<VRC_AstroPickup>();
                    if (RightTetherPickup != null)
                    {
                        RightTetherPickup.PickupController.ForceComponent = true;
                        RightTetherPickup.PickupController.MomentumTransferMethod = ForceMode.Force;
                        RightTetherPickup.PickupController.DisallowTheft = false;
                        RightTetherPickup.PickupController.ExactGun = Root_RightTetherPickup;
                        RightTetherPickup.PickupController.orientation = VRC_Pickup.PickupOrientation.Gun;
                        RightTetherPickup.PickupController.AutoHold = VRC_Pickup.AutoHoldMode.Yes;
                        RightTetherPickup.interactText = "";
                        RightTetherPickup.PickupController.UseText = "Grapple";
                        RightTetherPickup.PickupController.ThrowVelocityBoostMinSpeed = 1f;
                        RightTetherPickup.PickupController.ThrowVelocityBoostScale = 1f;
                        RightTetherPickup.PickupController.proximity = 0.5f;

                        RightTetherPickupInput = Root_RightTetherPickup.GetOrAddComponent<TetherPickupInput>();
                        if (RightTetherPickupInput != null)
                        {
                            RightTetherPickupInput.hasReturnPoint = true;
                            RightTetherPickupInput.returnPoint = Root_HeadRig_EnableParent_RightReturnPoint;
                            RightTetherPickupInput.pickup = RightTetherPickup;
                            RightTetherPickupInput.controller = RightController;
                            RightTetherPickupInput.RegisterPickupEvents();
                        }


                    }
                    if (Root_RightTetherPickup_Forward_Line != null)
                    {
                        RightLineRenderer = Root_RightTetherPickup_Forward_Line.GetOrAddComponent<ExampleLineRenderer>();
                        if (RightLineRenderer != null)
                        {
                            RightLineRenderer.controller = RightController;

                        }
                    }
                    if (Root_RightTetherPickup_Forward_TetherRing != null)
                    {
                        RightAnimator = Root_RightTetherPickup_Forward_TetherRing.GetOrAddComponent<ExampleAnimator>();
                        if (RightAnimator != null)
                        {
                            RightAnimator.controller = RightController;
                            RightAnimator.animator = Root_RightTetherPickup_Forward_TetherRing.GetComponent<Animator>();
                            if (Root_RightTetherPickup_Forward_HitSpark != null)
                            {
                                RightAnimator.endPoint = Root_RightTetherPickup_Forward_HitSpark.gameObject;
                                RightAnimator.particles = Root_RightTetherPickup_Forward_HitSpark.GetComponent<ParticleSystem>();
                                RightAnimator.hitSound = Root_RightTetherPickup_Forward_HitSpark.GetComponent<AudioSource>();
                                RightAnimator.heldSound = Root_RightTetherPickup_Forward_TetherRing_Lock.GetComponent<AudioSource>();
                                RightAnimator.unwindSound = Root_RightTetherPickup_Forward_TetherRing_Unwind.GetComponent<AudioSource>();
                                RightAnimator.unwindPitchLow = 0.5f;
                                RightAnimator.unwindPitchHigh = 1f;
                            }
                        }

                    }
                }

            }
        }
        private Transform _Root;

        internal Transform Root
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root == null) _Root = this.transform;
                return _Root.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_TetherRing;

        internal Transform Root_RightTetherPickup_Forward_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_TetherRing == null) _Root_RightTetherPickup_Forward_TetherRing = Root.FindObject("RightTetherPickup/Forward/TetherRing").transform;
                return _Root_RightTetherPickup_Forward_TetherRing.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_HitSpark;

        internal Transform Root_RightTetherPickup_Forward_HitSpark
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_HitSpark == null) _Root_RightTetherPickup_Forward_HitSpark = Root.FindObject("RightTetherPickup/Forward/HitSpark").transform;
                return _Root_RightTetherPickup_Forward_HitSpark.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_TetherRing_Armature_SecondRing;

        internal Transform Root_LeftTetherPickup_Forward_TetherRing_Armature_SecondRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_TetherRing_Armature_SecondRing == null) _Root_LeftTetherPickup_Forward_TetherRing_Armature_SecondRing = Root.FindObject("LeftTetherPickup/Forward/TetherRing/Armature/SecondRing").transform;
                return _Root_LeftTetherPickup_Forward_TetherRing_Armature_SecondRing.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_TetherRing_Armature_SecondRing;

        internal Transform Root_RightTetherPickup_Forward_TetherRing_Armature_SecondRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_TetherRing_Armature_SecondRing == null) _Root_RightTetherPickup_Forward_TetherRing_Armature_SecondRing = Root.FindObject("RightTetherPickup/Forward/TetherRing/Armature/SecondRing").transform;
                return _Root_RightTetherPickup_Forward_TetherRing_Armature_SecondRing.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_TetherRing_Armature_FirstRing;

        internal Transform Root_RightTetherPickup_Forward_TetherRing_Armature_FirstRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_TetherRing_Armature_FirstRing == null) _Root_RightTetherPickup_Forward_TetherRing_Armature_FirstRing = Root.FindObject("RightTetherPickup/Forward/TetherRing/Armature/FirstRing").transform;
                return _Root_RightTetherPickup_Forward_TetherRing_Armature_FirstRing.transform;
            }
        }

        private Transform _Root_HeadRig;

        internal Transform Root_HeadRig
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig == null) _Root_HeadRig = Root.FindObject("HeadRig").transform;
                return _Root_HeadRig.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward;

        internal Transform Root_RightTetherPickup_Forward
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward == null) _Root_RightTetherPickup_Forward = Root.FindObject("RightTetherPickup/Forward").transform;
                return _Root_RightTetherPickup_Forward.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_LeftReturnPoint;

        internal Transform Root_HeadRig_EnableParent_LeftReturnPoint
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_LeftReturnPoint == null) _Root_HeadRig_EnableParent_LeftReturnPoint = Root.FindObject("HeadRig/EnableParent/LeftReturnPoint").transform;
                return _Root_HeadRig_EnableParent_LeftReturnPoint.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent;

        internal Transform Root_HeadRig_EnableParent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent == null) _Root_HeadRig_EnableParent = Root.FindObject("HeadRig/EnableParent").transform;
                return _Root_HeadRig_EnableParent.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward;

        internal Transform Root_LeftTetherPickup_Forward
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward == null) _Root_LeftTetherPickup_Forward = Root.FindObject("LeftTetherPickup/Forward").transform;
                return _Root_LeftTetherPickup_Forward.transform;
            }
        }

        private Transform _Root_LeftTetherPickup;

        internal Transform Root_LeftTetherPickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup == null) _Root_LeftTetherPickup = Root.FindObject("LeftTetherPickup").transform;
                return _Root_LeftTetherPickup.transform;
            }
        }

        private Transform _Root_RightTetherPickup;

        internal Transform Root_RightTetherPickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup == null) _Root_RightTetherPickup = Root.FindObject("RightTetherPickup").transform;
                return _Root_RightTetherPickup.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_Line;

        internal Transform Root_RightTetherPickup_Forward_Line
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_Line == null) _Root_RightTetherPickup_Forward_Line = Root.FindObject("RightTetherPickup/Forward/Line").transform;
                return _Root_RightTetherPickup_Forward_Line.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_Controller;

        internal Transform Root_LeftTetherPickup_Forward_Controller
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_Controller == null) _Root_LeftTetherPickup_Forward_Controller = Root.FindObject("LeftTetherPickup/Forward/Controller").transform;
                return _Root_LeftTetherPickup_Forward_Controller.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_TetherRing;

        internal Transform Root_LeftTetherPickup_Forward_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_TetherRing == null) _Root_LeftTetherPickup_Forward_TetherRing = Root.FindObject("LeftTetherPickup/Forward/TetherRing").transform;
                return _Root_LeftTetherPickup_Forward_TetherRing.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_TetherRing_Unwind;

        internal Transform Root_LeftTetherPickup_Forward_TetherRing_Unwind
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_TetherRing_Unwind == null) _Root_LeftTetherPickup_Forward_TetherRing_Unwind = Root.FindObject("LeftTetherPickup/Forward/TetherRing/Unwind").transform;
                return _Root_LeftTetherPickup_Forward_TetherRing_Unwind.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_RightReturnPoint;

        internal Transform Root_HeadRig_EnableParent_RightReturnPoint
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_RightReturnPoint == null) _Root_HeadRig_EnableParent_RightReturnPoint = Root.FindObject("HeadRig/EnableParent/RightReturnPoint").transform;
                return _Root_HeadRig_EnableParent_RightReturnPoint.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_TetherRing_Unwind;

        internal Transform Root_RightTetherPickup_Forward_TetherRing_Unwind
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_TetherRing_Unwind == null) _Root_RightTetherPickup_Forward_TetherRing_Unwind = Root.FindObject("RightTetherPickup/Forward/TetherRing/Unwind").transform;
                return _Root_RightTetherPickup_Forward_TetherRing_Unwind.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_TetherRing_TetherRing;

        internal Transform Root_RightTetherPickup_Forward_TetherRing_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_TetherRing_TetherRing == null) _Root_RightTetherPickup_Forward_TetherRing_TetherRing = Root.FindObject("RightTetherPickup/Forward/TetherRing/TetherRing").transform;
                return _Root_RightTetherPickup_Forward_TetherRing_TetherRing.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_TetherRing_Armature;

        internal Transform Root_LeftTetherPickup_Forward_TetherRing_Armature
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_TetherRing_Armature == null) _Root_LeftTetherPickup_Forward_TetherRing_Armature = Root.FindObject("LeftTetherPickup/Forward/TetherRing/Armature").transform;
                return _Root_LeftTetherPickup_Forward_TetherRing_Armature.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_HitSpark;

        internal Transform Root_LeftTetherPickup_Forward_HitSpark
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_HitSpark == null) _Root_LeftTetherPickup_Forward_HitSpark = Root.FindObject("LeftTetherPickup/Forward/HitSpark").transform;
                return _Root_LeftTetherPickup_Forward_HitSpark.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_TetherRing_Lock;

        internal Transform Root_LeftTetherPickup_Forward_TetherRing_Lock
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_TetherRing_Lock == null) _Root_LeftTetherPickup_Forward_TetherRing_Lock = Root.FindObject("LeftTetherPickup/Forward/TetherRing/Lock").transform;
                return _Root_LeftTetherPickup_Forward_TetherRing_Lock.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_TetherRing_Armature;

        internal Transform Root_RightTetherPickup_Forward_TetherRing_Armature
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_TetherRing_Armature == null) _Root_RightTetherPickup_Forward_TetherRing_Armature = Root.FindObject("RightTetherPickup/Forward/TetherRing/Armature").transform;
                return _Root_RightTetherPickup_Forward_TetherRing_Armature.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_Line;

        internal Transform Root_LeftTetherPickup_Forward_Line
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_Line == null) _Root_LeftTetherPickup_Forward_Line = Root.FindObject("LeftTetherPickup/Forward/Line").transform;
                return _Root_LeftTetherPickup_Forward_Line.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_TetherRing_Lock;

        internal Transform Root_RightTetherPickup_Forward_TetherRing_Lock
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_TetherRing_Lock == null) _Root_RightTetherPickup_Forward_TetherRing_Lock = Root.FindObject("RightTetherPickup/Forward/TetherRing/Lock").transform;
                return _Root_RightTetherPickup_Forward_TetherRing_Lock.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_TetherRing_TetherRing;

        internal Transform Root_LeftTetherPickup_Forward_TetherRing_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_TetherRing_TetherRing == null) _Root_LeftTetherPickup_Forward_TetherRing_TetherRing = Root.FindObject("LeftTetherPickup/Forward/TetherRing/TetherRing").transform;
                return _Root_LeftTetherPickup_Forward_TetherRing_TetherRing.transform;
            }
        }

        private Transform _Root_LeftTetherPickup_Forward_TetherRing_Armature_FirstRing;

        internal Transform Root_LeftTetherPickup_Forward_TetherRing_Armature_FirstRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_LeftTetherPickup_Forward_TetherRing_Armature_FirstRing == null) _Root_LeftTetherPickup_Forward_TetherRing_Armature_FirstRing = Root.FindObject("LeftTetherPickup/Forward/TetherRing/Armature/FirstRing").transform;
                return _Root_LeftTetherPickup_Forward_TetherRing_Armature_FirstRing.transform;
            }
        }

        private Transform _Root_RightTetherPickup_Forward_Controller;

        internal Transform Root_RightTetherPickup_Forward_Controller
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_RightTetherPickup_Forward_Controller == null) _Root_RightTetherPickup_Forward_Controller = Root.FindObject("RightTetherPickup/Forward/Controller").transform;
                return _Root_RightTetherPickup_Forward_Controller.transform;
            }
        }
    }
}