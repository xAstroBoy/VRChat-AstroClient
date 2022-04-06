using Photon.Pun;
using VRC.Udon;

namespace AstroClient
{
    using System;
    using System.Collections.Generic;
    using AstroEventArgs;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using Cheetos;
    using ClientUI.Menu.ESP;
    using Moderation;
    using Photon.Realtime;
    using Startup.Hooks;
    using Startup.Patches;
    using Streamer;
    using Target;
    using UnityEngine;
    using VRC.Core;
    using VRC.SDKBase;
    using VRC.UI.Elements;
    using xAstroBoy;
    using ConfigManager = Config.ConfigManager;

    public class AstroMonoBehaviour : MonoBehaviour
    {
        #region events

        public AstroMonoBehaviour(IntPtr obj0) : base(obj0)
        {

            Main.Event_OnSceneLoaded += OnSceneLoaded;

            OnWorldRevealHook.Event_OnWorldReveal += OnWorldReveal;
            //SpawnEmojiRPCHook.Event_SpawnEmojiRPC += SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += VRC_EventDispatcherRFC_triggerEvent;

            RPCEventHook.Event_OnUdonSyncRPC += OnUdonSyncRPCEvent;

            AvatarManagerHook.Event_OnAvatarSpawn += OnAvatarSpawn;

            PlayerJoinAndLeaveHook.Event_OnPlayerJoin += OnPlayerJoined;
            PlayerJoinAndLeaveHook.Event_OnPlayerLeft += OnPlayerLeft;

            CheetosHooks.Event_OnMasterClientSwitched += OnMasterClientSwitched;
            CheetosHooks.Event_OnShowScreen += OnShowScreen;
            CheetosHooks.Event_OnPhotonPlayerJoined += OnPhotonJoin;
            CheetosHooks.Event_OnPhotonPlayerLeft += OnPhotonLeft;
            CheetosHooks.Event_OnRoomLeft += OnRoomLeft;
            CheetosHooks.Event_OnRoomJoined += OnRoomJoined;
            CheetosHooks.Event_OnFriended += OnFriended;
            CheetosHooks.Event_OnUnfriended += OnUnfriended;
            CheetosHooks.Event_OnEnterWorld += OnEnterWorld;
            QuickMenuHooks.Event_OnPlayerSelected += OnPlayerSelected;

            TargetSelector.Event_OnTargetSet += OnTargetSet;

            PhotonModerationHandler.Event_OnPlayerBlockedYou += OnPlayerBlockedYou;
            PhotonModerationHandler.Event_OnPlayerUnblockedYou += OnPlayerUnblockedYou;
            PhotonModerationHandler.Event_OnPlayerMutedYou += OnPlayerMutedYou;
            PhotonModerationHandler.Event_OnPlayerUnmutedYou += OnPlayerUnmutedYou;

            UiManager.Event_OnQuickMenuOpen += OnQuickMenuOpen;
            UiManager.Event_OnQuickMenuClose += OnQuickMenuClose;
            UiManager.Event_OnBigMenuOpen += OnBigMenuOpen;
            UiManager.Event_OnBigMenuClose += OnBigMenuClose;
            UiManager.Event_OnUserInfoMenuOpen += OnUserInfoMenuOpen;
            UiManager.Event_OnUserInfoMenuClose += OnUserInfoMenuClose;
            UiManager.Event_OnUiPageToggled += OnUiPageToggled;

            InputPatches.Event_OnInput_Jump += OnInput_Jump;
            InputPatches.Event_OnInput_UseLeft += OnInput_UseLeft;
            InputPatches.Event_OnInput_UseRight += OnInput_UseRight;
            InputPatches.Event_OnInput_GrabLeft += OnInput_GrabLeft;
            InputPatches.Event_OnInput_GrabRight += OnInput_GrabRight;

            JarRoleController.Event_OnViewRolesPropertyChanged += OnViewRolesPropertyChanged;
            PlayerESPMenu.Event_OnPlayerESPPropertyChanged += OnPlayerESPPropertyChanged;

            ConfigManager.Event_OnPublicESPColorChanged += OnPublicESPColorChanged;
            ConfigManager.Event_OnFriendESPColorChanged += OnFriendESPColorChanged;
            ConfigManager.Event_OnBlockedESPColorChanged += OnBlockedESPColorChanged;

            OnOwnerShipTransferredHook.Event_OnOwnerShipTranferred += OnOwnerShipTransferred;

            UdonEventsHook.Event_Udon_OnPickup += UdonBehaviour_Event_OnPickup;
            UdonEventsHook.Event_Udon_OnPickupUseUp += UdonBehaviour_Event_OnPickupUseUp;
            UdonEventsHook.Event_Udon_OnPickupUseDown += UdonBehaviour_Event_OnPickupUseDown;
            UdonEventsHook.Event_Udon_OnDrop += UdonBehaviour_Event_OnDrop;
            UdonEventsHook.Event_Udon_OnInteract += UdonBehaviour_Event_OnInteract;
            UdonEventsHook.Event_Udon_SendCustomEvent += UdonBehaviour_Event_SendCustomEvent;


        }

