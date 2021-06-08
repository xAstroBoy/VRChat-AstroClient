namespace AstroClientCore.Managers
{
	using AstroLibrary.Console;
	using Harmony;
	using System.Collections.Generic;
	using System.Reflection;

	public static class PatchManager
	{
		private static HarmonyInstance harmony;

		private static List<Patching.Patch> patches = new List<Patching.Patch>();

		public static HarmonyMethod GetPatch<T>(string name)
		{
			return new HarmonyMethod(typeof(T).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
		}

		public static void Initialize()
		{
			if (harmony == null)
			{
				harmony = HarmonyInstance.Create("AstroClient.PatchManager");
				ModConsole.Log("[PatchManager] Harmony Instance Created.");
			}
		}

		public static void AddPatch(Patching.Patch patch)
		{
			patches.Add(patch);
		}

		public static void DoPatches()
		{
			foreach (var patch in patches)
			{
				patch.DoPatch();
			}
		}
	}
}
