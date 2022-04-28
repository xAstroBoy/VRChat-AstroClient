using AstroClient.ClientActions;

namespace AstroClient.Startup.Hooks
{
    using System;
    
    using Tools.Extensions;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal class AvatarManagerHook : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

    

        private void OnApplicationStart() => HookAvatarManager();

        private void HookAvatarManager()
        {
            /* TODO: Consider switching to operator+ when everyone had to update the assembly unhollower */
            //       The current solution might be prefereable so we are always first */
             VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0 += (Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>)OnAvatarInstantiate;

            //VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0 =
            //    Il2CppSystem.Delegate.Combine(
            //        (Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>)
            //        OnAvatarInstantiate,
            //        VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0)
            //        .Cast<Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>>();

            Log.Debug("Hooked VRCAvatarManager");
        }

        private static void OnAvatarInstantiate(Player player, GameObject avatar, VRC_AvatarDescriptor descriptor)
        {
            ClientEventActions.OnAvatarSpawn.SafetyRaiseWithParams(player, avatar, player.GetVRCPlayer().field_Private_VRCAvatarManager_0, descriptor);
        }
    }
}