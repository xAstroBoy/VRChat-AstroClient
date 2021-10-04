namespace AstroClient.Components
{
    using AstroLibrary.Extensions;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Forces;

    [RegisterComponent]
    public class ObjectSpinner : GameEventsBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ObjectSpinner(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public ObjectSpinner(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ObjectSpinner>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~ObjectSpinner()
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
            RigidBody = GetComponent<Rigidbody>();
            ObjectSpinnerManager.Register(this);
            OnlineEditor.TakeObjectOwnership(gameObject);
            RigidBodyController = GetComponent<RigidBodyController>();
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
            if (RigidBodyController == null)
            {
                RigidBodyController = gameObject.AddComponent<RigidBodyController>();
                HasRequiredSettings = false;
            }
            else
            {
                HasRequiredSettings = false;
            }
            IsEnabled = true;
        }

        private void OnDestroy()
        {
            try
            {
                RigidBodyController.RestoreOriginalBody();
                OnlineEditor.RemoveOwnerShip(gameObject);
                ObjectSpinnerManager.RemoveObject(gameObject);
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
                    return;
                }

                if (PickupController.IsHeld)
                {
                    if (HasRequiredSettings)
                    {
                        RigidBodyController.RestoreOriginalBody();
                        HasRequiredSettings = false;
                    }
                    return;
                }

                if (Time.time - LastTimeCheck > SpinnerTimer)
                {
                    if (!HasRequiredSettings)
                    {
                        if (!RigidBodyController.EditMode)
                        {
                            RigidBodyController.EditMode = true;
                        }
                        if (!PickupController.IsHeld)
                        {
                            if (RigidBodyController != null)
                            {
                                RigidBodyController.isKinematic = false;
                                RigidBodyController.angularDrag = 0;
                                RigidBodyController.drag = 0;
                            }
                            HasRequiredSettings = true;
                        }
                    }
                    if (!PickupController.IsHeld)
                    {
                        if (!gameObject.IsOwner())
                        {
                            gameObject.TakeOwnership();
                        }
                        SpinObject(gameObject, ForceX, 0, 0);
                        SpinObject(gameObject, 0, ForceY, 0);
                        SpinObject(gameObject, 0, 0, ForceZ);
                    }

                    LastTimeCheck = Time.time;
                }
            }
            catch (Exception)
            {
            }
        }

        internal ObjectSpinnerManager Manager = null;

        internal float TimerOffset = 0f;

        private float LastTimeCheck = 0;

        internal float ForceX { get; set; }
        internal float ForceY{ get; set; }
        internal float ForceZ{ get; set; }
        internal float SpinnerTimer { get; set; }= 0.03f;
        private bool HasRequiredSettings { get; set; }= false;
        private Rigidbody RigidBody { get; set; }= null;
        private RigidBodyController  RigidBodyController { get; set; }
        private PickupController PickupController { get; set; }

        private VRC_AstroPickup VRC_AstroPickup { get; set; }
        private string OriginalText_Use { get; set; }
        private bool isPaused { get; set; }
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
                    if (!OriginalText_Use.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        OriginalText_Use = PickupController.UseText;
                    }
                    if (value)
                    {
                        VRC_AstroPickup.UseText = "Toggle Off Spinner";
                    }
                    else
                    {
                        VRC_AstroPickup.UseText = "Toggle On Spinner";
                    }
                }
            }

        }

    }
}