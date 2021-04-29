namespace AstroClient.Modules
{
	using AstroClient.ConsoleUtils;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;

	public static class ModuleManager
	{
		public static List<BaseModule> Modules = new List<BaseModule>();

		public static void LoadModules()
		{
			//ModConsole.Log("Loading Modules...");

   //         StackFrame[] frames = new StackTrace().GetFrames();
			//var assemblies = (from f in frames select f.GetMethod().ReflectedType.Assembly);

			//foreach (var assembly in assemblies)
			//{
			//	var types = assembly.GetTypes();

			//	foreach (var type in types)
			//	{
			//		var btype = type.BaseType;

			//		if (btype != null && btype.Equals(typeof(BaseModule)))
			//		{
			//			BaseModule module = assembly.CreateInstance(type.ToString(), true) as BaseModule;
			//			Modules.Add(module);
			//			ModConsole.Log($"ModuleManager Loaded Module: {module.name}");
			//		}

			//		ModConsole.Log($"type: {type}, of {btype}");
			//	}
			//}

			//var assembly = Assembly.GetExecutingAssembly();

            ModConsole.Log("Loading Modules...");
            var assembly = Assembly.GetExecutingAssembly();
			var types = assembly.GetTypes();

			foreach (var type in types)
			{
				var btype = type.BaseType;

				if (btype != null && btype.Equals(typeof(BaseModule)))
				{
					BaseModule module = assembly.CreateInstance(type.ToString(), true) as BaseModule;
					Modules.Add(module);
					ModConsole.Log($"ModuleManager Loaded Module: {module.name}");
				}

				ModConsole.Log($"type: {type}, of {btype}");
			}
		}
	}
}
