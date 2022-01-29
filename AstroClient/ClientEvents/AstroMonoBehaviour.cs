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

            Main.Event_OnSceneLoaded += Internal_OnSceneLoaded;

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

            JarRoleController.Event_OnViewRolesPropertyChanged += Internal_OnViewRolesPropertyChanged;
            PlayerESPMenu.Event_OnPlayerESPPropertyChanged += Internal_OnPlayerESPPropertyChanged;

            ConfigManager.Event_OnPublicESPColorChanged += Internal_OnPublicESPColorChanged;
            ConfigManager.Event_OnFriendESPColorChanged += Internal_OnFriendESPColorChanged;
            ConfigManager.Event_OnBlockedESPColorChanged += Internal_OnBlockedESPColorChanged;

        }
        private void Internal_OnEnterWorld(object sender, OnEnterWorldEventArgs e)
        {
            OnEnterWorld(e.ApiWorld, e.ApiWorldInstance);
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
        private void Internal_OnViewRolesPropertyChanged(object sender, BoolEventsArgs e) => OnViewRolesPropertyChanged(e.value);

        private void Internal_OnPlayerESPPropertyChanged(object sender, BoolEventsArgs e) => OnPlayerESPPropertyChanged(e.value);
        private void Internal_OnPublicESPColorChanged(object sender, ColorEventArgs e)
        {
            OnPublicESPColorChanged(e.Color);
        }

        private void Internal_OnBlockedESPColorChanged(object sender, ColorEventArgs e)
        {
            OnBlockedESPColorChanged(e.Color);
        }

        private void Internal_OnFriendESPColorChanged(object sender, ColorEventArgs e)
        {
            OnFriendESPColorChanged(e.Color);
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

        internal virtual void OnStreamerLeft(VRC.Player player)
        {
        }

        internal virtual void OnStreamerJoined(VRC.Player player)
        {
        }

        internal virtual void OnPhotonLeft(Player player)
        {
        }

        internal virtual void OnPhotonJoined(Player player)
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
        internal virtual void onUserInfoMenuOpen()
        {
        }

        internal virtual void onUserInfoMenuClose()
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
        #endregion
    }
}