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

    public class AvatarHider : GameEvents
    {
        public static bool HideAvatar = false;

        public static void DestroyAvatar(GameObject avatar)
        {
            avatar.transform.root.Find("ForwardDirection/Avatar").gameObject.DestroyMeLocal();
        }

        public override void OnAvatarSpawn(VRCAvatarManager avatarManager, GameObject avatar)
        {
            if (avatarManager == null || avatar == null) throw new ArgumentNullException();
            if (HideAvatar)
            {
                var self = Utils.LocalPlayer.GetPlayer();
                var owner = avatar.transform.root.GetComponent<Player>();

                if (self.GetUserID().Equals(owner.GetUserID()))
                {
                    DestroyAvatar(avatar);
                    ModConsole.DebugLog("Your avatar was hidden.");
                }
            }
        }
    }
}