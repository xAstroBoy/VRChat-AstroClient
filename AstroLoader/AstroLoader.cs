namespace AstroLoader
{
	using AstroClient.Cheetos;
	using MelonLoader;
	using System;
	using System.Reflection;

	public class AstroLoader : MelonPlugin
	{
#if DEBUG

		public static string[] DebugMelonPaths =
		{
			@"Debug\AstroClient.dll",
			@"Debug\AstroClientCore.dll",
			@"Debug\DontTouchMyClient.dll",
			@"Debug\MonoDumper.dll",
		};

		public static string[] DebugLibraryPaths =
		{
			@"Debug\Libs\AstroLibrary.dll",
		};

		public static string[] DebugModulePaths =
{
			@"Debug\Module\AstroTestModule.dll"
		};

#endif

		public static string[] EmbededLibraryPaths =
		{
			@"AstroLoader.Resources.Newtonsoft.Json.dll",
			@"AstroLoader.Resources.Newtonsoft.Json.Bson.dll",
		};

		public AstroLoader()
		{
			LoadEmbeddedLibraries();

#if DEBUG
			LoadDebug();
			return;
#endif

			KeyManager.ReadKey();

			AstroNetworkLoader.Initialize();

			while (!AstroNetworkLoader.IsReady)
			{
			}

			MelonUtils.JSonSerialize();

			if (AstroNetworkLoader.LibraryFiles.Count > 0)
			{
				foreach (var bytes in AstroNetworkLoader.LibraryFiles)
				{
					MelonUtils.JSonSerialize();
					Assembly.Load(bytes);
					MelonUtils.JSonDeserialize();
				}
			}

			if (AstroNetworkLoader.MelonFiles.Count > 0)
			{
				foreach (var bytes in AstroNetworkLoader.MelonFiles)
				{
					var dll = Assembly.Load(bytes);
					MelonUtils.JSonSerialize();
					MelonHandler.LoadFromAssembly(dll, Environment.CurrentDirectory + @"\Plugins\AstroLoader.dll");
					MelonUtils.JSonDeserialize();
				}
			}

			if (AstroNetworkLoader.ModuleFiles.Count > 0)
			{
				foreach (var bytes in AstroNetworkLoader.ModuleFiles)
				{
					MelonUtils.JSonSerialize();
					Assembly.Load(bytes);
					MelonUtils.JSonDeserialize();
				}
			}
		}

		public void LoadEmbeddedLibraries()
		{
			foreach (var path in EmbededLibraryPaths)
			{
				try
				{
					var bytes = CheetosHelpers.ExtractResource(path);
					MelonUtils.JSonSerialize();
					var dll = Assembly.Load(bytes);
					MelonUtils.JSonDeserialize();
					MelonLogger.Msg($"Injected Embedded Library: {path}");
				}
				catch (Exception e)
				{
					MelonLogger.Msg(e.Message);
					MelonLogger.Msg($"Failed to inject embedded library: {path}");
				}
			}
		}

#if DEBUG

		public void LoadDebug()
		{
			MelonLogger.Msg("Loader is in debug mode.");

			foreach (var path in DebugLibraryPaths)
			{
				try
				{
					MelonUtils.JSonSerialize();
					var dll = Assembly.LoadFrom(path);
					MelonUtils.JSonDeserialize();
					MelonLogger.Msg($"Injected Library: {path}");
				}
				catch (Exception e)
				{
					MelonLogger.Msg(e.Message);
					MelonLogger.Msg($"Failed to inject: {path}");
				}
			}

			foreach (var path in DebugMelonPaths)
			{
				try
				{
					MelonUtils.JSonSerialize();
					var dll = Assembly.LoadFile(path);
					MelonHandler.LoadFromAssembly(dll, path);
					MelonUtils.JSonDeserialize();
					MelonLogger.Msg($"Injected MelonMod/MelonPlugin: {path}");
				}
				catch (Exception e)
				{
					MelonLogger.Msg(e.Message);
					MelonLogger.Msg($"Failed to inject: {path}");
				}
			}

			foreach (var path in DebugModulePaths)
			{
				try
				{
					MelonUtils.JSonSerialize();
					_ = Assembly.LoadFile(path);
					MelonUtils.JSonDeserialize();
					MelonLogger.Msg($"Injected: {path}");
				}
				catch (Exception e)
				{
					MelonLogger.Msg(e.Message);
					MelonLogger.Msg($"Failed to inject: {path}");
				}
			}
		}

#endif
	}
}