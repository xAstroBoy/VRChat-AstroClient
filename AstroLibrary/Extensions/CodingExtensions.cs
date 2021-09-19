namespace AstroLibrary.Extensions
{
    using System.Collections.Generic;

    public static class CodingExtensions
    {
        public static bool IsEmpty<T>(this List<T> list) => list == null || list.Count == 0;

        public static bool IsNotEmpty<T>(this List<T> list) => list.Count != 0;

        public static bool IsNull<T>(this T obj) where T : class => obj == null;

        public static bool IsNull<T>(this T? obj) where T : struct => !obj.HasValue;

        public static bool IsNotNull<T>(this T obj) where T : class => obj != null;

        public static bool IsNotNull<T>(this T? obj) where T : struct => obj.HasValue;

        public static bool IsNotNullOrEmptyOrWhiteSpace(this string obj) => !string.IsNullOrEmpty(obj) && !string.IsNullOrWhiteSpace(obj);
    }
}