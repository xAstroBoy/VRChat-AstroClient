using System;
using VRC;

namespace AstroClient
{
	public class PlayerEventArgs : EventArgs
	{
		public Player player;

		public PlayerEventArgs(Player player)
		{
			this.player = player;
		}
	}
}