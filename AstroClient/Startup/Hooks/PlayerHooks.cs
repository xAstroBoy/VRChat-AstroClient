
using System.Linq;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Patching;
using Il2CppSystem;
using VRC;

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
            new AstroPatch(typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.Start)), null, GetPatch(nameof(VRCPlayerStartPatch)));
            new AstroPatch(typeof(VRCPlayer).GetMethod(nameof(VRCPlayer.Awake)), null, GetPatch(nameof(OnVRCPlayerAwake)));
            MethodInfo SetupFlagsMethod = typeof(VRCPlayer).GetMethods().First((MethodInfo mi) => mi.Name.StartsWith("Method_Public_Void_Hashtable_Boolean_"));
            new AstroPatch(SetupFlagsMethod, null, GetPatch(nameof(Internal_OnSetupFlagsReceived)));



            new AstroPatch(typeof(Player).GetMethod(nameof(Player.Awake)), null, GetPatch(nameof(PlayerAwakePatch)));
            new AstroPatch(typeof(Player).GetMethod(nameof(Player.Start)), null, GetPatch(nameof(PlayerStartPatch)));

        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(PlayerHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }
        private static void PlayerAwakePatch(Player __instance) => ClientEventActions.OnPlayerAwake.SafetyRaiseWithParams(__instance);
        private static void PlayerStartPatch(Player __instance) => ClientEventActions.OnPlayerStart.SafetyRaiseWithParams(__instance);


        private static void VRCPlayerStartPatch(VRCPlayer __instance) => ClientEventActions.OnVRCPlayerStart.SafetyRaiseWithParams(__instance);

        private static void OnVRCPlayerAwake(VRCPlayer __instance) => ClientEventActions.OnVRCPlayerAwake.SafetyRaiseWithParams(__instance);

        private static void Internal_OnSetupFlagsReceived(VRCPlayer __instance, Il2CppSystem.Collections.Hashtable __0)
        {
            if (__0 == null)
            {
                return;
            }
            ClientEventActions.OnSetupFlagsReceived.SafetyRaiseWithParams(__instance, __0);

        }

    }
}