using System;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class SovrenChillHome : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void FindEverything()
        {
            if (SovOS_NonPatronFunction != null && SovOS_PatronFunctions != null)
            {
                //#region Replace button contents from the same buttons in patron page

                var Fake_OpenPrivateRoom = SovOS_NonPatronFunction.FindObject("OpenPrivateRoom");
                var OpenPrivateRoom = SovOS_PatronFunctions.FindObject("OpenPrivateRoom");


                if (Fake_OpenPrivateRoom != null && OpenPrivateRoom != null)
                {
                    ActivateFakeButton_TeleportToPrivateRoom(Fake_OpenPrivateRoom, OpenPrivateRoom);
                }
                var Fake_PinkRoom = SovOS_NonPatronFunction.FindObject("PinkRoom");
                var PinkRoom = SovOS_PatronFunctions.FindObject("PinkRoom");

                if (Fake_PinkRoom != null && PinkRoom != null)
                {
                    ActivateFakeButton(Fake_PinkRoom, PinkRoom);
                }


                var Fake_GreenRoom = SovOS_NonPatronFunction.FindObject("GreenRoom");
                var GreenRoom = SovOS_PatronFunctions.FindObject("GreenRoom");
                if (Fake_GreenRoom != null && GreenRoom != null)
                {
                    ActivateFakeButton(Fake_GreenRoom, GreenRoom);
                }

                var Fake_OrangeRoom = SovOS_NonPatronFunction.FindObject("OrangeRoom");
                var OrangeRoom = SovOS_PatronFunctions.FindObject("OrangeRoom");

                if (Fake_OrangeRoom != null && OrangeRoom != null)
                {
                    ActivateFakeButton(Fake_OrangeRoom, OrangeRoom);
                }
            }

            var PinkRoomDoor_DNDBtnObj = Finder.Find("PinkRoomDoor/Inside/UI/Do Not Disturb Button");
            if (PinkRoomDoor_DNDBtnObj != null)
            {
                var toggle = PinkRoomDoor_DNDBtnObj.GetComponent<UnityEngine.UI.Toggle>();
                if (toggle != null)
                {
                    toggle.enabled = true;
                }

            }
            var PinkRoomDoor_LockToggle = Finder.Find("PinkRoomDoor/Inside/UI/Toggle");
            if (PinkRoomDoor_LockToggle != null)
            {
                var toggle = PinkRoomDoor_LockToggle.GetComponent<UnityEngine.UI.Toggle>();
                if (toggle != null)
                {
                    toggle.enabled = true;
                }
            }


            var OrangeRoomDoor_DNDBtnObj = Finder.Find("OrangeRoomDoor/Inside/UI/Do Not Disturb Button");
            if (OrangeRoomDoor_DNDBtnObj != null)
            {
                var toggle = OrangeRoomDoor_DNDBtnObj.GetComponent<UnityEngine.UI.Toggle>();
                if (toggle != null)
                {
                    toggle.enabled = true;
                }

            }
            var OrangeRoomDoor_LockToggle = Finder.Find("OrangeRoomDoor/Inside/UI/Toggle");
            if (OrangeRoomDoor_LockToggle != null)
            {
                var toggle = OrangeRoomDoor_LockToggle.GetComponent<UnityEngine.UI.Toggle>();
                if (toggle != null)
                {
                    toggle.enabled = true;
                }
            }

            var GreenRoomDoor_DNDBtnObj = Finder.Find("GreenRoomDoor/Inside/UI/Do Not Disturb Button");
            if (GreenRoomDoor_DNDBtnObj != null)
            {
                var toggle = GreenRoomDoor_DNDBtnObj.GetComponent<UnityEngine.UI.Toggle>();
                if (toggle != null)
                {
                    toggle.enabled = true;
                }

            }
            var GreenRoomDoor_LockToggle = Finder.Find("GreenRoomDoor/Inside/UI/Toggle");
            if (GreenRoomDoor_LockToggle != null)
            {
                var toggle = GreenRoomDoor_LockToggle.GetComponent<UnityEngine.UI.Toggle>();
                if (toggle != null)
                {
                    toggle.enabled = true;
                }
            }

        }


        private void ActivateFakeButton(Transform FakeButtonRoot, Transform RealButtonRoot)
        {
            if (FakeButtonRoot == null || RealButtonRoot == null)
            {
                return;
            }
            var Fake_TP = FakeButtonRoot.FindObject("TP");
            var Real_TP = RealButtonRoot.FindObject("TP");
            if (Fake_TP != null && Real_TP != null) 
            {
                var Fake_Button = Fake_TP.GetComponent<Button>();
                var Real_Button = Real_TP.GetComponent<Button>();
                if (Fake_Button != null && Real_Button != null)
                {
                    Fake_Button.interactable = true;
                    Fake_Button.onClick = new Button.ButtonClickedEvent();
                    Fake_Button.onClick.AddListener(new Action(() => { Real_Button.onClick.Invoke(); }));
                }


            }
        }
        private void ActivateFakeButton_TeleportToPrivateRoom(Transform FakeButtonRoot, Transform RealButtonRoot)
        {
            if (FakeButtonRoot == null || RealButtonRoot == null)
            {
                return;
            }
            var Fake_TP = FakeButtonRoot.FindObject("Button");
            var Real_TP = RealButtonRoot.FindObject("Button");
            if (Fake_TP != null && Real_TP != null)
            {
                var Fake_Button = Fake_TP.GetComponent<Button>();
                var Real_Button = Real_TP.GetComponent<Button>();
                if (Fake_Button != null && Real_Button != null)
                {
                    Fake_Button.interactable = true;
                    Fake_Button.onClick = new Button.ButtonClickedEvent();
                    Fake_Button.onClick.AddListener(new Action(() => { Real_Button.onClick.Invoke(); }));
                    var TextObj = Fake_TP.FindObject("Text (TMP)");
                    if (TextObj != null)
                    {
                        var Text = TextObj.GetComponent<TMPro.TextMeshProUGUI>();
                        if (Text != null)
                        {
                            Text.text = "Teleport";
                        }
                    }
                }


            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.SovrenChillHome))
            {

                isCurrentWorld = true;
                FindEverything(); 
            }
            else
            {
                isCurrentWorld = false;
            }
        }

        private static Transform _SovOS;
        internal static Transform SovOS
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_SovOS == null)
                {
                    _SovOS = Finder.Find("SovOS").transform;
                }
                return _SovOS;
            }
        }
        private static Transform _SovOS_Canvas;
        internal static Transform SovOS_Canvas
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (SovOS == null) return null;
                if (_SovOS_Canvas == null)
                {
                    _SovOS_Canvas = SovOS.FindObject("Canvas");
                }
                return _SovOS_Canvas;
            }
        }

        private static Transform _SovOS_Panel;
        internal static Transform SovOS_Panel
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (SovOS_Canvas == null) return null;
                if (_SovOS_Panel == null)
                {
                    _SovOS_Panel = SovOS_Canvas.FindObject("Panel");
                }
                return _SovOS_Panel;
            }
        }

        private static Transform _SovOS_PatronPage;
        internal static Transform SovOS_PatronPage
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (SovOS_Panel == null) return null;
                if (_SovOS_PatronPage == null)
                {
                    _SovOS_PatronPage = SovOS_Panel.FindObject("PatronPage");
                }
                return _SovOS_PatronPage;
            }
        }

        private static Transform _SovOS_NonPatronFunction;
        internal static Transform SovOS_NonPatronFunction
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (SovOS_PatronPage == null) return null;
                if (_SovOS_NonPatronFunction == null)
                {
                    _SovOS_NonPatronFunction = SovOS_PatronPage.FindObject("NonPatronPatronFunction");
                }
                return _SovOS_NonPatronFunction;
            }
        }
        private static Transform _SovOS_PatronFunctions;
        internal static Transform SovOS_PatronFunctions
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (SovOS_PatronPage == null) return null;
                if (_SovOS_PatronFunctions == null)
                {
                    _SovOS_PatronFunctions = SovOS_PatronPage.FindObject("Body");
                }
                return _SovOS_PatronFunctions;
            }
        }


        private static bool isCurrentWorld = false;
    }
}