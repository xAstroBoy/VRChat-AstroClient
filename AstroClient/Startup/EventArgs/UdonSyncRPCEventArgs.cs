using System;
using UnityEngine;
using VRC;

namespace AstroClient
{
    public class UdonSyncRPCEventArgs : EventArgs
    {
        public Player? sender;
        public GameObject? obj;
        public string action;


        public UdonSyncRPCEventArgs(Player sender, GameObject obj, string action)
        {
            this.sender = sender;
            this.obj = obj;
            this.action = action;

        }
    }
}