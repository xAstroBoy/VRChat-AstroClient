namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using System;
	using UnhollowerBaseLib.Attributes;
	using VRC.SDKBase;
	using VRC_Pickup = VRC.SDKBase.VRC_Pickup;

	public class PickupController : GameEventsBehaviour
    {
        public PickupController(IntPtr ptr) : base(ptr)
        {
        }

        // Use this for initialization
        public void Start()
        {
            Pickup1 = gameObject.GetComponent<VRC_Pickup>();
            Pickup2 = gameObject.GetComponent<VRCSDK2.VRC_Pickup>();
            Pickup3 = gameObject.GetComponent<VRC.SDK3.Components.VRCPickup>();

            control = gameObject.GetOrAddComponent<RigidBodyController>();
            BackupOriginalProperties();
            Locked = false;
            ModConsole.DebugLog("Attacked Successfully PickupController to object " + gameObject.name);
        }

        [HideFromIl2Cpp]
        private void BackupOriginalProperties()
        {
            if (Pickup1 != null)
            {
                Original_allowManipulationWhenEquipped = Pickup1.allowManipulationWhenEquipped;
                Original_pickupable = Pickup1.pickupable;
                Original_DisallowTheft = Pickup1.DisallowTheft;
                Original_AutoHold = Pickup1.AutoHold;
                Original_orientation = Pickup1.orientation;
                Original_Proximity = Pickup1.proximity;
                proximity = Pickup1.proximity;
                allowManipulationWhenEquipped = Pickup1.allowManipulationWhenEquipped;
                pickupable = Pickup1.pickupable;
                DisallowTheft = Pickup1.DisallowTheft;
                AutoHoldMode = Pickup1.AutoHold;
                PickupOrientation = Pickup1.orientation;
            }
            else if (Pickup2 != null)
            {
                Original_allowManipulationWhenEquipped = Pickup2.allowManipulationWhenEquipped;
                Original_pickupable = Pickup2.pickupable;
                Original_DisallowTheft = Pickup2.DisallowTheft;
                Original_AutoHold = Pickup2.AutoHold;
                Original_orientation = Pickup2.orientation;
                Original_Proximity = Pickup2.proximity;
                proximity = Pickup2.proximity;
                allowManipulationWhenEquipped = Pickup2.allowManipulationWhenEquipped;
                pickupable = Pickup2.pickupable;
                DisallowTheft = Pickup2.DisallowTheft;
                AutoHoldMode = Pickup2.AutoHold;
                PickupOrientation = Pickup2.orientation;
            }
            else if (Pickup3 != null)
            {
                Original_allowManipulationWhenEquipped = Pickup3.allowManipulationWhenEquipped;
                Original_pickupable = Pickup3.pickupable;
                Original_DisallowTheft = Pickup3.DisallowTheft;
                Original_AutoHold = Pickup3.AutoHold;
                Original_orientation = Pickup3.orientation;
                Original_Proximity = Pickup3.proximity;
                proximity = Pickup3.proximity;
                allowManipulationWhenEquipped = Pickup3.allowManipulationWhenEquipped;
                pickupable = Pickup3.pickupable;
                DisallowTheft = Pickup3.DisallowTheft;
                AutoHoldMode = Pickup3.AutoHold;
                PickupOrientation = Pickup3.orientation;
            }
        }

        [HideFromIl2Cpp]
        internal void RestoreOriginalProperties()
        {
            Locked = true;
            allowManipulationWhenEquipped = Original_allowManipulationWhenEquipped;
            pickupable = Original_pickupable;
            DisallowTheft = Original_DisallowTheft;
            AutoHoldMode = Original_AutoHold;
            PickupOrientation = Original_orientation;
            proximity = Original_Proximity;

            if (Pickup1 != null)
            {
                Pickup1.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                Pickup1.pickupable = pickupable;
                Pickup1.DisallowTheft = DisallowTheft;
                Pickup1.AutoHold = AutoHoldMode;
                Pickup1.orientation = PickupOrientation;
                Pickup1.proximity = proximity;
            }
            else if (Pickup2 != null)
            {
                Pickup2.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                Pickup2.pickupable = pickupable;
                Pickup2.DisallowTheft = DisallowTheft;
                Pickup2.AutoHold = AutoHoldMode;
                Pickup2.orientation = PickupOrientation;
                Pickup2.proximity = proximity;
            }
            else if (Pickup3 != null)
            {
                Pickup3.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                Pickup3.pickupable = pickupable;
                Pickup3.DisallowTheft = DisallowTheft;
                Pickup3.AutoHold = AutoHoldMode;
                Pickup3.orientation = PickupOrientation;
                Pickup3.proximity = proximity;
            }
            Locked = false;
        }

        [HideFromIl2Cpp]
        internal void SetRigidbody()
        {
            if (HasSetRigidbodyController)
            {
                return;
            }
            if (!HasSetRigidbodyController)
            {
                if (control != null)
                {
                    // IF INTERNAL SYNC IS NULL, Force The rigidbody to take over , Then Set it as Kinematic in case no collider is present.
                    if (control.Internal_Sync == null)
                    {
                        if (!control.Forced_RigidBody)
                        {
                            control.Forced_RigidBody = true;
                        }
                        if (!control.EditMode)
                        {
                            control.EditMode = true;
                        }
                        if (!control.isKinematic)
                        {
                            control.isKinematic = true;
                        }
                    }
                }
                HasSetRigidbodyController = true;
            }
        }

        // Update is called once per frame
        public void Update()
        {
            try
            {
                if (Locked)
                {
                    return;
                }
                Run_onPickupUpdate();
                if (ForceComponent)
                {
                    SetRigidbody();

                    if (!hasRequiredComponentBeenAdded)
                    {
                        Pickup1 = gameObject.GetComponent<VRC_Pickup>();
                        Pickup2 = gameObject.GetComponent<VRCSDK2.VRC_Pickup>();
                        Pickup3 = gameObject.GetComponent<VRC.SDK3.Components.VRCPickup>();
                        if (!HasTriedWithPickup1)
                        {
                            if (Pickup1 == null)
                            {
                                ModConsole.DebugLog("PickupController : Attempting to add  VRC.SDKBase.VRC_Pickup to object " + gameObject.name);
                                Pickup1 = gameObject.AddComponent<VRC_Pickup>();
                                if (Pickup1 == null)
                                {
                                    ModConsole.DebugLog("PickupController : Failed to add  VRC.SDKBase.VRC_Pickup to object " + gameObject.name);
                                    HasTriedWithPickup1 = true;
                                }
                                else
                                {
                                    ModConsole.DebugLog("PickupController : Added VRC.SDKBase.VRC_Pickup to object " + gameObject.name);
                                    if (Pickup1.ExactGrip == null)
                                    {
                                        Pickup1.ExactGrip = gameObject.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDKBase.VRC_Pickup ExactGrip to object transform " + gameObject.name);
                                    }
                                    if (Pickup1.ExactGun == null)
                                    {
                                        Pickup1.ExactGun = gameObject.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDKBase.VRC_Pickup ExactGun to object transform " + gameObject.name);
                                    }

                                    hasRequiredComponentBeenAdded = true;
                                    HasTriedWithPickup1 = true;
                                }
                            }
                            return;
                        }
                        if (!HasTriedWithPickup2)
                        {
                            if (Pickup2 == null)
                            {
                                ModConsole.DebugLog("PickupController : Attempting to add  VRCSDK2.VRC_Pickup to object " + gameObject.name);
                                Pickup2 = gameObject.AddComponent<VRCSDK2.VRC_Pickup>();
                                if (Pickup2 == null)
                                {
                                    ModConsole.DebugLog("PickupController : Failed to add  VRCSDK2.VRC_Pickup to object " + gameObject.name);
                                    HasTriedWithPickup2 = true;
                                }
                                else
                                {
                                    ModConsole.DebugLog("PickupController : Added VRCSDK2.VRC_Pickup to object " + gameObject.name);
                                    if (Pickup2.ExactGrip == null)
                                    {
                                        Pickup2.ExactGrip = gameObject.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRCSDK2.VRC_Pickup ExactGrip to object transform " + gameObject.name);
                                    }
                                    if (Pickup2.ExactGun == null)
                                    {
                                        Pickup2.ExactGun = gameObject.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRCSDK2.VRC_Pickup ExactGun to object transform " + gameObject.name);
                                    }
                                    hasRequiredComponentBeenAdded = true;
                                    HasTriedWithPickup2 = true;
                                }
                            }
                            return;
                        }
                        if (!HasTriedWithPickup3)
                        {
                            if (Pickup3 == null)
                            {
                                ModConsole.DebugLog("PickupController : Attempting to add  VRC.SDK3.Components.VRCPickup to object " + gameObject.name);
                                Pickup3 = gameObject.AddComponent<VRC.SDK3.Components.VRCPickup>();
                                if (Pickup3 == null)
                                {
                                    ModConsole.DebugLog("PickupController : Failed to add  VRC.SDK3.Components.VRCPickup to object " + gameObject.name);
                                    HasTriedWithPickup3 = true;
                                }
                                else
                                {
                                    ModConsole.DebugLog("PickupController : Added VRC.SDK3.Components.VRCPickup to object " + gameObject.name);
                                    if (Pickup3.ExactGrip == null)
                                    {
                                        Pickup3.ExactGrip = gameObject.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDK3.Components.VRCPickup ExactGrip to object transform " + gameObject.name);
                                    }
                                    if (Pickup3.ExactGun == null)
                                    {
                                        Pickup3.ExactGun = gameObject.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDK3.Components.VRCPickup ExactGun to object transform " + gameObject.name);
                                    }

                                    hasRequiredComponentBeenAdded = true;
                                    HasTriedWithPickup3 = true;
                                }
                            }
                            return;
                        }
                        if (!hasRequiredComponentBeenAdded && HasTriedWithPickup1 && HasTriedWithPickup2 && HasTriedWithPickup3)
                        {
                            ModConsole.DebugWarning("Failed to add A Pickup Component to the object : " + gameObject.name);
                            ForceComponent = false;
                            HasTriedWithPickup1 = false;
                            HasTriedWithPickup2 = false;
                            HasTriedWithPickup3 = false;
                            hasRequiredComponentBeenAdded = false;
                            return;
                        }
                    }
                }
                if (EditMode)
                {
                    if (Pickup1 != null)
                    {
                        if (Pickup1.allowManipulationWhenEquipped != allowManipulationWhenEquipped)
                        {
                            Pickup1.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                        }
                        if (Pickup1.pickupable != pickupable)
                        {
                            Pickup1.pickupable = pickupable;
                        }
                        if (Pickup1.DisallowTheft != DisallowTheft)
                        {
                            Pickup1.DisallowTheft = DisallowTheft;
                        }
                        if (Pickup1.AutoHold != AutoHoldMode)
                        {
                            Pickup1.AutoHold = AutoHoldMode;
                        }
                        if (Pickup1.orientation != PickupOrientation)
                        {
                            Pickup1.orientation = PickupOrientation;
                        }
                        if (Pickup1.proximity != proximity)
                        {
                            Pickup1.proximity = proximity;
                        }
                    }
                    if (Pickup2 != null)
                    {
                        if (Pickup2.allowManipulationWhenEquipped != allowManipulationWhenEquipped)
                        {
                            Pickup2.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                        }
                        if (Pickup2.pickupable != pickupable)
                        {
                            Pickup2.pickupable = pickupable;
                        }
                        if (Pickup2.DisallowTheft != DisallowTheft)
                        {
                            Pickup2.DisallowTheft = DisallowTheft;
                        }
                        if (Pickup2.AutoHold != AutoHoldMode)
                        {
                            Pickup2.AutoHold = AutoHoldMode;
                        }
                        if (Pickup2.orientation != PickupOrientation)
                        {
                            Pickup2.orientation = PickupOrientation;
                        }
                        if (Pickup2.proximity != proximity)
                        {
                            Pickup2.proximity = proximity;
                        }
                    }
                    if (Pickup3 != null)
                    {
                        if (Pickup3.allowManipulationWhenEquipped != allowManipulationWhenEquipped)
                        {
                            Pickup3.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                        }
                        if (Pickup3.pickupable != pickupable)
                        {
                            Pickup3.pickupable = pickupable;
                        }
                        if (Pickup3.DisallowTheft != DisallowTheft)
                        {
                            Pickup3.DisallowTheft = DisallowTheft;
                        }
                        if (Pickup3.AutoHold != AutoHoldMode)
                        {
                            Pickup3.AutoHold = AutoHoldMode;
                        }
                        if (Pickup3.orientation != PickupOrientation)
                        {
                            Pickup3.orientation = PickupOrientation;
                        }
                        if (Pickup3.proximity != proximity)
                        {
                            Pickup3.proximity = proximity;
                        }
                    }
                }
                else
                {
                    if (Pickup1 != null)
                    {
                        if (allowManipulationWhenEquipped != Pickup1.allowManipulationWhenEquipped)
                        {
                            if (!EditMode)
                            {
                                allowManipulationWhenEquipped = Pickup1.allowManipulationWhenEquipped;
                            }
                        }
                        if (pickupable != Pickup1.pickupable)
                        {
                            if (!EditMode)
                            {
                                pickupable = Pickup1.pickupable;
                            }
                        }
                        if (DisallowTheft != Pickup1.DisallowTheft)
                        {
                            if (!EditMode)
                            {
                                DisallowTheft = Pickup1.DisallowTheft;
                            }
                        }
                        if (AutoHoldMode != Pickup1.AutoHold)
                        {
                            if (!EditMode)
                            {
                                AutoHoldMode = Pickup1.AutoHold;
                            }
                        }
                        if (PickupOrientation != Pickup1.orientation)
                        {
                            if (!EditMode)
                            {
                                PickupOrientation = Pickup1.orientation;
                            }
                        }
                        if (proximity != Pickup1.proximity)
                        {
                            if (!EditMode)
                            {
                                proximity = Pickup1.proximity;
                            }
                        }
                        if (Original_allowManipulationWhenEquipped != Pickup1.allowManipulationWhenEquipped)
                        {
                            if (!EditMode)
                            {
                                Original_allowManipulationWhenEquipped = Pickup1.allowManipulationWhenEquipped;
                            }
                        }
                        if (Original_pickupable != Pickup1.pickupable)
                        {
                            if (!EditMode)
                            {
                                Original_pickupable = Pickup1.pickupable;
                            }
                        }
                        if (Original_DisallowTheft != Pickup1.DisallowTheft)
                        {
                            if (!EditMode)
                            {
                                Original_DisallowTheft = Pickup1.DisallowTheft;
                            }
                        }
                        if (Original_AutoHold != Pickup1.AutoHold)
                        {
                            if (!EditMode)
                            {
                                Original_AutoHold = Pickup1.AutoHold;
                            }
                        }
                        if (Original_orientation != Pickup1.orientation)
                        {
                            if (!EditMode)
                            {
                                Original_orientation = Pickup1.orientation;
                            }
                        }
                        if (Original_Proximity != Pickup1.proximity)
                        {
                            if (!EditMode)
                            {
                                Original_Proximity = Pickup1.proximity;
                            }
                        }
                    }
                    if (Pickup2 != null)
                    {
                        if (allowManipulationWhenEquipped != Pickup2.allowManipulationWhenEquipped)
                        {
                            if (!EditMode)
                            {
                                allowManipulationWhenEquipped = Pickup2.allowManipulationWhenEquipped;
                            }
                        }
                        if (pickupable != Pickup2.pickupable)
                        {
                            if (!EditMode)
                            {
                                pickupable = Pickup2.pickupable;
                            }
                        }
                        if (DisallowTheft != Pickup2.DisallowTheft)
                        {
                            if (!EditMode)
                            {
                                DisallowTheft = Pickup2.DisallowTheft;
                            }
                        }
                        if (AutoHoldMode != Pickup2.AutoHold)
                        {
                            if (!EditMode)
                            {
                                AutoHoldMode = Pickup2.AutoHold;
                            }
                        }
                        if (PickupOrientation != Pickup2.orientation)
                        {
                            if (!EditMode)
                            {
                                PickupOrientation = Pickup2.orientation;
                            }
                        }
                        if (proximity != Pickup2.proximity)
                        {
                            if (!EditMode)
                            {
                                proximity = Pickup2.proximity;
                            }
                        }
                        if (Original_allowManipulationWhenEquipped != Pickup2.allowManipulationWhenEquipped)
                        {
                            if (!EditMode)
                            {
                                Original_allowManipulationWhenEquipped = Pickup2.allowManipulationWhenEquipped;
                            }
                        }
                        if (Original_pickupable != Pickup2.pickupable)
                        {
                            if (!EditMode)
                            {
                                Original_pickupable = Pickup2.pickupable;
                            }
                        }
                        if (Original_DisallowTheft != Pickup2.DisallowTheft)
                        {
                            if (!EditMode)
                            {
                                Original_DisallowTheft = Pickup2.DisallowTheft;
                            }
                        }
                        if (Original_AutoHold != Pickup2.AutoHold)
                        {
                            if (!EditMode)
                            {
                                Original_AutoHold = Pickup2.AutoHold;
                            }
                        }
                        if (Original_orientation != Pickup2.orientation)
                        {
                            if (!EditMode)
                            {
                                Original_orientation = Pickup2.orientation;
                            }
                        }
                        if (Original_Proximity != Pickup2.proximity)
                        {
                            if (!EditMode)
                            {
                                Original_Proximity = Pickup2.proximity;
                            }
                        }
                    }
                    if (Pickup3 != null)
                    {
                        if (allowManipulationWhenEquipped != Pickup3.allowManipulationWhenEquipped)
                        {
                            if (!EditMode)
                            {
                                allowManipulationWhenEquipped = Pickup3.allowManipulationWhenEquipped;
                            }
                        }
                        if (pickupable != Pickup3.pickupable)
                        {
                            if (!EditMode)
                            {
                                pickupable = Pickup3.pickupable;
                            }
                        }
                        if (DisallowTheft != Pickup3.DisallowTheft)
                        {
                            if (!EditMode)
                            {
                                DisallowTheft = Pickup3.DisallowTheft;
                            }
                        }
                        if (AutoHoldMode != Pickup3.AutoHold)
                        {
                            if (!EditMode)
                            {
                                AutoHoldMode = Pickup3.AutoHold;
                            }
                        }
                        if (PickupOrientation != Pickup3.orientation)
                        {
                            if (!EditMode)
                            {
                                PickupOrientation = Pickup3.orientation;
                            }
                        }
                        if (proximity != Pickup3.proximity)
                        {
                            if (!EditMode)
                            {
                                proximity = Pickup3.proximity;
                            }
                        }
                        if (Original_allowManipulationWhenEquipped != Pickup3.allowManipulationWhenEquipped)
                        {
                            if (!EditMode)
                            {
                                Original_allowManipulationWhenEquipped = Pickup3.allowManipulationWhenEquipped;
                            }
                        }
                        if (Original_pickupable != Pickup3.pickupable)
                        {
                            if (!EditMode)
                            {
                                Original_pickupable = Pickup3.pickupable;
                            }
                        }
                        if (Original_DisallowTheft != Pickup3.DisallowTheft)
                        {
                            if (!EditMode)
                            {
                                Original_DisallowTheft = Pickup3.DisallowTheft;
                            }
                        }
                        if (Original_AutoHold != Pickup3.AutoHold)
                        {
                            if (!EditMode)
                            {
                                Original_AutoHold = Pickup3.AutoHold;
                            }
                        }
                        if (Original_orientation != Pickup3.orientation)
                        {
                            if (!EditMode)
                            {
                                Original_orientation = Pickup3.orientation;
                            }
                        }
                        if (Original_Proximity != Pickup3.proximity)
                        {
                            if (!EditMode)
                            {
                                Original_Proximity = Pickup3.proximity;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugError("Error in PickupController Bound to : " + gameObject.name);
                ModConsole.DebugErrorExc(e);
            }
        }

        private void OnDestroy()
        {
            ModConsole.DebugLog("PickupController Got Destroyed from " + gameObject.name);
        }

        // TODO: Remove this and use OnPickupPropertyChanged

        [HideFromIl2Cpp]
        internal string CurrentOwner
        {
            [HideFromIl2Cpp]
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

        // NEEDS a listener here in all properties!

        [HideFromIl2Cpp]
        internal bool IsHeld
        {
            [HideFromIl2Cpp]
            get
            {
                if (Pickup1 != null)
                {
                    return Pickup1.IsHeld;
                }
                else if (Pickup2 != null)
                {
                    return Pickup2.IsHeld;
                }
                else if (Pickup3 != null)
                {
                    return Pickup3.IsHeld;
                }
                else
                {
                    return false;
                }
            }
        }

        [HideFromIl2Cpp]
        internal string CurrentHolderDisplayName
        {
            [HideFromIl2Cpp]
            get
            {
                try
                {
                    if (Pickup1 != null)
                    {
                        var user = Pickup1.currentPlayer;
                        if (user != null)
                        {
                            return user.displayName;
                        }
                    }
                    else if (Pickup2 != null)
                    {
                        var user = Pickup2.currentPlayer;
                        if (user != null)
                        {
                            return user.displayName;
                        }
                    }
                    else if (Pickup3 != null)
                    {
                        var user = Pickup3.currentPlayer;
                        if (user != null)
                        {
                            return user.displayName;
                        }
                    }
                }
                catch
                {
                }
                return "None";
            }
        }

        internal VRCPlayerApi CurrentObjectHolderPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                try
                {
                    if (Pickup1 != null)
                    {
                        var user = Pickup1.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                    else if (Pickup2 != null)
                    {
                        var user = Pickup2.currentPlayer;
                        if (user != null)
                        {
                            return user;
                        }
                    }
                    else if (Pickup3 != null)
                    {
                        var user = Pickup3.currentPlayer;
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

        [HideFromIl2Cpp]
        internal bool HasPickupComponent()
        {
            if (Pickup1 != null)
            {
                return true;
            }
            else if (Pickup2 != null)
            {
                return true;
            }
            else if (Pickup3 != null)
            {
                return true;
            }
            return false;
        }

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

        private VRC_Pickup Pickup1 { get; set; }
        private VRCSDK2.VRC_Pickup Pickup2 { get; set; }
        private VRC.SDK3.Components.VRCPickup Pickup3 { get; set; }
        private RigidBodyController control { get; set; } = null;
        private protected bool Locked = false;

        private bool HasTriedWithPickup1 { get; set; } = false;
        private bool HasTriedWithPickup2 { get; set; } = false;
        private bool HasTriedWithPickup3 { get; set; } = false;
        private bool HasSetRigidbodyController { get; set; } = false;

        private bool hasRequiredComponentBeenAdded { get; set; } = false;

        private bool Original_allowManipulationWhenEquipped { get; set; }
        private bool Original_pickupable { get; set; }
        private bool Original_DisallowTheft { get; set; }
        private float Original_Proximity { get; set; }
        private VRC_Pickup.AutoHoldMode Original_AutoHold { get; set; }
        private VRC_Pickup.PickupOrientation Original_orientation { get; set; }

        private bool _EditMode = false;

        internal bool EditMode
        {
            get
            {
                return _EditMode;
            }
            set
            {
                _EditMode = value;
                Run_OnOnPickupPropertyChanged();
            }
        }

        private bool _ForceComponent = false;
        private bool _allowManipulationWhenEquipped;
        private bool _pickupable;
        private bool _DisallowTheft;
        private float _proximity;
        private VRC_Pickup.AutoHoldMode _AutoHoldMode;
        private VRC_Pickup.PickupOrientation _PickupOrientation;

        internal bool ForceComponent
        {
            get
            {
                return _ForceComponent;
            }
            set
            {
                _ForceComponent = value;
                Run_OnOnPickupPropertyChanged();
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
                Run_OnOnPickupPropertyChanged();
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
                Run_OnOnPickupPropertyChanged();
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
                Run_OnOnPickupPropertyChanged();
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
                Run_OnOnPickupPropertyChanged();
            }
        }

        internal VRC_Pickup.AutoHoldMode AutoHoldMode
        {
            get
            {
                return _AutoHoldMode;
            }
            set
            {
                _AutoHoldMode = value;
                Run_OnOnPickupPropertyChanged();
            }
        }

        internal VRC_Pickup.PickupOrientation PickupOrientation
        {
            get
            {
                return _PickupOrientation;
            }
            set
            {
                _PickupOrientation = value;
                Run_OnOnPickupPropertyChanged();
            }
        }
    }
}