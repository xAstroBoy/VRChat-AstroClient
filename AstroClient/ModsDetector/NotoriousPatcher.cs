
using AstroClient.xAstroBoy.Patching;

namespace AstroClient.ModsDetector
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using MelonLoader;
    using Attribute = System.Attribute;
    using AstroClient.Tools.Extensions;

    internal class NotoriousPatcher : AstroEvents
    {
        internal override void ExecutePriorityPatches()
        {
            MelonCoroutines.Start(AntiNotoConsoleClear());

        }

        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(NotoriousPatcher).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        private static Assembly _NotoriousLoader = null;
        private static Assembly NotoriousLoader
        {
            get
            {
                if (_NotoriousLoader == null)
                {
                    Assembly[] LoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                    if (LoadedAssemblies != null)
                    {
                        for (int i = 0; i < LoadedAssemblies.Length; i++)
                        {
                            Assembly item = LoadedAssemblies[i];
                            var CopyrightAttrib = item.GetAssemblyAttribute<AssemblyCopyrightAttribute>();
                            if (item.FullName.Contains("Notorious-Loader"))
                            {
                                if (CopyrightAttrib != null)
                                {
                                    if (CopyrightAttrib.Copyright.Equals("Created by Meap & Unreal"))
                                    {
                                        Log.Debug("Found Notorious Loader!");
                                        return _NotoriousLoader = item;
                                    }
                                }
                            }
                        }
                    }
                }
                return _NotoriousLoader;
            }
        }

        private static bool Fuck_Notorious_Console_Clear_On_Start()
        {
            Log.Debug("Console.Clear has Been Blocked!");
            ConsoleClearPatch?.Unpatch();
            return false; // FUCK YOU UNREAL <3.
        }

        internal static IEnumerator AntiNotoConsoleClear()
        {

            while (NotoriousLoader == null) yield return null;
            Log.Debug("Notorious Client has Been Loaded, Starting Patcher!");
            ConsoleClearPatch = new AstroPatch(typeof(Console).GetMethod(nameof(Console.Clear)), GetPatch(nameof(Fuck_Notorious_Console_Clear_On_Start)));
            yield return null;
        }

        private static AstroPatch ConsoleClearPatch { get; set; } = null;
    }
}