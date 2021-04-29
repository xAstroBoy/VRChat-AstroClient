using System;
using System.IO;

namespace AstroClient
{
	internal static class KeyManager
	{
		public static string AuthKey = string.Empty;

		public static bool IsAuthed = false;

		public static void ReadKey()
		{
			string keyPath = Environment.CurrentDirectory + @"\AstroClient\key.txt";

			if (File.Exists(keyPath))
			{
				AuthKey = File.ReadAllText(keyPath);
			}
			else
			{
				System.Console.Beep();
				Environment.Exit(0);
			}
		}
	}
}