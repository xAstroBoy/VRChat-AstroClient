﻿namespace AstroClient.AvatarMods
{
	using Extensions;
	using AstroLibrary.Console;
	using DayClientML2.Utility.Extensions;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using Color = System.Drawing.Color;
	using DayClientML2.Utility;
	using AstroLibrary.Finder;

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

		public static Transform Get_root_of_avatar_child(this Transform obj)
		{
			var root = obj.root;
			if(root != null)
			{
				var avatar = root.Get_Avatar();
				if(avatar != null)
				{
					foreach(var child in avatar.Get_Childs())
					{
						if(obj.IsChildOf(child))
						{
							return child;
						}	
					}
				}
			}
			return null;
		}


		public static List<Transform> AvatarParents(Transform avatar, Transform Armature, Transform Body)
		{
			List<Transform> AllChilds = new List<Transform>();
			foreach (var item in avatar.Get_Childs())
			{
				if (item != null)
				{

					// Some avatars don't have armature apparently , Probably renamed. 
					// TODO: MAKE A ARMATURE FINDER TO BE 100% accurate of what to skip.
					if (Armature != null)
					{
						if (item == Armature)
						{
							continue;
						}

						if (item.IsChildOf(Armature))
						{
							continue;
						}
					}
					// As well for "body" , as is renamed.
					if(Body != null)
					{
						if(item == Body)
						{
							continue;
						}
					}
					if(item == avatar)
					{
						continue;
					}

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

					var parents = AvatarParents(Avatar, Armature, body);
					if (parents.Count() != 0)
					{
						ModConsole.Log("[AVATAR RENDERER DUMPER] : Dumping All Renderers of " + player.GetAPIUser().displayName + " Avatar...", Color.Green);
						ModConsole.Log("[AVATAR RENDERER DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
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
						ModConsole.Log("[AVATAR RENDERER DUMPER] : No Renderers Found.", Color.Green);
					}
				}
			
		}

		public static void Avatar_MeshRenderer_Dumper(this Player player)
		{
			if (player != null)
			{
				var body = player.gameObject.transform.Get_Body();
				var Avatar = player.gameObject.transform.Get_Avatar();
				var Armature = player.gameObject.transform.Get_Armature();

					var parents = AvatarParents(Avatar, Armature, body);
					if (parents.Count() != 0)
					{
						ModConsole.Log("[AVATAR MESHRENDERER DUMPER] : Dumping All Renderers of " + player.GetAPIUser().displayName + " Avatar...", Color.Green);
						ModConsole.Log("[AVATAR MESHRENDERER DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
						ModConsole.Log("Dumping Mesh Renderers names ...", Color.Green);
						foreach (var item in parents)
						{
							foreach (var name in Dump_Renderers(item))
							{
								ModConsole.Log("Found Mesh Renderer [ " + name + " ] in " + player.DisplayName() + "'s avatar", Color.Yellow);
							}
						}
					}
					else
					{
						ModConsole.Log("[AVATAR MESHRENDERER DUMPER] : No Renderers Found.", Color.Green);
					}
				
			}
		}


		public static void Lewdify(this List<Transform> list, out bool HasTurnedOffChilds, out bool HasTurnedOnLewdChilds)
		{
			HasTurnedOffChilds = Lewdifier.LewdifyTermsToTurnOff(list);
			HasTurnedOnLewdChilds = Lewdifier.LewdifyTermsToToggleOn(list);
		}


		public static void RemoveLewdNSFWTags(Player player)
		{
			foreach (var tag in player.SearchTags("Possibly NSFW"))
			{
				if (tag != null)
				{
					tag.DestroyMeLocal();
				}
			}
			foreach (var tag in player.SearchTags("NSFW Avatar"))
			{
				if (tag != null)
				{
					tag.DestroyMeLocal();
				}
			}
		}


		public static void Lewdify(this Player player)
		{
			if (player != null)
			{
				RemoveLewdNSFWTags(player);
				var body = player.gameObject.transform.Get_Body();
				var Avatar = player.gameObject.transform.Get_Avatar();
				var Armature = player.gameObject.transform.Get_Armature();
				var parents = AvatarParents(Avatar, Armature, body);
				if (parents.Count() != 0)
				{
					parents.Lewdify(out var OffChilds, out var OnChilds);
					if (OffChilds && !OnChilds)
					{
						if (!player.HasTagWithText("Possibly NSFW"))
						{
							var tag = player.AddSingleTag();
							MiscUtility.DelayFunction(0.5f, () =>
						{
							if (tag != null)
							{
								tag.Label_Text = "Possibly NSFW";
								tag.Tag_Color = ColorUtils.HexToColor("#FFA500");
								tag.Label_TextColor = UnityEngine.Color.white;
							}
						});
						}
					}
					else if (!OffChilds && OnChilds)
					{
						if (!player.HasTagWithText("Possibly NSFW"))
						{
							var tag = player.AddSingleTag();
							MiscUtility.DelayFunction(0.5f, () =>
							{
								if (tag != null)
								{
									tag.Label_Text = "Possibly NSFW";
									tag.Tag_Color = ColorUtils.HexToColor("#FFA500");
									tag.Label_TextColor = UnityEngine.Color.white;
								}
							});
						}
					}
					else if (OnChilds && OffChilds)
					{
						if (!player.HasTagWithText("NSFW Avatar"))
						{
							var tag = player.AddSingleTag();
							MiscUtility.DelayFunction(0.5f, () =>
							{
								if (tag != null)
								{
									tag.Label_Text = "NSFW Avatar";
									tag.Tag_Color = UnityEngine.Color.red;
									tag.Label_TextColor = UnityEngine.Color.white;
								}
							});
						}
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

					var parents = AvatarParents(Avatar, Armature, body);
					if (parents.Count() != 0)
					{
						ModConsole.Log("[AVATAR TRANSFORM DUMPER] : Dumping All Transforms of " + player.GetAPIUser().displayName + " Avatar...", Color.Green);
						ModConsole.Log("[AVATAR TRANSFORM DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
						ModConsole.Log("Dumping Transforms names ...", Color.Green);
						foreach (var child in parents)
						{
							foreach (var item in Dump_Transforms(child))
							{
								ModConsole.Log("Found Transform [ " + item + " ] in " + player.DisplayName() + "'s avatar", Color.Yellow);
							}
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

					ModConsole.Log("[AVATAR MATERIAL DUMPER] : Dumping All Materials of " + player.GetAPIUser().displayName + " Avatar...", Color.Green);
					ModConsole.Log("[AVATAR MATERIAL DUMPER] : AVATAR ID : " + player.prop_ApiAvatar_0.id, Color.Green);
					ModConsole.Log("[AVATAR MATERIAL DUMPER] : Dumping Body Materials..", Color.Green);
					foreach (var item in Dump_Materials(body))
					{
						ModConsole.Log("Found Material [ " + item + " ] in " + player.DisplayName() + "'s avatar Body", Color.Yellow);
					}
					var parents = AvatarParents(Avatar, Armature, body);
					if (parents.Count() != 0)
					{
						ModConsole.Log("Dumping Materials names ...", Color.Green);
						foreach (var child in parents)
						{
							foreach (var item in Dump_Materials(child))
							{
								ModConsole.Log("Found Material [ " + item + " ] in " + player.DisplayName() + "'s avatar", Color.Yellow);
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
				if (TransformRenderers == null)
				{
					return dumpednames;
				}
				if (TransformRenderers.Count() == 0)
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
			}
			return dumpednames;
		}

		public static string GetAvatarID(this Player player)
		{
			if (player != null)
			{
				if(player._vrcplayer != null && player._vrcplayer.GetApiAvatar() != null)
				{
					return player._vrcplayer.GetApiAvatar().id;
				}
			}
			return null;
		}


		public static void BlackListAvatar_Lewdifier(this Player player)
		{
			if(player != null)
			{
				var avatarid = player.GetAvatarID();
				if(avatarid != null)
				{
					Lewdifier.AvatarsToSkip.Add(avatarid);
					Lewdifier.Save_AvatarToSkip();
					Lewdifier.Refresh_AvatarsToSkip();
				}
			}
		}

		public static List<string> Dump_Mesh_Renderers(this Transform item)
		{
			var dumpednames = new List<string>();
			if (item != null)
			{
				var TransformRenderers = item.GetComponentsInChildren<MeshRenderer>(true);
				if (TransformRenderers == null)
				{
					return dumpednames;
				}
				if (TransformRenderers.Count() == 0)
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
			}
			return dumpednames;
		}


		public static List<string> Dump_Materials(this Transform item)
		{
			var dumpednames = new List<string>();
			if (item != null)
			{
				var TransformRenderers = item.GetComponentsInChildren<Renderer>(true);

				if (TransformRenderers == null)
				{
					return dumpednames;
				}
				if (TransformRenderers.Count() == 0)
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