namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using AstroMonos.Components.Custom.Random;

    internal class OnInflaterBehaviourArgs : EventArgs
    {
        internal InflaterBehaviour InflaterBehaviour;

        internal OnInflaterBehaviourArgs(InflaterBehaviour InflaterBehaviour)
        {
            this.InflaterBehaviour = InflaterBehaviour;
        }
    }
}