using AstroClient.febucci;
using AstroClient.febucci.Utilities;
using AstroClient.Tools.Extensions;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using Cheetos;
    using System.Reflection;
    using xAstroBoy.Utility;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class UserEventCellPatches : AstroEvents
    {
        //internal static

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(UserEventCellPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            new AstroPatch(typeof(MonoBehaviourPublicTMteCaSiImdiCoUnique).GetMethod(nameof(MonoBehaviourPublicTMteCaSiImdiCoUnique.Method_Public_Void_String_Single_Sprite_0)), null, GetPatch(nameof(ShowHudNotifier)));
            new AstroPatch(typeof(MonoBehaviourPublicTMteCaSiImdiCoUnique).GetMethod(nameof(MonoBehaviourPublicTMteCaSiImdiCoUnique.OnDisable)), null, GetPatch(nameof(RemoveTextAnimator)));
        }

        private static void ShowHudNotifier(ref MonoBehaviourPublicTMteCaSiImdiCoUnique __instance, ref string __0)
        {
            if (__instance != null)
            {
                if (__instance.text != null)
                {
                    __instance.text.richText = true;
                    if (__0.NeedsTextAnimator())
                    {
                        var anim = __instance.text.gameObject.GetOrAddComponent<TextAnimator>();
                        if (anim != null)
                        {
                            anim.ShowAllCharacters(true);
                            anim.Safe_SetText(__0);
                        }
                    }
                }
            }
        }

        private static void RemoveTextAnimator(ref MonoBehaviourPublicTMteCaSiImdiCoUnique __instance)
        {
            if (__instance != null)
            {
                foreach(var anim in __instance.text.GetComponentsInChildren<TextAnimator>())
                {
                    anim.DestroyMeLocal(true);
                }
            }
        }
    }
}