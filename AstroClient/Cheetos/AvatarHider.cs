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

        public override void OnAvatarSpawn(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
            if (VRCAvatarManager == null || Avatar == null) throw new ArgumentNullException();
            if (HideAvatar)
            {
                var self = Utils.LocalPlayer.GetPlayer();
                var owner = Avatar.transform.root.GetComponent<Player>();

                if (self.UserID().Equals(owner.UserID()))
                {
                    DestroyAvatar(Avatar);
                    ModConsole.DebugLog("Your avatar was hidden.");
                }
            }
        }
    }
}