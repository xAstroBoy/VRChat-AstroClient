namespace AstroClient.AvatarMods
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using AstroClient.AstroExtensions;
	using AstroExtensions;
	using DayClientML2.Utility.Extensions;
	using AstroClient.Finder;
	using VRC;

	public static class AvatarUtils
	{

		public static Transform GetAvatarGameObject(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar");
		}


		public static Transform GetAvatarArmature(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar/Armature");
		}

		public static Transform GetAvatarBody(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar/Body");
		}

		public static List<Transform> AvatarChilds(Transform avatar, Transform Armature, Transform Body)
		{
			List<Transform> AllChilds = new List<Transform>();
			foreach (var item in avatar.GetComponentsInChildren<Transform>(true))
			{
				if (item == Armature || item.IsChildOf(Armature) || item == avatar || item == Body)
				{
					continue;
				}

				if (!AllChilds.Contains(item))
				{
					AllChilds.Add(item);
				}
			}
			return AllChilds;
		}

		public static void ReloadAllAvatars()
		{
			if (VRCPlayer.field_Internal_Static_VRCPlayer_0 == null)
			{
				return;
			}
			foreach (var player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
			{
				if (player != null && player.GetVRCPlayer() != null)
				{
					ReloadAvatar(player.GetVRCPlayer());
				}
			}
		}

		public static void ReloadAvatar(VRCPlayer player)
		{
			if (VRCPlayer.field_Internal_Static_VRCPlayer_0 != null && player != null)
			{
				player.Method_Public_Void_Boolean_0();
			}
		}

	}
}
