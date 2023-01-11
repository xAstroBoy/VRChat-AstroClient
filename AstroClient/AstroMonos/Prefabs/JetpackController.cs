using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Spawnables;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Player;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Xml.Schema;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using UnityEngine.Animations;
using VRCSDK2;
using VRC_Pickup = VRC.SDKBase.VRC_Pickup;
using VRCStation = VRC.SDKBase.VRCStation;

namespace AstroClient.AstroMonos.Prefabs
{
    // TODO : make a option to control the jetpack force speed.
    [RegisterComponent]
    public class JetpackController : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public JetpackController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }


        internal bool IgnoreQuickBoostAnim { get; set; } = false;
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnLocalAvatarLoaded += OnLocalAvatarLoaded;

                    }
                    else
                    {

                        ClientEventActions.OnLocalAvatarLoaded -= OnLocalAvatarLoaded;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private bool _AdjustScaleBasedOffAvatar = false;
        internal bool AdjustScaleBasedOffAvatar
        {
            get => _AdjustScaleBasedOffAvatar;
            set
            {
                if (_AdjustScaleBasedOffAvatar != value)
                {
                    if (value)
                    {
                        ActivateConstraint();
                    }
                    else
                    {
                        CleanConstraint();
                    }
                }
                if (JetpackScaleConstraint != null)
                {
                    JetpackScaleConstraint.enabled = value;
                }
                _AdjustScaleBasedOffAvatar = value;
            }
        }

        private void CleanConstraint()
        {
            if (JetpackScaleConstraint != null)
            {
                JetpackScaleConstraint.constraintActive = false;
                for (int i = 0; i < JetpackScaleConstraint.sourceCount; i++)
                {
                    JetpackScaleConstraint.RemoveSource(i);
                }
            }
        }


        private void ActivateConstraint()
        {
            if(JetpackScaleConstraint != null)
            {
                CleanConstraint();
            }
            // Let's make a new source
            if (GameInstances.CurrentAvatar != null)
            {
                if (JetpackScaleConstraint != null)
                {
                    JetpackScaleConstraint.AddSource(GenerateSource(GameInstances.CurrentAvatar.transform));
                    JetpackScaleConstraint.constraintActive = true;
                    //JetpackScaleConstraint.scaleOffset = Vector3.one;
                }
            }

        }



        private void OnLocalAvatarLoaded(GameObject avatar)
        {
            if(avatar == null) return; 
            if(AdjustScaleBasedOffAvatar)
            {
                ActivateConstraint();
            }

        }




        private void Start()
        {

            // For better manageability, correct the jetpack size to avatar size.
            HasSubscribed = true;

            if (Movement_Joypad != null)
            {
                JetstickPickup = Movement_Joypad.GetOrAddComponent<VRC_AstroPickup>();
                if (JetstickPickup != null)
                {
                    JetstickPickup.ForcePickupComponent = true;
                    JetstickPickup.PickupController.pickupable = true;
                    JetstickPickup.OnPickup = Movement_Joypad_OnPickup;
                    JetstickPickup.OnPickupUseDown = Movement_Joypad_OnPickupUseDown;
                    JetstickPickup.OnPickupUseUp = Movement_Joypad_OnPickupUseUp;
                    JetstickPickup.OnDrop = Movement_Joypad_OnDrop;
                    JetstickPickup.interactText = "Movement";
                    JetstickPickup.InteractionText = "Movement";
                    //Movement_Joypad_Grip.localRotation = new Quaternion(0, 0, 0, 0);
                    JetstickPickup.PickupController.ExactGrip = Movement_Joypad_Grip;
                    JetstickPickup.PickupController.orientation = VRC_Pickup.PickupOrientation.Grip;
                }
                Default_Movement_Joystick_Pos = Movement_Joypad.localPosition;
                Default_Movement_Joystick_Rot = Movement_Joypad.localRotation;

            }

            if (Thruster_Joypad != null)
            {
                Thruster_JoypadPickup = Thruster_Joypad.GetOrAddComponent<VRC_AstroPickup>();
                if (Thruster_JoypadPickup != null)
                {
                    Thruster_JoypadPickup.ForcePickupComponent = true;
                    Thruster_JoypadPickup.PickupController.pickupable = true;
                    Thruster_JoypadPickup.OnPickup = Thruster_Joypad_OnPickup;
                    Thruster_JoypadPickup.OnPickupUseDown = Thruster_Joypad_OnPickupUseDown;
                    Thruster_JoypadPickup.OnPickupUseUp = Thruster_Joypad_OnPickupUseUp;
                    Thruster_JoypadPickup.OnDrop = Thruster_Joypad_OnDrop;
                    Thruster_JoypadPickup.interactText = "Thruster";
                    Thruster_JoypadPickup.InteractionText = "Thruster";
                    //Thruster_Joypad_Grip.localRotation = new Quaternion(0,0,0,0);
                    Thruster_JoypadPickup.PickupController.ExactGrip = Thruster_Joypad_Grip;
                    Thruster_JoypadPickup.PickupController.orientation = VRC_Pickup.PickupOrientation.Grip;
                }
                Default_Thruster_Joystick_Pos = Thruster_Joypad.localPosition;
                Default_Thruster_Joystick_Rot = Thruster_Joypad.localRotation;

                //ThrusterForceDefault = ThrusterForce.relativeForce;
            }
            
            if(Chair != null)
            {
                // Check if Chair is present
                bool isPresent = Chair.GetComponent<VRC_Station>() != null || Chair.GetComponent<VRCStation>() != null;
                CurrentChair = Chair.GetOrAddComponent<VRC_AstroStation>();
                if(CurrentChair != null)
                {
                        MiscUtils.DelayFunction(0.1f, () =>
                        {
                            if (!isPresent)
                            {
                                CurrentChair.Station.PlayerMobility = VRCStation.Mobility.ImmobilizeForVehicle;
                                CurrentChair.Station.seated = true;
                                CurrentChair.Station.stationEnterPlayerLocation = Enter_Point;
                                CurrentChair.Station.stationExitPlayerLocation = Exit_Point;
                                //CurrentChair.Station.canUseStationFromStation = false;
                                //CurrentChair.Station.disableStationExit = true;
                            }
                            if (Thruster_Joypad != null)
                            {
                                CurrentChair.BlockVanillaStationExit = true;
                            }
                        });
                    
                    CurrentChair.OnStationExitEvent = OnStationExit;
                }
            }

        }



        private ConstraintSource GenerateSource(Transform avatar)
        {
            return new ConstraintSource
            {
                m_SourceTransform = avatar,
                m_Weight = 1,

            };
        }
        void OnDestroy()
        {
            if(CurrentChair != null)
            {
                CurrentChair.BlockVanillaStationExit = false;
                CurrentChair.ExitStation();
            }
        }
        private void Movement_Joypad_OnPickupUseDown()
        {
            JetpackForce.enabled = true;
            ParticleThrustParticles.Play();
            UpperJet_ON.gameObject.SetActive(true);
            UpperJet_OFF.gameObject.SetActive(false);
        }


        private void Movement_Joypad_OnPickupUseUp()
        {
            JetpackForce.enabled = false;
            UpperJet_ON.gameObject.SetActive(false);
            UpperJet_OFF.gameObject.SetActive(true);

        }

        private void Thruster_Joypad_OnPickupUseDown()
        {
            ThrusterForce.enabled = true;
            if (!IgnoreQuickBoostAnim)
            {
                QuickBoost.Play("quickboost");
            }
            QuickBoostParticles.Play();
            LowerJet_OFF.gameObject.SetActive(false);
            LowerJet_ON.gameObject.SetActive(true);

        }
        private void Thruster_Joypad_OnPickupUseUp()
        {
            ThrusterForce.enabled = false;
            LowerJet_OFF.gameObject.SetActive(true);
            LowerJet_ON.gameObject.SetActive(false);

        }



        private void OnStationExit()
        {
            Destroy(this.gameObject);
        }

        private void Thruster_Joypad_OnPickup()
        {
            if (Thruster_Joypad_PositionConstraint != null)
            {
                Thruster_Joypad_PositionConstraint.constraintActive = false;
            }
            if (Thruster_Joypad_RotationConstraint != null)
            {
                Thruster_Joypad_RotationConstraint.constraintActive = false;
            }


        }

        private void Thruster_Joypad_OnDrop()
        {
            //Thruster_Joypad.localPosition = Default_Thruster_Joystick_Pos;
            //Thruster_Joypad.localRotation = Default_Thruster_Joystick_Rot;

            if (Thruster_Joypad_PositionConstraint != null)
            {
                Thruster_Joypad_PositionConstraint.constraintActive = true;
            }
            if (Thruster_Joypad_RotationConstraint != null)
            {
                Thruster_Joypad_RotationConstraint.constraintActive = true;
            }
        }


        private void Movement_Joypad_OnPickup()
        {
            if (Movement_Joypad_PositionConstraint != null)
            {
                Movement_Joypad_PositionConstraint.constraintActive = false;
            }
            if (Movement_Joypad_RotationConstraint != null)
            {
                Movement_Joypad_RotationConstraint.constraintActive = false;
            }


        }

        private void Movement_Joypad_OnDrop()
        {
            //Movement_Joypad.localPosition = Default_Movement_Joystick_Pos;
            //Movement_Joypad.localRotation = Default_Movement_Joystick_Rot;
            if (Movement_Joypad_PositionConstraint != null)
            {
                Movement_Joypad_PositionConstraint.constraintActive = true;
            }
            if (Movement_Joypad_RotationConstraint != null)
            {
                Movement_Joypad_RotationConstraint.constraintActive = true;
            }
        }

        internal void RestoreOriginalSettings()
        {
            if(JetpackForce != null)
            {
                Current_Jetpack_Force = AstroJetPack.Jetpack_Force_Default;
            }
            if (ThrusterForce != null)
            {
                Current_Thruster_Force = AstroJetPack.Thruster_Force_Default;
            }

        }
        private ScaleConstraint _JetpackScaleConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ScaleConstraint JetpackScaleConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (_JetpackScaleConstraint == null)
                {
                    _JetpackScaleConstraint = transform.GetOrAddComponent<ScaleConstraint>();
                }
                return _JetpackScaleConstraint;
            }
        }


        private Transform _Chair {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }
        private Transform Chair
        {
            [HideFromIl2Cpp]
            get
            {
                if(_Chair == null)
                {
                    _Chair = transform.FindObject("Chair");
                }
                return _Chair;
            }
        }

        private Transform _Collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform SeatCollider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;
                if (_Collider == null)
                {
                    _Collider = Chair.FindObject("Collider");
                }
                return _Collider;
            }
        }

        private Transform _Enter_Point { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform Enter_Point
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;
                if (_Enter_Point == null)
                {
                    _Enter_Point = Chair.FindObject("Enter Point");
                }
                return _Enter_Point;
            }
        }
        private Transform _Exit_Point { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform Exit_Point
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;
                if (_Exit_Point == null)
                {
                    _Exit_Point = Chair.FindObject("Exit Point");
                }
                return _Exit_Point;
            }
        }



        private Transform _UpperJet {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }
        private Transform UpperJet
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;
                if (_UpperJet == null)
                {
                    _UpperJet = Chair.FindObject("UpperJet");
                }
                return _UpperJet;
            }
        }
        private Transform _UpperJet_ON {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }
        private Transform UpperJet_ON
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;

                if (_UpperJet_ON == null)
                {
                    _UpperJet_ON = UpperJet.FindObject("On");
                }
                return _UpperJet_ON;
            }
        }
        private Transform _UpperJet_OFF {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }
        private Transform UpperJet_OFF
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;

                if (_UpperJet_OFF == null)
                {
                    _UpperJet_OFF = UpperJet.FindObject("Off");
                }
                return _UpperJet_OFF;
            }
        }

        private Transform _Movement_Joypad {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }
        private Transform Movement_Joypad
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Movement_Joypad == null)
                {
                    _Movement_Joypad = transform.FindObject("Movement_Joypad");
                }
                return _Movement_Joypad;
            }
        }

        private Transform _Movement_Joypad_Grip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform Movement_Joypad_Grip
        {
            [HideFromIl2Cpp]
            get
            {
                if (Movement_Joypad == null) return null;
                if (_Movement_Joypad_Grip == null)
                {
                    _Movement_Joypad_Grip = Movement_Joypad.FindObject("Grip");
                }
                return _Movement_Joypad_Grip;
            }
        }



        private PositionConstraint _Movement_Joypad_PositionConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PositionConstraint Movement_Joypad_PositionConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (Movement_Joypad == null) return null;
                if (_Movement_Joypad_PositionConstraint == null)
                {
                    _Movement_Joypad_PositionConstraint = Movement_Joypad.GetComponent<PositionConstraint>();
                }
                return _Movement_Joypad_PositionConstraint;
            }
        }
        private RotationConstraint _Movement_Joypad_RotationConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RotationConstraint Movement_Joypad_RotationConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (Movement_Joypad == null) return null;
                if (_Movement_Joypad_RotationConstraint == null)
                {
                    _Movement_Joypad_RotationConstraint = Movement_Joypad.GetComponent<RotationConstraint>();
                }
                return _Movement_Joypad_RotationConstraint;
            }
        }

        private UnityEngine.ConstantForce _JetpackForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private UnityEngine.ConstantForce JetpackForce
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;
                if (_JetpackForce == null)
                {
                    _JetpackForce = Chair.GetComponent<UnityEngine.ConstantForce>();
                }
                return _JetpackForce;
            }
        }


        private Transform _Thruster { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform Thruster
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Thruster == null)
                {
                    _Thruster = transform.FindObject("Thruster");
                }
                return _Thruster;
            }
        }

        private Transform _Thruster_Joypad { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform Thruster_Joypad
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Thruster_Joypad == null)
                {
                    _Thruster_Joypad = transform.FindObject("Thruster_Joypad");
                }
                return _Thruster_Joypad;
            }
        }

        private Transform _Thruster_Joypad_Grip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform Thruster_Joypad_Grip
        {
            [HideFromIl2Cpp]
            get
            {
                if (Thruster_Joypad == null) return null;
                if (_Thruster_Joypad_Grip == null)
                {
                    _Thruster_Joypad_Grip = Thruster_Joypad.FindObject("Grip");
                }
                return _Thruster_Joypad_Grip;
            }
        }


        private PositionConstraint _Thruster_Joypad_PositionConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PositionConstraint Thruster_Joypad_PositionConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (Thruster_Joypad == null) return null;
                if (_Thruster_Joypad_PositionConstraint == null)
                {
                    _Thruster_Joypad_PositionConstraint = Thruster_Joypad.GetComponent<PositionConstraint>();
                }
                return _Thruster_Joypad_PositionConstraint;
            }
        }
        private RotationConstraint _Thruster_Joypad_RotationConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RotationConstraint Thruster_Joypad_RotationConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (Thruster_Joypad == null) return null;
                if (_Thruster_Joypad_RotationConstraint == null)
                {
                    _Thruster_Joypad_RotationConstraint = Thruster_Joypad.GetComponent<RotationConstraint>();
                }
                return _Thruster_Joypad_RotationConstraint;
            }
        }

        private Transform _LowerJet { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform LowerJet
        {
            [HideFromIl2Cpp]
            get
            {
                if (Thruster == null) return null;
                if (_LowerJet == null)
                {
                    _LowerJet = Thruster.FindObject("LowerJet");
                }
                return _LowerJet;
            }
        }
        private Transform _LowerJet_ON { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform LowerJet_ON
        {
            [HideFromIl2Cpp]
            get
            {
                if (LowerJet == null) return null;

                if (_LowerJet_ON == null)
                {
                    _LowerJet_ON = LowerJet.FindObject("On");
                }
                return _LowerJet_ON;
            }
        }
        private Transform _LowerJet_OFF { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform LowerJet_OFF
        {
            [HideFromIl2Cpp]
            get
            {
                if (LowerJet == null) return null;

                if (_LowerJet_OFF == null)
                {
                    _LowerJet_OFF = LowerJet.FindObject("Off");
                }
                return _LowerJet_OFF;
            }
        }
        private UnityEngine.ConstantForce _ThrusterForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private UnityEngine.ConstantForce ThrusterForce
        {
            [HideFromIl2Cpp]
            get
            {
                if (Thruster == null) return null;
                if (_ThrusterForce == null)
                {
                    _ThrusterForce = Thruster.GetComponent<UnityEngine.ConstantForce>();
                }
                return _ThrusterForce;
            }
        }
        private Animation _QuickBoost { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Animation QuickBoost
        {
            [HideFromIl2Cpp]
            get
            {
                if (Thruster == null) return null;
                if (_QuickBoost == null)
                {
                    _QuickBoost = Thruster.GetComponent<Animation>();
                }
                return _QuickBoost;
            }
        }

        private Transform _ParticleQuickBoost { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform ParticleQuickBoost
        {
            [HideFromIl2Cpp]
            get
            {
                if (Thruster == null) return null;

                if (_ParticleQuickBoost == null)
                {
                    _ParticleQuickBoost = Thruster.FindObject("ParticleQuickBoost");
                }
                return _ParticleQuickBoost;
            }
        }

        private ParticleSystem _QuickBoostParticles { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem QuickBoostParticles
        {
            [HideFromIl2Cpp]
            get
            {
                if (ParticleQuickBoost == null) return null;
                if (_QuickBoostParticles == null)
                {
                    _QuickBoostParticles = ParticleQuickBoost.GetComponent<ParticleSystem>();
                }
                return _QuickBoostParticles;
            }
        }

        private Transform _ParticleThrust { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform ParticleThrust
        {
            [HideFromIl2Cpp]
            get
            {
                if (Chair == null) return null;

                if (_ParticleThrust == null)
                {
                    _ParticleThrust = Chair.FindObject("ParticleThrust");
                }
                return _ParticleThrust;
            }
        }

        private ParticleSystem _ParticleThrustParticles { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private ParticleSystem ParticleThrustParticles
        {
            [HideFromIl2Cpp]
            get
            {
                if (ParticleThrust == null) return null;
                if (_ParticleThrustParticles == null)
                {
                    _ParticleThrustParticles = ParticleThrust.GetComponent<ParticleSystem>();
                }
                return _ParticleThrustParticles;
            }
        }
        internal Vector3 Default_Thruster_Joystick_Pos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Quaternion Default_Thruster_Joystick_Rot  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal Vector3 Default_Movement_Joystick_Pos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Quaternion Default_Movement_Joystick_Rot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        internal VRC_AstroPickup JetstickPickup {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }

        internal VRC_AstroPickup Thruster_JoypadPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal VRC_AstroStation CurrentChair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float Current_Thruster_Force
        {
            get
            {
                if(ThrusterForce != null)
                {
                    return ThrusterForce.relativeForce.x;
                }
                return default;
            }
            set
            {
                if(ThrusterForce != null)
                {
                    ThrusterForce.relativeForce = new Vector3(value, 0, 0);
                }
            }
        }
        internal float Current_Jetpack_Force
        {
            get
            {
                if (JetpackForce != null)
                {
                    return JetpackForce.relativeForce.x;
                }
                return default;
            }
            set
            {
                if (JetpackForce != null)
                {
                    JetpackForce.relativeForce = new Vector3(value, 0, 0);
                }
            }
        }

    }
}