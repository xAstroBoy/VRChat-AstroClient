namespace AstroClient
{
	using System;

	public class OnWorldRevealArgs : EventArgs
	{
		public string ID;
		public string Name;
		public string AssetUrl;

		public OnWorldRevealArgs(string ID, string Name, string AssetUrl)
		{
			this.ID = ID;
			this.Name = Name;
			this.AssetUrl = AssetUrl;
		}
	}
}