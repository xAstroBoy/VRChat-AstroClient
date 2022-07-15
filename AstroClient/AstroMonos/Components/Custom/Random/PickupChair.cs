using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Tools.Colors;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.Holders;
using AstroClient.xAstroBoy;
using RootMotion.FinalIK;
using UnityEngine.Animations;
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

        private bool isDebugMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

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
                Pickup.pickupable = true;
            }
        }

        private void StationEnterEvent()
        {
            if (Pickup != null)
            {
                Pickup.Drop();
                Pickup.pickupable = false;
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
            if (!isDebugMode)
            {
                if (Pickup == null) return;
                if (Pickup.isHeld)
                {
                    if (Laser == null) return;
                    Laser.SetPosition(0, Chair.transform.position);
                    Laser.SetPosition(1, Chair.transform.position + Chair.transform.up * 10f);
                }
            }
            else
            {
                if (Laser == null) return;
                Laser.SetPosition(0, Chair.transform.position);
                Laser.SetPosition(1, Chair.transform.position + Chair.transform.up * 10f);

            }
        }


        private void OnPickup()
        {
            if (Laser == null) return;
            Laser.enabled = true;
            if (FreezeChair)
            {
                if (PosConstraint != null)
                {
                    PosConstraint.locked = false;
                    PosConstraint.constraintActive = false;
                    PosConstraint.enabled = false;
                }

                //if (RotConstraint != null)
                //{
                //    RotConstraint.locked = false;
                //    RotConstraint.constraintActive = false;
                //    RotConstraint.enabled = false;
                //}

            }
        }
        private void OnDrop()
        {
            if (Laser == null) return;
            Laser.enabled = false;
            if (FreezeChair)
            {
                if (PosConstraint != null)
                {
                    PosConstraint.translationOffset = PositionOffset;
                    PosConstraint.translationAtRest = PositionOffset;
                    PosConstraint.locked = true;
                    PosConstraint.constraintActive = true;
                    PosConstraint.enabled = true;
                }

                //if (RotConstraint != null)
                //{
                //    RotConstraint.rotationOffset = RotationOffset;
                //    RotConstraint.rotationAtRest = RotationOffset;
                //    RotConstraint.locked = true;
                //    RotConstraint.constraintActive = true;
                //    RotConstraint.enabled = true;
                //}

            }

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



        /// <summary>
        /// TODO : Calculate a perfect size for each child, so it doesn't overlap it.
        /// </summary>
        /// <returns></returns>
        private float GetCubeSize()
        {
            //// Calculate the size based off the parent transform
            //var parentSize = transform.lossyScale;
            //var parentSizeX = parentSize.x;
            //var parentSizeY = parentSize.y;
            //var parentSizeZ = parentSize.z;
            //var cubeSize (parentSizeX, parentSizeY, parentSizeZ);
            //return cubeSize;

             return 0.082f;
        }

        private string ChairName => "AstroClient Pickup Chair";
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

        private ConstraintSource GenerateConstraintRule(Transform obj)
        {
            var source = new ConstraintSource
            {
                m_SourceTransform = obj,
                m_Weight = 1
            };
            return source;
        }

        [HideFromIl2Cpp]
        internal Vector3 RotationOffset => Chair.transform.eulerAngles - transform.localEulerAngles;
        [HideFromIl2Cpp]
        internal Vector3 PositionOffset => Chair.transform.position - transform.position;



        private bool _FreezeChair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool FreezeChair
        {
            [HideFromIl2Cpp]
            get => _FreezeChair;
            [HideFromIl2Cpp]
            set
            {
                _FreezeChair = value;
                if (value)
                {
                    if (PosConstraint != null)
                    {
                        PosConstraint.translationOffset = PositionOffset;
                        PosConstraint.translationAtRest = PositionOffset;
                        PosConstraint.locked = true;
                        PosConstraint.constraintActive = true;
                        PosConstraint.enabled = true;
                    }

                    //if (RotConstraint != null)
                    //{
                    //    RotConstraint.rotationOffset = RotationOffset;
                    //    RotConstraint.rotationAtRest = RotationOffset;
                    //    RotConstraint.locked = true;
                    //    RotConstraint.constraintActive = true;
                    //    RotConstraint.enabled = true;
                    //}

                    Chair.transform.parent = SpawnedItemsHolder.GetSpawnedItemsHolder().transform;
                }
                else
                {
                    if (PosConstraint != null)
                    {
                        PosConstraint.locked = false;
                        PosConstraint.constraintActive = false;
                        PosConstraint.enabled = false;
                    }

                    //if (RotConstraint != null)
                    //{
                    //    RotConstraint.locked = false;
                    //    RotConstraint.constraintActive = false;
                    //    RotConstraint.enabled = false;
                    //}
                    Chair.transform.parent = transform;

                }
            }
        }

        private LineRenderer Laser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private VRC_AstroStation CurrentChair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RigidBodyController ChairBodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup Pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PickupController Parentcontroller { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        
        //private RotationConstraint RotConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PositionConstraint PosConstraint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private GameObject _Chair { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private GameObject Chair
        {
            [HideFromIl2Cpp]
            get
            {
                if (_Chair == null)
                {
                    _Chair = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    _Chair.name = ChairName;
                    var size = GetCubeSize();
                    _Chair.transform.localScale = new Vector3(size, size, size);

                    var coll = _Chair.GetComponent<Collider>();
                    if (coll != null)
                    {
                        coll.isTrigger = true;
                    }
                    ChairBodyController = _Chair.GetOrAddComponent<RigidBodyController>();
                    if (ChairBodyController != null)
                    {
                        ChairBodyController.EditMode = true;
                        ChairBodyController.Forced_Rigidbody = true;
                    }
                    PosConstraint = _Chair.GetOrAddComponent<PositionConstraint>();
                    if (PosConstraint != null)
                    {
                        PosConstraint.AddSource(GenerateConstraintRule(transform));
                        PosConstraint.locked = false;
                        PosConstraint.constraintActive = false;
                        PosConstraint.enabled = false;
                        PosConstraint.translationOffset = PositionOffset;
                    }
                    //RotConstraint = _Chair.GetOrAddComponent<RotationConstraint>();
                    //if (RotConstraint != null)
                    //{
                    //    RotConstraint.AddSource(GenerateConstraintRule(transform));
                    //    RotConstraint.locked = false;
                    //    RotConstraint.constraintActive = false;
                    //    RotConstraint.enabled = false;
                    //    //(RotConstraint.rotationAxis == Axis.X + Axis.Z;
                    //    RotConstraint.rotationOffset = RotationOffset;
                    //}

                    var rend = _Chair.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        rend.material = new Material(Shader.Find("VRChat/UI/Additive"))
                        {
                            color = SystemColors.OrangeRed
                        };
                    }
                    _Chair.transform.parent = transform;
                    _Chair.transform.localPosition = Vector3.zero;
                    return _Chair;

                }
                return _Chair;
            }
        }
    }
}