namespace AstroClient.Extensions
{
	using AstroLibrary.Console;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRC.Udon;

	public static class Component_utils_ext
    {

		public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
		{
			var result = obj.GetComponent<T>();
			if (result == null)
				result = obj.AddComponent<T>();
			return result;
		}


		public static T GetOrAddComponent<T>(this Transform obj) where T : Component
		{
			return obj.gameObject.GetOrAddComponent<T>();
		}


	}
}