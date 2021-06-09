﻿namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
	using AstroClient.Components;
	using System;

	public class OnPickupControllerArgs : EventArgs
    {
        public PickupController control;

        public OnPickupControllerArgs(PickupController controller)
        {
            this.control = controller;
        }
    }
}