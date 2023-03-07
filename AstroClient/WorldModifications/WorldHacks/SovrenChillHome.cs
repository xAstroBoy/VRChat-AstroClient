
using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.Tools.Colors;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.UIPaths;
using AstroClient.xAstroBoy.Utility;
using Mono.CSharp;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    // TODO: update (patreon bypass doesn't work)
    // Possibly update and changes.

    internal class SovrenChillHome : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }




        public static void ChangeTeleportDoor(GameObject Outer, GameObject Room, string InteractText)
        {
            if (Outer != null && Room != null)
            {
                var OuterDoorTp = Outer.FindObject("Teleport Target");
                if (OuterDoorTp != null)
                {
                    // remove the original patron locked behaviour.
                    Outer.RemoveComponents<UdonBehaviour>();
                    // Replace the current behaviour with a trigger that skips all the patron crap
                    var AstroTrigger = Outer.AddComponent<VRC_AstroInteract>();
                    if (AstroTrigger != null)
                    {
                        AstroTrigger.interactText = InteractText;
                        AstroTrigger.OnInteract += () =>
                        {
                            Room.SetActive(true);
                            GameInstances.LocalPlayer.TeleportTo(OuterDoorTp);
                        };
                    }

                }
            }
        }

        private void PatchWorld()
        {
            PlayerCameraEditor.PlayerCamera.farClipPlane = 50000;
            foreach (var item in Finder.RootSceneObjects_WithoutAvatars)
            {
                if (item.name.Contains("fuck you kill cube"))
                {
                    item.DestroyMeLocal();
                }
            }

            var Main_NonPatronsPage = Finder.Find("SSOS/SSOS_Main_Tablet/Main_Canvas/Main_Panel (Add section here)/Section_NoPatreon");
            var Main_PatronPage = Finder.Find("SSOS/SSOS_Main_Tablet/Main_Canvas/Main_Panel (Add section here)/Section Patreon");
            if (Main_NonPatronsPage != null)
            {
                var listener = Main_NonPatronsPage.GetOrAddComponent<GameObjectListener>();
                if(listener != null)
                {
                    // Disable this and enable the patron one
                    listener.OnEnabled += () =>
                    {
                        Main_NonPatronsPage.SetActive(false);
                        Main_PatronPage.SetActive(true);
                        // Activate Patron childs
                        foreach (var item in Main_PatronPage.GetComponentsInChildren<Button>())
                        {
                            if (item != null)
                            {
                                item.interactable = true;
                            }
                        }

                        foreach (var child1 in Main_PatronPage.Get_Childs())
                        {
                            child1.gameObject.SetActive(true);
                            foreach(var child2 in child1.Get_Childs())
                            {
                                child2.gameObject.SetActive(true);

                            }
                        }
                        // activate transform in parent 
                        

                    };
                }
                //Main_NonPatronsPage.DestroyChildren(); // remove the blank stuff inside.
                //var Patron_Canvas = Main_PatronPage.FindObject("Layout (Add Buttons here)");
                //var Clone = Object.Instantiate(Patron_Canvas, new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f)), Main_NonPatronsPage.transform);
                //Clone.name = "Layout (Add Buttons here)";

            }

            #region Orange Room
            var OrangeRoom_Door = Finder.Find("SSOS_Room (5)/Door Outer");
            var OrangeRoom_Room = Finder.Find("privat room (1)");
            if (OrangeRoom_Room != null && OrangeRoom_Door != null)
            {
                OrangeRoom_Room.GetOrAddComponent<Enabler>();
                OrangeRoom_Room.SetActive(true);
                ActivateButtons(OrangeRoom_Room);
                ChangeTeleportDoor(OrangeRoom_Door, OrangeRoom_Room, "Enter <color=orange>Orange Room</color>");
            }
            #endregion
            #region Pink Room
            var PinkRoom_Door = Finder.Find("SSOS_Room (3)/Door Outer");
            var PinkRoom_Room = Finder.Find("privat room (2)");
            if (PinkRoom_Room != null && PinkRoom_Door != null)
            {
                PinkRoom_Room.GetOrAddComponent<Enabler>();
                PinkRoom_Room.SetActive(true);
                ActivateButtons(PinkRoom_Room);
                ChangeTeleportDoor(PinkRoom_Door, PinkRoom_Room, $"Enter <color=#{ColorUtility.ToHtmlStringRGB(SystemColors.Pink)}>Pink Room</color>");
            }
            #endregion
            #region Green Room
            var GreenRoom_Door = Finder.Find("SSOS_Room (4)/Door Outer");
            var GreenRoom_Room = Finder.Find("privat room (3)");
            if (GreenRoom_Room != null && GreenRoom_Door != null)
            {
                GreenRoom_Room.GetOrAddComponent<Enabler>();
                GreenRoom_Room.SetActive(true);
                ActivateButtons(GreenRoom_Room);
                ChangeTeleportDoor(GreenRoom_Door, GreenRoom_Room, "Enter <color=green>Green Room</color>");
            }
            #endregion



        }


        private void ActivateButtons(GameObject room)
        {
            foreach(var item in room.GetComponents<Button>())
            {
                item.interactable = true;
            }
            foreach(var item in room.GetComponentsInChildren<Button>(true))
            {
                item.interactable = true;
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.SovrenChillHome))
            {

                isCurrentWorld = true;
                PatchWorld(); 
            }
            else
            {
                isCurrentWorld = false;
            }
        }

        


        private static bool isCurrentWorld = false;
    }
}