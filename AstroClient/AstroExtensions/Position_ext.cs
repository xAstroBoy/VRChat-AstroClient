namespace AstroClient.Extensions
{
	using System.Collections.Generic;
	using UnityEngine;

	public static class Position_ext
    {
        public static void TeleportToTarget(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj, ObjectMiscOptions.CurrentTarget, HumanBodyBones.LeftHand, true);
                }
            }
        }

        public static void TeleportToMe(this List<GameObject> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    ItemPosition.TeleportObject(obj);
                }
            }
        }

        public static void TeleportToTarget(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, ObjectMiscOptions.CurrentTarget, HumanBodyBones.LeftHand, true);
            }
        }

        public static void TeleportToMe(this GameObject obj)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj);
            }
        }

        public static void TeleportToMe(this GameObject obj, HumanBodyBones bone)
        {
            if (obj != null)
            {
                ItemPosition.TeleportObject(obj, bone);
            }
        }
    }
}