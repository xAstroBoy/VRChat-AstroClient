namespace AstroNetworkingLibrary
{
    using System;

    internal static  class NetworkingExtensions
    {
        internal static  string ConvertToString(this byte[] bytes)
        {
            return bytes == null
                ? throw new ArgumentNullException(nameof(bytes), "ConvertToString bytes was null")
                : System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        internal static  byte[] ConvertToBytes(this string msg) => System.Text.Encoding.UTF8.GetBytes(msg);
    }
}