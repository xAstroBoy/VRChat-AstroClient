namespace AstroClient.AstroEventArgs
{
    using System;
    using UnityEngine;
    using VRC;

    internal class UdonSyncRPCEventArgs : EventArgs
    {
        internal string action;
        internal GameObject obj;
        internal Player sender;

        internal UdonSyncRPCEventArgs(Player sender, GameObject obj, string action)
        {
            this.sender = sender;
            this.obj = obj;
            this.action = action;
        }
    }
}