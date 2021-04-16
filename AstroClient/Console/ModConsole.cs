using AstroClient.variables;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Console = CheetosConsole.Console;

namespace AstroClient.ConsoleUtils
{
    public class ModConsole
    {
        private static bool HasRenamedOldLogFile = false;

        private static bool HasInitiated = false;

        private static bool DebugMode
        {
            get
            {
                return Bools.IsDebugMode;
            }
        }

        private static string LogsPath
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, $"External Logs\\{BuildInfo.Name}");
            }
        }

        private static string LatestLogFile
        {
            get
            {
                return Path.Combine(LogsPath, BuildInfo.Name + "_Latest.log");
            }
        }

        private static int LogInt = 0;

        private static int GetCurrentInt()
        {
            return LogInt++;
        }

        public static string GetNewFileName()
        {
            var result = GetCurrentInt();
            var newfilename = BuildInfo.Name + "-Log-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " (" + result + ").log";
            if (!File.Exists(Path.Combine(LogsPath, newfilename)))
            {
                return Path.Combine(LogsPath, newfilename);
            }
            else
            {
                return GetNewFileName();
            }
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
            DEBUG_ERROR
        }

        public static void LogExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
        {
            PrintCallerTag(callerName, callerLine);
            Exception((e as System.Exception), LogTypes.LOG);
        }

        public static void WarningExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
        {
            PrintCallerTag(callerName, callerLine);
            Exception((e as System.Exception), LogTypes.WARNING);
        }

        public static void ErrorExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
        {
            PrintCallerTag(callerName, callerLine);
            Exception((e as System.Exception), LogTypes.ERROR);
        }

        public static void DebugLogExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
        {
            PrintCallerTag(callerName, callerLine);
            Exception((e as System.Exception), LogTypes.DEBUG_LOG);
        }

        public static void DebugWarningExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
        {
            PrintCallerTag(callerName, callerLine);
            Exception((e as System.Exception), LogTypes.DEBUG_WARNING);
        }

        public static void DebugErrorExc<T>(T e, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLine = 0)
        {
            PrintCallerTag(callerName, callerLine);
            Exception((e as System.Exception), LogTypes.DEBUG_ERROR);
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
        public static void CheetoLog(string msg, Color? textcolor = null)
        {
            DebugLog($"[CHEETOS] {msg}", textcolor);
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

        public static void Exception<T>(T e, LogTypes logType = LogTypes.LOG, Color? color = null)
        {
            if (logType == LogTypes.DEBUG_LOG || logType == LogTypes.DEBUG_WARNING || logType == LogTypes.DEBUG_ERROR && !DebugMode)
            {
                return;
            }
            if (color == null)
            {
                color = Color.Red;
            }

            PrintTags(logType);

            PrintLine(); // Basically an easy way to newline

            var message = (e as System.Exception).Message;
            var stackTrace = (e as System.Exception).StackTrace;
            var targetSite = (e as System.Exception).TargetSite;
            var source = (e as System.Exception).Source;

            PrintLine($"Exception Message: {message}", color.Value);
            PrintLine($"Exception StackTrace: {stackTrace}", color.Value);
            PrintLine($"Exception TargetSite: {targetSite}");
            PrintLine($"Exception Source: {source}");
        }

        public static void PrintLine(string msg = "", Color? color = null)
        {
            Console.Write(msg + Environment.NewLine, color.Value);
            Task.Run(() => { Write(msg + Environment.NewLine); });
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
            Console.Write(BuildInfo.Name, Color.Gold);
            Console.Write("] ", Color.White);
            Task.Run(() => { Write($"[{BuildInfo.Name}] "); });
        }

        private static void PrintTimestamp()
        {
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            Console.Write("[", Color.White);
            Console.Write(time, Color.LightGreen);
            Console.Write("] ", Color.White);
            Task.Run(() => { Write($"[{time}] "); });
        }

        private static System.Threading.Mutex ConsoleMutex = new System.Threading.Mutex();
    }
}