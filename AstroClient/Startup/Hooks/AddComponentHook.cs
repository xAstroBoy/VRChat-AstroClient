namespace AstroClient.Startup.Hooks
{
    #region Imports

    using Cheetos;
    using System.Reflection;
    using UnityEngine;
    using VRC.Udon;
    using xAstroBoy.Utility;

    #endregion Imports
    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]

    internal class AddComponentHook : AstroEvents
    {

        //internal static 
        private HarmonyLib.Harmony harmony;

        internal override void ExecutePriorityPatches()
        {
            MiscUtils.DelayFunction(1f, new System.Action(() =>
            {
                InitPatches();
            }));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(AddComponentHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            new AstroPatch(typeof(GameObject).GetMethod(nameof(GameObject.AddComponentInternal)), null, GetPatch(nameof(ComponentInternalCheck)));
            new AstroPatch(typeof(GameObject).GetMethod(nameof(GameObject.Internal_AddComponentWithType)), null, GetPatch(nameof(ComponentInternalCheck)));

        }

        private static void ComponentInternalCheck(ref Component __result)
        {
            if (__result is UdonBehaviour)
            {
                ModConsole.DebugLog("A UdonBehaviour has been spawned!");
            }
        }
    }
}