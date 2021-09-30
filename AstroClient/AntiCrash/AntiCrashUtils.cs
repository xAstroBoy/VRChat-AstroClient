namespace AstroClient.AntiCrash
{
    using AstroLibrary.Console;

    internal static class AntiCrashUtils
    {
        /// <summary>
        /// This is temporary while I figure out things
        /// </summary>
        /// <param name="msg"></param>
        internal static void TempLog(string msg)
        {
            ModConsole.CheetoLog($"[ACS] {msg}");
        }
    }
}