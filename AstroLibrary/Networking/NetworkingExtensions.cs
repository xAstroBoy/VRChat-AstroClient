namespace AstroLibrary.Networking
{
    using System;
    using System.Text;

    public static class NetworkingExtensions
    {
        public static string ConvertToString(this byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes), "ConvertToString bytes was null");
            }
            return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        }

        public static byte[] ConvertToBytes(this string msg)
        {
            return Encoding.ASCII.GetBytes(msg);
        }
    }
}
