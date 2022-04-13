using System;
using AstroClient.Config;

namespace AstroClient.Startup
{

    internal class UnityLogger : AstroEvents
    {
        internal override void OnUnityLog(string message)
        {
            if (ConfigManager.General.LogUnityMessages)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Cheetah.Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Cheetah.Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(Cheetah.LogLevel), Cheetah.LogLevel.INFO)}] ", Cheetah.Color.HTML.Gray);
                Log.InternalWrite($"[Unity Log] ", Cheetah.Color.Crayola.Original.Gold);
                Log.InternalWriteLine(message, Cheetah.Color.HTML.White);

            }

        }

        internal override void OnUnityWarning(string message)
        {
            if (ConfigManager.General.LogUnityWarnings)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Cheetah.Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Cheetah.Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(Cheetah.LogLevel), Cheetah.LogLevel.INFO)}] ", Cheetah.Color.HTML.Gray);
                Log.InternalWrite($"[Unity Warning] ", Cheetah.Color.Crayola.Original.Orange);
                Log.InternalWriteLine(message, Cheetah.Color.HTML.White);
            }

        }

        internal override void OnUnityError(string message)
        {
            if (ConfigManager.General.LogUnityErrors)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Cheetah.Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Cheetah.Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(Cheetah.LogLevel), Cheetah.LogLevel.INFO)}] ", Cheetah.Color.HTML.Gray);
                Log.InternalWrite($"[Unity Error] ", Cheetah.Color.Crayola.Original.Red);
                Log.InternalWriteLine(message, Cheetah.Color.HTML.White);
            }

        }
    }
}