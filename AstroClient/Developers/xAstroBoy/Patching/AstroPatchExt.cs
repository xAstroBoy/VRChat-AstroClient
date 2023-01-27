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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">Targeted Class</param>
        /// <param name="TargetPatch">Harmony patch</param>
        /// <param name="ShowSuccessFulPatches">Default is false, this is spammy af</param>
        /// <returns></returns>
        internal static int PatchAllWith<T>(this T type, HarmonyMethod TargetPatch, bool ShowSuccessFulPatches = false) where T : System.Type
        {
            var flags =  BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            int Success = 0;
            foreach (var method in type.GetMethods(flags))
            {
                if (method.FullDescription().Contains(type.FullDescription()))
                {
                    var patch = new AstroPatch(method, TargetPatch, showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: ShowSuccessFulPatches);
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