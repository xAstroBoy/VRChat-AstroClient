namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using System;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;

    [RegisterComponent]
    public class VRC_AstroPickup : MonoBehaviour
    {
        public VRC_AstroPickup(IntPtr ptr)
            : base(ptr)
        {
        }
        private SerializedUdonProgramAsset AssignedProgram { get; } = UdonPrograms.PickupProgram;

        internal void Start()
        {
            if (AssignedProgram == null)
            {
                ModConsole.DebugError("Custom Pickup Events Can't Load as Program Asset is null!");
                Destroy(this);
            }

            UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
            if (UdonBehaviour != null)
            {
                UdonBehaviour.serializedProgramAsset = AssignedProgram;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
            }
        }

        // For now.

        internal void FixedUpdate()
        {
            if (UdonBehaviour == null)
            {
                UdonBehaviour = base.gameObject.AddComponent<UdonBehaviour>();
                UdonBehaviour.serializedProgramAsset = AssignedProgram;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
            }
            else
            {
                if (UdonBehaviour.serializedProgramAsset == null)
                {
                    UdonBehaviour.serializedProgramAsset = AssignedProgram;
                    UdonBehaviour.InitializeUdonContent();
                    UdonBehaviour.Start();
                }

                if (UdonBehaviour != null && UdonBehaviour._udonVM != null && !UdonBehaviour._udonManager != null)
                {
                    if (IUdonHeap == null)
                    {
                        IUdonHeap = UdonBehaviour._udonVM.InspectHeap();
                    }
                    if (IUdonHeap != null)
                    {
                        if (Get_OnPickup)
                        {
                            OnPickup();
                        }
                        if (Get_OnPickupUseUp)
                        {
                            OnPickupUseUp();
                        }
                        if (Get_OnPickupUseDown)
                        {
                            OnPickupUseDown();
                        }
                        if (Get_OnDrop)
                        {
                            OnDrop();
                        }
                    }
                }
            }
        }


        internal void OnDestroy()
        {
            if(UdonBehaviour != null)
            {
                Destroy(UdonBehaviour);
            }
        }

        internal void OnDisable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = false;
            }
        }


        internal void OnEnable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = true;
            }
        }


        private void SetBackToFalse(uint one)
        {
            if (IUdonHeap == null)
            {
                IUdonHeap = UdonBehaviour._udonVM.InspectHeap();
            }
            IUdonHeap.CopyHeapVariable(8u, one);

        }


        private bool Get_OnPickup
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(Addresses.OnPickup).Unbox<bool>();
                SetBackToFalse(Addresses.OnPickup);
                return result;
            }
        }



        private bool Get_OnPickupUseUp
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(Addresses.OnPickupUseUp).Unbox<bool>();
                SetBackToFalse(Addresses.OnPickupUseUp);
                return result;
            }
        }



        private bool Get_OnPickupUseDown
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(Addresses.OnPickupUseDown).Unbox<bool>();
                SetBackToFalse(Addresses.OnPickupUseDown);
                return result;
            }
        }

        private bool Get_OnDrop
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(Addresses.OnDrop).Unbox<bool>();
                SetBackToFalse(Addresses.OnDrop);
                return result;
            }
        }


        private string _UseText = "Use";

        internal string UseText
        {
            get => _UseText;
            set
            {
                _UseText = value;
                if(Controller != null)
                {
                    Controller.UseText = value;
                }
            }
        }

        private string _InteractionText;

        internal string InteractionText
        {
            get => _InteractionText;
            set
            {
                _InteractionText = value;
                if (Controller != null)
                {
                    Controller.InteractionText = value;
                }
            }
        }


        private struct Addresses
        {
            internal const uint OnDrop  = 7;
            internal const uint OnDrop_1 = 2;
            internal const uint OnPickup = 4;
            internal const uint OnPickup_1 = 3;
            internal const uint OnPickupUseDown = 6;
            internal const uint OnPickupUseDown_1 = 0;
            internal const uint OnPickupUseUp = 5;
            internal const uint OnPickupUseUp_1 = 1;
            internal const uint AlwaysFalse = 8;
        }
        internal Action OnPickup { get; set; }
        internal Action OnPickupUseUp { get; set; }
        internal Action OnPickupUseDown { get; set; }
        internal Action OnDrop { get; set; }
        internal bool IsForcedPickupController { get; set; } = false;
        private PickupController _Controller;
        private PickupController Controller
        {
            get
            {
                if(_Controller == null)
                {
                    if(IsForcedPickupController)
                    {
                        return _Controller = gameObject.AddComponent<PickupController>();
                    }
                    return _Controller = gameObject.GetComponent<PickupController>();
                }
                return _Controller;
            }
        }
        internal UdonBehaviour UdonBehaviour { get; private set; }
        private IUdonHeap IUdonHeap { get;  set; }
    }
}