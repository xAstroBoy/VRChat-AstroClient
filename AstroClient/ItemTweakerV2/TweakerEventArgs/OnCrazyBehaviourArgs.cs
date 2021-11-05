namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using AstroMonos.Components.Custom.Random;

    internal class OnCrazyBehaviourArgs : EventArgs
    {
        internal CrazyBehaviour CrazyBehaviour;

        internal OnCrazyBehaviourArgs(CrazyBehaviour CrazyBehaviour)
        {
            this.CrazyBehaviour = CrazyBehaviour;
        }
    }
}