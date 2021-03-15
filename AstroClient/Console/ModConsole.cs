using AstroClient.variables;
using Il2CppSystem.Text.RegularExpressions;
using MelonLoader;
using RubyButtonAPI;
using Colorful;
using System;
using Console = Colorful.Console;
using System.Drawing;

namespace AstroClient.ConsoleUtils
{
    public class ModConsole
    {
        public enum LogTypes
        {
            LOG,
            WARNING,
            ERROR,
            DEBUG_LOG, 
            DEBUG_WARNING,
            DEBUG_ERROR
        }



        public static void LogExc<T>(T e)
        {
            Exception((e as System.Exception), LogTypes.LOG);
        }

        public static void WarningExc<T>(T e)
        {
            Exception((e as System.Exception), LogTypes.WARNING);

        }

        public static void ErrorExc<T>(T e)
        {
            Exception((e as System.Exception), LogTypes.ERROR);
        }

        public static void DebugLogExc<T>(T e)
        {
            Exception((e as System.Exception), LogTypes.DEBUG_LOG);
        }
        public static void DebugWarningExc<T>(T e)
        {
            Exception((e as System.Exception), LogTypes.DEBUG_WARNING);

        }

        public static void DebugErrorExc<T>(T e)
        {
            Exception((e as System.Exception), LogTypes.DEBUG_ERROR);
        }



        public static void Log(string msg, Color? textcolor = null)
        {
            if (textcolor == null)
            {
                textcolor = Color.White;
            }
            PrintTags(LogTypes.LOG);
            PrintLine(msg, textcolor.Value);
        }
        public static void Warning(string msg, Color? textcolor = null)
        {
            if (textcolor == null)
            {
                textcolor = Color.White;
            }
            PrintTags(LogTypes.WARNING);
            PrintLine(msg, textcolor.Value);
        }

        public static void Error(string msg, Color? textcolor = null)
        {
            if (textcolor == null)
            {
                textcolor = Color.White;
            }
            PrintTags(LogTypes.ERROR);
            PrintLine(msg, textcolor.Value);
        }

        public static void DebugLog(string msg, Color? textcolor = null)
        {
            if (!Bools.isDebugMode)
            {
                return;
            }
            if (textcolor == null)
            {
                textcolor = Color.White;
            }
            PrintTags(LogTypes.DEBUG_LOG);
            PrintLine(msg, textcolor.Value);
        }

        public static void DebugWarning(string msg, Color? textcolor = null)
        {
            if (!Bools.isDebugMode)
            {
                return;
            }
            if (textcolor == null)
            {
                textcolor = Color.White;
            }
            PrintTags(LogTypes.DEBUG_LOG);
            PrintLine(msg, textcolor.Value);
        }


        public static void DebugError(string msg, Color? textcolor = null)
        {
            if (!Bools.isDebugMode)
            {
                return;
            }
            if (textcolor == null)
            {
                textcolor = Color.White;
            }
            PrintTags(LogTypes.DEBUG_LOG);
            PrintLine(msg, textcolor.Value);
        }

        public static void Exception<T>(T e, LogTypes logType = LogTypes.LOG, Color? color = null)
        {
            if (logType == LogTypes.DEBUG_LOG  || logType == LogTypes.DEBUG_WARNING || logType == LogTypes.DEBUG_ERROR && !Bools.isDebugMode)
            {
                return;
            }
            if (color == null)
            {
                color = Color.White;
            }


            PrintTags(logType);

            PrintLine(); // Basically an easy way to newline
            PrintLine($"Exception Message: {(e as System.Exception).Message}", color.Value);
            PrintLine($"Exception StackTrace: {(e as System.Exception).StackTrace}", color.Value);
            PrintLine($"Exception TargetSite: {(e as System.Exception).TargetSite}");
            PrintLine($"Exception Source: {(e as System.Exception).Source}");
        }

        public static void PrintLine(string msg = "", Color? color = null)
        {
            Console.Write(msg + Environment.NewLine, color.Value);
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
        private static void PrintLogTag()
        {
            Console.Write("[", Color.White);
            Console.Write("LOG", Color.Aqua);
            Console.Write("] ", Color.White);
        }


        private static void PrintWarningTag()
        {
            Console.Write("[", Color.White);
            Console.Write("WARNING", Color.Orange);
            Console.Write("] ", Color.White);
        }

        private static void PrintErrorTag()
        {
            Console.Write("[", Color.White);
            Console.Write("ERROR", Color.Red);
            Console.Write("] ", Color.White);
        }




        private static void PrintDebugLogTag()
        {
            Console.Write("[", Color.White);
            Console.Write("DEBUG LOG", Color.Aquamarine);
            Console.Write("] ", Color.White);
        }

        private static void PrintDebugWarningTag()
        {
            Console.Write("[", Color.White);
            Console.Write("DEBUG WARNING", Color.Orange);
            Console.Write("] ", Color.White);
        }


        private static void PrintDebugErrorTag()
        {
            Console.Write("[", Color.White);
            Console.Write("DEBUG ERROR", Color.Red);
            Console.Write("] ", Color.White);
        }

        private static void PrintModStamp()
        {
            Console.Write("[", Color.White);
            Console.Write(BuildInfo.Name, Color.Gold);
            Console.Write("] ", Color.White);
        }

        private static void PrintTimestamp()
        {
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            Console.Write("[", Color.White);
            Console.Write(time, Color.Green);
            Console.Write("] ", Color.White);
        }
    

    public static void ToggleConsole()
        {
            Bools.isDebugMode = !Bools.isDebugMode;
            if (ToggleDebugInfo != null)
            {
                ToggleDebugInfo.setToggleState(Bools.isDebugMode);
            }
            if (Bools.isDebugMode)
            {
                Log("Debug Info enabled", Color.Violet);
            }
            else
            {
                Log("Debug Info disabled", Color.Violet);
            }
        }

        public static void OnLevelLoad()
        {
            if (ToggleDebugInfo != null)
            {
                ToggleDebugInfo.setToggleState(Bools.isDebugMode);
            }
        }

        public static QMToggleButton ToggleDebugInfo;
    }
}