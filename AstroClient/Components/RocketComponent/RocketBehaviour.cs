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

        // Update is called once per frame
        private void Update()
        {
            try
            {
                if (!IsEnabled || isPaused)
                {
                    if (HasRequiredSettings)
                    {
                        HasRequiredSettings = false;
                    }
                    return;
                }
                //if (!CheckisOwner)
                //{
                //    if (Time.time - CheckisOwnerTimeCheck > CheckisOwnerDelay)
                //    {
                //        CheckisOwner = true;
                //        CheckisOwnerTimeCheck = Time.time;
                //    }
                //}
                    if (Time.time - RocketTimeCheck > RocketTimer)
                { 
                    if (isHeld)
                    {
                        if (HasRequiredSettings)
                        {
                            HasRequiredSettings = false;
                        }
                        return;
                    }
                    else
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

                    }
                    RocketTimeCheck = Time.time;
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
            IsEnabled = true;
        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                if (isOwner)
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

        private float CheckisOwnerTimeCheck { get; set; } = 0;

        private float CheckisOwnerDelay { get; set; } = 16f;
        private bool CheckisOwner { get; set; } = false;


        private float RocketTimeCheck { get; set; } = 0;
        private float _RocketTimer { get; set; } = 0.07f;
        internal float RocketTimer
        {
            get => _RocketTimer;
            set
            {
                _RocketTimer = value;
                Run_OnOnRocketPropertyChanged();
            }
        }

        private bool _ShouldBeAlwaysUp { get; set; } = false;
        internal bool ShouldBeAlwaysUp
        {
            get => _ShouldBeAlwaysUp;
            set
            {
                _ShouldBeAlwaysUp = value;
                Run_OnOnRocketPropertyChanged();
            }
        }

        private bool _UseGravity { get; set; } = false;
        internal bool UseGravity
        {
            get => _UseGravity;
            set
            {
                _UseGravity = value;
                Run_OnOnRocketPropertyChanged();
            }
        }


        private bool isCurrentOwner
        {
            get
            {
                    if (!gameObject.IsOwner())
                    {
                        gameObject.TakeOwnership();
                    }
                    return gameObject.IsOwner();
                //if (CheckisOwner)
                //{
                //}
                //else
                //{
                //    return true;
                //}
            }
        }
        private bool isHeld => PickupController.IsHeld;

        private bool _HasRequiredSettings = false;
        private bool HasRequiredSettings
        {
            get => _HasRequiredSettings;
            set
            {
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
        private RigidBodyController RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }
        private VRC_AstroPickup VRC_AstroPickup { get; set; }
        private string OriginalText_Use { get; set; }

        private bool isPaused { get; set; }

        private bool _IsEnabled;
        internal bool IsEnabled
        {
            get => _IsEnabled;
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