namespace AstroServer.Serializable
{
    using MongoDB.Entities;
    using System;

    [Serializable]
    public class RinData : Entity
    {
        public string Key = string.Empty;

        public bool IsDeveloper;
    }
}