namespace AstroClient
{
    using System;
    using UnityEngine;
    using VRC;

    public class UdonSyncRPCEventArgs : EventArgs
    {
        public Player sender;
        public GameObject obj;
        public string action;

        public UdonSyncRPCEventArgs(Player sender, GameObject obj, string action)
        {
            this.sender = sender;
            this.obj = obj;
            this.action = action;
        }
    }
}