namespace AstroClient
{
    using System;
    using System.Collections.Generic;

    internal class OnWorldRevealArgs : EventArgs
    {
        internal string ID;
        internal string Name;
        internal List<string> WorldTags;
        internal string AuthorName;
        internal string AssetUrl;
        

        internal OnWorldRevealArgs(string ID, string Name, List<string> WorldTags, string AuthorName, string AssetUrl)
        {
            this.ID = ID;
            this.Name = Name;
            this.AssetUrl = AssetUrl;
            this.WorldTags = WorldTags;
            this.AuthorName = AuthorName;
        }
    }
}