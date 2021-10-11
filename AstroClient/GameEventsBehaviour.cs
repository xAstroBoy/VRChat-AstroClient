namespace AstroClient
{
    using AstroClient.Cheetos;
    using AstroClient.Components;
    using AstroClient.Moderation;
    using AstroClient.Startup.Hooks;
    using AstroClient.Streamer;
    using AstroClientCore.Events;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    public class GameEventsBehaviour : MonoBehaviour
    {
        #region events
        public GameEventsBehaviour(IntPtr obj0) : base(obj0)
        {
            // ML Events
            //Main.Event_OnApplicationStart += Internal_OnApplicationStart;

            Main.Event_OnSceneLoaded += Internal_OnSceneLoaded;

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
            VRChatUIEvents.Event_OnQuickMenuOpen += Internal_OnQuickMenuOpen;
            VRChatUIEvents.Event_OnQuickMenuClose += Internal_OnQuickMenuClose;
            VRChatUIEvents.Event_OnBigMenuOpen += Internal_OnBigMenuOpen;
            VRChatUIEvents.Event_OnBigMenuClose += Internal_OnBigMenuClose;

            CheetosHooks.Event_OnRoomLeft += Internal_OnRoomLeft;
            CheetosHooks.Event_OnRoomJoined += Internal_OnRoomJoined;
            CheetosHooks.Event_OnFriended += Internal_OnFriended;
            CheetosHooks.Event_OnUnfriended += Internal_OnUnfriended;

            QuickMenuHooks.Event_OnPlayerSelected += Internal_OnPlayerSelected;

            TargetSelector.Event_OnTargetSet += Internal_OnTargetSet;

            StreamerProtector.Event_OnStreamerJoined += Internal_OnStreamerJoined;
            StreamerProtector.Event_OnStreamerLeft += Internal_OnStreamerLeft;

            PhotonModerationHandler.Event_OnPlayerBlockedYou += Internal_OnPlayerBlockedYou;
            PhotonModerationHandler.Event_OnPlayerUnblockedYou += Internal_OnPlayerUnblockedYou;
            PhotonModerationHandler.Event_OnPlayerMutedYou += Internal_OnPlayerMutedYou;
            PhotonModerationHandler.Event_OnPlayerUnmutedYou += Internal_OnPlayerUnmutedYou;


            #region utility stuff
            //Networking._IsOwner = Il2CppSystem.Delegate.Combine(
            //    (Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>)OnAvatarInstantiate,
            //    VRCAvatarManager.field_Private_Static_Action_3_Player_GameObject_VRC_AvatarDescriptor_0
            //).Cast<Il2CppSystem.Action<Player, GameObject, VRC.SDKBase.VRC_AvatarDescriptor>>();
            #endregion
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

        private void Internal_VRChat_OnUiManagerInit(object sender, EventArgs e)
        {
            VRChat_OnUiManagerInit();
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

        private void Internal_OnTargetSet(object sender, VRCPlayerEventArgs e)
        {
            OnTargetSet(e.player);
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

        internal virtual void VRChat_OnUiManagerInit()
        {
        }

        internal virtual void OnSceneLoaded(int buildIndex, string sceneName)
        {
        }

        internal virtual void OnMasterClientSwitched(Photon.Realtime.Player player)
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

        internal virtual void OnAvatarSpawn(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
        }

        internal virtual void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
        }

        internal virtual void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
        }

        internal virtual void OnPlayerSelected(Player player)
        {
        }

        internal virtual void OnTargetSet(Player player)
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

        internal virtual void OnViewRolesPropertyChanged(bool value)
        {
        }

        #endregion 

        private bool _isCurrentOwner;

    }
}