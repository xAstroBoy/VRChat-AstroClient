namespace AstroNetworkingLibrary
{
    using System;

    internal static class Encoding
    {
        internal static string Base64Encode(this string plainText) => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));

        internal static string Base64Decode(this string base64EncodedData) => System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
    }
}