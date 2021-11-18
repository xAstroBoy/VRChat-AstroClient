﻿namespace AstroClient.Cheetos
{
    #region Imports

    using System;
    using Tools.Extensions;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class AvatarHider : AstroEvents
    {
        internal static bool HideAvatar = false;

        internal static void DestroyAvatar(GameObject avatar)
        {
            avatar.transform.root.Find("ForwardDirection/Avatar").gameObject.DestroyMeLocal();
        }

        internal override void OnAvatarSpawn(Player Player, GameObject Avatar, VRCAvatarManager VRCAvatarManager,
            VRC_AvatarDescriptor VRC_AvatarDescriptor)
        {
            if (VRCAvatarManager == null || Avatar == null) throw new ArgumentNullException();
            if (HideAvatar && Player.GetAPIUser().IsSelf)
            {
                DestroyAvatar(Avatar);
                ModConsole.DebugLog("Your avatar was hidden.");
            }
        }
    }
}