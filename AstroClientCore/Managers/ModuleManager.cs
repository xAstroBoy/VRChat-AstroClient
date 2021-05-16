namespace AstroClientCore.Managers
{
	#region Imports

	using AstroLibrary;
	using AstroLibrary.Console;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Threading;

	#endregion

	public static class ModuleManager
	{
		public static List<BaseModule> Modules = new List<BaseModule>();

		public static List<Assembly> Assemblies = new List<Assembly>();

		public static void LoadModules()
		{
			ModConsole.Log("ModuleManager: Loading Modules...");

			foreach (var assembly in Thread.GetDomain().GetAssemblies())
			{
				foreach (var type in assembly.GetTypes())
				{
					if (type.BaseType != null && type.BaseType.Equals(typeof(BaseModule)))
					{
						BaseModule module = assembly.CreateInstance(type.ToString(), true) as BaseModule;
						Modules.Add(module);
						module.Start();
						ModConsole.Log($"ModuleManager: Loaded Module ({module.GetType()})");

						if (!Assemblies.Contains(assembly))
						{
							Assemblies.Add(assembly);
						}
					}
				}
			}
		}

		public static void OnGUI()
		{
			Modules.ForEach(m => m.OnGUI());
		}

		public static void OnApplicationQuit()
		{
			Modules.ForEach(m => m.OnApplicationQuit());
		}

		public static void VRChat_OnUiManagerInit()
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