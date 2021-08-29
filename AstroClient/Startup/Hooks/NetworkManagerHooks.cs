namespace AstroClient
{
    using AstroClientCore.Events;
    using MelonLoader;
    using System;
    using System.Collections;
    using VRC;

    public class NetworkManagerHooks : GameEvents
    {
        private static bool IsInitialized;
        private static bool SeenFire;
        private static bool AFiredFirst;

        public static event Action<Player> OnJoin;

        public static event Action<Player> OnLeave;

        public static EventHandler<PlayerEventArgs> Event_OnPlayerJoin;

        public static EventHandler<PlayerEventArgs> Event_OnPlayerLeft;

        public override void ExecutePriorityPatches()
        {
            MelonCoroutines.Start(HookNetworkManager());
        }

        public static IEnumerator HookNetworkManager()
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

        public static void OnPlayerJoinedEvent(Player player)
        {
            Event_OnPlayerJoin?.Invoke(null, new PlayerEventArgs(player));
        }

        public static void OnPlayerLeftEvent(Player player)
        {
            Event_OnPlayerLeft?.Invoke(null, new PlayerEventArgs(player));
        }

        public static void EventHandlerA(Player player)
        {
            if (!SeenFire)
            {
                AFiredFirst = true;
                SeenFire = true;
            }

            (AFiredFirst ? OnJoin : OnLeave)?.Invoke(player);
        }

        public static void EventHandlerB(Player player)
        {
            if (!SeenFire)
            {
                AFiredFirst = false;
                SeenFire = true;
            }

    (AFiredFirst ? OnLeave : OnJoin)?.Invoke(player);
        }

        public static void Initialize()
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
            field.field_Private_HashSet_1_UnityAction_1_T_0.Add(eventHandlerA);
        }
    }
}