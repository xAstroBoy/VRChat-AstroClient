namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnPickupControllerArgs : EventArgs
    {
        internal PickupController PickupController;

        internal OnPickupControllerArgs(PickupController PickupController)
        {
            this.PickupController = PickupController;
        }
    }
}