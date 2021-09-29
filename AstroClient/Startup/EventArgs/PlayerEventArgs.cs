namespace AstroClientCore.Events
{
    using System;
    using VRC;

    internal class PlayerEventArgs : EventArgs
    {
        public Player player;

        public PlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}