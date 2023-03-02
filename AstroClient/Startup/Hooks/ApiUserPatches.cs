using System;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Patching;
using AstroClient.xAstroBoy.Utility;
using HarmonyLib;
using System.Reflection;
using VRC;
using VRC.Core;

namespace AstroClient.Startup.Hooks
{
    [Obfuscation(Feature = "HarmonyRenamer")]
    internal class ApiUserPatches : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerJoin += PlayerJoin;
            ClientEventActions.OnPlayerAwake += PlayerAwake;
        }

        [Obfuscation(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(ApiUserPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            InitPatch();
        }

        private void InitPatch()
        {
            new AstroPatch(AccessTools.Property(typeof(APIUser), nameof(APIUser.allowAvatarCopying)).GetMethod, GetPatch(nameof(ForceAllow_Get)));
            new AstroPatch(AccessTools.Property(typeof(APIUser), nameof(APIUser.allowAvatarCopying)).SetMethod, GetPatch(nameof(ForceAllow_Set)));
            new AstroPatch(typeof(APIUser).GetMethod(nameof(APIUser.UnfriendUser)), GetPatch(nameof(OnUnfriended)));
            new AstroPatch(typeof(APIUser).GetMethod(nameof(APIUser.LocalAddFriend)), GetPatch(nameof(OnFriended)));

        }

        private static bool ForceAllow_Get(ref APIUser __instance, ref bool __result)
        {
            if (__instance != null)
            {
                if (!__instance.IsSelf)
                {
                    __instance._allowAvatarCopying_k__BackingField = true;
                    __result = true;
                    return false;
                }
            }
            return true;
        }

        private static bool ForceAllow_Set(ref APIUser __instance, ref bool __0)
        {
            if (__instance != null)
            {
                if (!__instance.IsSelf)
                {
                    __0 = true;
                    return false;
                }
            }
            return true;
        }
        private static void OnFriended(ref APIUser __0) => ClientEventActions.OnFriended?.SafetyRaiseWithParams(__0);

        private static void OnUnfriended(ref string __0, ref Il2CppSystem.Action __1, ref Il2CppSystem.Action __2) => ClientEventActions.OnUnfriended?.SafetyRaiseWithParams(__0);


        private void PlayerJoin(Player player) => SetPlayerAPIUser(player);

        private void PlayerAwake(Player player) => SetPlayerAPIUser(player);

        internal static void SetPlayerAPIUser(Player player)
        {
            if (player != null)
            {
                var apiuser = player.GetAPIUser();
                if (apiuser != null)
                {
                    if (apiuser.IsSelf) return;
                    apiuser.allowAvatarCopying = true;
                    apiuser._allowAvatarCopying_k__BackingField = true;
                }
            }
        }
    }
}