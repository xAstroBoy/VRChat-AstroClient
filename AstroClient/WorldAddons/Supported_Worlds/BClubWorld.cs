﻿namespace AstroClient
{
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using Boo.Lang.Compiler.TypeSystem;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC.Udon;

	public class BClubWorld : GameEvents
    {
		public static GameObject VIPRoom;

		public static List<Renderer> VIPHallRenderers = new List<Renderer>();

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.BClub)
            {
                try
                {
                    ModConsole.DebugLog($"Recognized {Name} World!");
                    ModConsole.DebugLog("Searching for Private Rooms Exteriors...");
                    CreateButtonGroup(1, new Vector3(-84.76529f, 15.75226f, -0.3361053f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    CreateButtonGroup(2, new Vector3(-83.04877f, 15.81609f, -4.297329f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    CreateButtonGroup(3, new Vector3(-76.76254f, 15.85877f, -0.3256264f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    CreateButtonGroup(4, new Vector3(-75.04338f, 15.79742f, -4.307182f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
                    CreateButtonGroup(5, new Vector3(-68.77336f, 15.78151f, -0.3279915f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
                    CreateButtonGroup(6, new Vector3(-67.04791f, 15.78925f, -4.3116f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));

					// nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance VIP/VIP Out Walls

					// VIP Room
					VIPRoom = GameObjectFinder.FindRootSceneObject("Bedroom VIP");

					if (VIPRoom == null)
					{
						ModConsole.Error("VIP Bedroom was not found!");
					}

					CreateVIPEntryButton(new Vector3(-54.159f, 16.0598f, -1.695f), Quaternion.Euler(0f, 90f, 0f));

					// Click stupid warning button in elevator.
					var elevatorButton = GameObjectFinder.Find("Lobby/Entrance Corridor/Udon/Warning/Enter - BlueButtonWide/Button Interactable");
					if (elevatorButton != null)
					{
						var udonComp = elevatorButton.GetComponent<UdonBehaviour>();
						if (udonComp != null)
						{
							udonComp.Interact();
						}
						else
						{
							ModConsole.Error("Elevator Button Not Found!");
						}
					}

                    RemovePrivacyBlocksOnRooms(1);
                    RemovePrivacyBlocksOnRooms(2);
                    RemovePrivacyBlocksOnRooms(3);
                    RemovePrivacyBlocksOnRooms(4);
                    RemovePrivacyBlocksOnRooms(5);
                    RemovePrivacyBlocksOnRooms(6);
                }
                catch (Exception e)
                {
                    ModConsole.DebugErrorExc(e);
                }
            }
        }

		private void CreateVIPEntryButton(Vector3 position, Quaternion rotation)
		{
			var entryPosition = new Vector3(140.9367f, -0.5667f, 0.0696f);
			var entryRotation = Quaternion.Euler(0f, 90f, 0f);

			_ = new WorldButton(position, rotation, "Enter\nVIP Room", () =>
			{
				if (VIPRoom != null)
				{
					VIPRoom.SetActive(true);
				}

				Utils.LocalPlayer.gameObject.transform.position = entryPosition;
				Utils.LocalPlayer.gameObject.transform.rotation = entryRotation;
			});
		}

        private void RemovePrivacyBlocksOnRooms(int roomid)
        {
            GameObject Bedrooms = GameObjectFinder.FindRootSceneObject("Bedrooms");
            if (Bedrooms != null)
            {
                var cover = Bedrooms.transform.FindObject($"Bedroom {roomid}/Black Covers");
                var privacy = Bedrooms.transform.FindObject($"Bedroom {roomid}/Privacy");
                if (privacy != null)
                {
                    privacy.DestroyMeLocal();
                }
                if (cover != null)
                {
                    cover.DestroyMeLocal();
                }
            }
        }

        // TODO : FIX THE UDON EVENT OR MAKE A LOCAL TELEPORT AND ENABLE THE ROOM WITH ONE BUTTON.
        private GameObject CreateButtonGroup(int doorID, Vector3 position, Quaternion rotation, bool flip = false)
        {
            GameObject nlobby = GameObjectFinder.FindRootSceneObject("nLobby");
            GameObject Bedrooms = GameObjectFinder.FindRootSceneObject("Bedrooms");

            if (nlobby != null && Bedrooms != null)
            {
                var room = nlobby.transform.FindObject($"Private Rooms Exterior/Room Entrances/Private Room Entrance {doorID}");
                var room_BedroomPreview = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                var room_ToggleLooking = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                var room_ToggleLock = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                var room_ToggleIncognito = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                var room_DND = Bedrooms.transform.FindObject($"Bedroom {doorID}/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                GameObject buttonGroup = GameObject.CreatePrimitive(PrimitiveType.Plane);
                buttonGroup.transform.SetParent(room.transform);
                buttonGroup.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Just so I can see where the parent is for now

                buttonGroup.transform.position = position;
                buttonGroup.transform.rotation = rotation;

                //buttonGroup.transform.position += new Vector3(0, 0.02f, 0);
                buttonGroup.RemoveColliders();
                buttonGroup.AddToWorldUtilsMenu();
                buttonGroup.RenameObject($"ButtonGroup {doorID}");

                buttonGroup.GetComponent<Renderer>().enabled = false;

                // add buttons
                if (room != null)
                {
                    if (room_BedroomPreview != null)
                    {
                        var clone = room_BedroomPreview.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-2.335898f, 0, -3.828288f);
                            clone.RenameObject($"Intercom {doorID}");
                            clone.AddCollider();

                            var udonEvent = UdonSearch.FindUdonEvent("PhotozoneMaster", $"EnableIntercomIn{doorID}");
                            void action() { udonEvent.ExecuteUdonEvent(); }

                            clone.gameObject.AddAstroInteractable(action);
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent != null && behaviourevent.Count() != 0)
                            {
                                foreach (var e in behaviourevent)
                                {
                                    e.DestroyMeLocal();
                                }
                            }
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
                            catch (Exception e)
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
                        var clone = room_ToggleLock.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-2.335898f, 0, -1.828288f);
                            clone.RenameObject($"Lock {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLock{doorID}");
                            void action() { udonEvent.ExecuteUdonEvent(); }
                            clone.gameObject.AddAstroInteractable(action);
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent != null && behaviourevent.Count() != 0)
                            {
                                foreach (var e in behaviourevent)
                                {
                                    e.DestroyMeLocal();
                                }
                            }
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
                        var clone = room_ToggleLooking.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-4.335898f, 0, -1.828288f);
                            clone.RenameObject($"Looking {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLooking{doorID}");
                            void action() { udonEvent.ExecuteUdonEvent(); }
                            clone.gameObject.AddAstroInteractable(action);
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent != null && behaviourevent.Count() != 0)
                            {
                                foreach (var e in behaviourevent)
                                {
                                    e.DestroyMeLocal();
                                }
                            }
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
                        var clone = room_ToggleIncognito.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-6.335898f, 0, -1.828288f);
                            clone.RenameObject($"Incognito {doorID}");
                            clone.AddCollider();

                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleAnon{doorID}");
                            void action() { udonEvent.ExecuteUdonEvent(); }
                            clone.gameObject.AddAstroInteractable(action);
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent != null && behaviourevent.Count() != 0)
                            {
                                foreach (var e in behaviourevent)
                                {
                                    e.DestroyMeLocal();
                                }
                            }

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
                        var clone = room_DND.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.SetParent(buttonGroup.transform);
                            clone.transform.position = buttonGroup.transform.position;
                            clone.transform.localPosition = new Vector3(-0.1719699f, 0, -2.196038f);
                            clone.transform.rotation = new Quaternion(0.5198629f, 0.5198629f, 0.5198629f, 0.5198629f);
                            clone.RenameObject($"Do Not Disturb {doorID}");
                            clone.AddCollider();
                            var udonEvent = UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleDoorbell{doorID}");
                            void action() { udonEvent.ExecuteUdonEvent(); }
                            clone.gameObject.AddAstroInteractable(action);
                            var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
                            if (behaviourevent != null && behaviourevent.Count() != 0)
                            {
                                foreach (var e in behaviourevent)
                                {
                                    e.DestroyMeLocal();
                                }
                            }
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
                if (nlobby == null)
                {
                    ModConsole.Error("Failed to Find NLobby!");
                }
                if (Bedrooms == null)
                {
                    ModConsole.Error("Failed to Find Bedrooms!");
                }
            }
            return null;
        }
    }
}