namespace AstroClient
{
    using System;

    internal class VRCPlayerEventArgs : EventArgs
    {
        internal VRC.Player player;

        internal VRCPlayerEventArgs(VRC.Player player)
        {
            this.player = player;
        }
    }
}