using AstroClient.components;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.extensions
{
    public static class PickupExtensions
    {
        public static void SetPickupTheft(this List<GameObject> list, bool DisallowTheft = false)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    Pickup.SetDisallowTheft(obj, DisallowTheft);
                }
            }
        }

        public static void SetPickupTheft(this GameObject obj, bool DisallowTheft = false)
        {
            Pickup.SetDisallowTheft(obj, DisallowTheft);
        }

        public static void PreventOthersFromPicking(this GameObject obj, bool PreventOthersFromGrabbing)
        {
            if (obj != null)
            {
                var control = obj.GetComponent<RigidBodyController>();
                if (control == null)
                {
                    control = obj.AddComponent<RigidBodyController>();
                }
                if (control != null)
                {
                    if (!control.EditMode)
                    {
                        control.EditMode = true;
                    }
                    control.PreventOthersFromGrabbing = PreventOthersFromGrabbing;
                }
            }
        }

        public static void SetPickupOrientation(this GameObject obj, VRC_Pickup.PickupOrientation orientation)
        {
            if (obj != null)
            {
                Pickup.SetPickupOrientation(obj, orientation);
            }
        }

        public static void SetAutoHoldMode(this GameObject obj, VRC_Pickup.AutoHoldMode holdmode)
        {
            if (obj != null)
            {
                Pickup.SetAutoHoldMode(obj, holdmode);
            }
        }

        public static void SetDisallowTheft(this GameObject obj, bool DisallowTheft)
        {
            if (obj != null)
            {
                Pickup.SetDisallowTheft(obj, DisallowTheft);
            }
        }

        public static void SetPickupable(this GameObject obj, bool pickupable)
        {
            if (obj != null)
            {
                Pickup.SetPickupable(obj, pickupable);
            }
        }

        public static void SetallowManipulationWhenEquipped(this GameObject obj, bool allowManipulationWhenEquipped)
        {
            if (obj != null)
            {
                Pickup.SetallowManipulationWhenEquipped(obj, allowManipulationWhenEquipped);
            }
        }
    }
}