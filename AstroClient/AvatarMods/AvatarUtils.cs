namespace AstroClient.AvatarMods
{
	using AstroClient.Finder;
	using AstroLibrary.Console;
	using DayClientML2.Utility.Extensions;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using Color = System.Drawing.Color;

	public static class AvatarUtils
	{
		public static Transform Get_Avatar(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar");
		}

		public static Transform Get_Armature(this Transform obj)
		{
			return obj.FindObject("ForwardDirection/Avatar/Armature");
		}

		public static Transform Get_Body(this Transform obj)
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

		public static void Avatar_Renderer_Dumper(this Player player)
		{
			if (player != null)
			{
				var body = player.gameObject.transform.Get_Body();
				var Avatar = player.gameObject.transform.Get_Avatar();
				var Armature = player.gameObject.transform.Get_Armature();
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

		public static void Avatar_Transform_Dumper(this Player player)
		{
			if (player != null)
			{
				var body = player.gameObject.transform.Get_Body();
				var Avatar = player.gameObject.transform.Get_Avatar();
				var Armature = player.gameObject.transform.Get_Armature();
				if (body != null && Avatar != null && Armature != null)
				{
					ModConsole.Log("[AVATAR TRANSFORM DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
					var dumpednames = new List<string>();
					var parents = AvatarParents(Avatar, Armature, body);
					if (parents.Count() != 0)
					{
						ModConsole.Log("[AVATAR TRANSFORM DUMPER] : Dumping All Transforms of " + player.GetAPIUser().displayName + " Avatar...", Color.Green);
						ModConsole.Log("Dumping Transforms names ...", Color.Green);
						foreach (var child in parents)
						{
							foreach (var item in Dump_Transforms(child))
							{
								ModConsole.Log("Found Transform [ " + item + " ] in " + player.DisplayName() + "'s avatar", Color.Yellow);
							}
						}
					}
					else
					{
						ModConsole.Log("[AVATAR TRANSFORM DUMPER] : No Materials Found.", Color.Green);
					}
				}
			}
		}

		public static void Avatar_Material_Dumper(this Player player)
		{
			if (player != null)
			{
				var body = player.gameObject.transform.Get_Body();
				var Avatar = player.gameObject.transform.Get_Avatar();
				var Armature = player.gameObject.transform.Get_Armature();
				if (body != null && Avatar != null && Armature != null)
				{
					ModConsole.Log("[AVATAR MATERIAL DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
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
							ModConsole.Log("Found Material [ " + item + " ] in " + player.DisplayName() + "'s avatar Body", Color.Yellow);
						}
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

		public static List<string> Dump_Transforms(this Transform item)
		{
			var dumpednames = new List<string>();
			if (item != null)
			{
				var childs = item.GetComponentsInChildren<Transform>(true);
				if (childs == null)
				{
					return dumpednames;
				}
				if (childs.Count() == 0)
				{
					return dumpednames;
				}
				foreach (var obj in childs)
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

		public static void Reload_All_Avatars()
		{
			foreach (var player in WorldUtils.Get_Players())
			{
				if (player != null && player.GetVRCPlayer() != null)
				{
					Reload_Avatars(player.GetVRCPlayer());
				}
			}
		}

		public static void Reload_Avatars(VRCPlayer player)
		{
			if (player != null)
			{
				player.Method_Public_Void_Boolean_0();
			}
		}
	}
}