﻿namespace AstroClient.WorldModifications.WorldHacks
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

    internal class PuttPuttQuest : AstroEvents
    {

        internal static void InitButtons(QMGridTab main)
        {
            PuttPuttPondMenu = new QMNestedGridMenu(main, "PuttPuttQuest Exploits", "PuttPuttQuest Exploits");
            ActivatePatronModeToggle = new QMToggleButton(PuttPuttPondMenu, "Patron Mode", () => { isPatron = true; }, () => { isPatron = false; }, "Enable Patron Golden putt");
            ActivateRainbowBallToggle = new QMToggleButton(PuttPuttPondMenu, "Rainbow Golf Ball", () => { RainbowBall = true; }, () => { RainbowBall = false; }, "rainbow mode on the golf ball!");
        }

        internal static bool? isPatron
        {
            get
            {
                if (PatronController != null) return PatronController.isPatron;
                return null;
            }
            set
            {
                var newvalue = value.GetValueOrDefault(false);
                if (PatronController != null)
                {
                    PatronController.SetAsPatron(newvalue);
                }
                if (ActivatePatronModeToggle != null) ActivatePatronModeToggle.SetToggleState(newvalue);
            }
        }

        private static void FindEverything()
        {
            foreach (var item in WorldUtils.UdonScripts)
            {
                try
                {
                    if (item != null)
                    {
                        if (PatronController == null)
                        {
                            if (item.gameObject.name.Equals("Patron Control"))
                            {
                                PatronController = item.gameObject.GetOrAddComponent<Ostinyo_World_PatronCracker>();
                            }
                        }
                        // TODO : Make the golf balls shoot fireworks on command.
                        //if (item.name.Equals("Golf Ball"))
                        //{
                        //    var editor = item.gameObject.GetOrAddComponent<PuttPuttPond_GolfBallManipulator>();
                        //    if (editor != null)
                        //    {
                        //        if (!GolfBalls.Contains(editor))
                        //        {
                        //            GolfBalls.Add(editor);
                        //        }
                        //    }
                        //}
                    }
                }
                catch { }
            }

            MiscUtils.DelayFunction(2f, () =>
            {
                ModConsole.DebugLog("Rainbow Ball Exploit!");

                RegisterBallColor(Button_Ball_White);
                RegisterBallColor(Button_Ball_Black);
                RegisterBallColor(Button_Ball_DarkGreen);
                RegisterBallColor(Button_Ball_Green);
                RegisterBallColor(Button_Ball_Yellow);
                RegisterBallColor(Button_Ball_Orange);
                RegisterBallColor(Button_Ball_Red);
                RegisterBallColor(Button_Ball_Pink);
                RegisterBallColor(Button_Ball_Purple);
                RegisterBallColor(Button_Ball_DarkBlue);
                RegisterBallColor(Button_Ball_Blue);
                RegisterBallColor(Button_Ball_Cyan);

            });

            if (PatronController != null)
            {
                if (ActivatePatronModeToggle != null) ActivatePatronModeToggle.SetToggleState(PatronController.isPatron.GetValueOrDefault(false));
            }
        }

        private static void RegisterBallColor(GameObject ballbutton)
        {
            if (ballbutton != null)
            {
                var colorinteractor = ballbutton.FindUdonEvent("_interact");
                if (colorinteractor != null)
                {
                    ModConsole.DebugLog($"Registered Interaction in {ballbutton.name} for rainbow golf ball!");
                    ColorActions.Add(colorinteractor);
                }
                else
                {
                    ModConsole.DebugLog($"Failed to find Interaction event in {ballbutton.name} for rainbow golf ball!");
                }
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.PuttPuttQuest || id == WorldIds.PuttPuttQuest_Night)
            {

                ModConsole.Log($"Recognized {Name} World, Patching Udon....");
                isPuttPuttPond = true;
                if (PuttPuttPondMenu != null)
                {
                    PuttPuttPondMenu.SetInteractable(true);
                    PuttPuttPondMenu.SetTextColor(Color.green);
                }

                FindEverything();
            }
            else
            {
                isPuttPuttPond = false;
                if (PuttPuttPondMenu != null)
                {
                    PuttPuttPondMenu.SetInteractable(false);
                    PuttPuttPondMenu.SetTextColor(Color.red);
                }
            }
        }

        // UNRELIABLE!
        //internal static PuttPuttPond_GolfBallManipulator SelfGolfball
        //{
        //    get
        //    {
        //        if (WorldUtils.WorldID != WorldIds.PuttPuttPond) return null;
        //        foreach (var item in GolfBalls)
        //        {
        //            if (item != null)
        //            {
        //                if (item.gameObject.active && item.transform.parent.gameObject.active)
        //                {
        //                    if (item.isSelf.GetValueOrDefault(false))
        //                    {
        //                        return item;
        //                    }
        //                }
        //            }
        //        }

        //        return null;
        //    }
        //}


        private static GameObject _Scene;
        internal static GameObject Scene
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (_Scene == null)
                {
                    return _Scene = GameObjectFinder.FindRootSceneObject("Scene");
                }

                return _Scene;
            }
        }

        private static GameObject _Putting_Center;
        internal static GameObject Putting_Center
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Scene == null) return null;
                if (_Putting_Center == null)
                {
                    return _Putting_Center = Scene.FindObject("Putting Center");
                }

                return _Putting_Center;
            }
        }
        private static GameObject _Ball_Color_Picker;
        internal static GameObject Ball_Color_Picker
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Putting_Center == null) return null;
                if (_Ball_Color_Picker == null)
                {
                    return _Ball_Color_Picker = Putting_Center.FindObject("Ball Color Picker");
                }

                return _Ball_Color_Picker;
            }
        }

        private static GameObject _Button_Ball_White;
        internal static GameObject Button_Ball_White
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_White == null)
                {
                    return _Button_Ball_White = Ball_Color_Picker.FindObject("Button Ball White");
                }

                return _Button_Ball_White;
            }
        }
        private static GameObject _Button_Ball_Black;
        internal static GameObject Button_Ball_Black
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Black == null)
                {
                    return _Button_Ball_Black = Ball_Color_Picker.FindObject("Button Ball Black");
                }

                return _Button_Ball_Black;
            }
        }
        private static GameObject _Button_Ball_DarkGreen;
        internal static GameObject Button_Ball_DarkGreen
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_DarkGreen == null)
                {
                    return _Button_Ball_DarkGreen = Ball_Color_Picker.FindObject("Button Ball DarkGreen");
                }

                return _Button_Ball_DarkGreen;
            }
        }
        private static GameObject _Button_Ball_Green;
        internal static GameObject Button_Ball_Green
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Green == null)
                {
                    return _Button_Ball_Green = Ball_Color_Picker.FindObject("Button Ball Green");
                }

                return _Button_Ball_Green;
            }
        }
        private static GameObject _Button_Ball_Yellow;
        internal static GameObject Button_Ball_Yellow
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Yellow == null)
                {
                    return _Button_Ball_Yellow = Ball_Color_Picker.FindObject("Button Ball Yellow");
                }

                return _Button_Ball_Yellow;
            }
        }
        private static GameObject _Button_Ball_Orange;
        internal static GameObject Button_Ball_Orange
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Orange == null)
                {
                    return _Button_Ball_Orange = Ball_Color_Picker.FindObject("Button Ball Orange");
                }

                return _Button_Ball_Orange;
            }
        }
        private static GameObject _Button_Ball_Red;
        internal static GameObject Button_Ball_Red
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Red == null)
                {
                    return _Button_Ball_Red = Ball_Color_Picker.FindObject("Button Ball Red");
                }

                return _Button_Ball_Red;
            }
        }
        private static GameObject _Button_Ball_Pink;
        internal static GameObject Button_Ball_Pink
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Pink == null)
                {
                    return _Button_Ball_Pink = Ball_Color_Picker.FindObject("Button Ball Pink");
                }

                return _Button_Ball_Pink;
            }
        }
        private static GameObject _Button_Ball_Purple;
        internal static GameObject Button_Ball_Purple
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Purple == null)
                {
                    return _Button_Ball_Purple = Ball_Color_Picker.FindObject("Button Ball Purple");
                }

                return _Button_Ball_Purple;
            }
        }
        private static GameObject _Button_Ball_DarkBlue;
        internal static GameObject Button_Ball_DarkBlue
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_DarkBlue == null)
                {
                    return _Button_Ball_DarkBlue = Ball_Color_Picker.FindObject("Button Ball DarkBlue");
                }

                return _Button_Ball_DarkBlue;
            }
        }
        private static GameObject _Button_Ball_Blue;
        internal static GameObject Button_Ball_Blue
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Blue == null)
                {
                    return _Button_Ball_Blue = Ball_Color_Picker.FindObject("Button Ball Blue");
                }

                return _Button_Ball_Blue;
            }
        }
        private static GameObject _Button_Ball_Cyan;
        internal static GameObject Button_Ball_Cyan
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Ball_Color_Picker == null) return null;
                if (_Button_Ball_Cyan == null)
                {
                    return _Button_Ball_Cyan = Ball_Color_Picker.FindObject("Button Ball Cyan");
                }

                return _Button_Ball_Cyan;
            }
        }

        internal override void OnRoomLeft()
        {
            PatronController = null;
            RainbowBall = false;
            ColorActions.Clear();
        }

        private static IEnumerator RainbowBallLoop()
        {
            for (; ; )
            {
                if (!isPuttPuttPond)
                {
                    RainbowBall = false;
                    yield break;
                }

                foreach (var udon in ColorActions)
                {
                    udon?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.05f);
                }

                if (RainbowBall)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    yield break;
                }
            }
        }

        private static bool isPuttPuttPond { get; set; } = false;
        private static object RainbowBallRoutine { get; set; }
        private static bool _RainbowBall { get; set; } = false;
        internal static bool RainbowBall
        {
            get
            {
                return _RainbowBall;
            }
            set
            {
                _RainbowBall = value;
                if (ActivateRainbowBallToggle != null)
                {
                    ActivateRainbowBallToggle.SetToggleState(value);
                }

                if (value)
                {
                    if (RainbowBallRoutine == null)
                    {
                        RainbowBallRoutine = MelonCoroutines.Start(RainbowBallLoop());
                    }
                }
                else
                {
                    if (RainbowBallRoutine != null)
                    {
                        MelonCoroutines.Stop(RainbowBallRoutine);
                    }

                    RainbowBallRoutine = null;
                }
            }
        }

        internal static Ostinyo_World_PatronCracker PatronController { get; set; }

        internal static QMNestedGridMenu PuttPuttPondMenu { get; set; }
        internal static QMToggleButton ActivatePatronModeToggle { get; set; }
        internal static QMToggleButton ActivateRainbowBallToggle { get; set; }

        private static List<UdonBehaviour_Cached> ColorActions = new List<UdonBehaviour_Cached>();

    }
}