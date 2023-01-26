using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
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
        private static string[] Trash = new[]
{
            "fuck you kill cube",
            "fuck you kill cube (1)",
            "fuck you kill cube",
            "fuck you kill cube",
            "fuck you kill cube",
            "fuck you kill cube",
        };

        private static string[] ButtonsToActivate = new[]
        {
            "SSOS_Room/Room Menu Inner/Canvas/Panel Main/Layout/DoNotDisturb",
            "SSOS_Room/Room Menu Inner/Canvas/Panel Main/Layout/KickEveryone",
            "SSOS_Room/Room Menu Inner/Canvas/Panel Main/Layout/LockToggle",
            "SSOS_Room/Room Menu Inner/Canvas/Panel Main/Layout/JoinRequests",
            "SSOS_Room (1)/Room Menu Inner/Canvas/Panel Main/Layout/DoNotDisturb",
            "SSOS_Room (1)/Room Menu Inner/Canvas/Panel Main/Layout/KickEveryone",
            "SSOS_Room (1)/Room Menu Inner/Canvas/Panel Main/Layout/JoinRequests",
            "SSOS_Room (1)/Room Menu Inner/Canvas/Panel Main/Layout/LockToggle",
            "SSOS_Room (2)/Room Menu Inner/Canvas/Panel Main/Layout/DoNotDisturb",
            "SSOS_Room (2)/Room Menu Inner/Canvas/Panel Main/Layout/JoinRequests",
            "SSOS_Room (2)/Room Menu Inner/Canvas/Panel Main/Layout/LockToggle",
            "SSOS_Room (2)/Room Menu Inner/Canvas/Panel Main/Layout/KickEveryone",
        };


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
                            GameInstances.LocalPlayer.TeleportTo(OuterDoorTp.transform.position, OuterDoorTp.transform.rotation);
                        };
                    }

                }
            }
        }

        private void PatchWorld()
        {
            foreach (var path in Trash)
            {
                var obj = Finder.Find(path);
                if (obj != null)
                {
                    obj.DestroyMeLocal();
                }
            }

            foreach (var path in ButtonsToActivate)
            {
                var obj = Finder.Find(path);
                if (obj != null)
                {
                    foreach(var item in obj.GetComponents<Button>())
                    {
                        if(item != null)
                        {
                            item.interactable = true;
                        }
                    }
                }
            }
            var Main_NonPatronsPage = Finder.Find("SSOS/SSOS_Main_Tablet/Main_Canvas/Main_Panel (Add section here)/Section_NoPatreon");
            var Main_PatronPage = Finder.Find("SSOS/SSOS_Main_Tablet/Main_Canvas/Main_Panel (Add section here)/Section Patreon");
            if(Main_NonPatronsPage != null)
            {
                Main_NonPatronsPage.DestroyChildren(); // remove the blank stuff inside.
                var Patron_Canvas = Main_PatronPage.FindObject("Layout (Add Buttons here)");
                var Clone = Object.Instantiate(Patron_Canvas, new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f)), Main_NonPatronsPage.transform);
                Clone.name = "Layout (Add Buttons here)";
                
            }

            #region Orange Room
            var OrangeRoom_Door = Finder.Find("SSOS_Room/Door Outer");
            var OrangeRoom_Room = Finder.Find("privat room (1)");
            ChangeTeleportDoor(OrangeRoom_Door, OrangeRoom_Room, "Enter <color=orange>Orange Room</color>");
            #endregion
            #region Pink Room
            var PinkRoom_Door = Finder.Find("SSOS_Room (1)/Door Outer");
            var PinkRoom_Room = Finder.Find("privat room (2)");
            ChangeTeleportDoor(PinkRoom_Door, PinkRoom_Room, "Enter <color=pink>Pink Room</color>");
            #endregion

            #region Green Room
            var GreenRoom_Door = Finder.Find("SSOS_Room (2)/Door Outer");
            var GreenRoom_Room = Finder.Find("privat room (3)");
            ChangeTeleportDoor(GreenRoom_Door, GreenRoom_Room, "Enter <color=green>Green Room</color>");
            #endregion



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