using UnhollowerBaseLib.Attributes;

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

        private SerializedUdonProgramAsset AssignedProgram { [HideFromIl2Cpp] get; } = UdonPrograms.PickupProgram;

        private void Start()
        {
            if (AssignedProgram == null)
            {
                ModConsole.Error("Custom Pickup Events Can't Load as Program Asset is null!");
                Destroy(this);
            }

            UdonBehaviour = base.gameObject.AddComponent<UdonBehaviour>();
            if (UdonBehaviour != null)
            {
                UdonBehaviour.serializedProgramAsset = AssignedProgram;
                UdonBehaviour.InitializeUdonContent();
                UdonBehaviour.Start();
            }
            if (!UdonBehaviour.enabled)
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
            if (PickupController != null)
            {
                if (PickupController.AutoHold != VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes)
                {
                    OriginalMode = PickupController.AutoHold;
                    PickupController.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
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
            if (PickupController != null)
            {
                PickupController.AutoHold = OriginalMode;
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

        // needed since the program is currently programmed to [HideFromIl2Cpp] set the bools only to true.
        // This will edit and [HideFromIl2Cpp] set the values to false hence how the Custom trigger works, by listening to these booleans.
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
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
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
            [HideFromIl2Cpp]
            get => _UseText;
            [HideFromIl2Cpp]
            set
            {
                _UseText = value;
                if (PickupController != null)
                {
                    PickupController.EditMode = true;
                    PickupController.UseText = value;
                }
            }
        }

        private string _InteractionText;

        internal string InteractionText
        {
            [HideFromIl2Cpp]
            get => _InteractionText;
            [HideFromIl2Cpp]
            set
            {
                _InteractionText = value;
                if (PickupController != null)
                {
                    PickupController.EditMode = true;
                    PickupController.InteractionText = value;
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

        internal Action OnPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnPickupUseUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnPickupUseDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnDrop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal VRC.SDKBase.VRC_Pickup.AutoHoldMode OriginalMode;

        private PickupController _PickupController;

        internal PickupController PickupController
        {
            [HideFromIl2Cpp]
            get
            {
                if (_PickupController == null)
                {
                    return _PickupController = gameObject.GetOrAddComponent<PickupController>();
                }
                return _PickupController;
            }
        }

        internal bool HasPickupComponent
        {
            [HideFromIl2Cpp]
            get
            {
                return PickupController.HasPickupComponent();
            }
        }

        internal bool ForcePickupComponent
        {
            [HideFromIl2Cpp]
            get
            {
                return PickupController.ForceComponent;
            }
            [HideFromIl2Cpp]
            set
            {
                PickupController.ForceComponent = value;
                if (value)
                {
                    if (PickupController.AutoHold != VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes)
                    {
                        OriginalMode = PickupController.AutoHold;
                        PickupController.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                    }
                }
            }
        }


        private UdonBehaviour UdonBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private IUdonHeap IUdonHeap { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}