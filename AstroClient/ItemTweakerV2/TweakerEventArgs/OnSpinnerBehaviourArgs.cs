namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnSpinnerBehaviourArgs : EventArgs
    {
        internal SpinnerBehaviour SpinnerBehaviour;

        internal OnSpinnerBehaviourArgs(SpinnerBehaviour SpinnerBehaviour)
        {
            this.SpinnerBehaviour = SpinnerBehaviour;
        }
    }
}