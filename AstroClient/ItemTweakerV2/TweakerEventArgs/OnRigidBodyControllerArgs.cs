namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnRigidBodyControllerArgs : EventArgs
    {
        internal RigidBodyController control;

        internal OnRigidBodyControllerArgs(RigidBodyController controller)
        {
            this.control = controller;
        }
    }
}