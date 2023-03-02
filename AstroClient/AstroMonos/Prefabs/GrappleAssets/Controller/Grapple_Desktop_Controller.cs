using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Effects;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Player;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Tether;
using AstroClient.ClientAttributes;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Controller
{
    [RegisterComponent]
    internal class Grapple_Desktop_Controller : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public Grapple_Desktop_Controller(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal TrackedObject HeadRig { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal KeyToggle KeyToggle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal TetherController LeftController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal TetherController RightController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal ExampleLineRenderer LeftLineRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal ExampleAnimator LeftAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        
        internal TetherAxisInput LeftAxis { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        
        internal ExampleLineRenderer RightLineRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal ExampleAnimator RightAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal TetherAxisInput RightAxis { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }


        internal void Start()
        {
            if (Root != null)
            {
                if (Root_HeadRig != null)
                {
                    HeadRig = Root_HeadRig.GetOrAddComponent<TrackedObject>();
                    if (HeadRig != null)
                    {
                        HeadRig.vrEnabled = false;
                        HeadRig.vrEnabledObject = Root_HeadRig_EnableParent.gameObject;
                        HeadRig.trackingType = VRCPlayerApi.TrackingDataType.Head;
                    }
                }
                if(Root_HeadRig_EnableParent_Left_Controller != null)
                {
                    LeftController = Root_HeadRig_EnableParent_Left_Controller.GetOrAddComponent<TetherController>();

                }
                if (Root_HeadRig_EnableParent_Right_Controller != null)
                {
                    RightController = Root_HeadRig_EnableParent_Right_Controller.GetOrAddComponent<TetherController>();

                }

                if (Root_HeadRig_EnableParent != null)
                {
                    KeyToggle = Root_HeadRig_EnableParent.GetOrAddComponent<KeyToggle>();
                    if (KeyToggle != null)
                    {
                        KeyToggle.initialState = false;
                        KeyToggle.key = KeyCode.G;
                        KeyToggle.toggleObject = new []
                        {
                            Root_HeadRig_EnableParent_Left.gameObject,
                            Root_HeadRig_EnableParent_Right.gameObject
                        };
                    }
                }

                if (Root_HeadRig_EnableParent_Left_Line != null)
                {
                    LeftLineRenderer = Root_HeadRig_EnableParent_Left_Line.GetOrAddComponent<ExampleLineRenderer>();
                    if (LeftLineRenderer != null)
                    {
                        LeftLineRenderer.controller = LeftController;
                    }
                }
                if(Root_HeadRig_EnableParent_Left != null)
                {
                    LeftAxis = Root_HeadRig_EnableParent_Left.GetOrAddComponent<TetherAxisInput>();
                    if(LeftAxis != null)
                    {
                        LeftAxis.controller = LeftController;
                        LeftAxis.tetherInput = "Fire1";
                    }
                }
                if (Root_HeadRig_EnableParent_Left_TetherRing != null)
                {
                    LeftAnimator = Root_HeadRig_EnableParent_Left_TetherRing.GetOrAddComponent<ExampleAnimator>();
                    if (LeftAnimator != null)
                    {
                        LeftAnimator.controller = LeftController;
                        LeftAnimator.animator = Root_HeadRig_EnableParent_Left_TetherRing.GetComponent<Animator>();
                        if (Root_HeadRig_EnableParent_Left_HitSpark != null)
                        {
                            LeftAnimator.endPoint = Root_HeadRig_EnableParent_Left_HitSpark.gameObject;
                            LeftAnimator.particles = Root_HeadRig_EnableParent_Left_HitSpark.GetComponent<ParticleSystem>();
                            LeftAnimator.hitSound = Root_HeadRig_EnableParent_Left_HitSpark.GetComponent<AudioSource>();
                            LeftAnimator.heldSound = Root_HeadRig_EnableParent_Left_TetherRing_Lock.GetComponent<AudioSource>();
                            LeftAnimator.unwindSound = Root_HeadRig_EnableParent_Left_TetherRing_Unwind.GetComponent<AudioSource>();
                        }
                    }

                }
                if(Root_HeadRig_EnableParent_Right_Line != null)
                {
                    RightLineRenderer = Root_HeadRig_EnableParent_Right_Line.GetOrAddComponent<ExampleLineRenderer>();
                    if (RightLineRenderer != null)
                    {
                        RightLineRenderer.controller = RightController;
                    }
                }
                if (Root_HeadRig_EnableParent_Right != null)
                {
                    RightAxis = Root_HeadRig_EnableParent_Right.GetOrAddComponent<TetherAxisInput>();
                    if (RightAxis != null)
                    {
                        RightAxis.controller = RightController;
                        RightAxis.tetherInput = "Fire2";
                    }
                }


                if (Root_HeadRig_EnableParent_Right_TetherRing != null)
                {
                    RightAnimator = Root_HeadRig_EnableParent_Right_TetherRing.GetOrAddComponent<ExampleAnimator>();
                    if (RightAnimator != null)
                    {
                        RightAnimator.controller = RightController;
                        RightAnimator.animator = Root_HeadRig_EnableParent_Right_TetherRing.GetComponent<Animator>();
                        if (Root_HeadRig_EnableParent_Right_HitSpark != null)
                        {
                            RightAnimator.endPoint = Root_HeadRig_EnableParent_Right_HitSpark.gameObject;
                            RightAnimator.particles = Root_HeadRig_EnableParent_Right_HitSpark.GetComponent<ParticleSystem>();
                            RightAnimator.hitSound = Root_HeadRig_EnableParent_Right_HitSpark.GetComponent<AudioSource>();
                            RightAnimator.heldSound = Root_HeadRig_EnableParent_Right_TetherRing_Lock.GetComponent<AudioSource>();
                            RightAnimator.unwindSound = Root_HeadRig_EnableParent_Right_TetherRing_Unwind.GetComponent<AudioSource>();
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

        private Transform _Root_HeadRig_EnableParent_Right_Line;

        public Transform Root_HeadRig_EnableParent_Right_Line
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_Line == null) _Root_HeadRig_EnableParent_Right_Line = Root.FindObject("HeadRig/EnableParent/Right/Line").transform;
                return _Root_HeadRig_EnableParent_Right_Line.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_TetherRing_Lock;

        public Transform Root_HeadRig_EnableParent_Right_TetherRing_Lock
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_TetherRing_Lock == null) _Root_HeadRig_EnableParent_Right_TetherRing_Lock = Root.FindObject("HeadRig/EnableParent/Right/TetherRing/Lock").transform;
                return _Root_HeadRig_EnableParent_Right_TetherRing_Lock.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_Controller;

        public Transform Root_HeadRig_EnableParent_Right_Controller
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_Controller == null) _Root_HeadRig_EnableParent_Right_Controller = Root.FindObject("HeadRig/EnableParent/Right/Controller").transform;
                return _Root_HeadRig_EnableParent_Right_Controller.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right;

        public Transform Root_HeadRig_EnableParent_Right
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right == null) _Root_HeadRig_EnableParent_Right = Root.FindObject("HeadRig/EnableParent/Right").transform;
                return _Root_HeadRig_EnableParent_Right.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_TetherRing_Unwind;

        public Transform Root_HeadRig_EnableParent_Right_TetherRing_Unwind
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_TetherRing_Unwind == null) _Root_HeadRig_EnableParent_Right_TetherRing_Unwind = Root.FindObject("HeadRig/EnableParent/Right/TetherRing/Unwind").transform;
                return _Root_HeadRig_EnableParent_Right_TetherRing_Unwind.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_HitSpark;

        public Transform Root_HeadRig_EnableParent_Right_HitSpark
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_HitSpark == null) _Root_HeadRig_EnableParent_Right_HitSpark = Root.FindObject("HeadRig/EnableParent/Right/HitSpark").transform;
                return _Root_HeadRig_EnableParent_Right_HitSpark.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_TetherRing;

        public Transform Root_HeadRig_EnableParent_Right_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_TetherRing == null) _Root_HeadRig_EnableParent_Right_TetherRing = Root.FindObject("HeadRig/EnableParent/Right/TetherRing").transform;
                return _Root_HeadRig_EnableParent_Right_TetherRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent;

        public Transform Root_HeadRig_EnableParent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent == null) _Root_HeadRig_EnableParent = Root.FindObject("HeadRig/EnableParent").transform;
                return _Root_HeadRig_EnableParent.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_TetherRing_TetherRing;

        public Transform Root_HeadRig_EnableParent_Left_TetherRing_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_TetherRing_TetherRing == null) _Root_HeadRig_EnableParent_Left_TetherRing_TetherRing = Root.FindObject("HeadRig/EnableParent/Left/TetherRing/TetherRing").transform;
                return _Root_HeadRig_EnableParent_Left_TetherRing_TetherRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_TetherRing_Lock;

        public Transform Root_HeadRig_EnableParent_Left_TetherRing_Lock
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_TetherRing_Lock == null) _Root_HeadRig_EnableParent_Left_TetherRing_Lock = Root.FindObject("HeadRig/EnableParent/Left/TetherRing/Lock").transform;
                return _Root_HeadRig_EnableParent_Left_TetherRing_Lock.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_TetherRing;

        public Transform Root_HeadRig_EnableParent_Left_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_TetherRing == null) _Root_HeadRig_EnableParent_Left_TetherRing = Root.FindObject("HeadRig/EnableParent/Left/TetherRing").transform;
                return _Root_HeadRig_EnableParent_Left_TetherRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_TetherRing_Armature_SecondRing;

        public Transform Root_HeadRig_EnableParent_Left_TetherRing_Armature_SecondRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_TetherRing_Armature_SecondRing == null) _Root_HeadRig_EnableParent_Left_TetherRing_Armature_SecondRing = Root.FindObject("HeadRig/EnableParent/Left/TetherRing/Armature/SecondRing").transform;
                return _Root_HeadRig_EnableParent_Left_TetherRing_Armature_SecondRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_TetherRing_Armature_FirstRing;

        public Transform Root_HeadRig_EnableParent_Left_TetherRing_Armature_FirstRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_TetherRing_Armature_FirstRing == null) _Root_HeadRig_EnableParent_Left_TetherRing_Armature_FirstRing = Root.FindObject("HeadRig/EnableParent/Left/TetherRing/Armature/FirstRing").transform;
                return _Root_HeadRig_EnableParent_Left_TetherRing_Armature_FirstRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_TetherRing_Armature;

        public Transform Root_HeadRig_EnableParent_Left_TetherRing_Armature
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_TetherRing_Armature == null) _Root_HeadRig_EnableParent_Left_TetherRing_Armature = Root.FindObject("HeadRig/EnableParent/Left/TetherRing/Armature").transform;
                return _Root_HeadRig_EnableParent_Left_TetherRing_Armature.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_TetherRing_Unwind;

        public Transform Root_HeadRig_EnableParent_Left_TetherRing_Unwind
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_TetherRing_Unwind == null) _Root_HeadRig_EnableParent_Left_TetherRing_Unwind = Root.FindObject("HeadRig/EnableParent/Left/TetherRing/Unwind").transform;
                return _Root_HeadRig_EnableParent_Left_TetherRing_Unwind.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left;

        public Transform Root_HeadRig_EnableParent_Left
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left == null) _Root_HeadRig_EnableParent_Left = Root.FindObject("HeadRig/EnableParent/Left").transform;
                return _Root_HeadRig_EnableParent_Left.transform;
            }
        }

        private Transform _Root_HeadRig;

        public Transform Root_HeadRig
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig == null) _Root_HeadRig = Root.FindObject("HeadRig").transform;
                return _Root_HeadRig.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_TetherRing_Armature_FirstRing;

        public Transform Root_HeadRig_EnableParent_Right_TetherRing_Armature_FirstRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_TetherRing_Armature_FirstRing == null) _Root_HeadRig_EnableParent_Right_TetherRing_Armature_FirstRing = Root.FindObject("HeadRig/EnableParent/Right/TetherRing/Armature/FirstRing").transform;
                return _Root_HeadRig_EnableParent_Right_TetherRing_Armature_FirstRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_TetherRing_TetherRing;

        public Transform Root_HeadRig_EnableParent_Right_TetherRing_TetherRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_TetherRing_TetherRing == null) _Root_HeadRig_EnableParent_Right_TetherRing_TetherRing = Root.FindObject("HeadRig/EnableParent/Right/TetherRing/TetherRing").transform;
                return _Root_HeadRig_EnableParent_Right_TetherRing_TetherRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_TetherRing_Armature_SecondRing;

        public Transform Root_HeadRig_EnableParent_Right_TetherRing_Armature_SecondRing
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_TetherRing_Armature_SecondRing == null) _Root_HeadRig_EnableParent_Right_TetherRing_Armature_SecondRing = Root.FindObject("HeadRig/EnableParent/Right/TetherRing/Armature/SecondRing").transform;
                return _Root_HeadRig_EnableParent_Right_TetherRing_Armature_SecondRing.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Right_TetherRing_Armature;

        public Transform Root_HeadRig_EnableParent_Right_TetherRing_Armature
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Right_TetherRing_Armature == null) _Root_HeadRig_EnableParent_Right_TetherRing_Armature = Root.FindObject("HeadRig/EnableParent/Right/TetherRing/Armature").transform;
                return _Root_HeadRig_EnableParent_Right_TetherRing_Armature.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_HitSpark;

        public Transform Root_HeadRig_EnableParent_Left_HitSpark
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_HitSpark == null) _Root_HeadRig_EnableParent_Left_HitSpark = Root.FindObject("HeadRig/EnableParent/Left/HitSpark").transform;
                return _Root_HeadRig_EnableParent_Left_HitSpark.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_Line;

        public Transform Root_HeadRig_EnableParent_Left_Line
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_Line == null) _Root_HeadRig_EnableParent_Left_Line = Root.FindObject("HeadRig/EnableParent/Left/Line").transform;
                return _Root_HeadRig_EnableParent_Left_Line.transform;
            }
        }

        private Transform _Root_HeadRig_EnableParent_Left_Controller;

        public Transform Root_HeadRig_EnableParent_Left_Controller
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Root_HeadRig_EnableParent_Left_Controller == null) _Root_HeadRig_EnableParent_Left_Controller = Root.FindObject("HeadRig/EnableParent/Left/Controller").transform;
                return _Root_HeadRig_EnableParent_Left_Controller.transform;
            }
        }
    }
}