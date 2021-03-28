using AstroClient.ConsoleUtils;
using AstroClient.ItemTweaker;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;
using static AstroClient.AstroUtils.ItemTweaker.ItemTweakerMain;
using VRC_Pickup = VRC.SDKBase.VRC_Pickup;

namespace AstroClient.components
{
    public class PickupController : MonoBehaviour
    {
        public PickupController(IntPtr ptr) : base(ptr)
        {
        }

        // Use this for initialization
        public void Start()
        {
            obj = gameObject;
            Pickup1 = GetComponent<VRC.SDKBase.VRC_Pickup>();
            Pickup2 = GetComponent<VRCSDK2.VRC_Pickup>();
            Pickup3 = GetComponent<VRC.SDK3.Components.VRCPickup>();
            BackupOriginalProperties();
            EditMode = false;
            Locked = false;
            ModConsole.DebugLog("Attacked Successfully PickupController to object " + obj.name);
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
                AutoHold = Pickup1.AutoHold;
                orientation = Pickup1.orientation;
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
                AutoHold = Pickup2.AutoHold;
                orientation = Pickup2.orientation;
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
                AutoHold = Pickup3.AutoHold;
                orientation = Pickup3.orientation;
            }
        }

        [HideFromIl2Cpp]
        internal void RestoreOriginalProperties()
        {
            Locked = true;
            allowManipulationWhenEquipped = Original_allowManipulationWhenEquipped;
            pickupable = Original_pickupable;
            DisallowTheft = Original_DisallowTheft;
            AutoHold = Original_AutoHold;
            orientation = Original_orientation;
            proximity = Original_Proximity;

            if (Pickup1 != null)
            {
                Pickup1.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                Pickup1.pickupable = pickupable;
                Pickup1.DisallowTheft = DisallowTheft;
                Pickup1.AutoHold = AutoHold;
                Pickup1.orientation = orientation;
                Pickup1.proximity = proximity;
            }
            else if (Pickup2 != null)
            {
                Pickup2.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                Pickup2.pickupable = pickupable;
                Pickup2.DisallowTheft = DisallowTheft;
                Pickup2.AutoHold = AutoHold;
                Pickup2.orientation = orientation;
                Pickup2.proximity = proximity;
            }
            else if (Pickup3 != null)
            {
                Pickup3.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                Pickup3.pickupable = pickupable;
                Pickup3.DisallowTheft = DisallowTheft;
                Pickup3.AutoHold = AutoHold;
                Pickup3.orientation = orientation;
                Pickup3.proximity = proximity;
            }
            EditMode = false;
            Locked = false;
        }

