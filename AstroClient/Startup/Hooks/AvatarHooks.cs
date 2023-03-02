using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Patching;
using HarmonyLib;
using System.Linq;
using System.Reflection;
using VRC.Core;

namespace AstroClient.Startup.Hooks
{
    using System;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using xAstroBoy.Utility;
    using AvatarLoadingBar = MonoBehaviourPublicSiTeReGrObCoCoObUnique;

    [ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class AvatarHooks : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
            ClientEventActions.OnVRCPlayerAwake += VrcPlayerAwake;
        }

        private void OnApplicationStart() => HookAvatarManager();

        internal override void ExecutePriorityPatches()
        {
            DoPatches();
        }

        [ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(AvatarHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        private void DoPatches()
        {
            foreach (MethodInfo OnAvatarDownloadMethod in from mb in typeof(AvatarLoadingBar).GetMethods()
                                                          where mb.Name.Contains("Method_Public_Void_Single_Int64_")
                                                          select mb)
            {
                new AstroPatch(OnAvatarDownloadMethod, GetPatch(nameof(OnAvatarDownloadProgress)));
            }
        }

        private static void OnAvatarDownloadProgress(AvatarLoadingBar __instance, float __0, long __1)
        {
            ClientEventActions.OnAvatarDownloadProgress.SafetyRaiseWithParams(__instance, __0, __1);
        }

        private void VrcPlayerAwake(VRCPlayer player)
        {
            player.Method_Public_add_Void_Action_0(new Action(()
                => OnVRCPlayerAvatarInstantiate(player.prop_VRCAvatarManager_0, player.field_Private_ApiAvatar_0, player.field_Internal_GameObject_0))
            );
        }

        private static void OnVRCPlayerAvatarInstantiate(VRCAvatarManager manager, ApiAvatar apiAvatar, GameObject avatar)
        {
            if (manager == null || apiAvatar == null || avatar == null)
            {
                return;
            }
            ClientEventActions.OnAvatarInstantiated.SafetyRaiseWithParams(manager, apiAvatar, avatar);
        }

        private void HookAvatarManager()
        {
            VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0 += (Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>)OnAvatarInstantiate;
            Log.Debug("Hooked VRCAvatarManager");
        }

        private static void OnAvatarInstantiate(Player player, GameObject avatar, VRC_AvatarDescriptor descriptor)
        {
            ClientEventActions.OnAvatarSpawn.SafetyRaiseWithParams(player, avatar, player.GetVRCPlayer().field_Private_VRCAvatarManager_0, descriptor);
        }
    }
}