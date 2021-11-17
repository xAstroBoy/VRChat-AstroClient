namespace AstroClient.AstroEventArgs
{
    using System;
    using VRC;

    internal class PlayerEventArgs : EventArgs
    {
        internal Player player;

        internal PlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}