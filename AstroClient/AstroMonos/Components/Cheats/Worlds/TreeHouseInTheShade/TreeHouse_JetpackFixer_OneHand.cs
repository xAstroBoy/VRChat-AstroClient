using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using VRC.SDK3.Components;
using VRCSDK2;

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
    public class TreeHouse_JetpackFixer_OneHand : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public TreeHouse_JetpackFixer_OneHand(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        
        

        private void Start()
        {

            if (WorldUtils.WorldID.Equals(WorldIds.TreeHouseInTheShade))
            {
                Log.Debug("One Handed Jetpack Spawned, Fixing!");
                if (VRCChair != null)
                {
                    VRCChair.RemoveComponent<VRC_Station>();
                    VRCChair.RemoveComponent<VRC_TriggerInternal>();
                    //VRCChair.RemoveComponent<VRC_Trigger>();
                    VRCChair.RemoveComponent<VRC_EventHandler>();
                    VRCChair.RemoveComponent<VRC_StationInternal2>();

                    var newstation = VRCChair.AddComponent<VRC_Station>();
                    if (newstation != null)
                    {
                        var enterpoint = VRCChair.FindObject("Enter Point");
                        var exitpoint = VRCChair.FindObject("Exit Point");
                        newstation.seated = true;
                        newstation.PlayerMobility = VRC.SDKBase.VRCStation.Mobility.ImmobilizeForVehicle;
                        newstation.canUseStationFromStation = false;
                        newstation.stationEnterPlayerLocation = enterpoint;
                        newstation.stationExitPlayerLocation = exitpoint;
                    }
                }
                if (VRCChairStick != null)
                {
                    VRCChairStick.GetOrAddComponent<Enabler>();


                    // Strip the Pickup of all events that are obsolete.
                    VRCChairStick.RemoveComponent<VRC_Pickup>();
                    VRCChairStick.RemoveComponent<VRC_Trigger>();
                    VRCChairStick.RemoveComponent<VRC_EventHandler>();
                    VRCChairStick.RemoveComponent<VRC_TriggerInternal>();


                    // Add our own control system
                    JetstickPickup = VRCChairStick.GetOrAddComponent<VRC_AstroPickup>();
                    if (JetstickPickup != null)
                    {
                        Log.Debug("Patching Jetpack Stick!");

                        JetstickPickup.ForcePickupComponent = true;
                        JetstickPickup.PickupController.pickupable = true;
                        JetstickPickup.OnPickupUseDown = Enable_Jet;
                        JetstickPickup.OnPickupUseUp = Disable_Jet;
                        JetstickPickup.OnDrop = Disable_Jet;
                    }
                }

            }

        }


        private void Enable_Jet()
        {
            if (JetpackForce != null)
            {
                JetpackForce.enabled = true;
            }
            if (UpperJet_OFF)
            {
                UpperJet_OFF.gameObject.SetActive(false);

            }
            if (UpperJet_ON)
            {
                UpperJet_ON.gameObject.SetActive(true);

            }
        }


        private void Disable_Jet()
        {
            if (JetpackForce != null)
            {
                JetpackForce.enabled = false;
            }
            if (UpperJet_OFF)
            {
                UpperJet_OFF.gameObject.SetActive(true);

            }
            if (UpperJet_ON)
            {
                UpperJet_ON.gameObject.SetActive(false);

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
                if (UpperJet == null) return null;

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
                if (UpperJet == null) return null;

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

        private VRC_AstroPickup JetstickPickup {   [HideFromIl2Cpp]  get; [HideFromIl2Cpp] set; }


    }
}