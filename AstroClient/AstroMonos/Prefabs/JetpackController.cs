using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
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
using VRCStation = VRC.SDKBase.VRCStation;

namespace AstroClient.AstroMonos.Prefabs
{
    [RegisterComponent]
    public class JetpackController : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public JetpackController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }


        private GameObject CurrentAvatar { get; set; } = null;

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

        private  void ActivateConstraint()
        {
            if(JetpackScaleConstraint != null)
            {
                CleanConstraint();
            }
            
            transform.localScale = Vector3.one;
            if (CurrentAvatar == null)
            {
                CurrentAvatar = GameInstances.CurrentAvatar;
            }

            // Let's make a new source
            if (CurrentAvatar != null)
            {
                JetpackScaleConstraint.constraintActive = true;
                var source = GenerateSource(CurrentAvatar);
                JetpackScaleConstraint.AddSource(source);

            }

        }



        private void OnLocalAvatarLoaded(GameObject avatar)
        {
            if(avatar == null) return; 
            CurrentAvatar = GameInstances.CurrentAvatar;
            if(AdjustScaleBasedOffAvatar)
            {
                ActivateConstraint();
            }

        }




        private void Start()
        {

            // For better manageability, correct the jetpack size to avatar size.
            HasSubscribed = true;
            
            


            if (VRCChairStick != null)
            {
                JetstickPickup = VRCChairStick.GetOrAddComponent<VRC_AstroPickup>();
                if (JetstickPickup != null)
                {
                    JetstickPickup.ForcePickupComponent = true;
                    JetstickPickup.PickupController.pickupable = true;
                    JetstickPickup.OnPickup = VRCChairStick_OnPickup;
                    JetstickPickup.OnPickupUseDown = VRCChairStick_OnPickupUseDown;
                    JetstickPickup.OnPickupUseUp = VRCChairStick_OnPickupUseUp;
                    JetstickPickup.OnDrop = VRCChairStick_OnDrop;
                    JetstickPickup.interactText = "Jet";
                    JetstickPickup.InteractionText = "Jet";
                }
            }

            if (ThrusterStick != null)
            {
                ThrusterStickPickup = ThrusterStick.GetOrAddComponent<VRC_AstroPickup>();
                if (ThrusterStickPickup != null)
                {
                    ThrusterStickPickup.ForcePickupComponent = true;
                    ThrusterStickPickup.PickupController.pickupable = true;
                    ThrusterStickPickup.OnPickup = ThrusterStick_OnPickup;
                    ThrusterStickPickup.OnPickupUseDown = ThrusterStick_OnPickupUseDown;
                    ThrusterStickPickup.OnPickupUseUp = ThrusterStick_OnPickupUseUp;
                    ThrusterStickPickup.OnDrop = ThrusterStick_OnDrop;
                    ThrusterStickPickup.interactText = "Thruster";
                    ThrusterStickPickup.InteractionText = "Thruster";
                }
            }
            
            if(VRCChair != null)
            {
                // Check if Chair is present
                bool isPresent = VRCChair.GetComponent<VRC_Station>() != null || VRCChair.GetComponent<VRCStation>() != null;
                CurrentChair = VRCChair.GetOrAddComponent<VRC_AstroStation>();
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
                            if (ThrusterStick != null)
                            {
                                CurrentChair.BlockVanillaStationExit = true;
                            }
                        });
                    
                    CurrentChair.OnStationExitEvent = OnStationExit;
                }
            }

        }



        private ConstraintSource GenerateSource(GameObject avatar)
        {
            return new ConstraintSource
            {
                m_SourceTransform = CurrentAvatar.transform,
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
        private void VRCChairStick_OnPickupUseDown()
        {
            JetpackForce.enabled = true;
            ParticleThrustParticles.Play();
            UpperJet_ON.gameObject.SetActive(true);
            UpperJet_OFF.gameObject.SetActive(false);
        }


        private void VRCChairStick_OnPickupUseUp()
        {
            JetpackForce.enabled = false;
            //ParticleThrustParticles.Play();
            UpperJet_ON.gameObject.SetActive(false);
            UpperJet_OFF.gameObject.SetActive(true);

        }

        private void ThrusterStick_OnPickupUseDown()
        {
            ThrusterForce.enabled = true;
            QuickBoost.Play("quickboost");
            QuickBoostParticles.Play();
            LowerJet_OFF.gameObject.SetActive(false);
            LowerJet_ON.gameObject.SetActive(true);

        }



        private void OnStationExit()
        {
            Destroy(this.gameObject);
        }

        private void ThrusterStick_OnPickup()
        {
            if (ThrusterStick_PositionConstraint != null)
            {
                ThrusterStick_PositionConstraint.enabled = false;
            }
            if (ThrusterStick_RotationConstraint != null)
            {
                ThrusterStick_RotationConstraint.enabled = false;
            }


        }

        private void ThrusterStick_OnDrop()
        {
            if (ThrusterStick_PositionConstraint != null)
            {
                ThrusterStick_PositionConstraint.enabled = true;
            }
            if (ThrusterStick_RotationConstraint != null)
            {
                ThrusterStick_RotationConstraint.enabled = true;
            }
        }


        private void VRCChairStick_OnPickup()
        {
            if (VRCChairStick_PositionConstraint != null)
            {
                VRCChairStick_PositionConstraint.enabled = false;
            }
            if (VRCChairStick_RotationConstraint != null)
            {
                VRCChairStick_RotationConstraint.enabled = false;
            }


        }

        private void VRCChairStick_OnDrop()
        {
            if (VRCChairStick_PositionConstraint != null)
            {
                VRCChairStick_PositionConstraint.enabled = true;
            }
            if (VRCChairStick_RotationConstraint != null)
            {
                VRCChairStick_RotationConstraint.enabled = true;
            }
        }

        private void ThrusterStick_OnPickupUseUp()
        {
            ThrusterForce.enabled = false;
            //QuickBoost.Play("quickboost");
            //QuickBoostParticles.Play();
            LowerJet_OFF.gameObject.SetActive(true);
            LowerJet_ON.gameObject.SetActive(false);

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


        private Transform _VRCChair {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }
        private Transform VRCChair
        {
            [HideFromIl2Cpp]
            get
            {
                if(_VRCChair == null)
                {
                    _VRCChair = gameObject.transform.root.FindObject("VRCChair");
                }
                return _VRCChair;
            }
        }

        private Transform _Collider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform SeatCollider
        {
            [HideFromIl2Cpp]
            get
            {
                if (VRCChair == null) return null;
                if (_Collider == null)
                {
                    _Collider = VRCChair.FindObject("Collider");
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
                if (VRCChair == null) return null;
                if (_Enter_Point == null)
                {
                    _Enter_Point = VRCChair.FindObject("Enter Point");
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
                if (VRCChair == null) return null;
                if (_Exit_Point == null)
                {
                    _Exit_Point = VRCChair.FindObject("Exit Point");
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
                if (VRCChair == null) return null;
                if (_UpperJet == null)
                {
                    _UpperJet = VRCChair.FindObject("UpperJet");
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
                if (VRCChair == null) return null;

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
                if (VRCChair == null) return null;

                if (_UpperJet_OFF == null)
                {
                    _UpperJet_OFF = UpperJet.FindObject("Off");
                }
                return _UpperJet_OFF;
            }
        }

        private Transform _VRCChairStick {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }
        private Transform VRCChairStick
        {
            [HideFromIl2Cpp]
            get
            {
                if (_VRCChairStick == null)
                {
                    _VRCChairStick = gameObject.transform.root.FindObject("VRCChairStick");
                }
                return _VRCChairStick;
            }
        }

        private PositionConstraint _VRCChairStick_PositionConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PositionConstraint VRCChairStick_PositionConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (VRCChairStick == null) return null;
                if (_VRCChairStick_PositionConstraint == null)
                {
                    _VRCChairStick_PositionConstraint = VRCChairStick.GetComponent<PositionConstraint>();
                }
                return _VRCChairStick_PositionConstraint;
            }
        }
        private RotationConstraint _VRCChairStick_RotationConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RotationConstraint VRCChairStick_RotationConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (VRCChairStick == null) return null;
                if (_VRCChairStick_RotationConstraint == null)
                {
                    _VRCChairStick_RotationConstraint = VRCChairStick.GetComponent<RotationConstraint>();
                }
                return _VRCChairStick_RotationConstraint;
            }
        }

        private UnityEngine.ConstantForce _JetpackForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private UnityEngine.ConstantForce JetpackForce
        {
            [HideFromIl2Cpp]
            get
            {
                if (VRCChair == null) return null;
                if (_JetpackForce == null)
                {
                    _JetpackForce = VRCChair.GetComponent<UnityEngine.ConstantForce>();
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
                    _Thruster = gameObject.transform.root.FindObject("Thruster");
                }
                return _Thruster;
            }
        }

        private Transform _ThrusterStick { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform ThrusterStick
        {
            [HideFromIl2Cpp]
            get
            {
                if (_ThrusterStick == null)
                {
                    _ThrusterStick = gameObject.transform.root.FindObject("ThrusterStick");
                }
                return _ThrusterStick;
            }
        }

        private PositionConstraint _ThrusterStick_PositionConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PositionConstraint ThrusterStick_PositionConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (ThrusterStick == null) return null;
                if (_ThrusterStick_PositionConstraint == null)
                {
                    _ThrusterStick_PositionConstraint = ThrusterStick.GetComponent<PositionConstraint>();
                }
                return _ThrusterStick_PositionConstraint;
            }
        }
        private RotationConstraint _ThrusterStick_RotationConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RotationConstraint ThrusterStick_RotationConstraint
        {
            [HideFromIl2Cpp]
            get
            {
                if (ThrusterStick == null) return null;
                if (_ThrusterStick_RotationConstraint == null)
                {
                    _ThrusterStick_RotationConstraint = ThrusterStick.GetComponent<RotationConstraint>();
                }
                return _ThrusterStick_RotationConstraint;
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
                if (VRCChair == null) return null;

                if (_ParticleThrust == null)
                {
                    _ParticleThrust = VRCChair.FindObject("ParticleThrust");
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

        internal VRC_AstroPickup JetstickPickup {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }

        internal VRC_AstroPickup ThrusterStickPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal VRC_AstroStation CurrentChair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

    }
}