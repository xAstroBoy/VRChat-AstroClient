﻿namespace AstroNetworkingLibrary
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;
    using System;
    using System.IO;

    internal static class BSonWriter
    {
        internal static string ToBson<T>(T value)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BsonDataWriter datawriter = new BsonDataWriter(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(datawriter, value);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        internal static T FromBson<T>(string base64data)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64data)))
            using (BsonDataReader reader = new BsonDataReader(ms))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader);
            }
        }
    }
}