namespace AstroLibrary.Extensions
{
    using AstroClient;
    using System.Collections.Generic;
    using UnityEngine;

    internal static class Position_ext
    {
        internal static void TeleportToTarget(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj, TargetSelector.CurrentTarget, HumanBodyBones.LeftHand, true);
                }
            }
        }

        internal static void TeleportToMe(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj);
                }
            }
        }

        internal static void TeleportToTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, TargetSelector.CurrentTarget, HumanBodyBones.LeftHand, true);
            }
        }

        internal static void TeleportToMe(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj);
            }
        }

        internal static void TeleportToMe(this GameObject obj, bool ResetRigidBody = false, bool ResetPickupProperties = false)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, ResetRigidBody, ResetPickupProperties);
            }
        }



        internal static void TeleportToMe(this GameObject obj, HumanBodyBones bone)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, bone);
            }
        }
    }
}