        // Update is called once per frame
        public void Update()
        {
            try
            {
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    UpdateHeldOwnerBtn();
                    UpdateEditMode();
                    UpdatePickupOwnerBtns();
                    UpdateIsHeld();
                    UpdatePickupOrientationBtn();
                    UpdateAutoHold();
                    UpdateAutoHoldMode();
                    Updatepickupable();
                    UpdateDisallowTheft();
                    UpdateProximitySlider();
                    UpdateHasPickupComponent();
                }

                if (Locked)
                {
                    return;
                }

                if (ForceComponent)
                {
                    if (!hasRequiredComponentBeenAdded)
                    {
                        if (!HasAddedRigidBodyController)
                        {
                            var RigidBodyController = obj.GetComponent<RigidBodyController>();
                            if (RigidBodyController == null)
                            {
                                RigidBodyController = obj.AddComponent<RigidBodyController>();
                            }
                            // IF INTERNAL SYNC IS NULL, FORCE ADD IT THEN REPLACE DEFAULT KINEMATIC TO TRUE BY DEFAULT TO AVOID OBJECTS FALLING IN THE WORLD.
                            if (RigidBodyController.Internal_Sync == null)
                            {
                                RigidBodyController.ForcedMode = true;
                                RigidBodyController.EditMode = true;
                                RigidBodyController.isKinematic = true;
                            }
                            HasAddedRigidBodyController = true;
                        }
                        Pickup1 = obj.GetComponent<VRC.SDKBase.VRC_Pickup>();
                        Pickup2 = obj.GetComponent<VRCSDK2.VRC_Pickup>();
                        Pickup3 = obj.GetComponent<VRC.SDK3.Components.VRCPickup>();
                        if (!HasTriedWithPickup1)
                        {
                            if (Pickup1 == null)
                            {
                                ModConsole.DebugLog("PickupController : Attempting to add  VRC.SDKBase.VRC_Pickup to object " + obj.name);
                                Pickup1 = obj.AddComponent<VRC.SDKBase.VRC_Pickup>();
                                if (Pickup1 == null)
                                {
                                    ModConsole.DebugLog("PickupController : Failed to add  VRC.SDKBase.VRC_Pickup to object " + obj.name);
                                    HasTriedWithPickup1 = true;
                                }
                                else
                                {
                                    ModConsole.DebugLog("PickupController : Added VRC.SDKBase.VRC_Pickup to object " + obj.name);
                                    if(Pickup1.ExactGrip == null)
                                    {
                                        Pickup1.ExactGrip = obj.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDKBase.VRC_Pickup ExactGrip to object transform " + obj.name);
                                    }
                                    if (Pickup1.ExactGun == null)
                                    {
                                        Pickup1.ExactGun = obj.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDKBase.VRC_Pickup ExactGun to object transform " + obj.name);
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
                                ModConsole.DebugLog("PickupController : Attempting to add  VRCSDK2.VRC_Pickup to object " + obj.name);
                                Pickup2 = obj.AddComponent<VRCSDK2.VRC_Pickup>();
                                if (Pickup2 == null)
                                {
                                    ModConsole.DebugLog("PickupController : Failed to add  VRCSDK2.VRC_Pickup to object " + obj.name);
                                    HasTriedWithPickup2 = true;
                                }
                                else
                                {
                                    ModConsole.DebugLog("PickupController : Added VRCSDK2.VRC_Pickup to object " + obj.name);
                                    if (Pickup2.ExactGrip == null)
                                    {
                                        Pickup2.ExactGrip = obj.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRCSDK2.VRC_Pickup ExactGrip to object transform " + obj.name);
                                    }
                                    if (Pickup2.ExactGun == null)
                                    {
                                        Pickup2.ExactGun = obj.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRCSDK2.VRC_Pickup ExactGun to object transform " + obj.name);
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
                                ModConsole.DebugLog("PickupController : Attempting to add  VRC.SDK3.Components.VRCPickup to object " + obj.name);
                                Pickup3 = obj.AddComponent<VRC.SDK3.Components.VRCPickup>();
                                if (Pickup3 == null)
                                {
                                    ModConsole.DebugLog("PickupController : Failed to add  VRC.SDK3.Components.VRCPickup to object " + obj.name);
                                    HasTriedWithPickup3 = true;
                                }
                                else
                                {
                                    ModConsole.DebugLog("PickupController : Added VRC.SDK3.Components.VRCPickup to object " + obj.name);
                                    if (Pickup3.ExactGrip == null)
                                    {
                                        Pickup3.ExactGrip = obj.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDK3.Components.VRCPickup ExactGrip to object transform " + obj.name);
                                    }
                                    if (Pickup3.ExactGun == null)
                                    {
                                        Pickup3.ExactGun = obj.transform;
                                        ModConsole.DebugLog("PickupController : Linked VRC.SDK3.Components.VRCPickup ExactGun to object transform " + obj.name);
                                    }

                                    hasRequiredComponentBeenAdded = true;
                                    HasTriedWithPickup3 = true;
                                }
                            }
                            return;
                        }
                        if (!hasRequiredComponentBeenAdded && HasTriedWithPickup1 && HasTriedWithPickup2 && HasTriedWithPickup3)
                        {
                            ModConsole.DebugWarning("Failed to add A Pickup Component to the object : " + obj.name);
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
                        if (Pickup1.AutoHold != AutoHold)
                        {
                            Pickup1.AutoHold = AutoHold;
                        }
                        if (Pickup1.orientation != orientation)
                        {
                            Pickup1.orientation = orientation;
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
                        if (Pickup2.AutoHold != AutoHold)
                        {
                            Pickup2.AutoHold = AutoHold;
                        }
                        if (Pickup2.orientation != orientation)
                        {
                            Pickup2.orientation = orientation;
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
                        if (Pickup3.AutoHold != AutoHold)
                        {
                            Pickup3.AutoHold = AutoHold;
                        }
                        if (Pickup3.orientation != orientation)
                        {
                            Pickup3.orientation = orientation;
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
                        if (AutoHold != Pickup1.AutoHold)
                        {
                            if (!EditMode)
                            {
                                AutoHold = Pickup1.AutoHold;
                            }
                        }
                        if (orientation != Pickup1.orientation)
                        {
                            if (!EditMode)
                            {
                                orientation = Pickup1.orientation;
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
                        if (AutoHold != Pickup2.AutoHold)
                        {
                            if (!EditMode)
                            {
                                AutoHold = Pickup2.AutoHold;
                            }
                        }
                        if (orientation != Pickup2.orientation)
                        {
                            if (!EditMode)
                            {
                                orientation = Pickup2.orientation;
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
                        if (AutoHold != Pickup3.AutoHold)
                        {
                            if (!EditMode)
                            {
                                AutoHold = Pickup3.AutoHold;
                            }
                        }
                        if (orientation != Pickup3.orientation)
                        {
                            if (!EditMode)
                            {
                                orientation = Pickup3.orientation;
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
                ModConsole.DebugError("Error in PickupController Bound to : " + obj.name);
                ModConsole.DebugErrorExc(e);
            }
        }

        private void OnDestroy()
        {
            ModConsole.DebugLog("PickupController Got Destroyed from " + obj.name);
        }

        [HideFromIl2Cpp]
        private void UpdatePickupOwnerBtns()
        {
            if (Tweaker_Object.CurrentSelectedObject == obj)
            {
                if (Pickup_CurrentObjOwner != null)
                {
                    Pickup_CurrentObjOwner.setButtonText(CurrentOwnerBtnText);
                }

                if (Main_CurrentObjOwner != null)
                {
                    Main_CurrentObjOwner.setButtonText(CurrentOwnerBtnText);
                }
                if (Forces_SelPickup_CurrentObjOwner != null)
                {
                    Forces_SelPickup_CurrentObjOwner.setButtonText(CurrentOwnerBtnText);
                }
                if (SelPickup_CurrentObjOwner != null)
                {
                    SelPickup_CurrentObjOwner.setButtonText(CurrentOwnerBtnText);
                }
                if (SelWorld_CurrentObjOwner != null)
                {
                    SelWorld_CurrentObjOwner.setButtonText(CurrentOwnerBtnText);
                }
            }
        }

        [HideFromIl2Cpp]
        internal string CurrentOwner
        {
            [HideFromIl2Cpp]
            get
            {
                return Networking.GetOwner(obj).displayName;
            }
        }

        [HideFromIl2Cpp]
        public string CurrentOwnerBtnText
        {
            [HideFromIl2Cpp]
            get
            {
                return "Current owner : \n" + CurrentOwner;
            }
        }

        [HideFromIl2Cpp]
        private void UpdatePickupOrientationBtn()
        {
            if (obj != null)
            {
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    if (Pickup_PickupOrientation_prop_any != null)
                    {
                        if (orientation == VRC_Pickup.PickupOrientation.Any)
                        {
                            Pickup_PickupOrientation_prop_any.setTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_PickupOrientation_prop_any.setTextColor(Color.red);
                        }
                    }
                    if (Pickup_PickupOrientation_prop_Grip != null)
                    {
                        if (orientation == VRC_Pickup.PickupOrientation.Grip)
                        {
                            Pickup_PickupOrientation_prop_Grip.setTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_PickupOrientation_prop_Grip.setTextColor(Color.red);
                        }
                    }
                    if (Pickup_PickupOrientation_prop_Gun != null)
                    {
                        if (orientation == VRC_Pickup.PickupOrientation.Gun)
                        {
                            Pickup_PickupOrientation_prop_Gun.setTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_PickupOrientation_prop_Gun.setTextColor(Color.red);
                        }
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateAutoHold()
        {
            if (obj != null)
            {
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    if (Pickup_AutoHoldMode_prop_AutoDetect != null)
                    {
                        if (AutoHold == VRC_Pickup.AutoHoldMode.AutoDetect)
                        {
                            Pickup_AutoHoldMode_prop_AutoDetect.setTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_AutoHoldMode_prop_AutoDetect.setTextColor(Color.red);
                        }
                    }
                    if (Pickup_AutoHoldMode_prop_Yes != null)
                    {
                        if (AutoHold == VRC_Pickup.AutoHoldMode.Yes)
                        {
                            Pickup_AutoHoldMode_prop_Yes.setTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_AutoHoldMode_prop_Yes.setTextColor(Color.red);
                        }
                    }
                    if (Pickup_AutoHoldMode_prop_No != null)
                    {
                        if (AutoHold == VRC_Pickup.AutoHoldMode.No)
                        {
                            Pickup_AutoHoldMode_prop_No.setTextColor(Color.green);
                        }
                        else
                        {
                            Pickup_AutoHoldMode_prop_No.setTextColor(Color.red);
                        }
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateAutoHoldMode()
        {
            if (obj != null)
            {
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    if (Pickup_allowManipulationWhenEquipped != null)
                    {
                        Pickup_allowManipulationWhenEquipped.setToggleState(allowManipulationWhenEquipped);
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        private void Updatepickupable()
        {
            if (obj != null)
            {
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    if (Pickup_pickupable != null)
                    {
                        Pickup_pickupable.setToggleState(pickupable);
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateDisallowTheft()
        {
            if (obj != null)
            {
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    if (Pickup_DisallowTheft != null)
                    {
                        Pickup_DisallowTheft.setToggleState(DisallowTheft);
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateProximitySlider()
        {
            if (obj != null)
            {
                if (Tweaker_Object.CurrentSelectedObject == obj)
                {
                    if (PickupProximitySlider != null)
                    {
                        PickupProximitySlider.SetValue(proximity);
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateIsHeld()
        {
            if (Tweaker_Object.CurrentSelectedObject == obj)
            {
                if (Pickup_IsHeld != null)
                {
                    Pickup_IsHeld.setButtonText(PickupHeldButtonText);
                    Pickup_IsHeld.setTextColor(PickupHeldButtonColor);
                }
                if (Forces_Pickup_IsHeld != null)
                {
                    Forces_Pickup_IsHeld.setButtonText(PickupHeldButtonText);
                    Forces_Pickup_IsHeld.setTextColor(PickupHeldButtonColor);
                }
                if (SelPickup_IsHeld != null)
                {
                    SelPickup_IsHeld.setButtonText(PickupHeldButtonText);
                    SelPickup_IsHeld.setTextColor(PickupHeldButtonColor);
                }
                if (SelWorld_IsHeld != null)
                {
                    SelWorld_IsHeld.setButtonText(PickupHeldButtonText);
                    SelWorld_IsHeld.setTextColor(PickupHeldButtonColor);
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateHeldOwnerBtn()
        {
            if (Tweaker_Object.CurrentSelectedObject == obj)
            {
                if (Forces_CurrentObjHolder != null)
                {
                    Forces_CurrentObjHolder.setButtonText(PickupHolderBtnText);
                }
                if (SelPickup_CurrentObjHolder != null)
                {
                    SelPickup_CurrentObjHolder.setButtonText(PickupHolderBtnText);
                }
                if (Main_CurrentObjHolder != null)
                {
                    Main_CurrentObjHolder.setButtonText(PickupHolderBtnText);
                }
                if (Pickup_CurrentObjHolder != null)
                {
                    Pickup_CurrentObjHolder.setButtonText(PickupHolderBtnText);
                }
                if (SelWorld_CurrentObjHolder != null)
                {
                    SelWorld_CurrentObjHolder.setButtonText(PickupHolderBtnText);
                }
            }
        }

        [HideFromIl2Cpp]
        internal bool isHeld
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
        private string CurrentObjectHolder
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
                        var user = Pickup3.currentPlayer;
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

        [HideFromIl2Cpp]
        private string PickupHeldButtonText
        {
            [HideFromIl2Cpp]
            get
            {
                if (isHeld)
                {
                    return "Held : Yes";
                }
                else
                {
                    return "Held : No";
                }
            }
        }

        [HideFromIl2Cpp]
        private string PickupHolderBtnText
        {
            [HideFromIl2Cpp]
            get
            {
                return "Current holder: \n " + CurrentObjectHolder;
            }
        }

        [HideFromIl2Cpp]
        private Color PickupHeldButtonColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (isHeld)
                {
                    return Color.green;
                }
                else
                {
                    return Color.red;
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateEditMode()
        {
            if (Tweaker_Object.CurrentSelectedObject == obj)
            {
                if (EditMode)
                {
                    Pickup_IsEditMode.setButtonText("Edit Mode : ON");
                    Pickup_IsEditMode.setTextColor(Color.green);
                }
                else
                {
                    Pickup_IsEditMode.setButtonText("Edit Mode : OFF");
                    Pickup_IsEditMode.setTextColor(Color.red);
                }
            }
        }

        [HideFromIl2Cpp]
        private void UpdateHasPickupComponent()
        {
            if (Tweaker_Object.CurrentSelectedObject == obj)
            {
                if (Pickup1 != null)
                {
                    HasPickupComponent.setTextColor(Color.green);
                    return;
                }
                else if (Pickup2 != null)
                {
                    HasPickupComponent.setTextColor(Color.green);
                    return;
                }
                else if (Pickup3 != null)
                {
                    HasPickupComponent.setTextColor(Color.green);
                    return;
                }
                else
                {

                    HasPickupComponent.setTextColor(Color.red);
                }
            }
        }


        private VRC.SDKBase.VRC_Pickup Pickup1;
        private VRCSDK2.VRC_Pickup Pickup2;
        private VRC.SDK3.Components.VRCPickup Pickup3;
        private GameObject obj = null;

        private bool HasTriedWithPickup1 = false;
        private bool HasTriedWithPickup2 = false;
        private bool HasTriedWithPickup3 = false;
        private bool HasAddedRigidBodyController = false;

        private bool hasRequiredComponentBeenAdded = false;

        private bool Original_allowManipulationWhenEquipped;
        private bool Original_pickupable;
        private bool Original_DisallowTheft;
        private float Original_Proximity;

        internal bool EditMode = false;
        internal VRC.SDKBase.VRC_Pickup.AutoHoldMode Original_AutoHold;
        internal VRC.SDKBase.VRC_Pickup.PickupOrientation Original_orientation;
        private protected bool Locked = false;
        internal bool ForceComponent = false;

        internal bool allowManipulationWhenEquipped;
        internal bool pickupable;
        internal bool DisallowTheft;
        internal float proximity;
        internal VRC.SDKBase.VRC_Pickup.AutoHoldMode AutoHold;
        internal VRC.SDKBase.VRC_Pickup.PickupOrientation orientation;
    }
}