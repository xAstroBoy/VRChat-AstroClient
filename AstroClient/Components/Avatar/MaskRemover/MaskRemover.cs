namespace AstroClient.Components
{
	using AstroClient.AvatarMods;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using System;
	using System.Linq;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC;
	using VRC.SDKBase;

	public class MaskRemover : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public MaskRemover(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = false;

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[MaskRemover Debug] : {msg}");
            }
        }

        // Use this for initialization
        public void Start()
        {
            if (player == null)
            {
                player = GetComponent<Player>();
            }
            if (player != null)
            {
                player.ReloadAvatar();
            }
        }

        public override void OnAvatarSpawn(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
            if (Avatar != null && VRCAvatarManager.prop_VRC_AvatarDescriptor_0 != null)
            {
                var AvatarPlayer = Avatar.transform.root.GetComponentInChildren<Player>();
                if (AvatarPlayer != null)
                {
                    if (AvatarPlayer == player) // Checks if this assigned player is the same.
                    {
                        if (AvatarRoot == null)
                        {
                            AvatarRoot = Avatar.transform.root;
                        }
                        avatar = null;
                        AvatarAnimator = null;
                        Armature = null;
                        Body = null;
                        var manager = AvatarPlayer._vrcplayer.prop_VRCAvatarManager_0;
                        if (manager != null)
                        {
                            if (manager.prop_VRCAvatarDescriptor_0 != null && manager.prop_VRC_AvatarDescriptor_0 != null)
                            {
                                var apiavatar = manager.field_Private_ApiAvatar_1;
                                if (apiavatar != null)
                                {
                                    if (!string.IsNullOrEmpty(apiavatar.assetUrl) && !string.IsNullOrEmpty(apiavatar.id))
                                    {
                                        AvatarRoot = Avatar.transform.root;
                                        if (AvatarRoot != null)
                                        {
                                            avatar = AvatarRoot.Get_Avatar();
                                            Armature = AvatarRoot.Get_Armature();
                                            Body = AvatarRoot.Get_Body();
                                            AvatarAnimator = avatar.GetComponentInChildren<Animator>();
                                            var childs = avatar.Get_All_Childs();
                                            if (childs.Count() != 0)
                                            {
                                                foreach (var item in childs)
                                                {
                                                    if (item.gameObject.GetComponent<Renderer>())
                                                    {
                                                        if (item.name.ToLower().Equals("mask") || item.name.ToLower().Equals("facemask"))
                                                        {
                                                            item.DestroyMeLocal();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        foreach (var itemchilds in item.Get_All_Childs())
                                                        {
                                                            if (itemchilds.gameObject.GetComponent<Renderer>())
                                                            {
                                                                if (itemchilds.name.ToLower().Equals("mask") || itemchilds.name.ToLower().Equals("facemask"))
                                                                {
                                                                    itemchilds.DestroyMeLocal();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void OnDestroy()
        {
            player.ReloadAvatar();
        }

        private Transform AvatarRoot = null;
        private Transform avatar = null;
        private Transform Armature = null;
        private Transform Body = null;
        private Player player = null;
        private Animator AvatarAnimator = null;
    }
}