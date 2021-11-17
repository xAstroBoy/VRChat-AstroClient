namespace AstroClient.AstroMonos.Components.Custom.Random
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.ObjectEditor.Online;
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Extensions;
    using static AstroClient.Tools.ObjectEditor.Editor.Forces.Forces;

    [RegisterComponent]
    public class SpinnerBehaviour : AstroMonoBehaviour
    {
        private bool _HasRequiredSettings;

        private bool _IsEnabled;
        public List<AstroMonoBehaviour> AntiGcList;

        public SpinnerBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private float _ForceX { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float ForceX
        {
            [HideFromIl2Cpp] get => _ForceX;
            [HideFromIl2Cpp]
            set
            {
                _ForceX = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private float _ForceY { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float ForceY
        {
            [HideFromIl2Cpp] get => _ForceY;
            [HideFromIl2Cpp]
            set
            {
                _ForceY = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private float _ForceZ { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float ForceZ
        {
            [HideFromIl2Cpp] get => _ForceZ;
            [HideFromIl2Cpp]
            set
            {
                _ForceZ = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private float _SpinnerTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.03f;

        internal float SpinnerTimer
        {
            [HideFromIl2Cpp] get => _SpinnerTimer;
            [HideFromIl2Cpp]
            set
            {
                _SpinnerTimer = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private float CheckisOwnerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private float CheckisOwnerDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 16f;
        private bool CheckisOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float SpinnerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool _ShouldBeAlwaysUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool ShouldBeAlwaysUp
        {
            [HideFromIl2Cpp] get => _ShouldBeAlwaysUp;
            [HideFromIl2Cpp]
            set
            {
                _ShouldBeAlwaysUp = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private bool _UseGravity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool UseGravity
        {
            [HideFromIl2Cpp] get => _UseGravity;
            [HideFromIl2Cpp]
            set
            {
                _UseGravity = value;
                Run_OnOnSpinnerPropertyChanged();
            }
        }

        private bool isCurrentOwner
        {
            [HideFromIl2Cpp]
            get
            {
                if (CheckisOwner) return gameObject.TryTakeOwnership();
                return true;
            }
        }

        private bool isHeld => PickupController.IsHeld;

        private bool HasRequiredSettings
        {
            [HideFromIl2Cpp] get => _HasRequiredSettings;
            [HideFromIl2Cpp]
            set
            {
                if (value.Equals(_HasRequiredSettings)) return; // Do Nothing.
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

        private Rigidbody RigidBody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RigidBodyController RigidBodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PickupController PickupController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup VRC_AstroPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private string OriginalText_Use { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool isPaused { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool IsEnabled
        {
            [HideFromIl2Cpp] get => _IsEnabled;
            [HideFromIl2Cpp]
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
                VRC_AstroPickup.OnPickup += () => { isPaused = true; };
                VRC_AstroPickup.OnPickupUseDown += () => { IsEnabled = !IsEnabled; };
                VRC_AstroPickup.OnDrop += () => { isPaused = false; };
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
                if (Time.time - CheckisOwnerTimeCheck > CheckisOwnerDelay)
                {
                    CheckisOwner = true;
                    CheckisOwnerTimeCheck = Time.time;
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
            catch
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
    }
}