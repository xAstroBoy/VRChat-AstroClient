using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;
using AstroClient.xAstroBoy.Extensions;
using VRC.SDKBase;
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
    public class VRC_AstroPickup : MonoBehaviour
    {

        public VRC_AstroPickup(IntPtr ptr) : base(ptr)
        {
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

                        ClientEventActions.Udon_OnPickup += UdonBehaviour_Event_OnPickup;
                        ClientEventActions.Udon_OnPickupUseUp += UdonBehaviour_Event_OnPickupUseUp;
                        ClientEventActions.Udon_OnPickupUseDown += UdonBehaviour_Event_OnPickupUseDown;
                        ClientEventActions.Udon_OnDrop += UdonBehaviour_Event_OnDrop;

                    }
                    else
                    {

                        ClientEventActions.Udon_OnPickup -= UdonBehaviour_Event_OnPickup;
                        ClientEventActions.Udon_OnPickupUseUp -= UdonBehaviour_Event_OnPickupUseUp;
                        ClientEventActions.Udon_OnPickupUseDown -= UdonBehaviour_Event_OnPickupUseDown;
                        ClientEventActions.Udon_OnDrop -= UdonBehaviour_Event_OnDrop;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private void Start()
        {
            HasSubscribed = true;
            UdonBehaviour = gameObject.AddComponent<UdonBehaviour>();
            if (PickupController != null)
            {
                // Required To Show the interaction text
                PickupController.EditMode = true;
                if (PickupController.AutoHold != VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes)
                {
                    OriginalMode = PickupController.AutoHold;
                    PickupController.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                }
            }
            MiscUtils.DelayFunction(1f, () =>
            {
                if (_interactText != "Use")
                {
                    interactText = _interactText;
                }

                if (_InteractionText != "Use")
                {
                    InteractionText = _InteractionText;
                }

            });



        }

        private VRC_Pickup.AutoHoldMode OriginalMode {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; }

        private void UdonBehaviour_Event_OnPickup(UdonBehaviour item)
        {
            if(item.Equals(UdonBehaviour))
            {
                OnPickup.SafetyRaise();
                isHeld = true;
            }
        }


        private void UdonBehaviour_Event_OnPickupUseUp(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour))
            {
                OnPickupUseUp.SafetyRaise();
            }
        }
        private void UdonBehaviour_Event_OnPickupUseDown(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour))
            {
                OnPickupUseDown.SafetyRaise();
            }
        }

        private void UdonBehaviour_Event_OnDrop(UdonBehaviour item)
        {
            if (item.Equals(UdonBehaviour))
            {
                OnDrop.SafetyRaise();
                isHeld = false;
            }
        }

        private void OnDestroy()
        {
            HasSubscribed = false;
            if (UdonBehaviour != null)
            {
                Destroy(UdonBehaviour);
            }
             PickupController.AutoHold = OriginalMode;
        }

        private void OnDisable()
        {
            HasSubscribed = false;
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = false;
            }
        }

        private void OnEnable()
        {
            HasSubscribed = true;
            if (UdonBehaviour != null)
            {
                UdonBehaviour.enabled = true;
            }
        }

        internal void Drop()
        {
            try
            {
                if (PickupController != null)
                {
                    if (PickupController.currentlyHeldBy != null)
                    {
                        PickupController.currentlyHeldBy.Drop();
                    }
                }
            }
            catch{} // SHUT THE FUCK UP
        }


        private string _interactText = "Use";

        internal string interactText
        {
            [HideFromIl2Cpp]
            get => _interactText;
            [HideFromIl2Cpp]
            set
            {
                _interactText = value;
                if (UdonBehaviour != null)
                {
                    UdonBehaviour.interactText = value;
                }
            }
        }
        private string _InteractionText = "Use";

        internal string InteractionText
        {
            [HideFromIl2Cpp]
            get => _InteractionText;
            [HideFromIl2Cpp]
            set
            {
                _InteractionText = value;
                if (UdonBehaviour != null)
                {
                    UdonBehaviour.InteractionText = value;
                }
                if (PickupController != null)
                {
                    if (!PickupController.EditMode)
                    {
                        PickupController.EditMode = true;
                    }
                    PickupController.InteractionText = value;
                }
            }
        }

        internal Action OnPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnPickupUseUp { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnPickupUseDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnDrop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool isHeld { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

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
                    PickupController.EditMode = true;
                    if (PickupController.AutoHold != VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes)
                    {
                        OriginalMode = PickupController.AutoHold;
                        PickupController.AutoHold = VRC.SDKBase.VRC_Pickup.AutoHoldMode.Yes;
                    }
                }
            }
        }

        internal bool pickupable
        {
            [HideFromIl2Cpp]
            get => PickupController.pickupable;
            [HideFromIl2Cpp]
            set => PickupController.pickupable = value;
        }

        private UdonBehaviour UdonBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}