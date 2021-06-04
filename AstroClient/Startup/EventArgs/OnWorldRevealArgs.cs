namespace AstroClient
{
	using System;
	using System.Collections.Generic;

	public class OnWorldRevealArgs : EventArgs
    {
        public string ID;
        public string Name;
        public List<string> WorldTags;
        public string AssetUrl;

        public OnWorldRevealArgs(string ID, string Name, List<string> WorldTags, string AssetUrl)
        {
            this.ID = ID;
            this.Name = Name;
            this.AssetUrl = AssetUrl;
            this.WorldTags = WorldTags;
        }
    }
}