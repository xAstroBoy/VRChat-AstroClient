namespace AstroClient
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Components;
	using UnityEngine;
	using VRC_Pickup = VRC.SDKBase.VRC_Pickup;

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
				var pickupEditor = obj.GetComponent<PickupController>();
				if (pickupEditor == null)
				{
					pickupEditor = obj.AddComponent<PickupController>();
				}
				if (!pickupEditor.ForceComponent)
				{
					pickupEditor.ForceComponent = true;
				}
				ItemTweakerMain.CheckIfContainsPickupProperties(obj);
			}
		}

		public static void SetPickupOrientation(GameObject obj, VRC_Pickup.PickupOrientation orientation)
		{
			if (obj != null)
			{
				var pickupEditor = obj.GetComponent<PickupController>();
				if (pickupEditor == null)
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