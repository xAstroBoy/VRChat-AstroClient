﻿namespace AstroClientCore.Events
{
    using System;
    using UnityEngine;

    internal class OnAvatarSpawnArgs : EventArgs
    {
        public VRCAvatarManager VRCAvatarManager;
        public GameObject Avatar;

        public OnAvatarSpawnArgs(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
            this.VRCAvatarManager = VRCAvatarManager;
            this.Avatar = Avatar;
        }
    }
}