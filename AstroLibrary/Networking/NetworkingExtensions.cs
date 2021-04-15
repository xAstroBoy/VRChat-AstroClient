using System;
using System.Text;

namespace AstroLibrary.Networking
{
    public static class NetworkingExtensions
    {
        public static string ConvertToString(this byte[] bytes)
        {
            return bytes == null
                ? throw new ArgumentNullException(nameof(bytes), "ConvertToString bytes was null")
                : Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        }

        public static byte[] ConvertToBytes(this string msg)
        {
            return Encoding.ASCII.GetBytes(msg);
        }
    }
}
