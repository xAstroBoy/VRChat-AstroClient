using UnhollowerBaseLib.Attributes;

namespace AstroClient.Components
{
    using AstroLibrary.Extensions;
    using System;
    using UnityEngine;
    using static AstroClient.Forces;

    [RegisterComponent]
    public class RocketBehaviour : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public RocketBehaviour(IntPtr obj0) : base(obj0)
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
            if (Time.time - RocketTimeCheck > RocketTimer)
            {
                if (!HasRequiredSettings)
                {
                    HasRequiredSettings = true;
                }
                if (isCurrentOwner)
                {
                    if (!ShouldBeAlwaysUp)
                    {
                        ApplyRelativeForce(gameObject, 0, UnityEngine.Random.Range(1f, 10f), 0);
                    }
                    else
                    {
                        ApplyForce(gameObject, 0, UnityEngine.Random.Range(1f, 10f), 0);
                    }
                }

                RocketTimeCheck = Time.time;
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

        private float CheckisOwnerTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0;

        private float CheckisOwnerDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 16f;
        private bool CheckisOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        private float RocketTimeCheck { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0;
        private float _RocketTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.07f;

        internal float RocketTimer
        {
            [HideFromIl2Cpp]
            get => _RocketTimer;
            [HideFromIl2Cpp]
            set
            {
                _RocketTimer = value;
                Run_OnOnRocketPropertyChanged();
            }
        }

        private bool _ShouldBeAlwaysUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal bool ShouldBeAlwaysUp
        {
            [HideFromIl2Cpp]
            get => _ShouldBeAlwaysUp;
            [HideFromIl2Cpp]
            set
            {
                _ShouldBeAlwaysUp = value;
                Run_OnOnRocketPropertyChanged();
            }
        }

        private bool _UseGravity { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal bool UseGravity
        {
            [HideFromIl2Cpp]
            get => _UseGravity;
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

        private bool isHeld => PickupController.IsHeld;

        private bool _HasRequiredSettings = false;

        private bool HasRequiredSettings
        {
            [HideFromIl2Cpp]
            get => _HasRequiredSettings;
            [HideFromIl2Cpp]
            set
            {
                if (value.Equals(_HasRequiredSettings))
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

        private Rigidbody RigidBody { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private RigidBodyController RigidBodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private PickupController PickupController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private VRC_AstroPickup VRC_AstroPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private string OriginalText_Use { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool isPaused { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool _IsEnabled;

        internal bool IsEnabled
        {
            [HideFromIl2Cpp]
            get => _IsEnabled;
            [HideFromIl2Cpp]
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
    }
}