using System.Reflection;
using AstroClient.febucci;
using AstroClient.febucci.Utilities;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Patching;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.Startup.Patches
{
    #region Imports

    #endregion Imports

    [Obfuscation(Feature = "HarmonyRenamer")]
    internal class UserEventCellPatches : AstroEvents
    {
        //internal static

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }

        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(UserEventCellPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [Obfuscation(Feature = "HarmonyHookInit", Exclude = false)]
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
                        var anim = ComponentUtils.GetOrAddComponent<TextAnimator>(__instance.text.gameObject);
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