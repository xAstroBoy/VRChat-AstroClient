namespace AstroClient
{
	using AstroClient.Extensions;
	using UnityEngine;
	using VRC;
	using static AstroClient.LocalPlayerUtils;

	public class ItemPosition
	{
		public static void TeleportObject(GameObject obj)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				obj.transform.position = GetPlayerBoneTransform(HumanBodyBones.RightHand).position;
				obj.KillCustomComponents(true);
				obj.KillForces(true);
			}
		}

		public static void TeleportObject(GameObject obj, Vector3 NewPos, bool SkipKillScripts = false)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				if (SkipKillScripts)
				{
					obj.KillCustomComponents(true);
				}
				obj.transform.position = NewPos;
			}
		}

		public static void TeleportObject(GameObject obj, Player player, HumanBodyBones targetbone, bool SkipKillScripts = false)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				if (SkipKillScripts)
				{
					obj.KillCustomComponents(true);
				}

				obj.transform.position = PlayerPositionBones(player, targetbone);
				OnlineEditor.RemoveOwnerShip(obj);
			}
		}


	}
}