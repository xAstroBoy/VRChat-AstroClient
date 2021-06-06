namespace AstroClient
{
	using System;

	public class VRCPlayerEventArgs : EventArgs
	{
		public VRCPlayer player;

		public VRCPlayerEventArgs(VRCPlayer player)
		{
			this.player = player;
		}
	}
}