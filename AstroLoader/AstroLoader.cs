namespace AstroLoader
{
	using MelonLoader;
	using System;
	using System.Reflection;

	public class AstroLoader : MelonPlugin
	{
		public static byte[] AssemblyFile;

#if OFFLINE
		public static string[] DebugMelonPaths =
		{
			@"Debug\AstroClient.dll",
			@"Debug\DontTouchMyClient.dll",
		};

		public static string[] DebugModulePaths =
{
			@"Debug\Module\AstroTestModule.dll"
		};
#endif

		public AstroLoader()
		{
#if OFFLINE
			LoadDebug();
			return;
#endif

			KeyManager.ReadKey();

			AstroNetworkLoader.Initialize();

			while (!AstroNetworkLoader.IsReady)
			{
			}

			//if (AstroNetworkLoader.AssemblyFile != null)
			//{
			//    try
			//    {
			//        var dll = Assembly.Load(AstroNetworkLoader.AssemblyFile);
			//        MelonHandler.LoadFromAssembly(dll, @"plugins\AstroLoader.dll");
			//    }
			//    catch (BadImageFormatException e)
			//    {
			//        Console.WriteLine("Bad Image Format Exception");
			//        Console.WriteLine(e.Message);
			//        Console.WriteLine(e.StackTrace);
			//        Console.WriteLine(e.Source);
			//    }
			//}
			//else
			//{
			//    Console.WriteLine("Failed to load assembly, it was null");
			//}
		}

#if OFFLINE
		public void LoadDebug()
		{
			Console.WriteLine("Loader is in debug mode.");

			foreach (var path in DebugMelonPaths)
			{
				try
				{
					var dll = Assembly.LoadFile(path);
					MelonHandler.LoadFromAssembly(dll, path);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
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
				}
			}
		}
#endif
	}
}