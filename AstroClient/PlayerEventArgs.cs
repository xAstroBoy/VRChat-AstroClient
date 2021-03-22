using System;
using VRC;

namespace AstroClient
{
    public class PlayerEventArgs : EventArgs
    {
        private Player player;

        public PlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}