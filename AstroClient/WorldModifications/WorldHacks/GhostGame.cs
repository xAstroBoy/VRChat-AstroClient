namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class GhostGame : AstroEvents
    {

        internal static void InitButtons(QMGridTab main)
        {
            GhostGameMenu = new QMNestedGridMenu(main, "Ghost Game Exploits", "Ghost Game Exploits");
            new QMSingleButton(GhostGameMenu, "toggle Lobby Mirror (skip master)", () => { ToggleMirrors_1.InvokeBehaviour(); }, "Toggle Lobby Mirror without being master (Fuck the mirror zombies)");
            new QMSingleButton(GhostGameMenu, "toggle Mailbox Mirror (skip master)", () => { ToggleMirrors_2.InvokeBehaviour(); }, "Toggle Mailbox Mirror without being master (Fuck the mirror zombies)");
            TrollMirrorZombiesBtn = new QMToggleButton(GhostGameMenu, "Turn Off Mirror Troll", () => { FuckOffMirrorZombies = true; }, () => { FuckOffMirrorZombies = false; }, "Turn off Mirrors To piss Zombie Mirrors and make them mad!");
        }

        internal override void OnRoomLeft()
        {
            isGhostGameWorld = false;
            ToggleMirrors_1 = null;
            ToggleMirrors_2 = null;
            TurnOffMirror_1 = null;
            TurnOffMirror_2 = null;
            FuckOffMirrorZombies = false;
            FuckOffMirrorZombiesRoutine = null;
            ArmoryDoor_AddKeyOnDoor = null;
            ArmoryDoor_LockDoor = null;

            ArmoryDoor_OpenDoor_Clockwise = null;
            ArmoryDoor_OpenDoor_CounterClockwise = null;
            ArmoryDoor_CloseDoor_Clockwise = null;
            ArmoryDoor_CloseDoor_CounterClockwise = null;
            ArmoryDoor_ResetDoor = null;
            Armory_GetMoneyReward = null;

        }

        internal static void FindEverything()
        {
            ToggleMirrors_1 = UdonSearch.FindUdonEvent("LobbyMirrorController", "Net_ToggleMirror");
            ToggleMirrors_2 = UdonSearch.FindUdonEvent("MailBox", "Net_ToggleMirror");
            TurnOffMirror_1 = UdonSearch.FindUdonEvent("MirrorManager", "ToggleOffMirros");
            TurnOffMirror_2 = UdonSearch.FindUdonEvent("MirrorManager (1)", "ToggleOffMirros");

            ToggleMirrors_1.UdonBehaviour.gameObject.AddToWorldUtilsMenu();
            ToggleMirrors_2.UdonBehaviour.gameObject.AddToWorldUtilsMenu();
            TurnOffMirror_1.UdonBehaviour.gameObject.AddToWorldUtilsMenu();
            TurnOffMirror_2.UdonBehaviour.gameObject.AddToWorldUtilsMenu();

            if (ArmoryRoom != null)
            {
                if (ArmoryMoneyRewardObject != null)
                {
                    Armory_GetMoneyReward = UdonSearch.FindUdonEvent(ArmoryMoneyRewardObject, "_interact");
                }

                if (ArmoryDoorObject != null)
                {
                    ArmoryDoor_LockDoor = UdonSearch.FindUdonEvent(ArmoryDoorObject, "LockDoor", "Local_ResetLock");
                    ArmoryDoor_AddKeyOnDoor = UdonSearch.FindUdonEvent(ArmoryDoorObject, "LockDoor", "Local_AddOneMoreKey");

                    ArmoryDoor_OpenDoor_Clockwise = UdonSearch.FindUdonEvent(ArmoryDoorObject, "DoorParent", "Local_OpenClockwise");
                    ArmoryDoor_OpenDoor_CounterClockwise = UdonSearch.FindUdonEvent(ArmoryDoorObject, "DoorParent", "Local_OpenCounterClockwise");

                    ArmoryDoor_CloseDoor_Clockwise = UdonSearch.FindUdonEvent(ArmoryDoorObject, "DoorParent", "Local_CloseClockwise");
                    ArmoryDoor_CloseDoor_CounterClockwise = UdonSearch.FindUdonEvent(ArmoryDoorObject, "DoorParent", "Local_CloseCounterClockwise");

                    ArmoryDoor_ResetDoor = UdonSearch.FindUdonEvent(ArmoryDoorObject, "DoorParent", "Local_ResetDoor");
                }

                if (WeaponsWorkshopObject != null)
                {
                    if (Armory_Craft_Sniper != null)
                    {
                        Armory_CraftSniper = UdonSearch.FindUdonEvent(Armory_Craft_Sniper, "CraftBtn", "_interact");
                    }

                    if (Armory_Craft_Gun != null)
                    {
                        Armory_CraftGun = UdonSearch.FindUdonEvent(Armory_Craft_Gun, "CraftBtn", "_interact");
                    }

                    if (Armory_Craft_Clue != null)
                    {
                        Armory_CraftClue = UdonSearch.FindUdonEvent(Armory_Craft_Clue, "CraftBtn", "_interact");

                    }

                }

                if (ArmoryCabinets != null)
                {
                    if (Cabinet_1_lock != null)
                    {
                        Armory_OpenCabinet_1 = UdonSearch.FindUdonEvent(Cabinet_1_lock, "_interact");

                    }

                    if (Cabinet_2_lock != null)
                    {
                        Armory_OpenCabinet_2 = UdonSearch.FindUdonEvent(Cabinet_2_lock, "_interact");
                    }
                }
            }
        }

        private static object FuckOffMirrorZombiesRoutine;
        private static bool _FuckOffMirrorZombies;
        internal static bool FuckOffMirrorZombies
        {
            get
            {
                return _FuckOffMirrorZombies;
            }
            set
            {
                _FuckOffMirrorZombies = value;
                if (TrollMirrorZombiesBtn != null)
                {
                    TrollMirrorZombiesBtn.SetToggleState(value);
                }
                if (value)
                {
                    if (FuckOffMirrorZombiesRoutine == null)
                    {
                        FuckOffMirrorZombiesRoutine = MelonCoroutines.Start(FuckOffMirrorsZombies());
                    }
                }
                else
                {
                    if (FuckOffMirrorZombiesRoutine != null)
                    {
                        MelonCoroutines.Stop(FuckOffMirrorZombiesRoutine);
                    }
                    FuckOffMirrorZombiesRoutine = null;
                }
            }
        }

        private static IEnumerator FuckOffMirrorsZombies()
        {
            for (; ; )
            {
                if (!isGhostGameWorld)
                {
                    FuckOffMirrorZombies = false;
                    yield break;
                }

                TurnOffMirror_1?.InvokeBehaviour();
                yield return new WaitForSeconds(0.05f);
                TurnOffMirror_2?.InvokeBehaviour();
                yield return new WaitForSeconds(0.05f);

                if (FuckOffMirrorZombies)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    yield break;
                }
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.GhostGame)
            {

                ModConsole.Log($"Recognized {Name} World, mirror toggle exploit available....");
                isGhostGameWorld = true;
                if (GhostGameMenu != null)
                {
                    GhostGameMenu.SetInteractable(true);
                    GhostGameMenu.SetTextColor(Color.green);
                }

                FindEverything();
            }
            else
            {
                isGhostGameWorld = false;
                if (GhostGameMenu != null)
                {
                    GhostGameMenu.SetInteractable(false);
                    GhostGameMenu.SetTextColor(Color.red);
                }
            }
        }

        private static GameObject _ArmoryRoom;
        private static GameObject ArmoryRoom
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (_ArmoryRoom == null)
                {
                    return _ArmoryRoom = GameObjectFinder.Find("/PoliceStation_A/RoomParts/1F/ArmoryRoom");
                }
                return _ArmoryRoom;
            }
        }

        private static GameObject _ArmoryMoneyRewardObject;
        private static GameObject ArmoryMoneyRewardObject
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (ArmoryRoom == null) return null;
                if (_ArmoryMoneyRewardObject == null)
                {
                    return _ArmoryMoneyRewardObject = ArmoryRoom.transform.FindObject("Cabinets/Closet_A (5)/LootBoxSystem/Rewards/Reward_FallBack/FallBackReward/MoneyPack/Pickup (2)").gameObject;
                }
                return _ArmoryMoneyRewardObject;
            }
        }
        private static GameObject _ArmoryCabinets;
        private static GameObject ArmoryCabinets
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (ArmoryRoom == null) return null;
                if (_ArmoryCabinets == null)
                {
                    return _ArmoryCabinets = ArmoryRoom.transform.FindObject("Cabinets").gameObject;
                }
                return _ArmoryCabinets;
            }
        }
        private static GameObject _Cabinet_1_lock;
        private static GameObject Cabinet_1_lock
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (ArmoryRoom == null) return null;
                if (ArmoryCabinets == null) return null;
                if (_Cabinet_1_lock == null)
                {
                    return _Cabinet_1_lock = ArmoryCabinets.transform.FindObject("Closet_A (5)/LootBoxSystem/Lock").gameObject;
                }
                return _Cabinet_1_lock;
            }
        }

        private static GameObject _Cabinet_2_lock;
        private static GameObject Cabinet_2_lock
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (ArmoryRoom == null) return null;
                if (ArmoryCabinets == null) return null;
                if (_Cabinet_2_lock == null)
                {
                    return _Cabinet_2_lock = ArmoryCabinets.transform.FindObject("Closet_A (4)/LootBoxSystem/Lock").gameObject;
                }
                return _Cabinet_2_lock;
            }
        }

        private static GameObject _ArmoryDoorObject;
        private static GameObject ArmoryDoorObject
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (ArmoryRoom == null) return null;
                if (_ArmoryDoorObject == null)
                {
                    return _ArmoryDoorObject = ArmoryRoom.transform.FindObject("LockDoor").gameObject;
                }
                return _ArmoryDoorObject;
            }
        }

        private static GameObject _WeaponsWorkshopObject;
        private static GameObject WeaponsWorkshopObject
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (_WeaponsWorkshopObject == null)
                {
                    return _WeaponsWorkshopObject = GameObjectFinder.Find("/PoliceStation_A/Functions/WeaponWorkShops");
                }
                return _WeaponsWorkshopObject;
            }
        }

        private static GameObject _Armory_Craft_Sniper;
        private static GameObject Armory_Craft_Sniper
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (WeaponsWorkshopObject == null) return null;
                if (_Armory_Craft_Sniper == null)
                {
                    return _Armory_Craft_Sniper = WeaponsWorkshopObject.transform.FindObject("T4_M107").gameObject;
                }
                return _Armory_Craft_Sniper;
            }
        }

        private static GameObject _Armory_Craft_Gun;
        private static GameObject Armory_Craft_Gun
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (WeaponsWorkshopObject == null) return null;
                if (_Armory_Craft_Gun == null)
                {
                    return _Armory_Craft_Gun = WeaponsWorkshopObject.transform.FindObject("T4_M249").gameObject;
                }
                return _Armory_Craft_Gun;
            }
        }
        private static GameObject _Armory_Craft_Clue;
        private static GameObject Armory_Craft_Clue
        {
            get
            {
                if (!isGhostGameWorld) return null;
                if (WeaponsWorkshopObject == null) return null;
                if (_Armory_Craft_Clue == null)
                {
                    return _Armory_Craft_Clue = WeaponsWorkshopObject.transform.FindObject("ClueFileGenerator (2)").gameObject;
                }
                return _Armory_Craft_Clue;
            }
        }

        internal static UdonBehaviour_Cached ToggleMirrors_1 { get; set; } // Fuck the mirrors.
        internal static UdonBehaviour_Cached ToggleMirrors_2 { get; set; } // Fuck the mirrors.

        internal static UdonBehaviour_Cached TurnOffMirror_1 { get; set; } // Fuck the mirrors.
        internal static UdonBehaviour_Cached TurnOffMirror_2 { get; set; } // Fuck the mirrors.

        internal static UdonBehaviour_Cached ArmoryDoor_LockDoor { get; set; }
        internal static UdonBehaviour_Cached ArmoryDoor_AddKeyOnDoor { get; set; }
        internal static UdonBehaviour_Cached ArmoryDoor_OpenDoor_Clockwise { get; set; }
        internal static UdonBehaviour_Cached ArmoryDoor_OpenDoor_CounterClockwise { get; set; }
        internal static UdonBehaviour_Cached ArmoryDoor_CloseDoor_Clockwise { get; set; }
        internal static UdonBehaviour_Cached ArmoryDoor_CloseDoor_CounterClockwise { get; set; }
        internal static UdonBehaviour_Cached ArmoryDoor_ResetDoor { get; set; }

        internal static UdonBehaviour_Cached Armory_CraftSniper { get; set; }
        internal static UdonBehaviour_Cached Armory_CraftGun { get; set; }
        internal static UdonBehaviour_Cached Armory_CraftClue { get; set; }

        internal static UdonBehaviour_Cached Armory_GetMoneyReward { get; set; }
        internal static UdonBehaviour_Cached Armory_OpenCabinet_1 { get; set; }
        internal static UdonBehaviour_Cached Armory_OpenCabinet_2 { get; set; }

        internal static QMToggleButton TrollMirrorZombiesBtn { get; set; }
        internal static QMNestedGridMenu GhostGameMenu { get; set; }
        internal static bool isGhostGameWorld = false;
    }
}