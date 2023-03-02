using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Patching;
using System.Linq;
using VRC;
using VRC.Core;

namespace AstroClient.Startup.Hooks
{
    using HarmonyLib;
    using System.Reflection;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class RoomManagerHooks : AstroEvents
    {
        internal override void ExecutePriorityPatches()
        {
            typeof(RoomManager).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name.StartsWith("Method_Public_Static_Boolean_ApiWorld_ApiWorldInstance_String_Int32_")).ToList().ForEach(m => new AstroPatch(m, null, GetPatch(nameof(OnEnterWorldEvent))));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(RoomManagerHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }
        private static void OnEnterWorldEvent(ApiWorld __0, ApiWorldInstance __1) => ClientEventActions.OnEnterWorld.SafetyRaiseWithParams(__0, __1);

    }
}