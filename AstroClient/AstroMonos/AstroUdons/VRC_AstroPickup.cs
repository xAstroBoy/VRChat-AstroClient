using AstroClient.Tools.UdonEditor;
using VRC.Udon.Common;

namespace AstroClient.AstroMonos.AstroUdons
{
    using System;
    using ClientAttributes;
    using Components.Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class VRC_AstroPickup : AstroMonoBehaviour
    {

        public VRC_AstroPickup(IntPtr ptr) : base(ptr)
        {
        }


        private void Start()
        {
            UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
            if (PickupController != null)
            {
                UseText = _UseText;
            }

        }

        internal override void UdonBehaviour_Event_OnPickup(UdonBehaviour item)
        {
            if(item.Equals(UdonBehaviour)) OnPickup.SafetyRaise();
        }


        internal override void UdonBehaviour_Event_OnPickupUseUp(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour)) OnPickupUseUp.SafetyRaise();
        }
        internal override void UdonBehaviour_Event_OnPickupUseDown(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour)) OnPickupUseDown.SafetyRaise();

        }

        internal override void UdonBehaviour_Event_OnDrop(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour)) OnDrop.SafetyRaise();

        }

        private void OnDestroy()
        {
            if (UdonBehaviour != null)
            {
                Destroy(UdonBehaviour);
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


        internal Action OnPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnPickupUseUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnPickupUseDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnDrop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


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
                        PickupController.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                    }
                }
            }
        }


        private UdonBehaviour UdonBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}