using MelonLoader;
using System;

#if DEBUG
#endif

using System.Reflection;

namespace AstroLoader
{
    public class AstroLoader : MelonPlugin
    {
        public static byte[] AssemblyFile;

#if DEBUG
        public static string[] DebugPaths =
        {
            @"\Debug\AstroClient.dll",
            @"\Debug\DontTouchMyClient.dll",
        };
#endif

        public AstroLoader()
        {
#if DEBUG
            LoadDebug();
            return;
#endif

            KeyManager.ReadKey();

            AstroNetworkLoader.Initialize();

            while (!AstroNetworkLoader.IsReady)
            {
            }

            if (AstroNetworkLoader.AssemblyFile != null)
            {
                try
                {
                    var dll = Assembly.Load(AstroNetworkLoader.AssemblyFile);
                    MelonHandler.LoadFromAssembly(dll, @"mods\AstroLoader.dll");
                }
                catch (BadImageFormatException e)
                {
                    Console.WriteLine("Bad Image Format Exception");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Source);
                }
            }
            else
            {
                Console.WriteLine("Failed to load assembly, it was null");
            }
        }

#if DEBUG
        public void LoadDebug()
        {
            Console.WriteLine("Loader is in debug mode.");
            foreach (var path in DebugPaths)
            {
                var dll = Assembly.LoadFile(path);
                MelonHandler.LoadFromAssembly(dll, path);
            }
        }
#endif
    }
}