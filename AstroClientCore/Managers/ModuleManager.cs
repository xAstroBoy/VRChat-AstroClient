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
			ModConsole.DebugLog("Loading Modules...");

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
						ModConsole.DebugLog($"ModuleManager Loaded Module: {module.GetType()}");
					}
				}
			}
		}
	}
}