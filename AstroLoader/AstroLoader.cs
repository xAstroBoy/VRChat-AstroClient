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
        public static string DebugPath1 = Environment.CurrentDirectory + @"\Debug\AstroClient.dll";
        public static string DebugPath2 = Environment.CurrentDirectory + @"\Debug\DontTouchMyClient.dll";
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
            var dll1 = Assembly.LoadFile(DebugPath1);
            var dll2 = Assembly.LoadFile(DebugPath2);
            MelonHandler.LoadFromAssembly(dll1, DebugPath1);
            MelonHandler.LoadFromAssembly(dll2, DebugPath2);
        }

#endif
    }
}