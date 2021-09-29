namespace AstroClientCore.Events
{
    using System;
    using UnityEngine;

    internal class OnAvatarSpawnArgs : EventArgs
    {
        internal VRCAvatarManager VRCAvatarManager;
        internal GameObject Avatar;

        internal OnAvatarSpawnArgs(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
            this.VRCAvatarManager = VRCAvatarManager;
            this.Avatar = Avatar;
        }
    }
}