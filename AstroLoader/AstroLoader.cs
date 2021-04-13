namespace AstroLoader
{
    using MelonLoader;
    using System;
    using System.Reflection;

    public class AstroLoader : MelonMod
    {
        public static byte[] AssemblyFile;

        public AstroLoader()
        {
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
                    Type[] types = dll.GetTypes();

                    foreach (Type type in types)
                    {
                        if (type.BaseType.Name.Contains("AstroClient"))
                        {
                            Console.WriteLine($"Loading -> {type}");
                            dll.CreateInstance(type.ToString(), true);
                        }
                    }
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
    }
}
