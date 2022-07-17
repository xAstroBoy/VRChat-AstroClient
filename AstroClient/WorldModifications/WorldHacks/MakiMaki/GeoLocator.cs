using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki;
using AstroClient.ClientActions;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.WorldModifications.WorldHacks.MakiMaki
{
    internal class GeoLocator : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        



        private static void FindEverything()
        {
            
            if(Customization != null)
            {
                ComponentUtils.GetOrAddComponent<MakiMaki_CustomizationReader>(Customization);
            }

        }



        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
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
                    return _Game = Finder.FindRootSceneObject("Game");
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
                    return _PlayerManager = Finder.FindRootSceneObject("PlayerManager");
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