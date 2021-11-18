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
    public class RocketBehaviour : AstroMonoBehaviour
    {
        private bool _HasRequiredSettings;

        private bool _IsEnabled;
        public List<AstroMonoBehaviour> AntiGcList;

        public RocketBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private float CheckisOwnerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private float CheckisOwnerDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 16f;
        private bool CheckisOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private float RocketTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float _RocketTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.07f;

        internal float RocketTimer
        {
            [HideFromIl2Cpp] get => _RocketTimer;
            [HideFromIl2Cpp]
            set
            {
                _RocketTimer = value;
                Run_OnOnRocketPropertyChanged();
            }
        }

        private bool _ShouldBeAlwaysUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool ShouldBeAlwaysUp
        {
            [HideFromIl2Cpp] get => _ShouldBeAlwaysUp;
            [HideFromIl2Cpp]
            set
            {
                _ShouldBeAlwaysUp = value;
                Run_OnOnRocketPropertyChanged();
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
                Run_OnOnRocketPropertyChanged();
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
                    if (value) VRC_AstroPickup.UseText = "Toggle Off Rocket";
                    else VRC_AstroPickup.UseText = "Toggle On Rocket";
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

            if (Time.time - RocketTimeCheck > RocketTimer)
            {
                if (!HasRequiredSettings) HasRequiredSettings = true;
                if (isCurrentOwner)
                {
                    if (!ShouldBeAlwaysUp) ApplyRelativeForce(gameObject, 0, Random.Range(1f, 10f), 0);
                    else ApplyForce(gameObject, 0, Random.Range(1f, 10f), 0);
                }

                RocketTimeCheck = Time.time;
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
    }
}