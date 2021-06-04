namespace AstroClient.AntiCrash
{
	using AstroLibrary.Console;

	public static class AntiCrashUtils
    {
        /// <summary>
        /// This is temporary while I figure out things
        /// </summary>
        /// <param name="msg"></param>
        public static void TempLog(string msg)
        {
            ModConsole.CheetoLog($"[ACS] {msg}");
        }
    }
}