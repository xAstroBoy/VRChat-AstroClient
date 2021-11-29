namespace AstroClient.AstroEventArgs
{
    using System;
    using VRC;

    internal class VRCPlayerEventArgs : EventArgs
    {
        internal Player player;

        internal VRCPlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}