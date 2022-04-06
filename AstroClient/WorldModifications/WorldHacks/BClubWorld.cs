﻿using AstroClient.AstroMonos.Components.Cheats.PatronCrackers;

namespace AstroClient.WorldModifications.WorldHacks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.AstroUdons;
    using AstroMonos.Components.Spoofer;
    using AstroMonos.Components.Tools;
    using AstroMonos.Components.Tools.Listeners;
    using CheetosUI;
    using Constants;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.UdonEditor;
    using Tools.UdonSearcher;
    using UnityEngine;
    using VRC.Udon;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    #endregion Imports

    // TODO : REWRITE!
    internal class BClubWorld : AstroEvents
    {
        internal static GameObject BedroomVIProot { get; set; }
        internal static GameObject VIPRoom { get; set; }
        internal static GameObject VIPInsideDoor { get; set; }
        internal static GameObject VIPButton { get; set; }
        internal static GameObject VIPControls { get; set; }
        internal static GameObject FlairBtnTablet { get; set; }
        internal static GameObject ElevatorFlairBtn { get; set; }
        private static GameObject PenthouseRoot { get; set; }
        internal static GameObject GlobalUdon { get; set; }
        internal static GameObject LobbyRoot { get; set; }

        internal static QMNestedGridMenu BClubExploitsPage { get; set; }

        private static QMToggleButton FreezeLockedToggle { get; set; }
        private static QMToggleButton FreezeUnlockedToggle { get; set; }
        private static QMToggleButton BlueChairToggle { get; set; }

        private static UdonBehaviour_Cached MoanSpamBehaviour { get; set; }

        private static bool _isFreezeLockEnabed { get; set; }
        private static bool _isFreezeUnlockEnabed { get; set; }
        private static bool _isRainbowEnabled { get; set; }
        private static bool _isMoanSpamEnabled { get; set; }

        private static bool isCurrentWorld { get; set; }

        private static object Rainbow_CancellationToken { get; set; }
        private static object MoanSpam_CancellationToken { get; set; }
        private static object DoorLockFreeze_CancellationToken { get; set; }
        private static object DoorUnlockFreeze_CancellationToken { get; set; }

        #region BlueChairSpam

        internal static bool IsBlueChairEnabled
        {
            get => _isBlueChairEnabed;
            set
            {
                if (value)
                {
                    Log.Write("BlueChair Enabled!");
                    BlueChairSpam();
                }
                else
                {
                    Log.Write("BlueChair Disabled!");
                }
                _isBlueChairEnabed = value;
            }
        }

        private static bool _isBlueChairEnabed;

        #endregion BlueChairSpam

        #region DoorbellSpam

        internal static bool IsDoorbellSpamEnabled
        {
            get => _isDoorBellSpamEnabled;
            set
            {
                if (value)
                {
                    if (DoorUnlockFreeze_CancellationToken == null)
                    {
                        Log.Write("Doorbell Spam Enabled!");
                        SpamDoorbells();
                    }
                }
                else
                {
                    Log.Write("Doorbell Spam Disabled!");
                    DoorUnlockFreeze_CancellationToken = null;
                }
                _isDoorBellSpamEnabled = value;
            }
        }

        private static QMToggleButton SpamDoorbellsToggle;
        private static bool _isDoorBellSpamEnabled;
        private static object DoorbellSpam_CancellationToken;

        #endregion DoorbellSpam

        internal static bool IsFreezeLockEnabed
        {
            get => _isFreezeLockEnabed;
            set
            {
                if (value)
                {
                    Log.Write("Door Locks Frozen: Locked");
                    if (IsFreezeUnlockEnabed) IsFreezeUnlockEnabed = false;
                    DoorLockFreeze();
                }
                else
                {
                    Log.Write("Door Locks Unfrozen");
                    DoorLockFreeze_CancellationToken = null;
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
                    Log.Write("Door Locks Unfrozen");
                    DoorUnlockFreeze_CancellationToken = null;
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
                    if (Rainbow_CancellationToken == null)
                    {
                        Log.Write("Rainbow Enabled!");
                        Rainbow();
                    }
                }
                else
                {
                    Log.Write("Rainbow Disabled.");
                    Rainbow_CancellationToken = null;
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
                    Log.Write("Moan Spam Disabled.");
                    MoanSpam_CancellationToken = null;
                }
                _isMoanSpamEnabled = value;
            }
        }

        #endregion MoanSpam

        private static GameObject LockIndicator1;
        private static GameObject LockIndicator2;
        private static GameObject LockIndicator3;
        private static GameObject LockIndicator4;
        private static GameObject LockIndicator5;
        private static GameObject LockIndicator6;
        private static GameObject LockIndicator7;

        private static GameObjectListener LockIndicator1_Listener;
        private static GameObjectListener LockIndicator2_Listener;
        private static GameObjectListener LockIndicator3_Listener;
        private static GameObjectListener LockIndicator4_Listener;
        private static GameObjectListener LockIndicator5_Listener;
        private static GameObjectListener LockIndicator6_Listener;
        private static GameObjectListener LockIndicator7_Listener;

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

        internal static GameObjectListener RegisterListener(GameObject Object, Action OnEnabled, Action OnDisabled, Action OnDestroy)
        {
            if (Object != null)
            {
                var listener = Object.GetOrAddComponent<GameObjectListener>();
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
            ToggleRainbowBtn = new QMToggleButton(MapFun, 5, 1, "Rainbow", () => { IsRainbowEnabled = true; }, () => { IsRainbowEnabled = false; }, "Rainbow", Color.green, Color.red);
            ToggleRainbowBtn.SetToggleState(IsRainbowEnabled, false);
            ToggleMoanSpamBtn = new QMToggleButton(MapFun, 6, 2, "Moan Spam", () => { IsMoanSpamEnabled = true; }, () => { IsMoanSpamEnabled = false; }, "Moan Spam", Color.green, Color.red);

            // VIP
            SpoofAsWorldAuthorBtn = new QMToggleButton(BClubExploitsPage, 6, 1, "VIP Spoof", () => { PlayerSpooferUtils.SpoofAsWorldAuthor = true; }, "VIP Spoof", () => { PlayerSpooferUtils.SpoofAsWorldAuthor = false; }, "VIP Spoof", Color.green, Color.red);
            //_ = new QMSingleButton(BClubExploitsPage, 4, 2, "Enter VIP", () => { EnterVIPRoom(); }, "Enter VIP Room");

            var Exploits = new QMNestedGridMenu(BClubExploitsPage, "World Exploits", "World exploits");

            // Spamming
            if (Bools.IsDeveloper)
            {
                BlueChairToggle = new QMToggleButton(Exploits, 5, -1, "BlueChair\nEveryone", () => IsBlueChairEnabled = true, () => IsBlueChairEnabled = false, "BlueChair Everyone", Color.green, Color.red);
            }
            SpamDoorbellsToggle = new QMToggleButton(Exploits, 5, 0, "Spam Doorbells", () => IsDoorbellSpamEnabled = true, () => IsDoorbellSpamEnabled = false, "Toggle Doorbell Spam");
            SpamDoorbellsToggle.SetToggleState(IsDoorbellSpamEnabled, false);
        }

        private static void Rainbow()
        {
            Rainbow_CancellationToken = MelonCoroutines.Start(RainbowLoop());
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

                foreach (var udon in ColorActions)
                {
                    udon?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.05f);
                }

                if (IsRainbowEnabled)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    yield break;
                }
            }
        }

        private static void MoanSpam()
        {
            MoanSpam_CancellationToken = MelonCoroutines.Start(MoanSpamLoop());
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

                if (IsMoanSpamEnabled)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    yield break;
                }
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

                if (LockIndicator1.active != true) ToggleDoor(1);
                if (LockIndicator2.active != true) ToggleDoor(2);
                if (LockIndicator3.active != true) ToggleDoor(3);
                if (LockIndicator4.active != true) ToggleDoor(4);
                if (LockIndicator5.active != true) ToggleDoor(5);
                if (LockIndicator6.active != true) ToggleDoor(6);
                if (LockIndicator7.active != true) ToggleDoor(7);

                if (IsFreezeLockEnabed)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    yield break;
                }
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

                if (LockIndicator1.active != false) ToggleDoor(1);
                if (LockIndicator2.active != false) ToggleDoor(2);
                if (LockIndicator3.active != false) ToggleDoor(3);
                if (LockIndicator4.active != false) ToggleDoor(4);
                if (LockIndicator5.active != false) ToggleDoor(5);
                if (LockIndicator6.active != false) ToggleDoor(6);
                if (LockIndicator7.active != false) ToggleDoor(7);

                if (IsFreezeUnlockEnabed)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    yield break;
                }
            }
        }

        private static List<UdonBehaviour_Cached> _bells = new List<UdonBehaviour_Cached>();

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

                foreach (var bell in _bells)
                {
                    bell?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.1f);
                }

                if (IsDoorbellSpamEnabled)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    yield break;
                }
            }
        }

        private static List<UdonBehaviour_Cached> _chairs = new List<UdonBehaviour_Cached>();

        private static void BlueChairSpam()
        {
            var temp = UdonParser.WorldBehaviours.Where(b => b.name.Contains("Chair") || b.name.Contains("Seat")).ToList();
            foreach (var chair in temp)
            {
                if (chair.name.Contains("Chair") || chair.name.Contains("Seat"))
                {
                    var action = chair.FindUdonEvent("Sit");
                    if (action != null && !_chairs.Contains(action))
                    {
                        _chairs.Add(action);
                    }
                }
            }
            Log.Write($"Blue Chairs: {_chairs.Count} found.");
            _ = MelonCoroutines.Start(DoBlueChairSpam());
        }

        private static IEnumerator DoBlueChairSpam()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsBlueChairEnabled = false;
                    yield break;
                }

                foreach (var chair in _chairs)
                {
                    chair?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.001f);
                }

                if (IsBlueChairEnabled)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    yield break;
                }
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

        internal override void OnRoomLeft()
        {
            if (isCurrentWorld)
            {
                isCurrentWorld = false;

                if (IsBlueChairEnabled) IsBlueChairEnabled = false;
                if (IsDoorbellSpamEnabled) IsDoorbellSpamEnabled = false;
                if (IsFreezeLockEnabed) IsFreezeLockEnabed = false;
                if (IsFreezeUnlockEnabed) IsFreezeUnlockEnabed = false;
                if (IsMoanSpamEnabled) IsMoanSpamEnabled = false;
                if (IsRainbowEnabled) IsRainbowEnabled = false;

                Rainbow_CancellationToken = null;
                MoanSpam_CancellationToken = null;
                DoorLockFreeze_CancellationToken = null;
                DoorUnlockFreeze_CancellationToken = null;

                _bells.Clear();
                _chairs.Clear();
                ColorActions.Clear();
                BedroomVIProot = null;
                Log.Write("Done unloading B Club..");
            }
        }

        private static List<UdonBehaviour_Cached> ColorActions = new List<UdonBehaviour_Cached>();
        private static UdonBehaviour_Cached VoiceAction;

        internal static GameObject GetIndicator(int id)
        {
            if (id <= 6)
            {
                return PenthouseRoot.transform.FindObject($"Private Rooms Exterior/Room Entrances/Private Room Entrance {id}/Screen/Canvas/Indicators/Locked").gameObject;
            }
            else if (id == 7)
            {
                return PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance VIP/Screen (1)/Canvas/Indicators/Locked").gameObject;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private static IEnumerator BypassElevator()
        {
            Log.Debug("Elevator Bypass Started", System.Drawing.Color.Aquamarine);
            var elevator = LobbyRoot.transform.FindObject("New Part/Udon/Warning");

            while (elevator == null) yield return new WaitForSeconds(0.001f);
            while (elevator.gameObject.active)
            {
                var udons = elevator.GetComponentsInChildren<UdonBehaviour>();
                foreach (var udon in udons)
                {
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

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.JustBClub)
            {
                if (BClubExploitsPage != null)
                {
                    BClubExploitsPage.SetInteractable(true);
                    BClubExploitsPage.SetTextColor(Color.green);
                }
                isCurrentWorld = true;
                UdonParser.WorldBehaviours.Where(b => b.name == "Doorbell").ToList().ForEach(s => _bells.Add(s.FindUdonEvent("DingDong")));
                Log.Write($"Recognized {Name} World! This world has an exploit menu, and other extra goodies!");
                var pedestralreader = UdonSearch.FindUdonEvent("RenderCamera", "_onPostRender");
                if(pedestralreader != null)
                {
                    pedestralreader.gameObject.GetOrAddComponent<RenderCameraHijacker>();
                }

                PenthouseRoot = GameObjectFinder.FindRootSceneObject("Penthouse");
                if (PenthouseRoot != null)
                {
                    LockIndicator1 = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 1/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator2 = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 2/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator3 = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 3/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator4 = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 4/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator5 = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 5/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator6 = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 6/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator7 = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance VIP/Screen (1)/Canvas/Indicators/Locked").gameObject;

                    LockIndicator1_Listener = RegisterListener(LockIndicator1, () => { LockButton1.SetToggleState(false); }, () => { LockButton1.SetToggleState(true); }, null);
                    LockIndicator2_Listener = RegisterListener(LockIndicator2, () => { LockButton2.SetToggleState(false); }, () => { LockButton2.SetToggleState(true); }, null);
                    LockIndicator3_Listener = RegisterListener(LockIndicator3, () => { LockButton3.SetToggleState(false); }, () => { LockButton3.SetToggleState(true); }, null);
                    LockIndicator4_Listener = RegisterListener(LockIndicator4, () => { LockButton4.SetToggleState(false); }, () => { LockButton4.SetToggleState(true); }, null);
                    LockIndicator5_Listener = RegisterListener(LockIndicator5, () => { LockButton5.SetToggleState(false); }, () => { LockButton5.SetToggleState(true); }, null);
                    LockIndicator6_Listener = RegisterListener(LockIndicator6, () => { LockButton6.SetToggleState(false); }, () => { LockButton6.SetToggleState(true); }, null);
                    LockIndicator7_Listener = RegisterListener(LockIndicator7, () => { LockButton7.SetToggleState(false); }, () => { LockButton7.SetToggleState(true); }, null);
                }
                else
                {
                    ModConsole.Error("Failed to find Penthouse!");
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

                LobbyRoot = GameObjectFinder.FindRootSceneObject("Lobby");
                if (LobbyRoot != null)
                {
                    var fuckthiscancer = LobbyRoot.transform.FindObject("New Part").FindObject("Cancer Spawn");
                    if (fuckthiscancer != null)
                    {
                        fuckthiscancer.DestroyMeLocal();
                    }

                    VIPControls = LobbyRoot.transform.FindObject("Udon/MyI Control Panel").gameObject;
                    if (VIPControls != null)
                    {
                        VIPControls.SetActive(true);
                        VIPControls.GetOrAddComponent<Enabler>();
                    }

                    ElevatorFlairBtn = LobbyRoot.transform.FindObject("New Part/Udon/Spawn Settings/Buttons/Own Flair - BlueButtonWide").gameObject;
                    if (ElevatorFlairBtn != null)
                    {
                        ElevatorFlairBtn.SetActive(true);
                        ElevatorFlairBtn.GetOrAddComponent<Enabler>();
                    }
                }

                GlobalUdon = GameObjectFinder.FindRootSceneObject("Udon");
                if (GlobalUdon != null)
                {
                    FlairBtnTablet = GlobalUdon.transform.FindObject("Main Controls/New Contents/Pages/World/Buttons/Own Flair - BlueButtonWide").gameObject;
                    if (FlairBtnTablet != null)
                    {
                        FlairBtnTablet.SetActive(true);
                        FlairBtnTablet.GetOrAddComponent<Enabler>();
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
                    VIPRoom = PenthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance VIP").gameObject;
                    if (VIPRoom == null)
                    {
                        ModConsole.Error("VIP Bedroom was not found!");
                    }

                    CreateVIPUnlockButton(new Vector3(-80.4f, 16.0598f, -1.695f), new Vector3(0f, 0, 0f));
                }
                catch (Exception e)
                {
                    ModConsole.DebugErrorExc(e);
                }

                try
                {
                    BedroomVIProot = GameObjectFinder.Find("Bedroom VIP");
                    if (BedroomVIProot == null)
                    {
                        ModConsole.Error("VIP Bedroom Root was not found!");
                    }

                }
                catch (Exception e)
                {
                    ModConsole.DebugErrorExc(e);
                }

                MoanSpamBehaviour = UdonSearch.FindUdonEvent("NPC Audio Udon", "PlayGruntHurt");
                Log.Write("Starting Update Loop");
                _ = MelonCoroutines.Start(RemovePrivacies());
                _ = MelonCoroutines.Start(BypassElevator());
                _ = MelonCoroutines.Start(EnableElevatorFlairBtn());
                _ = MelonCoroutines.Start(EnableTabletFlairBtn());
                _ = MelonCoroutines.Start(UpdateLoop());
            }
            else
            {
                isCurrentWorld = false;
                if (BClubExploitsPage != null)
                {
                    BClubExploitsPage.SetInteractable(false);
                    BClubExploitsPage.SetTextColor(Color.red);
                }
            }
        }

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
            if (VIPButton == null) VIPButton = BedroomVIProot.transform.FindObject("BedroomUdon/Door Tablet/BlueButtonWide - Toggle VIP only").gameObject;
            if (VIPButton != null)
            {
                VIPButton.gameObject.SetPosition(new Vector3(60.7236f, 63.1298f, -1.7349f));
            }
            else
            {
                ModConsole.Error("VIP Button not found!");
            }
        }

        private static void CreateVIPUnlockButton(Vector3 position, Vector3 rotation)
        {
            VIPInsideDoor = VIPRoom.transform.FindObject("Door001 (1)").gameObject;

            if (VIPInsideDoor != null)
            {
                _ = new WorldButton(position, rotation, Environment.NewLine + "Lock/Unlock\nVIP Room", () =>
                {
                    ToggleDoor(7);
                });
            }
        }

        private static void RemovePrivacyBlocksOnRooms(int roomid)
        {
            GameObject Bedrooms = GameObjectFinder.FindRootSceneObject("Bedrooms");
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
            GameObject Penthouse = GameObjectFinder.FindRootSceneObject("Penthouse");
            GameObject Bedrooms = GameObjectFinder.FindRootSceneObject("Bedrooms");

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
                                foreach (var e in behaviourevent)
                                {
                                    UnityEngine.Object.DestroyImmediate(e);
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
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find Bedroom Preview Button!");
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
                                foreach (var e in behaviourevent)
                                {
                                    UnityEngine.Object.DestroyImmediate(e);
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
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find Bedroom Toggle Lock Button!");
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
                                foreach (var e in behaviourevent)
                                {
                                    UnityEngine.Object.DestroyImmediate(e);
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
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find Bedroom Toggle Looking Button!");
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
                                foreach (var e in behaviourevent)
                                {
                                    UnityEngine.Object.DestroyImmediate(e);
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
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                        else
                        {
                            ModConsole.DebugWarning("Failed to find Bedroom Incognito Button!");
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
                                foreach (var e in behaviourevent)
                                {
                                    UnityEngine.Object.DestroyImmediate(e);
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
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find  Bedroom Toggle Do Not Disturb Button!");
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
                    ModConsole.Error("Failed to Find Penthouse!");
                }
                if (Bedrooms == null)
                {
                    ModConsole.Error("Failed to Find Bedrooms!");
                }
            }
            return null;
        }

    }
}