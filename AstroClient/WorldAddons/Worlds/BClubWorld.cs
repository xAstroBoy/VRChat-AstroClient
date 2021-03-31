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

                var buttonGroup = CreateButtonGroup(1, new Vector3(-68.75317f, 15.9341f, -0.3320923f), new Quaternion(0.5209573f, 0.4646181f, -0.5404834f, -0.469693f));
                //foreach (var action in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                //{
                //    if (action.name.ToLower() == "photozonemaster")
                //    {
                //        foreach (var subaction in action._eventTable)
                //        {
                //            ModConsole.Log($"Action {action.name} Contains Subaction {subaction.key}");
                //        }
                //    }

                //    if (action.name.ToLower() == "rooms info master")
                //    {
                //        foreach (var subaction in action._eventTable)
                //        {
                //            ModConsole.Log($"Action {action.name} Contains Subaction {subaction.key}");
                //        }
                //    }
                //}
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

            GameObject buttonGroup = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            buttonGroup.transform.SetParent(room.transform);
            buttonGroup.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Just so I can see where the parent is for now
            buttonGroup.transform.position = position;
            buttonGroup.transform.rotation = rotation;
            buttonGroup.transform.position += new Vector3(0, 0.02f, 0);
            buttonGroup.AddToWorldUtilsMenu();
            buttonGroup.RenameObject($"ButtonGroup {doorID}");
            buttonGroup.enablecolliders();
            buttonGroup.ForcePickupComponent();
            buttonGroup.SetPickupable(true);

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

                        Vector3 rot = clone.transform.rotation.eulerAngles;
                        rot = new Vector3(rot.x, rot.y, rot.z + 180);
                        clone.transform.rotation = Quaternion.Euler(rot);

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
