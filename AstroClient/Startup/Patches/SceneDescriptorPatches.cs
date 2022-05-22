namespace AstroClient.Startup.Hooks
{
    #region Imports

    using Cheetos;
    using HarmonyLib;
    using System.Reflection;
    using xAstroBoy.Utility;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class SceneDescriptorPatches : AstroEvents
    {
        //internal static

        internal override void ExecutePriorityPatches()
        {
            InitPatches();
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyLib.HarmonyMethod GetPatch(string name)
        {
            return new HarmonyLib.HarmonyMethod(typeof(SceneDescriptorPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyHookInit", Exclude = false)]
        internal void InitPatches()
        {
            new AstroPatch(AccessTools.Property(typeof(RoomManager), nameof(RoomManager.field_Private_Static_Boolean_1)).GetMethod, GetPatch(nameof(ForbidPortalDrops)));
        }

        private static bool ForbidPortalDrops(ref bool __result)
        {

            __result = false;
            return false;
        }
    }
}