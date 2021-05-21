namespace AstroClient
{
	using System;

	public class OnWorldRevealArgs : EventArgs
	{
		public string ID;
		public string Name;
		public string WorldTags;
		public string AssetUrl;
		public OnWorldRevealArgs(string ID, string Name, string WorldTags, string AssetUrl)
		{
			this.ID = ID;
			this.Name = Name;
			this.AssetUrl = AssetUrl;
			this.WorldTags = WorldTags;
		}
	}
}