﻿namespace AstroClient.Startup.Hooks
{
    using AstroClientCore.Events;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    internal class AvatarManagerHook : GameEvents
    {
        internal static event EventHandler<OnAvatarSpawnArgs> Event_OnAvatarSpawn;

        internal override void OnApplicationStart() => HookAvatarManager();

        private void HookAvatarManager()
        {
            /* TODO: Consider switching to operator+ when everyone had to update the assembly unhollower */
            /*       The current solution might be prefereable so we are always first */
            // VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0 += (Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>)OnAvatarInstantiate;

            VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0 =
                Il2CppSystem.Delegate.Combine(
                    (Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>)
                    OnAvatarInstantiate,
                    VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0)
                    .Cast<Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>>();

            ModConsole.DebugLog("Hooked VRCAvatarManager");
        }

        private static void OnAvatarInstantiate(Player player, GameObject avatar, VRC_AvatarDescriptor descriptor)
        {
            Event_OnAvatarSpawn.SafetyRaise(new OnAvatarSpawnArgs(player, avatar, player.GetVRCPlayer().prop_VRCAvatarManager_0, descriptor));
        }
    }
}