using AstroClient.ConsoleUtils;
using AstroClient.variables;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;

namespace AstroClient.Startup.Hooks
{
    public class AvatarManagerHook : Overridables
    {

        private HarmonyInstance harmony;

        public static event EventHandler<OnAvatarSpawnArgs> Event_OnAvatarSpawn;


        public override void OnApplicationStart()
        {
            HookAvatarManager();
        }


        private void HookAvatarManager()
        {
            if (harmony == null)
            {
                harmony = HarmonyInstance.Create(BuildInfo.Name + " AvatarManagerHook");
            }
            harmony.Patch(typeof(VRCAvatarManager).GetMethod("Awake", BindingFlags.Instance | BindingFlags.Public), null, new HarmonyMethod(typeof(Main).GetMethod("OnVRCAMAwake", BindingFlags.Static | BindingFlags.NonPublic)));
            ModConsole.Log("Hooked VRCAvatarManager");
        }

        private static void OnVRCAMAwake(VRCAvatarManager __instance)
        {
            VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique multicastDelegateNPublicSealedVoGaVRBoUnique = (System.Action<GameObject, VRC.SDKBase.VRC_AvatarDescriptor, bool>)OnAvatarSpawnEvent;
            VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_ = __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_0;
            VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2 = __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_1;
            field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_ = ((field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_ == null) ? multicastDelegateNPublicSealedVoGaVRBoUnique : Il2CppSystem.Delegate.Combine(field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_, multicastDelegateNPublicSealedVoGaVRBoUnique).Cast<VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique>());
            field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2 = ((field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2 == null) ? multicastDelegateNPublicSealedVoGaVRBoUnique : Il2CppSystem.Delegate.Combine(field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2, multicastDelegateNPublicSealedVoGaVRBoUnique).Cast<VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique>());
            __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_0 = field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_;
            __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_1 = field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2;
        }

        private static void OnAvatarSpawnEvent(GameObject avatar, VRC.SDKBase.VRC_AvatarDescriptor DescriptorObj, bool state)
        {
             Event_OnAvatarSpawn?.Invoke(null, new OnAvatarSpawnArgs(avatar, DescriptorObj, state));
        }

    }
}
