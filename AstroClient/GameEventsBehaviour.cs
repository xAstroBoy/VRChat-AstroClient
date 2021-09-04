namespace AstroClient
{
    using AstroClient.Cheetos;
    using AstroClient.Startup.Hooks;
    using AstroClientCore.Events;
    using System;
    using System.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;

    public class GameEventsBehaviour : MonoBehaviour
    {
        public GameEventsBehaviour(IntPtr obj0) : base(obj0)
        {
            Main.Event_OnSceneLoaded += Internal_OnLevelLoaded;
            NetworkManagerHooks.Event_OnPlayerJoin += Internal_OnPlayerJoined;
            NetworkManagerHooks.Event_OnPlayerLeft += Internal_OnPlayerLeft;
            SpawnEmojiRPCHook.Event_SpawnEmojiRPC += Internal_SpawnEmojiRPC;
            TriggerEventHook.Event_VRC_EventDispatcherRFC_triggerEvent += Internal_VRC_EventDispatcherRFC_triggerEvent;
            AvatarManagerHook.Event_OnAvatarSpawn += Internal_OnAvatarSpawn;
            RPCEventHook.Event_OnUdonSyncRPC += Internal_OnUdonSyncRPCEvent;
            OnWorldRevealHook.Event_OnWorldReveal += Internal_OnWorldReveal;

            CheetosHooks.Event_OnPhotonJoin += Internal_OnPhotonPlayerJoined;
            CheetosHooks.Event_OnPhotonLeft += Internal_OnPhotonPlayerLeft;
            CheetosHooks.Event_OnQuickMenuOpen += Internal_OnQuickMenuOpen;
            CheetosHooks.Event_OnQuickMenuClose += Internal_OnQuickMenuClose;
            CheetosHooks.Event_OnRoomLeft += Internal_OnRoomLeft;
            CheetosHooks.Event_OnRoomJoined += Internal_OnRoomJoined;
        }

        [HideFromIl2Cpp]
        private void Internal_OnLevelLoaded(object sender, EventArgs e)
        {
            OnLevelLoaded();
        }

        [HideFromIl2Cpp]
        private void Internal_OnRoomLeft(object sender, EventArgs e)
        {
            OnRoomLeft();
        }

        [HideFromIl2Cpp]
        private void Internal_OnRoomJoined(object sender, EventArgs e)
        {
            OnRoomJoined();
        }

        [HideFromIl2Cpp]
        private void Internal_OnFriended(object sender, EventArgs e)
        {
            OnFriended();
        }

        [HideFromIl2Cpp]
        private void Internal_OnUnfriended(object sender, EventArgs e)
        {
            OnUnfriended();
        }

        [HideFromIl2Cpp]
        private void Internal_OnPlayerLeft(object sender, PlayerEventArgs e)
        {
            OnPlayerLeft(e.player);
        }

        [HideFromIl2Cpp]
        private void Internal_OnPlayerJoined(object sender, PlayerEventArgs e)
        {
            OnPlayerJoined(e.player);
        }

        [HideFromIl2Cpp]
        private void Internal_SpawnEmojiRPC(object sender, SpawnEmojiArgs e)
        {
            SpawnEmojiRPC(e.player, e.Emoji);
        }

        [HideFromIl2Cpp]
        private void Internal_VRC_EventDispatcherRFC_triggerEvent(object sender, VRC_EventDispatcherRFC_TriggerEventArgs e)
        {
            VRC_EventDispatcherRFC_triggerEvent(e.VRC_EventHandler, e.VrcEvent, e.VrcBroadcastType, e.UnknownInt, e.UnknownFloat);
        }

        [HideFromIl2Cpp]
        private void Internal_OnAvatarSpawn(object sender, OnAvatarSpawnArgs e)
        {
            OnAvatarSpawn(e.VRCAvatarManager, e.Avatar);
        }

        [HideFromIl2Cpp]
        private void Internal_OnUdonSyncRPCEvent(object sender, UdonSyncRPCEventArgs e)
        {
            OnUdonSyncRPCEvent(e.sender, e.obj, e.action);
        }

        [HideFromIl2Cpp]
        private void Internal_OnQuickMenuOpen(object sender, EventArgs e)
        {
            OnQuickMenuOpen();
        }

        [HideFromIl2Cpp]
        private void Internal_OnQuickMenuClose(object sender, EventArgs e)
        {
            OnQuickMenuClose();
        }

        [HideFromIl2Cpp]
        private void Internal_OnPhotonPlayerLeft(object sender, PhotonPlayerEventArgs e)
        {
            OnPhotonLeft(e.player);
        }

        [HideFromIl2Cpp]
        private void Internal_OnPhotonPlayerJoined(object sender, PhotonPlayerEventArgs e)
        {
            OnPhotonJoined(e.player);
        }

        [HideFromIl2Cpp]
        private void Internal_OnWorldReveal(object sender, OnWorldRevealArgs e)
        {
            OnWorldReveal(e.ID, e.Name, e.WorldTags, e.AssetUrl);
        }

        [HideFromIl2Cpp]
        public virtual void OnPlayerLeft(Player player)
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnRoomLeft()
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnRoomJoined()
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnFriended()
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnUnfriended()
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnLevelLoaded()
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnPlayerJoined(Player player)
        {
        }

        [HideFromIl2Cpp]
        public virtual void SpawnEmojiRPC(VRCPlayer player, int emoji)
        {
        }

        [HideFromIl2Cpp]
        public virtual void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat)
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnAvatarSpawn(VRCAvatarManager VRCAvatarManager, GameObject Avatar)
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnPhotonLeft(Photon.Realtime.Player player)
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnPhotonJoined(Photon.Realtime.Player player)
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnQuickMenuOpen()
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnQuickMenuClose()
        {
        }

        [HideFromIl2Cpp]
        public virtual void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
        }
    }
}