namespace AstroClient
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using AstroEventArgs;
    using Cheetos;
    using Moderation;
    using Startup.Hooks;
    using Startup.Patches;
    using Streamer;
    using Target;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;
    using VRC.UI.Elements;
    using xAstroBoy;

    #endregion Imports

    // thanks TO Cheeto aka Craig on discord, he's been really helpful!
    internal class AstroEvents
    {
        public AstroEvents()
        {
            // ML Events
            Main.Event_OnApplicationLateStart += Internal_OnApplicationLateStart;

            Main.Event_OnUpdate += Internal_OnUpdate;
            Main.Event_LateUpdate += Internal_OnLateUpdate;

            Main.Event_VRChat_OnUiManagerInit += Internal_VRChat_OnUiManagerInit;
            Main.Event_VRChat_OnQuickMenuInit += Internal_VRChat_OnQuickMenuInit;
            Main.Event_VRChat_OnActionMenuInit += Internal_VRChat_OnActionMenuInit;
            Main.Event_OnGui += Internal_OnGui;

            Main.Event_OnSceneLoaded += Internal_OnSceneLoaded;
            Main.Event_OnApplicationQuit += Internal_OnApplicationQuit;

            // PATCHES

            // HOOKS
            OnWorldRevealHook.Event_OnWorldReveal += Internal_OnWorldReveal;
            SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;

            RPCEventHook.Event_OnUdonSyncRPC += Internal_OnUdonSyncRPCEvent;

            AvatarManagerHook.Event_OnAvatarSpawn += Internal_OnAvatarSpawn;

            PlayerJoinAndLeaveHook.Event_OnPlayerJoin += Internal_OnPlayerJoined;
            PlayerJoinAndLeaveHook.Event_OnPlayerLeft += Internal_OnPlayerLeft;

            CheetosHooks.Event_OnMasterClientSwitched += Internal_OnMasterClientSwitched;
            CheetosHooks.Event_OnShowScreen += Internal_OnShowScreen;
            CheetosHooks.Event_OnPhotonJoin += Internal_OnPhotonPlayerJoined;
            CheetosHooks.Event_OnPhotonLeft += Internal_OnPhotonPlayerLeft;
            CheetosHooks.Event_OnRoomLeft += Internal_OnRoomLeft;
            CheetosHooks.Event_OnRoomJoined += Internal_OnRoomJoined;
            CheetosHooks.Event_OnFriended += Internal_OnFriended;
            CheetosHooks.Event_OnUnfriended += Internal_OnUnfriended;
            CheetosHooks.Event_OnEnterWorld += Internal_OnEnterWorld;
            QuickMenuHooks.Event_OnPlayerSelected += Internal_OnPlayerSelected;

            TargetSelector.Event_OnTargetSet += Internal_OnTargetSet;

            StreamerProtector.Event_OnStreamerJoined += Internal_OnStreamerJoined;
            StreamerProtector.Event_OnStreamerLeft += Internal_OnStreamerLeft;

            PhotonModerationHandler.Event_OnPlayerBlockedYou += Internal_OnPlayerBlockedYou;
            PhotonModerationHandler.Event_OnPlayerUnblockedYou += Internal_OnPlayerUnblockedYou;
            PhotonModerationHandler.Event_OnPlayerMutedYou += Internal_OnPlayerMutedYou;
            PhotonModerationHandler.Event_OnPlayerUnmutedYou += Internal_OnPlayerUnmutedYou;

            UiManager.Event_OnQuickMenuOpen += Internal_OnQuickMenuOpen;
            UiManager.Event_OnQuickMenuClose += Internal_OnQuickMenuClose;
            UiManager.Event_OnBigMenuOpen += Internal_OnBigMenuOpen;
            UiManager.Event_OnBigMenuClose += Internal_OnBigMenuClose;
            UiManager.Event_OnUserInfoMenuOpen += Internal_OnUserInfoMenuOpen;
            UiManager.Event_OnUserInfoMenuClose += Internal_OnUserInfoMenuClose;
            UiManager.Event_OnUiPageToggled += Internal_OnUiPageToggled;

            InputPatches.Event_OnInput_Jump += Internal_OnInput_Jump;
            InputPatches.Event_OnInput_UseLeft += Internal_OnInput_UseLeft;
            InputPatches.Event_OnInput_UseRight += Internal_OnInput_UseRight;
            InputPatches.Event_OnInput_GrabLeft += Internal_OnInput_GrabLeft;
            InputPatches.Event_OnInput_GrabRight += Internal_OnInput_GrabRight;
        }

        private void Internal_OnShowScreen(object sender, ScreenEventArgs e)
        {
            OnShowScreen(e.page);
        }

        private void Internal_OnStreamerJoined(object sender, PlayerEventArgs e)
        {
            OnStreamerJoined(e.player);
        }

        private void Internal_OnStreamerLeft(object sender, PlayerEventArgs e)
        {
            OnStreamerLeft(e.player);
        }

        private void Internal_OnMasterClientSwitched(object sender, PhotonPlayerEventArgs e)
        {
            OnMasterClientSwitched(e.player);
        }

        private void Internal_OnApplicationLateStart(object sender, System.EventArgs e)
        {
            OnApplicationLateStart();
        }

        private void Internal_VRChat_OnUiManagerInit(object sender, EventArgs e)
        {
            VRChat_OnUiManagerInit();
        }

        private void Internal_VRChat_OnQuickMenuInit(object sender, EventArgs e)
        {
            VRChat_OnQuickMenuInit();
        }

        private void Internal_VRChat_OnActionMenuInit(object sender, EventArgs e)
        {
            VRChat_OnActionMenuInit();
        }

        private void Internal_OnUpdate(object sender, EventArgs e)
        {
            OnUpdate();
        }

        private void Internal_OnApplicationQuit(object sender, EventArgs e)
        {
            OnApplicationQuit();
        }
        private void Internal_OnGui(object sender, EventArgs e)
        {
            OnGUI();
        }

        private void Internal_OnLateUpdate(object sender, EventArgs e)
        {
            OnLateUpdate();
        }

        private void Internal_OnSceneLoaded(object sender, OnSceneLoadedEventArgs e)
        {
            OnSceneLoaded(e.BuildIndex, e.SceneName);
        }

        private void Internal_OnRoomLeft(object sender, EventArgs e)
        {
            OnRoomLeft();
        }

        private void Internal_OnRoomJoined(object sender, EventArgs e)
        {
            OnRoomJoined();
        }

        private void Internal_OnFriended(object sender, EventArgs e)
        {
            OnFriended();
        }

        private void Internal_OnUnfriended(object sender, EventArgs e)
        {
            OnUnfriended();
        }
        private void Internal_OnEnterWorld(object sender, OnEnterWorldEventArgs e)
        {
            OnEnterWorld(e.ApiWorld, e.ApiWorldInstance);
        }

        private void Internal_OnPlayerLeft(object sender, PlayerEventArgs e)
        {
            OnPlayerLeft(e.player);
        }

        private void Internal_OnPlayerJoined(object sender, PlayerEventArgs e)
        {
            OnPlayerJoined(e.player);
        }

        private void Internal_OnQuickMenuOpen(object sender, EventArgs e)
        {
            OnQuickMenuOpen();
        }

        private void Internal_OnQuickMenuClose(object sender, EventArgs e)
        {
            OnQuickMenuClose();
        }

        private void Internal_OnBigMenuOpen(object sender, EventArgs e)
        {
            OnBigMenuOpen();
        }

        private void Internal_OnBigMenuClose(object sender, EventArgs e)
        {
            OnBigMenuClose();
        }

        private void Internal_OnPhotonPlayerLeft(object sender, PhotonPlayerEventArgs e)
        {
            OnPhotonLeft(e.player);
        }

        private void Internal_OnPhotonPlayerJoined(object sender, PhotonPlayerEventArgs e)
        {
            OnPhotonJoined(e.player);
        }

        private void Internal_SpawnEmojiRPC(object sender, SpawnEmojiArgs e)
        {
            SpawnEmojiRPC(e.player, e.Emoji);
        }

        private void Internal_OnWorldReveal(object sender, OnWorldRevealArgs e)
        {
            OnWorldReveal(e.ID, e.Name, e.WorldTags, e.AssetUrl, e.AuthorName);
        }

        private void Internal_OnPlayerSelected(object sender, VRCPlayerEventArgs e)
        {
            OnPlayerSelected(e.player);
        }

        private void Internal_OnPlayerBlockedYou(object sender, PhotonPlayerEventArgs e)
        {
            OnPlayerBlockedYou(e.player);
        }

        private void Internal_OnPlayerUnblockedYou(object sender, PhotonPlayerEventArgs e)
        {
            OnPlayerUnblockedYou(e.player);
        }

        private void Internal_OnPlayerMutedYou(object sender, PhotonPlayerEventArgs e)
        {
            OnPlayerMutedYou(e.player);
        }

        private void Internal_OnPlayerUnmutedYou(object sender, PhotonPlayerEventArgs e)
        {
            OnPlayerUnmutedYou(e.player);
        }

        private void Internal_OnTargetSet(object sender, VRCPlayerEventArgs e)
        {
            OnTargetSet(e.player);
        }

        private void Internal_VRC_EventDispatcherRFC_triggerEvent(object sender, VRC_EventDispatcherRFC_TriggerEventArgs e)
        {
            VRC_EventDispatcherRFC_triggerEvent(e.VRC_EventHandler, e.VrcEvent, e.VrcBroadcastType, e.UnknownInt, e.UnknownFloat);
        }

        private void Internal_OnUdonSyncRPCEvent(object sender, UdonSyncRPCEventArgs e)
        {
            OnUdonSyncRPCEvent(e.sender, e.obj, e.action);
        }

        private void Internal_OnAvatarSpawn(object sender, OnAvatarSpawnArgs e)
        {
            OnAvatarSpawn(e.Player, e.Avatar, e.VRCAvatarManager, e.VRC_AvatarDescriptor);
        }

        private void Internal_OnInput_Jump(object sender, VRCInputArgs e)
        {
            OnInput_Jump(e.isClicked, e.isDown, e.isUp);
        }

        private void Internal_OnInput_UseLeft(object sender, VRCInputArgs e)
        {
            OnInput_UseLeft(e.isClicked, e.isDown, e.isUp);
        }

        private void Internal_OnInput_UseRight(object sender, VRCInputArgs e)
        {
            OnInput_UseRight(e.isClicked, e.isDown, e.isUp);
        }

        private void Internal_OnInput_GrabLeft(object sender, VRCInputArgs e)
        {
            OnInput_GrabLeft(e.isClicked, e.isDown, e.isUp);
        }

        private void Internal_OnInput_GrabRight(object sender, VRCInputArgs e)
        {
            OnInput_GrabRight(e.isClicked, e.isDown, e.isUp);
        }

        private void Internal_OnUserInfoMenuOpen(object sender, EventArgs e)
        {
            onUserInfoMenuOpen();
        }

        private void Internal_OnUserInfoMenuClose(object sender, EventArgs e)
        {
            onUserInfoMenuClose();
        }

        private void Internal_OnUiPageToggled(object sender, OnUiPageEventArgs e)
        {
            OnUiPageToggled(e.Page, e.Toggle, e.TransitionType);
        }

        internal virtual void onUserInfoMenuOpen()
        {
        }

        internal virtual void onUserInfoMenuClose()
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


        internal virtual void OnGUI()
        {
        }


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

        internal virtual void OnMasterClientSwitched(Photon.Realtime.Player player)
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

        internal virtual void OnPlayerLeft(Player player)
        {
        }

        internal virtual void OnPlayerJoined(Player player)
        {
        }

        internal virtual void OnStreamerLeft(Player player)
        {
        }

        internal virtual void OnStreamerJoined(Player player)
        {
        }

        internal virtual void OnPhotonLeft(Photon.Realtime.Player player)
        {
        }

        internal virtual void OnPhotonJoined(Photon.Realtime.Player player)
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

        internal virtual void OnAvatarSpawn(Player Player, GameObject Avatar, VRCAvatarManager VRCAvatarManager, VRC_AvatarDescriptor VRC_AvatarDescriptor)
        {
        }

        internal virtual void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
        }

        internal virtual void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
        }

        internal virtual void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
        }

        internal virtual void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
        }

        internal virtual void OnPlayerMutedYou(Photon.Realtime.Player player)
        {
        }

        internal virtual void OnPlayerUnmutedYou(Photon.Realtime.Player player)
        {
        }

        internal virtual void OnPlayerSelected(Player player)
        {
        }

        internal virtual void OnTargetSet(Player player)
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
    }
}