        void OnDestroy()
        {
            Main.Event_OnSceneLoaded -= OnSceneLoaded;

            OnWorldRevealHook.Event_OnWorldReveal -= OnWorldReveal;
            //SpawnEmojiRPCHook.Event_SpawnEmojiRPC -= SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent -= VRC_EventDispatcherRFC_triggerEvent;

            RPCEventHook.Event_OnUdonSyncRPC -= OnUdonSyncRPCEvent;

            AvatarManagerHook.Event_OnAvatarSpawn -= OnAvatarSpawn;

            PlayerJoinAndLeaveHook.Event_OnPlayerJoin -= OnPlayerJoined;
            PlayerJoinAndLeaveHook.Event_OnPlayerLeft -= OnPlayerLeft;

            CheetosHooks.Event_OnMasterClientSwitched -= OnMasterClientSwitched;
            CheetosHooks.Event_OnShowScreen -= OnShowScreen;
            CheetosHooks.Event_OnPhotonPlayerJoined -= OnPhotonJoin;
            CheetosHooks.Event_OnPhotonPlayerLeft -= OnPhotonLeft;
            CheetosHooks.Event_OnRoomLeft -= OnRoomLeft;
            CheetosHooks.Event_OnRoomJoined -= OnRoomJoined;
            CheetosHooks.Event_OnFriended -= OnFriended;
            CheetosHooks.Event_OnUnfriended -= OnUnfriended;
            CheetosHooks.Event_OnEnterWorld -= OnEnterWorld;
            QuickMenuHooks.Event_OnPlayerSelected -= OnPlayerSelected;

            TargetSelector.Event_OnTargetSet -= OnTargetSet;

            PhotonModerationHandler.Event_OnPlayerBlockedYou -= OnPlayerBlockedYou;
            PhotonModerationHandler.Event_OnPlayerUnblockedYou -= OnPlayerUnblockedYou;
            PhotonModerationHandler.Event_OnPlayerMutedYou -= OnPlayerMutedYou;
            PhotonModerationHandler.Event_OnPlayerUnmutedYou -= OnPlayerUnmutedYou;

            UiManager.Event_OnQuickMenuOpen -= OnQuickMenuOpen;
            UiManager.Event_OnQuickMenuClose -= OnQuickMenuClose;
            UiManager.Event_OnBigMenuOpen -= OnBigMenuOpen;
            UiManager.Event_OnBigMenuClose -= OnBigMenuClose;
            UiManager.Event_OnUserInfoMenuOpen -= OnUserInfoMenuOpen;
            UiManager.Event_OnUserInfoMenuClose -= OnUserInfoMenuClose;
            UiManager.Event_OnUiPageToggled -= OnUiPageToggled;

            InputPatches.Event_OnInput_Jump -= OnInput_Jump;
            InputPatches.Event_OnInput_UseLeft -= OnInput_UseLeft;
            InputPatches.Event_OnInput_UseRight -= OnInput_UseRight;
            InputPatches.Event_OnInput_GrabLeft -= OnInput_GrabLeft;
            InputPatches.Event_OnInput_GrabRight -= OnInput_GrabRight;

            JarRoleController.Event_OnViewRolesPropertyChanged -= OnViewRolesPropertyChanged;
            PlayerESPMenu.Event_OnPlayerESPPropertyChanged -= OnPlayerESPPropertyChanged;

            ConfigManager.Event_OnPublicESPColorChanged -= OnPublicESPColorChanged;
            ConfigManager.Event_OnFriendESPColorChanged -= OnFriendESPColorChanged;
            ConfigManager.Event_OnBlockedESPColorChanged -= OnBlockedESPColorChanged;

            OnOwnerShipTransferredHook.Event_OnOwnerShipTranferred -= OnOwnerShipTransferred;

            UdonEventsHook.Event_Udon_OnPickup -= UdonBehaviour_Event_OnPickup;
            UdonEventsHook.Event_Udon_OnPickupUseUp -= UdonBehaviour_Event_OnPickupUseUp;
            UdonEventsHook.Event_Udon_OnPickupUseDown -= UdonBehaviour_Event_OnPickupUseDown;
            UdonEventsHook.Event_Udon_OnDrop -= UdonBehaviour_Event_OnDrop;
            UdonEventsHook.Event_Udon_OnInteract -= UdonBehaviour_Event_OnInteract;
            UdonEventsHook.Event_Udon_SendCustomEvent -= UdonBehaviour_Event_SendCustomEvent;
            //Log.Debug($"Deregistered a AstroMonoBehaviour from EventHandlers and Destroying it!");
        }


