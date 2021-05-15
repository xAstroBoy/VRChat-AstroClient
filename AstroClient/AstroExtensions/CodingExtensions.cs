namespace AstroClient.Extensions
{
	using System.Collections.Generic;

	public static class CodingExtensions
	{
		public static bool IsEmpty<T>(this List<T> list)
		{
			return list == null || list.Count == 0;
		}

		public static bool isNotEmpty<T>(this List<T> list)
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

		public static bool isNotNull<T>(this T obj) where T : class
		{
			return obj != null;
		}

		public static bool isNotNull<T>(this T? obj) where T : struct
		{
			return obj.HasValue;
		}
	}
}