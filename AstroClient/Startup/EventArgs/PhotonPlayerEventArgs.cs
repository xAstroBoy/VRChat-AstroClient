namespace AstroClientCore.Events
{
    using Photon.Realtime;
    using System;

    internal class PhotonPlayerEventArgs : EventArgs
    {
        public Player player;

        public PhotonPlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}