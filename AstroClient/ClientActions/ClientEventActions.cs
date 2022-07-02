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
        internal static Action OnApplicationStart { get; set; }

        /// <summary>
        /// This gets called after OnApplicationStart
        /// </summary>
        internal static Action OnApplicationLateStart { get; set; }

        /// <summary>
        /// This gets called every single frame.
        /// </summary>

        internal static Action OnUpdate { get; set; }

        /// <summary>
        /// This gets called after  5 frames.
        /// </summary>

        internal static Action LateUpdate { get; set; }

        ///// <summary>
        ///// This gets called once VRChat UI is not null with a delay of 10s.
        ///// </summary>

        //internal static Action Delayed_VRChat_OnUiManagerInit { get; set; }


        /// <summary>
        /// This gets called once VRChat UI is not null.
        /// </summary>

        internal static Action VRChat_OnUiManagerInit { get; set; }

        /// <summary>
        /// This gets called once VRChat Quickmenu is not null.
        /// </summary>

        internal static Action VRChat_OnQuickMenuInit { get; set; }

        /// <summary>
        /// This gets called once VRChat ActionMenu is not null.
        /// </summary>

        internal static Action VRChat_OnActionMenuInit { get; set; }

        /// <summary>
        /// This gets called once PatchShield patches Has been unpatched.
        /// </summary>

        internal static Action OnPatchShieldRemoved { get; set; }

        /// <summary>
        /// This gets called every scene load excluding VRChat defaults.
        /// </summary>

        internal static Action<int, string> OnSceneLoaded { get; set; }

        /// <summary>
        /// This gets When application is being closed.
        /// </summary>
        internal static Action OnApplicationQuit { get; set; }

        /// <summary>
        /// This gets called when a avatar is done loading.
        /// </summary>
        internal static Action<Player, GameObject, VRCAvatarManager, VRC_AvatarDescriptor> OnAvatarSpawn { get; set; }

        /// <summary>
        /// This gets called when a udon RPC is being sent.
        /// <para>Params : VRC.Player sender, GameObject obj, string action</para>
        /// </summary>
        internal static System.Action<Player, GameObject, string> OnUdonSyncRPC { get; set; }

        /// <summary>
        /// This Gets called when the fading effect reveals the world.
        /// <para>Params : string id, string Name, List tags, string AssetURL, string AuthorName</para>
        /// </summary>
        internal static Action<string, string, List<string>, string, string> OnWorldReveal { get; set; }

        /// <summary>
        /// This Gets called when a PhotonView instance changes ownership.
        /// <para>Params : PhotonView instance, int PhotonID</para>
        /// </summary>
        internal static Action<PhotonView, int> OnOwnerShipTranferred { get; set; }

        /// <summary>
        /// This Gets called when you select a player in the quickmenu usermenu.
        /// <para>Params : VRC.Player player</para>
        /// </summary>
        internal static Action<VRC.Player> OnPlayerSelected { get; set; }

        /// <summary>
        /// This Gets called when a Player Joins.
        /// <para>Params : VRC.Player player</para>
        /// </summary>
        internal static Action<Player> OnPlayerJoin { get; set; }


        /// <summary>
        /// This Gets called when Player Component Starts.
        /// <para>Params : VRC.Player player</para>
        /// </summary>
        internal static Action<VRCPlayer> OnPlayerStart { get; set; }

        /// <summary>
        /// This Gets called when a Player Leaves.
        /// <para>Params : VRC.Player player</para>
        /// </summary>
        internal static Action<Player> OnPlayerLeft { get; set; }

        /// <summary>
        /// This Gets called when EventDispatcher is being called.
        /// <para>Params : VRC_EventHandler VRC_EventHandler, VRC_EventHandler.VrcEvent VrcEvent, VRC_EventHandler.VrcBroadcastType VrcBroadcastType, int UnknownInt, float UnknownFloat</para>
        /// </summary>
        internal static Action<VRC_EventHandler, VRC_EventHandler.VrcEvent, VRC_EventHandler.VrcBroadcastType, int, float> VRC_EventDispatcherRFC_triggerEvent { get; set; }

        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickup method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>
        internal static Action<UdonBehaviour> Udon_OnPickup { get; set; }

        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickup method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Udon_OnPickupUseUp { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickupUseDown method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Udon_OnPickupUseDown { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnDrop method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Udon_OnDrop { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnInteract method gets invoked.
        /// <para>Params : UdonBehaviour instance</para>
        /// </summary>

        internal static Action<UdonBehaviour> Udon_OnInteract { get; set; }
        /// <summary>
        /// This Gets called when a UdonBehaviour OnPickup method gets invoked.
        /// <para>Params : UdonBehaviour instance, string CustomEvent</para>
        /// </summary>

        internal static Action<UdonBehaviour, string> Udon_SendCustomEvent { get; set; }

        /// <summary>
        /// This listens to all VRC_Pickups IsHeld properties.
        /// <para>Params : VRC_Pickup instance, bool isHeld</para>
        /// </summary>

        internal static Action<VRC_Pickup, bool> Pickup_isHeld { get; set; }

        /// <summary>
        /// This Gets called when a player blocks you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> OnPlayerBlockedYou { get; set; }

        /// <summary>
        /// This Gets called when a player Unblocks you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> OnPlayerUnblockedYou { get; set; }

        /// <summary>
        /// This Gets called when a player Mutes you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> OnPlayerMutedYou { get; set; }
        /// <summary>
        /// This Gets called when a player Unmutes you.
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> OnPlayerUnmutedYou { get; set; }
        /// <summary>
        /// This Gets called when a player sends a emote.
        /// <para>Params : VRC.Player player, int emote</para>
        /// </summary>

        internal static Action<Player, int> SpawnEmojiRPC { get; set; }
        /// <summary>
        /// This Gets called when a player gets set as Target.
        /// <para>Params : VRC.Player player</para>
        /// </summary>

        internal static Action<Player> OnTargetSet { get; set; }

        /// <summary>
        /// This gets called when QuickMenu is Open.
        /// </summary>
        internal static Action OnQuickMenuOpen { get; set; }

        /// <summary>
        /// This gets called when QuickMenu is Closed.
        /// </summary>

        internal static Action OnQuickMenuClose { get; set; }
        /// <summary>
        /// This gets called when the Big Menu is Open.
        /// </summary>

        internal static Action OnBigMenuOpen { get; set; }
        /// <summary>
        /// This gets called when the Big Menu is Closed.
        /// </summary>

        internal static Action OnBigMenuClose { get; set; }
        /// <summary>
        /// This gets called when the User Info Menu is Opened.
        /// </summary>

        internal static Action OnUserInfoMenuOpen { get; set; }
        /// <summary>
        /// This gets called when the User Info Menu is Closed.
        /// </summary>

        internal static Action OnUserInfoMenuClose { get; set; }
        /// <summary>
        /// This listens to VRChat UIPage system for Switching between Menu pages.
        /// <para>Params : UIPage Page, bool Toggle, UIPage.TransitionType TransitionType</para>
        /// </summary>

        internal static Action<UIPage, bool, UIPage.TransitionType, bool> OnUiPageToggled { get; set; }

        /// <summary>
        /// This listens to VRChat input system for Jump event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>

        internal static Action<bool, bool, bool> OnInput_Jump { get; set; }
        /// <summary>
        /// This listens to VRChat input system for Use Left event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>

        internal static Action<bool, bool, bool> OnInput_UseLeft { get; set; }
        /// <summary>
        /// This listens to VRChat input system for Use Right event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>

        internal static Action<bool, bool, bool> OnInput_UseRight { get; set; }

        /// <summary>
        /// This listens to VRChat input system for Grab Left event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>
        internal static Action<bool, bool, bool> OnInput_GrabLeft { get; set; }

        /// <summary>
        /// This listens to VRChat input system for Grab Right event.
        /// <para>Params : bool isClicked, bool isDown, bool isUp</para>
        /// </summary>
        internal static Action<bool, bool, bool> OnInput_GrabRight { get; set; }

        /// <summary>
        /// This is being used for the keypad revealer, it destroys all failed finds.
        /// </summary>

        internal static Action Keypad_DestroyFailedFinds { get; set; }

        /// <summary>
        /// This is Unity Debug Logger message.
        /// <para>Params : string message</para>
        /// </summary>

        internal static Action<string> OnUnityLog { get; set; }
        /// <summary>
        /// This is Unity Debug Logger Warning.
        /// <para>Params : string message</para>
        /// </summary>

        internal static Action<string> OnUnityWarning { get; set; }
        /// <summary>
        /// This is Unity Debug Logger Error.
        /// <para>Params : string message</para>
        /// </summary>

        internal static Action<string> OnUnityError { get; set; }

        /// <summary>
        /// This is VRChat Big menu ?.
        /// <para>Params : VRCUiPage page</para>
        /// </summary>

        internal static Action<VRCUiPage> OnShowScreen { get; set; }

        /// <summary>
        /// This is when a Photon Player joins (it will trigger before OnPlayerJoin)
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> OnPhotonPlayerJoined { get; set; }

        /// <summary>
        /// This is when a Photon Player leave (it will trigger before OnPlayerLeft)
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>

        internal static Action<Photon.Realtime.Player> OnPhotonPlayerLeft { get; set; }
        /// <summary>
        /// This is when a Photon reassigns a new Instance Master 
        /// <para>Params : Photon.Realtime.Player player</para>
        /// </summary>
        internal static Action<Photon.Realtime.Player> OnMasterClientSwitched { get; set; }

        /// <summary>
        /// This is when you leave a room.
        /// </summary>

        internal static Action OnRoomLeft { get; set; }

        /// <summary>
        /// This is when you join a new room 
        /// </summary>

        internal static Action OnRoomJoined { get; set; }
        /// <summary>
        /// This is when a User friends you 
        /// <para>Params : ApiUser player</para>
        /// </summary>

        internal static Action<APIUser> OnFriended { get; set; }

        /// <summary>
        /// This is when a User unfriends you 
        /// <para>Params : string  UserID </para>
        /// </summary>

        internal static Action<string> OnUnfriended { get; set; }
        /// <summary>
        /// This is when you enter a world 
        /// <para>Params : ApiWorld world, ApiWorldInstance instance </para>
        /// </summary>

        internal static Action<ApiWorld, ApiWorldInstance> OnEnterWorld { get; set; }

        internal static Action<VRCPlayer, Il2CppSystem.Collections.Hashtable> OnSetupFlagsReceived { get; set; }

        internal static Action OnShowSocialRankChanged { get; set; }

        internal static Action<AvatarLoadingBar, float, long> OnAvatarDownloadProgress { get; set; }

        internal static Action<VRCAvatarManager, ApiAvatar, GameObject> OnAvatarInstantiated { get; set; }

        internal static Action<bool> OnViewRolesPropertyChanged { get; set; }


        /// <summary>
        /// This is a pickup component gets created 
        /// <para>Params : VRC.SDKBase.VRC_Pickup instance </para>
        /// </summary>
        internal static Action<VRC.SDKBase.VRC_Pickup> OnPickupAwake { get; set; }



        /// <summary>
        /// this gets invoked when the avatar scale gets changed.
        /// <para>Params : Transform avatartransform, float newscale </para>
        /// </summary>

        internal static Action<Transform, float> OnAvatarScaleChanged { get; set; }


        internal static Action<VRC_StationInternal> OnStationEnter { get; set; }

        /// <summary>
        /// this gets invoked when You leave the Station.
        /// <para>Params : VRCStation instance </para>
        /// </summary>
        internal static Action<VRC_StationInternal> OnStationExit { get; set; }


    }
}