namespace AstroClient.ClientUI.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using AstroMonos.Components.Tools;

    internal class OnPickupControllerArgs : EventArgs
    {
        internal PickupController PickupController;

        internal OnPickupControllerArgs(PickupController PickupController)
        {
            this.PickupController = PickupController;
        }
    }
}