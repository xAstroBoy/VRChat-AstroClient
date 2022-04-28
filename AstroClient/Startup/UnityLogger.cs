using System;
using AstroClient.ClientActions;
using AstroClient.Config;
using Cheetah;

namespace AstroClient.Startup
{

    internal class UnityLogger : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnUnityLog += OnUnityLog;
            ClientEventActions.OnUnityWarning += OnUnityWarning;
            ClientEventActions.OnUnityError += OnUnityError;

        }

        private void OnUnityLog(string message)
        {
            if (ConfigManager.General.LogUnityMessages)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(LogLevel), LogLevel.INFO)}] ", Color.HTML.Gray);
                Log.InternalWrite($"[Unity Log] ", Color.Crayola.Original.Gold);
                Log.InternalWriteLine(message, Color.HTML.White);

            }

        }

        private void OnUnityWarning(string message)
        {
            if (ConfigManager.General.LogUnityWarnings)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(LogLevel), LogLevel.INFO)}] ", Color.HTML.Gray);
                Log.InternalWrite($"[Unity Warning] ", Color.Crayola.Original.Orange);
                Log.InternalWriteLine(message, Color.HTML.White);
            }

        }

        private void OnUnityError(string message)
        {
            if (ConfigManager.General.LogUnityErrors)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(LogLevel), LogLevel.INFO)}] ", Color.HTML.Gray);
                Log.InternalWrite($"[Unity Error] ", Color.Crayola.Original.Red);
                Log.InternalWriteLine(message, Color.HTML.White);
            }

        }
    }
}