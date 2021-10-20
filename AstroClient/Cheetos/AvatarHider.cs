namespace AstroClient.Cheetos
{
    #region Imports

    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    #endregion Imports

    internal class AvatarHider : GameEvents
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
            if (HideAvatar && Utils.LocalPlayer.GetPlayer().GetUserID().Equals(Avatar.transform.root.GetComponent<Player>().GetUserID()))
            {
                DestroyAvatar(Avatar);
                ModConsole.DebugLog("Your avatar was hidden.");
            }
        }
    }
}