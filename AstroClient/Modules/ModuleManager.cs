namespace AstroClient.Modules
{
	using AstroClient.ConsoleUtils;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;
	using System.Threading;

	public static class ModuleManager
	{
		public static List<BaseModule> Modules = new List<BaseModule>();

		public static void LoadModules()
		{
			ModConsole.Log("Loading Modules...");

			var assemblies = Thread.GetDomain().GetAssemblies();

			foreach (var assembly in assemblies)
			{
				var types = assembly.GetTypes();
				foreach (var type in types)
				{
					var btype = type.BaseType;

					if (btype != null && btype.Equals(typeof(BaseModule)))
					{
						BaseModule module = assembly.CreateInstance(type.ToString(), true) as BaseModule;
						Modules.Add(module);
						ModConsole.Log($"ModuleManager Loaded Module: {module.GetType()}");
					}

					//ModConsole.Log($"type: {type}, of {btype}");
				}
			}
		}
	}
}
