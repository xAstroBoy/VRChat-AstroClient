namespace AstroClient.Components
{
    using AstroLibrary.Extensions;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Forces;
    using Random = UnityEngine.Random;

    [RegisterComponent]
    public class RocketBehaviour : GameEventsBehaviour
    {
        public RocketBehaviour(IntPtr ptr) : base(ptr)
        {
        }

        // Use this for initialization
        private void Start()
        {
            RigidBody = GetComponent<Rigidbody>();
            obj = RigidBody.gameObject;
            OnlineEditor.TakeObjectOwnership(obj);
            RigidBodyController = GetComponent<RigidBodyController>();

            if (RigidBodyController == null)
            {
                RigidBodyController = obj.AddComponent<RigidBodyController>();
                HasRequiredSettings = false;
            }
            else
            {
                HasRequiredSettings = false;
            }

            PickupController = GetComponent<PickupController>();
            if (PickupController == null)
            {
                PickupController = obj.AddComponent<PickupController>();
            }
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += new Action(() => { isPaused = true; });
                VRC_AstroPickup.OnPickupUseDown += new Action(() => { IsEnabled = !IsEnabled; });
                VRC_AstroPickup.OnDrop += new Action(() => { isPaused = false; });
            }
            IsEnabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (!IsEnabled || isPaused)
                {
                    return;
                }
                if (Time.time - LastTimeCheck > RocketTimer)
                {
                    if (PickupController.IsHeld)
                    {
                        if (HasRequiredSettings)
                        {
                            OnlineEditor.RemoveOwnerShip(obj);
                            RigidBodyController.RestoreOriginalBody();
                            HasRequiredSettings = false;
                        }
                    }
                    else
                    {
                        if (!HasRequiredSettings)
                        {
                            if (!RigidBodyController.EditMode)
                            {
                                RigidBodyController.EditMode = true;
                            }
                            if (!obj.IsOwner())
                            {
                                obj.TakeOwnership();
                            }

                            if (RigidBodyController != null)
                            {
                                RigidBodyController.isKinematic = false;
                                RigidBodyController.useGravity = UseGravity;
                                RigidBodyController.angularDrag = 0;
                                RigidBodyController.drag = 0;
                            }
                            HasRequiredSettings = true;
                        }
                        if (!PickupController.IsHeld)
                        {
                            if (obj.IsOwner())
                            {
                                if (!ShouldBeAlwaysUp)
                                {
                                    ApplyRelativeForce(obj, 0, Random.Range(1f, 10f), 0);
                                }
                                else
                                {
                                    ApplyForce(obj, 0, Random.Range(1f, 10f), 0);
                                }
                            }
                            else
                            {
                                obj.TakeOwnership();
                            }
                        }
                    }
                    LastTimeCheck = Time.time;
                }
            }
            catch (Exception)
            {
            }
            IsEnabled = true;
        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                OnlineEditor.RemoveOwnerShip(obj);
                if (VRC_AstroPickup != null)
                {
                    Destroy(VRC_AstroPickup);
                }
                PickupController.UseText = OriginalText_Use;
            }
            catch
            {
            }
        }

        #region actions

        private void Run_OnOnRocketPropertyChanged()
        {
            OnRocketPropertyChanged?.Invoke();
        }

        internal void SetOnRocketPropertyChanged(Action action)
        {
            OnRocketPropertyChanged += action;
        }


        internal void RemoveActionEvents()
        {
            OnRocketPropertyChanged = null;
        }

        private event Action? OnRocketPropertyChanged;

        #endregion actions

        private float LastTimeCheck { get; set; } = 0;

        private float _UpdateTimer { get; set; } = 2f;
        internal float UpdateTimer
        {
            get
            {
                return _UpdateTimer;
            }
            set
            {
                _UpdateTimer = value;
                Run_OnOnRocketPropertyChanged();
            }
        }

        private float _TimerOffset { get; set; } = 0f;
        internal float TimerOffset
        {
            get
            {
                return _TimerOffset;
            }
            set
            {
                _TimerOffset = value;
                Run_OnOnRocketPropertyChanged();

            }
        }

        private float _RocketTimer { get; set; } = 0.07f;
        internal float RocketTimer
        {
            get
            {
                return _RocketTimer;
            }
            set
            {
                _RocketTimer = value;
                Run_OnOnRocketPropertyChanged();
            }
        }




        private bool _ShouldBeAlwaysUp { get; set; } = false;
        internal bool ShouldBeAlwaysUp
        {
            get
            {
                return _ShouldBeAlwaysUp;
            }
            set
            {
                _ShouldBeAlwaysUp = value;
                Run_OnOnRocketPropertyChanged();
            }
        }



        private bool _UseGravity { get; set; } = false;
        internal bool UseGravity
        {
            get
            {
                return _UseGravity;
            }
            set
            {
                _UseGravity = value;
                Run_OnOnRocketPropertyChanged();
            }
        }





        private Rigidbody RigidBody { get; set; } = null;
        private GameObject obj { get; set; } = null;
        private RigidBodyController RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }
        private VRC_AstroPickup VRC_AstroPickup { get; set; }
        private string OriginalText_Use { get; set; }


        private bool isPaused { get; set; }

        private bool _IsEnabled;
        internal bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                if (VRC_AstroPickup != null)
                {
                    if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        OriginalText_Use = PickupController.UseText;
                    }
                    if (value)
                    {
                        VRC_AstroPickup.UseText = "Toggle Off Rocket";
                    }
                    else
                    {
                        VRC_AstroPickup.UseText = "Toggle On Rocket";
                    }
                }
            }

        }

        private bool HasRequiredSettings { get; set; }
    }
}