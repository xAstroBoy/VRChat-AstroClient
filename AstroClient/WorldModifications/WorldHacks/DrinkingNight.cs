using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;
using UnityEngine.AI;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.PatronCrackers;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.World;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class DrinkingNight : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            
        }
        private static Transform _Rooms;

        internal static Transform Rooms
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Rooms == null)
                {
                    return _Rooms = GameObjectFinder.FindRootSceneObject("--- Rooms ---").transform;
                }

                return _Rooms;
            }
        }
        private static Transform _AlwaysOn;

        internal static Transform AlwaysOn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_AlwaysOn == null)
                {
                    return _AlwaysOn = GameObjectFinder.FindRootSceneObject("--- Always On ---").transform;
                }

                return _AlwaysOn;
            }
        }
        private static Transform _GameLocks;

        internal static Transform GameLocks
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (AlwaysOn == null) return null;
                if (_GameLocks == null)
                {
                    return _GameLocks = AlwaysOn.FindObject("Game Locks").transform;
                }

                return _GameLocks;
            }
        }
        private static Transform _Elevator_Buttons;

        internal static Transform Elevator_Buttons
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (AlwaysOn == null) return null;
                if (_Elevator_Buttons == null)
                {
                    return _Elevator_Buttons = AlwaysOn.FindObject("Elevator TPs").transform;
                }

                return _Elevator_Buttons;
            }
        }

        private static GameObject VIPDoor_1 { get; set; }
        private static GameObject VIPDoor_2 { get; set; }
        private static GameObject VIPDoor_3 { get; set; }
        private static GameObject VIPDoor_4 { get; set; }
        private static GameObject PlayerButtons { get; set; }


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
                        ClientEventActions.OnUpdate += OnUpdate;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnUpdate -= OnUpdate;
                    }
                }
                _HasSubscribed = value;
            }
        }

        private static  void OnRoomLeft()
        {

            HasSubscribed = false;
        }

        private static void OnUpdate()
        {
            if (VIPDoor_1 != null)
            {
                if (!VIPDoor_1.active)
                {
                    VIPDoor_1.SetActive(true);
                }
            }
            if (VIPDoor_2 != null)
            {
                if (!VIPDoor_2.active)
                {
                    VIPDoor_2.SetActive(true);
                }
            }
            //if (VIPDoor_3 != null)
            //{
            //    if (!VIPDoor_3.active)
            //    {
            //        VIPDoor_3.SetActive(true);
            //    }
            //}
            //if (VIPDoor_4 != null)
            //{
            //    if (!VIPDoor_4.active)
            //    {
            //        VIPDoor_4.SetActive(true);
            //    }
            //}
            if (PlayerButtons != null)
            {
                if (!PlayerButtons.active)
                {
                    PlayerButtons.SetActive(true);
                }
            }

        }

        internal static void InitButtons(QMGridTab main)
        {
        }

        private static string[] ElevatorBtnPaths = new[]
        {
            "--- Always On ---/Elevator TPs/Hot Seat TP",
            "--- Always On ---/Elevator TPs/Kings Game TP",
            "--- Always On ---/Elevator TPs/VIP Room TP (1)",
            "--- Always On ---/Elevator TPs/Board Game TP",
            "--- Always On ---/Elevator TPs/Card Troubles Off",
            "--- Always On ---/Elevator TPs/Kings Game OFF",
            "--- Always On ---/Elevator TPs/Outdoor Fun TP",
            "--- Always On ---/Elevator TPs/Card Troubles TP",
            "--- Always On ---/Elevator TPs/Main Floor TP",
            "--- Always On ---/Elevator TPs/Random TP",
            "--- Always On ---/Elevator TPs/Board Game Off",
            "--- Always On ---/Elevator TPs/VIP Room TP",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/VIP",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Colliders Toggle",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Cylinder (24)",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/VIPPlus",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Chairs Toggle",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Music Toggle",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Join Leave Sound Toggle",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Optimize",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Optimize Normal",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Discord",
            "--- Rooms ---/Main Room/Entrance Hallway/Spawn Elevator/Buttons/World Toggles/Discord Gold",

        };


        private static void FindEverything()
        {
            var trash1 = GameObjectFinder.FindRootSceneObject("Cubessss");
            if(trash1 != null)
            {
                trash1.DestroyMeLocal();
            }
            var VIPRoom = Rooms.FindObject("VIP Room");
            if (VIPRoom != null)
            {
                VIPRoom.gameObject.SetActive(true);
                VIPRoom.GetOrAddComponent<Enabler>();
                VIPRoom.Set_UdonBehaviour_DisableInteractive(false);
                var VIPTP = VIPRoom.FindObject("VIP TP");
                if (VIPTP != null)
                {
                    VIPTP.gameObject.SetActive(true);
                    VIPTP.GetOrAddComponent<Enabler>();
                    VIPTP.Set_UdonBehaviour_DisableInteractive(false);
                }
            }
            foreach(var item in ElevatorBtnPaths)
            {
                var obj = GameObjectFinder.Find(item);
                if (obj != null)
                {
                    obj.gameObject.SetActive(true);
                    //obj.GetOrAddComponent<Enabler>();
                    obj.Set_UdonBehaviour_DisableInteractive(false);
                }
            }

            if(GameLocks != null)
            {
                var DebugRoot = GameLocks.FindObject("Debug");
                if(DebugRoot != null)
                {
                    DebugRoot.gameObject.SetActive(true);
                    VIPDoor_1 = DebugRoot.FindObject("Access").gameObject;
                    if (VIPDoor_1 != null)
                    {
                        VIPDoor_1.SetActive(true);
                    }
                    VIPDoor_2 = DebugRoot.FindObject("Access other").gameObject;
                    if (VIPDoor_2 != null)
                    {
                        VIPDoor_2.SetActive(true);
                    }
                }
                var cardgame = GameLocks.FindObject("Card Game");
                if (cardgame != null)
                {
                    VIPDoor_3 = cardgame.FindObject("Dare Button").gameObject;
                    if (VIPDoor_3 != null)
                    {
                        VIPDoor_3.gameObject.SetActive(true);
                        //VIPDoor_3.GetOrAddComponent<Enabler>();
                        VIPDoor_3.Set_UdonBehaviour_DisableInteractive(false);
                    }
                    VIPDoor_4 = cardgame.FindObject("Dare Button 2").gameObject;
                    if (VIPDoor_4 != null)
                    {
                        VIPDoor_4.gameObject.SetActive(true);
                        //VIPDoor_4.GetOrAddComponent<Enabler>();
                        VIPDoor_4.Set_UdonBehaviour_DisableInteractive(false);

                    }
                }
            }
        

            var UserEnableList = AlwaysOn.FindObject("User Enable List (1)");
            if(UserEnableList != null)
            {
                var canvas = UserEnableList.FindObject("Canvas");
                if(canvas != null)
                {
                    PlayerButtons = canvas.FindObject("Player Buttons").gameObject;
                    if(PlayerButtons != null)
                    {
                        PlayerButtons.gameObject.SetActive(true);
                        PlayerButtons.GetOrAddComponent<Enabler>();
                    }
                }
            }

            //Patch_PatronStuff();
            HasSubscribed = true;
            isCurrentWorld = true;
        }






        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.DrinkingNight)
            {

                Log.Write($"Recognized {Name} World, Patching Patron....");
                isCurrentWorld = true;
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(true);
                    CurrentMenu.SetTextColor(Color.green);
                }

                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
                HasSubscribed = false;
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(false);
                    CurrentMenu.SetTextColor(Color.red);
                }
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;

        internal static QMNestedGridMenu CurrentMenu { get; set; }

    }
}