namespace AstroClient.AstroEventArgs
{
    using System;
    using UnityEngine;
    using VRC;

    internal class UdonSyncRPCEventArgs : EventArgs
    {
        internal Player sender;
        internal GameObject obj;
        internal string action;

        internal UdonSyncRPCEventArgs(Player sender, GameObject obj, string action)
        {
            this.sender = sender;
            this.obj = obj;
            this.action = action;
        }
    }
}