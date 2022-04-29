
using AstroClient.xAstroBoy.Extensions;

namespace AstroClient.Startup.Hooks
{
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using AstroClient.Tools.Extensions;
    using AstroClient.xAstroBoy.Utility;

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class AntiMuteExperiment : AstroEvents
    {


        internal override void ExecutePriorityPatches()
        {
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_0)).GetMethod, GetPatch(nameof(Force_Bool_0)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_1)).GetMethod, GetPatch(nameof(Force_Bool_1)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_2)).GetMethod, GetPatch(nameof(Force_Bool_2)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_3)).GetMethod, GetPatch(nameof(Force_Bool_3)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_4)).GetMethod, GetPatch(nameof(Force_Bool_4)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_5)).GetMethod, GetPatch(nameof(Force_Bool_5)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_6)).GetMethod, GetPatch(nameof(Force_IsInstanceMaster)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_7)).GetMethod, GetPatch(nameof(Force_Bool_7)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_8)).GetMethod, GetPatch(nameof(Force_Bool_8)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_9)).GetMethod, GetPatch(nameof(Force_Bool_9)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_10)).GetMethod, GetPatch(nameof(Force_Bool_10)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_11)).GetMethod, GetPatch(nameof(Force_Bool_11)));
            new AstroPatch(AccessTools.Property(typeof(VRC.Player), nameof(VRC.Player.prop_Boolean_13)).GetMethod, GetPatch(nameof(Force_Bool_13)));


        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(AntiMuteExperiment).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }


        internal static bool Override_IsInstanceMaster { get; set; } = false;

        internal static bool Force_isInstanceMaster { get; set; } = false;

        private static bool Force_IsInstanceMaster(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_IsInstanceMaster) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Force_isInstanceMaster;
                    return false;
                }
            }
            return true;
        }





        internal static bool Override_Bool_0 { get; set; } = false;

        internal static bool Bool_0_Value { get; set; } = false;

        private static bool Force_Bool_0(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_0) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_0_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_1 { get; set; } = false;

        internal static bool Bool_1_Value { get; set; } = false;

        private static bool Force_Bool_1(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_1) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_1_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_11 { get; set; } = false;

        internal static bool Bool_11_Value { get; set; } = false;

        private static bool Force_Bool_11(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_11) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_11_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_12 { get; set; } = false;

        internal static bool Bool_12_Value { get; set; } = false;

        private static bool Force_Bool_12(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_12) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_12_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_13 { get; set; } = false;

        internal static bool Bool_13_Value { get; set; } = false;

        private static bool Force_Bool_13(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_13) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_13_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_2 { get; set; } = false;

        internal static bool Bool_2_Value { get; set; } = false;

        private static bool Force_Bool_2(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_2) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_2_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_3 { get; set; } = false;

        internal static bool Bool_3_Value { get; set; } = false;

        private static bool Force_Bool_3(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_3) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_3_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_4 { get; set; } = false;

        internal static bool Bool_4_Value { get; set; } = false;

        private static bool Force_Bool_4(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_4) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_4_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_5 { get; set; } = false;

        internal static bool Bool_5_Value { get; set; } = false;

        private static bool Force_Bool_5(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_5) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_5_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_7 { get; set; } = false;

        internal static bool Bool_7_Value { get; set; } = false;

        private static bool Force_Bool_7(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_7) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_7_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_8 { get; set; } = false;

        internal static bool Bool_8_Value { get; set; } = false;

        private static bool Force_Bool_8(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_8) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_8_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_9 { get; set; } = false;

        internal static bool Bool_9_Value { get; set; } = false;

        private static bool Force_Bool_9(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_9) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_9_Value;
                    return false;
                }
            }
            return true;
        }
        internal static bool Override_Bool_10 { get; set; } = false;

        internal static bool Bool_10_Value { get; set; } = false;

        private static bool Force_Bool_10(ref VRC.Player __instance, ref bool __result)
        {
            if (!Override_Bool_10) return true;
            if (__instance != null)
            {
                if (!__instance.prop_APIUser_0.IsSelf)
                {
                    __result = Bool_10_Value;
                    return false;
                }
            }
            return true;
        }

    }
}