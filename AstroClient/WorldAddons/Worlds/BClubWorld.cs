using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using AstroClient.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC.SDKBase;
using AstroClient.extensions;
using VRC.Udon;
using static AstroClient.variables.CustomLists;

namespace AstroClient
{
    public class BClubWorld : Overridables
    {
        public override void OnWorldReveal()
        {
            if(WorldUtils.GetWorldID() == WorldIds.BClub)
            {


                ModConsole.Log("Recognized " + WorldUtils.GetWorldName() + " World!");

                ModConsole.Log("Searching for Private Rooms Exteriors...");

                CreateButtonGroup(1, new Vector3(-84.66739f, 15.92832f, -0.3096771f), new Quaternion(-0.5241396f, -0.4620785f, -0.5343743f, -0.4756105f));
                CreateButtonGroup(2, new Vector3(-83.13092f, 15.94455f, -4.310131f),  new Quaternion(0.5096976f, 0.4497673f, -0.5503947f, -0.4847511f));
                CreateButtonGroup(3, new Vector3(-76.66214f, 15.96891f, -0.2979507f), new Quaternion(0.5298369f, 0.4824114f, 0.5115112f, 0.4742453f));

                CreateButtonGroup(4, new Vector3(-75.11559f, 15.92268f, -4.314186f), new Quaternion(0.5099828f, 0.4617184f, -0.5431892f, -0.4813308f));
                CreateButtonGroup(5, new Vector3(-68.67709f, 15.94213f, -0.3036766f), new Quaternion(0.5483611f, 0.4571108f, 0.5301241f, 0.4575135f));
                CreateButtonGroup(6, new Vector3(-67.13814f, 15.9624f, -4.320908f), new Quaternion(0.5246134f, 0.4534206f, -0.5460359f, -0.4701442f));


            }
        }

        public override void OnLevelLoaded()
        {
        }

        private GameObject CreateButtonGroup(int doorID, Vector3 position, Quaternion rotation)
        {
            var room = GameObjectFinder.Find($"nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance {doorID}");
            var room_BedroomPreview = GameObjectFinder.Find($"/Bedrooms/Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
            var room_ToggleLooking = GameObjectFinder.Find($"/Bedrooms/Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
            var room_ToggleLock = GameObjectFinder.Find($"/Bedrooms/Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
            var room_ToggleIncognito = GameObjectFinder.Find($"/Bedrooms/Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
            var room_DND = GameObjectFinder.Find($"/Bedrooms/Bedroom {doorID}/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

            GameObject buttonGroup = new GameObject(); // Removed primitive sphere as is not needed unless debug.
            buttonGroup.transform.SetParent(room.transform);
            //buttonGroup.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Just so I can see where the parent is for now
            buttonGroup.transform.position = position;
            buttonGroup.transform.rotation = rotation;
            buttonGroup.transform.position += new Vector3(0, 0.02f, 0);
            buttonGroup.AddToWorldUtilsMenu();
            buttonGroup.RenameObject($"ButtonGroup {doorID}");
            //buttonGroup.enablecolliders();
            //buttonGroup.ForcePickupComponent();
            //buttonGroup.SetPickupable(true);

            // add buttons
            if (room_BedroomPreview != null && room_ToggleLooking != null && room_ToggleLock != null && room_ToggleIncognito != null && room_DND != null)
            {
                ModConsole.Log($"Found all Private Room {doorID} Buttons!");

                if (room_BedroomPreview != null)
                {
                    var clone = room_BedroomPreview.InstantiateObject();
                    if (clone != null)
                    {
                        clone.transform.SetParent(buttonGroup.transform);
                        clone.transform.position = buttonGroup.transform.position;
                        clone.transform.localPosition += new Vector3(-2, 0f, 0f);
                        clone.AddToWorldUtilsMenu();
                        clone.RenameObject($"Intercom {doorID}");

                        var udonEvent = UdonSearch.FindUdonEvent("PhotozoneMaster", $"EnableIntercomIn{doorID}");
                        Action action = () => { udonEvent.ExecuteUdonEvent(); };
                        clone.AddAstroInteractable(action);
                    }
                }
                if (room_ToggleLooking != null)
                {
                    var clone = room_ToggleLooking.InstantiateObject();
                    if (clone != null)
                    {
                        clone.transform.SetParent(buttonGroup.transform);
                        clone.transform.position = buttonGroup.transform.position;
                        clone.transform.localPosition += new Vector3(-2f, 0f, 2f);
                        clone.AddToWorldUtilsMenu();
                        clone.RenameObject($"Looking {doorID}");

                        var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleLooking{doorID}");
                        Action action = () => { udonEvent.ExecuteUdonEvent(); };
                        clone.AddAstroInteractable(action);
                    }
                }
                if (room_ToggleLock != null)
                {
                    var clone = room_ToggleLock.InstantiateObject();
                    if (clone != null)
                    {
                        clone.transform.SetParent(buttonGroup.transform);
                        clone.transform.position = buttonGroup.transform.position;
                        clone.transform.localPosition += new Vector3(0f, 0f, 2f);
                        clone.AddToWorldUtilsMenu();
                        clone.RenameObject($"Lock {doorID}");

                        var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleLock{doorID}");
                        Action action = () => { udonEvent.ExecuteUdonEvent(); };
                        clone.AddAstroInteractable(action);
                    }
                }
                if (room_ToggleIncognito != null)
                {
                    var clone = room_ToggleIncognito.InstantiateObject();
                    if (clone != null)
                    {
                        clone.transform.SetParent(buttonGroup.transform);
                        clone.transform.position = buttonGroup.transform.position;
                        clone.transform.localPosition += new Vector3(0f, 0f, 0f);
                        clone.AddToWorldUtilsMenu();
                        clone.RenameObject($"Incognito {doorID}");

                        var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleAnon{doorID}");
                        Action action = () => { udonEvent.ExecuteUdonEvent(); };
                        clone.AddAstroInteractable(action);
                    }
                }
                if (room_DND != null)
                {
                    var clone = room_DND.InstantiateObject();
                    if (clone != null)
                    {
                        clone.transform.SetParent(buttonGroup.transform);
                        clone.transform.position = buttonGroup.transform.position;
                        clone.transform.localPosition += new Vector3(2f, 0f, 0f);
                        clone.transform.rotation = new Quaternion(0f, 272f, 90f, 0f);

                        clone.AddToWorldUtilsMenu();
                        clone.RenameObject($"Do Not Disturb {doorID}");

                        var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleDoorbell{doorID}");
                        Action action = () => { udonEvent.ExecuteUdonEvent(); };
                        clone.AddAstroInteractable(action);
                    }
                }
            }

            return buttonGroup;
        }
    }
}
