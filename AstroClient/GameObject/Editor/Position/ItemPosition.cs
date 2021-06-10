namespace AstroClient
{
	using AstroLibrary.Extensions;
	using UnityEngine;
	using VRC;

	public class ItemPosition
	{
		public static void TeleportObject(GameObject obj)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				obj.transform.position = Utils.LocalPlayer.GetPlayer().Get_Player_Bone_Position(HumanBodyBones.RightHand);
				obj.KillCustomComponents(true);
				obj.KillForces(true);
			}
		}

		public static void TeleportObject(GameObject obj, HumanBodyBones SelfBones)
		{
			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);
				obj.transform.position = Utils.LocalPlayer.GetPlayer().Get_Player_Bone_Position(SelfBones);
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

				obj.transform.position = player.Get_Player_Bone_Position(targetbone);
				OnlineEditor.RemoveOwnerShip(obj);
			}
		}
	}
}