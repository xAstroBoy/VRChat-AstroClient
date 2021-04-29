namespace AstroNetworkingLibrary
	{
	using System;
	using System.Text;

	public static class NetworkingExtensions
		{
		public static string ConvertToString(this byte[] bytes)
			{
			return bytes == null
				? throw new ArgumentNullException(nameof(bytes), "ConvertToString bytes was null")
				: Encoding.UTF8.GetString(bytes, 0, bytes.Length);
			}

		public static byte[] ConvertToBytes(this string msg)
			{
			return Encoding.UTF8.GetBytes(msg);
			}
		}
	}