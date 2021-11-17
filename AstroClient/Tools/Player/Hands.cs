namespace AstroClient.Tools.Player
{
    using UnityEngine;
    using xAstroBoy.Utility;

    internal static class PlayerHands
    {
        internal static void DropObject(GameObject obj)
        {
            if (GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
            {
                var lefthand = GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
                var righthand = GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
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

        internal static GameObject GetHoldTransform()
        {
            if (GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
            {
                var lefthand = GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
                var righthand = GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
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

        internal static GameObject GetLeftHoldObject()
        {
            if (GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
            {
                var lefthand = GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
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

        internal static GameObject GetRightHoldObject()
        {
            if (GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi() != null)
            {
                var RightHand = GameInstances.LocalPlayer.GetPlayer().GetVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
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