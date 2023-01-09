using AstroClient.AstroMonos.Components.Cheats.PatronCrackers;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Startup.Hooks;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks.BlueKun
{
    // TODO: Update the patron bypass with the new system.

    internal class JustBClub2Lobby : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnEnterWorld += OnWorldEnter;
        }

        private void OnWorldEnter(ApiWorld world, ApiWorldInstance instance)
        {
            if (world == null) return;

            if (world.id.Equals(WorldIds.JustBClub2Lobby) || world.id.Equals(WorldIds.JustBClub2))
            {
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("IsOnGround");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_CheckLocation");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("CheckIfLocalPlayerIsInRange");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_EndConvo");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__GetAnon");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__ResetRoom");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Resize");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetOccupantsCount");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetOccupantsCount");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetOccupantsCount");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetOccupantsCount");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetOccupantsCount");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetOccupantsCount");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_UpdateLists");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Seek");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetLock");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_Init");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_RegsiterAdapter");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("OnInteraction");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("RequestSerialization");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__ChangeVolume");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__GetGlassType");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__GetHitType");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__GetTargetType");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__Log");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__MainMat");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__OnPlayerAssigned");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__Press");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__PressTo");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__RegisterMimicButton");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__RegisterObjectAssigner");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__RegisterSlowObjectSyncUpdate");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__RegisterSnailUpdate");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__RegisterSubscription");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__RegisterUdonSharpEventReceiverWithPriority");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetBedroom");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetInteractable");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetMasterScript");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__SetTV");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__TryPlayDefaultSongForArea");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__Unique");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__UnregisterSubscription");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0__UpdateButtonTo");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_GetBallSpawn");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_GetCup");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_GetPlayerColor");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_ItsYourTurn");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_ResetGlassesIfOwner");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_SetActivePlayerColor");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("__0_SetColor");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_AssignRoom");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Cycle");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_DestroySpawn");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Disable");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_DisableCans");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_DisableLayoutGroup");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_DisableObjects");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_EnableAnimator");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_EnableAudio");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_EnableAudioSource");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_GetBoardSize");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_GetGameState");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Init");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_InitAreas");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_InitDesktop");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_OnDelayRequestSerialization");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_OnDelayUpdateAssignment");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_OneHandedMode");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_OnOwnerSet");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_OnVideoPlayerReady");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Page");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_PlayParam");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_PlayRandom");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Press");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Rain");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_ReEnableIsKinematic");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_RegisterMimicButtonWithOriginal");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_RequestSync");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Respawn");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_SetColor");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_SetJoinNotificationActiveTrue");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_SetShowerParam");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Show");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Snow");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_SyncGlass");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_ToggleColliders");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_ToggleMaxPerformance");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_ToggleNPCParam");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TogglePerformanceUi");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TogglePickupable");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TryDisableVipOnlyToggleButtons");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TvLoading");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TvLoadingEnd");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TvMediaChange");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TvMediaStart");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TvPlay");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_TvReady");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_UnMute");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_UpdateButton");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_UpdateButtons");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_UpdateFlairAndPlayerList");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_UpdateGameState");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_UpdateMarkerObjects");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Video");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_WalkAway");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("Check");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("CheckForceRefresh");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("EndTargetLocalPlayer");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("get_IsSad");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("Init");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("InitPrefab");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("IsReady");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("Refresh");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("Respawn");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("SetAdapterBool");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("SetAdapterFloat");


             //   UnityDestroyBlock.AddBlock("Udon 3rd Party");
              //  UnityDestroyBlock.MonitorDestroyingEvent = true; // This is to prevent Blue-kun from destroying the RenderCamera system
               // UnityDestroyBlock.OnDestroyBlocked += OnBlockedDestroy;
                //BlockPatronProcessor = true;
                //_ = MelonCoroutines.Start(ForcePatronReader());
                //_ = MelonCoroutines.Start(ForceEnableRenderCamera());
                HasSubscribed = true;
               // InterceptUdonCustomEvent = true;
                isCurrentWorld = true;
            }
        }

        private static bool _HasSubscribed = false;

        private static bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnUnityLog += OnUnityLog;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnUnityLog -= OnUnityLog;
                    }
                }
                _HasSubscribed = value;
            }
        }
        //private static bool _InterceptUdonCustomEvent = false;

        //private static bool InterceptUdonCustomEvent
        //{
        //    get => _InterceptUdonCustomEvent;
        //    set
        //    {
        //        if (_InterceptUdonCustomEvent != value)
        //        {
        //            if (value)
        //            {
        //                ClientEventActions.Udon_SendCustomEvent += Udon_SendCustomEvent;
        //            }
        //            else
        //            {
        //                ClientEventActions.Udon_SendCustomEvent -= Udon_SendCustomEvent;
        //            }
        //        }
        //        _InterceptUdonCustomEvent = value;
        //    }
        //}
        #region World Paths

        private static GameObject _Special;

        internal static GameObject Special
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Special == null)
                {
                    return _Special = Finder.FindRootSceneObject("Special");
                }
                return _Special;
            }
        }

        private static GameObject _Udon_third_Party;

        internal static GameObject Udon_third_Party
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Udon_third_Party == null)
                {
                    return _Udon_third_Party = Finder.FindRootSceneObject("Udon 3rd Party");
                }
                return _Udon_third_Party;
            }
        }

        private static GameObject _ImageReader;

        internal static GameObject ImageReader
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Udon_third_Party == null) return null;
                if (_ImageReader == null)
                {
                    return _ImageReader = Udon_third_Party.transform.FindObject("New avatar image reader (TMP)").gameObject;
                }
                return _ImageReader;
            }
        }

        private static GameObject _Cancer_Spawn;

        internal static GameObject Cancer_Spawn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Special == null) return null;
                if (_Cancer_Spawn == null)
                {
                    return _Cancer_Spawn = Special.transform.FindObject("Cancer Spawn").gameObject;
                }
                return _Cancer_Spawn;
            }
        }

        #endregion World Paths

        //private static ImageRenderCameraReader2 _RenderCameraReader;

        //internal static ImageRenderCameraReader2 RenderCameraReader
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (ImageReader == null) return null;
        //        else
        //        {
        //            ImageReader.SetActive(true);
        //        }

        //        if (_RenderCameraReader == null)
        //        {
        //            return _RenderCameraReader = ComponentUtils.GetOrAddComponent<ImageRenderCameraReader2>(ImageReader);
        //        }
        //        return _RenderCameraReader;
        //    }
        //}

        //private static BClub2PatronReader _PatronSystemReader;

        //internal static BClub2PatronReader PatronSystemReader
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (ProcessPatrons == null) return null;

        //        if (_PatronSystemReader == null)
        //        {
        //            return _PatronSystemReader = ComponentUtils.GetOrAddComponent<BClub2PatronReader>(ProcessPatrons.gameObject);
        //        }
        //        return _PatronSystemReader;
        //    }
       // }

        #region Udon Behaviours Cached and other random stuff

        private static UdonBehaviour_Cached _MoanSpamBehaviour;

        internal static UdonBehaviour_Cached MoanSpamBehaviour
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_MoanSpamBehaviour == null)
                {
                    return _MoanSpamBehaviour = UdonSearch.FindUdonEvent("Sounds", "_GruntHit");
                }
                return _MoanSpamBehaviour;
            }
        }

        private static UdonBehaviour_Cached _FallSpamBehaviour;

        internal static UdonBehaviour_Cached FallSpamBehaviour
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_FallSpamBehaviour == null)
                {
                    return _FallSpamBehaviour = UdonSearch.FindUdonEvent("NPC Animations Udon", "PlayFall");
                }
                return _FallSpamBehaviour;
            }
        }

        //private static UdonBehaviour_Cached _ProcessPatrons;

        //internal static UdonBehaviour_Cached ProcessPatrons
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_ProcessPatrons == null)
        //        {
        //            return _ProcessPatrons = UdonSearch.FindUdonEvent("Patreon", "_ProcessPatrons");
        //        }
        //        return _ProcessPatrons;
        //    }
        //}

        //private static UdonBehaviour_Cached _ProcessPatronsTest;

        //internal static UdonBehaviour_Cached ProcessPatronsTest
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_ProcessPatronsTest == null)
        //        {
        //            return _ProcessPatronsTest = UdonSearch.FindUdonEvent("Patreon", "_ProcessPatronsTest");
        //        }
        //        return _ProcessPatronsTest;
        //    }
        //}

        //private static UdonBehaviour_Cached _EjectNonVips;

        //internal static UdonBehaviour_Cached EjectNonVips
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_EjectNonVips == null)
        //        {
        //            return _EjectNonVips = UdonSearch.FindUdonEvent("Patreon", "_EjectNonVips");
        //        }
        //        return _EjectNonVips;
        //    }
        //}
        //private static UdonBehaviour_Cached _EjectSelfIfNotVip;

        //internal static UdonBehaviour_Cached EjectSelfIfNotVip
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_EjectSelfIfNotVip == null)
        //        {
        //            return _EjectSelfIfNotVip = UdonSearch.FindUdonEvent("Patreon", "EjectSelfIfNotVip");
        //        }
        //        return _EjectSelfIfNotVip;
        //    }
        //}
        //private static UdonBehaviour_Cached _PlayLeaveBedroom7;

        //internal static UdonBehaviour_Cached PlayLeaveBedroom7
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_PlayLeaveBedroom7 == null)
        //        {
        //            return _PlayLeaveBedroom7 = UdonSearch.FindUdonEvent("Teleports", "PlayLeaveBedroom7");
        //        }
        //        return _PlayLeaveBedroom7;
        //    }
        //}
        //private static UdonBehaviour_Cached _TeleportToBedroomOutside7;

        //internal static UdonBehaviour_Cached TeleportToBedroomOutside7
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_TeleportToBedroomOutside7 == null)
        //        {
        //            return _TeleportToBedroomOutside7 = UdonSearch.FindUdonEvent("Teleports", "_TeleportToBedroomOutside7");
        //        }
        //        return _TeleportToBedroomOutside7;
        //    }
        //}

        //private static ImageRenderCameraReader _RenderCameraReader;

        //internal static ImageRenderCameraReader RenderCameraReader
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (Decoder_Debug == null) return null;
        //        else
        //        {
        //            Decoder_Debug.SetActive(true);
        //        }
        //        if (RenderCamera == null) return null;
        //        else
        //        {
        //            RenderCamera.SetActive(true);
        //        }

        //        if (_RenderCameraReader == null)
        //        {
        //            return _RenderCameraReader = RenderCamera.GetOrAddComponent<ImageRenderCameraReader>();
        //        }
        //        return _RenderCameraReader;
        //    }
        //}

        //internal static bool _BlockVIPRoom_Kick = false;

        //internal static bool BlockVIPRoom_Kick
        //{
        //    get => _BlockVIPRoom_Kick;
        //    set
        //    {
        //        if(TeleportToBedroomOutside7 != null)
        //        {
        //            if(value)
        //            {
        //                TeleportToBedroomOutside7.Add_UdonFirewall_Rule(false, false, true);
        //            }
        //            else
        //            {
        //                TeleportToBedroomOutside7.Remove_UdonFirewall_Rule();
        //            }

        //            _BlockVIPRoom_Kick = value;
        //        }
        //    }
        //}

        #endregion Udon Behaviours Cached and other random stuff

        internal static string CurrentDisplayName
        {
            get
            {
                return PlayerSpooferUtils.Original_DisplayName;
            }
        }

        private static object MoanSpam_CancellationToken;
        private static object FallSpam_CancellationToken;
        private static object RainbowSpam_CancellationToken;

        internal static QMNestedGridMenu BClubExploitsPage;

        private static QMToggleButton ToggleRainbowBtn;
        private static QMToggleButton ToggleMoanSpamBtn;
        private static QMToggleButton ToggleFallSpamBtn;

        private static bool _isRainbowEnabled;
        private static bool _isMoanSpamEnabled;
        private static bool _isFallSpamEnabled;
        private static bool _isLocalPlayerSupporter;

        private static bool _isCurrentWorld;

        private static bool isCurrentWorld
        {
            get => _isCurrentWorld;
            set
            {
                _isCurrentWorld = value;
                if (!value)
                {
                    IsRainbowEnabled = false;
                    IsMoanSpamEnabled = false;
                    IsFallSpamEnabled = false;
                    _isLocalPlayerSupporter = false;
                    //InterceptUdonCustomEvent = false;
                    // Bells.Clear();
                    // Chairs.Clear();
                    ColorActions.Clear();
                    _MoanSpamBehaviour = null;
                    _FallSpamBehaviour = null;
                    //_ProcessPatrons = null;
                    //_RenderCameraReader = null;
                    MoanSpam_CancellationToken = null;
                    FallSpam_CancellationToken = null;
                    RainbowSpam_CancellationToken = null;
                    HasSubscribed = false;
                    UnityDestroyBlock.MonitorDestroyingEvent = false;
                }
            }
        }

        private static List<UdonBehaviour_Cached> ColorActions = new List<UdonBehaviour_Cached>();

        internal static bool isLocalPlayerSupporter
        {
            get => _isLocalPlayerSupporter;

            private set
            {
                if (value)
                {
                    Log.Debug($"{CurrentDisplayName} Gained Patron Access!", System.Drawing.Color.Chartreuse);
                }
                else
                {
                    Log.Debug($"{CurrentDisplayName} Lost Patron Access!", System.Drawing.Color.Red);
                }
                _isLocalPlayerSupporter = value;
            }
        }

        internal static bool IsRainbowEnabled
        {
            get => _isRainbowEnabled;
            set
            {
                if (value)
                {
                    if (RainbowSpam_CancellationToken == null)
                    {
                        Log.Write("Rainbow Enabled!");
                        Rainbow();
                    }
                }
                else
                {
                    if (RainbowSpam_CancellationToken != null)
                    {
                        Log.Write("Rainbow Disabled.");
                        MelonCoroutines.Stop(RainbowSpam_CancellationToken);
                        RainbowSpam_CancellationToken = null;
                    }
                }
                if (ToggleRainbowBtn != null)
                {
                    ToggleRainbowBtn.SetToggleState(value, false);
                }
                _isRainbowEnabled = value;
            }
        }

        #region MoanSpam

        internal static bool IsMoanSpamEnabled
        {
            get => _isMoanSpamEnabled;
            set
            {
                if (value)
                {
                    if (MoanSpam_CancellationToken == null)
                    {
                        Log.Write("Moan Spam Enabled!");
                        MoanSpam();
                    }
                }
                else
                {
                    if (MoanSpam_CancellationToken != null)
                    {
                        Log.Write("Moan Spam Disabled.");
                        MelonCoroutines.Stop(MoanSpam_CancellationToken);
                        MoanSpam_CancellationToken = null;
                    }
                }
                if (ToggleMoanSpamBtn != null)
                {
                    ToggleMoanSpamBtn.SetToggleState(value, false);
                }
                _isMoanSpamEnabled = value;
            }
        }

        #endregion MoanSpam

        #region FallSpam

        internal static bool IsFallSpamEnabled
        {
            get => _isFallSpamEnabled;
            set
            {
                if (value)
                {
                    if (FallSpam_CancellationToken == null)
                    {
                        Log.Write("Fall Spam Enabled!");
                        FallSpam();
                    }
                }
                else
                {
                    if (FallSpam_CancellationToken != null)
                    {
                        Log.Write("Fall Spam Disabled.");
                        MelonCoroutines.Stop(FallSpam_CancellationToken);
                        FallSpam_CancellationToken = null;
                    }
                }
                if (ToggleFallSpamBtn != null)
                {
                    ToggleFallSpamBtn.SetToggleState(value, false);
                }
                _isFallSpamEnabled = value;
            }
        }

        #endregion FallSpam

        //private static bool _BlockPatronProcessor = false;

        //internal static bool BlockPatronProcessor
        //{
        //    get => _BlockPatronProcessor;
        //    set
        //    {
        //        if (_BlockPatronProcessor != value)
        //        {
        //            if (value)
        //            {
        //                //GameObject_RPC_Firewall.EditRule("Patreon", "_ProcessPatrons", false, false, true);
        //                //GameObject_RPC_Firewall.EditRule("Patreon", "_ProcessPatronsTest", false, false, true);
        //                //GameObject_RPC_Firewall.EditRule("Patreon", "__0__ProcessPatrons", false, false, true);
        //                GameObject_RPC_Firewall.EditRule("New avatar image reader (TMP)", "_DecodeStepUTF16", false, false, true);
        //                GameObject_RPC_Firewall.EditRule("New avatar image reader (TMP)", "_DecodeStepUTF8", false, false, true);

                        
        //            }
        //            else
        //            {
        //                //GameObject_RPC_Firewall.RemoveRule("Patreon", "_ProcessPatrons");
        //                //GameObject_RPC_Firewall.RemoveRule("Patreon", "_ProcessPatronsTest");
        //                //GameObject_RPC_Firewall.RemoveRule("Patreon", "__0__ProcessPatrons");
        //                GameObject_RPC_Firewall.RemoveRule("New avatar image reader (TMP)", "_DecodeStepUTF16");
        //                GameObject_RPC_Firewall.RemoveRule("New avatar image reader (TMP)", "_DecodeStepUTF8");

        //            }
        //        }
        //        _BlockPatronProcessor = value;
        //    }
        //}
        private static UdonBehaviour_Cached _DecodeStep;

        internal static UdonBehaviour_Cached DecodeStep
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_DecodeStep == null)
                {
                    return _DecodeStep = UdonSearch.FindUdonEvent("New avatar image reader (TMP)", "_DecodeStepUTF16");
                }
                return _DecodeStep;
            }
        }

        //internal static void ForceEliteTier()
        //{
        //    try
        //    {
        //        if (RenderCameraReader == null)
        //        {
        //            Log.Warn($"Unable to Force Elite Tier due to RenderCamera Reader being Null!");
        //            return;
        //        }

                
        //    }
        //    catch { } // SHUT UP
        //}

        internal static void InitButtons(QMGridTab main)
        {
            BClubExploitsPage = new QMNestedGridMenu(main, "BClub 2 Lobby Exploits", "BClub Exploits");

            // Freeze Locks

            var MapFun = new QMNestedGridMenu(BClubExploitsPage, "World Fun", "Some Random Fun things");

            // Rainbow
            ToggleRainbowBtn = new QMToggleButton(MapFun, "Rainbow", () => { IsRainbowEnabled = true; }, () => { IsRainbowEnabled = false; }, "Rainbow", Color.green, Color.red);
            ToggleRainbowBtn.SetToggleState(IsRainbowEnabled, false);
            ToggleMoanSpamBtn = new QMToggleButton(MapFun, "Moan Spam", () => { IsMoanSpamEnabled = true; }, () => { IsMoanSpamEnabled = false; }, "Moan Spam", Color.green, Color.red);
            ToggleMoanSpamBtn.SetToggleState(IsMoanSpamEnabled, false);
            ToggleFallSpamBtn = new QMToggleButton(MapFun, "Fall Spam", () => { IsFallSpamEnabled = true; }, () => { IsFallSpamEnabled = false; }, "Fall Spam", Color.green, Color.red);
            ToggleFallSpamBtn.SetToggleState(IsFallSpamEnabled, false);

            // VIP
        }

        //internal static void OnBlockedDestroy(string path)
        //{
        //    if (path == "Udon 3rd Party/New avatar image reader (TMP)")
        //    {
        //        UnityDestroyBlock.MonitorDestroyingEvent = false;
        //    }
        //}

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.JustBClub2Lobby) || id.Equals(WorldIds.JustBClub2))
            {
                if (BClubExploitsPage != null)
                {
                    BClubExploitsPage.SetInteractable(true);
                    BClubExploitsPage.SetTextColor(Color.green);
                }

                Log.Write($"Recognized {Name} World! This world has an exploit menu, and other extra goodies!");

                var Root = Finder.Find("Just B Club 2");
                var VIPPath = Root.transform.FindObject("VIP/Udon VIP/Canvas TP/Room Canvas/UICanvas/UIHover/Main Canvas/Intercom/Left/Padding/Buttons");

                var VerticalLayout = VIPPath.GetComponent<VerticalLayoutGroup>();
                if(VerticalLayout != null)
                {
                    VerticalLayout.enabled = true;
                }

                foreach (var item in VIPPath.Get_Childs())
                {
                    if (item != null)
                    {
                        var enabler = item.GetOrAddComponent<Enabler>();
                        if (enabler != null)
                        {
                            enabler.ForceStart();
                        }
                        item.gameObject.SetActive(true);
                        var rect = item.GetComponent<RectTransform>();
                        if (rect != null)
                        {
                            if (item.name.Equals("Button | _TryToggleVipOnly"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -90);
                            }
                            if (item.name.Equals("Button | _Lock"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -320);
                            }
                            if (item.name.Equals("Button | _Dnd"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -550);
                            }
                            if (item.name.Equals("Button | _Anon"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -780);
                            }
                            if (item.name.Equals("Button | _Looking"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -1010);
                            }
                        }
                    }
                }

                //MiscUtils.DelayFunction(2f, () =>
                //{
                //    Log.Debug("Rainbow Exploit!");

                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Red"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Red"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Cyan"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Cyan"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Pink"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Pink"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Purple"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Purple"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Green"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Green"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Blue"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Blue"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Yellow"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Yellow"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Orange"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Orange"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1White"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2White"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Black"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Black"));
                //});

                if (Cancer_Spawn != null)
                {
                    Cancer_Spawn.DestroyMeLocal();
                }

                if (isLocalPlayerSupporter)
                {
                    //
                }
            }
            else
            {
                if (isCurrentWorld)
                {
                    isCurrentWorld = false;
                }
                HasSubscribed = false;
                if (BClubExploitsPage != null)
                {
                    BClubExploitsPage.SetInteractable(false);
                    BClubExploitsPage.SetTextColor(Color.red);
                }
            }
        }

        private static void OnUnityLog(string message)
        {
            if (!isCurrentWorld) return;
            if (message.Contains("[Patreon]"))
            {
                if (message.Contains("IsSupporter = true"))
                {
                    if (!isLocalPlayerSupporter)
                    {
                        isLocalPlayerSupporter = true;
                    }
                }
                if (message.Contains("[Patreon] IsSupporter = false. Toggle vipObjects"))
                {
                   // ForceEliteTier();
                    if (isLocalPlayerSupporter)
                    {
                        isLocalPlayerSupporter = false;
                    }
                }
            }
        }

        private static void Rainbow()
        {
            RainbowSpam_CancellationToken = MelonCoroutines.Start(RainbowLoop());
        }

        private static IEnumerator RainbowLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsRainbowEnabled = false;
                    yield break;
                }

                for (int i = 0; i < ColorActions.Count; i++)
                {
                    ColorActions[i]?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.1f);
                }

                yield return null;
            }
        }

        private static void MoanSpam()
        {
            MoanSpam_CancellationToken = MelonCoroutines.Start(MoanSpamLoop());
        }

        private static void FallSpam()
        {
            FallSpam_CancellationToken = MelonCoroutines.Start(FallSpamLoop());
        }

        private static IEnumerator MoanSpamLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsMoanSpamEnabled = false;
                    yield break;
                }

                MoanSpamBehaviour?.InvokeBehaviour();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private static IEnumerator FallSpamLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsFallSpamEnabled = false;
                    yield break;
                }

                FallSpamBehaviour?.InvokeBehaviour();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private static void OnRoomLeft()
        {
            if (isCurrentWorld)
            {
                isCurrentWorld = false;

                Log.Write("Done unloading B Club 2 Lobby..");
            }
        }

        //private static IEnumerator BypassElevator()
        //{
        //    Log.Debug("Elevator Bypass Started", System.Drawing.Color.Aquamarine);
        //    var elevator = Lobby.transform.FindObject("New Part/Udon/Warning");

        //    while (elevator == null) yield return new WaitForSeconds(0.001f);
        //    while (elevator.gameObject.active)
        //    {
        //        var udons = elevator.GetComponentsInChildren<UdonBehaviour>();
        //        for (int i = 0; i < udons.Count; i++)
        //        {
        //            UdonBehaviour udon = udons[i];
        //            if (udon != null)
        //            {
        //                udon.Interact();
        //            }
        //        }

        //        if (!elevator.gameObject.active)
        //        {
        //            Log.Debug("Unable to Bypass Elevator Warning.", System.Drawing.Color.Aquamarine);
        //            yield return new WaitForSeconds(0.5f);
        //        }
        //        else
        //        {
        //            Log.Debug("Bypassed Elevator Warning!", System.Drawing.Color.Aquamarine);
        //            yield break;
        //        }
        //    }

        //    yield return null;
        //}

        //private static void Udon_SendCustomEvent(UdonBehaviour item, string EventName)
        //{
        //    if (!isCurrentWorld) return;
        //    if (item == null) return;
        //    if (EventName.IsNullOrEmptyOrWhiteSpace()) return;
        //    if (item.name.Equals("New avatar image reader (TMP)"))
        //    {
        //        RenderCameraReader.HijackUdon();
        //    }
        //    if(item.name.Equals("Patreon"))
        //    {
        //        PatronSystemReader.HijackUdon();
        //    }

        //}

        //private static IEnumerator ForcePatronReader()
        //{
        //    while (PatronSystemReader == null) yield return null;
        //    Log.Debug("Patron Reader Installed!");
        //    yield break;
        //}

        //private static IEnumerator ForceEnableRenderCamera()
        //{
        //    while (RenderCameraReader == null) yield return null;
        //    Log.Debug("RenderCamera Reader Installed!");
        //    yield break;
        //}
    }
}