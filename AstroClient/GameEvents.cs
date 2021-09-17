namespace AstroClient
{
    #region Imports

    using AstroClient.Cheetos;
    using AstroClient.Startup.Hooks;
    using AstroClientCore.Events;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    #endregion Imports

    // thanks TO Cheeto aka Craig on discord, he's been really helpful!
    public class GameEvents
    {
        public GameEvents()
        {
            // ML Events
            //Main.Event_OnApplicationStart += Internal_OnApplicationStart;

            Main.Event_OnUpdate += Internal_OnUpdate;
            Main.Event_LateUpdate += Internal_OnLateUpdate;
            Main.Event_VRChat_OnUiManagerInit += Internal_VRChat_OnUiManagerInit;
            Main.Event_VRChat_OnQuickMenuInit += Internal_VRChat_OnQuickMenuInit;

            Main.Event_OnSceneLoaded += Internal_OnSceneLoaded;
            Main.Event_OnApplicationQuit += Internal_OnApplicationQuit;

            // PATCHES

            // HOOKS
            OnWorldRevealHook.Event_OnWorldReveal += Internal_OnWorldReveal;
            SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;

            RPCEventHook.Event_OnUdonSyncRPC += Internal_OnUdonSyncRPCEvent;

            AvatarManagerHook.Event_OnAvatarSpawn += Internal_OnAvatarSpawn;

            NetworkManagerHooks.Event_OnPlayerJoin += Internal_OnPlayerJoined;
            NetworkManagerHooks.Event_OnPlayerLeft += Internal_OnPlayerLeft;

            CheetosHooks.Event_OnMasterClientSwitched += Internal_OnMasterClientSwitched;
            CheetosHooks.Event_OnPhotonJoin += Internal_OnPhotonPlayerJoined;
            CheetosHooks.Event_OnPhotonLeft += Internal_OnPhotonPlayerLeft;
            CheetosHooks.Event_OnQuickMenuOpen += Internal_OnQuickMenuOpen;
            CheetosHooks.Event_OnQuickMenuClose += Internal_OnQuickMenuClose;
            CheetosHooks.Event_OnRoomLeft += Internal_OnRoomLeft;
            CheetosHooks.Event_OnRoomJoined += Internal_OnRoomJoined;
            CheetosHooks.Event_OnFriended += Internal_OnFriended;
            CheetosHooks.Event_OnUnfriended += Internal_OnUnfriended;

            QuickMenuHooks.Event_OnPlayerSelected += Internal_OnPlayerSelected;

            TargetSelector.Event_OnTargetSet += Internal_OnTargetSet;

            StreamerProtector.Event_OnStreamerJoined += Internal_OnStreamerJoined;
            StreamerProtector.Event_OnStreamerLeft += Internal_OnStreamerLeft;

            PhotonOnEventHook.Event_OnPlayerBlockedYou += Internal_OnPlayerBlockedYou;
            PhotonOnEventHook.Event_OnPlayerUnblockedYou += Internal_OnPlayerUnblockedYou;
            PhotonOnEventHook.Event_OnPlayerMutedYou += Internal_OnPlayerMutedYou;
            PhotonOnEventHook.Event_OnPlayerUnmutedYou += Internal_OnPlayerUnmutedYou;
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

        private void Internal_OnApplicationStart(object sender, EventArgs e)
        {
            OnApplicationStart();
        }

        private void Internal_VRChat_OnUiManagerInit(object sender, EventArgs e)
        {
            VRChat_OnUiManagerInit();
        }

        private void Internal_VRChat_OnQuickMenuInit(object sender, EventArgs e)
        {
            VRChat_OnQuickMenuInit();
        }

        private void Internal_OnUpdate(object sender, EventArgs e)
        {
            OnUpdate();
        }

        private void Internal_OnApplicationQuit(object sender, EventArgs e)
        {
            OnApplicationQuit();
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

        private void Internal_OnPlayerBlockedYou(object sender, VRCPlayerEventArgs e)
        {
            OnPlayerBlockedYou(e.player);
        }

        private void Internal_OnPlayerUnblockedYou(object sender, VRCPlayerEventArgs e)
        {
            OnPlayerUnblockedYou(e.player);
        }

        private void Internal_OnPlayerMutedYou(object sender, VRCPlayerEventArgs e)
        {
            OnPlayerMutedYou(e.player);
        }

        private void Internal_OnPlayerUnmutedYou(object sender, VRCPlayerEventArgs e)
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
            OnAvatarSpawn(e.VRCAvatarManager, e.Avatar);
        }

        public virtual void VRChat_OnUiManagerInit()
        {
        }

        public virtual void VRChat_OnQuickMenuInit()
        {
        }

        public virtual void ExecutePriorityPatches()
        {
        }

        public virtual void OnApplicationStart()
        {
        }

        public virtual void OnApplicationQuit()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnLateUpdate()
        {
        }

        public virtual void OnRayCast(RaycastHit hit)
        {
        }

        public virtual void OnSceneLoaded(int buildIndex, string sceneName)
        {
        }

        public virtual void OnMasterClientSwitched(Photon.Realtime.Player player)
        {
        }

        public virtual void OnRoomLeft()
        {
        }

        public virtual void OnRoomJoined()
        {
        }

        public virtual void OnFriended()
        {
        }

        public virtual void OnUnfriended()
        {
        }

        public virtual void OnPlayerLeft(Player player)
        {
        }

        public virtual void OnPlayerJoined(Player player)
        {
        }

        public virtual void OnStreamerLeft(Player player)
        {
        }

        public virtual void OnStreamerJoined(Player player)
        {
        }

        public virtual void OnPhotonLeft(Photon.Realtime.Player player)
        {
        }

        public virtual void OnPhotonJoined(Photon.Realtime.Player player)
        {
        }

        public virtual void OnQuickMenuOpen()
        {
        }

        public virtual void OnQuickMenuClose()
        {
        }

        public virtual void SpawnEmojiRPC(VRCPlayer player, int emoji)
        {
        }

        public virtual void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
        {
        }

        public virtual void OnAvatarSpawn(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
        }

        public virtual void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
        }

        public virtual void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
        }

        public virtual void OnPlayerBlockedYou(VRC.Player player)
        {
        }

        public virtual void OnPlayerUnblockedYou(VRC.Player player)
        {
        }

        public virtual void OnPlayerMutedYou(VRC.Player player)
        {
        }

        public virtual void OnPlayerUnmutedYou(VRC.Player player)
        {
        }

        public virtual void OnPlayerSelected(Player player)
        {
        }

        public virtual void OnTargetSet(Player player)
        {
        }
    }
}