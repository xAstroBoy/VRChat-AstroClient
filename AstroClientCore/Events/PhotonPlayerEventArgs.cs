namespace AstroClientCore
{
	using Photon.Realtime;
	using System;

	public class PhotonPlayerEventArgs : EventArgs
    {
        public Player player;

        public PhotonPlayerEventArgs(Player player)
        {
            this.player = player;
        }
    }
}