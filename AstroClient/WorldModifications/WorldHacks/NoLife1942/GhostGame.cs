using System.Collections;
using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using MelonLoader;
using UnityEngine;
using VRC.Core;

namespace AstroClient.WorldModifications.WorldHacks.NoLife1942
{
    internal class GhostGame : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnEnterWorld += EnterWorld;
            ClientEventActions.OnWorldReveal += OnWorldReveal;

        }
        private void EnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            if (world == null) return;
            //if (world.id.Equals(WorldIds.GhostGame))
            //{
            //    UdonReplacer.ReplaceString(world.authorName, PlayerSpooferUtils.Original_DisplayName);
            //}


        }



        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            isGhostGameWorld = false;
            ArmoryDoor_AddKeyOnDoor = null;
            ArmoryDoor_LockDoor = null;

            ArmoryDoor_OpenDoor_Clockwise = null;
            ArmoryDoor_OpenDoor_CounterClockwise = null;
            ArmoryDoor_CloseDoor_Clockwise = null;
            ArmoryDoor_CloseDoor_CounterClockwise = null;
            ArmoryDoor_ResetDoor = null;
            Armory_GetMoneyReward = null;
            HasSubscribed = false;
        }

        internal static void FindEverything()
        {
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


        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.GhostGame)
            {

                Log.Write($"Recognized {Name} World, Cheats available....");
                isGhostGameWorld = true;
                if (GhostGameMenu != null)
                {
                    GhostGameMenu.SetInteractable(true);
                    GhostGameMenu.SetTextColor(Color.green);
                }
                HasSubscribed = true;
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
                HasSubscribed = false;
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
                    return _ArmoryRoom = Finder.Find("/PoliceStation_A/RoomParts/1F/ArmoryRoom");
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
                    return _WeaponsWorkshopObject = Finder.Find("/PoliceStation_A/Functions/WeaponWorkShops");
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

        internal static QMNestedGridMenu GhostGameMenu { get; set; }
        internal static bool isGhostGameWorld = false;
    }
}