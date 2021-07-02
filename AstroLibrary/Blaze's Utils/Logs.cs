namespace Blaze
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class Logs
	{
		// Console Logs
		private static string lastConsole = string.Empty;
		public static void Msg(string message, ConsoleColor color)
		{
			if (message == lastConsole) return;
			else PushLog(message, color);
		}
		public static void SetTitle(string message) { Console.Title = message; }

		private static void PushLog(string message, ConsoleColor color)
		{
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("[");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(DateTime.Now.ToString("hh:mm:ss tt"));
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("] [");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Blaze's ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Mod");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("] ");
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		// Debug Panel Logs
		public static List<string> DebugLogs = new List<string>();
		private static string lastMsg = string.Empty;

		public static void Debug(string message)
		{
			if (message == lastMsg) return;
			lastMsg = message;
			DebugLogs.Add($"<b>[<color=#34eba8>{DateTime.Now:hh:mm tt}</color>] {message}</b>");
			if (DebugLogs.Count == 25)
			{
				DebugLogs.RemoveAt(0);
			}
			//QM.DM.SetText(string.Join("\n", DebugLogs.Take(25)));
		}

		// Hud Logs
		//private static string lastHud = string.Empty;
		//public static void Hud(string message)
		//{
		//    if (message == lastHud) return;
		//    lastHud = message;
		//    Modules.Hud.Display(message, 5f);
		//}
	}
}
