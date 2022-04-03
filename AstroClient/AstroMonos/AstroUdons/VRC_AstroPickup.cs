using AstroClient.Tools.UdonEditor;
using VRC.Udon.Common;

namespace AstroClient.AstroMonos.AstroUdons
{
    using System;
    using ClientAttributes;
    using Components.Tools;
    using Programs;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class VRC_AstroPickup : MonoBehaviour
    {

        public VRC_AstroPickup(IntPtr ptr) : base(ptr)
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
            RawItem = UdonBehaviour.ToRawUdonBehaviour();
            Initialize_PickupVars();
            if (PickupController != null)
            {
                if (PickupController.AutoHold != VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes)
                {
                    OriginalMode = PickupController.AutoHold;
                    PickupController.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                }
            }

            UseText = _UseText;
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
            if (RawItem != null)
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
            Destroy_PickupVars();
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
        //private void SetBackToFalse(uint one)
        //{
        //    if (IUdonHeap == null)
        //    {
        //        IUdonHeap = UdonBehaviour._udonVM.InspectHeap();
        //    }
        //    IUdonHeap.CopyHeapVariable(8u, one);
        //}


        internal void Initialize_PickupVars()
        {
            Private_Get_OnPickup = new AstroUdonVariable<bool>(RawItem, Addresses.OnPickup);
            Private_Get_OnPickupUseUp = new AstroUdonVariable<bool>(RawItem, Addresses.OnPickupUseUp);
            Private_Get_OnPickupUseDown = new AstroUdonVariable<bool>(RawItem, Addresses.OnPickupUseDown);
            Private_Get_OnDrop = new AstroUdonVariable<bool>(RawItem, Addresses.OnDrop);

        }

        internal void Destroy_PickupVars()
        {
            Private_Get_OnPickup = null;
            Private_Get_OnPickupUseUp = null;
            Private_Get_OnPickupUseDown = null;
            Private_Get_OnDrop = null;
        }

        private AstroUdonVariable<bool> Private_Get_OnPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_Get_OnPickupUseUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_Get_OnPickupUseDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_Get_OnDrop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private bool Get_OnPickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Get_OnPickup != null)
                {
                    var result = Private_Get_OnPickup.Value;
                    if(result)
                    {
                        Private_Get_OnPickup.Value = false;
                    }
                    return result;
                }
                return false;
            }
        }

        private bool Get_OnPickupUseUp
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Get_OnPickupUseUp != null)
                {
                    var result = Private_Get_OnPickupUseUp.Value;
                    if (result)
                    {
                        Private_Get_OnPickupUseUp.Value = false;
                    }
                    return result;
                }
                return false;
            }
        }


        private bool Get_OnPickupUseDown
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Get_OnPickupUseDown != null)
                {
                    var result = Private_Get_OnPickupUseDown.Value;
                    if (result)
                    {
                        Private_Get_OnPickupUseDown.Value = false;
                    }
                    return result;
                }
                return false;
            }
        }

        private bool Get_OnDrop
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Get_OnDrop != null)
                {
                    var result = Private_Get_OnDrop.Value;
                    if (result)
                    {
                        Private_Get_OnDrop.Value = false;
                    }
                    return result;
                }
                return false;
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
        private RawUdonBehaviour RawItem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}