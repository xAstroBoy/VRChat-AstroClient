using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.components;
using AstroClient.ConsoleUtils;
using System;
using UnityEngine;
using VRC_Pickup = VRC.SDKBase.VRC_Pickup;

namespace AstroClient
{
    public class Pickup
    {

        public static void RestoreOriginalProperty(GameObject obj)
        {
            if (obj != null)
            {
                var pickupEditor = obj.GetComponent<PickupController>();
                if (pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.RestoreOriginalProperties();
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }
        public static void ForcePickupComponentPresence(GameObject obj)
        {
            if (obj != null)
            {
                var pickup1 = obj.GetComponent<VRC.SDKBase.VRC_Pickup>();
                var pickup2 = obj.GetComponent<VRCSDK2.VRC_Pickup>();
                var pickup3 = obj.GetComponent<VRC.SDK3.Components.VRCPickup>();
                if (pickup1 != null || pickup2 != null || pickup3 != null)
                {
                    return;
                }
                else
                {
                    var pickupEditor = obj.GetComponent<PickupController>();
                    if (pickupEditor == null)
                    {
                        pickupEditor = obj.AddComponent<PickupController>();
                    }
                    if (!pickupEditor.ForceComponent)
                    {
                        pickupEditor.ForceComponent = true;
                        ModConsole.Log("Added Pickup Component to " + obj.name);
                    }
                }
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }

        public static void SetPickupOrientation(GameObject obj, VRC_Pickup.PickupOrientation orientation)
        {
            if (obj != null)
            {
                var pickupEditor = obj.GetComponent<PickupController>();
                if(pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.EditMode = true;
                pickupEditor.orientation = orientation;
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);

            }
        }

        public static void SetAutoHoldMode(GameObject obj, VRC_Pickup.AutoHoldMode holdmode)
        {
            if (obj != null)
            {
                var pickupEditor = obj.GetComponent<PickupController>();
                if (pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.EditMode = true;
                pickupEditor.AutoHold = holdmode;
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }

        public static void SetDisallowTheft(GameObject obj, bool DisallowTheft = false)
        {
            if (obj != null)
            {

                var pickupEditor = obj.GetComponent<PickupController>();
                if (pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.EditMode = true;
                pickupEditor.DisallowTheft = DisallowTheft;
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }

        public static void SetPickupable(GameObject obj, bool pickupable)
        {
            if (obj != null)
            {
                var pickupEditor = obj.GetComponent<PickupController>();
                if (pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.EditMode = true;
                pickupEditor.pickupable = pickupable;
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }

        public static void SetallowManipulationWhenEquipped(GameObject obj, bool allowManipulationWhenEquipped)
        {
            if (obj != null)
            {
                var pickupEditor = obj.GetComponent<PickupController>();
                if (pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.EditMode = true;
                pickupEditor.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }

        internal static void SetProximity(GameObject obj, int value)
        {
            if (obj != null)
            {
                var pickupEditor = obj.GetComponent<PickupController>();
                if (pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.EditMode = true;
                pickupEditor.proximity = value;
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }

        internal static void SetProximity(GameObject obj, float value)
        {
            if (obj != null)
            {
                var pickupEditor = obj.GetComponent<PickupController>();
                if (pickupEditor == null)
                {
                    pickupEditor = obj.AddComponent<PickupController>();
                }
                pickupEditor.EditMode = true;
                pickupEditor.proximity = value;
                ItemTweakerMain.CheckIfContainsPickupProperties(obj);
            }
        }


    }
}