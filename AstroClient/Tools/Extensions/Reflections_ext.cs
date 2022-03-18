namespace AstroClient.Tools.Extensions
{
    using System;
    using System.Linq;

    internal static class Reflections_ext
    {
        internal static T GetAssemblyAttribute<T>(this System.Reflection.Assembly ass) where T : Attribute
        {
            object[] attributes = ass.GetCustomAttributes(typeof(T), false);
            if (attributes == null || attributes.Length == 0)
                return null;
            return attributes.OfType<T>().SingleOrDefault();
        }
    }
}