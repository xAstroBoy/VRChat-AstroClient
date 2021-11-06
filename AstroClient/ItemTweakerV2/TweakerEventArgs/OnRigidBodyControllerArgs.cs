namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using AstroMonos.Components.Tools;

    internal class OnRigidBodyControllerArgs : EventArgs
    {
        internal RigidBodyController RigidBodyController;

        internal OnRigidBodyControllerArgs(RigidBodyController RigidBodyController)
        {
            this.RigidBodyController = RigidBodyController;
        }
    }
}