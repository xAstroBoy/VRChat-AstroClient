namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
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

        private void Start()
        {
            if (AssignedProgram == null)
            {
                ModConsole.DebugError("Custom Pickup Events Can't Load as Program Asset is null!");
                Destroy(this);
            }

            UdonBehaviour = base.gameObject.AddComponent<UdonBehaviour>();
            if (UdonBehaviour != null)
            {
                UdonBehaviour.serializedProgramAsset = AssignedProgram;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
            }
            if(!UdonBehaviour.enabled)
            {
                UdonBehaviour.enabled = true;
            }
            DoChecks();
        }

        private void DoChecks()
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
            }

            if (UdonBehaviour != null && UdonBehaviour._udonVM != null)
            {
                if (IUdonHeap == null)
                {
                    IUdonHeap = UdonBehaviour._udonVM.InspectHeap();
                }
            }
            if(Controller != null)
            {
                if(Controller.AutoHold != VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes)
                {
                    OriginalMode = Controller.AutoHold;
                    Controller.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                }
            }
        }

        private void FixedUpdate()
        {
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

        private void OnDestroy()
        {
            if (UdonBehaviour != null)
            {
                Destroy(UdonBehaviour);
            }
            if (Controller != null)
            {
                Controller.AutoHold = OriginalMode;
            }
        }

        private void OnDisable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = true;
            }
        }

        // needed since the program is currently programmed to set the bools only to true.
        // This will edit and set the values to false hence how the Custom trigger works, by listening to these booleans.
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
                if (result)
                {
                    SetBackToFalse(Addresses.OnPickup);
                }
                return result;
            }
        }

        private bool Get_OnPickupUseUp
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(Addresses.OnPickupUseUp).Unbox<bool>();
                if (result)
                {
                    SetBackToFalse(Addresses.OnPickupUseUp);
                }
                return result;
            }
        }

        private bool Get_OnPickupUseDown
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(Addresses.OnPickupUseDown).Unbox<bool>();
                if (result)
                {
                    SetBackToFalse(Addresses.OnPickupUseDown);
                }
                return result;
            }
        }

        private bool Get_OnDrop
        {
            get
            {
                var result = IUdonHeap.GetHeapVariable(Addresses.OnDrop).Unbox<bool>();
                if (result)
                {
                    SetBackToFalse(Addresses.OnDrop);
                }
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
                if (Controller != null)
                {
                    Controller.EditMode = true;
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
                    Controller.EditMode = true;
                    Controller.InteractionText = value;
                }
            }
        }

        private struct Addresses
        {
            internal const uint OnDrop = 7;
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

        internal VRC.SDKBase.VRC_Pickup.AutoHoldMode OriginalMode;


        private PickupController _Controller;
        private PickupController Controller
        {
            get
            {
                if (_Controller == null)
                {
                    return _Controller = gameObject.GetOrAddComponent<PickupController>();
                }
                return _Controller;
            }
        }

        private UdonBehaviour UdonBehaviour { get; set; }
        private IUdonHeap IUdonHeap { get; set; }
    }
}