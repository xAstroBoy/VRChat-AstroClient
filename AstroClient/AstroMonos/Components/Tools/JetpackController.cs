using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using Boo.Lang.Compiler.Ast;
using VRC.SDK3.Components;
using VRCSDK2;
using VRCStation = VRC.SDKBase.VRCStation;

namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
    using ClientResources.Loaders;
    using Il2CppSystem.Collections.Generic;
    using Spawnables.Enderpearl;
    using System;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class JetpackController : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public JetpackController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }




        private void Start()
        {
            if (VRCChairStick != null)
            {
                JetstickPickup = VRCChairStick.GetOrAddComponent<VRC_AstroPickup>();
                if (JetstickPickup != null)
                {
                    JetstickPickup.ForcePickupComponent = true;
                    JetstickPickup.PickupController.pickupable = true;
                    JetstickPickup.OnPickupUseDown = Enable_Jet;
                    JetstickPickup.OnPickupUseUp = Disable_Jet;
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
                    ThrusterStickPickup.OnPickupUseDown = Enable_Thruster;
                    ThrusterStickPickup.OnPickupUseUp = Disable_Thruster;
                    ThrusterStickPickup.interactText = "Thruster";
                    ThrusterStickPickup.InteractionText = "Thruster";
                }
            }
            
            if(VRCChair != null)
            {
                CurrentChair = VRCChair.GetOrAddComponent<VRC_AstroStation>();
                if(CurrentChair != null)
                {
                    MiscUtils.DelayFunction(1f, () =>
                    {
                        CurrentChair.Station.PlayerMobility = VRCStation.Mobility.ImmobilizeForVehicle;
                        //CurrentChair.Station.canUseStationFromStation = false;
                        CurrentChair.Station.seated = true;
                        CurrentChair.Station.stationEnterPlayerLocation = Enter_Point;
                        CurrentChair.Station.stationExitPlayerLocation = Exit_Point;
                        //CurrentChair.Station.disableStationExit = true;
                        CurrentChair.OnStationEnterEvent = OnStationEnter;
                        CurrentChair.OnStationExitEvent = OnStationExit;

                    });
                }
            }

        }


        private void Enable_Jet()
        {
            JetpackForce.enabled = true;
            ParticleThrustParticles.Play();
            UpperJet_ON.gameObject.SetActive(true);
            UpperJet_OFF.gameObject.SetActive(false);
        }


        private void Disable_Jet()
        {
            JetpackForce.enabled = false;
            //ParticleThrustParticles.Play();
            UpperJet_ON.gameObject.SetActive(false);
            UpperJet_OFF.gameObject.SetActive(true);

        }

        private void Enable_Thruster()
        {
            ThrusterForce.enabled = true;
            QuickBoost.Play("quickboost");
            QuickBoostParticles.Play();
            LowerJet_OFF.gameObject.SetActive(false);
            LowerJet_ON.gameObject.SetActive(true);

        }


        private void OnStationEnter()
        {
            LocalStar.gameObject.SetActive(true);
        }

        private void OnStationExit()
        {
            LocalStar.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }


        private void Disable_Thruster()
        {
            ThrusterForce.enabled = false;
            //QuickBoost.Play("quickboost");
            //QuickBoostParticles.Play();
            LowerJet_OFF.gameObject.SetActive(true);
            LowerJet_ON.gameObject.SetActive(false);

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


        private Transform _LocalStar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private Transform LocalStar
        {
            [HideFromIl2Cpp]
            get
            {
                if (VRCChair == null) return null;
                if (_LocalStar == null)
                {
                    _LocalStar = VRCChair.FindObject("LocalStar");
                }
                return _LocalStar;
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