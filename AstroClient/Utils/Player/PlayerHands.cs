namespace AstroClient
{
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using UnityEngine;

	public static class PlayerHands
	{
		public static void DropObject(GameObject obj)
		{
			if (Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
			{
				var lefthand = Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
				var righthand = Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
				if (lefthand != null)
				{
					if (lefthand.gameObject == obj)
					{
						lefthand.Drop();
					}
				}
				if (righthand != null)
				{
					if (righthand.gameObject == obj)
					{
						righthand.Drop();
					}
				}
			}
		}

		public static GameObject GetHoldTransform()
		{
			if (Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
			{
				var lefthand = Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
				var righthand = Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
				if (righthand != null)
				{
					if (righthand.gameObject != null)
					{
						return righthand.gameObject;
					}
				}
				else if (lefthand != null)
				{
					if (lefthand.gameObject != null)
					{
						return lefthand.gameObject;
					}
				}
			}
			return null;
		}

		public static GameObject GetLeftHoldObject()
		{
			if (Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
			{
				var lefthand = Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
				if (lefthand != null)
				{
					if (lefthand.gameObject != null)
					{
						return lefthand.gameObject;
					}
				}
			}
			return null;
		}

		public static GameObject GetRightHoldObject()
		{
			if (Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
			{
				var RightHand = Utils.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
				if (RightHand != null)
				{
					if (RightHand.gameObject != null)
					{
						return RightHand.gameObject;
					}
				}
			}
			return null;
		}
	}
}