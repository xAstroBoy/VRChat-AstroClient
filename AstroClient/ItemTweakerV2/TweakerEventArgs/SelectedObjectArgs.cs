namespace AstroClient.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using UnityEngine;

    internal class SelectedObjectArgs : EventArgs
    {
        public GameObject GameObject;

        public SelectedObjectArgs(GameObject obj)
        {
            this.GameObject = obj;
        }
    }
}