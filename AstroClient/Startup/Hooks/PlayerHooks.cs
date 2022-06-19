
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Extensions;

namespace AstroClient.Startup.Hooks
{
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Utility;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class PlayerHooks : AstroEvents
    {


        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.Start)), null, GetPatch(nameof(PlayerStartPatch)));
            
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(PlayerHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private static void PlayerStartPatch(VRCPlayer __instance)
        {
            ClientEventActions.OnPlayerStart.SafetyRaiseWithParams(__instance);
        }


    }
}