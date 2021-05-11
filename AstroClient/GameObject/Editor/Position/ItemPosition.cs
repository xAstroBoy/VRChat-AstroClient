namespace AstroClient
{
	using AstroClient.components;
	using AstroClient.extensions;
	using AstroClient.variables;
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
				var physic = obj.GetComponent<Rigidbody>();
				obj.transform.position = GetPlayerBoneTransform(HumanBodyBones.RightHand).position;

				obj.KillCustomScripts(true);
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
					obj.KillCustomScripts(true);
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
					obj.KillCustomScripts(true);
				}

				obj.transform.position = LocalPlayerUtils.PlayerPositionBones(player, targetbone);
				OnlineEditor.RemoveOwnerShip(obj);
			}
		}


	}
}