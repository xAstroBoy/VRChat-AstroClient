using AstroClient.ClientActions;
using AstroClient.Tools.Colors;

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
    public class RocketBehaviour : MonoBehaviour
    {
        private bool _HasRequiredSettings;

        private bool _IsEnabled;
        public List<MonoBehaviour> AntiGcList;

        public RocketBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        private void OnRoomLeft()
        {
            Destroy(this);
        }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
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
                //if(Laser != null)
                //{
                //    Laser.useWorldSpace = value;
                //}
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
        private LineRenderer Laser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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
                    if (value) VRC_AstroPickup.interactText = "Toggle Off Rocket";
                    else VRC_AstroPickup.interactText = "Toggle On Rocket";
                    Laser.enabled = value;
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
            Laser = gameObject.AddComponent<LineRenderer>();
            if (Laser != null)
            {
                Laser.material = new Material(Shader.Find("VRChat/UI/Additive"));
                Laser.startWidth = 0.01f;
                Laser.endWidth = 0.01f;
                Laser.widthMultiplier = 0.4f;
                Laser.startColor = SystemColors.OrangeRed;
                Laser.endColor = SystemColors.OrangeRed;
            }
            HasSubscribed = true;
            IsEnabled = false;
        }

 

        private void Update()
        {
            Laser.SetPosition(0, this.transform.position);
            if (!ShouldBeAlwaysUp)
            {
                Laser.SetPosition(1, this.transform.position + this.transform.up * 10f);
            }
            else
            {
                Laser.SetPosition(1, this.transform.position + new Vector3(0, 10f, 0) * 10f);
            }
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
                    var forceAmount = Random.Range(1f, 10f);
                    var forcevector = new Vector3(0, forceAmount, 0);
                    if (!ShouldBeAlwaysUp)
                    {
                        RigidBodyController.Rigidbody.AddRelativeForce(forcevector,  ForceMode.Impulse);
                    }
                    else
                    {
                        RigidBodyController.Rigidbody.AddForce(forcevector, ForceMode.Impulse);
                    }
                }
                RocketTimeCheck = Time.time;
            }
        }

        private void OnDestroy()
        {
            try
            {
                HasSubscribed = false;
                RigidBodyController.RestoreOriginalBody();
                if (gameObject.isLocalPlayerOwner()) OnlineEditor.RemoveOwnerShip(gameObject);
                if (VRC_AstroPickup != null) Destroy(VRC_AstroPickup);
                PickupController.UseText = OriginalText_Use;
                Laser.DestroyMeLocal(true);
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