namespace AstroClient.Components
{
    using AstroLibrary.Extensions;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Forces;

    [RegisterComponent]

    public class SpinnerBehaviour : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public SpinnerBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        private void Start()
        {
            RigidBody = GetComponent<Rigidbody>();
            OnlineEditor.TakeObjectOwnership(gameObject);
            RigidBodyController = GetComponent<RigidBodyController>();
            PickupController = GetComponent<PickupController>();

            if (PickupController == null)
            {
                PickupController = gameObject.AddComponent<PickupController>();
            }
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += new Action(() => { isPaused = true; });
                VRC_AstroPickup.OnPickupUseDown += new Action(() => { IsEnabled = !IsEnabled; });
                VRC_AstroPickup.OnDrop += new Action(() => { isPaused = false; });

            }
            if (RigidBodyController == null)
            {
                RigidBodyController = gameObject.AddComponent<RigidBodyController>();
                HasRequiredSettings = false;
            }
            else
            {
                HasRequiredSettings = false;
            }
            IsEnabled = true;
        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                OnlineEditor.RemoveOwnerShip(gameObject);
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


        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (!IsEnabled || isPaused)
                {
                    return;
                }

                if (PickupController.IsHeld)
                {
                    if (HasRequiredSettings)
                    {
                        RigidBodyController.RestoreOriginalBody();
                        HasRequiredSettings = false;
                    }
                    return;
                }

                if (Time.time - LastTimeCheck > SpinnerTimer)
                {
                    if (!HasRequiredSettings)
                    {
                        if (!RigidBodyController.EditMode)
                        {
                            RigidBodyController.EditMode = true;
                        }
                        if (!PickupController.IsHeld)
                        {
                            if (RigidBodyController != null)
                            {
                                RigidBodyController.isKinematic = false;
                                RigidBodyController.angularDrag = 0;
                                RigidBodyController.drag = 0;
                            }
                            HasRequiredSettings = true;
                        }
                    }
                    if (!PickupController.IsHeld)
                    {
                        if (!gameObject.IsOwner())
                        {
                            gameObject.TakeOwnership();
                        }
                        SpinObject(gameObject, ForceX, 0, 0);
                        SpinObject(gameObject, 0, ForceY, 0);
                        SpinObject(gameObject, 0, 0, ForceZ);
                    }

                    LastTimeCheck = Time.time;
                }
            }
            catch (Exception)
            {
            }
        }

        #region actions

        private void Run_OnOnSpinnerPropertyChanged()
        {
            OnSpinnerPropertyChanged?.Invoke();
        }

        internal void SetOnSpinnerPropertyChanged(Action action)
        {
            OnSpinnerPropertyChanged += action;
        }


        internal void RemoveActionEvents()
        {
            OnSpinnerPropertyChanged = null;
        }

        private event Action? OnSpinnerPropertyChanged;

        #endregion actions

        internal float TimerOffset = 0f;

        private float LastTimeCheck = 0;

        private float _ForceX { get; set; }
        internal float ForceX
        {
            get
            {
                return _ForceX;
            }
            set
            {
                _ForceX = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }
        private float _ForceY { get; set; }
        internal float ForceY
        {
            get
            {
                return _ForceY;
            }
            set
            {
                _ForceY = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }


        private float _ForceZ { get; set; }
        internal float ForceZ
        {
            get
            {
                return _ForceZ;
            }
            set
            {
                _ForceZ = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }



        private float _SpinnerTimer { get; set; } = 0.03f;
        internal float SpinnerTimer
        {
            get
            {
                return _SpinnerTimer;
            }
            set
            {
                _SpinnerTimer = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private bool HasRequiredSettings { get; set; } = false;
        private Rigidbody RigidBody { get; set; }= null;
        private RigidBodyController  RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }

        private VRC_AstroPickup VRC_AstroPickup { get; set; }
        private string OriginalText_Use { get; set; }
        private bool isPaused { get; set; }


        private bool _IsEnabled = true;
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
                        VRC_AstroPickup.UseText = "Toggle Off Spinner";
                    }
                    else
                    {
                        VRC_AstroPickup.UseText = "Toggle On Spinner";
                    }
                }
            }

        }

    }
}