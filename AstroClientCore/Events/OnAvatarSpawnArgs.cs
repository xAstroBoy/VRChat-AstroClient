namespace AstroClientCore.Events
{
	using System;
	using UnityEngine;

	public class OnAvatarSpawnArgs : EventArgs
    {
        public GameObject Avatar;
        public VRC.SDKBase.VRC_AvatarDescriptor VRC_AvatarDescriptor;
        public bool state;

        public OnAvatarSpawnArgs(GameObject avatar, VRC.SDKBase.VRC_AvatarDescriptor VRC_AvatarDescriptor, bool state)
        {
            this.Avatar = avatar;
            this.VRC_AvatarDescriptor = VRC_AvatarDescriptor;
            this.state = state;
        }
    }
}