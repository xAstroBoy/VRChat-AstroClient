using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;

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

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private static  void OnRoomLeft()
        {

            HasSubscribed = false;
        }

        internal static void InitButtons(QMGridTab main)
        {
        }



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
                var VIPTP = VIPRoom.FindObject("VIP TP");
                if (VIPTP != null)
                {
                    VIPTP.gameObject.SetActive(true);
                    VIPTP.GetOrAddComponent<Enabler>();
                }
            }
            if(GameLocks != null)
            {
                var DebugRoot = GameLocks.FindObject("Debug");
                if(DebugRoot != null)
                {
                    DebugRoot.gameObject.SetActive(true);
                    DebugRoot.gameObject.SetActive(true);
                    var VIPRoomDoor1 = DebugRoot.FindObject("Access");
                    if (VIPRoomDoor1 != null)
                    {
                        VIPRoomDoor1.gameObject.SetActive(true);
                        VIPRoomDoor1.GetOrAddComponent<Enabler>();
                    }
                    var VIPRoomDoor2 = DebugRoot.FindObject("Access other");
                    if (VIPRoomDoor2 != null)
                    {
                        VIPRoomDoor2.gameObject.SetActive(true);
                        VIPRoomDoor2.GetOrAddComponent<Enabler>();
                    }
                }
                var cardgame = GameLocks.FindObject("Card Game");
                if(cardgame != null)
                {
                    
                    var VIPRoomDoor3 = DebugRoot.FindObject("Enter Game Room (2)");
                    if (VIPRoomDoor3 != null)
                    {
                        VIPRoomDoor3.gameObject.SetActive(true);
                        VIPRoomDoor3.GetOrAddComponent<Enabler>();
                    }
                    var VIPRoomDoor4 = DebugRoot.FindObject("Enter Game Room (3)");
                    if (VIPRoomDoor4 != null)
                    {
                        VIPRoomDoor4.gameObject.SetActive(true);
                        VIPRoomDoor4.GetOrAddComponent<Enabler>();
                    }
                }
            }
            if(Elevator_Buttons != null)
            {
                var LegitVIPButton = Elevator_Buttons.FindObject("VIP Room TP (1)");
                if(LegitVIPButton != null)
                {
                    LegitVIPButton.gameObject.SetActive(true);
                    LegitVIPButton.RemoveComponent<BoxCollider>(); // Remove and set a meshCollider instead..
                    LegitVIPButton.AddComponent<MeshCollider>();
                    foreach(var udon in LegitVIPButton.Get_UdonBehaviours())
                    {
                        // author being sneaky enabled DisableInteractiveEvent...

                        udon.DisableInteractive = false; // Fuck off

                    }
                }
            }

            var UserEnableList = AlwaysOn.FindObject("User Enable List (1)");
            if(UserEnableList != null)
            {
                var canvas = UserEnableList.FindObject("Canvas");
                if(canvas != null)
                {
                    var playerbtns = canvas.FindObject("Player Buttons");
                    if(playerbtns != null)
                    {
                        playerbtns.gameObject.SetActive(true);
                        playerbtns.GetOrAddComponent<Enabler>();
                    }
                }
            }

            //Patch_PatronStuff();
            HasSubscribed = true;
            isCurrentWorld = true;
        }


        internal static string[] PatronShit { get; } =
        {
                    "isPatron",
                    "bTier3",
                    "bTier2",
        };

        private static void Patch_PatronStuff()
        {
            var results = UdonSearch.FindAllUdonsContainingSymbols(PatronShit);
            foreach (var item in results)
            {
                foreach (var symbolname in PatronShit)
                {
                    var symbol = item.FindUdonVariable(symbolname);
                    if (symbol != null)
                    {
                        UdonHeapEditor.PatchHeap(symbol, symbolname, true, () =>
                        {
                            Log.Debug($"Patched {symbol.gameObject.name} {symbolname} To True");
                        });

                    }
                }

            }
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