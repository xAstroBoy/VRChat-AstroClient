namespace AstroClient.Extensions
{
	#region Imports

	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Cloner;
	using AstroClient.ItemTweaker;
	using AstroClient.Startup;
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using AstroLibrary.Utility;
	using DayClientML2.Utility;
	using System.Collections.Generic;
	using System.Windows.Forms;
	using UnityEngine;
	using VRC.SDKBase;
	using Color = System.Drawing.Color;

	#endregion Imports

	public static class VRC_UiShape_ext
    {
		internal static void AddUiShapeWithTriggerCollider(this GameObject obj)
		{
			obj.AddComponent<VRC_UiShape>().Awake(); // Awake is not called on disabled object, so call it manually; calling it twice doesn't cause issues
			obj.GetComponent<BoxCollider>().isTrigger = true;
		}

	}
}