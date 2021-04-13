﻿namespace AstroLoader
{
    using AstroLibrary;
    using MelonLoader;
    using System;
    using System.Reflection;

    public class AstroLoader : MelonMod
    {
        public static byte[] AssemblyFile;

        public static event EventHandler Event_OnUpdate;

        public static event EventHandler Event_LateUpdate;

        public static event EventHandler Event_VRChat_OnUiManagerInit;

        public static event EventHandler Event_OnLevelLoaded;

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
                        if (type.BaseType == typeof(ModBase))
                        {
                            //Debug.Log($"Loading -> {type}");
                            ModBase mod = dll.CreateInstance(type.ToString(), true) as ModBase;
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
