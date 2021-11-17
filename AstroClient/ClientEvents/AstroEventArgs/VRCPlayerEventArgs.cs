namespace AstroClient.AstroEventArgs
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