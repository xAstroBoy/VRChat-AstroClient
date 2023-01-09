using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Cheats.PatronCrackers;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.Constants;
using AstroClient.CustomClasses;
using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using UnityEngine;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks.BlueKun
{
    #region Imports

    #endregion Imports

    // TODO: Update the patron bypass with the new system.
    internal class JustBClub1 : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
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
                        //ClientEventActions.Udon_SendCustomEvent += UdonBehaviour_Event_SendCustomEvent;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnUnityLog -= OnUnityLog;
                        //ClientEventActions.Udon_SendCustomEvent -= UdonBehaviour_Event_SendCustomEvent;

                    }
                }
                _HasSubscribed = value;
            }
        }

        #region World Paths

        private static GameObject _Bedroom_VIP;

        internal static GameObject Bedroom_VIP
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Bedroom_VIP == null)
                {
                    return _Bedroom_VIP = Finder.FindRootSceneObject("Bedroom VIP");
                }
                return _Bedroom_VIP;
            }
        }

        private static GameObject _Lobby;

        internal static GameObject Lobby
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Lobby == null)
                {
                    return _Lobby = Finder.FindRootSceneObject("Lobby");
                }
                return _Lobby;
            }
        }

        private static GameObject _Udon;

        internal static GameObject Udon
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Udon == null)
                {
                    return _Udon = Finder.FindRootSceneObject("Udon");
                }
                return _Udon;
            }
        }

        private static GameObject _VIPRoomEntrance;

        internal static GameObject VIPRoomEntrance
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_VIPRoomEntrance == null)
                {
                    return _VIPRoomEntrance = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance VIP").gameObject;
                }
                return _VIPRoomEntrance;
            }
        }

        private static GameObject _VIPRoom_OutsideDoor;

        internal static GameObject VIPRoom_OutsideDoor
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (VIPRoomEntrance == null) return null;
                if (_VIPRoom_OutsideDoor == null)
                {
                    return _VIPRoom_OutsideDoor = VIPRoomEntrance.transform.FindObject("Door001 (1)").gameObject;
                }
                return _VIPRoom_OutsideDoor;
            }
        }


        private static GameObject _Penthouse;

        internal static GameObject Penthouse
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Penthouse == null)
                {
                    return _Penthouse = Finder.FindRootSceneObject("Penthouse");
                }
                return _Penthouse;
            }
        }

        private static GameObject _Bedrooms;

        internal static GameObject Bedrooms
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Bedrooms == null)
                {
                    return _Bedrooms = Finder.FindRootSceneObject("Bedrooms");
                }
                return _Bedrooms;
            }
        }

        private static GameObject _Decoder_Debug;

        internal static GameObject Decoder_Debug
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Decoder_Debug == null)
                {
                    return _Decoder_Debug = Finder.FindRootSceneObject("Decoder_Debug");
                }
                return _Decoder_Debug;
            }
        }

        private static GameObject _RenderCamera;

        internal static GameObject RenderCamera
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Decoder_Debug == null) return null;
                if (_RenderCamera == null)
                {
                    return _RenderCamera = Decoder_Debug.transform.FindObject("RenderCamera").gameObject;
                }
                return _RenderCamera;
            }
        }

        private static GameObject _VIPButton;

        internal static GameObject VIPButton
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Bedroom_VIP == null) return null;
                if (_VIPButton == null)
                {
                    return _VIPButton = Bedroom_VIP.transform.FindObject("BedroomUdon/Door Tablet/BlueButtonWide - Toggle VIP only").gameObject;
                }
                return _VIPButton;
            }
        }


        private static GameObject _VIPRoom_Internal_Door;

        internal static GameObject VIPRoom_Internal_Door
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Bedroom_VIP == null) return null;
                if (_VIPRoom_Internal_Door == null)
                {
                    return _VIPRoom_Internal_Door = Bedroom_VIP.transform.FindObject("BedroomUdon/Door Inside/Door").gameObject;
                }
                return _VIPRoom_Internal_Door;
            }
        }

        private static GameObject _LockIndicator_1;

        internal static GameObject LockIndicator_1
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_LockIndicator_1 == null)
                {
                    return _LockIndicator_1 = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 1/Screen/Canvas/Indicators/Locked").gameObject;
                }
                return _LockIndicator_1;
            }
        }

        private static GameObject _LockIndicator_2;

        internal static GameObject LockIndicator_2
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_LockIndicator_2 == null)
                {
                    return _LockIndicator_2 = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 2/Screen/Canvas/Indicators/Locked").gameObject;
                }
                return _LockIndicator_2;
            }
        }

        private static GameObject _LockIndicator_3;

        internal static GameObject LockIndicator_3
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_LockIndicator_3 == null)
                {
                    return _LockIndicator_3 = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 3/Screen/Canvas/Indicators/Locked").gameObject;
                }
                return _LockIndicator_3;
            }
        }

        private static GameObject _LockIndicator_4;

        internal static GameObject LockIndicator_4
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_LockIndicator_4 == null)
                {
                    return _LockIndicator_4 = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 4/Screen/Canvas/Indicators/Locked").gameObject;
                }
                return _LockIndicator_4;
            }
        }

        private static GameObject _LockIndicator_5;

        internal static GameObject LockIndicator_5
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_LockIndicator_5 == null)
                {
                    return _LockIndicator_5 = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 5/Screen/Canvas/Indicators/Locked").gameObject;
                }
                return _LockIndicator_5;
            }
        }

        private static GameObject _LockIndicator_6;

        internal static GameObject LockIndicator_6
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_LockIndicator_6 == null)
                {
                    return _LockIndicator_6 = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 6/Screen/Canvas/Indicators/Locked").gameObject;
                }
                return _LockIndicator_6;
            }
        }

        private static GameObject _LockIndicator_VIP;

        internal static GameObject LockIndicator_VIP
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Penthouse == null) return null;
                if (_LockIndicator_VIP == null)
                {
                    return _LockIndicator_VIP = Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance VIP/Screen (1)/Canvas/Indicators/Locked").gameObject;
                }
                return _LockIndicator_VIP;
            }
        }

        private static GameObject _VIP_Outside_Door_Entrance;

        internal static GameObject VIP_Outside_Door_Entrance
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (VIPRoomEntrance == null) return null;
                if (_VIP_Outside_Door_Entrance == null)
                {
                    return _VIP_Outside_Door_Entrance = VIPRoomEntrance.transform.FindObject("Door001 (1)").gameObject;
                }
                return _VIP_Outside_Door_Entrance;
            }
        }

        private static GameObject _VIPControls;

        internal static GameObject VIPControls
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Lobby == null) return null;
                if (_VIPControls == null)
                {
                    return _VIPControls = Lobby.transform.FindObject("Udon/MyI Control Panel").gameObject;
                }
                return _VIPControls;
            }
        }

        private static GameObject _Cancer_Spawn;

        internal static GameObject Cancer_Spawn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Lobby == null) return null;
                if (_Cancer_Spawn == null)
                {
                    return _Cancer_Spawn = Lobby.transform.FindObject("New Part").FindObject("Cancer Spawn").gameObject;
                }
                return _Cancer_Spawn;
            }
        }

        private static GameObject _ElevatorFlairBtn;

        internal static GameObject ElevatorFlairBtn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Lobby == null) return null;
                if (_ElevatorFlairBtn == null)
                {
                    return _ElevatorFlairBtn = Lobby.transform.FindObject("New Part/Udon/Spawn Settings/Buttons/Own Flair - BlueButtonWide").gameObject;
                }
                return _ElevatorFlairBtn;
            }
        }

        private static GameObject _FlairBtnTablet;

        internal static GameObject FlairBtnTablet
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Udon == null) return null;
                if (_FlairBtnTablet == null)
                {
                    return _FlairBtnTablet = Udon.transform.FindObject("Main Controls/New Contents/Pages/World/Buttons/Own Flair - BlueButtonWide").gameObject;
                }
                return _FlairBtnTablet;
            }
        }

        #endregion World Paths

        #region Udon Behaviours Cached and other random stuff

        private static UdonBehaviour_Cached _MoanSpamBehaviour;

        internal static UdonBehaviour_Cached MoanSpamBehaviour
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_MoanSpamBehaviour == null)
                {
                    return _MoanSpamBehaviour = UdonSearch.FindUdonEvent("NPC Audio Udon", "PlayGruntHurt");
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

        private static UdonBehaviour_Cached _ProcessPatronsFromReadRenderTexture;

        internal static UdonBehaviour_Cached ProcessPatronsFromReadRenderTexture
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_ProcessPatronsFromReadRenderTexture == null)
                {
                    return _ProcessPatronsFromReadRenderTexture = UdonSearch.FindUdonEvent("Patreon", "_ProcessPatronsFromReadRenderTexture");
                }
                return _ProcessPatronsFromReadRenderTexture;
            }
        }

        private static UdonBehaviour_Cached _ReadPictureStep;

        internal static UdonBehaviour_Cached ReadPictureStep
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_ReadPictureStep == null)
                {
                    return _ReadPictureStep = UdonSearch.FindUdonEvent("RenderCamera", "ReadPictureStep");
                }
                return _ReadPictureStep;
            }
        }
        private static UdonBehaviour_Cached _EjectNonVips;

        internal static UdonBehaviour_Cached EjectNonVips
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_EjectNonVips == null)
                {
                    return _EjectNonVips = UdonSearch.FindUdonEvent("Patreon", "_EjectNonVips");
                }
                return _EjectNonVips;
            }
        }
        private static UdonBehaviour_Cached _EjectSelfIfNotVip;

        internal static UdonBehaviour_Cached EjectSelfIfNotVip
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_EjectSelfIfNotVip == null)
                {
                    return _EjectSelfIfNotVip = UdonSearch.FindUdonEvent("Patreon", "EjectSelfIfNotVip");
                }
                return _EjectSelfIfNotVip;
            }
        }
        private static UdonBehaviour_Cached _PlayLeaveBedroom7;

        internal static UdonBehaviour_Cached PlayLeaveBedroom7
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_PlayLeaveBedroom7 == null)
                {
                    return _PlayLeaveBedroom7 = UdonSearch.FindUdonEvent("Teleports", "PlayLeaveBedroom7");
                }
                return _PlayLeaveBedroom7;
            }
        }
        private static UdonBehaviour_Cached _TeleportToBedroomOutside7;

        internal static UdonBehaviour_Cached TeleportToBedroomOutside7
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_TeleportToBedroomOutside7 == null)
                {
                    return _TeleportToBedroomOutside7 = UdonSearch.FindUdonEvent("Teleports", "_TeleportToBedroomOutside7");
                }
                return _TeleportToBedroomOutside7;
            }
        }

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
        //            return _RenderCameraReader = ComponentUtils.GetOrAddComponent<ImageRenderCameraReader>(RenderCamera);
        //        }
        //        return _RenderCameraReader;
        //    }
        //}

        internal static bool _BlockVIPRoom_Kick = false;

        internal static bool BlockVIPRoom_Kick
        {
            get => _BlockVIPRoom_Kick;
            set
            {
                if(TeleportToBedroomOutside7 != null)
                {
                    if(value)
                    {
                        TeleportToBedroomOutside7.Add_UdonFirewall_Rule(false, false, true);
                    }
                    else
                    {
                        TeleportToBedroomOutside7.Remove_UdonFirewall_Rule();
                    }


                    _BlockVIPRoom_Kick = value;
                }
            }
        }
        

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
        private static object DoorLockFreeze_CancellationToken;
        private static object DoorUnlockFreeze_CancellationToken;
        private static object BlueChairSpam_CancellationToken;
        private static object RainbowSpam_CancellationToken;
        private static object DoorbellSpam_CancellationToken;

        internal static QMNestedGridMenu BClubExploitsPage;

        private static QMToggleButton FreezeLockedToggle;
        private static QMToggleButton FreezeUnlockedToggle;
        private static QMToggleButton BlueChairToggle;
        private static QMToggleButton LockButton1;
        private static QMToggleButton LockButton2;
        private static QMToggleButton LockButton3;
        private static QMToggleButton LockButton4;
        private static QMToggleButton LockButton5;
        private static QMToggleButton LockButton6;
        private static QMToggleButton LockButton7;

        private static QMToggleButton SpoofAsWorldAuthorBtn;
        private static QMToggleButton ToggleRainbowBtn;
        private static QMToggleButton ToggleMoanSpamBtn;
        private static QMToggleButton ToggleFallSpamBtn;

        private static bool _isFreezeLockEnabed;
        private static bool _isFreezeUnlockEnabed;
        private static bool _isRainbowEnabled;
        private static bool _isMoanSpamEnabled;
        private static bool _isFallSpamEnabled;
        private static bool _isLocalPlayerElite;
        private static bool _isLocalPlayerPatron;
        private static bool _isDoorBellSpamEnabled;
        private static bool _isBlueChairEnabed;

        private static bool _isCurrentWorld;

        private static bool isCurrentWorld
        {
            get => _isCurrentWorld;
            set
            {
                _isCurrentWorld = value;
                if (!value)
                {
                    IsBlueChairEnabled = false;
                    IsDoorbellSpamEnabled = false;
                    IsFreezeLockEnabed = false;
                    IsFreezeUnlockEnabed = false;
                    IsRainbowEnabled = false;
                    IsMoanSpamEnabled = false;
                    IsFallSpamEnabled = false;
                    _isLocalPlayerElite = false;
                    _isLocalPlayerPatron = false;
                    _BlockVIPRoom_Kick = false;
                    _PlayLeaveBedroom7 = null;
                    _TeleportToBedroomOutside7 = null;
                    _EjectSelfIfNotVip = null;
                    _VIPRoom_Internal_Door = null;
                    _VIP_Outside_Door_Entrance = null;

                    Bells.Clear();
                    Chairs.Clear();
                    ColorActions.Clear();

                    _Bedroom_VIP = null;
                    _Lobby = null;
                    _Udon = null;
                    _VIPRoomEntrance = null;
                    _Penthouse = null;
                    _Bedrooms = null;
                    _VIPButton = null;
                    _LockIndicator_1 = null;
                    _LockIndicator_2 = null;
                    _LockIndicator_3 = null;
                    _LockIndicator_4 = null;
                    _LockIndicator_5 = null;
                    _LockIndicator_6 = null;
                    _LockIndicator_VIP = null;
                    _VIP_Outside_Door_Entrance = null;
                    _VIPControls = null;
                    _Cancer_Spawn = null;
                    _ElevatorFlairBtn = null;
                    _FlairBtnTablet = null;
                    _Decoder_Debug = null;
                    _RenderCamera = null;

                    LockIndicator1_Listener = null;
                    LockIndicator2_Listener = null;
                    LockIndicator3_Listener = null;
                    LockIndicator4_Listener = null;
                    LockIndicator5_Listener = null;
                    LockIndicator6_Listener = null;
                    LockIndicator7_Listener = null;

                    _MoanSpamBehaviour = null;
                    _FallSpamBehaviour = null;
                    _ProcessPatronsFromReadRenderTexture = null;
                    _ReadPictureStep = null;
                    //_RenderCameraReader = null;
                    MoanSpam_CancellationToken = null;
                    FallSpam_CancellationToken = null;
                    DoorLockFreeze_CancellationToken = null;
                    DoorUnlockFreeze_CancellationToken = null;
                    BlueChairSpam_CancellationToken = null;
                    RainbowSpam_CancellationToken = null;
                    DoorbellSpam_CancellationToken = null;
                    HasSubscribed = false;
                }
            }
        }

        private static QMToggleButton SpamDoorbellsToggle;

        private static List<UdonBehaviour_Cached> ColorActions = new List<UdonBehaviour_Cached>();
        private static List<UdonBehaviour_Cached> Bells = new List<UdonBehaviour_Cached>();

        private static List<UdonBehaviour_Cached> Chairs = new List<UdonBehaviour_Cached>();

        private static GameObjectListener LockIndicator1_Listener;
        private static GameObjectListener LockIndicator2_Listener;
        private static GameObjectListener LockIndicator3_Listener;
        private static GameObjectListener LockIndicator4_Listener;
        private static GameObjectListener LockIndicator5_Listener;
        private static GameObjectListener LockIndicator6_Listener;
        private static GameObjectListener LockIndicator7_Listener;

        internal static bool isLocalPlayerElite
        {
            get => _isLocalPlayerElite;

            private set
            {
                if (value)
                {
                    Log.Debug($"{CurrentDisplayName} Gained Elite Access!", System.Drawing.Color.Chartreuse);
                }
                else
                {
                    Log.Debug($"{CurrentDisplayName} Lost Elite Access!", System.Drawing.Color.Red);
                }
                _isLocalPlayerElite = value;
            }
        }

        internal static bool isLocalPlayerPatron
        {
            get => _isLocalPlayerPatron;

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
                _isLocalPlayerPatron = value;
            }
        }

        #region BlueChairSpam

        internal static bool IsBlueChairEnabled
        {
            get => _isBlueChairEnabed;
            set
            {
                if (value)
                {
                    if (DoorbellSpam_CancellationToken == null)
                    {
                        Log.Write("BlueChair Enabled!");
                        BlueChairSpam();
                    }

                }
                else
                {
                    if (BlueChairSpam_CancellationToken != null)
                    {
                        Log.Write("BlueChair Disabled!");
                        MelonCoroutines.Stop(BlueChairSpam_CancellationToken);
                        BlueChairSpam_CancellationToken = null;
                    }
                }
                if (BlueChairToggle != null)
                {
                    BlueChairToggle.SetToggleState(value, false);
                }

                _isBlueChairEnabed = value;
            }
        }

        #endregion BlueChairSpam

        #region DoorbellSpam

        internal static bool IsDoorbellSpamEnabled
        {
            get => _isDoorBellSpamEnabled;
            set
            {
                if (value)
                {
                    if (DoorbellSpam_CancellationToken == null)
                    {
                        Log.Write("Doorbell Spam Enabled!");
                        SpamDoorbells();
                    }
                }
                else
                {
                    if (DoorbellSpam_CancellationToken != null)
                    {
                        Log.Write("Doorbell Spam Disabled!");
                        MelonCoroutines.Stop(DoorbellSpam_CancellationToken);
                        DoorbellSpam_CancellationToken = null;
                    }
                }
                if (SpamDoorbellsToggle != null)
                {
                    SpamDoorbellsToggle.SetToggleState(value, false);
                }

                _isDoorBellSpamEnabled = value;
            }
        }

        #endregion DoorbellSpam

        internal static bool IsFreezeLockEnabed
        {
            get => _isFreezeLockEnabed;
            set
            {
                if (value)
                {
                    if (DoorLockFreeze_CancellationToken == null)
                    {
                        Log.Write("Door Locks Frozen: Locked");
                        if (IsFreezeUnlockEnabed) IsFreezeUnlockEnabed = false;
                        DoorLockFreeze();
                    }
                }
                else
                {
                    if (DoorLockFreeze_CancellationToken != null)
                    {
                        Log.Write("Door Locks Unfrozen");
                        MelonCoroutines.Stop(DoorLockFreeze_CancellationToken);
                        DoorLockFreeze_CancellationToken = null;
                    }
                }
                if (FreezeUnlockedToggle != null)
                {
                    FreezeUnlockedToggle.SetToggleState(value, false);
                }

                _isFreezeLockEnabed = value;
            }
        }

        internal static bool IsFreezeUnlockEnabed
        {
            get => _isFreezeUnlockEnabed;
            set
            {
                if (value)
                {
                    if (DoorUnlockFreeze_CancellationToken == null)
                    {
                        Log.Write("Door Locks Frozen: Unlocked");
                        if (IsFreezeLockEnabed) IsFreezeLockEnabed = false;
                        DoorUnlockFreeze();
                    }
                }
                else
                {
                    if (DoorUnlockFreeze_CancellationToken != null)
                    {
                        Log.Write("Door Locks Unfrozen");
                        MelonCoroutines.Stop(DoorUnlockFreeze_CancellationToken);
                        DoorUnlockFreeze_CancellationToken = null;
                    }
                }
                if (FreezeUnlockedToggle != null)
                {
                    FreezeUnlockedToggle.SetToggleState(value, false);
                }

                _isFreezeUnlockEnabed = value;
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

        internal static GameObjectListener RegisterListener(GameObject Object, Action OnEnabled, Action OnDisabled, Action OnDestroy)
        {
            if (Object != null)
            {
                var listener = ComponentUtils.GetOrAddComponent<GameObjectListener>(Object);
                MiscUtils.DelayFunction(1f, () =>
                {
                    if (listener != null)
                    {
                        listener.OnEnabled += OnEnabled;
                        listener.OnDisabled += OnDisabled;
                        listener.OnDestroyed += OnDestroy;
                    }
                });
                return listener;
            }
            return null;
        }

        internal static void InitButtons(QMGridTab main)
        {
            BClubExploitsPage = new QMNestedGridMenu(main, "BClub Exploits", "BClub Exploits");

            var DoorController = new QMNestedGridMenu(BClubExploitsPage, "Private Rooms Door", "Control B Club Doors ");

            // Locks
            LockButton1 = new QMToggleButton(DoorController, "Unlock 1", () => { ToggleDoor(1); }, "Lock 1", () => { ToggleDoor(1); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton2 = new QMToggleButton(DoorController, "Unlock 2", () => { ToggleDoor(2); }, "Lock 2", () => { ToggleDoor(2); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton3 = new QMToggleButton(DoorController, "Unlock 3", () => { ToggleDoor(3); }, "Lock 3", () => { ToggleDoor(3); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton4 = new QMToggleButton(DoorController, "Unlock 4", () => { ToggleDoor(4); }, "Lock 4", () => { ToggleDoor(4); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton5 = new QMToggleButton(DoorController, "Unlock 5", () => { ToggleDoor(5); }, "Lock 5", () => { ToggleDoor(5); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton6 = new QMToggleButton(DoorController, "Unlock 6", () => { ToggleDoor(6); }, "Lock 6", () => { ToggleDoor(6); }, "Toggle Door Lock", Color.green, Color.red);
            LockButton7 = new QMToggleButton(DoorController, "Unlock 7", () => { ToggleDoor(7); }, "Lock 7", () => { ToggleDoor(7); }, "Toggle Door Lock", Color.green, Color.red);

            // Freeze Locks
            FreezeLockedToggle = new QMToggleButton(DoorController, "Freeze\nLocked", () => { IsFreezeLockEnabed = true; }, () => { IsFreezeLockEnabed = false; }, "Door Freezer", Color.green, Color.red);
            FreezeUnlockedToggle = new QMToggleButton(DoorController, "Freeze\nUnlocked", () => { IsFreezeUnlockEnabed = true; }, () => { IsFreezeUnlockEnabed = false; }, "Door Freezer", Color.green, Color.red);
            FreezeLockedToggle.SetToggleState(IsFreezeLockEnabed, false);
            FreezeUnlockedToggle.SetToggleState(IsFreezeUnlockEnabed, false);

            var MapFun = new QMNestedGridMenu(BClubExploitsPage, "World Fun", "Some Random Fun things");

            // Rainbow
            ToggleRainbowBtn = new QMToggleButton(MapFun, "Rainbow", () => { IsRainbowEnabled = true; }, () => { IsRainbowEnabled = false; }, "Rainbow", Color.green, Color.red);
            ToggleRainbowBtn.SetToggleState(IsRainbowEnabled, false);
            ToggleMoanSpamBtn = new QMToggleButton(MapFun, "Moan Spam", () => { IsMoanSpamEnabled = true; }, () => { IsMoanSpamEnabled = false; }, "Moan Spam", Color.green, Color.red);
            ToggleMoanSpamBtn.SetToggleState(IsMoanSpamEnabled, false);
            ToggleFallSpamBtn = new QMToggleButton(MapFun, "Fall Spam", () => { IsFallSpamEnabled = true; }, () => { IsFallSpamEnabled = false; }, "Fall Spam", Color.green, Color.red);
            ToggleFallSpamBtn.SetToggleState(IsFallSpamEnabled, false);

            // VIP
            SpoofAsWorldAuthorBtn = new QMToggleButton(BClubExploitsPage, 6, 1, "VIP Spoof", () => { PlayerSpooferUtils.SpoofAsWorldAuthor = true; }, "VIP Spoof", () => { PlayerSpooferUtils.SpoofAsWorldAuthor = false; }, "VIP Spoof", Color.green, Color.red);
            //_ = new QMSingleButton(BClubExploitsPage, 4, 2, "Enter VIP", () => { EnterVIPRoom(); }, "Enter VIP Room");

            var Exploits = new QMNestedGridMenu(BClubExploitsPage, "World Exploits", "World exploits");

            // Spamming
            if (Bools.IsDeveloper)
            {
                BlueChairToggle = new QMToggleButton(Exploits, "BlueChair\nEveryone", () => IsBlueChairEnabled = true, () => IsBlueChairEnabled = false, "BlueChair Everyone", Color.green, Color.red);
            }
            SpamDoorbellsToggle = new QMToggleButton(Exploits, "Spam Doorbells", () => IsDoorbellSpamEnabled = true, () => IsDoorbellSpamEnabled = false, "Toggle Doorbell Spam");
            SpamDoorbellsToggle.SetToggleState(IsDoorbellSpamEnabled, false);
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.JustBClub))
            {
                isCurrentWorld = true;
                //_ = MelonCoroutines.Start(ForceEnableRenderCamera());
                HasSubscribed = true;

                
                if (BClubExploitsPage != null)
                {
                    BClubExploitsPage.SetInteractable(true);
                    BClubExploitsPage.SetTextColor(Color.green);
                }

                // Activate both parent and root to Start the reader!
                if (Decoder_Debug != null)
                {
                    Decoder_Debug.SetActive(true);
                }
                if (RenderCamera != null)
                {
                    RenderCamera.SetActive(true);
                }

                WorldUtils.UdonScripts.Where(b => b.name == "Doorbell").ToList().ForEach(s => Bells.Add(s.FindUdonEvent("DingDong")));
                Log.Write($"Recognized {Name} World! This world has an exploit menu, and other extra goodies!");

                if (Penthouse != null)
                {
                    LockIndicator1_Listener = RegisterListener(LockIndicator_1, () => { LockButton1.SetToggleState(false); }, () => { LockButton1.SetToggleState(true); }, null);
                    LockIndicator2_Listener = RegisterListener(LockIndicator_2, () => { LockButton2.SetToggleState(false); }, () => { LockButton2.SetToggleState(true); }, null);
                    LockIndicator3_Listener = RegisterListener(LockIndicator_3, () => { LockButton3.SetToggleState(false); }, () => { LockButton3.SetToggleState(true); }, null);
                    LockIndicator4_Listener = RegisterListener(LockIndicator_4, () => { LockButton4.SetToggleState(false); }, () => { LockButton4.SetToggleState(true); }, null);
                    LockIndicator5_Listener = RegisterListener(LockIndicator_5, () => { LockButton5.SetToggleState(false); }, () => { LockButton5.SetToggleState(true); }, null);
                    LockIndicator6_Listener = RegisterListener(LockIndicator_6, () => { LockButton6.SetToggleState(false); }, () => { LockButton6.SetToggleState(true); }, null);
                    LockIndicator7_Listener = RegisterListener(LockIndicator_VIP, () => { LockButton7.SetToggleState(false); }, () => { LockButton7.SetToggleState(true); }, null);
                }
                else
                {
                    Log.Error("Failed to find Penthouse!");
                }

                MiscUtils.DelayFunction(2f, () =>
                {
                    Log.Debug("Rainbow Exploit!");

                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Red"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Red"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Cyan"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Cyan"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Pink"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Pink"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Purple"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Purple"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Green"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Green"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Blue"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Blue"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Yellow"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Yellow"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Orange"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Orange"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1White"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2White"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Black"));
                    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Black"));
                });

                if (Lobby != null)
                {
                    if (Cancer_Spawn != null)
                    {
                        Cancer_Spawn.DestroyMeLocal();
                    }

                    if (VIPControls != null)
                    {
                        VIPControls.SetActive(true);
                        ComponentUtils.GetOrAddComponent<Enabler>(VIPControls);
                    }

                    if (ElevatorFlairBtn != null)
                    {
                        ElevatorFlairBtn.SetActive(true);
                        ComponentUtils.GetOrAddComponent<Enabler>(ElevatorFlairBtn);
                    }
                }

                if (Udon != null)
                {
                    if (FlairBtnTablet != null)
                    {
                        FlairBtnTablet.SetActive(true);
                        ComponentUtils.GetOrAddComponent<Enabler>(FlairBtnTablet);
                    }
                }



                try
                {
                    Log.Debug("Searching for Private Rooms Exteriors...");
                    _ = CreateButtonGroup(1, new Vector3(-111.00629f, 15.75226f, -0.3361053f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    _ = CreateButtonGroup(2, new Vector3(-109.28977f, 15.81609f, -4.297329f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    _ = CreateButtonGroup(3, new Vector3(-103.00354f, 15.85877f, -0.3256264f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    _ = CreateButtonGroup(4, new Vector3(-101.28438f, 15.79742f, -4.307182f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    _ = CreateButtonGroup(5, new Vector3(-95.01436f, 15.78151f, -0.3279915f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    _ = CreateButtonGroup(6, new Vector3(-93.28891f, 15.78925f, -4.3116f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));

                    // VIP Room
                    if (VIPRoomEntrance == null)
                    {
                        Log.Error("VIP Bedroom was not found!");
                    }

                    CreateVIPUnlockButton(new Vector3(-80.4f, 16.0598f, -1.695f), new Vector3(0f, 0, 0f));
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }

                try
                {
                    if (Bedroom_VIP == null)
                    {
                        Log.Error("VIP Bedroom Root was not found!");
                    }
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }



                // Firewall Rules

                // This should be the one ejecting you when someone presses the "Eject Non-VIP" button 

                //if (EjectSelfIfNotVip != null)
                //{
                //    EjectSelfIfNotVip.Add_UdonFirewall_Rule(false, false, true);
                //}
                //if (PlayLeaveBedroom7 != null)
                //{
                //    PlayLeaveBedroom7.Add_UdonFirewall_Rule(false, false, true);
                //}

                if(VIP_Outside_Door_Entrance != null)
                {
                    var trigger = ComponentUtils.GetOrAddComponent<VRC_AstroInteract>(VIP_Outside_Door_Entrance);
                    if(trigger != null)
                    {
                        trigger.OnInteract = () =>
                        {
                            BlockVIPRoom_Kick = true;
                        };
                    }
                }


                if (VIPRoom_Internal_Door != null)
                {
                    var Trigger = ComponentUtils.GetOrAddComponent<VRC_AstroInteract>(VIPRoom_Internal_Door);
                    if (Trigger != null)
                    {
                        Trigger.OnInteract = () =>
                        {
                            BlockVIPRoom_Kick = false;
                            TeleportToBedroomOutside7.InvokeBehaviour();
                        };
                    }
                }

                Log.Write("Starting Update Loop");
                _ = MelonCoroutines.Start(RemovePrivacies());
                //_ = MelonCoroutines.Start(BypassElevator());
                _ = MelonCoroutines.Start(EnableElevatorFlairBtn());
                _ = MelonCoroutines.Start(EnableTabletFlairBtn());
                _ = MelonCoroutines.Start(UpdateLoop());
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
            if (CurrentDisplayName.IsNullOrEmptyOrWhiteSpace()) return;
            if (message.Contains("[Patreon]"))
            {
                if (message.Contains(CurrentDisplayName.ToLower()))
                {

                    if (message.Contains("is a patron"))
                    {
                        if (!isLocalPlayerPatron)
                        {
                            isLocalPlayerPatron = true;
                        }

                    }
                    if (message.Contains("is not a patron"))
                    {
                        //ForceEliteTier();
                        if (isLocalPlayerPatron)
                        {
                            isLocalPlayerPatron = false;
                        }

                    }

                    if (message.Contains("is an elite"))
                    {
                        if (!isLocalPlayerElite)
                        {
                            isLocalPlayerElite = true;
                        }
                    }
                    if (message.Contains("is not an elite"))
                    {
                       // ForceEliteTier();
                        if (isLocalPlayerElite)
                        {
                            isLocalPlayerElite = false;
                        }

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

        private static void DoorLockFreeze()
        {
            DoorLockFreeze_CancellationToken = MelonCoroutines.Start(DoorLockFreezeLoop());
        }

        private static void DoorUnlockFreeze()
        {
            DoorUnlockFreeze_CancellationToken = MelonCoroutines.Start(DoorUnlockFreezeLoop());
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

        private static IEnumerator DoorLockFreezeLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsFreezeLockEnabed = false;
                    yield break;
                }

                if (LockIndicator_1.active != true) ToggleDoor(1);
                if (LockIndicator_2.active != true) ToggleDoor(2);
                if (LockIndicator_3.active != true) ToggleDoor(3);
                if (LockIndicator_4.active != true) ToggleDoor(4);
                if (LockIndicator_5.active != true) ToggleDoor(5);
                if (LockIndicator_6.active != true) ToggleDoor(6);
                if (LockIndicator_VIP.active != true) ToggleDoor(7);

                yield return new WaitForSeconds(1f);
            }
        }

        private static IEnumerator DoorUnlockFreezeLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsFreezeUnlockEnabed = false;
                    yield break;
                }

                if (LockIndicator_1.active != false) ToggleDoor(1);
                if (LockIndicator_2.active != false) ToggleDoor(2);
                if (LockIndicator_3.active != false) ToggleDoor(3);
                if (LockIndicator_4.active != false) ToggleDoor(4);
                if (LockIndicator_5.active != false) ToggleDoor(5);
                if (LockIndicator_6.active != false) ToggleDoor(6);
                if (LockIndicator_VIP.active != false) ToggleDoor(7);

                yield return new WaitForSeconds(1f);
            }
        }

        private static void SpamDoorbells()
        {
            DoorbellSpam_CancellationToken = MelonCoroutines.Start(DoDoorbellSpam());
        }

        private static IEnumerator DoDoorbellSpam()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsDoorbellSpamEnabled = false;
                    yield break;
                }

                for (int i = 0; i < Bells.Count; i++)
                {
                    Bells[i]?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.1f);
                }

                yield return null;
            }
        }

        private static void BlueChairSpam()
        {
            var temp = WorldUtils.UdonScripts.Where(b => b.name.Contains("Chair") || b.name.Contains("Seat")).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                UdonBehaviour chair = temp[i];
                if (chair.name.Contains("Chair") || chair.name.Contains("Seat"))
                {
                    var action = chair.FindUdonEvent("Sit");
                    if (action != null && !Chairs.Contains(action))
                    {
                        Chairs.Add(action);
                    }
                }
            }
            Log.Write($"Blue Chairs: {Chairs.Count} found.");
            BlueChairSpam_CancellationToken = MelonCoroutines.Start(DoBlueChairSpam());
        }

        private static IEnumerator DoBlueChairSpam()
        {
            if (!Chairs.Any())
            {
                Log.Error("No bluechairs found!");
                yield break;
            }
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsBlueChairEnabled = false;
                    yield break;
                }

                for (int i = 0; i < Chairs.Count; i++)
                {
                    Chairs[i]?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.1f);
                }

                yield return null;
            }
        }

        private static void ToggleDoor(int doorID)
        {
            if (doorID <= 6)
            {
                UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLock{doorID}")?.InvokeBehaviour();
            }
            else if (doorID == 7)
            {
                UdonSearch.FindUdonEvent("Patreon", $"_ToggleLockVip")?.InvokeBehaviour();
            }
        }

        private static void OnRoomLeft()
        {
            if (isCurrentWorld)
            {
                isCurrentWorld = false;

                Log.Write("Done unloading B Club..");
            }
        }

        internal static GameObject GetIndicator(int id)
        {
            if (Penthouse == null) return null;
            if (id <= 6)
            {
                return Penthouse.transform.FindObject($"Private Rooms Exterior/Room Entrances/Private Room Entrance {id}/Screen/Canvas/Indicators/Locked").gameObject;
            }
            else if (id == 7)
            {
                return Penthouse.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance VIP/Screen (1)/Canvas/Indicators/Locked").gameObject;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private static IEnumerator BypassElevator()
        {
            Log.Debug("Elevator Bypass Started", System.Drawing.Color.Aquamarine);
            var elevator = Lobby.transform.FindObject("New Part/Udon/Warning");

            while (elevator == null) yield return new WaitForSeconds(0.001f);
            while (elevator.gameObject.active)
            {
                var udons = elevator.GetComponentsInChildren<UdonBehaviour>();
                for (int i = 0; i < udons.Count; i++)
                {
                    UdonBehaviour udon = udons[i];
                    if (udon != null)
                    {
                        udon.Interact();
                    }
                }

                if (!elevator.gameObject.active)
                {
                    Log.Debug("Unable to Bypass Elevator Warning.", System.Drawing.Color.Aquamarine);
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    Log.Debug("Bypassed Elevator Warning!", System.Drawing.Color.Aquamarine);
                    yield break;
                }
            }

            yield return null;
        }

        //private static void UdonBehaviour_Event_SendCustomEvent(UdonBehaviour item, string EventName)
        //{
        //    if (!isCurrentWorld) return;
        //    if (item == null) return;
        //    if (EventName.IsNullOrEmptyOrWhiteSpace()) return;
        //    //if (item.name.isMatch("RenderCamera") && EventName.isMatch("_ProcessPatronsFromReadRenderTexture"))
        //    //{
        //    //    ForceEliteTier();
        //    //}

        //    if (item.name.isMatch("Patreon") && EventName.isMatch("_ProcessPatronsFromReadRenderTexture"))
        //    {
        //        ForceEliteTier();
        //    }
        //}

        //internal static void ForceEliteTier()
        //{
        //    try
        //    {
        //        if (RenderCameraReader == null)
        //        {
        //            Log.Warn($"Unable to Force Elite Tier due to RenderCamera Reader being Null!");
        //            return;
        //        }
        //        if (ProcessPatronsFromReadRenderTexture == null)
        //        {
        //            Log.Warn($"Unable to Force Elite Tier due to ProcessPatronsFromReadRenderTexture Event being Null!");
        //            return;
        //        }

        //        // First let's edit the results of the rendercamera.

        //        // Split the results.
        //        bool HasBeenModified = false;
        //        var result = RenderCameraReader.currentOutputString.ReadLines().ToList();
        //        if (result != null && result.Count != 0)
        //        {
        //            if (!result.Contains(PlayerSpooferUtils.Original_DisplayName))
        //            {
        //                Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Patron & Elite List..");
        //                result.Insert(0, PlayerSpooferUtils.Original_DisplayName);
        //                HasBeenModified = true;
        //            }
        //            if (GameInstances.LocalPlayer != null)
        //            {
        //                if (!result.Contains(GameInstances.LocalPlayer.displayName))
        //                {
        //                    Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Patron & Elite List..");
        //                    result.Insert(1, GameInstances.LocalPlayer.displayName);
        //                    HasBeenModified = true;
        //                }
        //            }
        //        }

        //        if (HasBeenModified)
        //        {
        //            // if that's so, let's force a new reading.

        //            // First replace the output with the modified one
        //            RenderCameraReader.currentOutputString = string.Join("\n", result);

        //            //Secondly invoke again the Reading event.
        //            ProcessPatronsFromReadRenderTexture.InvokeBehaviour();
        //        }
        //    }
        //    catch { } // SHUT UP
        //}

        private static IEnumerator RemovePrivacies()
        {
            for (int i = 1; i <= 6; i++)
            {
                RemovePrivacyBlocksOnRooms(i);
                yield return null;
            }

            Log.Write("Room Privacies Removed..");
            yield break;
        }

        private static IEnumerator UpdateLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld) yield break;
                try
                {
                    RestoreVIPButton();
                }
                catch { }

                yield return new WaitForSeconds(5f);
            }
        }

        private static IEnumerator EnableElevatorFlairBtn()
        {
            while (ElevatorFlairBtn == null) yield return null;
            for (; ; )
            {
                if (!isCurrentWorld) yield break;
                if (!ElevatorFlairBtn.active)
                {
                    ElevatorFlairBtn.SetActive(true);
                }
                yield return new WaitForSeconds(5f);
            }

            yield break;
        }

        //private static IEnumerator ForceEnableRenderCamera()
        //{
        //    while (RenderCameraReader == null) yield return null;
        //    Log.Debug("RenderCamera Reader Installed!");
        //    yield break;
        //}

        private static IEnumerator EnableTabletFlairBtn()
        {
            while (FlairBtnTablet == null) yield return null;
            for (; ; )
            {
                if (!isCurrentWorld) yield break;
                if (!FlairBtnTablet.active)
                {
                    FlairBtnTablet.SetActive(true);
                }
                yield return new WaitForSeconds(5f);
            }

            yield break;
        }

        private static void RestoreVIPButton()
        {
            // Restore VIP button
            if (VIPButton != null)
            {
                VIPButton.gameObject.SetPosition(new Vector3(60.7236f, 63.1298f, -1.7349f));
            }
            else
            {
                Log.Error("VIP Button not found!");
            }
        }

        private static void CreateVIPUnlockButton(Vector3 position, Vector3 rotation)
        {
            if (VIP_Outside_Door_Entrance != null)
            {
                _ = new WorldButton(position, rotation, "Lock/Unlock\nVIP Room", () =>
                {
                    ToggleDoor(7);
                });
            }
        }

        private static void RemovePrivacyBlocksOnRooms(int roomid)
        {
            if (Bedrooms != null)
            {
                var cover = Bedrooms.transform.FindObject($"Bedroom {roomid}/Black Covers");
                var privacy = Bedrooms.transform.FindObject($"Bedroom {roomid}/Privacy");
                if (privacy != null)
                {
                    privacy.DestroyMeLocal();
                }
                if (cover != null)
                {
                    cover.DestroyMeLocal();
                }
            }
        }

        // TODO : FIX THE UDON EVENT OR MAKE A LOCAL TELEPORT AND ENABLE THE ROOM WITH ONE BUTTON.
        private GameObject CreateButtonGroup(int doorID, Vector3 position, Quaternion rotation, bool flip = false)
        {
            if (Bedrooms != null)
            {
                var room = Penthouse.transform.FindObject($"Private Rooms Exterior/Room Entrances/Private Room Entrance {doorID}");
                var room_BedroomPreview = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                var room_ToggleLooking = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                var room_ToggleLock = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                var room_ToggleIncognito = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                var room_DND = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");
                
                GameObject buttonGroup = GameObject.CreatePrimitive(PrimitiveType.Plane);
                buttonGroup.transform.SetParent(room.transform);
                buttonGroup.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Just so I can see where the parent is for now

                buttonGroup.transform.position = position;
                buttonGroup.transform.rotation = rotation;

                //buttonGroup.transform.position += new Vector3(0, 0.02f, 0);
                buttonGroup.RemoveColliders();
                buttonGroup.AddToWorldUtilsMenu();
                buttonGroup.RenameObject($"ButtonGroup {doorID}");

                buttonGroup.GetComponent<Renderer>().enabled = false;

                // add buttons
                if (room != null)
                {
                    if (room_BedroomPreview != null)
                    {
                        var clone = room_BedroomPreview.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-2.335898f, 0, -3.828288f);
                            clone.RenameObject($"Intercom {doorID}");
                            clone.AddCollider();

                            var udonEvent = UdonSearch.FindUdonEvent("PhotozoneMaster", $"EnableIntercomIn{doorID}");
                            void action() { udonEvent.InvokeBehaviour(); }
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent.Count() != 0)
                            {
                                for (int i = 0; i < behaviourevent.Count; i++)
                                {
                                    UnityEngine.Object.DestroyImmediate(behaviourevent[i]);
                                }
                            }
                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable";
                                var TriggerComponent = clone.transform.Find(path);
                                string ObjectName = $"Toggle Intercom {doorID} - Trigger";
                                string InteractionText = $"Toggle Intercom {doorID} - AstroClient";
                                var RenameTrigger = clone.transform.Find(path);
                                if (RenameTrigger != null)
                                {
                                    RenameTrigger.gameObject.RenameObject(ObjectName);
                                }

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroInteract>();
                                if (AstroTrigger != null)
                                {
                                    AstroTrigger.interactText = InteractionText;
                                    AstroTrigger.OnInteract = action;
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                            }
                        }
                    }
                    else
                    {
                        Log.Warn("Failed to find Bedroom Preview Button!");
                    }

                    if (room_ToggleLock != null)
                    {
                        var clone = room_ToggleLock.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-2.335898f, 0, -1.828288f);
                            clone.RenameObject($"Lock {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLock{doorID}");
                            void action() { udonEvent.InvokeBehaviour(); }
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent.Count() != 0)
                            {
                                for (int i = 0; i < behaviourevent.Count; i++)
                                {
                                    UnityEngine.Object.DestroyImmediate(behaviourevent[i]);
                                }
                            }
                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable - Toggle Lock";
                                string ObjectName = $"Toggle Lock {doorID} - Trigger";
                                string InteractionText = $"Toggle Lock {doorID} - AstroClient";
                                var RenameTrigger = clone.transform.Find(path);
                                if (RenameTrigger != null)
                                {
                                    RenameTrigger.gameObject.RenameObject(ObjectName);
                                }

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroInteract>();
                                if (AstroTrigger != null)
                                {
                                    AstroTrigger.interactText = InteractionText;
                                    AstroTrigger.OnInteract = action;
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                            }
                        }
                    }
                    else
                    {
                        Log.Warn("Failed to find Bedroom Toggle Lock Button!");
                    }

                    if (room_ToggleLooking != null)
                    {
                        var clone = room_ToggleLooking.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-4.335898f, 0, -1.828288f);
                            clone.RenameObject($"Looking {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLooking{doorID}");
                            void action() { udonEvent.InvokeBehaviour(); }
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent.Count() != 0)
                            {
                                for (int i = 0; i < behaviourevent.Count; i++)
                                {
                                    UnityEngine.Object.DestroyImmediate(behaviourevent[i]);
                                }
                            }
                            clone.AddToWorldUtilsMenu();

                            try
                            {
                                string path = "Button Interactable - Looking";
                                string ObjectName = $"Toggle Looking For Company {doorID} - Trigger";
                                string InteractionText = $"Toggle Looking For Company {doorID} - AstroClient";
                                var RenameTrigger = clone.transform.Find(path);
                                if (RenameTrigger != null)
                                {
                                    RenameTrigger.gameObject.RenameObject(ObjectName);
                                }

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroInteract>();
                                if (AstroTrigger != null)
                                {
                                    AstroTrigger.interactText = InteractionText;
                                    AstroTrigger.OnInteract = action;
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                            }
                        }
                    }
                    else
                    {
                        Log.Warn("Failed to find Bedroom Toggle Looking Button!");
                    }

                    if (room_ToggleIncognito != null)
                    {
                        var clone = room_ToggleIncognito.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-6.335898f, 0, -1.828288f);
                            clone.RenameObject($"Incognito {doorID}");
                            clone.AddCollider();

                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleAnon{doorID}");
                            void action() { udonEvent.InvokeBehaviour(); }
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent.Count() != 0)
                            {
                                for (int i = 0; i < behaviourevent.Count; i++)
                                {
                                    UnityEngine.Object.DestroyImmediate(behaviourevent[i]);
                                }
                            }

                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable - Anon";
                                string ObjectName = $"Toggle Incognito {doorID} - Trigger";
                                string InteractionText = $"Toggle Incognito {doorID} - AstroClient";
                                var RenameTrigger = clone.transform.Find(path);
                                if (RenameTrigger != null)
                                {
                                    RenameTrigger.gameObject.RenameObject(ObjectName);
                                }

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroInteract>();
                                if (AstroTrigger != null)
                                {
                                    AstroTrigger.interactText = InteractionText;
                                    AstroTrigger.OnInteract = action;
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                            }
                        }
                        else
                        {
                            Log.Warn("Failed to find Bedroom Incognito Button!");
                        }
                    }
                    if (room_DND != null)
                    {
                        var clone = room_DND.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-0.1719699f, 0, -2.196038f);
                            clone.transform.rotation = new Quaternion(0.5198629f, 0.5198629f, 0.5198629f, 0.5198629f);
                            clone.RenameObject($"Do Not Disturb {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleDoorbell{doorID}");
                            void action() { udonEvent.InvokeBehaviour(); }
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent.Count() != 0)
                            {
                                for (int i = 0; i < behaviourevent.Count; i++)
                                {
                                    UnityEngine.Object.DestroyImmediate(behaviourevent[i]);
                                }
                            }
                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable DND";
                                string ObjectName = $"Toggle Do Not Disturb {doorID} - Trigger";
                                string InteractionText = $"Toggle Do Not Disturb {doorID} - AstroClient";
                                var RenameTrigger = clone.transform.Find(path);
                                if (RenameTrigger != null)
                                {
                                    RenameTrigger.gameObject.RenameObject(ObjectName);
                                }

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroInteract>();
                                if (AstroTrigger != null)
                                {
                                    AstroTrigger.interactText = InteractionText;
                                    AstroTrigger.OnInteract = action;
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                            }
                        }
                    }
                    else
                    {
                        Log.Warn("Failed to find Bedroom Toggle Do Not Disturb Button!");
                    }
                }

                if (flip)
                {
                    buttonGroup.transform.eulerAngles += new Vector3(0, 180, 0);
                }

                return buttonGroup;
            }
            else
            {
                if (Penthouse == null)
                {
                    Log.Error("Failed to Find Penthouse!");
                }
                if (Bedrooms == null)
                {
                    Log.Error("Failed to Find Bedrooms!");
                }
            }
            return null;
        }
    }
}