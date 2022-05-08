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

    internal class TreeHouseInTheShade : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }
        private static Transform _Jetpack_Panel;

        internal static Transform Jetpack_Panel
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Jetpack_Panel == null)
                {
                    return _Jetpack_Panel = GameObjectFinder.FindRootSceneObject("Jetpack Panel").transform;
                }

                return _Jetpack_Panel;
            }
        }


        private static Transform _Canvas;

        internal static Transform Canvas
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Jetpack_Panel == null) return null;
                if (_Canvas == null)
                {
                    return _Canvas = Jetpack_Panel.FindObject("Canvas").transform;
                }

                return _Canvas;
            }
        }
        private static Transform _TimerEnableButtons;

        internal static Transform TimerEnableButtons
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_TimerEnableButtons == null)
                {
                    return _TimerEnableButtons = Canvas.FindObject("TimerEnableButtons").transform;
                }

                return _TimerEnableButtons;
            }
        }
        private static Transform _TextCooldown;

        internal static Transform TextCooldown
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_TextCooldown == null)
                {
                    return _TextCooldown = Canvas.FindObject("TextCooldown").transform;
                }

                return _TextCooldown;
            }
        }

        private static Transform _Spawn_Desktop;

        internal static Transform Spawn_Desktop
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_Spawn_Desktop == null)
                {
                    return _Spawn_Desktop = Canvas.FindObject("Button1 Spawn Desktop").transform;
                }

                return _Spawn_Desktop;
            }
        }
        private static Transform _Spawn_VR;

        internal static Transform Spawn_VR
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Canvas == null) return null;
                if (_Spawn_VR == null)
                {
                    return _Spawn_VR = Canvas.FindObject("Button2 Spawn VR").transform;
                }

                return _Spawn_VR;
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
            if (TimerEnableButtons != null)
            {
                if (TimerEnableButtons.gameObject.active)
                {
                    TimerEnableButtons.gameObject.SetActive(false);
                }
            }

            if (Spawn_VR != null)
            {
                if(!Spawn_VR.gameObject.active)
                {
                    Spawn_VR.gameObject.SetActive(true);
                }
            }
            if (Spawn_Desktop != null)
            {
                if (!Spawn_Desktop.gameObject.active)
                {
                    Spawn_Desktop.gameObject.SetActive(true);
                }
            }

        }




        private static void FindEverything()
        {
            
            if(TextCooldown != null)
            {
                var text = TextCooldown.GetComponent<UnityEngine.UI.Text>();
                if(text != null)
                {
                    text.supportRichText = true;
                    text.resizeTextForBestFit = true;
                    text.text = $"Cooldown Removed By AstroClient \n R.I.P {WorldUtils.AuthorName} \n ????-2020";
                }
            }
            HasSubscribed = true;
            isCurrentWorld = true;
        }






        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.TreeHouseInTheShade)
            {

                Log.Write($"Recognized {Name} World, Removing Jetpack Panel Cooldown....", System.Drawing.Color.Chartreuse);
                Log.Write($"This author passed away of heart failure... RIP {WorldUtils.AuthorName}....", System.Drawing.Color.Gold);
                Log.Write("VRChat should keep the memory alive and keep his quality work alive...", System.Drawing.Color.Gold);
                Log.Write("Im Bypassing the Jetpack because in his other worlds , the jetpack panel has no delay...", System.Drawing.Color.Gold);
                Log.Write("And I hope this guy doesn't mind this bypass...", System.Drawing.Color.Gold);
                Log.Write("If you use munchen, and this world breaks, remove it....", System.Drawing.Color.Gold);

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