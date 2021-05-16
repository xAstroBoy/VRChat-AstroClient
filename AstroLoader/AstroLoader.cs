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

			if (AstroNetworkLoader.LibraryFiles.Count > 0)
			{
				foreach (var bytes in AstroNetworkLoader.LibraryFiles)
				{
					Assembly.Load(bytes);
				}
			}

			if (AstroNetworkLoader.MelonFiles.Count > 0)
			{
				foreach (var bytes in AstroNetworkLoader.MelonFiles)
				{
					var dll = Assembly.Load(bytes);
					MelonHandler.LoadFromAssembly(dll, Environment.CurrentDirectory + @"\Plugins\AstroLoader.dll");
				}
			}

			if (AstroNetworkLoader.ModuleFiles.Count > 0)
			{
				foreach (var bytes in AstroNetworkLoader.ModuleFiles)
				{
					Assembly.Load(bytes);
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
					var dll = Assembly.Load(bytes);
					Console.WriteLine($"Injected Embedded Library: {path}");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine($"Failed to inject embedded library: {path}");
				}
			}
		}

#if DEBUG

		public void LoadDebug()
		{
			Console.WriteLine("Loader is in debug mode.");

			foreach (var path in DebugLibraryPaths)
			{
				try
				{
					var dll = Assembly.LoadFrom(path);
					Console.WriteLine($"Injected Library: {path}");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine($"Failed to inject: {path}");
				}
			}

			foreach (var path in DebugMelonPaths)
			{
				try
				{
					var dll = Assembly.LoadFile(path);
					MelonHandler.LoadFromAssembly(dll, path);
					Console.WriteLine($"Injected MelonMod/MelonPlugin: {path}");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine($"Failed to inject: {path}");
				}
			}

			foreach (var path in DebugModulePaths)
			{
				try
				{
					_ = Assembly.LoadFile(path);
					Console.WriteLine($"Injected: {path}");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine($"Failed to inject: {path}");
				}
			}
		}

#endif
	}
}