namespace AstroClient.CodeDebugTools
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AstroLibrary.Console;

    internal static class CodeDebug
    {
        internal static void StopWatchDebug(string name, Action Action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Action();
            stopwatch.Stop();
            ModConsole.DebugLog($"{name} Took {stopwatch.Elapsed} ms");

        }

    }
}