        internal virtual void OnOwnerShipTransferred(PhotonView instance, int PhotonID)
        {
        }

        internal virtual void OnPublicESPColorChanged(UnityEngine.Color color)
        {
        }

        internal virtual void OnBlockedESPColorChanged(UnityEngine.Color color)
        {
        }

        internal virtual void OnFriendESPColorChanged(UnityEngine.Color color)
        {
        }
        internal virtual void VRChat_OnUiManagerInit()
        {
        }

        internal virtual void OnSceneLoaded(int buildIndex, string sceneName)
        {
        }

        internal virtual void OnMasterClientSwitched(Player player)
        {
        }

        internal virtual void OnRoomLeft()
        {
        }

        internal virtual void OnRoomJoined()
        {
        }

        internal virtual void OnFriended()
        {
        }

        internal virtual void OnUnfriended()
        {
        }

        internal virtual void OnPlayerLeft(VRC.Player player)
        {
        }

        internal virtual void OnPlayerJoined(VRC.Player player)
        {
        }

        internal virtual void OnPhotonLeft(Player player)
        {
        }

        internal virtual void OnPhotonJoin(Player player)
        {
        }

        internal virtual void OnQuickMenuOpen()
        {
        }

        internal virtual void OnQuickMenuClose()
        {
        }

        internal virtual void OnBigMenuOpen()
        {
        }

        internal virtual void OnBigMenuClose()
        {
        }
        internal virtual void OnUserInfoMenuOpen()
        {
        }

        internal virtual void OnUserInfoMenuClose()
        {
        }

        internal virtual void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
        }

        internal virtual void SpawnEmojiRPC(VRCPlayer player, int emoji)
        {
        }

        internal virtual void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
        {
        }

        internal virtual void OnAvatarSpawn(VRC.Player Player, GameObject Avatar, VRCAvatarManager VRCAvatarManager, VRC_AvatarDescriptor VRC_AvatarDescriptor)
        {
        }

        internal virtual void OnUdonSyncRPCEvent(VRC.Player sender, GameObject obj, string action)
        {
        }

        internal virtual void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
        }

        internal virtual void OnPlayerSelected(VRC.Player player)
        {
        }

        internal virtual void OnTargetSet(VRC.Player player)
        {
        }

        internal virtual void OnPlayerBlockedYou(Player player)
        {
        }

        internal virtual void OnPlayerUnblockedYou(Player player)
        {
        }

        internal virtual void OnPlayerMutedYou(Player player)
        {
        }

        internal virtual void OnPlayerUnmutedYou(Player player)
        {
        }

        internal virtual void OnViewRolesPropertyChanged(bool value)
        {
        }

        internal virtual void OnPlayerESPPropertyChanged(bool value) { }

        internal virtual void OnInput_Jump(bool isClicked, bool isDown, bool isUp)
        {
        }

        internal virtual void OnInput_UseLeft(bool isClicked, bool isDown, bool isUp)
        {
        }

        internal virtual void OnInput_UseRight(bool isClicked, bool isDown, bool isUp)
        {
        }

        internal virtual void OnInput_GrabLeft(bool isClicked, bool isDown, bool isUp)
        {
        }

        internal virtual void OnInput_GrabRight(bool isClicked, bool isDown, bool isUp)
        {
        }

        internal virtual void OnShowScreen(VRCUiPage page)
        {
        }
        internal virtual void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
        }

        internal virtual void UdonBehaviour_Event_OnPickup(UdonBehaviour item)
        {
        }
        internal virtual void UdonBehaviour_Event_OnPickupUseUp(UdonBehaviour item)
        {
        }
        internal virtual void UdonBehaviour_Event_OnPickupUseDown(UdonBehaviour item)
        {
        }
        internal virtual void UdonBehaviour_Event_OnDrop(UdonBehaviour item)
        {
        }
        internal virtual void UdonBehaviour_Event_OnInteract(UdonBehaviour item)
        {
        }
        internal virtual void UdonBehaviour_Event_SendCustomEvent(UdonBehaviour item, string EventName)
        {
        }

        #endregion
    }
}