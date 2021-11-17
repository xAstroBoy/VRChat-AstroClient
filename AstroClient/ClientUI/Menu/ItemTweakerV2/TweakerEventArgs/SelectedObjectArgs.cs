namespace AstroClient.ClientUI.Menu.ItemTweakerV2.TweakerEventArgs
{
    using System;
    using UnityEngine;

    internal class SelectedObjectArgs : EventArgs
    {
        internal GameObject GameObject;

        internal SelectedObjectArgs(GameObject obj)
        {
            this.GameObject = obj;
        }
    }
}