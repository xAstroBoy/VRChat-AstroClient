namespace AstroLibrary.Console
{
	using System;
	using System.Diagnostics;
	using System.Drawing;
	using System.IO;
	using System.Runtime.CompilerServices;
	using System.Threading.Tasks;
	using Console = CheetosConsole.Console;

	public class ModConsole
	{
		public static string ModName = string.Empty;

		public static bool DebugMode = false;

		private static bool HasRenamedOldLogFile = false;

		private static bool HasInitiated = false;

		/// <summary>
		/// Opens the latest log file in Notepad
		/// </summary>
		public static void OpenLatestLogFile()
		{
			string path = Path.Combine(LogsPath, $"{ModName}_Latest.log");
			try
			{
				Process.Start(path);
			}
			catch (Exception e)
			{
				Error($"Failed to open Log: {e.Message} - {path}");
			}
		}

		private static string LogsPath => Path.Combine(Environment.CurrentDirectory, $"External Logs\\{ModName}");

		private static string LatestLogFile => Path.Combine(LogsPath, $"{ModName}_Latest.log");

		private static int LogInt = 0;

		private static int CurrentInt => LogInt++;

		public static string GetNewFileName()
		{
			var result = CurrentInt;
			var newfilename = $"{ModName}-Log-{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} ({result}).log";
			return !File.Exists(Path.Combine(LogsPath, newfilename)) ? Path.Combine(LogsPath, newfilename) : GetNewFileName();
		}

		public static void ReplaceOldLatestFile()
		{
			var tmp = GetNewFileName();
			if (File.Exists(LatestLogFile))
			{
				File.Move(LatestLogFile, tmp);
			}
		}

		public static void InitLogsSetup()
		{
			if (!HasInitiated)
			{
				if (!Directory.Exists(LogsPath))
				{
					Directory.CreateDirectory(LogsPath);
				}
				if (!HasRenamedOldLogFile)
				{
					ReplaceOldLatestFile();
					HasRenamedOldLogFile = true;
				}
				HasInitiated = true;
			}
		}

		public static void Write(string msg)
		{
			if (!HasInitiated)
			{
				InitLogsSetup();
			}

			ConsoleMutex.WaitOne();
			File.AppendAllText(LatestLogFile, msg);
			ConsoleMutex.ReleaseMutex();
		}

		public enum LogTypes
		{
			LOG,
			WARNING,
			ERROR,
			DEBUG_LOG,
			DEBUG_WARNING,
			DEBUG_ERROR,
			ANTI_CRASH,
			CHEETOS_LOG
		}

		public static void LogExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			PrintCallerTag(callerName, callerLine);
			Exception(e as Exception, LogTypes.LOG);
		}

		public static void WarningExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			PrintCallerTag(callerName, callerLine);
			Exception(e as Exception, LogTypes.WARNING);
		}

		public static void ErrorExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			PrintCallerTag(callerName, callerLine);
			Exception(e as Exception, LogTypes.ERROR);
		}

		public static void DebugLogExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			PrintCallerTag(callerName, callerLine);
			Exception(e as Exception, LogTypes.DEBUG_LOG);
		}

		public static void DebugWarningExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			PrintCallerTag(callerName, callerLine);
			Exception(e as Exception, LogTypes.DEBUG_WARNING);
		}

		public static void DebugErrorExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			PrintCallerTag(callerName, callerLine);
			Exception(e as Exception, LogTypes.DEBUG_ERROR);
		}

		public static void Log(string msg, Color? textcolor = null)
		{
			if (textcolor == null)
			{
				textcolor = Color.PapayaWhip;
			}
			PrintTags(LogTypes.LOG);
			PrintLine(msg, textcolor.Value);
		}

		public static void Warning(string msg, Color? textcolor = null)
		{
			if (textcolor == null)
			{
				textcolor = Color.Yellow;
			}
			PrintTags(LogTypes.WARNING);
			PrintLine(msg, textcolor.Value);
		}

		public static void Error(string msg, Color? textcolor = null)
		{
			if (textcolor == null)
			{
				textcolor = Color.Red;
			}
			PrintTags(LogTypes.ERROR);
			PrintLine(msg, textcolor.Value);
		}

		/// <summary>
		/// I did this because I can trace the references easier, as I tend to do a lot of console spam during development.
		/// I know you'll never understand me :3
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="textcolor"></param>
		public static void CheetoLog(string msg, Color? textcolor = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			if (!DebugMode)
			{
				return;
			}
			if (textcolor == null)
			{
				textcolor = Color.PapayaWhip;
			}
			PrintTags(LogTypes.CHEETOS_LOG);
			PrintCallerTag(callerName, callerLine);
			PrintLine(msg, textcolor.Value);
		}

		public static void DebugLog(string msg, Color? textcolor = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			if (!DebugMode)
			{
				return;
			}
			if (textcolor == null)
			{
				textcolor = Color.PapayaWhip;
			}
			PrintTags(LogTypes.DEBUG_LOG);
			PrintCallerTag(callerName, callerLine);
			PrintLine(msg, textcolor.Value);
		}

		public static void DebugWarning(string msg, Color? textcolor = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			if (!DebugMode)
			{
				return;
			}
			if (textcolor == null)
			{
				textcolor = Color.Yellow;
			}
			PrintTags(LogTypes.DEBUG_LOG);
			PrintCallerTag(callerName, callerLine);
			PrintLine(msg, textcolor.Value);
		}

		public static void DebugError(string msg, Color? textcolor = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			if (!DebugMode)
			{
				return;
			}
			if (textcolor == null)
			{
				textcolor = Color.Red;
			}
			PrintTags(LogTypes.DEBUG_LOG);
			PrintCallerTag(callerName, callerLine);
			PrintLine(msg, textcolor.Value);
		}

		public static void AntiCrash(string msg, Color? textcolor = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			if (!DebugMode)
			{
				return;
			}
			if (textcolor == null)
			{
				textcolor = Color.Red;
			}
			PrintTags(LogTypes.ANTI_CRASH);
			PrintCallerTag(callerName, callerLine);
			PrintLine(msg, textcolor.Value);
		}

		public static void Exception<T>(T e, LogTypes logType = LogTypes.LOG, Color? color = null, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
		{
			if (logType == LogTypes.DEBUG_LOG || logType == LogTypes.DEBUG_WARNING || (logType == LogTypes.DEBUG_ERROR && !DebugMode))
			{
				return;
			}
			if (color == null)
			{
				color = Color.Red;
			}

			PrintTags(logType);

			PrintLine(); // Basically an easy way to newline

			var message = (e as Exception).Message;
			var stackTrace = (e as Exception).StackTrace;
			var targetSite = (e as Exception).TargetSite;
			var source = (e as Exception).Source;

			PrintCallerTag(callerName, callerLine);
			PrintLine(); // Basically an easy way to newline
			PrintLine($"Exception Message: {message}", color.Value);
			PrintLine($"Exception StackTrace: {stackTrace}", color.Value);
			PrintLine($"Exception TargetSite: {targetSite}");
			PrintLine($"Exception Source: {source}");
		}

		public static void PrintLine(string msg = "", Color? color = null)
		{
			ConsoleMutex.WaitOne();
			Console.Write(msg + Environment.NewLine, color.Value);
			ConsoleMutex.ReleaseMutex();
			ConsoleMutex.WaitOne();
			Write(msg + Environment.NewLine);
			ConsoleMutex.ReleaseMutex();
		}

		private static void PrintTags(LogTypes logType = LogTypes.LOG)
		{
			PrintTimestamp();
			PrintModStamp();

			switch (logType)
			{
				case LogTypes.LOG:
					PrintLogTag();
					break;

				case LogTypes.WARNING:
					PrintWarningTag();
					break;

				case LogTypes.ERROR:
					PrintErrorTag();
					break;

				case LogTypes.DEBUG_LOG:
					PrintDebugLogTag();
					break;

				case LogTypes.DEBUG_WARNING:
					PrintDebugWarningTag();
					break;

				case LogTypes.DEBUG_ERROR:
					PrintDebugErrorTag();
					break;

				case LogTypes.ANTI_CRASH:
					PrintAntiCrashTag();
					break;

				case LogTypes.CHEETOS_LOG:
					PrintAntiCrashTag();
					break;
			}
		}

		private static void PrintCallerTag(string callerName, int callerLine)
		{
			Console.Write("[", Color.White);
			Console.Write(callerName, Color.Olive);
			Console.Write(":", Color.White);
			Console.Write(callerLine.ToString(), Color.Green);
			Console.Write("]: ", Color.White);
			Task.Run(() => { Write("[LOG]: "); });
		}

		private static void PrintAntiCrashTag()
		{
			Console.Write("[", Color.White);
			Console.Write("LOG", Color.PaleVioletRed);
			Console.Write("]: ", Color.White);
			Task.Run(() => { Write("[ANTICRASH]: "); });
		}

		private static void PrintLogTag()
		{
			Console.Write("[", Color.White);
			Console.Write("LOG", Color.Aqua);
			Console.Write("]: ", Color.White);
			Task.Run(() => { Write("[LOG]: "); });
		}

		private static void PrintWarningTag()
		{
			Console.Write("[", Color.White);
			Console.Write("WARNING", Color.Orange);
			Console.Write("]: ", Color.White);
			Task.Run(() => { Write("[WARNING]: "); });
		}

		private static void PrintErrorTag()
		{
			Console.Write("[", Color.White);
			Console.Write("ERROR", Color.Red);
			Console.Write("]: ", Color.White);
			Task.Run(() => { Write("[ERROR]: "); });
		}

		private static void PrintDebugLogTag()
		{
			Console.Write("[", Color.White);
			Console.Write("DEBUG LOG", Color.Aquamarine);
			Console.Write("] ", Color.White);
			Task.Run(() => { Write("[DEBUG LOG]: "); });
		}

		private static void PrintDebugWarningTag()
		{
			Console.Write("[", Color.White);
			Console.Write("DEBUG WARNING", Color.Orange);
			Console.Write("] ", Color.White);
			Task.Run(() => { Write("[DEBUG WARNING]: "); });
		}

		private static void PrintDebugErrorTag()
		{
			Console.Write("[", Color.White);
			Console.Write("DEBUG ERROR", Color.Red);
			Console.Write("] ", Color.White);
			Task.Run(() => { Write("[DEBUG ERROR]: "); });
		}

		private static void PrintModStamp()
		{
			Console.Write("[", Color.White);
			Console.Write(ModName, Color.Gold);
			Console.Write("] ", Color.White);
			Task.Run(() => { Write($"[{ModName}] "); });
		}

		private static void PrintTimestamp()
		{
			string time = DateTime.Now.ToString("HH:mm:ss.fff");
			Console.Write("[", Color.White);
			Console.Write(time, Color.LightGreen);
			Console.Write("] ", Color.White);
			Task.Run(() => { Write($"[{time}] "); });
		}

		private static readonly System.Threading.Mutex ConsoleMutex = new System.Threading.Mutex();
	}
}