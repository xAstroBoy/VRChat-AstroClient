﻿namespace AstroClient.Extensions
{
	using AstroClient.Components;
	using System.Collections.Generic;
	using UnityEngine;
	using VRC.SDKBase;

	public static class PickupController_ext
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
				instance.ForceComponent = ForceComponent;
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
				instance.AutoHoldMode = AutoHoldMode;
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
				instance.PickupOrientation = PickupOrientation;
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

		public static void Pickup_RestoreOriginalProperties(this PickupController instance)
		{
			if (instance != null)
			{
				instance.RestoreOriginalProperties();
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
				return instance.CurrentObjectHolderPlayer;
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
			obj.GetOrAddComponent<PickupController>().Pickup_RestoreOriginalProperties();
		}

		public static bool Pickup_Get_isHeld(this GameObject obj)
		{
			return obj.GetOrAddComponent<PickupController>().IsHeld;
		}

		public static VRCPlayerApi Pickup_Get_HeldByUser(this GameObject obj)
		{
			return obj.GetOrAddComponent<PickupController>().CurrentObjectHolderPlayer;
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
					obj.GetOrAddComponent<PickupController>().Pickup_RestoreOriginalProperties();
				}
			}
		}
	}
}