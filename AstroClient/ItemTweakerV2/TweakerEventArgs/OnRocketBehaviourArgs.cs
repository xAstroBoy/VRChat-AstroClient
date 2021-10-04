namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnRocketBehaviourArgs : EventArgs
    {
        internal RocketBehaviour RocketBehaviour;

        internal OnRocketBehaviourArgs(RocketBehaviour RocketBehaviour)
        {
            this.RocketBehaviour = RocketBehaviour;
        }
    }
}