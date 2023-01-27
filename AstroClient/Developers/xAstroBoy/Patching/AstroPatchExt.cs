using System;
using System.Reflection;
using Boo.Lang;
using HarmonyLib;

namespace AstroClient.xAstroBoy.Patching
{
    #region Imports

    #endregion Imports

    internal static class AstroPatchExt
    {
        /// <summary>
        /// This patches all classes with one type of Prefix patch
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">Targeted Class</param>
        /// <param name="PrefixPatch">Harmony patch</param>
        /// <param name="ShowSuccessFulPatches">Default is false, this is spammy af</param>
        /// <returns>How many successful methods Got patched.</returns>
        internal static int PatchAllMethods<T>(this T type, HarmonyMethod PrefixPatch, bool ShowSuccessFulPatches = false) where T : System.Type
        {
            var flags =  BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            int Success = 0;
            foreach (var method in type.GetMethods(flags))
            {
                if (method.FullDescription().Contains(type.FullDescription()))
                {
                    var patch = new AstroPatch(method, PrefixPatch, showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: ShowSuccessFulPatches);
                    if (patch.isActivePatch)
                    {
                        Success++;
                    }
                }
            }
            return Success;
        }


    }
}