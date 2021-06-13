namespace CheetoClient
{
	using AstroLibrary.Console;
	using HarmonyLib;
	using MelonLoader;
	using System;
	using System.Reflection;
	using UnityEngine;
	using VRC.SDKBase;

	public class CheetoClient : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.Initialize("CheetoClient");
			var harmony = new Harmony("CheetoClient");
			harmony.PatchAll(Assembly.GetExecutingAssembly());

			foreach (var method in harmony.GetPatchedMethods())
			{
				ModConsole.Log($"Patched: {method.Name}");
			}

			ModConsole.Log("CheetoClient Initialized");

			PrintNestedTypes(typeof(VRCUiCursor));
		}

		public static void PrintNestedTypes<T>(T type) where T : Type
		{
			foreach (var t in type.GetNestedTypes())
			{
				ModConsole.Log($"{type.Name} has nested Type {t.Name}");
			}
		}
	}
}
