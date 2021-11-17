namespace AstroClient.xAstroBoy.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class CodingExtensions
    {
        public static bool IsEmpty<T>(this List<T> list) => list == null || list.Count == 0;

        public static bool IsNotEmpty<T>(this List<T> list) => list.Count != 0;

        public static bool IsNull<T>(this T obj) where T : class => obj == null;

        public static bool IsNull<T>(this T? obj) where T : struct => !obj.HasValue;

        public static bool IsNotNull<T>(this T obj) where T : class => obj != null;

        public static bool IsNotNull<T>(this T? obj) where T : struct => obj.HasValue;

        public static bool IsNotNullOrEmptyOrWhiteSpace(this string obj) => !string.IsNullOrEmpty(obj) && !string.IsNullOrWhiteSpace(obj);

        internal static string ReplaceWholeWord(this string original, string wordToFind, string replacement, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.Replace(original, wordToFind, replacement, regexOptions);
        }

        internal static bool isMatch(this string value, string wordToFind, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.IsMatch(value, wordToFind, regexOptions);
        }

        internal static string RemoveWhitespace(this string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }


    }
}