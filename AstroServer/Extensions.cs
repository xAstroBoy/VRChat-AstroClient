namespace AstroServer
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static string ConvertToString(this byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes), "ConvertToString bytes was null");
            }
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        public static byte[] ConvertToBytes(this string msg)
        {
            return Encoding.UTF8.GetBytes(msg);
        }
    }
}
