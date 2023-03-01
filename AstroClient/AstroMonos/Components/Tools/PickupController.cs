using AstroClient.ClientActions;
using AstroClient.PlayerList.Entries;
using AstroClient.xAstroBoy.Extensions;
using UnityEngine.SceneManagement;

namespace AstroClient.AstroMonos.Components.Tools
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.Extensions.Components_exts;
    using AstroClient.Tools.ObjectEditor.Online;
    using AstroClient.Tools.Player;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using System;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class PickupController : MonoBehaviour
    {
        internal Action OnPickupHeld { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Action OnPickupDrop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool _CurrentHeldStatus = false;

        private bool CurrentHeldStatus
        {
            get => _CurrentHeldStatus;
            set
            {
                if (value != _CurrentHeldStatus)
                {
                    if (value)
                    {
                        PickupBlocker.PickupBlocker.OnPickupHeldCheck(this);
                        OnPickupHeld?.SafetyRaise();
                    }
                    else
                    {
                        OnPickupDrop?.SafetyRaise();
                    }
                }
                _CurrentHeldStatus = value;
            }
        }

        public List<MonoBehaviour> AntiGcList;

        public PickupController(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool _EventsAreEnabled = false;

        private bool EventsAreEnabled
        {
            [HideFromIl2Cpp]
            get => _EventsAreEnabled;
            [HideFromIl2Cpp]
            set
            {
                if (_EventsAreEnabled != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
                        ClientEventActions.OnQuickMenuOpen += OnQuickMenuOpen;
                        ClientEventActions.OnBigMenuOpen += OnBigMenuOpen;
                        ClientEventActions.OnBigMenuClose += OnBigMenuClose;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnQuickMenuClose -= OnQuickMenuClose;
                        ClientEventActions.OnQuickMenuOpen -= OnQuickMenuOpen;
                        ClientEventActions.OnBigMenuOpen -= OnBigMenuOpen;
                        ClientEventActions.OnBigMenuClose -= OnBigMenuClose;
                    }
                }
                _EventsAreEnabled = value;
            }
        }

        private bool _EnableInputEvents = false;

        private bool EnableInputEvents
        {
            [HideFromIl2Cpp]
            get => _EnableInputEvents;
            [HideFromIl2Cpp]
            set
            {
                if (_EnableInputEvents != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnInput_UseRight += OnInput_UseRight;
                        ClientEventActions.OnInput_UseLeft += OnInput_UseLeft;
                    }
                    else
                    {
                        ClientEventActions.OnInput_UseRight -= OnInput_UseRight;
                        ClientEventActions.OnInput_UseLeft -= OnInput_UseLeft;
                    }
                }
                _EnableInputEvents = value;
            }
        }

        private bool isUsingUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            SDK2_Pickup = gameObject.GetComponent<VRCSDK2.VRC_Pickup>();
            SDK3_Pickup = gameObject.GetComponent<VRCPickup>();
            RigidBodyController = gameObject.GetOrAddComponent<RigidBodyController>();
            EventsAreEnabled = true;
            SyncProperties(true);
            //Log.Debug("Attacked Successfully PickupController to object " + gameObject.name);
            isUsingUI = false;
            InvokeRepeating(nameof(PickupUpdate), 0.1f, 0.3f);
            InvokeRepeating(nameof(PickupProtection), 0.1f, 0.1f);
        }

        //private void Update()
        //{
        //    PickupProtection();
        //}
        private void PickupUpdate()
        {
            if (!isActiveAndEnabled) return;
            if (gameObject != null)
            {
                CurrentHeldStatus = this.IsHeld;
                Run_onPickupUpdate();
                if (!EditMode)
                    SyncProperties(true);
            }
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        private void OnQuickMenuClose()
        {
            isUsingUI = false;
            if (AntiTheft)
            {
                EnableInputEvents = true;
            }
        }

        private void OnQuickMenuOpen()
        {
            isUsingUI = true;
            if (AntiTheft)
            {
                EnableInputEvents = false;
            }
        }

        private void OnBigMenuOpen()
        {
            isUsingUI = true;
            if (AntiTheft)
            {
                EnableInputEvents = false;
            }
        }

        private void OnBigMenuClose()
        {
            isUsingUI = false;
            if (AntiTheft)
            {
                EnableInputEvents = true;
            }
        }

        internal void GrabItem(VRC_Pickup.PickupHand Hand)
        {
            if (Hand == VRC_Pickup.PickupHand.Right)
            {
                if (SDK2_Pickup != null)
                {
                    PlayerHands.SetPickup_RightHand(SDK2_Pickup);
                }
                else if(SDK3_Pickup != null)
                {
                    PlayerHands.SetPickup_RightHand(SDK3_Pickup);
                }
            }
            else
            {
                if (SDK2_Pickup != null)
                {
                    PlayerHands.SetPickup_LeftHand(SDK2_Pickup);
                }
                else if (SDK3_Pickup != null)
                {
                    PlayerHands.SetPickup_LeftHand(SDK3_Pickup);
                }
            }
        }

        private void OnInput_UseRight(bool isClicked, bool isDown, bool isUp)
        {
            if (AntiTheft)
            {
                if (isUsingUI) return;
                if (isClicked)
                    try
                    {
                        if (CurrentHolder == null && !IsHeld || CurrentHolder is { isLocal: false })
                            if (GameInstances.LocalPlayer.GetPickupInHand(VRC_Pickup.PickupHand.Right) == null)
                            {
                                if (SDK2_Pickup != null)
                                {
                                    PlayerHands.SetPickup_RightHand(SDK2_Pickup);

                                    return;
                                }
                                else if (SDK3_Pickup != null)
                                {
                                    PlayerHands.SetPickup_RightHand(SDK3_Pickup);
                                    return;
                                }
                            }
                        //gameObject.TeleportToMeWithRot(HumanBodyBones.RightHand, false);
                    }
                    catch
                    {
                    }
            }
        }

        private void OnInput_UseLeft(bool isClicked, bool isDown, bool isUp)
        {
            if (AntiTheft)
            {
                if (isUsingUI) return;
                if (isClicked)
                    try
                    {
                        if (CurrentHolder == null && !IsHeld || CurrentHolder is { isLocal: false })
                            if (GameInstances.LocalPlayer.GetPickupInHand(VRC_Pickup.PickupHand.Left) == null)
                            {
                                if (SDK2_Pickup != null)
                                {
                                    PlayerHands.SetPickup_LeftHand(SDK2_Pickup);
                                }
                                else if (SDK3_Pickup != null)
                                {
                                    PlayerHands.SetPickup_LeftHand(SDK3_Pickup);
                                }
                            }
                        //gameObject.TeleportToMeWithRot(HumanBodyBones.RightHand, false);
                    }
                    catch
                    {
                    }
            }
        }

        #region anti-grab method

        private void PickupProtection()
        {
            // Add a Shield for the Local User.
            if (!isActiveAndEnabled) return;
            if (!IsHeld) return;
            if (CurrentHolder == null) return;
            if (CurrentHolder.isLocal) return;
            if (AllowOnlySelfToGrab)
            {
                if (!CurrentHolder.isLocal)
                    OnlineEditor.TakeObjectOwnership(gameObject);
                gameObject.SetPosition(gameObject.transform.position);
                gameObject.SetRotation(gameObject.transform.rotation);
            }
        }

        private bool _AntiTheft = false;

        internal bool AntiTheft
        {
            [HideFromIl2Cpp]
            get
            {
                return _AntiTheft;
            }
            set
            {
                _AntiTheft = value;
                EnableInputEvents = value;
                if (!value)
                {
                    DisallowTheft = Original_DisallowTheft;
                }
            }
        }

        private bool _PreventOthersFromGrabbing;

        internal bool AllowOnlySelfToGrab
        {
            [HideFromIl2Cpp]
            get => _PreventOthersFromGrabbing;
            [HideFromIl2Cpp]
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
            if (isFromUpdate && _EditMode) _EditMode = false; // Disable this so it goes on Sync Mode.
             if (SDK2_Pickup != null)
            {
                CurrentHeldStatus = SDK2_Pickup.IsHeld;

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
                CurrentHeldStatus = SDK3_Pickup.IsHeld;

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

        private void OnDestroy()
        {
            EventsAreEnabled = false;
            OnPickupDrop = null;
            OnPickupHeld = null;
            RestoreProperties();
            WorldInfoEntry.Update_Pickups = true;
        }

        internal void RestoreProperties()
        {
            if (_EditMode)
            {
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

        internal VRCHandGrasper currentlyHeldBy
        {
            [HideFromIl2Cpp]
            get
            {
                try
                {
                    if (SDK2_Pickup != null) return SDK2_Pickup.currentlyHeldBy.TryCast<VRCHandGrasper>();
                    else if (SDK3_Pickup != null) return SDK3_Pickup.currentlyHeldBy.TryCast<VRCHandGrasper>();
                }
                catch { }
                return null;
            }
        }

        internal string UseDownEventName
        {
            [HideFromIl2Cpp]
            get => _UseDownEventName;
            [HideFromIl2Cpp]
            set
            {
                _UseDownEventName = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.UseDownEventName = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.UseDownEventName = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRCPlayerApi currentLocalPlayer
        {
            [HideFromIl2Cpp]
            get => _currentLocalPlayer;
            [HideFromIl2Cpp]
            set
            {
                _currentLocalPlayer = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.currentLocalPlayer = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.currentLocalPlayer = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal float ThrowVelocityBoostScale
        {
            [HideFromIl2Cpp]
            get => _ThrowVelocityBoostScale;
            [HideFromIl2Cpp]
            set
            {
                _ThrowVelocityBoostScale = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.ThrowVelocityBoostScale = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.ThrowVelocityBoostScale = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal float ThrowVelocityBoostMinSpeed
        {
            [HideFromIl2Cpp]
            get => _ThrowVelocityBoostMinSpeed;
            [HideFromIl2Cpp]
            set
            {
                _ThrowVelocityBoostMinSpeed = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.ThrowVelocityBoostMinSpeed = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.ThrowVelocityBoostMinSpeed = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string DropEventName
        {
            [HideFromIl2Cpp]
            get => _DropEventName;
            [HideFromIl2Cpp]
            set
            {
                _DropEventName = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.DropEventName = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.DropEventName = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string PickupEventName
        {
            [HideFromIl2Cpp]
            get => _PickupEventName;
            [HideFromIl2Cpp]
            set
            {
                _PickupEventName = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.PickupEventName = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.PickupEventName = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal bool pickupable
        {
            [HideFromIl2Cpp]
            get => _pickupable;
            [HideFromIl2Cpp]
            set
            {
                _pickupable = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.pickupable = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.pickupable = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string UseUpEventName
        {
            [HideFromIl2Cpp]
            get => _UseUpEventName;
            [HideFromIl2Cpp]
            set
            {
                _UseUpEventName = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.UseUpEventName = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.UseUpEventName = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRC_EventHandler.VrcBroadcastType useEventBroadcastType
        {
            [HideFromIl2Cpp]
            get => _useEventBroadcastType;
            [HideFromIl2Cpp]
            set
            {
                _useEventBroadcastType = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.useEventBroadcastType = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.useEventBroadcastType = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal VRC_Pickup.PickupOrientation orientation
        {
            [HideFromIl2Cpp]
            get => _orientation;
            [HideFromIl2Cpp]
            set
            {
                _orientation = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.orientation = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.orientation = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string InteractionText
        {
            [HideFromIl2Cpp]
            get => _InteractionText;
            [HideFromIl2Cpp]
            set
            {
                _InteractionText = value;
                if (SDK2_Pickup != null) SDK2_Pickup.InteractionText = value;
                if (SDK3_Pickup != null) SDK3_Pickup.InteractionText = value;
                if (EditMode) Run_OnOnPickupPropertyChanged();
            }
        }

        internal VRC_Pickup.AutoHoldMode AutoHold
        {
            [HideFromIl2Cpp]
            get => _AutoHold;
            [HideFromIl2Cpp]
            set
            {
                _AutoHold = value;
                if (SDK2_Pickup != null) SDK2_Pickup.AutoHold = value;
                if (SDK3_Pickup != null) SDK3_Pickup.AutoHold = value;
                if (EditMode) Run_OnOnPickupPropertyChanged();
            }
        }

        internal float proximity
        {
            [HideFromIl2Cpp]
            get => _proximity;
            [HideFromIl2Cpp]
            set
            {
                _proximity = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.proximity = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.proximity = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal bool allowManipulationWhenEquipped
        {
            [HideFromIl2Cpp]
            get => _allowManipulationWhenEquipped;
            [HideFromIl2Cpp]
            set
            {
                _allowManipulationWhenEquipped = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.allowManipulationWhenEquipped = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.allowManipulationWhenEquipped = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal Transform ExactGrip
        {
            [HideFromIl2Cpp]
            get => _ExactGrip;
            [HideFromIl2Cpp]
            set
            {
                _ExactGrip = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.ExactGrip = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.ExactGrip = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal Transform ExactGun
        {
            [HideFromIl2Cpp]
            get => _ExactGun;
            [HideFromIl2Cpp]
            set
            {
                _ExactGun = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.ExactGun = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.ExactGun = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal bool DisallowTheft
        {
            [HideFromIl2Cpp]
            get => _DisallowTheft;
            [HideFromIl2Cpp]
            set
            {
                _DisallowTheft = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.DisallowTheft = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.DisallowTheft = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal ForceMode MomentumTransferMethod
        {
            [HideFromIl2Cpp]
            get => _MomentumTransferMethod;
            [HideFromIl2Cpp]
            set
            {
                _MomentumTransferMethod = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.MomentumTransferMethod = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.MomentumTransferMethod = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        internal string UseText
        {
            [HideFromIl2Cpp]
            get => _UseText;
            [HideFromIl2Cpp]
            set
            {
                _UseText = value;
                if (SDK2_Pickup != null) SDK2_Pickup.UseText = value;
                if (SDK3_Pickup != null) SDK3_Pickup.UseText = value;
                if (EditMode) Run_OnOnPickupPropertyChanged();
            }
        }

        internal VRC_EventHandler.VrcBroadcastType pickupDropEventBroadcastType
        {
            [HideFromIl2Cpp]
            get => _pickupDropEventBroadcastType;
            [HideFromIl2Cpp]
            set
            {
                _pickupDropEventBroadcastType = value;
                if (EditMode)
                {
                    if (SDK2_Pickup != null) SDK2_Pickup.pickupDropEventBroadcastType = value;
                    if (SDK3_Pickup != null) SDK3_Pickup.pickupDropEventBroadcastType = value;
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        #endregion Reflected Values

        #region Pickup Getters Only

        internal bool IsHeld
        {
            [HideFromIl2Cpp]
            get
            {
                if (SDK2_Pickup != null) return SDK2_Pickup.IsHeld;
                if (SDK3_Pickup != null) return SDK3_Pickup.IsHeld;
                return false;
            }
        }

        internal VRC_Pickup.PickupHand CurrentHand
        {
            [HideFromIl2Cpp]
            get
            {
                if (SDK2_Pickup != null) return SDK2_Pickup.currentHand;
                if (SDK3_Pickup != null) return SDK3_Pickup.currentHand;
                return VRC_Pickup.PickupHand.None;
            }
        }

        internal VRCPlayerApi currentPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                try
                {
                    if (SDK2_Pickup != null)
                    {
                        var user = SDK2_Pickup.currentPlayer;
                        if (user != null) return user;
                    }
                    else if (SDK3_Pickup != null)
                    {
                        var user = SDK3_Pickup.currentPlayer;
                        if (user != null) return user;
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
            [HideFromIl2Cpp]
            get
            {
                var owner = Networking.GetOwner(gameObject);
                if (owner != null) return owner.displayName;
                return "Unassigned owner";
            }
        }

        internal string CurrentHolderDisplayName
        {
            [HideFromIl2Cpp]
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

        internal void Drop()
        {
            currentlyHeldBy.Drop();
        }

        internal VRCPlayerApi CurrentHolder
        {
            [HideFromIl2Cpp]
            get
            {
                try
                {
                    if (SDK2_Pickup != null)
                    {
                        var user = SDK2_Pickup.currentPlayer;
                        if (user != null) return user;
                    }
                    else if (SDK3_Pickup != null)
                    {
                        var user = SDK3_Pickup.currentPlayer;
                        if (user != null) return user;
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
            if (SDK2_Pickup != null || SDK3_Pickup != null) return true;
            return false;
        }

        internal void SetRigidbody()
        {
            if (HasSetRigidbodyController) return;
            if (!HasSetRigidbodyController)
            {
                if (RigidBodyController != null)
                    // IF INTERNAL SYNC IS NULL, Force The rigidbody to take over , Then [HideFromIl2Cpp] set it as Kinematic in case no collider is present.
                    if (RigidBodyController.SyncPhysics == null)
                    {
                        if (!RigidBodyController.Forced_Rigidbody) RigidBodyController.Forced_Rigidbody = true;
                        if (!RigidBodyController.EditMode) RigidBodyController.EditMode = true;
                        // Let's use smart kinematic (Checks for Colliders present that can block and prevent the fall of the object).

                        if (RigidBodyController != null)
                        {
                            var will_it_fall_throught = RigidBodyController.RigidBody_Will_It_fall_throught();
                            if (!will_it_fall_throught) RigidBodyController.RigidBody_Override_isKinematic(false);
                            else RigidBodyController.RigidBody_Override_isKinematic(true);
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

        private void ForcePickupComponent()
        {
            SetRigidbody();

            if (!hasRequiredComponentBeenAdded)
            {
                switch (SceneUtils.SDKVersion)
                {
                    case 3:
                        SDK3_Pickup = gameObject.GetOrAddComponent<VRCPickup>();
                        // verify if the pickup is added
                        if (SDK3_Pickup != null)
                        {
                            hasRequiredComponentBeenAdded = true;
                        }
                        break;

                    default:
                        SDK2_Pickup = gameObject.GetOrAddComponent<VRCSDK2.VRC_Pickup>();
                        if (SDK2_Pickup != null)
                        {
                            hasRequiredComponentBeenAdded = true;
                        }
                        break;
                }
            }
            if (!hasRequiredComponentBeenAdded)
            {
                ForceComponent = false;
            }
        }

        private bool HasSetRigidbodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool hasRequiredComponentBeenAdded { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private bool _ForceComponent;

        internal bool ForceComponent
        {
            [HideFromIl2Cpp]
            get => _ForceComponent;
            [HideFromIl2Cpp]
            set
            {
                if (value)
                {
                    _ForceComponent = true;
                    if (!hasRequiredComponentBeenAdded) ForcePickupComponent();
                    Run_OnOnPickupPropertyChanged();
                }
            }
        }

        #endregion Force Pickup Functions

        #region essentials

        private VRCSDK2.VRC_Pickup _SDK2_Pickup;

        internal VRCSDK2.VRC_Pickup SDK2_Pickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (SceneUtils.isSDK2)
                {
                    if (_SDK2_Pickup == null) return _SDK2_Pickup = gameObject.GetComponent<VRCSDK2.VRC_Pickup>();
                }
                return _SDK2_Pickup;
            }
            [HideFromIl2Cpp]
            private set => _SDK2_Pickup = value;
        }

        private VRCPickup _SDK3_Pickup;

        internal VRCPickup SDK3_Pickup
        {
            [HideFromIl2Cpp]
            get
            {
                if (SceneUtils.isSDK3)
                {
                    if (_SDK3_Pickup == null) return _SDK3_Pickup = gameObject.GetComponent<VRCPickup>();
                }
                return _SDK3_Pickup;
            }
            [HideFromIl2Cpp]
            private set => _SDK3_Pickup = value;
        }

        internal RigidBodyController RigidBodyController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private bool _EditMode;

        internal bool EditMode
        {
            [HideFromIl2Cpp]
            get => _EditMode;
            [HideFromIl2Cpp]
            set
            {
                if (value) SyncProperties(false);
                else RestoreProperties();
                _EditMode = value;
                Run_OnOnPickupPropertyChanged();
            }
        }

        #endregion essentials
    }
}