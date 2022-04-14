
#region Imports

using System.Collections.Generic;
using AstroClient.Cheetos;
using AstroClient.Moderation;
using AstroClient.Startup.Hooks;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Patches;
using AstroClient.Target;
using AstroClient.xAstroBoy;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon;
using VRC.UI.Elements;

#endregion

namespace AstroClient
{
    #region Usings

    #endregion Imports

    // thanks TO Cheeto aka Craig on discord, he's been really helpful!
    internal class AstroEvents
    {
        public AstroEvents()
        {
            Main.Event_OnApplicationLateStart += OnApplicationLateStart;

            Main.Event_OnUpdate += OnUpdate;
            Main.Event_LateUpdate += OnLateUpdate;

            Main.Event_VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;
            Main.Event_VRChat_OnQuickMenuInit += VRChat_OnQuickMenuInit;
            Main.Event_VRChat_OnActionMenuInit += VRChat_OnActionMenuInit;
           // Main.Event_OnGui += OnGUI;

            Main.Event_OnSceneLoaded += OnSceneLoaded;
            Main.Event_OnApplicationQuit += OnApplicationQuit;

            OnWorldRevealHook.Event_OnWorldReveal += OnWorldReveal;
            //SpawnEmojiRPCHook.Event_SpawnEmojiRPC += SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += VRC_EventDispatcherRFC_triggerEvent;

            EventDispatcher_HandleUdonEvent.Event_OnUdonSyncRPC += OnUdonSyncRPCEvent;

            AvatarManagerHook.Event_OnAvatarSpawn += OnAvatarSpawn;

            PlayerJoinAndLeaveHook.Event_OnPlayerJoin += OnPlayerJoined;
            PlayerJoinAndLeaveHook.Event_OnPlayerLeft += OnPlayerLeft;

            CheetosHooks.Event_OnMasterClientSwitched += OnMasterClientSwitched;
            CheetosHooks.Event_OnShowScreen += OnShowScreen;
            CheetosHooks.Event_OnPhotonPlayerJoined += OnPhotonPlayerJoined;
            CheetosHooks.Event_OnPhotonPlayerLeft += OnPhotonPlayerLeft;
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

            //USpeakHook.Event_OnRawAudio += OnRawAudio;
            OnOwnerShipTransferredHook.Event_OnOwnerShipTranferred += OnOwnerShipTransferred;


            UdonEventsHook.Event_Udon_OnPickup += UdonBehaviour_Event_OnPickup;
            UdonEventsHook.Event_Udon_OnPickupUseUp += UdonBehaviour_Event_OnPickupUseUp;
            UdonEventsHook.Event_Udon_OnPickupUseDown += UdonBehaviour_Event_OnPickupUseDown;
            UdonEventsHook.Event_Udon_OnDrop += UdonBehaviour_Event_OnDrop;
            UdonEventsHook.Event_Udon_OnInteract += UdonBehaviour_Event_OnInteract;
            EventDispatcher_HandleUdonEvent.Event_Udon_SendCustomEvent += UdonBehaviour_Event_SendCustomEvent;

            UnityMessagesHook.Event_OnUnityLog += OnUnityLog;
            UnityMessagesHook.Event_OnUnityWarning += OnUnityWarning;
            UnityMessagesHook.Event_OnUnityError += OnUnityError;

        }

        internal virtual void OnRawAudio(VRCPlayer player, float[] RawAudio, int sample_rate)
        {

        }

        internal virtual void StartPreloadResources()
        {

        }
        internal virtual void OnUserInfoMenuOpen()
        {
        }

        internal virtual void OnUserInfoMenuClose()
        {
        }

        internal virtual void OnWorldCheatsActionMenuOpen()
        {

        }

        internal virtual void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
        }

        internal virtual void VRChat_OnUiManagerInit()
        {
        }

        internal virtual void VRChat_OnQuickMenuInit()
        {
        }

        internal virtual void VRChat_OnActionMenuInit()
        {
        }

        internal virtual void ExecutePriorityPatches()
        {
        }

        internal virtual void OnApplicationStart()
        {
        }

        internal virtual void OnApplicationLateStart()
        {
        }

        //internal virtual void OnGUI()
        //{
        //}

        internal virtual void OnApplicationQuit()
        {
        }

        internal virtual void OnUpdate()
        {
        }

        internal virtual void OnLateUpdate()
        {
        }

        internal virtual void OnRayCast(RaycastHit hit)
        {
        }

        internal virtual void OnSceneLoaded(int buildIndex, string sceneName)
        {
        }

        internal virtual void OnMasterClientSwitched(Player player)
        {
        }
        internal virtual void OnOwnerShipTransferred(PhotonView instance, int PhotonID)
        {
        }

        internal virtual void OnShowScreen(VRCUiPage page)
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
        internal virtual void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
        }

        internal virtual void OnPlayerLeft(VRC.Player player)
        {
        }

        internal virtual void OnPlayerJoined(VRC.Player player)
        {
        }

        internal virtual void OnPhotonPlayerLeft(Player player)
        {
        }

        internal virtual void OnPhotonPlayerJoined(Player player)
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

        internal virtual void OnPlayerSelected(VRC.Player player)
        {
        }

        internal virtual void OnTargetSet(VRC.Player player)
        {
        }

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

        internal virtual void OnUnityLog(string message)
        {
        }
        internal virtual void OnUnityWarning(string message)
        {
        }
        internal virtual void OnUnityError(string message)
        {
        }

    }
}