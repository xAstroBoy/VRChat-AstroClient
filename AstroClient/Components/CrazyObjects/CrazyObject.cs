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
    public class CrazyObject : GameEventsBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public CrazyObject(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public CrazyObject(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<CrazyObject>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~CrazyObject()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        // Use this for initialization
        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            CrazyObjectManager.Register(this);
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
                CrazyObjectManager.RemoveObject(gameObject);
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
                    if (HasRequiredSettings)
                    {
                        RigidBodyController.RestoreOriginalBody();
                        HasRequiredSettings = false;
                    }
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

        internal CrazyObjectManager CrazyObjectManager { get; set; } = null;

        internal float TimerOffset { get; set; } = 0f;
        private float LastTimeCheck { get; set; } = 0;
        private float LastTimeCheck2 { get; set; } = 0;

        internal float CrazyTimer { get; set; } = 0.04f;
        internal float ImpulseTimer { get; set; } = 5f;
        internal float ImpulseForce { get; set; } = 1.5f;
        internal bool ShouldDoImpulseMode { get; set; } = true;
        internal bool IsDoingImpulseMode { get; set; } = false;

        internal bool IsImpulseModeActive { get; set; } = false;
        private Rigidbody Rigidbody { get; set; }
        private RigidBodyController RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }

        internal bool UseGravity { get; set; }
        private bool HasRequiredSettings { get; set; } = false;


        private VRC_AstroPickup VRC_AstroPickup { get; set; }
        private string OriginalText_Use { get; set; }
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
                    if(!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        OriginalText_Use = PickupController.UseText;
                    }
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