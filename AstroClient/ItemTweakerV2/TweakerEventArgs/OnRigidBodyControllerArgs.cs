namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnRigidBodyControllerArgs : EventArgs
    {
        internal RigidBodyController RigidBodyController;

        internal OnRigidBodyControllerArgs(RigidBodyController RigidBodyController)
        {
            this.RigidBodyController = RigidBodyController;
        }
    }
}