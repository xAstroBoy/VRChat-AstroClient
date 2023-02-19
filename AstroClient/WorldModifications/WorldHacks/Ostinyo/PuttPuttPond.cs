using System.Collections;
using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Cheats.PatronCrackers;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.World;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using UnityEngine;

namespace AstroClient.WorldModifications.WorldHacks.Ostinyo
{
    internal class PuttPuttPond : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
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


        internal static void InitButtons(QMGridTab main)
        {
            PuttPuttPondMenu = new QMNestedGridMenu(main, "PuttPuttPond Exploits", "PuttPuttPond Exploits");
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
            foreach (var item in WorldUtils_Old.Get_UdonBehaviours())
            {
                try
                {
                    if (item != null)
                    {
                        if (PatronController == null)
                        {
                            if (item.name.Equals("Patron Control"))
                            {
                                PatronController = ComponentUtils.GetOrAddComponent<Ostinyo_World_PatronCracker>(item.gameObject);
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
                Log.Debug("Rainbow Ball Exploit!");

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
                    Log.Debug($"Registered Interaction in {ballbutton.name} for rainbow golf ball!");
                    ColorActions.Add(colorinteractor);
                }
                else
                {
                    Log.Debug($"Failed to find Interaction event in {ballbutton.name} for rainbow golf ball!");
                }
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.PuttPuttPond)
            {

                Log.Write($"Recognized {Name} World, Patching Udon....");
                isPuttPuttPond = true;
                if (PuttPuttPondMenu != null)
                {
                    PuttPuttPondMenu.SetInteractable(true);
                    PuttPuttPondMenu.SetTextColor(Color.green);
                }

                FindEverything();
                HasSubscribed = true;
            }
            else
            {
                isPuttPuttPond = false;
                if (PuttPuttPondMenu != null)
                {
                    PuttPuttPondMenu.SetInteractable(false);
                    PuttPuttPondMenu.SetTextColor(Color.red);
                }
                HasSubscribed = false;
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

        private static GameObject _SpawnArea;
        internal static GameObject SpawnArea
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (_SpawnArea == null)
                {
                    return _SpawnArea = Finder.FindRootSceneObject("Spawn Area");
                }

                return _SpawnArea;
            }
        }
        private static GameObject _Booths;
        internal static GameObject Booths
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (SpawnArea == null) return null;
                if (_Booths == null)
                {
                    return _Booths = SpawnArea.FindObject("Booths");
                }

                return _Booths;
            }
        }

        private static GameObject _Putting_Booth;
        internal static GameObject Putting_Booth
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Booths == null) return null;
                if (_Putting_Booth == null)
                {
                    return _Putting_Booth = Booths.FindObject("Putting Booth");
                }

                return _Putting_Booth;
            }
        }
        private static GameObject _Ball_Color_Picker;
        internal static GameObject Ball_Color_Picker
        {
            get
            {
                if (!isPuttPuttPond) return null;
                if (Putting_Booth == null) return null;
                if (_Ball_Color_Picker == null)
                {
                    return _Ball_Color_Picker = Putting_Booth.FindObject("Ball Color Picker");
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

        private void OnRoomLeft()
        {
            PatronController = null;
            RainbowBall = false;
            ColorActions.Clear();
            HasSubscribed = false;
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
                    udon?.Invoke();
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