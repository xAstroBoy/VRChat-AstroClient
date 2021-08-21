﻿namespace AstroClient
{
	using Il2CppSystem.Collections.Generic;
	using UnhollowerBaseLib;
	using UnhollowerRuntimeLib;

	public static class UdonConverter
	{
		public static Il2CppSystem.Object Generate_Il2CPPObject(string[] item)
		{
			Il2CppStringArray array2 = new Il2CppStringArray(item);
			Il2CppSystem.Object boxed = new Il2CppSystem.Object(array2.Pointer);
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(string item)
		{
			var ptr = IL2CPP.ManagedStringToIl2Cpp(item);
			Il2CppSystem.Object boxed = new Il2CppSystem.Object(ptr);
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(System.UInt32 item)
		{
			var converted = new Il2CppSystem.UInt32() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(System.Int32 item)
		{
			var converted = new Il2CppSystem.Int32() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(System.Int64 item)
		{
			var converted = new Il2CppSystem.Int64() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(System.Char item)
		{
			var converted = new Il2CppSystem.Char() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(System.Single item)
		{
			var converted = new Il2CppSystem.Single() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(System.Boolean item)
		{
			var converted = new Il2CppSystem.Boolean() { m_value = item };
			var boxed = converted.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(UnityEngine.Color item)
		{
			var boxed = item.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(UnityEngine.Vector3 item)
		{
			var boxed = item.BoxIl2CppObject();
			return boxed ?? null;
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject(UnityEngine.Quaternion item)
		{
			var boxed = item.BoxIl2CppObject();
			return boxed ?? null;
		}


		public static Il2CppSystem.Object Generate_Il2CppObject_Unmanaged<T>(List<T> list) where T : unmanaged
		{
			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}

		public static Il2CppSystem.Object Generate_Il2CppObject_Unmanaged<T>(T[] array) where T : unmanaged
		{
			var list = new Il2CppSystem.Collections.Generic.List<T>();
			foreach (var item in array)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}


		public static Il2CppSystem.Object Generate_Il2CPPObject_Il2cppObjectBase<T>(List<T> list) where T : Il2CppObjectBase 
		{
			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}

		public static Il2CppSystem.Object Generate_Il2CPPObject_Il2cppObjectBase<T>(T[] array) where T : Il2CppObjectBase
		{
			var list = new Il2CppSystem.Collections.Generic.List<T>();
			foreach (var item in array)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}

			// Convert to Array.

			var arrayresult = list.ToArray();
			return new Il2CppSystem.Object(arrayresult.Pointer);
		}


		public static Il2CppSystem.Object Generate_Il2CPPObject_Il2cppObjectBase<T>(T item) where T : Il2CppObjectBase
		{
			var boxed = new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<T>.NativeClassPtr, item.Pointer));
			return boxed ?? null;
		}




		public static Il2CppSystem.Object Generate_Il2CppObject_Unmanaged<T> (T value) where T : unmanaged
		{
			if (typeof(T).IsEnum)
			{
				var enumtype = Il2CppType.Of<T>();
				foreach (var item in enumtype.GetEnumValues())
				{
					var result = item.Unbox<T>();
					if (result.Equals(value))
					{
						return item;
					}
				}
			}
			return null;
		}

	}
}