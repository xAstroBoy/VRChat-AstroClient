namespace AstroClient
{
    using System;
    using System.Collections.Generic;

    internal class OnWorldRevealArgs : EventArgs
    {
        public string ID;
        public string Name;
        public List<string> WorldTags;
        public string AuthorName;
        public string AssetUrl;
        

        public OnWorldRevealArgs(string ID, string Name, List<string> WorldTags, string AuthorName, string AssetUrl)
        {
            this.ID = ID;
            this.Name = Name;
            this.AssetUrl = AssetUrl;
            this.WorldTags = WorldTags;
            this.AuthorName = AuthorName;
        }
    }
}