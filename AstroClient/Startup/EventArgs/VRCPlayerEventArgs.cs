namespace AstroClient
{
    using System;

    internal class VRCPlayerEventArgs : EventArgs
    {
        public VRC.Player player;

        public VRCPlayerEventArgs(VRC.Player player)
        {
            this.player = player;
        }
    }
}