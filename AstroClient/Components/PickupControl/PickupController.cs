namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Linq;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.SDKBase;

    [RegisterComponent]
    public class PickupController : GameEventsBehaviour
    {
        public PickupController(IntPtr ptr) : base(ptr)
        {
        }

        // Use this for initialization
        internal void Start()
        {
            SDKBase_Pickup = gameObject.GetComponent<VRC.SDKBase.VRC_Pickup>();
            SDK2_Pickup = gameObject.GetComponent<VRCSDK2.VRC_Pickup>();
            SDK3_Pickup = gameObject.GetComponent<VRC.SDK3.Components.VRCPickup>();
            RigidBodyController = gameObject.GetOrAddComponent<RigidBodyController>();
            SyncProperties(true);
            ModConsole.DebugLog("Attacked Successfully PickupController to object " + gameObject.name);
            isUsingUI = false;
            InvokeRepeating(nameof(PickupUpdate), 0.1f, 0.3f);

        }

        private bool isUsingUI { get; set; }
        internal override void OnQuickMenuClose() => isUsingUI = false;

        internal override void OnQuickMenuOpen() => isUsingUI = true;

        internal override void OnBigMenuOpen() => isUsingUI = true;

        internal override void OnBigMenuClose() => isUsingUI = false;


        private void PickupUpdate()
        {
            if (gameObject != null)
            {
                if (gameObject.active && this.isActiveAndEnabled)
                {
                    Run_onPickupUpdate();
                    if (!EditMode)
                    {
                        SyncProperties(true);
                    }
                }
            }
        }


        private void Update()
        {
            PickupProtection();
            AntiPickupTheft();
        }


        private void AntiPickupTheft()
        {
            if (isUsingUI) return;
            if (!AntiTheft) return;
            if (Utils.LocalPlayer == null) return;
            bool TeleporToAntiTheft = false;
            if (CurrentHolder == null && !IsHeld || !CurrentHolder.isLocal)
            {
                TeleporToAntiTheft = true;
            }
            if(TeleporToAntiTheft)
            {
                if (InputUtils.IsImputUseRightCalled)
                {
                    if (Utils.LocalPlayer.GetPickupInHand(VRC_Pickup.PickupHand.Right) != null)
                    {
                        return;
                    }
                    else
                    {
                        gameObject.TeleportToMe(HumanBodyBones.RightHand, false, true);
                    }
                }
                else if (InputUtils.IsImputUseLeftCalled)
                {
                    if (Utils.LocalPlayer.GetPickupInHand(VRC_Pickup.PickupHand.Left) != null)
                    { 
                        return;
                    }
                    else
                    {
                        gameObject.TeleportToMe(HumanBodyBones.LeftHand, false, true);
                    }
                }
            }
        }

        #region anti-grab method
        private void PickupProtection()
        {
            // Add a Shield for the Local User.
            if (!IsHeld) return;
            if (CurrentHolder == null) return;
            if (CurrentHolder.isLocal) return;
            if (!AllowOnlySelfToGrab)
            {

                if (PickupBlocker.blockeduserids != null && PickupBlocker.blockeduserids.Count() != 0)
                {
                    var id = CurrentHolder.GetPlayer().GetAPIUser().GetUserID();
                    if (PickupBlocker.blockeduserids.Contains(id))
                    {
                        ModConsole.DebugLog($"Prevented {this.gameObject} from being used from Blacklisted user {CurrentHolderDisplayName}");
                        OnlineEditor.TakeObjectOwnership(gameObject);
                    }
                }

            }
            else
            {
                if (!CurrentHolder.isLocal)
                {
                    if (!OnlineEditor.IsLocalPlayerOwner(gameObject))
                    {
                        OnlineEditor.TakeObjectOwnership(gameObject);
                    }
                }
            }

        }

        internal bool AntiTheft = false;

        private bool _PreventOthersFromGrabbing = false;

        internal bool AllowOnlySelfToGrab
        {
            get
            {
                return _PreventOthersFromGrabbing;
            }
            set
            {
                _PreventOthersFromGrabbing = value;
                Run_OnOnPickupPropertyChanged();
            }
        }

        #endregion anti-grab method


        #region Backup and Restore Methods

        private void SyncProperties(bool isFromUpdate)
        {
            if (isFromUpdate)
            {
                if (_EditMode)
                {
                    _EditMode = false; // Disable this so it goes on Sync Mode.
                }
            }
            if (SDKBase_Pickup != null)
            {
                Original_currentlyHeldBy = SDKBase_Pickup.currentlyHeldBy;
                Original_UseDownEventName = SDKBase_Pickup.UseDownEventName;
                Original_currentLocalPlayer = SDKBase_Pickup.currentLocalPlayer;
                Original_ThrowVelocityBoostScale = SDKBase_Pickup.ThrowVelocityBoostScale;
                Original_ThrowVelocityBoostMinSpeed = SDKBase_Pickup.ThrowVelocityBoostMinSpeed;
                Original_DropEventName = SDKBase_Pickup.DropEventName;
                Original_PickupEventName = SDKBase_Pickup.PickupEventName;
                Original_pickupable = SDKBase_Pickup.pickupable;
                Original_UseUpEventName = SDKBase_Pickup.UseUpEventName;
                Original_useEventBroadcastType = SDKBase_Pickup.useEventBroadcastType;
                Original_orientation = SDKBase_Pickup.orientation;
                Original_InteractionText = SDKBase_Pickup.InteractionText;
                Original_AutoHold = SDKBase_Pickup.AutoHold;
                Original_proximity = SDKBase_Pickup.proximity;
                Original_allowManipulationWhenEquipped = SDKBase_Pickup.allowManipulationWhenEquipped;
                Original_ExactGrip = SDKBase_Pickup.ExactGrip;
                Original_ExactGun = SDKBase_Pickup.ExactGun;
                Original_DisallowTheft = SDKBase_Pickup.DisallowTheft;
                Original_MomentumTransferMethod = SDKBase_Pickup.MomentumTransferMethod;
                Original_UseText = SDKBase_Pickup.UseText;
                Original_pickupDropEventBroadcastType = SDKBase_Pickup.pickupDropEventBroadcastType;

                // Sync Properties as well

                currentlyHeldBy = SDKBase_Pickup.currentlyHeldBy;
                UseDownEventName = SDKBase_Pickup.UseDownEventName;
                currentLocalPlayer = SDKBase_Pickup.currentLocalPlayer;
                ThrowVelocityBoostScale = SDKBase_Pickup.ThrowVelocityBoostScale;
                ThrowVelocityBoostMinSpeed = SDKBase_Pickup.ThrowVelocityBoostMinSpeed;
                DropEventName = SDKBase_Pickup.DropEventName;
                PickupEventName = SDKBase_Pickup.PickupEventName;
                pickupable = SDKBase_Pickup.pickupable;
                UseUpEventName = SDKBase_Pickup.UseUpEventName;
                useEventBroadcastType = SDKBase_Pickup.useEventBroadcastType;
                orientation = SDKBase_Pickup.orientation;
                InteractionText = SDKBase_Pickup.InteractionText;
                AutoHold = SDKBase_Pickup.AutoHold;
                proximity = SDKBase_Pickup.proximity;
                allowManipulationWhenEquipped = SDKBase_Pickup.allowManipulationWhenEquipped;
                ExactGrip = SDKBase_Pickup.ExactGrip;
                ExactGun = SDKBase_Pickup.ExactGun;
                DisallowTheft = SDKBase_Pickup.DisallowTheft;
                MomentumTransferMethod = SDKBase_Pickup.MomentumTransferMethod;
                UseText = SDKBase_Pickup.UseText;
                pickupDropEventBroadcastType = SDKBase_Pickup.pickupDropEventBroadcastType;
            }
            else if (SDK2_Pickup != null)
            {
                Original_currentlyHeldBy = SDK2_Pickup.currentlyHeldBy;
                Original_UseDownEventName = SDK2_Pickup.UseDownEventName;
                Original_currentLocalPlayer = SDK2_Pickup.currentLocalPlayer;
                Original_ThrowVelocityBoostScale = SDK2_Pickup.ThrowVelocityBoostScale;
                Original_ThrowVelocityBoostMinSpeed = SDK2_Pickup.ThrowVelocityBoostMinSpeed;
                Original_DropEventName = SDK2_Pickup.DropEventName;
                Original_PickupEventName = SDK2_Pickup.PickupEventName;
                Original_pickupable = SDK2_Pickup.pickupable;
                Original_UseUpEventName = SDK2_Pickup.UseUpEventName;
                Original_useEventBroadcastType = SDK2_Pickup.useEventBroadcastType;
                Original_orientation = SDK2_Pickup.orientation;
                Original_InteractionText = SDK2_Pickup.InteractionText;
                Original_AutoHold = SDK2_Pickup.AutoHold;
                Original_proximity = SDK2_Pickup.proximity;
                Original_allowManipulationWhenEquipped = SDK2_Pickup.allowManipulationWhenEquipped;
                Original_ExactGrip = SDK2_Pickup.ExactGrip;
                Original_ExactGun = SDK2_Pickup.ExactGun;
                Original_DisallowTheft = SDK2_Pickup.DisallowTheft;
                Original_MomentumTransferMethod = SDK2_Pickup.MomentumTransferMethod;
                Original_UseText = SDK2_Pickup.UseText;
                Original_pickupDropEventBroadcastType = SDK2_Pickup.pickupDropEventBroadcastType;

                // Sync Properties as well

                currentlyHeldBy = SDK2_Pickup.currentlyHeldBy;
                UseDownEventName = SDK2_Pickup.UseDownEventName;
                currentLocalPlayer = SDK2_Pickup.currentLocalPlayer;
                ThrowVelocityBoostScale = SDK2_Pickup.ThrowVelocityBoostScale;
                ThrowVelocityBoostMinSpeed = SDK2_Pickup.ThrowVelocityBoostMinSpeed;
                DropEventName = SDK2_Pickup.DropEventName;
                PickupEventName = SDK2_Pickup.PickupEventName;
                pickupable = SDK2_Pickup.pickupable;
                UseUpEventName = SDK2_Pickup.UseUpEventName;
                useEventBroadcastType = SDK2_Pickup.useEventBroadcastType;
                orientation = SDK2_Pickup.orientation;
                InteractionText = SDK2_Pickup.InteractionText;
                AutoHold = SDK2_Pickup.AutoHold;
                proximity = SDK2_Pickup.proximity;
                allowManipulationWhenEquipped = SDK2_Pickup.allowManipulationWhenEquipped;
                ExactGrip = SDK2_Pickup.ExactGrip;
                ExactGun = SDK2_Pickup.ExactGun;
                DisallowTheft = SDK2_Pickup.DisallowTheft;
                MomentumTransferMethod = SDK2_Pickup.MomentumTransferMethod;
                UseText = SDK2_Pickup.UseText;
                pickupDropEventBroadcastType = SDK2_Pickup.pickupDropEventBroadcastType;
            }
            else if (SDK3_Pickup != null)
            {
                Original_currentlyHeldBy = SDK3_Pickup.currentlyHeldBy;
                Original_UseDownEventName = SDK3_Pickup.UseDownEventName;
                Original_currentLocalPlayer = SDK3_Pickup.currentLocalPlayer;
                Original_ThrowVelocityBoostScale = SDK3_Pickup.ThrowVelocityBoostScale;
                Original_ThrowVelocityBoostMinSpeed = SDK3_Pickup.ThrowVelocityBoostMinSpeed;
                Original_DropEventName = SDK3_Pickup.DropEventName;
                Original_PickupEventName = SDK3_Pickup.PickupEventName;
                Original_pickupable = SDK3_Pickup.pickupable;
                Original_UseUpEventName = SDK3_Pickup.UseUpEventName;
                Original_useEventBroadcastType = SDK3_Pickup.useEventBroadcastType;
                Original_orientation = SDK3_Pickup.orientation;
                Original_InteractionText = SDK3_Pickup.InteractionText;
                Original_AutoHold = SDK3_Pickup.AutoHold;
                Original_proximity = SDK3_Pickup.proximity;
                Original_allowManipulationWhenEquipped = SDK3_Pickup.allowManipulationWhenEquipped;
                Original_ExactGrip = SDK3_Pickup.ExactGrip;
                Original_ExactGun = SDK3_Pickup.ExactGun;
                Original_DisallowTheft = SDK3_Pickup.DisallowTheft;
                Original_MomentumTransferMethod = SDK3_Pickup.MomentumTransferMethod;
                Original_UseText = SDK3_Pickup.UseText;
                Original_pickupDropEventBroadcastType = SDK3_Pickup.pickupDropEventBroadcastType;

                // Sync Properties as well

                currentlyHeldBy = SDK3_Pickup.currentlyHeldBy;
                UseDownEventName = SDK3_Pickup.UseDownEventName;
                currentLocalPlayer = SDK3_Pickup.currentLocalPlayer;
                ThrowVelocityBoostScale = SDK3_Pickup.ThrowVelocityBoostScale;
                ThrowVelocityBoostMinSpeed = SDK3_Pickup.ThrowVelocityBoostMinSpeed;
                DropEventName = SDK3_Pickup.DropEventName;
                PickupEventName = SDK3_Pickup.PickupEventName;
                pickupable = SDK3_Pickup.pickupable;
                UseUpEventName = SDK3_Pickup.UseUpEventName;
                useEventBroadcastType = SDK3_Pickup.useEventBroadcastType;
                orientation = SDK3_Pickup.orientation;
                InteractionText = SDK3_Pickup.InteractionText;
                AutoHold = SDK3_Pickup.AutoHold;
                proximity = SDK3_Pickup.proximity;
                allowManipulationWhenEquipped = SDK3_Pickup.allowManipulationWhenEquipped;
                ExactGrip = SDK3_Pickup.ExactGrip;
                ExactGun = SDK3_Pickup.ExactGun;
                DisallowTheft = SDK3_Pickup.DisallowTheft;
                MomentumTransferMethod = SDK3_Pickup.MomentumTransferMethod;
                UseText = SDK3_Pickup.UseText;
                pickupDropEventBroadcastType = SDK3_Pickup.pickupDropEventBroadcastType;
            }
        }

        internal void RestoreProperties()
        {
            if (_EditMode)
            {
                currentlyHeldBy = Original_currentlyHeldBy;
                UseDownEventName = Original_UseDownEventName;
                currentLocalPlayer = Original_currentLocalPlayer;
                ThrowVelocityBoostScale = Original_ThrowVelocityBoostScale;
                ThrowVelocityBoostMinSpeed = Original_ThrowVelocityBoostMinSpeed;
                DropEventName = Original_DropEventName;
                PickupEventName = Original_PickupEventName;
                pickupable = Original_pickupable;
                UseUpEventName = Original_UseUpEventName;
                useEventBroadcastType = Original_useEventBroadcastType;
                orientation = Original_orientation;
                InteractionText = Original_InteractionText;
                AutoHold = Original_AutoHold;
                proximity = Original_proximity;
                allowManipulationWhenEquipped = Original_allowManipulationWhenEquipped;
                ExactGrip = Original_ExactGrip;
                ExactGun = Original_ExactGun;
                DisallowTheft = Original_DisallowTheft;
                MomentumTransferMethod = Original_MomentumTransferMethod;
                UseText = Original_UseText;
                pickupDropEventBroadcastType = Original_pickupDropEventBroadcastType;
                _EditMode = false;
            }
        }

        #endregion Backup and Restore Methods

        #region Internal Reflection (Do Not edit these values)

        private Component _currentlyHeldBy;
        private string _UseDownEventName;
        private VRCPlayerApi _currentLocalPlayer;
        private float _ThrowVelocityBoostScale;
        private float _ThrowVelocityBoostMinSpeed;
        private string _DropEventName;
        private string _PickupEventName;
        private bool _pickupable;
        private string _UseUpEventName;
        private VRC_EventHandler.VrcBroadcastType _useEventBroadcastType;
        private VRC_Pickup.PickupOrientation _orientation;
        private string _InteractionText;
        private VRC_Pickup.AutoHoldMode _AutoHold;
        private float _proximity;
        private bool _allowManipulationWhenEquipped;
        private Transform _ExactGrip;
        private Transform _ExactGun;
        private bool _DisallowTheft;
        private ForceMode _MomentumTransferMethod;
        private string _UseText = "Use";
        private VRC_EventHandler.VrcBroadcastType _pickupDropEventBroadcastType;

        #endregion Internal Reflection (Do Not edit these values)

        #region Original Backup Values

        private Component Original_currentlyHeldBy;
        private string Original_UseDownEventName;
        private VRCPlayerApi Original_currentLocalPlayer;
        private float Original_ThrowVelocityBoostScale;
        private float Original_ThrowVelocityBoostMinSpeed;
        private string Original_DropEventName;
        private string Original_PickupEventName;
        private bool Original_pickupable;
        private string Original_UseUpEventName;
        private VRC_EventHandler.VrcBroadcastType Original_useEventBroadcastType;
        private VRC_Pickup.PickupOrientation Original_orientation;
        private string Original_InteractionText;
        private VRC_Pickup.AutoHoldMode Original_AutoHold;
        private float Original_proximity;
        private bool Original_allowManipulationWhenEquipped;
        private Transform Original_ExactGrip;
        private Transform Original_ExactGun;
        private bool Original_DisallowTheft;
        private ForceMode Original_MomentumTransferMethod;
        private string Original_UseText;
        private VRC_EventHandler.VrcBroadcastType Original_pickupDropEventBroadcastType;

        #endregion Original Backup Values

        #region Reflected Values

        internal Component currentlyHeldBy
        {
            get
            {
                return _currentlyHeldBy;
            }
            set
            {
                _currentlyHeldBy = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.currentlyHeldBy = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.currentlyHeldBy = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.currentlyHeldBy = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string UseDownEventName
        {
            get
            {
                return _UseDownEventName;
            }
            set
            {
                _UseDownEventName = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.UseDownEventName = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.UseDownEventName = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.UseDownEventName = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRCPlayerApi currentLocalPlayer
        {
            get
            {
                return _currentLocalPlayer;
            }
            set
            {
                _currentLocalPlayer = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.currentLocalPlayer = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.currentLocalPlayer = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.currentLocalPlayer = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal float ThrowVelocityBoostScale
        {
            get
            {
                return _ThrowVelocityBoostScale;
            }
            set
            {
                _ThrowVelocityBoostScale = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.ThrowVelocityBoostScale = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.ThrowVelocityBoostScale = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.ThrowVelocityBoostScale = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal float ThrowVelocityBoostMinSpeed
        {
            get
            {
                return _ThrowVelocityBoostMinSpeed;
            }
            set
            {
                _ThrowVelocityBoostMinSpeed = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.ThrowVelocityBoostMinSpeed = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.ThrowVelocityBoostMinSpeed = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.ThrowVelocityBoostMinSpeed = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string DropEventName
        {
            get
            {
                return _DropEventName;
            }
            set
            {
                _DropEventName = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.DropEventName = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.DropEventName = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.DropEventName = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string PickupEventName
        {
            get
            {
                return _PickupEventName;
            }
            set
            {
                _PickupEventName = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.PickupEventName = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.PickupEventName = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.PickupEventName = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal bool pickupable
        {
            get
            {
                return _pickupable;
            }
            set
            {
                _pickupable = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.pickupable = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.pickupable = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.pickupable = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string UseUpEventName
        {
            get
            {
                return _UseUpEventName;
            }
            set
            {
                _UseUpEventName = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.UseUpEventName = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.UseUpEventName = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.UseUpEventName = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRC_EventHandler.VrcBroadcastType useEventBroadcastType
        {
            get
            {
                return _useEventBroadcastType;
            }
            set
            {
                _useEventBroadcastType = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.useEventBroadcastType = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.useEventBroadcastType = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.useEventBroadcastType = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRC_Pickup.PickupOrientation orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.orientation = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.orientation = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.orientation = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string InteractionText
        {
            get
            {
                return _InteractionText;
            }
            set
            {
                _InteractionText = value;
                if (SDKBase_Pickup != null)
                {
                    SDKBase_Pickup.InteractionText = value;
                }
                if (SDK2_Pickup != null)
                {
                    SDK2_Pickup.InteractionText = value;
                }
                if (SDK3_Pickup != null)
                {
                    SDK3_Pickup.InteractionText = value;
                }
                if (EditMode)
                {
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRC_Pickup.AutoHoldMode AutoHold
        {
            get
            {
                return _AutoHold;
            }
            set
            {
                _AutoHold = value;
                if (SDKBase_Pickup != null)
                {
                    SDKBase_Pickup.AutoHold = value;
                }
                if (SDK2_Pickup != null)
                {
                    SDK2_Pickup.AutoHold = value;
                }
                if (SDK3_Pickup != null)
                {
                    SDK3_Pickup.AutoHold = value;
                }
                if (EditMode)
                {
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal float proximity
        {
            get
            {
                return _proximity;
            }
            set
            {
                _proximity = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.proximity = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.proximity = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.proximity = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal bool allowManipulationWhenEquipped
        {
            get
            {
                return _allowManipulationWhenEquipped;
            }
            set
            {
                _allowManipulationWhenEquipped = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.allowManipulationWhenEquipped = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.allowManipulationWhenEquipped = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.allowManipulationWhenEquipped = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal Transform ExactGrip
        {
            get
            {
                return _ExactGrip;
            }
            set
            {
                _ExactGrip = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.ExactGrip = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.ExactGrip = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.ExactGrip = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal Transform ExactGun
        {
            get
            {
                return _ExactGun;
            }
            set
            {
                _ExactGun = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.ExactGun = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.ExactGun = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.ExactGun = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal bool DisallowTheft
        {
            get
            {
                return _DisallowTheft;
            }
            set
            {
                _DisallowTheft = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.DisallowTheft = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.DisallowTheft = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.DisallowTheft = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal ForceMode MomentumTransferMethod
        {
            get
            {
                return _MomentumTransferMethod;
            }
            set
            {
                _MomentumTransferMethod = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.MomentumTransferMethod = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.MomentumTransferMethod = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.MomentumTransferMethod = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string UseText
        {
            get
            {
                return _UseText;
            }
            set
            {
                _UseText = value;
                if (SDKBase_Pickup != null)
                {
                    SDKBase_Pickup.UseText = value;
                }
                if (SDK2_Pickup != null)
                {
                    SDK2_Pickup.UseText = value;
                }
                if (SDK3_Pickup != null)
                {
                    SDK3_Pickup.UseText = value;
                }
                if (EditMode)
                {
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRC_EventHandler.VrcBroadcastType pickupDropEventBroadcastType
        {
            get
            {
                return _pickupDropEventBroadcastType;
            }
            set
            {
                _pickupDropEventBroadcastType = value;
                if (EditMode)
                {
                    if (SDKBase_Pickup != null)
                    {
                        SDKBase_Pickup.pickupDropEventBroadcastType = value;
                    }
                    if (SDK2_Pickup != null)
                    {
                        SDK2_Pickup.pickupDropEventBroadcastType = value;
                    }
                    if (SDK3_Pickup != null)
                    {
                        SDK3_Pickup.pickupDropEventBroadcastType = value;
                    }
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        #endregion Reflected Values

        #region Pickup Getters Only

        
        internal bool IsHeld
        {
            
            get
            {
                if (SDKBase_Pickup != null)
                {
                    return SDKBase_Pickup.IsHeld;
                }
                else if (SDK2_Pickup != null)
                {
                    return SDK2_Pickup.IsHeld;
                }
                else if (SDK3_Pickup != null)
                {
                    return SDK3_Pickup.IsHeld;
                }
                else
                {
                    return false;
                }
            }
        }

        internal VRC_Pickup.PickupHand CurrentHand
        {
            get
            {
                if (SDKBase_Pickup != null)
                {
                    return SDKBase_Pickup.currentHand;
                }
                else if (SDK2_Pickup != null)
                {
                    return SDK2_Pickup.currentHand;
                }
                else if (SDK3_Pickup != null)
                {
                    return SDK3_Pickup.currentHand;
                }
                return VRC_Pickup.PickupHand.None;
            }
        }

        internal VRCPlayerApi currentPlayer
        {
            
            get
            {
                try
                {
                    if (SDKBase_Pickup != null)
                    {
                        var user = SDKBase_Pickup.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                    else if (SDK2_Pickup != null)
                    {
                        var user = SDK2_Pickup.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                    else if (SDK3_Pickup != null)
                    {
                        var user = SDK3_Pickup.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                }
                catch
                {
                }
                return null;
            }
        }

        #endregion Pickup Getters Only

        #region extras

        internal string CurrentOwner
        {
            
            get
            {
                var owner = Networking.GetOwner(gameObject);
                if (owner != null)
                {
                    return owner.displayName;
                }
                return "Unassigned owner";
            }
        }

        internal string CurrentHolderDisplayName
        {
            
            get
            {
                try
                {
                    return CurrentHolder?.displayName;
                }
                catch
                {
                }
                return "None";
            }
        }


        internal VRCPlayerApi CurrentHolder
        {
            
            get
            {
                try
                {
                    if (SDKBase_Pickup != null)
                    {
                        var user = SDKBase_Pickup.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                    else if (SDK2_Pickup != null)
                    {
                        var user = SDK2_Pickup.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                    else if (SDK3_Pickup != null)
                    {
                        var user = SDK3_Pickup.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                }
                catch
                {
                }
                return null;
            }
        }

        internal bool HasPickupComponent()
        {
            if (SDKBase_Pickup != null || SDK2_Pickup != null || SDK3_Pickup != null)
            {
                return true;
            }
            return false;
        }

        internal void SetRigidbody()
        {
            if (HasSetRigidbodyController)
            {
                return;
            }
            if (!HasSetRigidbodyController)
            {
                if (RigidBodyController != null)
                {
                    // IF INTERNAL SYNC IS NULL, Force The rigidbody to take over , Then Set it as Kinematic in case no collider is present.
                    if (RigidBodyController.SyncPhysics == null)
                    {
                        if (!RigidBodyController.Forced_Rigidbody)
                        {
                            RigidBodyController.Forced_Rigidbody = true;
                        }
                        if (!RigidBodyController.EditMode)
                        {
                            RigidBodyController.EditMode = true;
                        }
                        // Let's use smart kinematic (Checks for Colliders present that can block and prevent the fall of the object).

                        if (RigidBodyController != null)
                        {
                            var will_it_fall_throught = RigidBodyController.RigidBody_Will_It_fall_throught();
                            if (!will_it_fall_throught)
                            {
                                RigidBodyController.RigidBody_Set_isKinematic(false);
                            }
                            else
                            {
                                RigidBodyController.RigidBody_Set_isKinematic(true);
                            }
                        }
                    }
                }
                HasSetRigidbodyController = true;
            }
        }

        #endregion extras

        #region actions

        private void Run_OnOnPickupPropertyChanged()
        {
            OnPickupPropertyChanged?.Invoke();
        }

        internal void SetOnPickupPropertyChanged(Action action)
        {
            OnPickupPropertyChanged += action;
        }

        private void Run_onPickupUpdate()
        {
            OnPickup_OnUpdate?.Invoke();
        }

        internal void SetOnPickup_OnUpdate(Action action)
        {
            OnPickup_OnUpdate += action;
        }

        internal void RemoveActionEvents()
        {
            OnPickupPropertyChanged = null;
            OnPickup_OnUpdate = null;
        }

        private event Action? OnPickupPropertyChanged;

        private event Action? OnPickup_OnUpdate;

        #endregion actions

        #region Force Pickup Functions

        private bool _Force_Pickup_Component = false;

        internal bool Force_Pickup_Component
        {
            get
            {
                return _Force_Pickup_Component;
            }
            set
            {
                _Force_Pickup_Component = value;
                if (value)
                {
                    ForcePickupComponent();
                }
                Run_OnOnPickupPropertyChanged();
            }
        }

        private void ForcePickupComponent()
        {
            SetRigidbody();

            if (!hasRequiredComponentBeenAdded)
            {
                SDKBase_Pickup = gameObject.GetComponent<VRC_Pickup>();
                SDK2_Pickup = gameObject.GetComponent<VRCSDK2.VRC_Pickup>();
                SDK3_Pickup = gameObject.GetComponent<VRC.SDK3.Components.VRCPickup>();
                if (!HasTriedWithSDKBase_Pickup)
                {
                    if (SDKBase_Pickup == null)
                    {
                        ModConsole.DebugLog("PickupController : Attempting to add  VRC.SDKBase.VRC_Pickup to object " + gameObject.name);
                        SDKBase_Pickup = gameObject.AddComponent<VRC_Pickup>();
                        if (SDKBase_Pickup == null)
                        {
                            ModConsole.DebugLog("PickupController : Failed to add  VRC.SDKBase.VRC_Pickup to object " + gameObject.name);
                            HasTriedWithSDKBase_Pickup = true;
                        }
                        else
                        {
                            ModConsole.DebugLog("PickupController : Added VRC.SDKBase.VRC_Pickup to object " + gameObject.name);
                            if (SDKBase_Pickup.ExactGrip == null)
                            {
                                SDKBase_Pickup.ExactGrip = gameObject.transform;
                                ModConsole.DebugLog("PickupController : Linked VRC.SDKBase.VRC_Pickup ExactGrip to object transform " + gameObject.name);
                            }
                            if (SDKBase_Pickup.ExactGun == null)
                            {
                                SDKBase_Pickup.ExactGun = gameObject.transform;
                                ModConsole.DebugLog("PickupController : Linked VRC.SDKBase.VRC_Pickup ExactGun to object transform " + gameObject.name);
                            }

                            hasRequiredComponentBeenAdded = true;
                            HasTriedWithSDKBase_Pickup = true;
                            return;
                        }
                    }
                }
                if (!HasTriedWithSDK2_Pickup)
                {
                    if (SDK2_Pickup == null)
                    {
                        ModConsole.DebugLog("PickupController : Attempting to add  VRCSDK2.VRC_Pickup to object " + gameObject.name);
                        SDK2_Pickup = gameObject.AddComponent<VRCSDK2.VRC_Pickup>();
                        if (SDK2_Pickup == null)
                        {
                            ModConsole.DebugLog("PickupController : Failed to add  VRCSDK2.VRC_Pickup to object " + gameObject.name);
                            HasTriedWithSDK2_Pickup = true;
                        }
                        else
                        {
                            ModConsole.DebugLog("PickupController : Added VRCSDK2.VRC_Pickup to object " + gameObject.name);
                            if (SDK2_Pickup.ExactGrip == null)
                            {
                                SDK2_Pickup.ExactGrip = gameObject.transform;
                                ModConsole.DebugLog("PickupController : Linked VRCSDK2.VRC_Pickup ExactGrip to object transform " + gameObject.name);
                            }
                            if (SDK2_Pickup.ExactGun == null)
                            {
                                SDK2_Pickup.ExactGun = gameObject.transform;
                                ModConsole.DebugLog("PickupController : Linked VRCSDK2.VRC_Pickup ExactGun to object transform " + gameObject.name);
                            }
                            hasRequiredComponentBeenAdded = true;
                            HasTriedWithSDK2_Pickup = true;
                            return;
                        }
                    }
                }
                if (!HasTriedWithSDK3_Pickup)
                {
                    if (SDK3_Pickup == null)
                    {
                        ModConsole.DebugLog("PickupController : Attempting to add  VRC.SDK3.Components.VRCPickup to object " + gameObject.name);
                        SDK3_Pickup = gameObject.AddComponent<VRC.SDK3.Components.VRCPickup>();
                        if (SDK3_Pickup == null)
                        {
                            ModConsole.DebugLog("PickupController : Failed to add  VRC.SDK3.Components.VRCPickup to object " + gameObject.name);
                            HasTriedWithSDK3_Pickup = true;
                        }
                        else
                        {
                            ModConsole.DebugLog("PickupController : Added VRC.SDK3.Components.VRCPickup to object " + gameObject.name);
                            if (SDK3_Pickup.ExactGrip == null)
                            {
                                SDK3_Pickup.ExactGrip = gameObject.transform;
                                ModConsole.DebugLog("PickupController : Linked VRC.SDK3.Components.VRCPickup ExactGrip to object transform " + gameObject.name);
                            }
                            if (SDK3_Pickup.ExactGun == null)
                            {
                                SDK3_Pickup.ExactGun = gameObject.transform;
                                ModConsole.DebugLog("PickupController : Linked VRC.SDK3.Components.VRCPickup ExactGun to object transform " + gameObject.name);
                            }

                            hasRequiredComponentBeenAdded = true;
                            HasTriedWithSDK3_Pickup = true;
                            return;
                        }
                    }
                }
                if (!hasRequiredComponentBeenAdded && HasTriedWithSDKBase_Pickup && HasTriedWithSDK2_Pickup && HasTriedWithSDK3_Pickup)
                {
                    ModConsole.DebugWarning("Failed to add A Pickup Component to the object : " + gameObject.name);
                    ForceComponent = false;
                    HasTriedWithSDKBase_Pickup = false;
                    HasTriedWithSDK2_Pickup = false;
                    HasTriedWithSDK3_Pickup = false;
                    hasRequiredComponentBeenAdded = false;
                    return;
                }
            }
        }

        private bool HasTriedWithSDKBase_Pickup { get; set; } = false;
        private bool HasTriedWithSDK2_Pickup { get; set; } = false;
        private bool HasTriedWithSDK3_Pickup { get; set; } = false;
        private bool HasSetRigidbodyController { get; set; } = false;
        private bool hasRequiredComponentBeenAdded { get; set; } = false;

        private bool _ForceComponent = false;

        internal bool ForceComponent
        {
            get
            {
                return _ForceComponent;
            }
            set
            {
                if (value)
                {
                    _ForceComponent = value;
                    if (!hasRequiredComponentBeenAdded)
                    {
                        ForcePickupComponent();
                    }
                    Run_OnOnPickupPropertyChanged();
                }
                else
                {
                    return;
                }
            }
        }

        #endregion Force Pickup Functions

        #region essentials
        

        private VRC_Pickup _SDKBase_Pickup;

        internal VRC_Pickup SDKBase_Pickup
        {
            get
            {
                if (_SDKBase_Pickup == null)
                {
                    return _SDKBase_Pickup = gameObject.GetComponent<VRC_Pickup>();
                }
                return _SDKBase_Pickup;
            }
            private set
            {
                _SDKBase_Pickup = value;
            }
        }

        private VRCSDK2.VRC_Pickup _SDK2_Pickup;

        internal VRCSDK2.VRC_Pickup SDK2_Pickup
        {
            get
            {
                if (_SDK2_Pickup == null)
                {
                    return _SDK2_Pickup = gameObject.GetComponent<VRCSDK2.VRC_Pickup>();
                }
                return _SDK2_Pickup;
            }
            private set
            {
                _SDK2_Pickup = value;
            }
        }

        private VRC.SDK3.Components.VRCPickup _SDK3_Pickup;

        internal VRC.SDK3.Components.VRCPickup SDK3_Pickup
        {
            get
            {
                if (_SDK3_Pickup == null)
                {
                    return _SDK3_Pickup = gameObject.GetComponent<VRC.SDK3.Components.VRCPickup>();
                }
                return _SDK3_Pickup;
            }
            private set
            {
                _SDK3_Pickup = value;
            }
        }

        internal RigidBodyController RigidBodyController { get; private set; }

        private bool _EditMode = false;

        internal bool EditMode
        {
            get
            {
                return _EditMode;
            }
            set
            {
                if (value)
                {
                    SyncProperties(false);
                }
                else
                {
                    RestoreProperties();
                }
                _EditMode = value;
                Run_OnOnPickupPropertyChanged();
            }
        }


        #endregion essentials
    }
}