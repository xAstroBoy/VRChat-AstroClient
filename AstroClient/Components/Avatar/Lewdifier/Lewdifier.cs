﻿namespace AstroClient.Components
{
    using AstroClient.AvatarMods;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;

    [RegisterComponent]
    public class Lewdifier : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public Lewdifier(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode)
            {
                if (player != null)
                {
                    ModConsole.DebugLog($"[Lewdifier Debug] [{player.DisplayName()}] : {msg}");
                }
                else
                {
                    ModConsole.DebugLog($"[Lewdifier Debug] : {msg}");
                }
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
                if (PlayerTag == null)
                {
                    PlayerTag = SingleTagsUtils.AddSingleTag(player);
                    if (PlayerTag != null)
                    {
                        PlayerTag.ShowTag = false;
                    }
                }
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
                        Avatar = null;
                        AvatarAnimator = null;
                        Armature = null;
                        Body = null;
                        ChildsToKeepOff.Clear();
                        ChildsTokeepOn.Clear();
                        PlayerTag.ShowTag = false;
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
                                        AvatarID = apiavatar.id;
                                        Lewdify_Avatar();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal void Lewdify_Avatar()
        {
            if (!LewdifierUtils.AvatarsToSkip.Contains(AvatarID))
            {
                if (AvatarRoot == null)
                {
                    AvatarRoot = this.transform.root;
                }
                if (AvatarRoot != null)
                {
                    Avatar = AvatarRoot.Get_Avatar();
                    Armature = AvatarRoot.Get_Armature();
                    Body = AvatarRoot.Get_Body();
                    AvatarAnimator = Avatar.GetComponentInChildren<Animator>();
                    PlayerTag.ShowTag = false;

                    var avi_parents = Avatar.Get_Childs();
                    if (avi_parents.Count() != 0)
                    {
                        bool hasTurnedOffChilds = Lewdify_Terms_To_turn_Off(avi_parents);
                        bool hasTurnedOnChilds = Lewdify_Terms_To_turn_On(avi_parents);
                        if (hasTurnedOffChilds && !hasTurnedOnChilds)
                        {
                            if (PlayerTag != null)
                            {
                                PlayerTag.Label_Text = "Possibly NSFW";
                                PlayerTag.Tag_Color = ColorUtils.HexToColor("#FFA500");
                                PlayerTag.ShowTag = true;
                            }
                        }
                        else if (!hasTurnedOffChilds && hasTurnedOnChilds)
                        {
                            if (PlayerTag != null)
                            {
                                PlayerTag.Label_Text = "Possibly NSFW";
                                PlayerTag.Tag_Color = ColorUtils.HexToColor("#FFA500");
                                PlayerTag.ShowTag = true;
                            }
                        }
                        else if (!hasTurnedOffChilds && !hasTurnedOnChilds)
                        {
                            if (PlayerTag != null)
                            {
                                PlayerTag.Label_Text = "NOT NSFW";
                                PlayerTag.Tag_Color = Color.blue;
                                PlayerTag.ShowTag = true;
                            }
                        }
                        else if (hasTurnedOffChilds && hasTurnedOnChilds)
                        {
                            if (PlayerTag != null)
                            {
                                PlayerTag.Label_Text = "NSFW";
                                PlayerTag.Tag_Color = Color.red;
                                PlayerTag.ShowTag = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (PlayerTag != null)
                {
                    PlayerTag.Label_Text = "Skipped Lewdify";
                    PlayerTag.Tag_Color = Color.cyan;
                    PlayerTag.ShowTag = true;
                }
            }
        }

        private bool Lewdify_Terms_To_turn_Off(List<Transform> avataritems)
        {
            bool FoundaHit = false;
            if (avataritems.Count() != 0)
            {
                for (int i = 0; i < avataritems.Count; i++)
                {
                    Transform parent = avataritems[i];
                    if (CheckForTermsToToggleOff(parent))
                    {
                        FoundaHit = true;
                    }
                    if (parent != null)
                    {
                        List<Transform> list = parent.Get_All_Childs();
                        for (int i1 = 0; i1 < list.Count; i1++)
                        {
                            Transform child = list[i1];
                            if (CheckForTermsToToggleOff(child))
                            {
                                FoundaHit = true;
                            }
                        }
                    }
                }
            }
            return FoundaHit;
        }

        private bool CheckForTermsToToggleOff(Transform item)
        {
            bool FoundaHit = false;
            if (item.gameObject.GetComponentsInChildren<Renderer>(true).Count() != 0)
            {
                Debug($"Checking {item.name} in TermsToToggleOff");
                if (LewdifierUtils.TermsToToggleOff.Contains(item.name.ToLower()))
                {
                    Debug($"{item.name} Found in TermsToToggleOff");

                    FoundaHit = true;

                    if (item.gameObject.active)
                    {
                        item.gameObject.SetActiveRecursively(false);
                    }
                    if (!ChildsToKeepOff.Contains(item))
                    {
                        ChildsToKeepOff.Add(item);
                    }
                }
            }
            return FoundaHit;
        }

        private bool Lewdify_Terms_To_turn_On(List<Transform> avataritems)
        {
            bool FoundaHit = false;
            if (avataritems.Count() != 0)
            {
                for (int i = 0; i < avataritems.Count; i++)
                {
                    Transform parent = avataritems[i];
                    if (CheckForTermsToToggleOn(parent))
                    {
                        FoundaHit = true;
                    }

                    List<Transform> list = parent.Get_All_Childs();
                    for (int i1 = 0; i1 < list.Count; i1++)
                    {
                        Transform child = list[i1];
                        if (CheckForTermsToToggleOn(child))
                        {
                            FoundaHit = true;
                        }
                    }
                }
            }
            return FoundaHit;
        }

        private bool CheckForTermsToToggleOn(Transform item)
        {
            bool flag = false;
            if (item.gameObject.GetComponentsInChildren<Renderer>(true).Count() != 0)
            {
                Debug($"Checking {item.name} in TermsToToggleOn");

                if (LewdifierUtils.TermsToToggleOn.Contains(item.name.ToLower()))
                {
                    flag = true;

                    Debug($"{item.name} Found in TermsToToggleOn");

                    var parent = item.Get_root_of_avatar_child();
                    ModConsole.DebugLog($"Got root of  {item.name} , Root is : {parent.name}");

                    if (parent != null)
                    {
                        ModConsole.DebugLog($"Enabling Parent.. {parent.name}...");

                        if (!parent.gameObject.active)
                        {
                            parent.gameObject.active = true;
                        }
                        if (!item.gameObject.active)
                        {
                            item.gameObject.SetActiveRecursively(true);
                        }
                    }
                }
            }
            return flag;
        }

        // TODO: Figure how to Edit the animator to Be able to toggle the Objects with animator active.
        //public void Update()
        //{
        //}

        public void LateUpdate()
        {
            if (PlayerTag == null)
            {
                PlayerTag = player.AddSingleTag();
            }
            if (AvatarModifier.ForceLewdify)
            {
                try
                {
                    if (ChildsToKeepOff.Count() != 0)
                    {
                        for (int i = 0; i < ChildsToKeepOff.Count; i++)
                        {
                            Transform child = ChildsToKeepOff[i];
                            if (child != null && child.gameObject.active)
                            {
                                _ = ChildsToKeepOff.Remove(child);
                                child.DestroyMeLocal();
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public void OnDestroy()
        {
            ChildsTokeepOn.Clear();
            ChildsToKeepOff.Clear();
            Destroy(PlayerTag);
            player.ReloadAvatar();
            Destroy(this);
        }

        internal Transform AvatarRoot;
        internal Transform Avatar;
        internal Transform Armature;
        internal Transform Body;
        internal SingleTag PlayerTag;
        internal Player player;
        internal Animator AvatarAnimator;
        internal string AvatarID;
        internal List<Transform> ChildsToKeepOff = new List<Transform>();
        internal List<Transform> ChildsTokeepOn = new List<Transform>();
    }
}