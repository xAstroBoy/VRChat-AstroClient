namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using Il2CppSystem;
    using VRC.SDKBase;

    internal static class Il2Cpp_ext
    {
        //internal static List<UnityEngine.Object> ConvertToUnityObject(this Il2CppReferenceArray<Il2CppSystem.Object> list)
        //{
        //	var items = new List<UnityEngine.Object>();
        //	foreach(var item in items)
        //	{
        //		if(item != null)
        //		{
        //			var result = item.Unbox<UnityEngine.Object>();
        //			if(result != null)
        //			{
        //				Log.Debug($"Casted Object :  {result.GetType().FullName}, from item : {item.GetIl2CppType().FullName}");
        //				items.Add(result);
        //			}
        //		}
        //	}
        //	return items;
        //}
        internal static  bool IsNullable(this Type value)
        {
            return Il2CppSystem.Nullable.GetUnderlyingType(value) != null;
        }

        internal static Il2CppSystem.Collections.Generic.List<T> ToIl2CPPlist<T>(this System.Collections.Generic.List<T> list)
        {
            var result = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (var item in list)
            {
                result.Add(item);
            }

            return result;
        }

    }
}