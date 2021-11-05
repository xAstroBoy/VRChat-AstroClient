﻿namespace AstroClient.Components
{
    using AstroLibrary.Console;
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
            RigidBodyController = GetComponent<RigidBodyController>();
            RigidBodyController ??= gameObject.AddComponent<RigidBodyController>();

            PickupController = GetComponent<PickupController>();
            PickupController ??= gameObject.AddComponent<PickupController>();
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += new Action(() => { isPaused = true; });
                VRC_AstroPickup.OnPickupUseDown += new Action(() => { IsEnabled = !IsEnabled; });
                VRC_AstroPickup.OnDrop += new Action(() => { isPaused = false; });
            }
            IsEnabled = true;
        }

        private void Update()
        {
            if (!IsEnabled || isPaused || isHeld)
            {
                if (HasRequiredSettings) HasRequiredSettings = false;
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
            if (Time.time - SpinnerTimeCheck > SpinnerTimer)
            {
                if (!HasRequiredSettings) HasRequiredSettings = true;
                if (isCurrentOwner)
                {
                    SpinObject(gameObject, ForceX, 0, 0);
                    SpinObject(gameObject, 0, ForceY, 0);
                    SpinObject(gameObject, 0, 0, ForceZ);
                }
                SpinnerTimeCheck = Time.time;
            }
        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                if (gameObject.IsOwner()) OnlineEditor.RemoveOwnerShip(gameObject);
                if (VRC_AstroPickup != null) Destroy(VRC_AstroPickup);
                PickupController.UseText = OriginalText_Use;
            }
            catch { }
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
        private float _ForceX { get; set; }
        internal float ForceX
        {
            get => _ForceX;
            set
            {
                _ForceX = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private float _ForceY { get; set; }
        internal float ForceY
        {
            get => _ForceY;
            set
            {
                _ForceY = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private float _ForceZ { get; set; }
        internal float ForceZ
        {
            get => _ForceZ;
            set
            {
                _ForceZ = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private float _SpinnerTimer { get; set; } = 0.03f;
        internal float SpinnerTimer
        {
            get => _SpinnerTimer;
            set
            {
                _SpinnerTimer = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }
        private float CheckisOwnerTimeCheck = 0;

        private float CheckisOwnerDelay = 16f;
        private bool CheckisOwner = false;
        private float SpinnerTimeCheck = 0;

        private bool _ShouldBeAlwaysUp = false;
        internal bool ShouldBeAlwaysUp
        {
            get => _ShouldBeAlwaysUp;
            set
            {
                _ShouldBeAlwaysUp = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private bool _UseGravity = false;
        internal bool UseGravity
        {
            get => _UseGravity;
            set
            {
                _UseGravity = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private bool isCurrentOwner
        {
            get
            {
                if (CheckisOwner) return gameObject.TryTakeOwnership();
                else return true;
            }
        }
        private bool isHeld => PickupController.IsHeld;

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
                        if (!RigidBodyController.EditMode) RigidBodyController.EditMode = true;
                        RigidBodyController.isKinematic = false;
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

        private Rigidbody RigidBody = null;
        private RigidBodyController RigidBodyController;
        private PickupController PickupController;
        private VRC_AstroPickup VRC_AstroPickup;
        private string OriginalText_Use;

        private bool isPaused;

        private bool _IsEnabled;
        internal bool IsEnabled
        {
            get => _IsEnabled;
            set
            {
                _IsEnabled = value;
                if (VRC_AstroPickup != null)
                {
                    if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace()) OriginalText_Use = PickupController.UseText;
                    if (value) VRC_AstroPickup.UseText = "Toggle Off Spinner";
                    else VRC_AstroPickup.UseText = "Toggle On Spinner";
                }
            }

        }
    }
}