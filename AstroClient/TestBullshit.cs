namespace AstroClient
{
    using System;
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using UnityEngine;

    internal class BullshitTest : AstroEvents
    {
        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(BullshitTest).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void OnApplicationStart()
		{

            new AstroPatch(AccessTools.Property(typeof(Cubemap), nameof(Cubemap.isReadable)).GetMethod, null, null, null, null, GetPatch(nameof(MakeReadableCubeMap)));

            new AstroPatch(AccessTools.Property(typeof(Texture), nameof(Texture.isReadable)).GetMethod, null, null, null, null, GetPatch(nameof(MakeReadableTexture)));


        }


        private static void MakeReadableCubeMap(Cubemap __instance, ref bool __result)
        {
            ModConsole.DebugLog($"Hijacking {__instance.name} Readability.");
            __result = true;
        }

        private static void MakeReadableTexture(Texture __instance, ref bool __result)
        {
            ModConsole.DebugLog($"Hijacking {__instance.name} Readability.");
            __result = true;
        }

    }
}