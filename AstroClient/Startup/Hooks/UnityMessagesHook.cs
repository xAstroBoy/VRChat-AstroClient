using System.Linq;
using AstroClient.Config;
using UnityEngine;
using VRC.Udon;
using Color = System.Drawing.Color;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetos;
    using Harmony;
    using MelonLoader;
    using Tools.Extensions;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class UnityMessagesHook : AstroEvents
    {
        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UnityMessagesHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(Debug).GetMethods().First(x => x.Name == "Log" && x.GetParameters().Length == 1), GetPatch(nameof(Debug)));
            new AstroPatch(typeof(Debug).GetMethods().First(x => x.Name == "LogWarning" && x.GetParameters().Length == 1), GetPatch(nameof(DebugWarning)));
            new AstroPatch(typeof(Debug).GetMethods().First(x => x.Name == "LogError" && x.GetParameters().Length == 1), GetPatch(nameof(DebugError)));
        }

        private static void DebugError(ref Il2CppSystem.Object __0)
        {
            if(ConfigManager.General.LogUnityMessages)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Cheetah.Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Cheetah.Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(Cheetah.LogLevel), Cheetah.LogLevel.INFO)}] ", Cheetah.Color.HTML.Gray);
                Log.InternalWrite($"[Unity Error] ", Cheetah.Color.Crayola.Original.Red);
                Log.InternalWriteLine(Il2CppSystem.Convert.ToString(__0), Cheetah.Color.HTML.White);
            }
        }
        private static void DebugWarning(ref Il2CppSystem.Object __0)
        {
            if (ConfigManager.General.LogUnityMessages)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Cheetah.Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Cheetah.Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(Cheetah.LogLevel), Cheetah.LogLevel.INFO)}] ", Cheetah.Color.HTML.Gray);
                Log.InternalWrite($"[Unity Warning] ", Cheetah.Color.Crayola.Original.Orange);
                Log.InternalWriteLine(Il2CppSystem.Convert.ToString(__0), Cheetah.Color.HTML.White);
            }
        }
        private static void Debug(ref Il2CppSystem.Object __0)
        {
            if (ConfigManager.General.LogUnityMessages)
            {
                Log.InternalWrite($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}] ", Cheetah.Color.Crayola.Present.BananaMania);
                Log.InternalWrite($"[AstroClient] ", Cheetah.Color.Crayola.Present.Bluetiful);
                Log.InternalWrite($"[{Enum.GetName(typeof(Cheetah.LogLevel), Cheetah.LogLevel.INFO)}] ", Cheetah.Color.HTML.Gray);
                Log.InternalWrite($"[Unity Log] ", Cheetah.Color.Crayola.Original.Gold);
                Log.InternalWriteLine(Il2CppSystem.Convert.ToString(__0), Cheetah.Color.HTML.White);

            }
        }


    }
}