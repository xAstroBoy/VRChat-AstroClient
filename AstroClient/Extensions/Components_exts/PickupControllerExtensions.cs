namespace AstroLibrary.Extensions
{
    using AstroClient.Components;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.SDKBase;

    public static class PickupControllerExtensions
    {
        public static void Pickup_Set_DisallowTheft(this PickupController instance, bool DisallowTheft)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.DisallowTheft = DisallowTheft;
            }
        }

        public static void Pickup_Set_proximity(this PickupController instance, float proximity)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.proximity = proximity;
            }
        }

        public static void Pickup_Set_ForceComponent(this PickupController instance, bool ForceComponent = true)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.Force_Pickup_Component = ForceComponent;
            }
        }

        public static void Pickup_Set_AutoHoldMode(this PickupController instance, VRC_Pickup.AutoHoldMode AutoHoldMode)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.AutoHold = AutoHoldMode;
            }
        }

        public static void Pickup_Set_PickupOrientation(this PickupController instance, VRC_Pickup.PickupOrientation PickupOrientation)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.orientation = PickupOrientation;
            }
        }

        public static void Pickup_Set_Pickupable(this PickupController instance, bool pickupable)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.pickupable = pickupable;
            }
        }

        public static void Pickup_Set_allowManipulationWhenEquipped(this PickupController instance, bool allowManipulationWhenEquipped)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.allowManipulationWhenEquipped = allowManipulationWhenEquipped;
            }
        }

        public static void Pickup_RestoreProperties(this PickupController instance)
        {
            if (instance != null)
            {
                instance.RestoreProperties();
            }
        }

        public static bool Pickup_Get_isHeld(this PickupController instance)
        {
            if (instance != null)
            {
                return instance.IsHeld;
            }
            return false;
        }

        public static VRCPlayerApi Pickup_Get_HeldByUser(this PickupController instance)
        {
            if (instance != null)
            {
                return instance.currentPlayer;
            }
            return null;
        }

        public static void Pickup_Set_DisallowTheft(this GameObject obj, bool DisallowTheft)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_DisallowTheft(DisallowTheft);
        }

        public static void Pickup_Set_proximity(this GameObject obj, float proximity)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_proximity(proximity);
        }

        public static void Pickup_Set_ForceComponent(this GameObject obj, bool ForceComponent = true)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_ForceComponent(ForceComponent);
        }

        public static void Pickup_Set_AutoHoldMode(this GameObject obj, VRC_Pickup.AutoHoldMode AutoHoldMode)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_AutoHoldMode(AutoHoldMode);
        }

        public static void Pickup_Set_PickupOrientation(this GameObject obj, VRC_Pickup.PickupOrientation PickupOrientation)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_PickupOrientation(PickupOrientation);
        }

        public static void Pickup_Set_Pickupable(this GameObject obj, bool pickupable)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_Pickupable(pickupable);
        }

        public static void Pickup_Set_allowManipulationWhenEquipped(this GameObject obj, bool allowManipulationWhenEquipped)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_allowManipulationWhenEquipped(allowManipulationWhenEquipped);
        }

        public static void Pickup_RestoreOriginalProperties(this GameObject obj)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_RestoreProperties();
        }

        public static bool Pickup_Get_isHeld(this GameObject obj)
        {
            return obj.GetOrAddComponent<PickupController>().IsHeld;
        }

        public static VRCPlayerApi Pickup_Get_HeldByUser(this GameObject obj)
        {
            return obj.GetOrAddComponent<PickupController>().currentPlayer;
        }

        public static void Pickup_Set_DisallowTheft(this List<GameObject> items, bool DisallowTheft)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_DisallowTheft(DisallowTheft);
                }
            }
        }

        public static void Pickup_Set_proximity(this List<GameObject> items, float proximity)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_proximity(proximity);
                }
            }
        }

        public static void Pickup_Set_ForceComponent(this List<GameObject> items, bool ForceComponent = true)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_ForceComponent(ForceComponent);
                }
            }
        }

        public static void Pickup_Set_AutoHoldMode(this List<GameObject> items, VRC_Pickup.AutoHoldMode AutoHoldMode)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_AutoHoldMode(AutoHoldMode);
                }
            }
        }

        public static void Pickup_Set_PickupOrientation(this List<GameObject> items, VRC_Pickup.PickupOrientation PickupOrientation)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_PickupOrientation(PickupOrientation);
                }
            }
        }

        public static void Pickup_Set_Pickupable(this List<GameObject> items, bool pickupable)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_Pickupable(pickupable);
                }
            }
        }

        public static void Pickup_Set_allowManipulationWhenEquipped(this List<GameObject> items, bool allowManipulationWhenEquipped)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_allowManipulationWhenEquipped(allowManipulationWhenEquipped);
                }
            }
        }

        public static void Pickup_RestoreOriginalProperties(this List<GameObject> items)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_RestoreProperties();
                }
            }
        }

        public static string Get_IsHeld_ButtonText(this PickupController controller)
        {
            if (controller != null)
            {
                return controller.IsHeld ? "Held : Yes" : "Held : No";
            }
            return "No Pickup Property Found";
        }

        public static Color Get_IsHeld_ButtonColor(this PickupController controller)
        {
            if (controller != null)
            {
                return controller.IsHeld ? Color.green : Color.red;
            }
            return Color.red;
        }

        public static string Get_IsHeldBy_ButtonText(this PickupController controller)
        {
            if (controller.currentPlayer != null)
            {
                return "Held By " + controller.CurrentHolderDisplayName;
            }
            return "Not Held";
        }

        public static string Get_PickupOwner_ButtonText(this PickupController controller)
        {
            return "Current owner : \n" + controller.CurrentOwner;
        }

        public static void Pickup_Set_ThrowVelocityBoostScale(this PickupController instance, float ThrowVelocityBoostScale)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }
                instance.ThrowVelocityBoostScale = ThrowVelocityBoostScale;
            }
        }
    }
}