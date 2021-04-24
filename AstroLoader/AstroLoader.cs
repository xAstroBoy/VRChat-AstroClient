using MelonLoader;
using System;

#if DEBUG
#endif

using System.Reflection;

namespace AstroLoader
{
    public class AstroLoader : MelonMod
    {
        public static byte[] AssemblyFile;

#if DEBUG
        public static string DebugPath = Environment.CurrentDirectory + @"\Dependencies\AstroClient.dll";
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
            var dll = Assembly.LoadFile(DebugPath);
            MelonHandler.LoadFromAssembly(dll, DebugPath);
        }

#endif
    }
}