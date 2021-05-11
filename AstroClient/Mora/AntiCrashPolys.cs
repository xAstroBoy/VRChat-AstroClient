namespace AstroClient.AntiCrash
{
	using AstroClient.ConsoleUtils;
	using UnityEngine;
	using MelonLoader;
	using System;
	using System.Collections.Generic;
	using UnhollowerBaseLib;
	using VRC;
	using VRCSDK2;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Net.Cache;
	using System.Net.Security;
	using System.Security.Cryptography.X509Certificates;
	using VRC.Core;
	using VRC.UI;
	using AstroClient.Cheetos;
	using static AstroClient.Mora.anticrashwrappers;
	using AstroClient.Mora;
	using RubyButtonAPI;

	internal class AntiCrashPolys : GameEvents
	{
		public static Dictionary<string, avatar_data> anti_crash_list = new Dictionary<string, avatar_data>();

		public static string[] shader_list;

		public static List<string> shader_list_local = new List<string>();

		public struct avatar_data
		{
			public string asseturl;

			public int polys;
		}
		public override void VRChat_OnUiManagerInit()
		{
			#if DEBUG
			new QMSingleButton("ShortcutMenu", 5, -0.5f, "check\nblacklist", delegate () { MelonLogger.Log($"{shader_list_local}"); }, "checks the shader list.", null, null, true);
            #endif
		}
			public static void set_pickups(bool state)
		{
			foreach (VRC_Pickup vrc_Pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>())
			{
				if (!(vrc_Pickup == null) && !vrc_Pickup.name.Contains("ViewFinder"))
				{
					vrc_Pickup.gameObject.SetActive(state);
				}
			}
		}

		public static bool shader_check(Player user)
		{
			Il2CppArrayBase<Renderer> componentsInChildren = user.prop_VRCPlayer_0.prop_VRCAvatarManager_0.GetComponentsInChildren<Renderer>(true);
			Shader shader = Shader.Find("Standard");
			bool result = false;
			for (int i = 0; i < componentsInChildren.Count; i++)
			{
				Renderer renderer = componentsInChildren[i];
				if (!(renderer == null))
				{
					for (int j = 0; j < renderer.materials.Count; j++)
					{
						Material material = renderer.materials[j];
						if (anticrashWrapper.is_known(material.shader.name))
						{
							material.shader = shader;
							result = true;
						}
					}
				}
			}
			return result;
		}

		public static bool Work_hk(Player user, int polys)
		{
			bool result;
			try
			{
				if (shader_list.Length == 0)
				{
					shader_list = anticrashWrapper.get_shader_blacklist();
				}
				if (user == null)
				{
					result = false;
				}
				else
				{
					bool flag5 = false;
					flag5 = shader_check(user);
					if (flag5)
					{
						CheetosHelpers.SendHudNotification($"[!!!] nuked shaders for \"" + user.field_Private_APIUser_0.displayName.ToString() + "\"");
					}
					if (flag5)
					{
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
        public static QMSingleButton CheckBlackList;
	}
}
