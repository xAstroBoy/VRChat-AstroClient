using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon;
using VRC.UI.Elements;

namespace AstroClient.ClientActions
{
    // Put all actions here .

    // There goes all Hooks and other "global" actions.

    internal class ClientEventActions
    {
        /// <summary>
        /// This gets called after OnApplicationStart
        /// </summary>
        internal static Action Event_OnApplicationStart { get; set; }

        /// <summary>
        /// This gets called after OnApplicationStart
        /// </summary>
        internal static Action Event_OnApplicationLateStart { get; set; }

        /// <summary>
        /// This gets called every single frame.
        /// </summary>

        internal static Action Event_OnUpdate { get; set; }

        /// <summary>
        /// This gets called after  5 frames.
        /// </summary>

        internal static Action Event_LateUpdate { get; set; }

        /// <summary>
        /// This gets called once VRChat UI is not null.
        /// </summary>

        internal static Action Event_VRChat_OnUiManagerInit { get; set; }

        /// <summary>
        /// This gets called once VRChat Quickmenu is not null.
        /// </summary>

        internal static Action Event_VRChat_OnQuickMenuInit { get; set; }

        /// <summary>
        /// This gets called once VRChat ActionMenu is not null.
        /// </summary>

        internal static Action Event_VRChat_OnActionMenuInit { get; set; }

        /// <summary>
        /// This gets called once PatchShield patches Has been unpatched.
        /// </summary>

        internal static Action Event_OnPatchShieldRemoved { get; set; }

        /// <summary>
        /// This gets called every scene load excluding VRChat defaults.
        /// </summary>

        internal static Action<int, string> Event_OnSceneLoaded { get; set; }

        /// <summary>
        /// This gets When application is being closed.
        /// </summary>
        internal static Action Event_OnApplicationQuit { get; set; }

        /// <summary>
        /// This gets called when a avatar is done loading.
        /// </summary>
        internal static Action<Player, GameObject, VRCAvatarManager, VRC_AvatarDescriptor> Event_OnAvatarSpawn { get; set; }

        /// <summary>
        /// This gets called when a udon RPC is being sent.
        /// <para>Params : VRC.Player sender, GameObject obj, string action</para>
        /// </summary>
        internal static System.Action<Player, GameObject, string> Event_OnUdonSyncRPC { get; set; }

        /// <summary>
        /// This Gets called when the fading effect reveals the world.
        /// <para>Params : string id, string Name, List tags, string AssetURL, string AuthorName</para>
        /// </summary>
        internal static Action<string, string, List<string>, string, string> Event_OnWorldReveal { get; set; }

        /// <summary>
        /// This Gets called when a PhotonView instance changes ownership.
        /// <para>Params : PhotonView instance, int PhotonID</para>
        /// </summary>
        internal static Action<PhotonView, int> Event_OnOwnerShipTranferred { get; set; }

        /// <summary>
        /// This Gets called when you select a player in the quickmenu usermenu.
        /// <para>Params : VRC.Player player</para>
        /// </summary>
        internal static Action<VRC.Player> Event_OnPlayerSelected { get; set; }

        /// <summary>
        /// This Gets called when a Player Joins.
        /// <para>Params : VRC.Player player</para>
        /// </summary>
        internal static Action<Player> Event_OnPlayerJoin { get; set; }

        /// <summary>
        /// This Gets called when a Player Leaves.
        /// <para>Params : VRC.Player player</para>
        /// </summary>
        internal static Action<Player> Event_OnPlayerLeft { get; set; }

