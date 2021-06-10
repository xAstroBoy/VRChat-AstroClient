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