namespace AstroClient.Extensions
{
	using System.Collections.Generic;

	public static class CodingExtensions
	{
		public static bool IsEmpty<T>(this List<T> list)
		{
			return list == null || list.Count == 0;
		}

		public static bool IsNotEmpty<T>(this List<T> list)
		{
			return list.Count != 0;
		}

		public static bool IsNull<T>(this T obj) where T : class
		{
			return obj == null;
		}

		public static bool IsNull<T>(this T? obj) where T : struct
		{
			return !obj.HasValue;
		}

		public static bool IsNotNull<T>(this T obj) where T : class
		{
			return obj != null;
		}

		public static bool IsNotNull<T>(this T? obj) where T : struct
		{
			return obj.HasValue;
		}
	}
}