using System.Reflection;
using Boo.Lang;
using HarmonyLib;

namespace AstroClient.xAstroBoy.Patching
{
    #region Imports

    #endregion Imports

    internal class UnityClassBlocker<T> where T: UnityEngine.Object
    {
        private readonly BindingFlags TargetedFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

        private List<AstroPatch> Patches = new List<AstroPatch>();
        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(UnityClassBlocker<T>).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        /// <summary>
        /// This executes a return false Prefix in all methods in the class, completely deactivating it and also destroys the instance of the class, if possible.
        /// </summary>
        /// <param name="ShowSuccessFulPatches">Default is false, because is super spammy.</param>
        internal UnityClassBlocker(bool ShowSuccessFulPatches = false)
        {

            int Success = 0;
            foreach (var method in typeof(T).GetMethods(TargetedFlags))
            {
                if (method.FullDescription().Contains(typeof(T).FullDescription()))
                {
                    var patch = new AstroPatch(method, GetPatch(nameof(DestroyAndReturnFalse)), showErrorOnConsole: false, ShowFailedPatches: false, ShowSuccessFulPatches: ShowSuccessFulPatches);
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

            Log.Write($"Blocked {Success} {typeof(T).FullDescription()} Methods.");
        }

        internal static bool DestroyAndReturnFalse(ref T __instance)
        {
            try
            {
                if (__instance != null)
                {
                    UnityEngine.Object.DestroyImmediate(__instance);
                }
            }
            catch{}
            return false;
        }
    }
}