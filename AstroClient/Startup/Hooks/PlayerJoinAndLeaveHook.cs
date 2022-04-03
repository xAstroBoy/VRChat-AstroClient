namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Collections;
    using AstroEventArgs;
    using MelonLoader;
    using Tools.Extensions;
    using VRC;

    internal class PlayerJoinAndLeaveHook : AstroEvents
    {

        internal static Action<Player> Event_OnPlayerJoin;

        internal static Action<Player> Event_OnPlayerLeft;

        internal override void VRChat_OnUiManagerInit()
        {
            var field0 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0;
            var field1 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;

            field0.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>((player) => { if (player != null) Event_OnPlayerJoin?.SafetyRaise(player); }));
            field1.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>((player) => { if (player != null) Event_OnPlayerLeft?.SafetyRaise(player); }));

        }

    }
}