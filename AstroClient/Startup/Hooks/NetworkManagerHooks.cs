namespace AstroClient.Startup.Hooks
{
    using System;
    using System.Collections;
    using AstroEventArgs;
    using MelonLoader;
    using Tools.Extensions;
    using VRC;

    internal class NetworkManagerHooks : AstroEvents
    {
        private static bool IsInitialized;
        private static bool SeenFire;
        private static bool AFiredFirst;

        internal static event Action<Player> OnJoin;

        internal static event Action<Player> OnLeave;

        internal static EventHandler<PlayerEventArgs> Event_OnPlayerJoin;

        internal static EventHandler<PlayerEventArgs> Event_OnPlayerLeft;

        internal override void ExecutePriorityPatches()
        {
            _ = MelonCoroutines.Start(HookNetworkManager());
        }

        internal static IEnumerator HookNetworkManager()
        {
            while (NetworkManager.field_Internal_Static_NetworkManager_0 is null)
            {
                yield return null;
            }

            while (VRCAudioManager.field_Private_Static_VRCAudioManager_0 is null)
            {
                yield return null;
            }

            while (VRCUiManager.prop_VRCUiManager_0 is null)
            {
                yield return null;
            }

            Initialize();
            OnJoin += OnPlayerJoinedEvent;
            OnLeave += OnPlayerLeftEvent;
        }

        internal static void OnPlayerJoinedEvent(Player player)
        {
            Event_OnPlayerJoin?.SafetyRaise(new PlayerEventArgs(player));
        }

        internal static void OnPlayerLeftEvent(Player player)
        {
            Event_OnPlayerLeft?.SafetyRaise(new PlayerEventArgs(player));
        }

        internal static void EventHandlerA(Player player)
        {
            if (!SeenFire)
            {
                AFiredFirst = true;
                SeenFire = true;
            }

            (AFiredFirst ? OnJoin : OnLeave)?.Invoke(player);
        }

        internal static void EventHandlerB(Player player)
        {
            if (!SeenFire)
            {
                AFiredFirst = false;
                SeenFire = true;
            }

            (AFiredFirst ? OnLeave : OnJoin)?.Invoke(player);
        }

        internal static void Initialize()
        {
            if (IsInitialized) return;
            if (NetworkManager.field_Internal_Static_NetworkManager_0 is null) return;

            var field0 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0;
            var field1 = NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1;

            AddDelegate(field0, EventHandlerA);
            AddDelegate(field1, EventHandlerB);

            IsInitialized = true;
        }

        private static void AddDelegate(VRC.Core.VRCEventDelegate<Player> field, Action<Player> eventHandlerA)
        {
            _ = field.field_Private_HashSet_1_UnityAction_1_T_0.Add(eventHandlerA);
        }
    }
}