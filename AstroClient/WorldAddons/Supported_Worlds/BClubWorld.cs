﻿namespace AstroClient
{
	#region Imports

	using AstroClient.Components;
	using AstroClient.Udon;
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using AstroLibrary.Utility;
	using MelonLoader;
	using RubyButtonAPI;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC.Udon;

	#endregion

	public class BClubWorld : GameEvents
	{
		public static GameObject VIPRoom;

		public static GameObject VIPInsideDoor;

		public static QMNestedButton BClubExploitsPage;

		public static int SpamCount = 0;

		public static float DoorbellTime = 0f;

		private static QMToggleButton SpamDoorbellsToggle;

		private static bool _isDoorBellSpamEnabled;

		public static bool IsDoorbellSpamEnabled
		{
			get => _isDoorBellSpamEnabled;
			set
			{
				if (value)
				{
					if (_isDoorBellSpamEnabled)
					{
						ModConsole.Log("Doorbell Spam Already Running!");
						return;
					}
					else
					{
						ModConsole.Log("Doorbell Spam Enabled!");
						_isDoorBellSpamEnabled = true;
						SpamDoorbells();
					}
				}
				else
				{
					ModConsole.Log("Doorbell Spam Disabled!");
					_isDoorBellSpamEnabled = false;
				}
			}
		}

		public static void InitButtons(QMTabMenu main, float x, float y)
		{
			BClubExploitsPage = new QMNestedButton(main, x, y, "BClub Exploits", "BClub Exploits", null, null, null, null, true);

			// Locks
			_ = new QMSingleButton(BClubExploitsPage, 1, 0, "Toggle\nLock\n1", () => { ToggleDoor(1); }, "Toggle Door Lock");
			_ = new QMSingleButton(BClubExploitsPage, 2, 0, "Toggle\nLock\n2", () => { ToggleDoor(2); }, "Toggle Door Lock");
			_ = new QMSingleButton(BClubExploitsPage, 3, 0, "Toggle\nLock\n3", () => { ToggleDoor(3); }, "Toggle Door Lock");
			_ = new QMSingleButton(BClubExploitsPage, 4, 0, "Toggle\nLock\n4", () => { ToggleDoor(4); }, "Toggle Door Lock");
			_ = new QMSingleButton(BClubExploitsPage, 1, 1, "Toggle\nLock\n5", () => { ToggleDoor(5); }, "Toggle Door Lock");
			_ = new QMSingleButton(BClubExploitsPage, 2, 1, "Toggle\nLock\n6", () => { ToggleDoor(6); }, "Toggle Door Lock");

			// VIP
			_ = new QMSingleButton(BClubExploitsPage, 3, 2, "Enter VIP", () => { EnterVIPRoom(); }, "Enter VIP Room");

			// Spamming
			_ = new QMSingleButton(BClubExploitsPage, 5, -1, "BlueChair\nEveryone", () => { BlueChairSpam(); }, "BlueChair Spam");
			SpamDoorbellsToggle = new QMToggleButton(BClubExploitsPage, 5, 0, "Spam Doorbells", () => { IsDoorbellSpamEnabled = true; }, "Spam Doorbells", () => { IsDoorbellSpamEnabled = false; }, "Toggle Doorbell Spam");
			SpamDoorbellsToggle.SetToggleState(IsDoorbellSpamEnabled, false);
		}

		private static List<UdonBehaviour> _bells = new List<UdonBehaviour>();

		private static void SpamDoorbells()
		{
			MelonCoroutines.Start(DoDoorbellSpam());
		}

		private static IEnumerator DoDoorbellSpam()
		{
			for (; ; )
			{
				DoorbellTime += 1 * Time.deltaTime;

				if (DoorbellTime < 1000f)
				{
					yield return null;
				}
				else
				{
					DoorbellTime = 0;
				}

				foreach (var bell in _bells)
				{
					bell.FindUdonEvent("DingDong")?.ExecuteUdonEvent();
					yield return null;
				}

				if (IsDoorbellSpamEnabled)
				{
					yield return null;
				}
				else
				{
					yield break;
				}
			}
		}

		private static float BlueChairTime;

		private static void BlueChairSpam()
		{
			MelonCoroutines.Start(DoBlueChairSpam());
		}

		private static IEnumerator DoBlueChairSpam()
		{
			BlueChairTime += 1 * Time.deltaTime;

			if (BlueChairTime < 0.5f)
			{
				yield return null;
			}
			else
			{
				BlueChairTime = 0f;
			}

			for (int i = 0; i < 100; i++)
			{
				var chairs = WorldUtils.GetUdonScripts().Where(b => b.name.Contains("Chair") || b.name.Contains("Seat"));

				foreach (var chair in chairs)
				{
					chair.FindUdonEvent("Sit")?.ExecuteUdonEvent();
					yield return null;
				}
				yield return null;
			}

			yield break;
		}

		private static void ToggleDoor(int doorID)
		{
			UdonSearch.FindUdonEvent("Rooms Info Master", $"_ToggleLock{doorID}").ExecuteUdonEvent();
		}

		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			if (id == WorldIds.BClub)
			{
				_bells = WorldUtils.GetUdonScripts().Where(b => b.name == "Doorbell").ToList();
				ModConsole.Log($"Recognized {Name} World! This world has an exploit menu, and other extra goodies!");

				try
				{
					ModConsole.DebugLog("Searching for Private Rooms Exteriors...");
					CreateButtonGroup(1, new Vector3(-111.00629f, 15.75226f, -0.3361053f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
					CreateButtonGroup(2, new Vector3(-109.28977f, 15.81609f, -4.297329f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
					CreateButtonGroup(3, new Vector3(-103.00354f, 15.85877f, -0.3256264f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
					CreateButtonGroup(4, new Vector3(-101.28438f, 15.79742f, -4.307182f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));
					CreateButtonGroup(5, new Vector3(-95.01436f, 15.78151f, -0.3279915f), new Quaternion(-0.4959923f, -0.4991081f, -0.5004623f, -0.5044011f), true); // NEEDS TO BE FLIPPED
					CreateButtonGroup(6, new Vector3(-93.28891f, 15.78925f, -4.3116f), new Quaternion(-0.501132f, -0.5050993f, -0.4984204f, -0.4952965f));

					// Penthouse/Private Rooms Exterior/Room Entrances/Private Room Entrance VIP/VIP Out Walls

					// VIP Room
					VIPRoom = GameObjectFinder.FindRootSceneObject("Bedroom VIP");

					if (VIPRoom == null)
					{
						ModConsole.Error("VIP Bedroom was not found!");
					}
					else
					{
						VIPInsideDoor = VIPRoom.transform.FindObject("BedroomUdon/Door Inside/Door").gameObject;

						if (VIPInsideDoor == null)
						{
							ModConsole.Log("VIP Inside Door not found!");
						}
						else
						{
							ModConsole.Log("VIP Inside Door found..");
						}
					}

					CreateVIPEntryButton(new Vector3(-80.4f, 16.0598f, -1.695f), Quaternion.Euler(0f, 90f, 0f));

					// Click stupid warning button in elevator.
					MiscUtils.DelayFunction(5f, () =>
					{
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
								ModConsole.Error("Elevator Button's Udon Component Not Found!");
							}
						}
						else
						{
							ModConsole.Error("Elevator Button Not Found!");
						}
					});

					RemovePrivacyBlocksOnRooms(1);
					RemovePrivacyBlocksOnRooms(2);
					RemovePrivacyBlocksOnRooms(3);
					RemovePrivacyBlocksOnRooms(4);
					RemovePrivacyBlocksOnRooms(5);
					RemovePrivacyBlocksOnRooms(6);
					//PatchPatreonList();
					//PatchPatreonNode();
				}
				catch (Exception e)
				{
					ModConsole.DebugErrorExc(e);
				}
			}
		}

		private static void EnterVIPRoom()
		{
			if (VIPRoom != null)
			{
				VIPRoom.SetActive(true);
			}

			Utils.LocalPlayer.gameObject.transform.position = VIPInsideDoor.transform.position + new Vector3(0.5f, 0, 0);
			Utils.LocalPlayer.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
		}

		private void CreateVIPEntryButton(Vector3 position, Quaternion rotation)
		{
			VIPInsideDoor = VIPRoom.transform.FindObject("BedroomUdon/Door Inside/Door").gameObject;

			if (VIPInsideDoor != null)
			{
				_ = new WorldButton(position, rotation, "Enter\nVIP Room", () =>
				{
					EnterVIPRoom();
				});
			}
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
			GameObject nlobby = GameObjectFinder.FindRootSceneObject("Penthouse");
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
							var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
							if (behaviourevent != null && behaviourevent.Count() != 0)
							{
								foreach (var e in behaviourevent)
								{
									UnityEngine.Object.DestroyImmediate(e);
								}
							}
							clone.AddToWorldUtilsMenu();
							try
							{
								string path = "Button Interactable";
								var TriggerComponent = clone.transform.Find(path);
								string ObjectName = $"Toggle Intercom {doorID} - Trigger";
								string InteractionText = $"Toggle Intercom {doorID} - AstroClient";
								var RenameTrigger = clone.transform.Find(path);
								if (RenameTrigger != null)
								{
									RenameTrigger.gameObject.RenameObject(ObjectName);
								}

								var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
								if (AstroTrigger != null)
								{
									AstroTrigger.InteractText = InteractionText;
									AstroTrigger.OnInteract = action;
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
							var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
							if (behaviourevent != null && behaviourevent.Count() != 0)
							{
								foreach (var e in behaviourevent)
								{
									UnityEngine.Object.DestroyImmediate(e);
								}
							}
							clone.AddToWorldUtilsMenu();
							try
							{
								string path = "Button Interactable - Toggle Lock";
								string ObjectName = $"Toggle Lock {doorID} - Trigger";
								string InteractionText = $"Toggle Lock {doorID} - AstroClient";
								var RenameTrigger = clone.transform.Find(path);
								if (RenameTrigger != null)
								{
									RenameTrigger.gameObject.RenameObject(ObjectName);
								}

								var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
								if (AstroTrigger != null)
								{
									AstroTrigger.InteractText = InteractionText;
									AstroTrigger.OnInteract = action;
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
							var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
							if (behaviourevent != null && behaviourevent.Count() != 0)
							{
								foreach (var e in behaviourevent)
								{
									UnityEngine.Object.DestroyImmediate(e);
								}
							}
							clone.AddToWorldUtilsMenu();

							try
							{
								string path = "Button Interactable - Looking";
								string ObjectName = $"Toggle Looking For Company {doorID} - Trigger";
								string InteractionText = $"Toggle Looking For Company {doorID} - AstroClient";
								var RenameTrigger = clone.transform.Find(path);
								if (RenameTrigger != null)
								{
									RenameTrigger.gameObject.RenameObject(ObjectName);
								}

								var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
								if (AstroTrigger != null)
								{
									AstroTrigger.InteractText = InteractionText;
									AstroTrigger.OnInteract = action;
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
							var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
							if (behaviourevent != null && behaviourevent.Count() != 0)
							{
								foreach (var e in behaviourevent)
								{
									UnityEngine.Object.DestroyImmediate(e);
								}
							}

							clone.AddToWorldUtilsMenu();
							try
							{
								string path = "Button Interactable - Anon";
								string ObjectName = $"Toggle Incognito {doorID} - Trigger";
								string InteractionText = $"Toggle Incognito {doorID} - AstroClient";
								var RenameTrigger = clone.transform.Find(path);
								if (RenameTrigger != null)
								{
									RenameTrigger.gameObject.RenameObject(ObjectName);
								}

								var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
								if (AstroTrigger != null)
								{
									AstroTrigger.InteractText = InteractionText;
									AstroTrigger.OnInteract = action;
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
							var behaviourevent = clone.gameObject.GetComponentsInChildren<UdonBehaviour>();
							if (behaviourevent != null && behaviourevent.Count() != 0)
							{
								foreach (var e in behaviourevent)
								{
									UnityEngine.Object.DestroyImmediate(e);
								}
							}
							clone.AddToWorldUtilsMenu();
							try
							{
								string path = "Button Interactable DND";
								string ObjectName = $"Toggle Do Not Disturb {doorID} - Trigger";
								string InteractionText = $"Toggle Do Not Disturb {doorID} - AstroClient";
								var RenameTrigger = clone.transform.Find(path);
								if (RenameTrigger != null)
								{
									RenameTrigger.gameObject.RenameObject(ObjectName);
								}

								var AstroTrigger = clone.gameObject.AddComponent<VRC_AstroUdonTrigger>();
								if (AstroTrigger != null)
								{
									AstroTrigger.InteractText = InteractionText;
									AstroTrigger.OnInteract = action;
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
					ModConsole.Error("Failed to Find Penthouse!");
				}
				if (Bedrooms == null)
				{
					ModConsole.Error("Failed to Find Bedrooms!");
				}
			}
			return null;
		}

		private static void PatchPatreonList()
		{
			try
			{
				var patreonlist = GameObjectFinder.Find("/Udon/Patreon Lists");
				if (patreonlist != null)
				{
					var node = patreonlist.GetComponent<UdonBehaviour>();
					var disassembled = node.DisassembleUdonBehaviour();
					if (disassembled != null)
					{
						var obj_List = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("localPatrons"));
						if (obj_List != null)
						{
							var patreonstr = obj_List.Unpack_String();
							if (!patreonstr.Contains(Utils.LocalPlayer.displayName))
							{
								var modifiedpatreonstr = Utils.LocalPlayer.displayName + Environment.NewLine + patreonstr.Skip(1);

								UdonHeapEditor.PatchHeap(disassembled, "localPatrons", modifiedpatreonstr, true);
							}
						}
					}
					node.InitializeUdonContent();
					node.Start();
				}
			}
			catch (Exception e)
			{
				ModConsole.ErrorExc(e);
			}
		}

		private static void PatchPatreonNode()
		{
				var patreonlist = GameObjectFinder.Find("Udon/Patreon");
				if (patreonlist != null)
				{
					var node = patreonlist.GetComponent<UdonBehaviour>();
				var disassembled = node.DisassembleUdonBehaviour();
				if (disassembled != null)
				{
					try
					{
						var isEliteBoolPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("__0_isElite_Boolean"));
						if (isEliteBoolPatch != null)
						{
							var extract = isEliteBoolPatch.Unpack_Boolean();
							if (extract.HasValue)
							{
								if (!extract.Value)
								{
									UdonHeapEditor.PatchHeap(disassembled, "__0_isElite_Boolean", true, true);
								}
							}
						}
						var vipOnlyPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("vipOnly"));
						if (vipOnlyPatch != null)
						{
							UdonHeapEditor.PatchHeap(disassembled, "vipOnly", false, true);
						}

						var vipOnlyLocalPatch = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("vipOnlyLocal"));
						if (vipOnlyLocalPatch != null)
						{
							UdonHeapEditor.PatchHeap(disassembled, "vipOnlyLocal", false, true);
						}
					}

					catch (Exception e)
					{
						ModConsole.ErrorExc(e);

					}
				}
				try
					{
						var Elite_List = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("elitesInInstance"));
						if (Elite_List != null)
						{
							var list = Elite_List.Unpack_Array_VRCPlayerApi().ToList();
							if (list != null && list.Count() != 0)
							{
								if (!list.Contains(Utils.LocalPlayer))
								{
									list.Add(Utils.LocalPlayer);
								}
							}
							else
							{
							list = new List<VRC.SDKBase.VRCPlayerApi>
							{
								Utils.LocalPlayer
							};
						}

							UdonHeapEditor.PatchHeap(disassembled, "elitesInInstance", list.ToArray(), true);
						}

					var Patron_List = disassembled.IUdonHeap.GetHeapVariable(disassembled.IUdonSymbolTable.GetAddressFromSymbol("vipsInInstance"));
					if (Patron_List != null)
					{
						var list = Patron_List.Unpack_Array_VRCPlayerApi().ToList();
						if (list != null && list.Count() != 0)
						{
							if (!list.Contains(Utils.LocalPlayer))
							{
								list.Add(Utils.LocalPlayer);
							}
						}
						else
						{
							list = new List<VRC.SDKBase.VRCPlayerApi>
							{
								Utils.LocalPlayer
							};
						}

						UdonHeapEditor.PatchHeap(disassembled, "vipsInInstance", list.ToArray(), true);
					}
					node.InitializeUdonContent();
					node.Start();

				}
				catch (Exception e)
					{
						ModConsole.ErrorExc(e);
					}


				}

		}
	}
}