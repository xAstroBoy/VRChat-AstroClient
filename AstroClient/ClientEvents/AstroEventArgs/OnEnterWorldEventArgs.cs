namespace AstroClient.AstroEventArgs
{
    using System;
    using Photon.Realtime;
    using VRC.Core;

    internal class OnEnterWorldEventArgs : EventArgs
    {
        internal ApiWorld ApiWorld;
        internal ApiWorldInstance ApiWorldInstance;

        internal OnEnterWorldEventArgs(ApiWorld ApiWorld, ApiWorldInstance ApiWorldInstance)
        {
            this.ApiWorld = ApiWorld;
            this.ApiWorldInstance = ApiWorldInstance;

        }
    }
}