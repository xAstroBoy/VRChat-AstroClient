namespace AstroClient.AntiCrash
{
    using AstroLibrary;
    using AstroLibrary.Utility;
    using AstroButtonAPI;
    using System;
    using System.Collections.Generic;
    using UnhollowerBaseLib;
    using UnityEngine;
    using VRC;
    using VRCSDK2;
    using static AstroClient.Mora.anticrashwrappers;

    internal class AntiCrashPolys : GameEvents
    {
        internal static Dictionary<string, avatar_data> anti_crash_list = new Dictionary<string, avatar_data>();

        internal static string[] shader_list;

        internal static List<string> shader_list_local = new List<string>();

        internal struct avatar_data
        {
            internal string asseturl;

            internal int polys;
        }

        internal override void VRChat_OnUiManagerInit()
        {
            //new QMSingleButton("ShortcutMenu", 5, -0.5f, "check\nblacklist", delegate () { ModConsole.Log($"{shader_list_local}"); }, "checks the shader list.", null, null, true);
        }

        internal static void Set_Pickups(bool state)
        {
            Il2CppArrayBase<VRC_Pickup> list = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
            for (int i = 0; i < list.Count; i++)
            {
                VRC_Pickup vrc_Pickup = list[i];
                if (!(vrc_Pickup == null) && !vrc_Pickup.name.Contains("ViewFinder"))
                {
                    vrc_Pickup.gameObject.SetActive(state);
                }
            }
        }

        internal static bool Shader_Check(Player user)
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

        internal static bool Work_hk(Player user, int polys)
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
                    flag5 = Shader_Check(user);
                    if (flag5)
                    {
                        PopupUtils.QueHudMessage($"[!!!] nuked shaders for \"" + user.prop_APIUser_0.displayName.ToString() + "\"");
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

        internal static QMSingleButton CheckBlackList;
    }
}