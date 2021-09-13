namespace AstroClient
{
    #region Imports

    using AstroClient.Components;
    using AstroClient.Udon;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using MelonLoader;
    using RubyButtonAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.Udon;
    using static AstroClient.Variables.CustomLists;

    #endregion Imports

    public class BClubWorld : GameEvents
    {
        public static GameObject VIPRoom;
        public static GameObject VIPInsideDoor;
        public static GameObject VIPButton;

        public static QMNestedButton BClubExploitsPage;

        public static int SpamCount = 0;

        private static QMToggleButton SpamDoorbellsToggle;
        private static QMToggleButton FreezeLockedToggle;
        private static QMToggleButton FreezeUnlockedToggle;
        private static QMToggleButton BlueChairToggle;

        private static bool _isDoorBellSpamEnabled;
        private static bool _isFreezeLockEnabed;
        private static bool _isFreezeUnlockEnabed;
        private static bool _isBlueChairEnabed;

        private static bool isCurrentWorld;
        private static string realName;

        private static UdonBehaviour_Cached[] lockActions;

        public static bool IsBlueChairEnabled
        {
            get => _isBlueChairEnabed;
            set
            {
                if (value)
                {
                    ModConsole.Log("BlueChair Enabled!");
                    BlueChairSpam();
                }
                else
                {
                    ModConsole.Log("BlueChair Disabled!");
                }

                _isBlueChairEnabed = value;
            }
        }

        public static bool IsDoorbellSpamEnabled
        {
            get => _isDoorBellSpamEnabled;
            set
            {
                if (value)
                {
                    ModConsole.Log("Doorbell Spam Enabled!");
                    SpamDoorbells();
                }
                else
                {
                    ModConsole.Log("Doorbell Spam Disabled!");
                }

                _isDoorBellSpamEnabled = value;
            }
        }

        public static bool IsFreezeLockEnabed
        {
            get => _isFreezeLockEnabed;
            set
            {
                if (value)
                {
                    ModConsole.Log("Door Locks Frozen: Locked");
                    if (IsFreezeUnlockEnabed) IsFreezeUnlockEnabed = false;
                    DoorLockFreeze();
                }
                else
                {
                    ModConsole.Log("Door Locks Unfrozen");
                }

                _isFreezeLockEnabed = value;
            }
        }

        public static bool IsFreezeUnlockEnabed
        {
            get => _isFreezeUnlockEnabed;
            set
            {
                if (value)
                {
                    if (_isFreezeUnlockEnabed)
                    {
                        return;
                    }
                    else
                    {
                        ModConsole.Log("Door Locks Frozen: Unlocked");
                        if (IsFreezeLockEnabed) IsFreezeLockEnabed = false;
                        DoorUnlockFreeze();
                    }
                }
                else
                {
                    ModConsole.Log("Door Locks Unfrozen");
                }

                _isFreezeUnlockEnabed = value;
            }
        }

        private static QMToggleButton LockButton1;
        private static GameObject LockIndicator1;
        private static QMToggleButton LockButton2;
        private static GameObject LockIndicator2;
        private static QMToggleButton LockButton3;
        private static GameObject LockIndicator3;
        private static QMToggleButton LockButton4;
        private static GameObject LockIndicator4;
        private static QMToggleButton LockButton5;
        private static GameObject LockIndicator5;
        private static QMToggleButton LockButton6;
        private static GameObject LockIndicator6;

        public static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            BClubExploitsPage = new QMNestedButton(main, x, y, "BClub Exploits", "BClub Exploits", null, null, null, null, btnHalf);

            // Locks
            LockButton1 = new QMToggleButton(BClubExploitsPage, 1, 0, "Unlock 1", () => { ToggleDoor(1); }, "Lock 1", () => { ToggleDoor(1); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            LockButton2 = new QMToggleButton(BClubExploitsPage, 2, 0, "Unlock 2", () => { ToggleDoor(2); }, "Lock 2", () => { ToggleDoor(2); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            LockButton3 = new QMToggleButton(BClubExploitsPage, 3, 0, "Unlock 3", () => { ToggleDoor(3); }, "Lock 3", () => { ToggleDoor(3); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            LockButton4 = new QMToggleButton(BClubExploitsPage, 1, 1, "Unlock 4", () => { ToggleDoor(4); }, "Lock 4", () => { ToggleDoor(4); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            LockButton5 = new QMToggleButton(BClubExploitsPage, 2, 1, "Unlock 5", () => { ToggleDoor(5); }, "Lock 5", () => { ToggleDoor(5); }, "Toggle Door Lock", null, Color.green, Color.red, false);
            LockButton6 = new QMToggleButton(BClubExploitsPage, 3, 1, "Unlock 6", () => { ToggleDoor(6); }, "Lock 6", () => { ToggleDoor(6); }, "Toggle Door Lock", null, Color.green, Color.red, false);


            // VIP
            _ = new QMToggleButton(BClubExploitsPage, 5, 1, "VIP Spoof", () => { Bools.IsBClubVIPSpoofing = true; PlayerUtils.GetAPIUser()._displayName_k__BackingField = "Blue-kun"; }, "VIP Spoof", () => { Bools.IsBClubVIPSpoofing = false; PlayerUtils.GetAPIUser()._displayName_k__BackingField = realName; }, "VIP Spoof", null, Color.green, Color.red, false);
            //_ = new QMSingleButton(BClubExploitsPage, 4, 2, "Enter VIP", () => { EnterVIPRoom(); }, "Enter VIP Room");

            // Freeze Locks
            FreezeLockedToggle = new QMToggleButton(BClubExploitsPage, -1, 1, "Freeze\nLocked", () => { IsFreezeLockEnabed = true; }, "", () => { IsFreezeLockEnabed = false; }, "Door Freezer", null, Color.green, Color.red, false);
            FreezeUnlockedToggle = new QMToggleButton(BClubExploitsPage, -1, 2, "Freeze\nUnlocked", () => { IsFreezeUnlockEnabed = true; }, "", () => { IsFreezeUnlockEnabed = false; }, "Door Freezer", null, Color.green, Color.red, false);
            FreezeLockedToggle.SetToggleState(IsFreezeLockEnabed, false);
            FreezeUnlockedToggle.SetToggleState(IsFreezeUnlockEnabed, false);

            // Spamming
            if (Bools.IsDeveloper)
            {
                BlueChairToggle = new QMToggleButton(BClubExploitsPage, 5, -1, "BlueChair\nEveryone", () => IsBlueChairEnabled = true, "", () => IsBlueChairEnabled = false, "BlueChair Everyone", null, Color.green, Color.red, false);
            }
            SpamDoorbellsToggle = new QMToggleButton(BClubExploitsPage, 5, 0, "Spam Doorbells", () => IsDoorbellSpamEnabled = true, "", () => IsDoorbellSpamEnabled = false, "Toggle Doorbell Spam");
            SpamDoorbellsToggle.SetToggleState(IsDoorbellSpamEnabled, false);
        }

        private static void RefreshButtons()
        {
            VIPButton.gameObject.transform.position = new Vector3(60.7236f, 63.1298f, -1.7349f);

            if (!LockIndicator1.active)
            {
                LockButton1.SetToggleState(true);
            }
            else
            {
                LockButton1.SetToggleState(false);
            }

            if (!LockIndicator2.active)
            {
                LockButton2.SetToggleState(true);
            }
            else
            {
                LockButton2.SetToggleState(false);
            }

            if (!LockIndicator3.active)
            {
                LockButton3.SetToggleState(true);
            }
            else
            {
                LockButton3.SetToggleState(false);
            }

            if (!LockIndicator4.active)
            {
                LockButton4.SetToggleState(true);
            }
            else
            {
                LockButton4.SetToggleState(false);
            }

            if (!LockIndicator5.active)
            {
                LockButton5.SetToggleState(true);
            }
            else
            {
                LockButton5.SetToggleState(false);
            }

            if (!LockIndicator6.active)
            {
                LockButton6.SetToggleState(true);
            }
            else
            {
                LockButton6.SetToggleState(false);
            }
        }

        private static void DoorLockFreeze()
        {
            _ = MelonCoroutines.Start(DoorLockFreezeLoop());
        }

        private static void DoorUnlockFreeze()
        {
            _ = MelonCoroutines.Start(DoorUnlockFreezeLoop());
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
            _ = MelonCoroutines.Start(DoDoorbellSpam());
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
                    bell?.ExecuteUdonEvent();
                    yield return new WaitForSeconds(0.1f);
                }

                if (IsDoorbellSpamEnabled)
                {
                    yield return null;
                }
                else
                {
                    yield break;
                }
            }
        }

        private static List<UdonBehaviour_Cached> chairs;

        private static void BlueChairSpam()
        {
            chairs = new List<UdonBehaviour_Cached>();
            WorldUtils.GetUdonScripts().Where(b => b.name == "Chair").ToList().ForEach(s => chairs.Add(s.FindUdonEvent("Sit")));
            _ = MelonCoroutines.Start(DoBlueChairSpam());
        }

        private static IEnumerator DoBlueChairSpam()
        {
            for (; ; )
            {
                if (!isCurrentWorld || !IsBlueChairEnabled)
                {
                    yield break;
                }

                foreach (var chair in chairs)
                {

                    yield return null;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

        private static void ToggleDoor(int doorID)
        {
            UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLock{doorID}").ExecuteUdonEvent();
            RefreshButtons();
        }

        public override void OnRoomLeft()
        {
            if (isCurrentWorld)
            {
                isCurrentWorld = false;
                ModConsole.Log("Leaving B Club");
                Bools.IsBClubVIPSpoofing = false;
                PlayerUtils.GetAPIUser()._displayName_k__BackingField = realName;
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.BClub)
            {
                isCurrentWorld = true;
                realName = PlayerUtils.GetPlayer().GetDisplayName();
                WorldUtils.GetUdonScripts().Where(b => b.name == "Doorbell").ToList().ForEach(s => _bells.Add(s.FindUdonEvent("DingDong")));
                ModConsole.Log($"Recognized {Name} World! This world has an exploit menu, and other extra goodies!");

                var penthouseRoot = GameObjectFinder.FindRootSceneObject("Penthouse");
                if (penthouseRoot != null)
                {
                    LockIndicator1 = penthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 1/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator2 = penthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 2/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator3 = penthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 3/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator4 = penthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 4/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator5 = penthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 5/Screen/Canvas/Indicators/Locked").gameObject;
                    LockIndicator6 = penthouseRoot.transform.FindObject("Private Rooms Exterior/Room Entrances/Private Room Entrance 6/Screen/Canvas/Indicators/Locked").gameObject;
                }
                else
                {
                    ModConsole.Error("Failed to find Penthouse!");
                }

                try
                {
                    ModConsole.DebugLog("Searching for Private Rooms Exteriors...");
                    _ = CreateButtonGroup(1, new Vector3(-111.00629f, 15.75226f, -0.3361053f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    _ = CreateButtonGroup(2, new Vector3(-109.28977f, 15.81609f, -4.297329f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    _ = CreateButtonGroup(3, new Vector3(-103.00354f, 15.85877f, -0.3256264f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    _ = CreateButtonGroup(4, new Vector3(-101.28438f, 15.79742f, -4.307182f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    _ = CreateButtonGroup(5, new Vector3(-95.01436f, 15.78151f, -0.3279915f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    _ = CreateButtonGroup(6, new Vector3(-93.28891f, 15.78925f, -4.3116f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));

                    // Penthouse/Private Rooms Exterior/Room Entrances/Private Room Entrance VIP/VIP Out Walls

                    // VIP Room
                    VIPRoom = GameObjectFinder.FindRootSceneObject("Bedroom VIP");

                    if (VIPRoom == null)
                    {
                        ModConsole.Error("VIP Bedroom was not found!");
                    }
                    else
                    {
                        VIPInsideDoor = VIPRoom.transform.FindObject("BedroomUdon/Door Inside/Door").gameObject;

                        if (VIPInsideDoor == null)
                        {
                            ModConsole.Log("VIP Inside Door not found!");
                        }
                        else
                        {
                            ModConsole.Log("VIP Inside Door found..");
                        }
                    }

                    CreateVIPEntryButton(new Vector3(-80.4f, 16.0598f, -1.695f), Quaternion.Euler(0f, 90f, 0f));

                    // Click stupid warning button in elevator.
                    MiscUtils.DelayFunction(5f, () =>
                    {
                        var elevatorButton = GameObjectFinder.Find("Lobby/Entrance Corridor/Udon/Warning/Enter - BlueButtonWide/Button Interactable");
                        if (elevatorButton != null)
                        {
                            var udonComp = elevatorButton.GetComponent<UdonBehaviour>();
                            if (udonComp != null)
                            {
                                udonComp.Interact();
                            }
                            else
                            {
                                ModConsole.Error("Elevator Button's Udon Component Not Found!");
                            }
                        }
                        else
                        {
                            ModConsole.Error("Elevator Button Not Found!");
                        }
                    });

                    // Restore the VIP Button
                    MiscUtils.DelayFunction(5f, () =>
                    {
                        RestoreVIPButton();
                    });

                    RemovePrivacyBlocksOnRooms(1);
                    RemovePrivacyBlocksOnRooms(2);
                    RemovePrivacyBlocksOnRooms(3);
                    RemovePrivacyBlocksOnRooms(4);
                    RemovePrivacyBlocksOnRooms(5);
                    RemovePrivacyBlocksOnRooms(6);

                    lockActions = new UdonBehaviour_Cached[6];
                    for (int i = 1; i <= 6; i++)
                    {
                        lockActions.Append(UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLock{i}"));
                        ModConsole.Log($"Found: {lockActions[i].UdonBehaviour.name}");
                    }

                    _ = MelonCoroutines.Start(UpdateButtonsLoop());
                }
                catch (Exception e)
                {
                    ModConsole.DebugErrorExc(e);
                }
            }
            else
            {
                Bools.IsBClubVIPSpoofing = false;
            }
        }

        private static void RestoreVIPButton()
        {
            // Restore VIP button
            VIPButton = VIPRoom.transform.Find("BedroomUdon/Door Tablet/BlueButtonWide - Toggle VIP only").gameObject;
            if (VIPButton != null)
            {
                VIPButton.gameObject.transform.position = new Vector3(60.7236f, 63.1298f, -1.7349f);
            }
            else
            {
                ModConsole.Error("VIP Button not found!");
            }
        }

        private static IEnumerator UpdateButtonsLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld) yield break;

                if (Bools.IsBClubVIPSpoofing)
                {
                    RestoreVIPButton();
                    PlayerUtils.GetAPIUser()._displayName_k__BackingField = "Blue-kun";
                }
                RefreshButtons();
                yield return new WaitForSeconds(0.1f);
            }
        }

        private static void EnterVIPRoom()
        {
            if (VIPRoom != null)
            {
                VIPRoom.SetActive(true);
            }

            Utils.LocalPlayer.gameObject.transform.position = VIPInsideDoor.transform.position + new Vector3(0.5f, 0, 0);
            Utils.LocalPlayer.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        private void CreateVIPEntryButton(Vector3 position, Quaternion rotation)
        {
            VIPInsideDoor = VIPRoom.transform.FindObject("BedroomUdon/Door Inside/Door").gameObject;

            if (VIPInsideDoor != null)
            {
                _ = new WorldButton(position, rotation, "Enter\nVIP Room", () =>
                {
                    EnterVIPRoom();
                });
            }
        }

        private void RemovePrivacyBlocksOnRooms(int roomid)
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
            GameObject nlobby = GameObjectFinder.FindRootSceneObject("Penthouse");
            GameObject Bedrooms = GameObjectFinder.FindRootSceneObject("Bedrooms");

            if (Bedrooms != null)
            {
                var room = nlobby.transform.FindObject($"Private Rooms Exterior/Room Entrances/Private Room Entrance {doorID}");
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
                            void action() { udonEvent.ExecuteUdonEvent(); }
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

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
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
                            void action() { udonEvent.ExecuteUdonEvent(); }
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

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
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
                            void action() { udonEvent.ExecuteUdonEvent(); }
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

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
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
                            void action() { udonEvent.ExecuteUdonEvent(); }
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

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
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
                            void action() { udonEvent.ExecuteUdonEvent(); }
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

                                var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
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
                if (nlobby == null)
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

        private static void PatreonPatch()
        {
            PatchPatreonList();
            PatchPatreonNode();
            UdonSearch.FindUdonEvent("Patreon", $"IsPatron")?.ExecuteUdonEvent();
            UdonSearch.FindUdonEvent("Patreon", $"IsElite")?.ExecuteUdonEvent();
            UdonSearch.FindUdonEvent("Patreon", $"_ProcessPatrons")?.ExecuteUdonEvent();
        }

        private static void PatchPatreonList()
        {
            try
            {
                var patreonlist = GameObjectFinder.Find("/Udon/Patreon Lists");
                if (patreonlist != null)
                {
                    var node = patreonlist.GetComponent<UdonBehaviour>();
                    var disassembled = node.DisassembleUdonBehaviour();
                    if (disassembled != null)
                    {
                        var obj_List = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("localPatrons"));
                        if (obj_List != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "localPatrons", Utils.LocalPlayer.displayName, true);
                        }

                        var localVipsPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("localVips"));
                        if (localVipsPatch != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "localVips", Utils.LocalPlayer.displayName, true);
                        }

                        var obj_List2 = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("__0_intnl_interpolatedStr_String"));
                        if (obj_List2 != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "__0_intnl_interpolatedStr_String", Utils.LocalPlayer.displayName, true);
                        }

                        var obj_List3 = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("syncedVips"));
                        if (obj_List3 != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "syncedVips", Utils.LocalPlayer.displayName, true);
                        }

                        var obj_List4 = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("__0_mp_liveVips_String"));
                        if (obj_List4 != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "__0_mp_liveVips_String", Utils.LocalPlayer.displayName, true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private static void PatchPatreonNode()
        {
            var patreonlist = GameObjectFinder.Find("Udon/Patreon");
            if (patreonlist != null)
            {
                var node = patreonlist.GetComponent<UdonBehaviour>();
                var disassembled = node.DisassembleUdonBehaviour();
                if (disassembled != null)
                {
                    try
                    {
                        var isEliteBoolPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("__0_isElite_Boolean"));
                        if (isEliteBoolPatch != null)
                        {
                            var extract = isEliteBoolPatch.Unpack_Boolean();
                            if (extract.HasValue)
                            {
                                if (!extract.Value)
                                {
                                    UdonHeapEditor.PatchHeap(disassembled, "__0_isElite_Boolean", true, true);
                                }
                            }
                        }

                        var vipOnlyPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("vipOnly"));
                        if (vipOnlyPatch != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "vipOnly", false, true);
                        }

                        var vipOnlyLocalPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("vipOnlyLocal"));
                        if (vipOnlyLocalPatch != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "vipOnlyLocal", false, true);
                        }

                        var patronPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("__0_isPatron_Boolean"));
                        if (patronPatch != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "__0_isPatron_Boolean", true, true);
                        }

                        var obj_List = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("__0_mp_patronsToProcess_String"));
                        if (obj_List != null)
                        {
                            UdonHeapEditor.PatchHeap(disassembled, "__0_mp_patronsToProcess_String", Utils.LocalPlayer.displayName, true);
                        }
                    }
                    catch (Exception e)
                    {
                        ModConsole.ErrorExc(e);
                    }
                }
                try
                {
                    var Elite_List = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("elitesInInstance"));
                    if (Elite_List != null)
                    {
                        var list = Elite_List.Unpack_Array_VRCPlayerApi().ToList();
                        if (list.Count() != 0)
                        {
                            if (!list.Contains(Utils.LocalPlayer))
                            {
                                list.Add(Utils.LocalPlayer);
                            }
                        }
                        else
                        {
                            list = new List<VRC.SDKBase.VRCPlayerApi>
                            {
                                Utils.LocalPlayer
                            };
                        }

                        UdonHeapEditor.PatchHeap(disassembled, "elitesInInstance", list.ToArray(), true);
                    }

                    var Patron_List = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("vipsInInstance"));
                    if (Patron_List != null)
                    {
                        var list = Patron_List.Unpack_Array_VRCPlayerApi().ToList();
                        if (list.Count() != 0)
                        {
                            if (!list.Contains(Utils.LocalPlayer))
                            {
                                list.Add(Utils.LocalPlayer);
                            }
                        }
                        else
                        {
                            list = new List<VRC.SDKBase.VRCPlayerApi>
                            {
                                Utils.LocalPlayer
                            };
                        }

                        UdonHeapEditor.PatchHeap(disassembled, "vipsInInstance", list.ToArray(), true);
                    }
                    node.InitializeUdonContent();
                    node.Start();
                }
                catch (Exception e)
                {
                    ModConsole.ErrorExc(e);
                }
            }
        }
    }
}