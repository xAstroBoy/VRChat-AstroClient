namespace AstroClient.Cheetos
{
    #region Imports

    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
    using VRC;

    #endregion Imports

    internal class AvatarHider : GameEvents
    {
        internal static bool HideAvatar = false;

        internal static void DestroyAvatar(GameObject avatar)
        {
            avatar.transform.root.Find("ForwardDirection/Avatar").gameObject.DestroyMeLocal();
        }

        internal override void OnAvatarSpawn(VRCAvatarManager avatarManager, GameObject avatar)
        {
            if (avatarManager == null || avatar == null) throw new ArgumentNullException();
            if (HideAvatar && Utils.LocalPlayer.GetPlayer().GetUserID().Equals(avatar.transform.root.GetComponent<Player>().GetUserID()))
            {
                DestroyAvatar(avatar);
                ModConsole.DebugLog("Your avatar was hidden.");
            }
        }
    }
}