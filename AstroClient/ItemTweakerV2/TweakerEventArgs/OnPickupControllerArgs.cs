﻿namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnPickupControllerArgs : EventArgs
    {
        internal PickupController control;

        internal OnPickupControllerArgs(PickupController controller)
        {
            this.control = controller;
        }
    }
}