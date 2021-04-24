﻿namespace AstroLibrary.Serializable
{
    using System;
    using System.Reflection;

    [Serializable, Obfuscation]
    public class AvatarData
    {
        public string ID = string.Empty;

        public string Name = string.Empty;

        public string Description = string.Empty;

        public string AuthorID = string.Empty;

        public string AuthorName = string.Empty;

        public int Version = 0;

        public string ReleaseStatus = string.Empty;

        public string AssetURL = string.Empty;

        public string ImageURL = string.Empty;

        public string ThumbnailURL = string.Empty;
    }
}