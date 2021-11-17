namespace AstroClient.AstroEventArgs
{
    using System;
    using VRC.Core;

    internal class APIUserEventArgs : EventArgs
    {
        internal APIUser player;

        internal APIUserEventArgs(APIUser player)
        {
            this.player = player;
        }
    }
}