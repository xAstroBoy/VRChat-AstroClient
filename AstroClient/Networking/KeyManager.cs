namespace AstroClient
{
	using System;
	using System.IO;

	internal static class KeyManager
	{
		public static string AuthKey = string.Empty;

		public static bool IsAuthed = false;

		public static void ReadKey()
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