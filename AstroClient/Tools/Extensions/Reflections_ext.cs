using System.Collections.Generic;

namespace AstroClient.Tools.Extensions
{
    using System;
    using System.Linq;

    internal static class Reflections_ext
    {
        public static T Pop<T>(this List<T> list)
        {
            var index = list.Count - 1;
            var r = list[index];
            list.RemoveAt(index);
            return r;
        }

        public static T PopAt<T>(this List<T> list, int index)
        {
            var r = list[index];
            list.RemoveAt(index);
            return r;
        }

        public static T PopFirst<T>(this List<T> list, Predicate<T> predicate)
        {
            var index = list.FindIndex(predicate);
            var r = list[index];
            list.RemoveAt(index);
            return r;
        }

        public static T PopFirstOrDefault<T>(this List<T> list, Predicate<T> predicate) where T : class
        {
            var index = list.FindIndex(predicate);
            if (index > -1)
            {
                var r = list[index];
                list.RemoveAt(index);
                return r;
            }
            return null;
        }
        internal static T GetAssemblyAttribute<T>(this System.Reflection.Assembly ass) where T : Attribute
        {
            object[] attributes = ass.GetCustomAttributes(typeof(T), false);
            if (attributes == null || attributes.Length == 0)
                return null;
            return attributes.OfType<T>().SingleOrDefault();
        }
    }
}