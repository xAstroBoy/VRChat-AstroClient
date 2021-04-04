﻿using UnityEngine;

#region AstroClient Imports

using static AstroClient.LocalPlayerUtils;

#endregion AstroClient Imports

namespace AstroClient
{
    public static class PlayerHands 
    {


        public static void DropObject(GameObject obj)
        {
            if (GetSelfVRCPlayerApi() != null)
            {
                var lefthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
                var righthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
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
            if (GetSelfVRCPlayerApi() != null)
            {
                var lefthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
                var righthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
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
            if (GetSelfVRCPlayerApi() != null)
            {
                var lefthand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Left);
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
            if (GetSelfVRCPlayerApi() != null)
            {
                var RightHand = GetSelfVRCPlayerApi().GetPickupInHand(VRC.SDKBase.VRC_Pickup.PickupHand.Right);
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