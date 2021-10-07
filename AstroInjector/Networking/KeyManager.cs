namespace AstroInjector
{
    using AstroNetworkingLibrary.Serializable;
    using System;
    using System.IO;

    internal static class KeyManager
    {
        internal static AuthData Data;

        internal static bool IsAuthed { get; set; } = false;

        internal static bool IsReady = false;

        internal static void ReadKey()
        {
            string keyPath = $@"{Environment.CurrentDirectory}\CheetoAuth\key.txt";
            string keyPathBad = $@"{Environment.CurrentDirectory}\CheetoAuth\key.txt.txt";
            string keyPathBad2 = $@"{Environment.CurrentDirectory}\CheetoAuth\key";

            if (File.Exists(keyPathBad))
            {
                File.Move(keyPathBad, keyPath);
            }

            if (File.Exists(keyPathBad2))
            {
                File.Move(keyPathBad2, keyPath);
            }

            if (File.Exists(keyPath))
            {
                Data = new AuthData(0, File.ReadAllText(keyPath));
            }
            else
            {
                Console.Beep();
                Environment.Exit(0);
            }
        }
    }
}