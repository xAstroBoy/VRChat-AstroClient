namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Forces;

    [RegisterComponent]
    public class CrazyBehaviour : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public CrazyBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        private void Start()
        {
            RigidBody = GetComponent<Rigidbody>();
            RigidBodyController = GetComponent<RigidBodyController>();
            if (RigidBodyController == null)
            {
                RigidBodyController = gameObject.AddComponent<RigidBodyController>();
            }
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
            IsEnabled = false;
        }

        private void Update()
        {
            if (!IsEnabled || isPaused || isHeld)
            {
                if (HasRequiredSettings)
                {
                    HasRequiredSettings = false;
                }
                return;
            }
            if (!CheckisOwner)
            {
                if (Time.time - CheckisOwnerTimeCheck > CheckisOwnerDelay)
                {
                    CheckisOwner = true;
                    CheckisOwnerTimeCheck = Time.time;
                }
            }
            if (Time.time - CrazyTimeCheck > CrazyTimer)
            {
                if (!HasRequiredSettings)
                {
                    HasRequiredSettings = true;
                }
                if (isCurrentOwner)
                {
                    if (Time.time - InpulseTimeCheck > ImpulseTimer)
                    {
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
                            InpulseTimeCheck = Time.time;
                        }
                    }
                    if (Time.time - CrazyTimeCheck > CrazyTimer)
                    {
                        if (!PickupController.IsHeld && !gameObject.IsOwner())
                        {
                            gameObject.TakeOwnership();
                        }
                        if (!IsDoingImpulseMode)
                        {
                            ApplyRelativeForce(gameObject, UnityEngine.Random.Range(1f, 8f), 0, 0);

                            SpinObject(gameObject, UnityEngine.Random.Range(0f, 2f), 0, 0);

                            ApplyRelativeForce(gameObject, 0, UnityEngine.Random.Range(1f, 8f), 0);

                            SpinObject(gameObject, 0, UnityEngine.Random.Range(0f, 2f), 0);

                            ApplyRelativeForce(gameObject, 0, 0, UnityEngine.Random.Range(1f, 8f));

                            SpinObject(gameObject, 0, 0, UnityEngine.Random.Range(0f, 2f));
                        }
                        CrazyTimeCheck = Time.time;
                    }
                }

            }
        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                if (gameObject.IsOwner())
                {
                    OnlineEditor.RemoveOwnerShip(gameObject);
                }
                if (VRC_AstroPickup != null)
                {
                    Destroy(VRC_AstroPickup);
                }
                PickupController.UseText = OriginalText_Use;
            }
            catch { }
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
        private float CrazyTimeCheck { get; set; } = 0;
        private float InpulseTimeCheck { get; set; } = 0;

        private float _CrazyTimer { get; set; } = 0.04f;
        internal float CrazyTimer
        {
            get => _CrazyTimer;
            set
            {
                _CrazyTimer = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private float _ImpulseTimer { get; set; } = 5f;
        internal float ImpulseTimer
        {
            get => _ImpulseTimer;
            set
            {
                _ImpulseTimer = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private float _ImpulseForce { get; set; } = 1.5f;
        internal float ImpulseForce
        {
            get => _ImpulseForce;
            set
            {
                _ImpulseForce = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _ShouldDoImpulseMode { get; set; } = true;
        internal bool ShouldDoImpulseMode
        {
            get => _ShouldDoImpulseMode;
            set
            {
                _ShouldDoImpulseMode = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _IsDoingImpulseMode { get; set; } = false;
        internal bool IsDoingImpulseMode
        {
            get => _IsDoingImpulseMode;
            set
            {
                _IsDoingImpulseMode = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _IsImpulseModeActive { get; set; } = false;
        internal bool IsImpulseModeActive
        {
            get => _IsImpulseModeActive;
            set
            {
                _IsImpulseModeActive = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }


        private bool _UseGravity { get; set; }
        internal bool UseGravity
        {
            get => _UseGravity;
            set
            {
                _UseGravity = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private Rigidbody Rigidbody { get; set; }
        private RigidBodyController RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }
        private bool isHeld => PickupController.IsHeld;

        private VRC_AstroPickup VRC_AstroPickup { get; set; }

        private bool isPaused;
        private bool _IsEnabled = true;
        internal bool IsEnabled
        {
            get => _IsEnabled;
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
        private float CheckisOwnerTimeCheck { get; set; } = 0;

        private float CheckisOwnerDelay { get; set; } = 16f;
        private bool CheckisOwner { get; set; } = false;
        private bool isCurrentOwner
        {
            get
            {
                if (CheckisOwner)
                {
                    if (!gameObject.IsOwner())
                    {
                        gameObject.TakeOwnership();
                    }
                    return gameObject.IsOwner();
                }
                else
                {
                    return true;
                }
            }
        }

        private bool _HasRequiredSettings = false;
        private bool HasRequiredSettings
        {
            get => _HasRequiredSettings;
            set
            {
                if(value.Equals(_HasRequiredSettings))
                {
                    return; // Do Nothing.
                }
                _HasRequiredSettings = value;
                if (value)
                {
                    if (RigidBodyController != null)
                    {
                        if (!RigidBodyController.EditMode)
                        {
                            RigidBodyController.EditMode = true;
                        }
                        RigidBodyController.isKinematic = false;
                        RigidBodyController.useGravity = UseGravity;
                        RigidBodyController.angularDrag = 0;
                        RigidBodyController.drag = 0;
                    }
                }
                else
                {
                    RigidBodyController.RestoreOriginalBody();
                    RigidBodyController.EditMode = false;
                }
            }
        }

        private Rigidbody RigidBody { get; set; } = null;
        private string OriginalText_Use { get; set; }


        
    }
}