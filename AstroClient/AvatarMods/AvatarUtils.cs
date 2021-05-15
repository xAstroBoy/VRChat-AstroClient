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
	using AstroClient.ConsoleUtils;
	using Color = System.Drawing.Color;

	public static class AvatarUtils
	{

		public static Transform GetAvatar(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar");
		}


		public static Transform GetArmature(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar/Armature");
		}

		public static Transform GetBody(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar/Body");
		}

		public static List<Transform> AvatarParents(Transform avatar, Transform Armature, Transform Body)
		{
			List<Transform> AllChilds = new List<Transform>();
			foreach (var item in avatar.GetComponents<Transform>())
			{
				if (item == Armature || item == avatar || item == Body)
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
		public static void AvatarRendererDumper(this Player player)
		{
			if (player != null)
			{
				var body = player.gameObject.transform.GetBody();
				var Avatar = player.gameObject.transform.GetAvatar();
				var Armature = player.gameObject.transform.GetArmature();
				if (body != null && Avatar != null && Armature != null)
				{
					ModConsole.Log("[AVATAR RENDERER DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
					var parents = AvatarParents(Avatar, Armature, body);
					if (parents.Count() != 0)
					{
						ModConsole.Log("[AVATAR RENDERER DUMPER] : Dumping All Renderers of " + player.GetAPIUser().displayName + " Avatar...", Color.Green);
						ModConsole.Log("Dumping Renderers names ...", Color.Green);
						foreach (var item in parents)
						{
							foreach (var name in Dump_Renderers(item))
							{
								ModConsole.Log("Found Renderer [ " + name + " ] in " + player.DisplayName() + "'s avatar", Color.Yellow);
							}
						}
					}
					else
					{
						ModConsole.Log("[AVATAR RENDERER DUMPER] : No Materials Found.", Color.Green);

					}
				}
			}
		}


		public static List<string> Dump_Renderers(this Transform item)
		{
			var dumpednames = new List<string>();
			if (item != null)
			{
				var TransformRenderers = item.GetComponentsInChildren<Renderer>(true);
				var GameObjectRenderers = item.GetComponentsInChildren<Renderer>(true);
				if (GameObjectRenderers == null || TransformRenderers == null)
				{
					return dumpednames;
				}
				if (TransformRenderers.Count() == 0 || GameObjectRenderers.Count() == 0)
				{
					return dumpednames;
				}
				foreach (var obj in TransformRenderers)
				{
					if (obj != null)
					{
						if (!dumpednames.Contains(obj.name))
						{
							dumpednames.Add(obj.name);
						}
					}
				}
				foreach (var obj in GameObjectRenderers)
				{
					if (obj != null)
					{
						if (!dumpednames.Contains(obj.name))
						{
							dumpednames.Add(obj.name);
						}
					}
				}
			}
			return dumpednames;
		}


		public static List<string> Dump_Materials(this Transform item)
		{
			var dumpednames = new List<string>();
			if (item != null)
			{
				var TransformRenderers = item.GetComponentsInChildren<Renderer>(true);
				var GameObjectRenderers = item.GetComponentsInChildren<Renderer>(true);
				if (GameObjectRenderers == null || TransformRenderers == null)
				{
					return dumpednames;
				}
				if (TransformRenderers.Count() == 0 || GameObjectRenderers.Count() == 0)
				{
					return dumpednames;
				}
				foreach (var obj in TransformRenderers)
				{
					if (obj != null)
					{
						if (!dumpednames.Contains(obj.material.name))
						{
							dumpednames.Add(obj.material.name);
						}
					}
				}
				foreach (var obj in GameObjectRenderers)
				{
					if (obj != null)
					{
						if (!dumpednames.Contains(obj.material.name))
						{
							dumpednames.Add(obj.material.name);
						}
					}
				}
			}
			return dumpednames;
		}



		public static void AvatarMaterialDumper(this Player player)
		{
			if (player != null)
			{
				var body = player.gameObject.transform.GetBody();
				var Avatar = player.gameObject.transform.GetAvatar();
				var Armature = player.gameObject.transform.GetArmature();
				if (body != null && Avatar != null && Armature != null)
				{
					ModConsole.Log("[AVATAR MATERIAL DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
					var dumpednames = new List<string>();
					var parents = AvatarParents(Avatar, Armature, body);
					if (parents.Count() != 0)
					{
						ModConsole.Log("[AVATAR MATERIAL DUMPER] : Dumping All Materials of " + player.GetAPIUser().displayName + " Avatar...", Color.Green);
						ModConsole.Log("Dumping Materials names ...", Color.Green);
						foreach (var child in parents)
						{
							foreach (var item in Dump_Materials(child))
							{
								ModConsole.Log("Found Material [ " + item + " ] in " + player.DisplayName() + "'s avatar", Color.Yellow);
							}
						}
						foreach (var item in Dump_Materials(body))
						{
							ModConsole.Log("Found Material [ " + item + " ] in " + player.DisplayName() + "'s avatar", Color.Yellow);
						}
					}
					else
					{
						ModConsole.Log("[AVATAR MATERIAL DUMPER] : No Materials Found.", Color.Green);

					}
				}
			}
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
