namespace CheetoClient
{
	using AstroLibrary.Console;
	using HarmonyLib;
	using MelonLoader;
	using System;
	using System.Reflection;

	public class CheetoClient : MelonMod
	{
		public override void OnApplicationStart()
		{
			ModConsole.Initialize("CheetoClient");
			ModConsole.Log("Congratulations, you now have the most useless client!");
		}

	}
}
