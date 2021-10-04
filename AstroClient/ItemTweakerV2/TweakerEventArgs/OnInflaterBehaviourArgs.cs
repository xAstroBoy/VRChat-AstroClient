namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnInflaterBehaviourArgs : EventArgs
    {
        internal InflaterBehaviour InflaterBehaviour;

        internal OnInflaterBehaviourArgs(InflaterBehaviour InflaterBehaviour)
        {
            this.InflaterBehaviour = InflaterBehaviour;
        }
    }
}