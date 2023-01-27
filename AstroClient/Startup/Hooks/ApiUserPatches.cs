using System.Reflection;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Patching;
using AstroClient.xAstroBoy.Utility;
using HarmonyLib;
using VRC;
using VRC.Core;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    #endregion Imports

    [Obfuscation(Feature = "HarmonyRenamer")]
    internal class ApiUserPatches : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerJoin += PlayerJoin;
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


        private void PlayerJoin(Player player)
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

        //private void Setusers()
        //{
        //    foreach (var user in Resources.FindObjectsOfTypeAll<VRC.Player>())
        //    {
        //        if (user != null)
        //        {
        //            if(user.field_Private_APIUser_0 != null)
        //            {
        //                if (user.prop_APIUser_0.IsSelf) continue;
        //                user.prop_APIUser_0._allowAvatarCopying_k__BackingField = true;
        //                user.prop_APIUser_0.allowAvatarCopying = true;
        //            }
        //        }
        //    }
        //}


    }
}