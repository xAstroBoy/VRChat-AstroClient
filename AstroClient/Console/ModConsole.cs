using AstroClient.variables;
using Il2CppSystem.Text.RegularExpressions;
using MelonLoader;
using RubyButtonAPI;
using System;
using System.Text;

namespace AstroClient.ConsoleUtils
{
    public class ModConsole
    {

        public static void LogExc(Il2CppSystem.Exception e)
        {
            MelonLogger.Msg($"Exception Message : {e.Message}");
            MelonLogger.Msg($"Exception StackTrace : {e.StackTrace}");
            MelonLogger.Msg($"Exception TargetSite : {e.TargetSite}");
            MelonLogger.Msg($"Exception Source : {e.Source}");

        }

        public static void WarningExc(Il2CppSystem.Exception e)
        {
            MelonLogger.Warning($"Exception Message : {e.Message}");
            MelonLogger.Warning($"Exception StackTrace : {e.StackTrace}");
            MelonLogger.Warning($"Exception TargetSite : {e.TargetSite}");
            MelonLogger.Warning($"Exception Source : {e.Source}");
        }

        public static void ErrorExc(Il2CppSystem.Exception e)
        {
            MelonLogger.Error($"Exception Message : {e.Message}");
            MelonLogger.Error($"Exception StackTrace : {e.StackTrace}");
            MelonLogger.Error($"Exception TargetSite : {e.TargetSite}");
            MelonLogger.Error($"Exception Source : {e.Source}");
        }


        public static void DebugLogExc(Il2CppSystem.Exception e)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Msg($"[ASTRODEBUG] Exception Message : {e.Message}");
                MelonLogger.Msg($"[ASTRODEBUG] Exception StackTrace : {e.StackTrace}");
                MelonLogger.Msg($"[ASTRODEBUG] Exception TargetSite : {e.TargetSite}");
                MelonLogger.Msg($"[ASTRODEBUG] Exception Source : {e.Source}");
            }
        }
        public static void DebugWarningExc(Il2CppSystem.Exception e)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Warning($"[ASTRODEBUG] Exception Message : {e.Message}");
                MelonLogger.Warning($"[ASTRODEBUG] Exception StackTrace : {e.StackTrace}");
                MelonLogger.Warning($"[ASTRODEBUG] Exception TargetSite : {e.TargetSite}");
                MelonLogger.Warning($"[ASTRODEBUG] Exception Source : {e.Source}");
            }
        }

        public static void DebugErrorExc(Il2CppSystem.Exception e)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Error($"[ASTRODEBUG] Exception Message : {e.Message}");
                MelonLogger.Error($"[ASTRODEBUG] Exception StackTrace : {e.StackTrace}");
                MelonLogger.Error($"[ASTRODEBUG] Exception TargetSite : {e.TargetSite}");
                MelonLogger.Error($"[ASTRODEBUG] Exception Source : {e.Source}");
            }
        }

        public static void LogExc(System.Exception e)
        {
            MelonLogger.Msg($"Exception Message : {e.Message}");
            MelonLogger.Msg($"Exception StackTrace : {e.StackTrace}");
            MelonLogger.Msg($"Exception TargetSite : {e.TargetSite}");
            MelonLogger.Msg($"Exception Source : {e.Source}");

        }

        public static void WarningExc(System.Exception e)
        {
            MelonLogger.Warning($"Exception Message : {e.Message}");
            MelonLogger.Warning($"Exception StackTrace : {e.StackTrace}");
            MelonLogger.Warning($"Exception TargetSite : {e.TargetSite}");
            MelonLogger.Warning($"Exception Source : {e.Source}");
        }

        public static void ErrorExc(System.Exception e)
        {
            MelonLogger.Error($"Exception Message : {e.Message}");
            MelonLogger.Error($"Exception StackTrace : {e.StackTrace}");
            MelonLogger.Error($"Exception TargetSite : {e.TargetSite}");
            MelonLogger.Error($"Exception Source : {e.Source}");
        }


        public static void DebugLogExc(System.Exception e)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Msg($"[ASTRODEBUG] Exception Message : {e.Message}");
                MelonLogger.Msg($"[ASTRODEBUG] Exception StackTrace : {e.StackTrace}");
                MelonLogger.Msg($"[ASTRODEBUG] Exception TargetSite : {e.TargetSite}");
                MelonLogger.Msg($"[ASTRODEBUG] Exception Source : {e.Source}");
            }
        }
        public static void DebugWarningExc(System.Exception e)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Warning($"[ASTRODEBUG] Exception Message : {e.Message}");
                MelonLogger.Warning($"[ASTRODEBUG] Exception StackTrace : {e.StackTrace}");
                MelonLogger.Warning($"[ASTRODEBUG] Exception TargetSite : {e.TargetSite}");
                MelonLogger.Warning($"[ASTRODEBUG] Exception Source : {e.Source}");
            }
        }

        public static void DebugErrorExc(System.Exception e)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Error($"[ASTRODEBUG] Exception Message : {e.Message}");
                MelonLogger.Error($"[ASTRODEBUG] Exception StackTrace : {e.StackTrace}");
                MelonLogger.Error($"[ASTRODEBUG] Exception TargetSite : {e.TargetSite}");
                MelonLogger.Error($"[ASTRODEBUG] Exception Source : {e.Source}");
            }
        }




        public static void Log(string text, ConsoleColor color)
        {
            MelonLogger.Msg(color, $"{text}");
        }

        
        public static void Log(string text)
        {
            MelonLogger.Msg($"{text}");
        }


        public static void Warning(string text)
        {
            MelonLogger.Warning($"{text}");
        }

        public static void Error(string text)
        {
            MelonLogger.Error($"{text}");
        }


        public static void DebugLog(string text)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Msg($"[ASTRODEBUG] {text}");
            }
        }
        public static void DebugWarning(string text)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Warning($"[ASTRODEBUG] {text}");
            }
        }

        public static void DebugError(string text)
        {
            if (Bools.isDebugMode)
            {
                MelonLogger.Error($"[ASTRODEBUG] {text}");
            }
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
                MelonLogger.Msg(": Debug Info enabled");
            }
            else
            {
                MelonLogger.Msg(": Debug Info disabled");
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