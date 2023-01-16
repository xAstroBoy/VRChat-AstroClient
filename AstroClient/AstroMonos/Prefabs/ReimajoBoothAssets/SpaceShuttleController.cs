using AstroClient;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientAttributes;
using AstroClient.ClientResources.Loaders;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace ReimajoBoothAssets
{
    // TODO: Finish and adjust to make it work without udon.
    /// <summary>
    /// This script needs to be added in "{this.transform.root.name}/ShipController"
    /// </summary>
    [RegisterComponent]
    internal class SpaceShuttleController : MonoBehaviour
    {
        private List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public SpaceShuttleController(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        #region PrefabPaths

        private GameObject _SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_frontLeftCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_upRightCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_backRightCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_backwardCTR1/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2_AudioSource == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2_AudioSource = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.R/_backwardMTRs2/AudioSource").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_downLeftCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_downFrontLeftCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_downRightCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_downFrontLeftCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_frontRightCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_frontForwardCTR1/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngineTop").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/LandingGearDoorFront.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_L;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/OrbitalManouveringEngine.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/LandingGearDoorFront.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorFront_R;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downLeftCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downLeftCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downLeftCTR = this.transform.root.FindObject("ParticlesRoot/_downLeftCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downLeftCTR;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/FrontGear1/FrontGear3").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/NavBallParent").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/LandingGearDoorRear.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_R;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_upRightCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_upFrontLeftCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_backwardCTR1/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_downFrontRightCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_frontLeftCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_upFrontRightCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3_AudioSource == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3_AudioSource = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngineTop/_backwardMTRs3/AudioSource").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontForwardCTR1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontForwardCTR1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontForwardCTR1 == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontForwardCTR1 = this.transform.root.FindObject("ParticlesRoot/_frontForwardCTR1").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontForwardCTR1;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Altimeter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Altimeter
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Altimeter == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Altimeter = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Altimeter").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Altimeter;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Throttle").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Elevator.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_L;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.L/RearGear2.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/EjectButton").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backwardCTR2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backwardCTR2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backwardCTR2 == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backwardCTR2 = this.transform.root.FindObject("ParticlesRoot/_backwardCTR2").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backwardCTR2;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.R/RearGear3.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/OrbitalManouveringEngine.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_OrbitalManouveringEngine_L;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Rudder { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Rudder
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Rudder == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Rudder = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Rudder").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Rudder;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton__desktopButton2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton__desktopButton2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton__desktopButton2 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton__desktopButton2 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/EjectButton/_desktopButton2").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton__desktopButton2;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RudderControl.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_L;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_frontForwardCTR2/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_backwardCTR2/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.R/_backwardMTRs2").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RudderControl.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RudderControl_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/FrontGear1/FrontGear2").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2;
            }
        }

        private GameObject _SpaceShuttle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle == null)
                {
                    return _SpaceShuttle = Finder.Find($"SpaceShuttle").gameObject;
                }

                return _SpaceShuttle;
            }
        }

        private GameObject _SpaceShuttle_SelfAdjustingChair_Pilot_Exit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_SelfAdjustingChair_Pilot_Exit
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_SelfAdjustingChair_Pilot_Exit == null)
                {
                    return _SpaceShuttle_SelfAdjustingChair_Pilot_Exit = this.transform.root.FindObject("SelfAdjustingChair_Pilot/Exit").gameObject;
                }

                return _SpaceShuttle_SelfAdjustingChair_Pilot_Exit;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button2").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/LandingGearDoorRear.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_LandingGearDoorRear_L;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Elevator.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Elevator_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickTrigger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickTrigger
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickTrigger == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickTrigger = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Joystick/JoystickTrigger").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickTrigger;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button1").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backLeftCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backLeftCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backLeftCTR = this.transform.root.FindObject("ParticlesRoot/_backLeftCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backLeftCTR;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downFrontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downFrontLeftCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downFrontLeftCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downFrontLeftCTR = this.transform.root.FindObject("ParticlesRoot/_downFrontLeftCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downFrontLeftCTR;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downRightCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downRightCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downRightCTR = this.transform.root.FindObject("ParticlesRoot/_downRightCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downRightCTR;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_backLeftCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_upLeftCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters_AudioSource == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters_AudioSource = this.transform.root.FindObject("ParticlesRoot/_downRightCTR/ColdGasThrusters/AudioSource").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_upFrontRightCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_frontRightCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_upFrontLeftCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_SelfAdjustingChair_Pilot__seatBackEndSurfaceForward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_SelfAdjustingChair_Pilot__seatBackEndSurfaceForward
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_SelfAdjustingChair_Pilot__seatBackEndSurfaceForward == null)
                {
                    return _SpaceShuttle_SelfAdjustingChair_Pilot__seatBackEndSurfaceForward = this.transform.root.FindObject("SelfAdjustingChair_Pilot/_seatBackEndSurfaceForward").gameObject;
                }

                return _SpaceShuttle_SelfAdjustingChair_Pilot__seatBackEndSurfaceForward;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R__desktopButton0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R__desktopButton0
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R__desktopButton0 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R__desktopButton0 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.R/_desktopButton0").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R__desktopButton0;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R_RearGear4_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R_RearGear4_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R_RearGear4_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R_RearGear4_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.R/RearGear3.R/RearGear4.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear3_R_RearGear4_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature = this.transform.root.FindObject("Space Shuttle Model/Armature").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model = this.transform.root.FindObject("Space Shuttle Model").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L_RearWheel_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L_RearWheel_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L_RearWheel_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L_RearWheel_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.L/RearGear2.L/RearWheel.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear2_L_RearWheel_L;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/FrontGear1").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3_FrontGear4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3_FrontGear4
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3_FrontGear4 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3_FrontGear4 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/FrontGear1/FrontGear3/FrontGear4").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear3_FrontGear4;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton1 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton1 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Joystick/JoystickButton1").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton1;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_upLeftCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1_AudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1_AudioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1_AudioSource == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1_AudioSource = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.L/_backwardMTRs1/AudioSource").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1_AudioSource;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngineTop/_backwardMTRs3").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.L/RearGear3.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontRightCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontRightCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontRightCTR = this.transform.root.FindObject("ParticlesRoot/_frontRightCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontRightCTR;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button3").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3;
            }
        }

        private GameObject _SpaceShuttle_SelfAdjustingChair_Pilot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_SelfAdjustingChair_Pilot
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_SelfAdjustingChair_Pilot == null)
                {
                    return _SpaceShuttle_SelfAdjustingChair_Pilot = this.transform.root.FindObject("SelfAdjustingChair_Pilot").gameObject;
                }

                return _SpaceShuttle_SelfAdjustingChair_Pilot;
            }
        }

        private GameObject _SpaceShuttle__audioSourceGearDeploySound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle__audioSourceGearDeploySound
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle__audioSourceGearDeploySound == null)
                {
                    return _SpaceShuttle__audioSourceGearDeploySound = this.transform.root.FindObject("_audioSourceGearDeploySound").gameObject;
                }

                return _SpaceShuttle__audioSourceGearDeploySound;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_frontForwardCTR1/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_SelfAdjustingChair_Pilot__seatSurfaceUpAndFrontEdgeForward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_SelfAdjustingChair_Pilot__seatSurfaceUpAndFrontEdgeForward
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_SelfAdjustingChair_Pilot__seatSurfaceUpAndFrontEdgeForward == null)
                {
                    return _SpaceShuttle_SelfAdjustingChair_Pilot__seatSurfaceUpAndFrontEdgeForward = this.transform.root.FindObject("SelfAdjustingChair_Pilot/_seatSurfaceUpAndFrontEdgeForward").gameObject;
                }

                return _SpaceShuttle_SelfAdjustingChair_Pilot__seatSurfaceUpAndFrontEdgeForward;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upLeftCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upLeftCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upLeftCTR = this.transform.root.FindObject("ParticlesRoot/_upLeftCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upLeftCTR;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upFrontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upFrontLeftCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upFrontLeftCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upFrontLeftCTR = this.transform.root.FindObject("ParticlesRoot/_upFrontLeftCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upFrontLeftCTR;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot == null)
                {
                    return _SpaceShuttle_ParticlesRoot = this.transform.root.FindObject("ParticlesRoot").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backwardCTR1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backwardCTR1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backwardCTR1 == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backwardCTR1 = this.transform.root.FindObject("ParticlesRoot/_backwardCTR1").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backwardCTR1;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/NavBallParent/NavballRotateHere").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/MainEngine.L/_backwardMTRs1").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_backRightCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L__desktopButton1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L__desktopButton1
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L__desktopButton1 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L__desktopButton1 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.L/_desktopButton1").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L__desktopButton1;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.R/RearGear2.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R;
            }
        }

        private GameObject _SpaceShuttle_ShipController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ShipController
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ShipController == null)
                {
                    return _SpaceShuttle_ShipController = this.transform.root.FindObject("ShipController").gameObject;
                }

                return _SpaceShuttle_ShipController;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_backLeftCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button5").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upRightCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upRightCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upRightCTR = this.transform.root.FindObject("ParticlesRoot/_upRightCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upRightCTR;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downFrontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downFrontRightCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downFrontRightCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downFrontRightCTR = this.transform.root.FindObject("ParticlesRoot/_downFrontRightCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downFrontRightCTR;
            }
        }

        private GameObject _SpaceShuttle_CustomCG { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_CustomCG
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_CustomCG == null)
                {
                    return _SpaceShuttle_CustomCG = this.transform.root.FindObject("CustomCG").gameObject;
                }

                return _SpaceShuttle_CustomCG;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__upFrontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__upFrontRightCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__upFrontRightCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__upFrontRightCTR = this.transform.root.FindObject("ParticlesRoot/_upFrontRightCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__upFrontRightCTR;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3_ButtonHighlight__2_ { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3_ButtonHighlight__2_
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3_ButtonHighlight__2_ == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3_ButtonHighlight__2_ = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button3/ButtonHighlight (2)").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button3_ButtonHighlight__2_;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L_ButtonHighlightGearDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L_ButtonHighlightGearDown
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L_ButtonHighlightGearDown == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L_ButtonHighlightGearDown = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.L/ButtonHighlightGearDown").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L_ButtonHighlightGearDown;
            }
        }

        private GameObject _SpaceShuttle_SelfAdjustingChair_Pilot__stationSeat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_SelfAdjustingChair_Pilot__stationSeat
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_SelfAdjustingChair_Pilot__stationSeat == null)
                {
                    return _SpaceShuttle_SelfAdjustingChair_Pilot__stationSeat = this.transform.root.FindObject("SelfAdjustingChair_Pilot/_stationSeat").gameObject;
                }

                return _SpaceShuttle_SelfAdjustingChair_Pilot__stationSeat;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Space_Shuttle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Space_Shuttle
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Space_Shuttle == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Space_Shuttle = this.transform.root.FindObject("Space Shuttle Model/Space Shuttle").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Space_Shuttle;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button6").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere_Navball { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere_Navball
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere_Navball == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere_Navball = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/NavBallParent/NavballRotateHere/Navball").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere_Navball;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R_RearWheel_R { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R_RearWheel_R
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R_RearWheel_R == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R_RearWheel_R = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.R/RearGear2.R/RearWheel.R").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_R_RearGear2_R_RearWheel_R;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Speedometer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Speedometer
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Speedometer == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Speedometer = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Speedometer").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Speedometer;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L_RearGear4_L { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L_RearGear4_L
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L_RearGear4_L == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L_RearGear4_L = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/RearGear1.L/RearGear3.L/RearGear4.L").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_RearGear1_L_RearGear3_L_RearGear4_L;
            }
        }

        private GameObject _SpaceShuttle_SelfAdjustingChair_Pilot_ChairController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_SelfAdjustingChair_Pilot_ChairController
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_SelfAdjustingChair_Pilot_ChairController == null)
                {
                    return _SpaceShuttle_SelfAdjustingChair_Pilot_ChairController = this.transform.root.FindObject("SelfAdjustingChair_Pilot/ChairController").gameObject;
                }

                return _SpaceShuttle_SelfAdjustingChair_Pilot_ChairController;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontLeftCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontLeftCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontLeftCTR = this.transform.root.FindObject("ParticlesRoot/_frontLeftCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontLeftCTR;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button4").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2_FrontWheel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2_FrontWheel
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2_FrontWheel == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2_FrontWheel = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/FrontGear1/FrontGear2/FrontWheel").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_FrontGear1_FrontGear2_FrontWheel;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Joystick").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root = this.transform.root.FindObject("Space Shuttle Model/Armature/Root").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton2 == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton2 = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Joystick/JoystickButton2").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickButton2;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4_ButtonHighlight__3_ { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4_ButtonHighlight__3_
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4_ButtonHighlight__3_ == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4_ButtonHighlight__3_ = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button4/ButtonHighlight (3)").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button4_ButtonHighlight__3_;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5_ButtonHighlight__4_ { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5_ButtonHighlight__4_
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5_ButtonHighlight__4_ == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5_ButtonHighlight__4_ = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button5/ButtonHighlight (4)").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button5_ButtonHighlight__4_;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6_ButtonHighlight__5_ { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6_ButtonHighlight__5_
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6_ButtonHighlight__5_ == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6_ButtonHighlight__5_ = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button6/ButtonHighlight (5)").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button6_ButtonHighlight__5_;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2_ButtonHighlight__1_ { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2_ButtonHighlight__1_
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2_ButtonHighlight__1_ == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2_ButtonHighlight__1_ = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button2/ButtonHighlight (1)").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button2_ButtonHighlight__1_;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R_ButtonHighlightFlightAssist { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R_ButtonHighlightFlightAssist
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R_ButtonHighlightFlightAssist == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R_ButtonHighlightFlightAssist = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/DashboardButton.R/ButtonHighlightFlightAssist").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R_ButtonHighlightFlightAssist;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1_ButtonHighlight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1_ButtonHighlight
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1_ButtonHighlight == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1_ButtonHighlight = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Button1/ButtonHighlight").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Button1_ButtonHighlight;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backRightCTR
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backRightCTR == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backRightCTR = this.transform.root.FindObject("ParticlesRoot/_backRightCTR").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backRightCTR;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontForwardCTR2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontForwardCTR2
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontForwardCTR2 == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontForwardCTR2 = this.transform.root.FindObject("ParticlesRoot/_frontForwardCTR2").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontForwardCTR2;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle_ThrottleThumbstick { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle_ThrottleThumbstick
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle_ThrottleThumbstick == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle_ThrottleThumbstick = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Throttle/ThrottleThumbstick").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Throttle_ThrottleThumbstick;
            }
        }

        private GameObject _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickThumbstick { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickThumbstick
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickThumbstick == null)
                {
                    return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickThumbstick = this.transform.root.FindObject("Space Shuttle Model/Armature/Root/Joystick/JoystickThumbstick").gameObject;
                }

                return _SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick_JoystickThumbstick;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_downLeftCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_frontForwardCTR2/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_downFrontRightCTR/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters;
            }
        }

        private GameObject _SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal GameObject SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters
        {
            [HideFromIl2Cpp]
            get
            {
                if (_SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters == null)
                {
                    return _SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters = this.transform.root.FindObject("ParticlesRoot/_backwardCTR2/ColdGasThrusters").gameObject;
                }

                return _SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters;
            }
        }

        #endregion PrefabPaths

        private bool _gearDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        internal bool gearDown
        {
            [HideFromIl2Cpp]
            get
            {
                return _gearDown;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _gearDown)
                {
                    gearDeployAudioSource.Stop();
                    if (value)
                    {
                        gearDeployAudioSource.clip = gearOutSound;
                        gearDeployAudioSource.Play();
                    }
                    else
                    {
                        gearDeployAudioSource.clip = gearInSound;
                        gearDeployAudioSource.Play();
                    }
                    buttonHighlightGearDown.SetActive(value);
                    animator.SetBool("LandingGearDeployed", value);
                    _gearDown = value;
                }
            }
        }

        private bool directionUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionForwardFast { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }



        private bool directionForwardSlow { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionBackward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionRollLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionRollRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionPitchUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionPitchDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionYawLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private bool directionYawRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        /// <summary>
        /// This slider value ranging from 0 to 1 determines the flight stick sensitivity
        /// </summary>
        internal float sliderValue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.3f;

        /// <summary>
        /// The constant forward force that is applied to the constant force component on the ship
        /// </summary>
        internal float constantRelativeForwardForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 600000;

        /// <summary>
        /// The constant backward force that is applied to the constant force component on the ship
        /// </summary>
        internal float constantRelativeBackwardForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 100000;

        /// <summary>
        /// The horizontal thruster force that is applied to the constant force component on the ship
        /// when steering with the thumbstick
        /// </summary>
        internal float constantRelativeHorizontalForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 100000;

        /// <summary>
        /// The vertical thruster force that is applied to the constant force component on the ship
        /// when steering with the thumbstick
        /// </summary>
        internal float constantRelativeVerticalForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 100000;

        /// <summary>
        /// How fast the roll will accelerate in deskop mode, multiplier of delta time
        /// </summary>
        internal float desktopRollSpeedLerp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 2f;

        /// <summary>
        /// Maximum roll speed, in degrees. Should stay under 180.
        /// </summary>
        internal float maxRollSpeedDegrees { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 90f; //was 100

        /// <summary>
        /// Minimum value when <see cref="_sliderValue"/> is 0
        /// </summary>
        internal float controlSensitivityMin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 1.0f;

        /// <summary>
        /// Maximum value when <see cref="_sliderValue"/> is 1
        /// </summary>
        internal float controlSensitivityMax { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 3.0f;

        /// <summary>
        /// Controller rotation offset for desktop players, so that they can look forward while flying instead of looking down
        /// </summary>
        internal float controllerXOffsetDesktopUser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 45f;

        /// <summary>
        /// Controller rotation offset for VR players, so that they can look forward while flying instead of looking down
        /// </summary>
        internal float controllerXOffsetVRUser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0f;

        /// <summary>
        /// All desktop buttons which will be disabled unless the player is in the spaceship.
        /// </summary>
        private List<GameObject> desktopButtons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new List<GameObject>();

        /// <summary>
        /// Gear down button highlight (shown when the gears are down & the player is in the spaceship)
        /// </summary>
        private GameObject buttonHighlightGearDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Flight assist button highlight (shown when the flight assist is on & the player is in the spaceship)
        /// </summary>
        private GameObject buttonHighlightFlightAssist { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Custom center of gravity of the ship
        /// </summary>
        private Transform customCenterOfGravity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Animator of the space shuttle
        /// </summary>
        private Animator animator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// AudioSource to play the gear deploy sound
        /// </summary>
        private AudioSource gearDeployAudioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// AudioClip for the gear deploy (gear in) sound
        /// </summary>
        private AudioClip gearInSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// AudioClip for the gear deploy (gear out) sound
        /// </summary>
        private AudioClip gearOutSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Root of the Flight Stick (local pickup object), will be reset to the local position at start when it's released
        /// </summary>
        private Transform flightStickRoot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Nav ball bone (Instrumentation)
        /// </summary>
        private Transform navBall { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Speed indicator bone (Instrumentation)
        /// </summary>
        private Transform speedIndicatorBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Altitude indicator bone (Instrumentation)
        /// </summary>
        private Transform altitudeIndicatorBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// Rigidbody of the ship, will be toggled between kinematic / non-kinematic
        /// </summary>
        private Rigidbody Ship { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// The pilot's chair of the ship (VRCStation)
        /// </summary>
        internal ChairController pilotChairStation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing main truster number 1/3 </summary>
        private Transform backwardMTRs1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing main truster number 2/3 </summary>
        private Transform backwardMTRs2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing main truster number 3/3 </summary>
        private Transform backwardMTRs3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing cold gas truster number 1/2 </summary>
        private Transform backwardCTRs1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backwards pointing cold gas truster number 2/2 </summary>
        private Transform backwardCTRs2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster number 1/2 </summary>
        private Transform frontForwardCTR1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster number 2/2 </summary>
        private Transform frontForwardCTR2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster on the front left </summary>
        private Transform frontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Forward pointing cold gas truster on the front right </summary>
        private Transform frontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the front left </summary>
        private Transform upFrontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the front right </summary>
        private Transform upFrontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the far left / middle (wing) </summary>
        private Transform upLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Upward pointing cold gas truster on the far right / middle (wing) </summary>
        private Transform upRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the far left / middle (wing) </summary>
        private Transform downLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the far right / middle (wing) </summary>
        private Transform downRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the front left </summary>
        private Transform downFrontLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Downward pointing cold gas truster on the front right </summary>
        private Transform downFrontRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backward pointing cold gas truster on the back left </summary>
        private Transform backLeftCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Backward pointing cold gas truster on the back right </summary>
        private Transform backRightCTR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary> Bone of the space ship armature that moves the joystick visually </summary>
        private Transform joystickBone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float oldForwardThrustTriggerInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        //particle systems fetched from the transform objects
        private ParticleSystem backwardMainPS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private ParticleSystem backwardMainPS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem backwardMainPS3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem backwardSlowPS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem backwardSlowPS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem frontForwardPS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem frontForwardPS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem frontLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem frontRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem upFrontLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem upFrontRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem upLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem upRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem downLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem downRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem downFrontLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem downFrontRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem backLeftPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem backRightPS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        //audio sources
        private AudioSource backwardMainASs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private AudioSource backwardSlowAS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource backwardSlowAS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource frontForwardAS1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource frontForwardAS2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource frontLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource frontRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource upFrontLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource upFrontRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource upLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource upRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource downLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource downRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource downFrontLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource downFrontRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource backLeftAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private AudioSource backRightAS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool _backwardMain { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backwardMain
        {
            [HideFromIl2Cpp]
            get
            {
                return _backwardMain;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backwardMain)
                {
                    _backwardMain = value;

                    //forward main boosters
                    if (value)
                    {
                        backwardMainPS1.Play();
                        backwardMainPS2.Play();
                        backwardMainPS3.Play();
                        backwardMainASs.Play();
                    }
                    else
                    {
                        backwardMainPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        backwardMainPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        backwardMainPS3.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        backwardMainASs.Stop();
                    }
                }
            }
        }

        private bool _upFrontLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upFrontLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _upFrontLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upFrontLeft)
                {
                    _upFrontLeft = value;
                    if (value)
                    {
                        upFrontLeftPS.Play();
                    }
                    else
                    {
                        upFrontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
            }
        }

        private bool _backwardSlow { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backwardSlow
        {
            [HideFromIl2Cpp]
            get
            {
                return _backwardSlow;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backwardSlow)
                {
                    _backwardSlow = value;
                    if (value)
                    {
                        backwardSlowPS1.Play();
                        backwardSlowPS2.Play();
                        backwardSlowAS1.Play();
                        backwardSlowAS2.Play();
                    }
                    else
                    {
                        backwardSlowPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        backwardSlowPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        backwardSlowAS1.Stop();
                        backwardSlowAS2.Stop();
                    }
                }
            }
        }

        private bool _frontForward { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool frontForward
        {
            [HideFromIl2Cpp]
            get
            {
                return _frontForward;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _frontForward)
                {
                    _frontForward = value;
                    if (value)
                    {
                        frontForwardPS1.Play();
                        frontForwardAS1.Play();
                        frontForwardPS2.Play();
                        frontForwardAS2.Play();
                    }
                    else
                    {
                        frontForwardPS1.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        frontForwardAS1.Stop();
                        frontForwardPS2.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        frontForwardAS2.Stop();
                    }
                }
            }
        }

        private bool _frontLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool frontLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _frontLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _frontLeft)
                {
                    _frontLeft = value;
                    if (value)
                    {
                        frontLeftPS.Play();
                        frontLeftAS.Play();
                    }
                    else
                    {
                        frontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        frontLeftAS.Stop();
                    }
                }
            }
        }

        private bool _frontRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool frontRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _frontRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _frontRight)
                {
                    _frontRight = value;
                    if (value)
                    {
                        frontRightPS.Play();
                        frontRightAS.Play();
                    }
                    else
                    {
                        frontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        frontRightAS.Stop();
                    }
                }
            }
        }

        private bool _upFrontRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upFrontRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _upFrontRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upFrontRight)
                {
                    _upFrontRight = value;
                    if (value)
                    {
                        upFrontRightPS.Play();
                    }
                    else
                    {
                        upFrontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
            }
        }

        private bool _upLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _upLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upLeft)
                {
                    _upLeft = value;
                    if (value)
                    {
                        upLeftPS.Play();
                    }
                    else
                    {
                        upLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
            }
        }

        private bool _upRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool upRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _upRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _upRight)
                {
                    _upRight = value;
                    if (value)
                    {
                        upRightPS.Play();
                        upRightAS.Play();
                    }
                    else
                    {
                        upRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        upRightAS.Stop();
                    }
                }
            }
        }

        private bool _downLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _downLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downLeft)
                {
                    _downLeft = value;
                    if (value)
                    {
                        downLeftPS.Play();
                        downLeftAS.Play();
                    }
                    else
                    {
                        downLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        downLeftAS.Stop();
                    }
                }
            }
        }

        private bool _downRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _downRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downRight)
                {
                    _downRight = value;
                    if (value)
                    {
                        downRightPS.Play();
                        downRightAS.Play();
                    }
                    else
                    {
                        downRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        downRightAS.Stop();
                    }
                }
            }
        }

        private bool _downFrontLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downFrontLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _downFrontLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downFrontLeft)
                {
                    _downFrontLeft = value;
                    if (value)
                    {
                        downFrontLeftPS.Play();
                        downFrontLeftAS.Play();
                    }
                    else
                    {
                        downFrontLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        downFrontLeftAS.Stop();
                    }
                }
            }
        }

        private bool _downFrontRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool downFrontRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _downFrontRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _downFrontRight)
                {
                    _downFrontRight = value;
                    if (value)
                    {
                        downFrontRightPS.Play();
                        downFrontRightAS.Play();
                    }
                    else
                    {
                        downFrontRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        downFrontRightAS.Stop();
                    }
                }
            }
        }

        private bool _backLeft { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backLeft
        {
            [HideFromIl2Cpp]
            get
            {
                return _backLeft;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backLeft)
                {
                    _backLeft = value;
                    if (value)
                    {
                        backLeftPS.Play();
                        backLeftAS.Play();
                    }
                    else
                    {
                        backLeftPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        backLeftAS.Stop();
                    }
                }
            }
        }

        private bool _backRight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        private bool backRight
        {
            [HideFromIl2Cpp]
            get
            {
                return _backRight;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value != _backRight)
                {
                    _backRight = value;
                    if (value)
                    {
                        backRightPS.Play();
                        backRightAS.Play();
                    }
                    else
                    {
                        backRightPS.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
                        backRightAS.Stop();
                    }
                }
            }
        }

        private ConstantForce constantForceShipComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup flightStickPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float forwardSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float controlSensitivitySpan { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float currentControlSensitivity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool localPlayerIsInStationSeat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool addControllerOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool stickIsHeld { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float fadeOutTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Vector3 localFlightStickLocalResetPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion localFlightStickLocalResetRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion steeringOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Quaternion currentFlightStickRotation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private GameObject ShipGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float forwardBackwardThrust { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float upDownThrustInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float leftRightThrustInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal float controllerXOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool isVR { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private string INDEX_TRIGGER_PICKUP_HAND_NAME { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } //is [HideFromIl2Cpp] set at runtime
        private string INDEX_TRIGGER_OTHER_HAND_NAME { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } //is [HideFromIl2Cpp] set at runtime
        private const string INDEX_TRIGGER_RIGHT = "Oculus_CrossPlatform_SecondaryIndexTrigger";
        private const string INDEX_TRIGGER_LEFT = "Oculus_CrossPlatform_PrimaryIndexTrigger";
#if RIGHT_HAND_THUMBSTICK
        private const string HORIZONTAL_INPUT_AXIS_NAME = "Oculus_CrossPlatform_SecondaryThumbstickHorizontal"; //right hand
        private const string VERTICAL_INPUT_AXIS_NAME = "Oculus_CrossPlatform_SecondaryThumbstickVertical"; //right hand
#else
        private const string HORIZONTAL_INPUT_AXIS_NAME = "Horizontal"; //left hand
        private const string VERTICAL_INPUT_AXIS_NAME = "Vertical"; //left hand
#endif

        /// <summary>
        /// Offset for the space ship parameter applied onto the "V" parameter (vertical movement)
        /// </summary>
        private const float V_OFFSET = 0.08f; //our space shuttle animator requires this offset

        /// <summary>
        /// Offset for the space ship parameter applied onto the "R" parameter (rotational movement)
        /// </summary>
        private const float R_OFFSET = 0.035f; //our space shuttle animator requires this offset

        /// <summary>
        /// Biggest negative joystick angle that is accepted, everything bigger is capped
        /// </summary>
        private const float MIN_JOYSTICK_TILT = -32;

        /// <summary>
        /// Biggest positive joystick angle that is accepted, everything bigger is capped
        /// </summary>
        private const float MAX_JOYSTICK_TILT = 32;

        /// <summary>
        /// How long the input "fades out" when the stick is dropped.
        /// </summary>
        private const float FADE_OUT_TIME = 2f;

        /// <summary>
        /// Minimum thumbstick input for the thruster system to be active. Anything below is considered as no input (deadzone).
        /// </summary>
        private const float MIN_STICK_INPUT = 0.05f;

        /// <summary>
        /// Trigger input threshold which is considered as moving slow (uses cold gas trusters). Anything above will fire the main trusters.
        /// </summary>
        private const float SLOW_TRIGGER_INPUT = 0.2f;

        /// <summary>
        /// Minimum joystick input in degrees for the steering system to be active. Anything below is considered as no input (deadzone).
        /// </summary>
        private const float MIN_AXIS_INPUT = 5f;

        /// <summary>
        /// The input that is [HideFromIl2Cpp] set locally if the remote user steers in the negative direction. Must be between -1 and 0.
        /// </summary>
        private const float NEGATIVE_REMOTE_STEERING = -0.5f;

        /// <summary>
        /// The input that is [HideFromIl2Cpp] set locally if the remote user doesn't steer in any direction. Must be between -1 and 1.
        /// This should be 0 unless your animator is weird.
        /// </summary>
        private const float NEUTRAL_REMOTE_STEERING = 0;

        /// <summary>
        /// The input that is [HideFromIl2Cpp] set locally if the remote user steers in the positive direction. Must be between 1 and 0.
        /// </summary>
        private const float POSITIVE_REMOTE_STEERING = 0.5f;

        private static void SetVRCSpatialAudioSource(GameObject audio, float gain, float far)
        {
            var audiosource = audio.GetComponentInChildren<AudioSource>();
            if (audiosource == null) return;
            var SpatialSource = audiosource.GetOrAddComponent<VRC_SpatialAudioSource>();
            if (SpatialSource != null)
            {
                SpatialSource.Gain = gain;
                SpatialSource.Far = far;
                SpatialSource.EnableSpatialization = true;
            }
        }

        /// <summary>
        /// Disables all thrusters. This is only called from the object owner.
        /// </summary>
        internal void DisableAllThrusters()
        {
            backwardMain = false;
            backwardSlow = false;
            frontForward = false;
            frontLeft = false;
            frontRight = false;
            upFrontLeft = false;
            upFrontRight = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
            downFrontLeft = false;
            downFrontRight = false;
            backLeft = false;
            backRight = false;
        }

        /// <summary>
        /// Takes in the current pitch/yaw/roll input and syncs it to remote users.
        /// </summary>
        /// <param name="pitchRotation">Pilot input for the joystick pitch angle, in degrees</param>
        /// <param name="yawRotation">Pilot input for the joystick yaw angle, in degrees</param>
        /// <param name="rollRotation">Pilot input for the joystick roll angle, in degrees</param>
        internal void SyncControlInput(float pitchRotation, float yawRotation, float rollRotation)
        {
            //check up-down stick axis
            if (Mathf.Abs(upDownThrustInput) > MIN_STICK_INPUT)
            {
                //relevant input for up/down
                if (upDownThrustInput < 0)
                {
                    SetDirectionUp();
                }
                else
                {
                    SetDirectionDown();
                }
            }
            else
            {
                SetDirectionUpDownNeutral();
            }

            //check left-right stick axis
            if (Mathf.Abs(leftRightThrustInput) > MIN_STICK_INPUT)
            {
                //relevant input for up/down
                if (leftRightThrustInput > 0)
                {
                    SetDirectionRight();
                }
                else
                {
                    SetDirectionLeft();
                }
            }
            else
            {
                SetDirectionLeftRightNeutral();
            }

            //check forward-backward input _forwardBackwardThrust
            if (Mathf.Abs(forwardBackwardThrust) > MIN_STICK_INPUT)
            {
                //relevant input for forward/backward
                if (forwardBackwardThrust > 0)
                {
                    if (forwardBackwardThrust < SLOW_TRIGGER_INPUT)
                    {
                        SetDirectionForwardSlow();
                    }
                    else
                    {
                        SetDirectionForwardFast();
                    }
                }
                else
                {
                    SetDirectionBackward();
                }
            }
            else
            {
                SetDirectionForwardBackwardNeutral();
            }

            //Left/right roll axis
            rollRotation = rollRotation > 180 ? rollRotation - 360 : rollRotation;
            if (Mathf.Abs(rollRotation) > MIN_AXIS_INPUT)
            {
                //relevant input for left/right
                if (rollRotation < 0)
                {
                    SetDirectionRollLeft();
                }
                else
                {
                    SetDirectionRollRight();
                }
            }
            else
            {
                SetDirectionRollLeftRollRightNeutral();
            }

            //Up/Down pitch axis
            pitchRotation = pitchRotation > 180 ? pitchRotation - 360 : pitchRotation;
            if (Mathf.Abs(pitchRotation) > MIN_AXIS_INPUT)
            {
                //relevant input for up/down
                if (pitchRotation > 0)
                {
                    SetDirectionPitchDown();
                }
                else
                {
                    SetDirectionPitchUp();
                }
            }
            else
            {
                SetDirectionPitchUpPitchDownNeutral();
            }

            //Left/Right yaw axis
            yawRotation = yawRotation > 180 ? yawRotation - 360 : yawRotation;
            if (Mathf.Abs(yawRotation) > MIN_AXIS_INPUT)
            {
                //relevant input for left/right
                if (yawRotation > 0)
                {
                    SetDirectionYawRight();
                }
                else
                {
                    SetDirectionYawLeft();
                }
            }
            else
            {
                SetDirectionYawLeftYawRightNeutral();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft upwards
        /// </summary>
        internal void SetDirectionUp()
        {
            //player wants to fly upwards, so activate down-booster
            if (directionUp)
            {
                //we're already flying upwards, so nothing changed
            }
            else
            {
                directionUp = true;

                //we now fly upwards for the first time, so activate down booster
                downFrontLeft = true;
                downFrontRight = true;
                downLeft = true;
                downRight = true;
                //we're no longer flying downwards
                if (directionDown)
                {
                    directionDown = false;
                    SetDisabled_upFrontLeft();
                    SetDisabled_upFrontRight();
                    SetDisabled_upLeft();
                    SetDisabled_upRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither up nor downwards
        /// </summary>
        internal void SetDirectionUpDownNeutral()
        {
            //we are flying neither up nor down, so cancel directions if they are active
            if (directionUp)
            {
                directionUp = false;

                SetDisabled_downLeft();
                SetDisabled_downRight();
                SetDisabled_downFrontLeft();
                SetDisabled_downFrontRight();
            }
            if (directionDown)
            {
                directionDown = false;

                SetDisabled_upLeft();
                SetDisabled_upRight();
                SetDisabled_upFrontLeft();
                SetDisabled_upFrontRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft downwards
        /// </summary>
        internal void SetDirectionDown()
        {
            //player wants to fly downwards, so activate up-booster
            if (directionDown)
            {
                //we're already flying downwards, so nothing changed
            }
            else
            {
                directionDown = true;

                //we now fly upwards for the first time, so activate up booster
                upFrontRight = true;
                upFrontLeft = true;
                upLeft = true;
                upRight = true;
                //check if we flew upwards before
                if (directionUp)
                {
                    directionUp = false;

                    //we are no longer flying upwards
                    SetDisabled_downLeft();
                    SetDisabled_downRight();
                    SetDisabled_downFrontLeft();
                    SetDisabled_downFrontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft leftwards
        /// </summary>
        internal void SetDirectionLeft()
        {
            //player wants to fly leftwards, so activate right-booster
            if (directionLeft)
            {
                //we're already flying leftwards, so nothing changed
            }
            else
            {
                directionLeft = true;

                //we now fly leftwards for the first time, so activate right booster
                frontRight = true;
                backRight = true;
                //we're no longer flying rightwards
                if (directionRight)
                {
                    directionRight = false;

                    //we are no longer flying rightwards
                    SetDisabled_frontLeft();
                    SetDisabled_backLeft();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither left nor rightwards
        /// </summary>
        internal void SetDirectionLeftRightNeutral()
        {
            //we are flying neither left nor right, so cancel directions if they are active
            if (directionLeft)
            {
                directionLeft = false;

                SetDisabled_frontRight();
                SetDisabled_backRight();
            }
            if (directionRight)
            {
                directionRight = false;

                SetDisabled_frontLeft();
                SetDisabled_backLeft();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft rightwards
        /// </summary>
        internal void SetDirectionRight()
        {
            //player wants to fly rightwards, so activate left-booster
            if (directionRight)
            {
                //we're already flying rightwards, so nothing changed
            }
            else
            {
                directionRight = true;

                //we now fly leftwards for the first time, so activate right booster
                frontLeft = true;
                backLeft = true;
                //check if we flew leftwards before
                if (directionLeft)
                {
                    directionLeft = false;

                    SetDisabled_frontRight();
                    SetDisabled_backRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft forwardwards fast
        /// </summary>
        internal void SetDirectionForwardFast()
        {
            //player wants to fly forwardwards, so activate backward-booster
            if (directionForwardFast)
            {
                //we're already flying forwardwards, so nothing changed
            }
            else
            {
                directionForwardFast = true;

                //we now fly forward for the first time, so activate main backward booster
                backwardMain = true;
                //we're no longer flying backward
                if (directionBackward)
                {
                    directionBackward = false;

                    //we are no longer flying backward
                    SetDisabled_frontForward();
                }
                if (directionForwardSlow)
                {
                    directionForwardSlow = false;

                    //we are no longer flying forward
                    SetDisabled_backwardSlow();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft forwardwards slow
        /// </summary>
        internal void SetDirectionForwardSlow()
        {
            //player wants to fly forwardwards, so activate backward-booster
            if (directionForwardSlow)
            {
                //we're already flying forwardwards, so nothing changed
            }
            else
            {
                directionForwardSlow = true;

                //we now fly forward for the first time, so activate slow backward booster
                backwardSlow = true;
                //we're no longer flying backward
                if (directionBackward)
                {
                    directionBackward = false;

                    //we are no longer flying backward
                    SetDisabled_frontForward();
                }
                if (directionForwardFast)
                {
                    directionForwardFast = false;

                    //we are no longer flying forward
                    SetDisabled_backwardMain();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither forward nor backwardwards
        /// </summary>
        internal void SetDirectionForwardBackwardNeutral()
        {
            //we are flying neither forward nor backward, so cancel directions if they are active
            if (directionBackward)
            {
                directionBackward = false;

                SetDisabled_frontForward();
            }
            if (directionForwardFast)
            {
                directionForwardFast = false;

                //we are no longer flying forward
                SetDisabled_backwardMain();
            }
            if (directionForwardSlow)
            {
                directionForwardSlow = false;

                //we are no longer flying forward
                SetDisabled_backwardSlow();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft backwardwards
        /// </summary>
        internal void SetDirectionBackward()
        {
            //player wants to fly backward, so activate forward-booster
            if (!directionBackward)
            {
                directionBackward = true;

                //we now fly backward for the first time, so activate forward pointing booster
                frontForward = true;
                //check if we flew forward before
                if (directionForwardFast)
                {
                    directionForwardFast = false;

                    //we are no longer flying forward
                    SetDisabled_backwardMain();
                }
                if (directionForwardSlow)
                {
                    directionForwardSlow = false;

                    //we are no longer flying forward
                    SetDisabled_backwardSlow();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft leftYawwards
        /// </summary>
        internal void SetDirectionYawLeft()
        {
            //player wants to fly leftYaw
            if (directionYawLeft)
            {
                //we're already flying leftYawwards, so nothing changed
            }
            else
            {
                directionYawLeft = true;

                //we now fly leftYawwards for the first time, so activate rightYaw booster
                backLeft = true;
                frontRight = true;
                //we're no longer flying rightYawwards
                if (directionYawRight)
                {
                    directionYawRight = false;

                    SetDisabled_frontLeft();
                    SetDisabled_backRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither leftYaw nor rightYawwards
        /// </summary>
        internal void SetDirectionYawLeftYawRightNeutral()
        {
            //we are flying neither leftYaw nor rightYaw, so cancel directions if they are active
            if (directionYawLeft)
            {
                directionYawLeft = false;

                SetDisabled_backLeft();
                SetDisabled_frontRight();
            }
            if (directionYawRight)
            {
                directionYawRight = false;

                SetDisabled_frontLeft();
                SetDisabled_backRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft rightYawwards
        /// </summary>
        internal void SetDirectionYawRight()
        {
            //player wants to fly rightYawwards, so activate leftYaw-booster
            if (directionYawRight)
            {
                //we're already flying rightYawwards, so nothing changed
            }
            else
            {
                directionYawRight = true;

                //we now fly leftYawwards for the first time, so activate rightYaw booster
                backRight = true;
                frontLeft = true;
                //check if we flew leftYawwards before
                if (directionYawLeft)
                {
                    directionYawLeft = false;

                    SetDisabled_backLeft();
                    SetDisabled_frontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft leftRollwards
        /// </summary>
        internal void SetDirectionRollLeft()
        {
            //player wants to fly leftRoll
            if (directionRollLeft)
            {
                //we're already flying leftRollwards, so nothing changed
            }
            else
            {
                directionRollLeft = true;

                //we now fly leftRollwards for the first time, so activate rightRoll booster
                downLeft = true;
                downFrontLeft = true;
                upRight = true;
                upFrontRight = true;
                //we're no longer flying rightRollwards
                if (directionRollRight)
                {
                    directionRollRight = false;

                    SetDisabled_upLeft();
                    SetDisabled_upFrontLeft();
                    SetDisabled_downRight();
                    SetDisabled_downFrontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither leftRoll nor rightRollwards
        /// </summary>
        internal void SetDirectionRollLeftRollRightNeutral()
        {
            //we are flying neither leftRoll nor rightRoll, so cancel directions if they are active
            if (directionRollLeft)
            {
                directionRollLeft = false;

                SetDisabled_downLeft();
                SetDisabled_downFrontLeft();
                SetDisabled_upRight();
                SetDisabled_upFrontRight();
            }
            if (directionRollRight)
            {
                directionRollRight = false;

                SetDisabled_upLeft();
                SetDisabled_upFrontLeft();
                SetDisabled_downRight();
                SetDisabled_downFrontRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft rightRollwards
        /// </summary>
        internal void SetDirectionRollRight()
        {
            //player wants to fly rightRollwards, so activate leftRoll-booster
            if (directionRollRight)
            {
                //we're already flying rightRollwards, so nothing changed
            }
            else
            {
                directionRollRight = true;

                //we now fly leftRollwards for the first time, so activate rightRoll booster
                downRight = true;
                downFrontRight = true;
                upLeft = true;
                upFrontLeft = true;
                //check if we flew leftRollwards before
                if (directionRollLeft)
                {
                    directionRollLeft = false;

                    SetDisabled_downLeft();
                    SetDisabled_downFrontLeft();
                    SetDisabled_upRight();
                    SetDisabled_upFrontRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft pitchUpwards
        /// </summary>
        internal void SetDirectionPitchUp()
        {
            //player wants to fly pitchUp
            if (directionPitchUp)
            {
                //we're already flying pitchUpwards, so nothing changed
            }
            else
            {
                directionPitchUp = true;

                //we now fly pitchUpwards for the first time, so activate pitchDown booster
                downFrontLeft = true;
                downFrontRight = true;
                upLeft = true;
                upRight = true;
                //we're no longer flying pitchDownwards
                if (directionPitchDown)
                {
                    directionPitchDown = false;
                    SetDisabled_upFrontLeft();
                    SetDisabled_upFrontRight();
                    SetDisabled_downLeft();
                    SetDisabled_downRight();
                }
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft neither pitchUp nor pitchDownwards
        /// </summary>
        internal void SetDirectionPitchUpPitchDownNeutral()
        {
            //we are flying neither pitchUp nor pitchDown, so cancel directions if they are active
            if (directionPitchUp)
            {
                directionPitchUp = false;

                SetDisabled_downFrontLeft();
                SetDisabled_downFrontRight();
                SetDisabled_upLeft();
                SetDisabled_upRight();
            }
            if (directionPitchDown)
            {
                directionPitchDown = false;

                SetDisabled_upFrontLeft();
                SetDisabled_upFrontRight();
                SetDisabled_downLeft();
                SetDisabled_downRight();
            }
        }

        /// <summary>
        /// Is called when the input pushes the aircraft pitchDownwards
        /// </summary>
        internal void SetDirectionPitchDown()
        {
            //player wants to fly pitchDownwards, so activate pitchUp-booster
            if (directionPitchDown)
            {
                //we're already flying pitchDownwards, so nothing changed
            }
            else
            {
                directionPitchDown = true;

                //we now fly pitchUpwards for the first time, so activate pitchDown booster
                upFrontLeft = true;
                upFrontRight = true;
                downLeft = true;
                downRight = true;
                //check if we flew pitchUpwards before
                if (directionPitchUp)
                {
                    directionPitchUp = false;

                    SetDisabled_downFrontLeft();
                    SetDisabled_downFrontRight();
                    SetDisabled_upLeft();
                    SetDisabled_upRight();
                }
            }
        }

        /// <summary>
        /// Main thruster that is pointing backwards
        /// </summary>
        internal void SetDisabled_backwardMain()
        {
            backwardMain = false;
        }

        /// <summary>
        /// Slow thruster that is pointing backwards
        /// </summary>
        internal void SetDisabled_backwardSlow()
        {
            backwardSlow = false;
        }

        /// <summary>
        /// Thruster that is pointing forward in the front
        /// </summary>
        internal void SetDisabled_frontForward()
        {
            frontForward = false;
        }

        /// <summary>
        /// Thruster on the front that is pointing to the left
        /// Used for going right and turning on Y-axis
        /// </summary>
        internal void SetDisabled_frontLeft()
        {
            if (directionRight)
                return;
            if (directionYawRight)
                return;
            frontLeft = false;
        }

        internal void SetDisabled_frontRight()
        {
            if (directionLeft)
                return;
            if (directionYawLeft)
                return;
            frontRight = false;
        }

        internal void SetDisabled_upFrontLeft()
        {
            if (directionRollRight)
                return;
            if (directionPitchDown)
                return;
            if (directionDown)
                return;
            upFrontLeft = false;
        }

        internal void SetDisabled_upFrontRight()
        {
            if (directionRollLeft)
                return;
            if (directionPitchDown)
                return;
            if (directionDown)
                return;
            upFrontRight = false;
        }

        internal void SetDisabled_upLeft()
        {
            if (directionDown)
                return;
            if (directionRollLeft)
                return;
            if (directionPitchUp)
                return;
            upLeft = false;
        }

        internal void SetDisabled_upRight()
        {
            if (directionDown)
                return;
            if (directionRollRight)
                return;
            if (directionPitchUp)
                return;
            upRight = false;
        }

        internal void SetDisabled_downLeft()
        {
            if (directionUp)
                return;
            if (directionRollRight)
                return;
            if (directionPitchDown)
                return;
            downLeft = false;
        }

        internal void SetDisabled_downRight()
        {
            if (directionUp)
                return;
            if (directionRollLeft)
                return;
            if (directionPitchDown)
                return;
            downRight = false;
        }

        internal void SetDisabled_downFrontLeft()
        {
            if (directionUp)
                return;
            if (directionRollRight)
                return;
            if (directionPitchUp)
                return;
            downFrontLeft = false;
        }

        internal void SetDisabled_downFrontRight()
        {
            if (directionUp)
                return;
            if (directionRollLeft)
                return;
            if (directionPitchUp)
                return;
            downFrontRight = false;
        }

        internal void SetDisabled_backLeft()
        {
            if (directionRight)
                return;
            if (directionYawLeft)
                return;
            backLeft = false;
        }

        internal void SetDisabled_backRight()
        {
            if (directionLeft)
                return;
            if (directionYawRight)
                return;
            backRight = false;
        }

        /// <summary>
        /// Is called from an external slider when <see cref="_sliderValue"/> changed
        /// </summary>
        internal void SliderValueChanged()
        {
            currentControlSensitivity = controlSensitivityMin + (sliderValue * controlSensitivitySpan);
        }

        /// <summary>
        /// Is called when a button in the cockpit is pressed.
        /// </summary>
        internal void OnButtonDown(int id)
        {
            switch (id)
            {
                case 0:
                    _ToggleFlightAssist();
                    break;

                case 1:
                    ToggleGearDown();
                    break;

                case 2:
                    if (localPlayerIsInStationSeat)
                    {
                        pilotChairStation.Station.ExitStation();
                    }
                    break;
            }
        }

        /// <summary>
        /// Toggles the flight assist on/off, default is on.
        /// </summary>
        internal void ToggleGearDown()
        {
            gearDown = !gearDown;
        }

        private bool _flightAssistOn = true;

        /// <summary>
        /// Toggles the flight assist on/off, default is on.
        /// </summary>
        internal void _ToggleFlightAssist()
        {
            _flightAssistOn = !_flightAssistOn;
            buttonHighlightFlightAssist.SetActive(_flightAssistOn);
            ApplyFlightAssistSetting();
        }

        internal void ApplyFlightAssistSetting()
        {
            if (_flightAssistOn)
            {
                Ship.drag = 1;
                Ship.angularDrag = 1;
            }
            else
            {
                Ship.drag = 0.01f;
                Ship.angularDrag = 1f;
            }
        }

        internal void FindParticleAndSource()
        {
            backwardMainPS1 = backwardMTRs1.GetGetInChildrens<ParticleSystem>(true);
            backwardMainPS2 = backwardMTRs2.GetGetInChildrens<ParticleSystem>(true);
            backwardMainPS3 = backwardMTRs3.GetGetInChildrens<ParticleSystem>(true);
            backwardSlowPS1 = backwardCTRs1.GetGetInChildrens<ParticleSystem>(true);
            backwardSlowPS2 = backwardCTRs2.GetGetInChildrens<ParticleSystem>(true);
            frontForwardPS1 = frontForwardCTR1.GetGetInChildrens<ParticleSystem>(true);
            frontForwardPS2 = frontForwardCTR2.GetGetInChildrens<ParticleSystem>(true);
            frontLeftPS = frontLeftCTR.GetGetInChildrens<ParticleSystem>(true);
            frontRightPS = frontRightCTR.GetGetInChildrens<ParticleSystem>(true);
            upFrontLeftPS = upFrontLeftCTR.GetGetInChildrens<ParticleSystem>(true);
            upFrontRightPS = upFrontRightCTR.GetGetInChildrens<ParticleSystem>(true);
            upLeftPS = upLeftCTR.GetGetInChildrens<ParticleSystem>(true);
            upRightPS = upRightCTR.GetGetInChildrens<ParticleSystem>(true);
            downLeftPS = downLeftCTR.GetGetInChildrens<ParticleSystem>(true);
            downRightPS = downRightCTR.GetGetInChildrens<ParticleSystem>(true);
            downFrontLeftPS = downFrontLeftCTR.GetGetInChildrens<ParticleSystem>(true);
            downFrontRightPS = downFrontRightCTR.GetGetInChildrens<ParticleSystem>(true);
            backLeftPS = backLeftCTR.GetGetInChildrens<ParticleSystem>(true);
            backRightPS = backRightCTR.GetGetInChildrens<ParticleSystem>(true);
            //fetch audio sources
            backwardMainASs = backwardMTRs1.GetGetInChildrens<AudioSource>(true);
            backwardSlowAS1 = backwardCTRs1.GetGetInChildrens<AudioSource>(true);
            backwardSlowAS2 = backwardCTRs2.GetGetInChildrens<AudioSource>(true);
            frontForwardAS1 = frontForwardCTR1.GetGetInChildrens<AudioSource>(true);
            frontForwardAS2 = frontForwardCTR2.GetGetInChildrens<AudioSource>(true);
            frontLeftAS = frontLeftCTR.GetGetInChildrens<AudioSource>(true);
            frontRightAS = frontRightCTR.GetGetInChildrens<AudioSource>(true);
            upFrontLeftAS = upFrontLeftCTR.GetGetInChildrens<AudioSource>(true);
            upFrontRightAS = upFrontRightCTR.GetGetInChildrens<AudioSource>(true);
            upLeftAS = upLeftCTR.GetGetInChildrens<AudioSource>(true);
            upRightAS = upRightCTR.GetGetInChildrens<AudioSource>(true);
            downLeftAS = downLeftCTR.GetGetInChildrens<AudioSource>(true);
            downRightAS = downRightCTR.GetGetInChildrens<AudioSource>(true);
            downFrontLeftAS = downFrontLeftCTR.GetGetInChildrens<AudioSource>(true);
            downFrontRightAS = downFrontRightCTR.GetGetInChildrens<AudioSource>(true);
            backLeftAS = backLeftCTR.GetGetInChildrens<AudioSource>(true);
            backRightAS = backRightCTR.GetGetInChildrens<AudioSource>(true);
        }

        internal void Set_SpatialAudio()
        {
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__upRightCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__frontForwardCTR2_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__downFrontLeftCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__downRightCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__frontLeftCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__backwardCTR1_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__upLeftCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__frontForwardCTR1_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__backLeftCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__frontRightCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__upFrontRightCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__upFrontLeftCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__backwardCTR2_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__backRightCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__downLeftCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle_ParticlesRoot__downFrontRightCTR_ColdGasThrusters_AudioSource, 10, 100);
            SetVRCSpatialAudioSource(SpaceShuttle__audioSourceGearDeploySound, 10, 40);
            SetVRCSpatialAudioSource(SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1_AudioSource, 60, 40);
            SetVRCSpatialAudioSource(SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2_AudioSource, 60, 40);
            SetVRCSpatialAudioSource(SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2_AudioSource, 60, 40);
            Log.Debug("Spatial Audio set.");
        }

        /// <summary>
        /// Is called once at the start of the world to setup the script
        /// </summary>
        internal void Start()
        {
            Initialize();
        }

        internal void Set_DesktopButtons()
        {

            var Desktop0 = SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R__desktopButton0.gameObject;
            if (Desktop0 != null)
            {
                var interact = Desktop0.GetOrAddComponent<VRC_AstroInteract>();
                if (interact != null)
                {
                    interact.InteractionText = "Toggle Pro Mode";
                    interact.proximity = 0_05f;
                    interact.OnInteract = () =>
                    {
                        this.OnButtonDown(0);
                    };
                }
                if (!desktopButtons.Contains(Desktop0)) desktopButtons.Add(Desktop0);
            }
            var Desktop1 = SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L__desktopButton1;
            if (Desktop1 != null)
            {
                var interact = Desktop1.GetOrAddComponent<VRC_AstroInteract>();
                if (interact != null)
                {
                    interact.InteractionText = "Toggle Gear";
                    interact.proximity = 0_05f;
                    interact.OnInteract = () =>
                    {
                        this.OnButtonDown(1);
                    };
                }
                if (!desktopButtons.Contains(Desktop1)) desktopButtons.Add(Desktop1);
            }
            var Desktop2 = SpaceShuttle_Space_Shuttle_Model_Armature_Root_EjectButton__desktopButton2;
            if (Desktop2 != null)
            {
                var interact = Desktop2.GetOrAddComponent<VRC_AstroInteract>();
                if (interact != null)
                {
                    interact.InteractionText = "Exit Space Ship";
                    interact.proximity = 0_05f;
                    interact.OnInteract = () =>
                    {
                        this.OnButtonDown(2);
                    };
                }
                if (!desktopButtons.Contains(Desktop2)) desktopButtons.Add(Desktop2);

            }

            Log.Debug("Set Buttons triggers.");

        }
        internal void Set_Paths()
        {
            Ship = this.transform.root.GetComponent<Rigidbody>();
            constantForceShipComponent = this.transform.root.GetComponent<ConstantForce>();
            ShipGameObject = this.transform.root.gameObject;
            buttonHighlightGearDown = SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_L_ButtonHighlightGearDown.gameObject;
            buttonHighlightFlightAssist = SpaceShuttle_Space_Shuttle_Model_Armature_Root_DashboardButton_R_ButtonHighlightFlightAssist.gameObject;
            customCenterOfGravity = SpaceShuttle_CustomCG.transform;
            animator = SpaceShuttle_Space_Shuttle_Model.GetComponent<Animator>();
            gearDeployAudioSource = SpaceShuttle__audioSourceGearDeploySound.GetComponent<AudioSource>();
            flightStickRoot = this.transform;
            navBall = SpaceShuttle_Space_Shuttle_Model_Armature_Root_NavBallParent_NavballRotateHere.transform;
            speedIndicatorBone = SpaceShuttle_Space_Shuttle_Model_Armature_Root_Speedometer.transform;
            altitudeIndicatorBone = SpaceShuttle_Space_Shuttle_Model_Armature_Root_Altimeter.transform;
            backwardMTRs1 = SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_L__backwardMTRs1.transform;
            backwardMTRs2 = SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngine_R__backwardMTRs2.transform;
            backwardMTRs3 = SpaceShuttle_Space_Shuttle_Model_Armature_Root_MainEngineTop__backwardMTRs3.transform;

            backwardCTRs1 = SpaceShuttle_ParticlesRoot__backwardCTR1.transform;
            backwardCTRs2 = SpaceShuttle_ParticlesRoot__backwardCTR2.transform;

            frontForwardCTR1 = SpaceShuttle_ParticlesRoot__frontForwardCTR1.transform;
            frontForwardCTR2 = SpaceShuttle_ParticlesRoot__frontForwardCTR2.transform;

            upRightCTR = SpaceShuttle_ParticlesRoot__upRightCTR.transform;

            upFrontRightCTR = SpaceShuttle_ParticlesRoot__upFrontRightCTR.transform;
            downFrontRightCTR = SpaceShuttle_ParticlesRoot__downFrontRightCTR.transform;
            downFrontLeftCTR = SpaceShuttle_ParticlesRoot__downFrontLeftCTR.transform;
            backLeftCTR = SpaceShuttle_ParticlesRoot__backLeftCTR.transform;
            downRightCTR = SpaceShuttle_ParticlesRoot__downRightCTR.transform;
            downLeftCTR = SpaceShuttle_ParticlesRoot__downLeftCTR.transform;
            frontRightCTR = SpaceShuttle_ParticlesRoot__frontRightCTR.transform;
            frontLeftCTR = SpaceShuttle_ParticlesRoot__frontLeftCTR.transform;
            backRightCTR = SpaceShuttle_ParticlesRoot__backRightCTR.transform;
            upFrontLeftCTR = SpaceShuttle_ParticlesRoot__upFrontLeftCTR.transform;
            upLeftCTR = SpaceShuttle_ParticlesRoot__upLeftCTR.transform;
            joystickBone = SpaceShuttle_Space_Shuttle_Model_Armature_Root_Joystick.transform;
            gearOutSound = AudioClips.Shuttle_gearOutSound;
            gearInSound = AudioClips.Shuttle_gearInSound;
            Log.Debug("Set Shuttle Paths.");
        }

        internal void Set_FlightStick()
        {
            flightStickPickup = flightStickRoot.GetOrAddComponent<VRC_AstroPickup>();
            if (flightStickPickup != null)
            {
                flightStickPickup.ForcePickupComponent = true;
                flightStickPickup.PickupController.EditMode = true;
                flightStickPickup.PickupController.orientation = VRC_Pickup.PickupOrientation.Any;
                flightStickPickup.PickupController.AutoHold = VRC_Pickup.AutoHoldMode.Yes;
                flightStickPickup.PickupController.UseText = "Grab";
                flightStickPickup.PickupController.ThrowVelocityBoostMinSpeed = 1;
                flightStickPickup.PickupController.ThrowVelocityBoostScale = 1;
                flightStickPickup.pickupable = true;
                flightStickPickup.PickupController.proximity = 2;
                flightStickPickup.OnPickup += OnPickup;
                flightStickPickup.OnDrop += OnDrop;
                Log.Debug("Flightstick ready.");
            }
        }

        internal void Set_ChairController()
        {
            var station = SpaceShuttle_SelfAdjustingChair_Pilot_ChairController.GetOrAddComponent<VRC_AstroStation>();
            if(station != null)
            {
                station.Start();
                station.disableStationExit = true;
                station.Station.seated = true;
                station.Station.PlayerMobility = VRCStation.Mobility.ImmobilizeForVehicle;
                station.Station.canUseStationFromStation = false;
                station.Station.stationEnterPlayerLocation = SpaceShuttle_SelfAdjustingChair_Pilot__stationSeat.transform;
                station.Station.stationExitPlayerLocation = SpaceShuttle_SelfAdjustingChair_Pilot_Exit.transform;
                station.StationTrigger.InteractionText = "Drive Shuttle";
                station.StationTrigger.proximity = 2;
            }
            pilotChairStation = SpaceShuttle_SelfAdjustingChair_Pilot_ChairController.GetOrAddComponent<ChairController>();
            if (pilotChairStation != null)
            {
                pilotChairStation.disableColliderControl = false;
                pilotChairStation.enableStationMenuButtonExit = false;
                pilotChairStation.stationSeat = SpaceShuttle_SelfAdjustingChair_Pilot__stationSeat.transform;
                pilotChairStation.seatSurfaceUpAndFrontEdgeForward = SpaceShuttle_SelfAdjustingChair_Pilot__seatSurfaceUpAndFrontEdgeForward.transform;
                pilotChairStation.seatBackEndSurfaceForward = SpaceShuttle_SelfAdjustingChair_Pilot__seatBackEndSurfaceForward.transform;
                pilotChairStation.OnStationEnter += OnStationEnter;
                pilotChairStation.OnStationExit += OnStationExit;
                Log.Debug("ChairController ready!");
            }

        }
        internal void Initialize()
        {
            #region Setup Variables
            Set_Paths();
            Set_DesktopButtons();
            Set_FlightStick();
            Set_ChairController();

            // add missing audio components
            Set_SpatialAudio();


            #endregion Setup Variables

            foreach (var button in desktopButtons)
            {
                button.SetActive(false);
            }
            DisableButtonHighlights();
            //fetch particle systems
            controlSensitivitySpan = controlSensitivityMax - controlSensitivityMin;
            SliderValueChanged(); //apply the calculated controlSensitivitySpan
            ApplyFlightAssistSetting();
            FindParticleAndSource();
            DisableAllThrusters();
            if (customCenterOfGravity)
            {
                Ship.centerOfMass = customCenterOfGravity.localPosition;
            }
            if (constantForceShipComponent != null)
            {
                constantForceShipComponent.relativeForce = new Vector3(0, 0, 0);
            }
            else
            {
                Log.Error("[ShipController] There is no constant force component attached to the ship's rigidbody.");
            }
            Ship.isKinematic = true;
            flightStickPickup.ForcePickupComponent = true;
            flightStickPickup.PickupController.EditMode = true;
            flightStickPickup.pickupable = false;
            isVR = GameInstances.LocalPlayer.IsUserInVR();
            controllerXOffset = isVR ? controllerXOffsetVRUser : controllerXOffsetDesktopUser;
            if (controllerXOffset != 0)
            {
                addControllerOffset = true;
                Log.Debug($"[ShipController] Adding controller X-Offset with {controllerXOffset} degrees.");
                steeringOffset = Quaternion.Euler(controllerXOffset, 0, 0);
            }
            StoreLocalStickPositionOffset();
            if (constantRelativeVerticalForce > 0)
                constantRelativeVerticalForce = -constantRelativeVerticalForce;
            if (constantRelativeBackwardForce < 0)
                constantRelativeBackwardForce = -constantRelativeBackwardForce;
            animator.SetBool("LandingGearDeployed", gearDown);
            ResetAnimator();
            Log.Debug("Shuttle is ready!");
        }

        internal void Update()
        {   
            //we call UpdateSteering each frame while the controller is held, to avoid having update loops for empty stations
            if (isVR)
            {
                //allows advanced VR input via thumbstick
                UpdateSteeringVR();
            }
            else
            {   
                UpdateSteeringDesktop();
            }
            UpdateWhileInStation();
            UpdateFadeOut();
        }

        /// <summary>
        /// Resets the space shuttle animator to be in the neutral steering position
        /// </summary>
        internal void ResetAnimator()
        {
            animator.SetFloat("V", value: 0 + V_OFFSET);
            animator.SetFloat("H", value: 0);
            animator.SetFloat("R", value: 0.5f + R_OFFSET);
        }

        /// <summary>
        /// Is called each frame after the stick was dropped
        /// for <see cref="FADE_OUT_TIME"/> seconds to smoothly
        /// fade out the rotational steering
        /// </summary>
        internal void UpdateFadeOut()
        {
            if (stickIsHeld)
                return;
            fadeOutTime += Time.deltaTime;
            if (fadeOutTime < FADE_OUT_TIME)
            {
                Ship.MoveRotation(Quaternion.Slerp(Ship.rotation, currentFlightStickRotation, currentControlSensitivity * Time.deltaTime));
            }
            else
            {
                // Log.Debug("[ShipController] Stopped fade-out update.");
            }
        }

        /// <summary>
        /// Is called every frame while the player is in the station to
        /// update the instruments and run the buttons
        /// </summary>
        internal void UpdateWhileInStation()
        {
            if (localPlayerIsInStationSeat)
            {
                UpdateInstruments();
                Vector3 localRotation = flightStickRoot.localEulerAngles;
                if (isVR)
                {
                    float inputX = (flightStickRoot.localRotation.eulerAngles.x + controllerXOffset) % 360;
                    if (inputX > 180) inputX -= 360;
                    float inputY = flightStickRoot.localRotation.eulerAngles.y % 360;
                    if (inputY > 180) inputY -= 360;
                    float inputZ = flightStickRoot.localRotation.eulerAngles.z % 360;
                    if (inputZ > 180) inputZ -= 360;
                    float inputXClamped = Mathf.Clamp(inputX, MIN_JOYSTICK_TILT, MAX_JOYSTICK_TILT);
                    float inputYClamped = Mathf.Clamp(inputY, MIN_JOYSTICK_TILT, MAX_JOYSTICK_TILT);
                    float inputZClamped = Mathf.Clamp(inputZ, MIN_JOYSTICK_TILT, MAX_JOYSTICK_TILT);
                    //joystick is already driven by animation --> _joystickBone.localEulerAngles = new Vector3(inputXClamped, 0, inputZClamped);
                    //pitch up-> joystick back -> V:1 (Pitch&Yaw layer)
                    //pitch down-> joystick front -> V:-1 (Pitch&Yaw layer)
                    animator.SetFloat("V", value: (-inputXClamped / MAX_JOYSTICK_TILT) + V_OFFSET);
                    //turn left-> thumbstick left -> H:-1 (Pitch&Yaw layer)
                    //turn right-> thumbstick right -> H:1 (Pitch&Yaw layer)
                    animator.SetFloat("H", value: inputYClamped / MAX_JOYSTICK_TILT);
                    //roll left-> joystick left -> R:0 (Pitch&Yaw layer)
                    //roll right-> joystick right -> R:1 (Pitch&Yaw layer)
                    animator.SetFloat("R", value: (((inputZClamped / MAX_JOYSTICK_TILT) + 1) * 0.5f) + R_OFFSET);
                    //JTH Joystick Thumbstick horizontal
                    animator.SetFloat("JTH", value: leftRightThrustInput);
                    //JTV Joystick Thumbstick vertical
                    animator.SetFloat("JTV", value: upDownThrustInput);
                    //TTH Throttle Thumbstick horizontal
                    //TTV Throttle Thumbstick vertical
                    //Throttle 0-1
                    animator.SetFloat("Throttle", value: (forwardBackwardThrust > 0 ? forwardBackwardThrust / constantRelativeForwardForce : 0));
                    //LandingGearDeployed (bool)
                }
            }
        }

        /// <summary>
        /// Updates the nav ball, speed and height indicator.
        /// The navball part was an absolute pain and is still not perfect.
        /// Additional thanks goes to NotFish who suffered endlessly to try to make the navball work in all angles.
        /// </summary>
        internal void UpdateInstruments()
        {
#pragma warning disable IDE0018 // Inline variable declaration is not possible in Udon right now
            Vector3 axisVector;
            float axisRotation;
#pragma warning restore IDE0018

            ShipGameObject.transform.rotation.ToAngleAxis(out axisRotation, out axisVector);

            //Mirror pitch
            axisVector.y *= -1;
            navBall.localRotation = Quaternion.AngleAxis(axisRotation, axisVector);

            //moves from 90 (zero) to -90 (max)
            altitudeIndicatorBone.localEulerAngles = new Vector3(-74.413f, 180, 83.6f - (173.6f * Mathf.Clamp01(ShipGameObject.transform.position.y / 400)));
            //moves from 90 (zero) to -90 (max)
            speedIndicatorBone.localEulerAngles = new Vector3(-74.413f, 180, 83.6f - (173.6f * Mathf.Clamp01(Ship.velocity.magnitude / 60)));
        }

        /// <summary>
        /// Is called in every frame while the controller is held in hand for VR users
        /// </summary>
        internal void UpdateSteeringVR()
        {
            if (stickIsHeld)
            {
                if (Input.GetButtonDown("Oculus_CrossPlatform_Button2")) //right menu button
                    OnButtonDown(1);
                //amplify the roll axis 3x
                float roll = flightStickRoot.localRotation.eulerAngles.z % 360;
                roll = roll > 180 ? roll - 360 : roll;
                if (roll >= 0)
                {
                    roll = Mathf.Min(2 * roll, 120 - roll);
                }
                else
                {
                    roll = Mathf.Max(2 * roll, -120 - roll);
                }
                currentFlightStickRotation = Quaternion.AngleAxis(roll, flightStickRoot.forward) * flightStickRoot.rotation;
                if (addControllerOffset)
                {
                    currentFlightStickRotation *= steeringOffset;
                }
                Ship.MoveRotation(Quaternion.Slerp(Ship.rotation, currentFlightStickRotation, currentControlSensitivity * Time.deltaTime));
                //check if input thrust has changed
                float triggerInput = Input.GetAxisRaw(INDEX_TRIGGER_PICKUP_HAND_NAME) - (Input.GetAxisRaw(INDEX_TRIGGER_OTHER_HAND_NAME));
                if (triggerInput != oldForwardThrustTriggerInput)
                {
                    if (triggerInput > 0)
                    {
                        forwardBackwardThrust = triggerInput * constantRelativeForwardForce;
                    }
                    else
                    {
                        forwardBackwardThrust = triggerInput * constantRelativeBackwardForce;
                    }
                    oldForwardThrustTriggerInput = triggerInput;
                }
                if (forwardBackwardThrust >= 0)
                {
                    forwardSpeed = Mathf.Min(Mathf.Lerp(forwardSpeed, forwardBackwardThrust, Time.deltaTime), forwardBackwardThrust);
                }
                else
                {
                    forwardSpeed = Mathf.Max(Mathf.Lerp(forwardSpeed, forwardBackwardThrust, Time.deltaTime), forwardBackwardThrust);
                }
                leftRightThrustInput = Input.GetAxisRaw(HORIZONTAL_INPUT_AXIS_NAME);
                upDownThrustInput = Input.GetAxisRaw(VERTICAL_INPUT_AXIS_NAME);
                constantForceShipComponent.relativeForce = new Vector3(leftRightThrustInput * constantRelativeHorizontalForce, upDownThrustInput * constantRelativeVerticalForce, forwardSpeed);
                Vector3 stickRotation = flightStickRoot.localRotation.eulerAngles;
                SyncControlInput(stickRotation.x % 360, stickRotation.y % 360, stickRotation.z % 360);
            }
            else
            {
                constantForceShipComponent.relativeForce = Vector3.zero;
#if DEBUG_TEST
                Log.Debug("[ShipController] Stopping steering update loop");
#endif
            }
        }

        /// <summary>
        /// Is called in every frame while the controller is held in hand for desktop users
        /// </summary>
        internal void UpdateSteeringDesktop()
        {
            if (stickIsHeld)
            {
                float rollAngleInput = 0;
                if (Input.GetKey(KeyCode.Q))
                {
                    if (Input.GetKey(KeyCode.E)) { } //compiler optimization
                    else
                    {
                        rollAngleInput = maxRollSpeedDegrees;
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        rollAngleInput = -maxRollSpeedDegrees;
                    }
                }
                rollAngleInput = Mathf.LerpAngle(rollAngleInput, rollAngleInput, Time.deltaTime * desktopRollSpeedLerp);
                currentFlightStickRotation = Quaternion.AngleAxis(rollAngleInput, flightStickRoot.forward) * flightStickRoot.rotation;
                if (addControllerOffset)
                {
                    currentFlightStickRotation *= steeringOffset;
                }
                Ship.MoveRotation(Quaternion.Slerp(Ship.rotation, currentFlightStickRotation, currentControlSensitivity * Time.deltaTime));
                //UpDown
                if (Input.GetKey(KeyCode.S))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        upDownThrustInput = 0;
                    }
                    else
                    {
                        upDownThrustInput = 1;
                    }
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    upDownThrustInput = -1;
                }
                else
                {
                    upDownThrustInput = 0;
                }
                //LeftRight
                if (Input.GetKey(KeyCode.D))
                {
                    if (Input.GetKey(KeyCode.A))
                        leftRightThrustInput = 0;
                    else
                        leftRightThrustInput = 1;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    leftRightThrustInput = -1;
                }
                else
                {
                    leftRightThrustInput = 0;
                }
                //forward/backward
                if (Input.GetMouseButton(0)) //primary mouse button
                {
                    if (Input.GetKey(KeyCode.Space))
                        forwardBackwardThrust = 0;
                    else
                        forwardBackwardThrust = constantRelativeForwardForce;
                }
                else if (Input.GetKey(KeyCode.Space)) //space
                {
                    forwardBackwardThrust = -constantRelativeForwardForce;
                }
                else
                {
                    forwardBackwardThrust = 0;
                }
                constantForceShipComponent.relativeForce = new Vector3(leftRightThrustInput * constantRelativeHorizontalForce, upDownThrustInput * constantRelativeVerticalForce, forwardBackwardThrust);
                Vector3 stickRotation = addControllerOffset ? (flightStickRoot.localRotation * steeringOffset).eulerAngles : flightStickRoot.localRotation.eulerAngles;
                SyncControlInput(stickRotation.x % 360, stickRotation.y % 360, rollAngleInput);
            }
        }

        /// <summary>
        /// Saves the current local stick position offset from the ship, is called at Start()
        /// </summary>
        internal void StoreLocalStickPositionOffset()
        {
            localFlightStickLocalResetPosition = flightStickRoot.localPosition;
            localFlightStickLocalResetRotation = flightStickRoot.localRotation;
        }

        /// <summary>
        /// Resets the local stick root position offset from the ship, which was stored at Start()
        /// </summary>
        internal void ResetLocalStickPositionOffset()
        {
#if DEBUG_TEST
            Log.Debug("[ShipController] Restored stick position offset");
#endif
            flightStickRoot.localPosition = localFlightStickLocalResetPosition;
            flightStickRoot.localRotation = localFlightStickLocalResetRotation;
        }

        /// <summary>
        /// Must be called from the station seat when a player entered the pilot chair
        /// </summary>
        internal void OnStationEnter()
        {
            Log.Debug("[ShipController] Player entered this station, called OnStationEnter() locally");
            foreach (GameObject button in desktopButtons)
            {
                button.SetActive(true);
            }
            SetButtonHighlightsToCurrentState(); 
            Log.Debug("[ShipController] LocalPlayer entered the station.");
            localPlayerIsInStationSeat = true;
            Ship.isKinematic = false;
            ResetLocalStickPositionOffset();
            flightStickPickup.pickupable = true;
            //reset ship thrusters just in case
            stickIsHeld = false;
            DisableAllThrusters();
            ResetAnimator();
        }

        /// <summary>
        /// Applies the current "highlight on/off" state to all buttons
        /// </summary>
        internal void SetButtonHighlightsToCurrentState()
        {
            buttonHighlightGearDown.SetActive(gearDown);
            buttonHighlightFlightAssist.SetActive(_flightAssistOn);
        }

        /// <summary>
        /// Disables the current "highlight on" objects on all buttons, regardless of their state
        /// </summary>
        internal void DisableButtonHighlights()
        {
            buttonHighlightGearDown.SetActive(false);
            buttonHighlightFlightAssist.SetActive(false);
        }

        /// <summary>
        /// Must be called from the station seat when a player exited the pilot chair
        /// </summary>
        internal void OnStationExit()
        {
            Log.Debug("[ShipController] Player exited this station, called OnStationExit() locally");
            foreach (GameObject button in desktopButtons)
            {
                button.SetActive(false);
            }
            DisableButtonHighlights();
            stickIsHeld = false;
            DisableAllThrusters();
            ResetAnimator();
            //smoothly fade out rotation steering
            fadeOutTime = 0;
            Log.Debug("[ShipController] LocalPlayer exited the station.");
            localPlayerIsInStationSeat = false;
            Ship.isKinematic = true;
            flightStickPickup.pickupable = false;
            ResetLocalStickPositionOffset();
            flightStickPickup.Drop();
        }

        /// <summary>
        /// Is called when the flight stick (local pickup) is being picked up.
        /// </summary>
        internal void OnPickup()
        {
            DisableAllThrusters();
            if (flightStickPickup.CurrentHand == VRC_Pickup.PickupHand.Left)
            {
                INDEX_TRIGGER_PICKUP_HAND_NAME = INDEX_TRIGGER_LEFT;
                INDEX_TRIGGER_OTHER_HAND_NAME = INDEX_TRIGGER_RIGHT;
            }
            else
            {
                INDEX_TRIGGER_PICKUP_HAND_NAME = INDEX_TRIGGER_RIGHT;
                INDEX_TRIGGER_OTHER_HAND_NAME = INDEX_TRIGGER_LEFT;
            }
            stickIsHeld = true;
            if (addControllerOffset)
            {
                controllerXOffset = isVR ? controllerXOffsetVRUser : controllerXOffsetDesktopUser;
            }

        }

        /// <summary>
        /// Is called when the flight stick (local pickup) is being dropped.
        /// </summary>
        internal void OnDrop()
        {
            Log.Debug("[ShipController] Flight stick was dropped, now fading out steering.");
            stickIsHeld = false;
            if (addControllerOffset)
            {
                controllerXOffset = 0;
            }
            DisableAllThrusters();
            //smoothly fade out rotation steering
            fadeOutTime = 0;
            ResetLocalStickPositionOffset();
        }
    }
}