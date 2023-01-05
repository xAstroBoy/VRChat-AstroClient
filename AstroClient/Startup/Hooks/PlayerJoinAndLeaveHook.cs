using AstroClient.ClientActions;

namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Collections;
    
    using MelonLoader;
    using Tools.Extensions;
    using VRC;

    internal class PlayerJoinAndLeaveHook : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;
        }



        private void VRChat_OnUiManagerInit()
        {
            var field0 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;
            var field1 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_2;

            field0.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>((player) => { if (player != null) ClientEventActions.OnPlayerJoin?.SafetyRaiseWithParams(player); }));
            field1.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>((player) => { if (player != null) ClientEventActions.OnPlayerLeft?.SafetyRaiseWithParams(player); }));

        }

    }
}