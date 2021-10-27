namespace AstroInjector
{
    using global::AstroInjector.Cheetos;
    using MelonLoader;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class AstroInjector : MelonPlugin
    {
#if DEBUG

        internal static string[] DebugMelonPaths =
        {
            @"Debug\AstroClient.dll",
			//@"Debug\AstroClientCore.dll",
			//@"Debug\DontTouchMyClient.dll",
			//@"Debug\MonoDumper.dll",
		};

        internal static string[] DebugLibraryPaths =
        {
            //@"Debug\Libs\AstroLibrary.dll",
        };

        internal static string[] DebugModulePaths =
        {
			//@"Debug\Module\AstroTestModule.dll"
		};

#endif

        internal static string[] EmbededLibraryPaths =
        {
            @"AstroInjector.Resources.Newtonsoft.Json.dll",
            @"AstroInjector.Resources.Newtonsoft.Json.Bson.dll",
            @"AstroInjector.Resources.websocket-sharp.dll",
        };

        internal static string[] EmbededMelonsPaths =
        {
            //@"AstroInjector.Resources.DontTouchMyClient.dll",
        };

        public AstroInjector()
        {
            LoadEmbeddedLibraries();
            if (Environment.GetCommandLineArgs().Any(a => a.Contains("RinBot")))
            {
                MelonLogger.Msg($"Detected RinBot: Skipping AstroClient Loading");
                return;
            }
            LoadEmbeddedMelons();

#if DEBUG
            //LoadDebug();
            //return;
#endif

            KeyManager.ReadKey();

            AstroNetworkLoader.Initialize();

            while (!AstroNetworkLoader.IsReady)
            {
            }

            if (AstroNetworkLoader.LibraryFiles.Count > 0)
            {
                for (int i = 0; i < AstroNetworkLoader.LibraryFiles.Count; i++)
                {
                    byte[] bytes = AstroNetworkLoader.LibraryFiles[i];
                    Assembly.Load(bytes);
                }
            }

            if (AstroNetworkLoader.MelonFiles.Count > 0)
            {
                for (int i = 0; i < AstroNetworkLoader.MelonFiles.Count; i++)
                {
                    byte[] bytes = AstroNetworkLoader.MelonFiles[i];
                    var dll = Assembly.Load(bytes);
                    MelonHandler.LoadFromAssembly(dll, Environment.CurrentDirectory + @"\Plugins\AstroInjector.dll");
                }
            }

            if (AstroNetworkLoader.ModuleFiles.Count > 0)
            {
                for (int i = 0; i < AstroNetworkLoader.ModuleFiles.Count; i++)
                {
                    byte[] bytes = AstroNetworkLoader.ModuleFiles[i];
                    Assembly.Load(bytes);
                }
            }
        }

        internal void LoadEmbeddedLibraries()
        {
            for (int i = 0; i < EmbededLibraryPaths.Length; i++)
            {
                string path = EmbededLibraryPaths[i];
                try
                {
                    var bytes = CheetosHelpers.ExtractResource(path);
                    var dll = Assembly.Load(bytes);
                    MelonLogger.Msg($"Injected Embedded Library: {path}");
                }
                catch (Exception e)
                {
                    MelonLogger.Msg(e.Message);
                    MelonLogger.Msg($"Failed to inject embedded library: {path}");
                }
            }
        }

        internal void LoadEmbeddedMelons()
        {
            for (int i = 0; i < EmbededMelonsPaths.Length; i++)
            {
                string path = EmbededMelonsPaths[i];
                try
                {
                    var bytes = CheetosHelpers.ExtractResource(path);
                    var dll = Assembly.Load(bytes);
                    MelonHandler.LoadFromAssembly(dll, Environment.CurrentDirectory + @"\Plugins\AstroInjector.dll");
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

        internal void LoadDebug()
        {
            MelonLogger.Msg("Loader is in debug mode.");

            for (int i = 0; i < DebugLibraryPaths.Length; i++)
            {
                string path = DebugLibraryPaths[i];
                try
                {
                    if (File.Exists(path))
                    {
                        var dll = Assembly.LoadFrom(path);
                        MelonHandler.LoadFromAssembly(dll, path);
                        MelonLogger.Msg($"Injected Library: {path}");
                    }
                    else
                    {
                        var newpath = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "-Obfuscated" + Path.GetExtension(path);
                        var obfuscatedll = Assembly.LoadFrom(newpath);
                        MelonHandler.LoadFromAssembly(obfuscatedll, newpath);
                        MelonLogger.Msg($"Injected Obfuscated Library: {path}");
                    }

                }
                catch (Exception e)
                {
                    MelonLogger.Msg(e.Message);
                    MelonLogger.Msg($"Failed to inject: {path}");
                }
            }

            for (int i = 0; i < DebugMelonPaths.Length; i++)
            {
                string path = DebugMelonPaths[i];
                try
                {
                    if (File.Exists(path))
                    {
                        var dll = Assembly.LoadFile(path);
                        MelonHandler.LoadFromAssembly(dll, path);
                        MelonLogger.Msg($"Injected MelonMod/MelonPlugin: {path}");
                    }
                    else
                    {   var newpath = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "-Obfuscated" + Path.GetExtension(path);
                        var obfuscatedll = Assembly.LoadFile(newpath);
                        MelonHandler.LoadFromAssembly(obfuscatedll, newpath);
                        MelonLogger.Msg($"Injected Obfuscated MelonMod/MelonPlugin: {path}");
                    }
                }
                catch (Exception e)
                {
                    MelonLogger.Msg(e.Message);
                    MelonLogger.Msg($"Failed to inject: {path}");
                }
            }

            for (int i = 0; i < DebugModulePaths.Length; i++)
            {
                string path = DebugModulePaths[i];
                try
                {
                    _ = Assembly.LoadFile(path);
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