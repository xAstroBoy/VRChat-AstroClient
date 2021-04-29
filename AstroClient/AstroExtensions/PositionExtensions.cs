namespace AstroClient.extensions
{
	using System.Collections.Generic;
	using UnityEngine;

	public static class PositionExtensions
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
	}
}