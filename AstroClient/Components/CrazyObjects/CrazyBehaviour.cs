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
    public class CrazyBehaviour : GameEventsBehaviour
    {
        public CrazyBehaviour(IntPtr ptr) : base(ptr)
        {
        }

        // Use this for initialization
        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            OnlineEditor.TakeObjectOwnership(gameObject);
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
            RigidBodyController = GetComponent<RigidBodyController>();
            if (RigidBodyController == null)
            {
                RigidBodyController = gameObject.AddComponent<RigidBodyController>();
            }
            HasRequiredSettings = false;
            IsEnabled = false;
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
                        OnlineEditor.RemoveOwnerShip(gameObject);
                        HasRequiredSettings = false;
                    }
                    return;
                }

                if (!HasRequiredSettings)
                {
                    if (!RigidBodyController.EditMode)
                    {
                        RigidBodyController.EditMode = true;
                    }
                    if (!gameObject.IsOwner() && !PickupController.IsHeld)
                    {
                        gameObject.TakeOwnership();
                        if (RigidBodyController != null)
                        {
                            RigidBodyController.isKinematic = false;
                            RigidBodyController.useGravity = UseGravity;
                            RigidBodyController.angularDrag = 0;
                            RigidBodyController.drag = 0;
                            HasRequiredSettings = true;
                        }
                    }
                }

                if (Time.time - LastTimeCheck2 > ImpulseTimer)
                {
                    if (!PickupController.IsHeld)
                    {
                        if (!gameObject.IsOwner())
                        {
                            gameObject.TakeOwnership();
                        }
                    }
                    if (ShouldDoImpulseMode)
                    {
                        if (IsImpulseModeActive && !IsDoingImpulseMode)
                        {
                            IsDoingImpulseMode = true;
                            ApplyRelativeForce(gameObject, 0, ImpulseForce, 0);
                            ApplyRelativeForce(gameObject, 0, ImpulseForce, 0);
                            ApplyRelativeForce(gameObject, 0, ImpulseForce, 0);
                            ApplyRelativeForce(gameObject, 0, ImpulseForce, 0);
                            ApplyRelativeForce(gameObject, 0, ImpulseForce, 0);
                            ApplyRelativeForce(gameObject, 0, ImpulseForce, 0);
                            IsDoingImpulseMode = false;
                        }
                        LastTimeCheck2 = Time.time;
                    }
                }

                if (Time.time - LastTimeCheck > CrazyTimer)
                {
                    if (!PickupController.IsHeld && !gameObject.IsOwner())
                    {
                        gameObject.TakeOwnership();
                    }
                    if (!IsDoingImpulseMode)
                    {
                        ApplyRelativeForce(gameObject, Random.Range(1f, 8f), 0, 0);

                        SpinObject(gameObject, Random.Range(0f, 2f), 0, 0);

                        ApplyRelativeForce(gameObject, 0, Random.Range(1f, 8f), 0);

                        SpinObject(gameObject, 0, Random.Range(0f, 2f), 0);

                        ApplyRelativeForce(gameObject, 0, 0, Random.Range(1f, 8f));

                        SpinObject(gameObject, 0, 0, Random.Range(0f, 2f));
                    }
                    LastTimeCheck = Time.time;
                }
            }
            catch
            {
            }
        }

        #region actions

        private void Run_OnOnCrazyPropertyChanged()
        {
            OnCrazyPropertyChanged?.Invoke();
        }

        internal void SetOnCrazyPropertyChanged(Action action)
        {
            OnCrazyPropertyChanged += action;
        }


        internal void RemoveActionEvents()
        {
            OnCrazyPropertyChanged = null;
        }

        private event Action? OnCrazyPropertyChanged;

        #endregion actions
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
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private float LastTimeCheck { get; set; } = 0;
        private float LastTimeCheck2 { get; set; } = 0;

        private float _CrazyTimer { get; set; } = 0.04f;
        internal float CrazyTimer
        {
            get
            {
                return _CrazyTimer;
            }
            set
            {
                _CrazyTimer = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private float _ImpulseTimer { get; set; } = 5f;
        internal float ImpulseTimer
        {
            get
            {
                return _ImpulseTimer;
            }
            set
            {
                _ImpulseTimer = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private float _ImpulseForce { get; set; } = 1.5f;
        internal float ImpulseForce
        {
            get
            {
                return _ImpulseForce;
            }
            set
            {
                _ImpulseForce = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _ShouldDoImpulseMode { get; set; } = true;
        internal bool ShouldDoImpulseMode
        {
            get
            {
                return _ShouldDoImpulseMode;
            }
            set
            {
                _ShouldDoImpulseMode = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _IsDoingImpulseMode { get; set; } = false;
        internal bool IsDoingImpulseMode
        {
            get
            {
                return _IsDoingImpulseMode;
            }
            set
            {
                _IsDoingImpulseMode = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _IsImpulseModeActive { get; set; } = false;
        internal bool IsImpulseModeActive
        {
            get
            {
                return _IsImpulseModeActive;
            }
            set
            {
                _IsImpulseModeActive = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }


        private bool _UseGravity { get; set; }
        internal bool UseGravity
        {
            get
            {
                return _UseGravity;
            }
            set
            {
                _UseGravity = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private Rigidbody Rigidbody { get; set; }
        private RigidBodyController RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }

        private bool HasRequiredSettings { get; set; } = false;


        private VRC_AstroPickup VRC_AstroPickup { get; set; }

        private bool isPaused;
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
                    if (value)
                    {
                        VRC_AstroPickup.UseText = "Toggle Off Crazy Object";
                    }
                    else
                    {
                        VRC_AstroPickup.UseText = "Toggle On Crazy Object";
                    }
                }
            }

        }
    }
}