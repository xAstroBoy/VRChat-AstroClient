namespace AstroNetworkingLibrary.Serializable
{
    using System;
    using System.Reflection;

    [Serializable, Obfuscation]
    public class AuthData
    {
        public int ClientType;

        public string Key = string.Empty;

        public AuthData(int clientType, string key = "")
        {
            ClientType = clientType;
            Key = key;
        }
    }
}