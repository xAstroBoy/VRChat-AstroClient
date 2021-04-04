using AstroClient.ConsoleUtils;
using AstroClient.Variables;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using AstroClient.extensions;
using VRCSDK2;
using AstroClient.Finder;

namespace AstroClient
{
    public class BClubWorld : Overridables
    {
        public static void CloneTriggerToObject(GameObject OrigObj, GameObject DisplayObj, string InteractText)
        {
            try
            {
                var DeleteTrigger = DisplayObj.GetComponent<VRC_Trigger>();
                var WorkingTrigger = OrigObj.GetComponent<VRC_Trigger>();
                VRC_Trigger Cloned_trigger = null;

                if (DeleteTrigger != null)
                {
                    DeleteTrigger.DestroyMeLocal();
                }
                if (WorkingTrigger != null)
                {
                    Cloned_trigger = DisplayObj.AddComponent<VRC_Trigger>().GetCopyOf(WorkingTrigger);
                    if (Cloned_trigger != null)
                    {
                        Cloned_trigger.interactText = "[AstroClient]: " + InteractText;
                    }
                }
                if (Cloned_trigger != null)
                {
                    DisplayObj.AddCollider();
                    ModConsole.Log($"Added Successfully {InteractText}");
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
        }


        public override void OnWorldReveal()
        {
            if(WorldUtils.GetWorldID() == WorldIds.BClub)
            {
                try
                {
                    ModConsole.Log("Recognized BClub World!");
                    ModConsole.Log("Searching for Private Rooms Exteriors...");
                    CreateButtonGroup(1, new Vector3(-84.76529f, 15.75226f, -0.3361053f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    CreateButtonGroup(2, new Vector3(-83.04877f, 15.81609f, -4.297329f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    CreateButtonGroup(3, new Vector3(-76.76254f, 15.85877f, -0.3256264f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    CreateButtonGroup(4, new Vector3(-75.04338f, 15.79742f, -4.307182f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    CreateButtonGroup(5, new Vector3(-68.77336f, 15.78151f, -0.3279915f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    CreateButtonGroup(6, new Vector3(-67.04791f, 15.78925f, -4.3116f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));

                    // Remove stupid warning in elevator.
                    var warning = GameObjectFinder.Find("Lobby/Warning");
                    if (warning != null)
                    {
                        warning.SetActive(false);
                    }
                } catch (Exception e)
                {
                    ModConsole.DebugErrorExc(e);
                }
            }
        }

        private GameObject CreateButtonGroup(int doorID, Vector3 position, Quaternion rotation, bool flip = false)
        {
            GameObject nlobby = SceneManager.GetActiveScene().GetRootGameObjects().Where(x => x.gameObject.name == "nLobby").First();
            GameObject Bedrooms = SceneManager.GetActiveScene().GetRootGameObjects().Where(x => x.gameObject.name == "Bedrooms").First();
            if (nlobby != null && Bedrooms != null)
            {
                ModConsole.Log("Found nlobby and Bedrooms!");


                var room = nlobby.transform.Find($"Private Rooms Exterior/Room Entrances/Private Room Entrance {doorID}");
                var room_BedroomPreview = Bedrooms.transform.Find($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                var room_ToggleLooking = Bedrooms.transform.Find($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                var room_ToggleLock = Bedrooms.transform.Find($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                var room_ToggleIncognito = Bedrooms.transform.Find($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                var room_DND = Bedrooms.transform.Find($"Bedroom {doorID}/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");


                GameObject buttonGroup = GameObject.CreatePrimitive(PrimitiveType.Plane);
                buttonGroup.transform.SetParent(room.transform);
                buttonGroup.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Just so I can see where the parent is for now

                buttonGroup.transform.position = position;
                buttonGroup.transform.rotation = rotation;

                //buttonGroup.transform.position += new Vector3(0, 0.02f, 0);
                buttonGroup.removeColliders();
                buttonGroup.AddToWorldUtilsMenu();
                buttonGroup.RenameObject($"ButtonGroup {doorID}");

                buttonGroup.GetComponent<Renderer>().enabled = false;

                // add buttons
                if (room != null)
                {
                    ModConsole.Log($"Found all Private Room {doorID} Buttons!");

                    if (room_BedroomPreview != null)
                    {
                        //ModConsole.DebugLog("Found Bedroom Preview Button!, spawning..");
                        var clone = room_BedroomPreview.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-2.335898f, 0, -3.828288f);
                            clone.RenameObject($"Intercom {doorID}");
                            clone.AddCollider();

                            var udonEvent = UdonSearch.FindUdonEvent("PhotozoneMaster", $"EnableIntercomIn{doorID}");
                            Action action = () => { udonEvent.ExecuteUdonEvent(); };


                            clone.gameObject.AddAstroInteractable(action);
                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable";
                                var TriggerComponent = clone.transform.Find(path);
                                if (TriggerComponent != null)
                                {
                                    
                                    TriggerComponent.gameObject.AddAstroInteractable(action);
                                    TriggerComponent.gameObject.RenameObject($"Intercom {doorID} - Trigger");
                                }
                            }
                            catch(Exception e)
                            {
                                ModConsole.DebugWarningExc(e);
                            }

                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find Bedroom Preview Button!");
                    }

                    if (room_ToggleLock != null)
                    {
                        //ModConsole.DebugLog("Found Bedroom Toggle Lock Button!, spawning..");
                        var clone = room_ToggleLock.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-2.335898f, 0, -1.828288f);
                            clone.RenameObject($"Lock {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleLock{doorID}");
                            Action action = () => { udonEvent.ExecuteUdonEvent(); };
                            clone.gameObject.AddAstroInteractable(action);

                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable - Toggle Lock";
                                var TriggerComponent = clone.transform.Find(path);
                                if (TriggerComponent != null)
                                {
                                    TriggerComponent.gameObject.AddAstroInteractable(action);
                                    TriggerComponent.gameObject.RenameObject($"Lock {doorID} - Trigger");
                                }
                            }
                            catch (Exception e)
                            {
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find Bedroom Toggle Lock Button!");
                    }

                    if (room_ToggleLooking != null)
                    {
                        //ModConsole.DebugLog("Found Bedroom Toggle Looking Button!, spawning..");

                        var clone = room_ToggleLooking.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-4.335898f, 0, -1.828288f);
                            clone.RenameObject($"Looking {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleLooking{doorID}");
                            Action action = () => { udonEvent.ExecuteUdonEvent(); };
                            clone.gameObject.AddAstroInteractable(action);

                            clone.AddToWorldUtilsMenu();

                            try
                            {

                                string path = "Button Interactable - Looking";
                                var TriggerComponent = clone.transform.Find(path);
                                if (TriggerComponent != null)
                                {
                                    TriggerComponent.gameObject.AddAstroInteractable(action);
                                    TriggerComponent.gameObject.RenameObject($"Looking {doorID} - Trigger");
                                }
                            }
                            catch (Exception e)
                            {
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find Bedroom Toggle Looking Button!");
                    }



                    if (room_ToggleIncognito != null)
                    {
                        //ModConsole.DebugLog("Found Bedroom Toggle Incognito Button!, spawning..");

                        var clone = room_ToggleIncognito.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-6.335898f, 0, -1.828288f);
                            clone.RenameObject($"Incognito {doorID}");
                            clone.AddCollider();

                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleAnon{doorID}");
                            Action action = () => { udonEvent.ExecuteUdonEvent(); };
                            clone.gameObject.AddAstroInteractable(action);


                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable - Anon";
                                var TriggerComponent = clone.transform.Find(path);
                                if (TriggerComponent != null)
                                {
                                    TriggerComponent.gameObject.AddAstroInteractable(action);
                                    TriggerComponent.gameObject.RenameObject($"Incognito {doorID} - Trigger");
                                }
                            }
                            catch (Exception e)
                            {
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                        else
                        {
                            ModConsole.DebugWarning("Failed to find Bedroom Incognito Button!");
                        }
                    }
                    if (room_DND != null)
                    {
                        //ModConsole.DebugLog("Found Bedroom Toggle Do Not Disturb Button!, spawning..");
                        var clone = room_DND.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-0.1719699f, 0, -2.196038f);
                            clone.transform.rotation = new Quaternion(0.5198629f, 0.5198629f, 0.5198629f, 0.5198629f);
                            clone.RenameObject($"Do Not Disturb {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"ToggleDoorbell{doorID}");
                            Action action = () => { udonEvent.ExecuteUdonEvent(); };
                            clone.gameObject.AddAstroInteractable(action);

                            clone.AddToWorldUtilsMenu();
                            try
                            {
                                string path = "Button Interactable DND";
                                var TriggerComponent = clone.transform.Find(path);
                                if (TriggerComponent != null)
                                {
                                    TriggerComponent.gameObject.AddAstroInteractable(action);
                                    TriggerComponent.gameObject.RenameObject($"Do Not Disturb {doorID} - Trigger");
                                }
                            }
                            catch (Exception e)
                            {
                                ModConsole.DebugWarningExc(e);
                            }
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning("Failed to find  Bedroom Toggle Do Not Disturb Button!");
                    }
                }

                if (flip)
                {
                    buttonGroup.transform.eulerAngles += new Vector3(0, 180, 0);
                }

                return buttonGroup;
            }
            else
            {
                if(nlobby == null)
                {
                    ModConsole.Error("Failed to Find NLobby!");
                }
                if(Bedrooms == null)
                {
                    ModConsole.Error("Failed to Find Bedrooms!");
                }

            }
            return null;
        }
    }
}
