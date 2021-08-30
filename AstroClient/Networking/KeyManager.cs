namespace AstroClient
{
    using System;
    using System.IO;

    internal static class KeyManager
    {
        internal static string AuthKey = string.Empty;

        internal static bool IsAuthed { get; set; } = false;

        internal static bool IsReady = false;

        internal static void ReadKey()
        {
            string keyPath = $@"{Environment.CurrentDirectory}\AstroClient\key.txt";
            string keyPathBad = $@"{Environment.CurrentDirectory}\AstroClient\key.txt.txt";
            string keyPathBad2 = $@"{Environment.CurrentDirectory}\AstroClient\key";

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
                AuthKey = File.ReadAllText(keyPath);
            }
            else
            {
                Console.Beep();
                Environment.Exit(0);
            }
        }
    }
}