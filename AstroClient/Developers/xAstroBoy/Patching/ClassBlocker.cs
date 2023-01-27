using System;
using System.Reflection;
using Boo.Lang;
using HarmonyLib;

namespace AstroClient.xAstroBoy.Patching
{
    #region Imports

    #endregion Imports

    internal class ClassBlocker
    {
        private static readonly BindingFlags TargetedFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        private static List<AstroPatch> Patches = new List<AstroPatch>();
        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(ClassBlocker).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static));
        }
        /// <summary>
        /// This executes a return false Prefix in all methods in the class, completely deactivating it.
        /// </summary>
        /// <param name="ShowSuccessFulPatches">Default is false, because is super spammy.</param>
        internal ClassBlocker(Type type, bool ShowSuccessFulPatches = false)
        {

            int Success = 0;
            foreach (var method in type.GetMethods(TargetedFlags))
            {
                if (method.FullDescription().Contains(type.FullDescription()))
                {
                    var patch = new AstroPatch(method, GetPatch(nameof(ReturnFalse)), showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: ShowSuccessFulPatches);
                    if (patch.isActivePatch)
                    {
                        if (!Patches.Contains(patch))
                        {
                            Patches.Add(patch);
                        }
                        Success++;
                    }
                }
            }

            Log.Write($"Blocked {Success} {type.FullDescription()} Methods.");
        }

        private static bool ReturnFalse()
        {
            try{} catch{}
            return false;
        }
    }
}