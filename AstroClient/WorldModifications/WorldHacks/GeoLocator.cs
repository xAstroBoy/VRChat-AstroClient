using AstroClient.AstroMonos.Components.Cheats.Worlds.GeoLocator;
using AstroClient.AstroMonos.Components.Cheats.Worlds.UdonTycoon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.PatronCrackers;
    using AstroMonos.Components.Cheats.Worlds.PuttPuttPond;
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

    internal class GeoLocator : AstroEvents
    {

        internal static void InitButtons(QMGridTab main)
        {
        }

        

        private static void FindEverything()
        {
            
            if(Customization != null)
            {
                Customization.GetOrAddComponent<GeoLocator_CustomizationReader>();
            }

        }



        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.GeoLocator)
            {

                Log.Write($"Recognized {Name} World, Patching Patron System....");
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


        private static GameObject _Game;
        internal static GameObject Game
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Game == null)
                {
                    return _Game = GameObjectFinder.FindRootSceneObject("Game");
                }

                return _Game;
            }
        }
        private static GameObject _Customization;
        internal static GameObject Customization
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Game == null) return null;
                if (_Customization == null)
                {
                    return _Customization = Game.FindObject("Customization");
                }

                return _Customization;
            }
        }

        private static GameObject _PlayerManager;
        internal static GameObject PlayerManager
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_PlayerManager == null)
                {
                    return _PlayerManager = GameObjectFinder.FindRootSceneObject("PlayerManager");
                }

                return _PlayerManager;
            }
        }
        private static GameObject _PlayerPermissionManager;
        internal static GameObject PlayerPermissionManager
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (PlayerManager == null) return null;
                if (_PlayerPermissionManager == null)
                {
                    return _PlayerPermissionManager = PlayerManager.FindObject("PlayerPermissionManager");
                }

                return _PlayerPermissionManager;
            }
        }



        internal static bool isCurrentWorld { get; set; } = false;

        internal static QMNestedGridMenu CurrentMenu { get; set; }

    }
}