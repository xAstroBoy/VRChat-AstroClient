using AstroClient.ClientActions;

namespace AstroClient.Cheetos
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
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnAvatarSpawn += OnAvatarSpawn;
        }

        internal static bool HideAvatar = false;

        internal static void DestroyAvatar(GameObject avatar)
        {
            avatar.transform.root.Find("ForwardDirection/Avatar").gameObject.DestroyMeLocal();
        }

        private void OnAvatarSpawn(Player Player, GameObject Avatar, VRCAvatarManager VRCAvatarManager,
            VRC_AvatarDescriptor VRC_AvatarDescriptor)
        {
            if (VRCAvatarManager == null || Avatar == null) return;
            if (HideAvatar && Player.GetAPIUser().IsSelf)
            {
                DestroyAvatar(Avatar);
                Log.Debug("Your avatar was hidden.");
            }
        }
    }
}