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
                UdonBehaviour.interactText = interactText;
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
                UdonBehaviour.interactText = interactText;
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


        private string _interactText = "Use";

        internal string interactText
        {
            get => _interactText;
            set
            {
                _interactText = value;
                if (UdonBehaviour != null)
                {
                    UdonBehaviour.interactText = value;
                }
                if(VRCInteractable != null)
                {
                    VRCInteractable.interactText = value;
                }
            }
        }

        private SerializedUdonProgramAsset AssignedProgram { get; } = UdonPrograms.PickupProgram;
        private struct Addresses
        {
            internal const uint OnDrop  = 7u;
            internal const uint OnDrop_1 = 2u;
            internal const uint OnPickup = 4u;
            internal const uint OnPickup_1 = 3u;
            internal const uint OnPickupUseDown = 6u;
            internal const uint OnPickupUseDown_1 = 0u;
            internal const uint OnPickupUseUp = 5u;
            internal const uint OnPickupUseUp_1 = 1u;
            internal const uint AlwaysFalse = 8u;
        }
        internal Action OnPickup { get; set; }
        internal Action OnPickupUseUp { get; set; }
        internal Action OnPickupUseDown { get; set; }
        internal Action OnDrop { get; set; }

        private VRCInteractable _VRCInteractable;
        private VRCInteractable VRCInteractable
        {
            get
            {
                if(_VRCInteractable == null)
                {
                    return _VRCInteractable = gameObject.GetComponent<VRCInteractable>();
                }
                return _VRCInteractable;
            }
        }
        internal UdonBehaviour UdonBehaviour { get; private set; }
        private IUdonHeap IUdonHeap { get;  set; }
    }
}