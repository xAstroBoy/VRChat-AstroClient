namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using AstroClient.Components;
    using System;

    internal class OnCrazyBehaviourArgs : EventArgs
    {
        internal CrazyBehaviour CrazyBehaviour;

        internal OnCrazyBehaviourArgs(CrazyBehaviour CrazyBehaviour)
        {
            this.CrazyBehaviour = CrazyBehaviour;
        }
    }
}