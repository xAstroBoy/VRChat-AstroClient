namespace AstroClient.Tools.Extensions.Components_exts
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal static class PickupControllerExtensions
    {
        internal static void Pickup_Set_DisallowTheft(this PickupController instance, bool DisallowTheft)
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

        internal static void Pickup_Set_AntiTheft(this PickupController instance, bool AntiTheft)
        {
            if (instance != null)
            {
                instance.AntiTheft = AntiTheft;
            }
        }

        internal static void Pickup_Set_proximity(this PickupController instance, float proximity)
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
        internal static bool Pickup_Get_ForceComponent(this PickupController instance)
        {
            if (instance != null)
            {
                return  instance.ForceComponent;
            }
            return false;
        }

        internal static void Pickup_Set_ForceComponent(this PickupController instance, bool ForceComponent = true)
        {
            if (instance != null)
            {
                if (!instance.EditMode)
                {
                    instance.EditMode = true;
                }

                instance.ForceComponent = ForceComponent;
            }
        }

        internal static void Pickup_Set_AutoHoldMode(this PickupController instance, VRC_Pickup.AutoHoldMode AutoHoldMode)
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

        internal static void Pickup_Set_PickupOrientation(this PickupController instance, VRC_Pickup.PickupOrientation PickupOrientation)
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

        internal static void Pickup_Set_Pickupable(this PickupController instance, bool pickupable)
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

        internal static void Pickup_Set_allowManipulationWhenEquipped(this PickupController instance, bool allowManipulationWhenEquipped)
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

        internal static void Pickup_RestoreProperties(this PickupController instance)
        {
            if (instance != null)
            {
                instance.RestoreProperties();
            }
        }

        internal static bool Pickup_Get_isHeld(this PickupController instance)
        {
            if (instance != null)
            {
                return instance.IsHeld;
            }

            return false;
        }

        internal static bool Pickup_Get_AntiTheft(this PickupController instance)
        {
            if (instance != null)
            {
                return instance.AntiTheft;
            }

            return false;
        }

        internal static VRCPlayerApi Pickup_Get_HeldByUser(this PickupController instance)
        {
            if (instance != null)
            {
                return instance.currentPlayer;
            }

            return null;
        }
        /// <summary>
        /// This won't add the pickupcontroller, but it checks if is present, if is , returns ForceComponent.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static bool Pickup_Get_ForceComponent(this GameObject obj)
        {
            if(obj != null)
            {
                var controller = obj.GetComponent<PickupController>();
                if(controller != null)
                {
                    return controller.ForceComponent;
                }
            }
            return false;
        }

        internal static void Pickup_Set_AntiTheft(this GameObject obj, bool AntiTheft)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_AntiTheft(AntiTheft);
        }
        internal static bool Pickup_Get_AntiTheft(this GameObject obj)
        {
            return obj.GetOrAddComponent<PickupController>().Pickup_Get_AntiTheft();
        }

        internal static void Pickup_Set_DisallowTheft(this GameObject obj, bool DisallowTheft)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_DisallowTheft(DisallowTheft);
        }

        internal static void Pickup_Set_proximity(this GameObject obj, float proximity)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_proximity(proximity);
        }

        internal static void Pickup_Set_ForceComponent(this GameObject obj, bool ForceComponent = true)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_ForceComponent(ForceComponent);
        }

        internal static void Pickup_Set_AutoHoldMode(this GameObject obj, VRC_Pickup.AutoHoldMode AutoHoldMode)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_AutoHoldMode(AutoHoldMode);
        }

        internal static void Pickup_Set_PickupOrientation(this GameObject obj, VRC_Pickup.PickupOrientation PickupOrientation)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_PickupOrientation(PickupOrientation);
        }

        internal static void Pickup_Set_Pickupable(this GameObject obj, bool pickupable)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_Pickupable(pickupable);
        }

        internal static void Pickup_Set_allowManipulationWhenEquipped(this GameObject obj, bool allowManipulationWhenEquipped)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_Set_allowManipulationWhenEquipped(allowManipulationWhenEquipped);
        }

        internal static void Pickup_RestoreOriginalProperties(this GameObject obj)
        {
            obj.GetOrAddComponent<PickupController>().Pickup_RestoreProperties();
        }

        internal static bool Pickup_Get_isHeld(this GameObject obj)
        {
            return obj.GetOrAddComponent<PickupController>().IsHeld;
        }

        internal static VRCPlayerApi Pickup_Get_HeldByUser(this GameObject obj)
        {
            return obj.GetOrAddComponent<PickupController>().currentPlayer;
        }

        internal static void Pickup_Set_DisallowTheft(this List<GameObject> items, bool DisallowTheft)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_DisallowTheft(DisallowTheft);
                }
            }
        }

        internal static void Pickup_Set_AntiTheft(this List<GameObject> items, bool AntiTheft)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_AntiTheft(AntiTheft);
                }
            }
        }

        internal static void Pickup_Set_proximity(this List<GameObject> items, float proximity)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_proximity(proximity);
                }
            }
        }

        internal static void Pickup_Set_ForceComponent(this List<GameObject> items, bool ForceComponent = true)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_ForceComponent(ForceComponent);
                }
            }
        }

        internal static void Pickup_Set_AutoHoldMode(this List<GameObject> items, VRC_Pickup.AutoHoldMode AutoHoldMode)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_AutoHoldMode(AutoHoldMode);
                }
            }
        }

        internal static void Pickup_Set_PickupOrientation(this List<GameObject> items, VRC_Pickup.PickupOrientation PickupOrientation)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_PickupOrientation(PickupOrientation);
                }
            }
        }

        internal static void Pickup_Set_Pickupable(this List<GameObject> items, bool pickupable)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_Pickupable(pickupable);
                }
            }
        }

        internal static void Pickup_Set_allowManipulationWhenEquipped(this List<GameObject> items, bool allowManipulationWhenEquipped)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_allowManipulationWhenEquipped(allowManipulationWhenEquipped);
                }
            }
        }

        internal static void Pickup_RestoreOriginalProperties(this List<GameObject> items)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_RestoreProperties();
                }
            }
        }


        internal static void Pickup_Set_ThrowVelocityBoostScale(this List<GameObject> items, float ThrowVelocityBoostScale)
        {
            foreach (var obj in items)
            {
                if (obj != null)
                {
                    obj.GetOrAddComponent<PickupController>().Pickup_Set_ThrowVelocityBoostScale(ThrowVelocityBoostScale);
                }
            }
        }

        internal static string Get_IsHeld_ButtonText(this PickupController controller)
        {
            if (controller != null)
            {
                return controller.IsHeld ? "Held : Yes" : "Held : No";
            }

            return "No Pickup Property Found";
        }

        internal static Color Get_IsHeld_ButtonColor(this PickupController controller)
        {
            if (controller != null)
            {
                return controller.IsHeld ? Color.green : Color.red;
            }

            return Color.red;
        }

        internal static string Get_IsHeldBy_ButtonText(this PickupController controller)
        {
            if (controller.currentPlayer != null)
            {
                return "Held By " + controller.CurrentHolderDisplayName;
            }

            return "Not Held";
        }

        internal static string Get_PickupOwner_ButtonText(this PickupController controller)
        {
            return "Current owner : \n" + controller.CurrentOwner;
        }

        internal static void Pickup_AllowOnlySelfToGrab(this PickupController control, bool AllowOnlySelfToGrab)
        {
            if (control != null)
            {
                if (!control.EditMode)
                {
                    control.EditMode = true;
                }

                control.AllowOnlySelfToGrab = AllowOnlySelfToGrab;
            }
        }

        internal static void Pickup_Set_ThrowVelocityBoostScale(this PickupController instance, float ThrowVelocityBoostScale)
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