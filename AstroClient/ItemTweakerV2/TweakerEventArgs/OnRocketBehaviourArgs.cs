namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using AstroMonos.Components.Custom.Random;

    internal class OnRocketBehaviourArgs : EventArgs
    {
        internal RocketBehaviour RocketBehaviour;

        internal OnRocketBehaviourArgs(RocketBehaviour RocketBehaviour)
        {
            this.RocketBehaviour = RocketBehaviour;
        }
    }
}