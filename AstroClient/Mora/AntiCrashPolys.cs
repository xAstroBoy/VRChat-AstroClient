namespace AstroClient.AntiCrash
{
	using AstroClient.Cheetos;
	using AstroLibrary;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using UnhollowerBaseLib;
	using UnityEngine;
	using VRC;
	using VRCSDK2;
	using static AstroClient.Mora.anticrashwrappers;

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
            //new QMSingleButton("ShortcutMenu", 5, -0.5f, "check\nblacklist", delegate () { ModConsole.Log($"{shader_list_local}"); }, "checks the shader list.", null, null, true);
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
                        CheetosHelpers.SendHudNotification($"[!!!] nuked shaders for \"" + user.prop_APIUser_0.displayName.ToString() + "\"");
                    }
                    result = flag5;
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