namespace AstroInjector
{
    using global::AstroInjector.Cheetos;
    using MelonLoader;
    using System;
    using System.Reflection;

    public class AstroInjector : MelonPlugin
    {
#if DEBUG

        public static string[] DebugMelonPaths =
        {
            @"Debug\AstroClient.dll",
			//@"Debug\AstroClientCore.dll",
			@"Debug\DontTouchMyClient.dll",
			//@"Debug\MonoDumper.dll",
		};

        public static string[] DebugLibraryPaths =
        {
            @"Debug\Libs\AstroLibrary.dll",
        };

        public static string[] DebugModulePaths =
{
			//@"Debug\Module\AstroTestModule.dll"
		};

#endif

        public static string[] EmbededLibraryPaths =
        {
            @"AstroInjector.Resources.Newtonsoft.Json.dll",
            @"AstroInjector.Resources.Newtonsoft.Json.Bson.dll",
        };

        public AstroInjector()
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
                    //MelonLogger.Msg($"Injected Embedded Library: {path}");
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
                    var dll = Assembly.LoadFrom(path);
                    //MelonLogger.Msg($"Injected Library: {path}");
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
                    var dll = Assembly.LoadFile(path);
                    MelonHandler.LoadFromAssembly(dll, path);
                    //MelonLogger.Msg($"Injected MelonMod/MelonPlugin: {path}");
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
                    _ = Assembly.LoadFile(path);
                    //MelonLogger.Msg($"Injected: {path}");
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