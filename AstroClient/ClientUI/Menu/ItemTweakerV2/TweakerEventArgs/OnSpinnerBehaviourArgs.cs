namespace AstroClient.ClientUI.Menu.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using AstroMonos.Components.Custom.Random;

    internal class OnSpinnerBehaviourArgs : EventArgs
    {
        internal SpinnerBehaviour SpinnerBehaviour;

        internal OnSpinnerBehaviourArgs(SpinnerBehaviour SpinnerBehaviour)
        {
            this.SpinnerBehaviour = SpinnerBehaviour;
        }
    }
}