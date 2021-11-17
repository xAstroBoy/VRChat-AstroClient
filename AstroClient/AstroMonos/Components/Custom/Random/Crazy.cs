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
    using Random = UnityEngine.Random;

    [RegisterComponent]
    public class CrazyBehaviour : AstroMonoBehaviour
    {
        private bool _HasRequiredSettings;
        private bool _IsEnabled = true;
        public List<AstroMonoBehaviour> AntiGcList;

        private bool isPaused;

        public CrazyBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private float CrazyTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float InpulseTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private float _CrazyTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.04f;

        internal float CrazyTimer
        {
            [HideFromIl2Cpp] get => _CrazyTimer;
            [HideFromIl2Cpp]
            set
            {
                _CrazyTimer = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private float _ImpulseTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 5f;

        internal float ImpulseTimer
        {
            [HideFromIl2Cpp] get => _ImpulseTimer;
            [HideFromIl2Cpp]
            set
            {
                _ImpulseTimer = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private float _ImpulseForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 1.5f;

        internal float ImpulseForce
        {
            [HideFromIl2Cpp] get => _ImpulseForce;
            [HideFromIl2Cpp]
            set
            {
                _ImpulseForce = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _ShouldDoImpulseMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        internal bool ShouldDoImpulseMode
        {
            [HideFromIl2Cpp] get => _ShouldDoImpulseMode;
            [HideFromIl2Cpp]
            set
            {
                _ShouldDoImpulseMode = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _IsDoingImpulseMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool IsDoingImpulseMode
        {
            [HideFromIl2Cpp] get => _IsDoingImpulseMode;
            [HideFromIl2Cpp]
            set
            {
                _IsDoingImpulseMode = value;
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private bool _IsImpulseModeActive { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool IsImpulseModeActive
        {
            [HideFromIl2Cpp] get => _IsImpulseModeActive;
            [HideFromIl2Cpp]
            set
            {
                _IsImpulseModeActive = value;
                Run_OnOnCrazyPropertyChanged();
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
                Run_OnOnCrazyPropertyChanged();
            }
        }

        private Rigidbody Rigidbody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private RigidBodyController RigidBodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PickupController PickupController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool isHeld => PickupController.IsHeld;

        private VRC_AstroPickup VRC_AstroPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

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

                    if (value)
                        VRC_AstroPickup.UseText = "Toggle Off Crazy Object";
                    else
                        VRC_AstroPickup.UseText = "Toggle On Crazy Object";
                }
            }
        }

        private float CheckisOwnerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private float CheckisOwnerDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 16f;
        private bool CheckisOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool isCurrentOwner
        {
            [HideFromIl2Cpp]
            get
            {
                if (CheckisOwner)
                    return gameObject.TryTakeOwnership();
                return true;
            }
        }

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

        private Rigidbody RigidBody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private string OriginalText_Use { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        private void Start()
        {
            RigidBody = GetComponent<Rigidbody>();
            RigidBodyController = GetComponent<RigidBodyController>();
            if (RigidBodyController == null) RigidBodyController = gameObject.AddComponent<RigidBodyController>();
            PickupController = GetComponent<PickupController>();
            if (PickupController == null) PickupController = gameObject.AddComponent<PickupController>();
            VRC_AstroPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (VRC_AstroPickup != null)
            {
                VRC_AstroPickup.OnPickup += () => { isPaused = true; };
                VRC_AstroPickup.OnPickupUseDown += () => { IsEnabled = !IsEnabled; };
                VRC_AstroPickup.OnDrop += () => { isPaused = false; };
            }

            IsEnabled = false;
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

            if (Time.time - CrazyTimeCheck > CrazyTimer)
            {
                if (!HasRequiredSettings) HasRequiredSettings = true;
                if (isCurrentOwner)
                {
                    if (Time.time - InpulseTimeCheck > ImpulseTimer)
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

                    if (Time.time - CrazyTimeCheck > CrazyTimer)
                    {
                        if (!PickupController.IsHeld) gameObject.TryTakeOwnership();
                        if (!IsDoingImpulseMode)
                        {
                            ApplyRelativeForce(gameObject, Random.Range(1f, 8f), 0, 0);
                            SpinObject(gameObject, Random.Range(0f, 2f), 0, 0);
                            ApplyRelativeForce(gameObject, 0, Random.Range(1f, 8f), 0);
                            SpinObject(gameObject, 0, Random.Range(0f, 2f), 0);
                            ApplyRelativeForce(gameObject, 0, 0, Random.Range(1f, 8f));
                            SpinObject(gameObject, 0, 0, Random.Range(0f, 2f));
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
                if (gameObject.IsOwner()) OnlineEditor.RemoveOwnerShip(gameObject);
                if (VRC_AstroPickup != null) Destroy(VRC_AstroPickup);
                PickupController.UseText = OriginalText_Use;
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
    }
}