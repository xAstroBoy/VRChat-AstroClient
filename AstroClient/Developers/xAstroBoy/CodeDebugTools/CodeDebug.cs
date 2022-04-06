﻿namespace AstroClient.xAstroBoy.CodeDebugTools
{
    using System;
    using System.Diagnostics;

    internal static class CodeDebug
    {
        internal static void StopWatchDebug(string name, Action Action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Action();
            stopwatch.Stop();
            Log.Debug($"{name} Took {stopwatch.Elapsed} ms");

        }

    }
}
