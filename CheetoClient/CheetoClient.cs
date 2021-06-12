namespace CheetoClient
{
	using AstroLibrary.Console;
	using HarmonyLib;
	using MelonLoader;
	using System.Reflection;
	using UnityEngine;

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
		}
	}
}
