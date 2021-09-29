﻿namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnRigidBodyControllerArgs : EventArgs
    {
        public RigidBodyController control;

        public OnRigidBodyControllerArgs(RigidBodyController controller)
        {
            this.control = controller;
        }
    }
}