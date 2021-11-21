namespace AstroClient.Tools.Player
{
    using System.Linq;
    using AstroMonos.Components.Tools;
    using Extensions;
    using Input;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRCSDK2;
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

        //internal static void SetPressedController()
        //{
        //    if (SteamVR_Controller != null)
        //    {
        //        input.Method_Private_Void_Boolean_PDM_0(true);
        //        input.Method_Public_Void_Boolean_0(true);
        //        input.Method_Public_Void_Boolean_1(true);
        //        input.Method_Private_Void_Boolean_PDM_1(true);
        //        input.Method_Public_Void_Boolean_2(true);
        //        input.Method_Private_Void_Boolean_PDM_2(true);
        //        input.Method_Private_Void_Boolean_PDM_3(true);
        //        input.Method_Public_Void_Boolean_3(true);
        //    }
        //}

        internal static void SetPickupInRightHand(VRC.SDKBase.VRC_Pickup pickup)
        {
            if (pickup != null)
            {
                if (RighthandGrasper != null)
                {
                    if (RighthandGrasper.Method_Public_VRC_Pickup_0() != null) return;
                    pickup.gameObject.TeleportToMeWithRot(HumanBodyBones.RightHand, false);
                }
            }
        }

        internal static void SetPickupLeftHand(VRC.SDKBase.VRC_Pickup pickup)
        {
            if (pickup != null)
            {
                if (LefthandGrasper != null)
                {
                    if (LefthandGrasper.Method_Public_VRC_Pickup_0() != null) return;
                    pickup.gameObject.TeleportToMeWithRot(HumanBodyBones.LeftHand, false);
                }
            }
        }

        private static VRCHandGrasper _RightHandGrasper;

        internal static VRCHandGrasper RighthandGrasper
        {
            get
            {
                if (_RightHandGrasper == null)
                {
                    if (GameInstances.LocalPlayer.GetPlayer() != null)
                    {
                        return GameInstances.LocalPlayer.GetPlayer().transform.Find("AnimationController/HeadAndHandIK/RightEffector").GetComponent<VRCHandGrasper>();
                    }
                }

                return _RightHandGrasper;
            }
        }


        private static VRCHandGrasper _LeftHandGrasper;

        internal static VRCHandGrasper LefthandGrasper
        {
            get
            {
                if (_RightHandGrasper == null)
                {
                    if (GameInstances.LocalPlayer.GetPlayer() != null)
                    {
                        return GameInstances.LocalPlayer.GetPlayer().transform.Find("AnimationController/HeadAndHandIK/LeftEffector").GetComponent<VRCHandGrasper>();
                    }
                }

                return _RightHandGrasper;
            }
        }

    }
}