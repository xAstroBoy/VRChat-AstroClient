namespace AstroClientCore.Events
{
    using Photon.Realtime;
    using System;

    internal class PhotonPlayerEventArgs : EventArgs
    {
        internal Player player;

        internal PhotonPlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}