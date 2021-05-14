namespace AstroClientCore.Managers
{
	#region Imports

	using AstroClientCore.ConsoleUtils;
	using AstroLibrary;
	using System.Collections.Generic;
	using System.Threading;

	#endregion

	public static class ModuleManager
	{
		public static List<BaseModule> Modules = new List<BaseModule>();

		public static void LoadModules()
		{
			ModConsole.Log("ModuleManager: Loading Modules...");

			var assemblies = Thread.GetDomain().GetAssemblies();

			foreach (var assembly in assemblies)
			{
				foreach (var type in assembly.GetTypes())
				{
					if (type.BaseType != null && type.BaseType.Equals(typeof(BaseModule)))
					{
						BaseModule module = assembly.CreateInstance(type.ToString(), true) as BaseModule;
						Modules.Add(module);
						module.Start();
						ModConsole.Log($"ModuleManager: Loaded Module ({module.GetType()})");
					}
				}
			}
		}

		internal static void OnGUI()
		{
			Modules.ForEach(m => m.OnGUI());
		}

		internal static void OnApplicationQuit()
		{
			Modules.ForEach(m => m.OnApplicationQuit());
		}

		internal static void VRChat_OnUiManagerInit()
		{
			Modules.ForEach(m => m.VRChat_OnUiManagerInit());
		}

		public static void Update()
		{
			Modules.ForEach(m => m.Update());
		}

		public static void LateUpdate()
		{
			Modules.ForEach(m => m.LateUpdate());
		}
	}
}