        /// <summary>
        /// This Gets called when EventDispatcher is being called.
        /// <para>Params : VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat</para>
        /// </summary>
        internal static Action<VRC_EventHandler, VRC_EventHandler.VrcEvent, VRC_EventHandler.VrcBroadcastType, int, float> Event_VRC_EventDispatcherRFC_triggerEvent { get; set; }

        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickup method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>
        internal static Action<UdonBehaviour> Event_Udon_OnPickup { get; set; }

        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickup method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Event_Udon_OnPickupUseUp { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickupUseDown method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Event_Udon_OnPickupUseDown { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnDrop method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Event_Udon_OnDrop { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnInteract method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Event_Udon_OnInteract { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickup method gets invoked.
        /// <para>Params : UdonBehaviour instance, string CustomEvent</para>
        /// </summary>

        internal static Action<UdonBehaviour, string> Event_Udon_SendCustomEvent { get; set; }

        /// <summary>
        /// This listens to all VRC_Pickups IsHeld properties.
        /// <para>Params : VRC_Pickup instance, bool isHeld</para>
        /// </summary>

        internal static Action<VRC_Pickup, bool> Event_Pickup_isHeld { get; set; }

        /// <summary>
        /// This Gets called when a player blocks you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> Event_OnPlayerBlockedYou { get; set; }

        /// <summary>
        /// This Gets called when a player Unblocks you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> Event_OnPlayerUnblockedYou { get; set; }

        /// <summary>
        /// This Gets called when a player Mutes you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> Event_OnPlayerMutedYou { get; set; }
        /// <summary>
        /// This Gets called when a player Unmutes you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> Event_OnPlayerUnmutedYou { get; set; }
        /// <summary>
        /// This Gets called when a player sends a emote.
        /// <para>Params : VRC.Player player, int emote</para>
        /// </summary>

        internal static Action<Player, int> Event_SpawnEmojiRPC { get; set; }
        /// <summary>
        /// This Gets called when a player gets set as Target.
        /// <para>Params : VRC.Player player</para>
        /// </summary>

        internal static Action<Player> Event_OnTargetSet { get; set; }

        /// <summary>
        /// This gets called when QuickMenu is Open.
        /// </summary>
        internal static Action Event_OnQuickMenuOpen { get; set; }

        /// <summary>
        /// This gets called when QuickMenu is Closed.
        /// </summary>

        internal static Action Event_OnQuickMenuClose { get; set; }
        /// <summary>
        /// This gets called when the Big Menu is Open.
        /// </summary>

        internal static Action Event_OnBigMenuOpen { get; set; }
        /// <summary>
        /// This gets called when the Big Menu is Closed.
        /// </summary>

        internal static Action Event_OnBigMenuClose { get; set; }
        /// <summary>
        /// This gets called when the User Info Menu is Opened.
        /// </summary>

        internal static Action Event_OnUserInfoMenuOpen { get; set; }
        /// <summary>
        /// This gets called when the User Info Menu is Closed.
        /// </summary>

        internal static Action Event_OnUserInfoMenuClose { get; set; }
        /// <summary>
        /// This listens to VRChat UIPage system for Switching between Menu pages.
        /// <para>Params : UIPage Page, bool Toggle, UIPage.TransitionType TransitionType</para>
        /// </summary>

        internal static Action<UIPage, bool, UIPage.TransitionType> Event_OnUiPageToggled { get; set; }

        /// <summary>
        /// This listens to VRChat input system for Jump event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>

        internal static Action<bool, bool, bool> Event_OnInput_Jump { get; set; }
        /// <summary>
        /// This listens to VRChat input system for Use Left event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>

        internal static Action<bool, bool, bool> Event_OnInput_UseLeft { get; set; }
        /// <summary>
        /// This listens to VRChat input system for Use Right event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>

        internal static Action<bool, bool, bool> Event_OnInput_UseRight { get; set; }

        /// <summary>
        /// This listens to VRChat input system for Grab Left event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>
        internal static Action<bool, bool, bool> Event_OnInput_GrabLeft { get; set; }

        /// <summary>
        /// This listens to VRChat input system for Grab Right event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>
        internal static Action<bool, bool, bool> Event_OnInput_GrabRight { get; set; }

        /// <summary>
        /// This is being used for the keypad revealer, it destroys all failed finds.
        /// </summary>

        internal static Action Event_Keypad_DestroyFailedFinds { get; set; }

        /// <summary>
        /// This is Unity Debug Logger message.
        /// <para>Params : string message</para>
        /// </summary>

        internal static Action<string> Event_OnUnityLog { get; set; }
        /// <summary>
        /// This is Unity Debug Logger Warning.
        /// <para>Params : string message</para>
        /// </summary>

        internal static Action<string> Event_OnUnityWarning { get; set; }
        /// <summary>
        /// This is Unity Debug Logger Error.
        /// <para>Params : string message</para>
        /// </summary>

        internal static Action<string> Event_OnUnityError { get; set; }

        internal static Action<VRCUiPage> Event_OnShowScreen { get; set; }

        internal static Action<Photon.Realtime.Player> Event_OnPhotonPlayerJoined { get; set; }
        internal static Action<Photon.Realtime.Player> Event_OnPhotonPlayerLeft { get; set; }
        internal static Action<Photon.Realtime.Player> Event_OnMasterClientSwitched { get; set; }

        internal static Action Event_OnRoomLeft { get; set; }
        internal static Action Event_OnRoomJoined { get; set; }

        internal static Action<APIUser> Event_OnFriended { get; set; }
        internal static Action<string> Event_OnUnfriended { get; set; }

        internal static Action<ApiWorld, ApiWorldInstance> Event_OnEnterWorld { get; set; }

        internal static Action<VRCPlayer, Il2CppSystem.Collections.Hashtable> Event_OnSetupFlagsReceived { get; set; }

        internal static Action Event_OnShowSocialRankChanged { get; set; }

        internal static Action<AvatarLoadingBar, float, long> Event_OnAvatarDownloadProgress { get; set; }

        internal static Action<VRCAvatarManager, ApiAvatar, GameObject> Event_OnAvatarInstantiated { get; set; }

        internal static Action<bool> Event_OnViewRolesPropertyChanged { get; set; }
    }
}