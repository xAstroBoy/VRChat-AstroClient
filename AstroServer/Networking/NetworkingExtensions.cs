namespace AstroNetworkingLibrary
{
    using System;

    internal static class NetworkingExtensions
    {
        internal static string ConvertToString(this byte[] bytes)
        {
            return bytes == null
                ? throw new ArgumentNullException(nameof(bytes), "ConvertToString bytes was null")
                : System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        internal static byte[] ConvertToBytes(this string msg) => System.Text.Encoding.UTF8.GetBytes(msg);

        public static string GetByteArrayAsString(this byte[] array)
        {
            var m = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                m += $"{array[i]:X2}";
                if ((i % 4) == 3) m += " ";
            }
            return m;
        }
    }
}