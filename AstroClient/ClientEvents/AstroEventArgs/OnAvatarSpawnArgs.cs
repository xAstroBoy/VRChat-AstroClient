namespace AstroClient.AstroEventArgs
{
    using System;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    internal class OnAvatarSpawnArgs : EventArgs
    {
        internal Player Player { get; set; }
        internal GameObject Avatar { get; set; }
        internal VRCAvatarManager VRCAvatarManager { get; set; }
        internal VRC_AvatarDescriptor VRC_AvatarDescriptor { get; set; }

        internal OnAvatarSpawnArgs(Player Player, GameObject Avatar, VRCAvatarManager VRCAvatarManager, VRC_AvatarDescriptor VRC_AvatarDescriptor)
        {
            this.Player = Player;
            this.Avatar = Avatar;
            this.VRCAvatarManager = VRCAvatarManager;
            this.VRC_AvatarDescriptor = VRC_AvatarDescriptor;
        }
    }
}