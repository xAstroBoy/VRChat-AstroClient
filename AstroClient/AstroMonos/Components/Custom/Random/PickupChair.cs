using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Tools.Colors;
using AstroClient.xAstroBoy;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.Components.Custom.Random
{
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using System;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class PickupChair : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public PickupChair(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        private void Start()
        {
            Initialize();
        }

        internal void Initialize()
        {
            _ = Chair;
            CurrentChair = Chair.GetOrAddComponent<VRC_AstroStation>();
            if (CurrentChair != null)
            {

                CurrentChair.OnStationEnterEvent = StationEnterEvent;
                CurrentChair.OnStationExitEvent = StationExitEvent;
                MiscUtils.DelayFunction(0.1f, () =>
                {
                    CurrentChair.Station.stationEnterPlayerLocation = Chair.transform;
                    CurrentChair.Station.stationExitPlayerLocation = Chair.transform;
                    CurrentChair.Station.PlayerMobility = VRCStation.Mobility.ImmobilizeForVehicle;
                    CurrentChair.Station.seated = true;
                });
            }
            Laser = Chair.GetOrAddComponent<LineRenderer>();
            if (Laser != null)
            {
                Laser.material = new Material(Shader.Find("VRChat/UI/Additive"));
                Laser.startWidth = 0.01f;
                Laser.endWidth = 0.01f;
                Laser.widthMultiplier = 0.4f;
                Laser.startColor = SystemColors.Cyan;
                Laser.endColor = SystemColors.Cyan;
                Laser.enabled = false;
            }
            Pickup = Chair.GetOrAddComponent<VRC_AstroPickup>();
            if (Pickup != null)
            {
                Pickup.ForcePickupComponent = true;
                Pickup.OnPickup = OnPickup;
                Pickup.OnDrop = OnDrop;
                Pickup.OnPickupUseDown = PickupUseDown;

            }
            Parentcontroller = transform.GetComponent<PickupController>();
            
            HasSubscribed = true;
        }

        private void StationExitEvent()
        {
            if (Pickup != null)
            {
                Pickup.enabled = true;
            }
        }

        private void StationEnterEvent()
        {
            if (Pickup != null)
            {
                Pickup.Drop();
                Pickup.enabled = false;
            }
            if (Parentcontroller != null)
            {
                Parentcontroller.Drop();
            }
            if (Laser != null)
            {
                Laser.enabled = false;
            }
        }

        private void PickupUseDown()
        {
            CurrentChair.EnterStation();
        }

        private void Update()
        {
            if (Pickup == null) return;
            if (!Pickup.isHeld) return;
            if (Laser == null) return;
            Laser.SetPosition(0, Chair.transform.position);
            Laser.SetPosition(1, Chair.transform.position + Chair.transform.up * 10f);
        }

        private void OnPickup()
        {
            if (Laser == null) return;
            Laser.enabled = true;
        }
        private void OnDrop()
        {
            if (Laser == null) return;
            Laser.enabled = false;
        }

        private void OnDestroy()
        {
            if (_Chair != null)
            {
                Destroy(_Chair);
            }
            if (CurrentChair != null)
            {
                Destroy(CurrentChair);
            }
            if (Laser != null)
            {
                Destroy(Laser);
            }
        }

        private GameObject SpawnChairObject()
        {
            var newchair = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (newchair != null)
            {
                newchair.name = ChairName;
                newchair.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
                
                var coll = newchair.GetComponent<Collider>();
                if (coll != null)
                {
                    coll.isTrigger = true;
                }
                var rigidbody = newchair.GetOrAddComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.isKinematic = true;
                }
                newchair.transform.parent = transform;
                newchair.transform.localPosition = Vector3.zero;
                return newchair;
            }
            return null;
        }


        
        private string ChairName => "AstroClient Pickup Chair";
        private bool _HasSubscribed = false;
        private float cubeSize => 0.082f;

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
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                    }
                }
                _HasSubscribed = value;
            }
        }

        private LineRenderer Laser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private VRC_AstroStation CurrentChair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup Pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PickupController Parentcontroller { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private GameObject _Chair;

        private GameObject Chair
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Chair == null)
                {
                    _Chair = SpawnChairObject();
                }
                return _Chair;
            }
        }
    }
}