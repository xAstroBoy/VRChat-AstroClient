namespace AstroClientCore.Events
{
    using System;
    using VRC;

    public class PlayerEventArgs : EventArgs
    {
        public Player player;

        public PlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}