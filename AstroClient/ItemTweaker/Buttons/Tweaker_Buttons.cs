namespace AstroClient.AstroUtils.ItemTweaker
{
	#region Imports

	using AstroClient.components;
	using AstroClient.extensions;
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweaker;
	using AstroClient.variables;
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRC.Udon;
	using VRC.Udon.Common.Interfaces;
	using Color = UnityEngine.Color;

	#endregion Imports

	public class ItemTweakerMain : GameEvents
	{
		public static void InitButtons(float x, float y, bool btnHalf)
		{
			//var menu = new QMNestedButton("ShortcutMenu", x, y, "Item Tweaker", "Item Tweaker!", null, null, null, null, btnHalf);
			QMTabMenu menu = new QMTabMenu(3f, "Item Tweaker", null, null, null, "AstroClient.Resources.box.png");

			// DONT USE SYNCPHYSIC UNLESS OBJECT IS SYNCED , (On progress to make unsynced objects synced as well) 
			//new QMSingleButton(menu, -1, -2f, "Force Sync Physic", new Action(() => { Tweaker_Object.GetGameObjectToEdit().ForceSyncPhysic(); }), "Force Sync Physic", null, null, true);

			GameObjMenu.InitTogglerMenu(menu, -1, -1.5f, true);
			Tweaker_Object.TransformToEditBtn = new QMSingleButton(menu, -1, -1f, "None", new Action(() => { Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", null, null);

			ObjectActiveToggle = new QMSingleToggleButton(menu, -1, 0f, "Enabled", () =>
			{
				Tweaker_Object.GetGameObjectToEdit().SetActiveStatus(true);
			}, "Disabled", () =>
			{
				Tweaker_Object.GetGameObjectToEdit().SetActiveStatus(false);
			}, "Toggles SetActive", Color.green, Color.red, null, false, true);
			Main_CurrentObjOwner = new QMSingleButton(menu, -1, 0.5f, "Current Owner : null", null, "Shows Current object owner.", null, null, true);
			Main_CurrentObjOwner.SetResizeTextForBestFit(true);
			Main_CurrentObjHolder = new QMSingleButton(menu, -1, 1f, "Current Holder : null", null, "Shows Current object Holder.", null, null, true);
			Main_CurrentObjHolder.SetResizeTextForBestFit(true);

			SubMenuTeleportToMe = new QMSingleButton(menu, -1, 1.5f, GetTeleportToMeBtnText, new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }), GetTeleportToMeBtnText, null, null);
			SubMenuTeleportToMe.SetResizeTextForBestFit(true);

			SubMenuTeleportToTarget = new QMSingleButton(menu, -1, 2.5f, GetTeleportToTargetText, new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }), GetTeleportToTargetText, null, null);
			SubMenuTeleportToTarget.SetResizeTextForBestFit(true);

			new QMSingleButton(menu, 2, 1.5f, "Restore Rigidbody", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RestoreOriginalSettings(); }), "Restore Default RigidBody Config.", null, null, true);
			new QMSingleButton(menu, 1, 1.5f, "Remove Add-ons", new Action(KillCustomComponents), "Kill All Custom Add-ons.", null, null, true);
			new QMSingleButton(menu, 2, 2f, "Teleport to Object", new Action(() => { GameObjectUtils.TeleportPlayerToPickup(Tweaker_Object.GetGameObjectToEdit()); }), "Teleport to object.", null, null, true);
			new QMSingleButton(menu, 2, 2.5f, "Respawn Object", new Action(() => { GameObjectUtils.RestoreOriginalLocation(Tweaker_Object.GetGameObjectToEdit(), false); }), "Reset Object Position.", null, null, true);

			PhysicSubMenu(menu, 2, 0, true);
			ConstraintSubMenu(menu, 2, 0.5f, true);
			PickupPropertySubMenu(menu, 2, 1, true);
			new QMSingleButton(menu, 3, 0, "Spawn Clone", new Action(() => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }), "Instantiates a copy of The selected object.", null, null, true);
			new QMSingleButton(menu, 3, 0.5f, "Kill Clones", new Action(() => { Cloner.ObjectCloner.ClonedObjectsDeleter(); }), "Removes All Cloned Objects.", null, null, true);

			Object_no_Gravity = new QMSingleButton(menu, 1, 0, "No Gravity", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SetGravity(false); }), "Make the object lose gravity!", null, null, true);
			Object_Gravity = new QMSingleButton(menu, 1, 0.5f, "World Gravity", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SetGravity(true); }), "Make the object affected by gravity!", null, null, true);
			ScaleSubMenuButtons(menu, 1, 1, true);

			var tmp = new QMSingleToggleButton(menu, 1, 2, "Selected Item ESP : ON", () =>
			{
				Tweaker_Object.CurrentSelectedItemEnabledESP = true;
			}, "Selected Item ESP : OFF", () => { Tweaker_Object.CurrentSelectedItemEnabledESP = false; }, "Toggles Selected item ESP", Color.green, Color.red, null, false, true);
			tmp.SetResizeTextForBestFit(true);

			Tweaker_Object.LockHoldItem = new QMSingleToggleButton(menu, 1, 2.5f, "Lock ON", () =>
			{
				Tweaker_Object.DoNotPickOtherItems = true;
			}, "Lock OFF", () => { Tweaker_Object.DoNotPickOtherItems = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)", Color.green, Color.red, null, false, true);

			PickupSelectionQMScroll(menu, 3, 2, true);
			WorldObjectSeletionQMScroll(menu, 3, 2.5f, true);
			InternalTriggerQMScroll(menu, 4, 2, true);
			VRC_InteractableSubMenu(menu, 4, 2.5f, true);
			if (Bools.IsDeveloper)
			{
				Internal_UdonEvents(menu, 5, 2, true);
			}

			CurrentObjectCoordsBtn = new QMSingleButton(menu, 5, -1, "", null, "Shows Object Coords", null, null, false);
			CurrentObjectCoordsBtn.getGameObject().GetComponent<UnityEngine.UI.Image>().enabled = false;
			CurrentObjectCoordsBtn.SetResizeTextForBestFit(true);

			new QMSingleButton(menu, 6, -2f, "Copy Local Position.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyLocalPosition(); }), "Copies Object Current Local Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 6, -1.5f, "Copy Position.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyPosition(); }), "Copies Object Current Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 6, -1f, "Copy Rotation.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyRotation(); }), "Copies Object Current Rotation in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 6, -0.5f, "Copy Object Path.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyPath(); }), "Copies Object Current Path in clipboard.", null, Color.yellow, true);

			new QMSingleButton(menu, 6, 2f, "DANGER : Destroy item.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DestroyObject(); }), "Destroys Object , You need to reload the world to restore it back.", null, Color.red, true);
			SpawnedPickupsCounter = new QMSingleButton(menu, 6, 0, GetClonesPickupText, null, GetClonesPickupText, null, Color.cyan, true);
			SpawnedPrefabsCounter = new QMSingleButton(menu, 6, 0.5f, GetSpawnedPrefabText, null, GetSpawnedPrefabText, null, Color.cyan, true);
			ProtectionInteractor = new QMSingleToggleButton(menu, 6, 1, "Interaction block ON", () =>
			{
				var control = Tweaker_Object.GetGameObjectToEdit().GetComponent<RigidBodyController>();
				if (control != null)
				{
					if (!control.EditMode)
					{
						control.EditMode = true;
					}
					control.PreventOthersFromGrabbing = true;
				}
			}, "Interaction block OFF", () =>
			{
				var control = Tweaker_Object.GetGameObjectToEdit().GetComponent<RigidBodyController>();
				if (control != null)
				{
					if (!control.EditMode)
					{
						control.EditMode = true;
					}
					control.PreventOthersFromGrabbing = false;
				}
			}, "Prevents Others from interacting with the object", Color.green, Color.red, null, false, true);

			ForceSubMenu(menu, 4, 0, true);
			RocketComponentSubMenu(menu, 4, 0.5f, true);
			CrazyComponentSubMenu(menu, 4, 1f, true);
			SpinnerSubMenu(menu, 4, 1.5f, true);
			PrefabSpawnerQMScroll(menu, 3, 1f, true);
			new QMSingleButton(menu, 3, 1.5f, "Kill Spawned Prefabs", new Action(() => { KillSpawnedPrefabs(); }), "Removes All Prefabs Objects.", null, null, true);

			Forces.TakeOwnerShipToggle = new QMSingleToggleButton(menu, 5, 0, "Take Ownership : ON", () =>
			{
				Forces.TakeOwnership = true;
			}, "Take Ownership : OFF", () =>
			{
				Forces.TakeOwnership = false;
			}, "Control if Forces should get ownership of objects", Color.green, Color.red, null, false, true);

			new QMSingleButton(menu, 5, 0.5f, "Activates all Colliders", new Action(() => { Tweaker_Object.GetGameObjectToEdit().enablecolliders(); }), "Enables all colliders bound to the object", null, null, true);
			new QMSingleButton(menu, 5, 1f, "Add Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);
			new QMSingleButton(menu, 5, 1.5f, "Add Trigger Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddTriggerCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);
			new QMSingleButton(menu, 6, 1.5f, "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().ClaimOwnership(); }), "Make Whatever Player, drop the object.", null, Color.cyan, true);
		}

		public static void AddToWorldUtilsMenu(GameObject obj)
		{
			if (obj != null)
			{
				if (!WorldObjects.Contains(obj))
				{
					WorldObjects.Add(obj);
				}
			}
		}

		public static void WorldObjectSeletionQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Select W.Objects", "Select World Objects to edit", null, null, null, null, btnHalf);
			var scroll = new QMScrollMenu(menu);
			new QMSingleButton(menu, 0, -1, "Refresh", delegate
			{
				scroll.Refresh();
			}, "", null, null, true);

			SelWorld_TeleportToMePickup = new QMSingleButton(menu, 0, -0.5f, GetTeleportToMeBtnText, delegate
		   {
			   Tweaker_Object.GetGameObjectToEdit().TeleportToMe();
		   }, GetTeleportToMeBtnText);
			SelWorld_TeleportToMePickup.SetResizeTextForBestFit(true);

			SelWorld_TeleportToTargetPickup = new QMSingleButton(menu, 0, 0.5f, GetTeleportToTargetText, delegate
			{
				Tweaker_Object.GetGameObjectToEdit().TeleportToTarget();
			}, GetTeleportToTargetText);
			SelWorld_TeleportToTargetPickup.SetResizeTextForBestFit(true);
			new QMSingleButton(menu, 0, 1.5f, "Spawn Clone", new Action(() => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }), "Instantiates a copy of The selected object.", null, null, true);
			SelWorld_CurrentObjHolder = new QMSingleButton(menu, -1, -0.5f, "Current Holder : null", null, "Who is Holding the object.", null, null, false);
			SelWorld_CurrentObjHolder.SetResizeTextForBestFit(true);
			SelWorld_IsHeld = new QMSingleButton(menu, -1, -1f, "Held : No", null, "See if Pickup is held or not.", null, null, true);
			SelWorld_CurrentObjOwner = new QMSingleButton(menu, -1, 0.5f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
			SelWorld_CurrentObjOwner.SetResizeTextForBestFit(true);

			scroll.SetAction(delegate
			{
				foreach (var item in WorldObjects)
				{
					scroll.Add(
					new QMSingleButton(scroll.BaseMenu, 0, 0, $"Select {item.name}", delegate
					{
						Tweaker_Object.SetObjectToEdit(item);
					}, $"Select {item.name}", null, GetObjectStatus(item.gameObject)));
				}
			});
		}

		public static void PickupSelectionQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Select Pickup", "Select World Pickup to edit", null, null, null, null, btnHalf);
			var PickupQMScroll = new QMScrollMenu(menu);
			new QMSingleButton(menu, 0, -1, "Refresh", delegate
			{
				PickupQMScroll.Refresh();
			}, "", null, null, true);

			TeleportToMePickup = new QMSingleButton(menu, 0, -0.5f, GetTeleportToMeBtnText, delegate
		   {
			   Tweaker_Object.GetGameObjectToEdit().TeleportToMe();
		   }, GetTeleportToMeBtnText);
			TeleportToMePickup.SetResizeTextForBestFit(true);

			TeleportToTargetPickup = new QMSingleButton(menu, 0, 0.5f, GetTeleportToTargetText, delegate
			{
				Tweaker_Object.GetGameObjectToEdit().TeleportToTarget();
			}, GetTeleportToTargetText);
			TeleportToTargetPickup.SetResizeTextForBestFit(true);
			new QMSingleButton(menu, 0, 1.5f, "Spawn Clone", new Action(() => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }), "Instantiates a copy of The selected object.", null, null, true);
			SelPickup_CurrentObjHolder = new QMSingleButton(menu, -1, -0.5f, "Current Holder : null", null, "Who is Holding the object.", null, null, false);
			SelPickup_CurrentObjHolder.SetResizeTextForBestFit(true);
			SelPickup_IsHeld = new QMSingleButton(menu, -1, -1f, "Held : No", null, "See if Pickup is held or not.", null, null, true);
			SelPickup_CurrentObjOwner = new QMSingleButton(menu, -1, 0.5f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
			SelPickup_CurrentObjOwner.SetResizeTextForBestFit(true);

			PickupQMScroll.SetAction(delegate
			{
				foreach (var pickup in WorldUtils.GetPickups())
				{
					if (pickup.name == "ViewFinder")
					{
						continue;
					}
					if (pickup.name == "AvatarDebugConsole")
					{
						continue;
					}
					PickupQMScroll.Add(
					new QMSingleButton(PickupQMScroll.BaseMenu, 0, 0, $"Select {pickup.name}", delegate
					{
						Tweaker_Object.SetObjectToEdit(pickup);
					}, $"Select {pickup.name}", null, GetObjectStatus(pickup)));
				}
			});
		}

		internal static void CheckIfContainsPickupProperties(GameObject obj)
		{
			if (obj != null)
			{
				if (obj == Tweaker_Object.CurrentSelectedObject)
				{
					var pickup1 = obj.GetComponent<VRC.SDKBase.VRC_Pickup>();
					var pickup2 = obj.GetComponent<VRCSDK2.VRC_Pickup>();
					var pickup3 = obj.GetComponent<VRC.SDK3.Components.VRCPickup>();
					if (pickup1 == null && pickup2 == null && pickup3 == null)
					{
						if (HasPickupComponent != null)
						{
							HasPickupComponent.setTextColor(Color.red);
						}

						#region PickupOrientation

						if (Pickup_PickupOrientation_prop_any != null)
						{
							Pickup_PickupOrientation_prop_any.setTextColor(Color.red);
						}
						if (Pickup_PickupOrientation_prop_Grip != null)
						{
							Pickup_PickupOrientation_prop_Grip.setTextColor(Color.red);
						}
						if (Pickup_PickupOrientation_prop_Gun != null)
						{
							Pickup_PickupOrientation_prop_Gun.setTextColor(Color.red);
						}

						#endregion PickupOrientation

						#region Autohold

						if (Pickup_AutoHoldMode_prop_AutoDetect != null)
						{
							Pickup_AutoHoldMode_prop_AutoDetect.setTextColor(Color.red);
						}
						if (Pickup_AutoHoldMode_prop_Yes != null)
						{
							Pickup_AutoHoldMode_prop_Yes.setTextColor(Color.red);
						}
						if (Pickup_AutoHoldMode_prop_No != null)
						{
							Pickup_AutoHoldMode_prop_No.setTextColor(Color.red);
						}

						#endregion Autohold

						#region AllowManipulationWhenEquipped

						if (Pickup_allowManipulationWhenEquipped != null)
						{
							Pickup_allowManipulationWhenEquipped.setToggleState(false);
						}

						#endregion AllowManipulationWhenEquipped

						#region Pickupable

						if (Pickup_pickupable != null)
						{
							Pickup_pickupable.setToggleState(false);
						}

						#endregion Pickupable

						#region DisallowTheft

						if (Pickup_DisallowTheft != null)
						{
							Pickup_DisallowTheft.setToggleState(false);
						}

						#endregion DisallowTheft
					}
				}
				else
				{
					if (HasPickupComponent != null)
					{
						HasPickupComponent.setTextColor(Color.green);
					}
				}
			}
		}

		public static void InternalTriggerQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Interact Triggers", "Interact with Selected Pickup Triggers", null, null, null, null, btnHalf);
			var scroll = new QMScrollMenu(menu);
			scroll.SetAction(delegate
			{
				foreach (var trigger in GetObjectTriggers(Tweaker_Object.GetGameObjectToEdit()))
				{
					scroll.Add(
					new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {trigger.name}", delegate
					{
						trigger.TriggerClick();
					}, $"Click {trigger.name}", null, GetObjectStatus(trigger)));
				}
			});
		}

		public static List<VRC.SDKBase.VRC_Trigger> GetObjectTriggers(GameObject obj)
		{
			var ContainedTriggers = new List<VRC.SDKBase.VRC_Trigger>();

			if (obj != null)
			{
				var list = obj.GetComponentsInChildren<VRC.SDKBase.VRC_Trigger>(true);
				var list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true);
				if (list.Count() != 0)
				{
					foreach (var item in list)
					{
						if (!ContainedTriggers.Contains(item))
						{
							ContainedTriggers.Add(item);
						}
					}
					return ContainedTriggers;
				}
				else if (list2.Count() != 0)
				{
					foreach (var item in list2)
					{
						if (!ContainedTriggers.Contains(item))
						{
							ContainedTriggers.Add(item);
						}
					}
					return ContainedTriggers;
				}
				return ContainedTriggers;
			}
			return ContainedTriggers;
		}

		public static List<UdonBehaviour> GetObjectUdonVRC(GameObject obj)
		{
			if (obj != null)
			{
				try
				{
					var Internal_UdonBehaviour = new List<UdonBehaviour>();
					var list1 = obj.GetComponentsInChildren<UdonBehaviour>(true);
					if (list1.Count() != 0)
					{
						foreach (var item in list1)
						{
							if (!Internal_UdonBehaviour.Contains(item))
							{
								Internal_UdonBehaviour.Add(item);
							}
						}
						return Internal_UdonBehaviour;
					}
				}
				catch (Exception)
				{
					return null;
				}
			}
			return null;
		}

		public static List<GameObject> GeObjectVRC_Interactables(GameObject obj)
		{
			if (obj != null)
			{
				try
				{
					var VRC_Interactables = new List<GameObject>();
					var list1 = obj.GetComponentsInChildren<VRC.SDKBase.VRC_Interactable>(true);
					var list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Interactable>(true);
					var list3 = obj.GetComponentsInChildren<VRCInteractable>(true);
					if (list1.Count() != 0)
					{
						foreach (var item in list1)
						{
							if (!VRC_Interactables.Contains(item.gameObject))
							{
								VRC_Interactables.Add(item.gameObject);
							}
						}
						return VRC_Interactables;
					}
					if (list2.Count() != 0 && list1.Count() == 0)
					{
						foreach (var item in list2)
						{
							if (!VRC_Interactables.Contains(item.gameObject))
							{
								VRC_Interactables.Add(item.gameObject);
							}
						}
						return VRC_Interactables;
					}
					if (list3.Count() != 0 && list1.Count() == 0 && list2.Count() == 0)
					{
						foreach (var item in list3)
						{
							if (!VRC_Interactables.Contains(item.gameObject))
							{
								VRC_Interactables.Add(item.gameObject);
							}
						}
						return VRC_Interactables;
					}
					return VRC_Interactables;
				}
				catch (Exception)
				{
					return null;
				}
			}
			return null;
		}

		public static void Internal_UdonEvents(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var Menu = new QMNestedButton(main, x, y, "Internal Udon Events ", "Interact with Internal Udon Events", null, null, null, null, btnHalf);
			var whytfisthishere = new QMNestedButton(Menu, -5f, -5f, "", "");
			whytfisthishere.getMainButton().setActive(false);
			var MainScroll = new QMScrollMenu(whytfisthishere);
			var subscroll = new QMScrollMenu(Menu);
			new QMSingleButton(Menu, 0, -1.5f, "Refresh", delegate
			{
				MainScroll.Refresh();
				subscroll.Refresh();
			}, "", null, null, true);
			subscroll.SetAction(delegate
			{
				foreach (var action in GetObjectUdonVRC(Tweaker_Object.GetGameObjectToEdit()))
				{
					subscroll.Add(new QMSingleButton(Menu, 0f, 0f, action.gameObject.name, delegate
					{
						MainScroll.SetAction(delegate
						{
							foreach (var subaction in action._eventTable)
							{
								MainScroll.Add(new QMSingleButton(MainScroll.BaseMenu, 0f, 0f, subaction.Key, delegate
								{
									if (subaction.key.StartsWith("_"))
									{
										action.SendCustomEvent(subaction.Key);
									}
									else
									{
										action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
									}
								}, (action.gameObject)?.ToString() + " Run " + subaction.Key));
							}
						});
						MainScroll.BaseMenu.getMainButton().getGameObject().GetComponent<UnityEngine.UI.Button>()
							.onClick.Invoke();
					}, action.interactText));
				}
			});
		}

		public static void VRC_InteractableSubMenu(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Internal VRC_Interactable ", "Interact with Internal VRC_Interactable Triggers", null, null, null, null, btnHalf);
			menu.getMainButton().SetResizeTextForBestFit(true);
			var scroll = new QMScrollMenu(menu);
			new QMSingleButton(menu, 0, -1, "Refresh", delegate
			{
				scroll.Refresh();
			}, "", null, null, true);
			scroll.SetAction(delegate
			{
				foreach (var obj in GeObjectVRC_Interactables(Tweaker_Object.GetGameObjectToEdit()))
				{
					scroll.Add(
					new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {obj.name}", delegate
					{
						obj.VRC_Interactable_Click();
					}, $"Click {obj.name}", null, ItemTweakerMain.GetObjectStatus(obj)));
				}
			});
		}

		public static Color GetObjectStatus(GameObject obj)
		{
			if (obj != null)
			{
				if (obj.active)
				{
					return Color.green;
				}
				else
				{
					return Color.red;
				}
			}
			return Color.red;
		}

		public static Color GetObjectStatus(VRC_Trigger obj)
		{
			if (obj != null)
			{
				if (obj.enabled)
				{
					return Color.green;
				}
				else
				{
					return Color.red;
				}
			}
			return Color.red;
		}


		public static void PrefabSpawnerQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
		{
			var menu = new QMNestedButton(main, x, y, "Spawn Prefabs", "Spawn World Prefabs", null, null, null, null, btnHalf);
			var prefabQMScroll = new QMScrollMenu(menu);
			prefabQMScroll.SetAction(delegate
			{
				foreach (var prefab in WorldUtils.GetAllWorldPrefabs())
				{
					prefabQMScroll.Add(
					new QMSingleButton(prefabQMScroll.BaseMenu, 0, 0, $"Spawn {prefab.name}", delegate
					{
						var newprefab = Networking.Instantiate(0, prefab.name, LocalPlayerUtils.GetPlayerBoneTransform(HumanBodyBones.RightHand).position, new Quaternion(0, 0, 0, 0));
						if (newprefab != null)
						{
							RegisterPrefab(newprefab);
							Tweaker_Object.SetObjectToEdit(newprefab);
						}
					}, $"Spawn {prefab.name}"));
				}
			});
		}

		public static void UpdateTeleportToMeBtns()
		{
			try
			{
				if (TeleportToMePickup != null)
				{
					TeleportToMePickup.setButtonText(GetTeleportToMeBtnText);
					TeleportToMePickup.setToolTip(GetTeleportToMeBtnText);
				}
				if (SubMenuTeleportToMe != null)
				{
					SubMenuTeleportToMe.setButtonText(GetTeleportToMeBtnText);
					SubMenuTeleportToMe.setToolTip(GetTeleportToMeBtnText);
				}
				if (SelWorld_TeleportToMePickup != null)
				{
					SelWorld_TeleportToMePickup.setButtonText(GetTeleportToMeBtnText);
					SelWorld_TeleportToMePickup.setToolTip(GetTeleportToMeBtnText);
				}
			}
			catch { }
		}

		public static string GetTeleportToMeBtnText
		{
			get
			{
				return "Teleport\nto\nyou:\n" + Tweaker_Object.GetObjectToEditName;
			}
		}

		public static string GetTeleportToTargetText
		{
			get
			{
				if (ObjectMiscOptions.CurrentTarget != null)
				{
					return "Teleport\n" + Tweaker_Object.GetObjectToEditName + "\nto:\n" + ObjectMiscOptions.CurrentTarget.field_Private_APIUser_0.displayName;
				}
				else
				{
					return "Teleport\nto:\n null";
				}
			}
		}

		public static List<GameObject> SpawnedPrefabs = new List<GameObject>();

		public static void RegisterPrefab(GameObject obj)
		{
			if (obj != null)
			{
				if (!SpawnedPrefabs.Contains(obj))
				{
					SpawnedPrefabs.Add(obj);
				}
				UpdateSpawnedPrefabsBtn();
			}
		}

		public static void ScaleSubMenuButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var ScaleEditor = new QMNestedButton(menu, x, y, "Scale", "Scale Editor Menu!", null, null, null, null, btnHalf);

			ScaleSlider = new QMSlider(Utils.QuickMenu.transform.Find(ScaleEditor.getMenuName()), "Scale:", 250, -720, delegate (float value)
			{
				ObjectMiscOptions.SetScaleValueToUse(value);
			}, 0.1f, 20, 0, true);
			ScaleSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
			ScaleSlider.SetTextLabel("");

			ObjectMiscOptions.CurrentAddValue = new QMSingleButton(ScaleEditor, 5, -1, ObjectMiscOptions.ScaleValueToUse.ToString(), null, string.Empty, null, null, true);
			ObjectMiscOptions.GameObjectActualScale = new QMSingleButton(ScaleEditor, 5, 0, string.Empty, null, "Current Inflater Object Scale", null, null);
			ObjectMiscOptions.CurrentScaleButton = new QMSingleButton(ScaleEditor, 5, 1, string.Empty, null, "Current Item Scale", null, null);

			new QMSingleButton(ScaleEditor, 1, 1, "+ Scale", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncreaseHoldItemScale(); }), "Increase item scale!", null, null, true);
			new QMSingleButton(ScaleEditor, 1, 1.5f, "- Scale", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecreaseHoldItemScale(); }), "Decrease item scale!", null, null, true);

			ObjectMiscOptions.InflaterModeButton = new QMSingleToggleButton(ScaleEditor, 1, 2, "SCale Inflater ON", new Action(() => { ObjectMiscOptions.InflaterScaleMode = true; }), "Scale Inflater OFF", new Action(() => { ObjectMiscOptions.InflaterScaleMode = false; }), "Change between instant or inflater", Color.green, Color.red, null, false, true);
			new QMSingleButton(ScaleEditor, 1, 2.5f, "Restore Original", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RestoreOriginalScaleItem(); }), "Restores Original Item Scale!", null, null, true);

			ObjectMiscOptions.ScaleEditX = new QMSingleToggleButton(ScaleEditor, 2, 1, "Edit X", new Action(() => { ObjectMiscOptions.EditVectorX = true; }), "Ignore X", new Action(() => { ObjectMiscOptions.EditVectorX = false; }), "Make Inflater Edit X", Color.green, Color.red, null, false, true);
			ObjectMiscOptions.ScaleEditY = new QMSingleToggleButton(ScaleEditor, 2, 1.5f, "Edit Y", new Action(() => { ObjectMiscOptions.EditVectorY = true; }), "Ignore Y", new Action(() => { ObjectMiscOptions.EditVectorY = false; }), "Make Inflater Edit Y", Color.green, Color.red, null, false, true);
			ObjectMiscOptions.ScaleEditZ = new QMSingleToggleButton(ScaleEditor, 2, 2, "Edit Z", new Action(() => { ObjectMiscOptions.EditVectorZ = true; }), "Ignore Z", new Action(() => { ObjectMiscOptions.EditVectorZ = false; }), "Make Inflater Edit Z", Color.green, Color.red, null, false, true);
		}

		public static void PhysicSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var PhysicEditor = new QMNestedButton(menu, x, y, "Physics", "Item Physics Editor Menu!", null, null, null, null, btnHalf);
			new QMSingleButton(PhysicEditor, 1, 0, "Enable Collisions", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SetDetectCollision(true); }), "Make the object affected by colliders!", null, null, true);
			new QMSingleButton(PhysicEditor, 1, 0.5f, "Disable Collisions", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SetDetectCollision(false); }), "Make the object unaffected by colliders!", null, null, true);
			new QMSingleButton(PhysicEditor, 2, 0, "Enable Kinematic", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SetKinematic(true); }), "Make the object Kinematic!", null, null, true);
			new QMSingleButton(PhysicEditor, 2, 0.5f, "Disable Kinematic", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SetKinematic(false); }), "Disables Kinematic!", null, null, true);
			new QMSingleButton(PhysicEditor, 3, 0f, "Make It bouncy", new Action(() => {

				var item = Tweaker_Object.GetGameObjectToEdit();
				if (item != null)
				{
					var bouncer = item.GetComponent<Bouncer>();
					if (bouncer == null)
					{
						bouncer =  item.AddComponent<Bouncer>();
					}
					if(bouncer != null)
					{
						bouncer.BounceTowardPlayer = false;
					}
				}
			}), "Make It Bouncy!", null, null, true);
			 new QMSingleButton(PhysicEditor, 3, 0.5f, "Make It bouncy toward player", new Action(() =>
			{

				var item = Tweaker_Object.GetGameObjectToEdit();
				if (item != null)
				{
					var bouncer = item.GetComponent<Bouncer>();
					if (bouncer == null)
					{
						bouncer = item.AddComponent<Bouncer>();
					}
					if(bouncer != null)
					{
						bouncer.BounceTowardPlayer = true;
					}
				}
			}), "Make It bouncy toward player!", null, null, true).SetResizeTextForBestFit(true);
			
			new QMSingleButton(PhysicEditor, 3, 1f, "Remove Bouncy", new Action(() => {
				var item = Tweaker_Object.GetGameObjectToEdit();
				if (item != null)
				{
					var bouncer = item.GetComponent<Bouncer>();
					if (bouncer != null)
					{
						bouncer.DestroyMeLocal();
					}
				}
			}), "Kill the Bouncyness!!", null, null, true);

		}

		public static void ConstraintSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var ConstraintMenu = new QMNestedButton(menu, x, y, "Constraints", "Item Constraints Options", null, null, null, null, btnHalf);
			Forces.Constraint_X_Toggle = new QMToggleButton(ConstraintMenu, 1, 0, "Block X Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePositionX); }), "Unlock X Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezePositionX); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Y_Toggle = new QMToggleButton(ConstraintMenu, 2, 0, "Block Y Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePositionY); }), "Unlock Y Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezePositionY); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Z_Toggle = new QMToggleButton(ConstraintMenu, 3, 0, "Block Z Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePositionZ); }), "Unlock Z Movement", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezePositionZ); }), "Control Current Object Constraints!", null, null, null, false);
			new QMSingleButton(ConstraintMenu, 4, 0, "Freeze Position", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezePosition); }), null, null, null, false);

			Forces.Constraint_Rot_X_Toggle = new QMToggleButton(ConstraintMenu, 1, 1, "Block X Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotationX); }), "Unlock X Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezeRotationX); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Rot_Y_Toggle = new QMToggleButton(ConstraintMenu, 2, 1, "Block Y Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotationY); }), "Unlock Y Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezeRotationY); }), "Control Current Object Constraints!", null, null, null, false);
			Forces.Constraint_Rot_Z_Toggle = new QMToggleButton(ConstraintMenu, 3, 1, "Block Z Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotationZ); }), "Unlock Z Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RemoveConstraint(RigidbodyConstraints.FreezeRotationZ); }), "Control Current Object Constraints!", null, null, null, false);
			new QMSingleButton(ConstraintMenu, 4, 1, "Freeze Rotation", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddConstraint(RigidbodyConstraints.FreezeRotation); }), null, null, null, false);

			new QMSingleButton(ConstraintMenu, 1, 2, "Remove all Object Constraints", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_all_constraints(); }), "Delete all object Constraints", null, null);
		}

		public static void ForceSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var ForceSubMenu = new QMNestedButton(menu, x, y, "Forces", "You have the Force! Dont abuse it! <3!", null, null, null, null, btnHalf);

			Forces_Pickup_IsHeld = new QMSingleButton(ForceSubMenu, 0, -1.5f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

			Forces_CurrentObjHolder = new QMSingleButton(ForceSubMenu, 0, -1, "Current holder : null", null, "Who is the current object Holder.", null, null, false);
			Forces_CurrentObjHolder.SetResizeTextForBestFit(true);

			Forces_SelPickup_CurrentObjOwner = new QMSingleButton(ForceSubMenu, 5, -1, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
			Forces_SelPickup_CurrentObjOwner.SetResizeTextForBestFit(true);

			Forces.ForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 0, "Force : " + Forces.Force, new Action(Forces.ResetForcesVar), string.Empty, null, null);
			Forces.SpinForceAmnt1 = new QMSingleButton(ForceSubMenu, 0, 1, "Spin Force : " + Forces.SpinForce, new Action(Forces.ResetSpinForcesVar), string.Empty, null, null);

			QMNestedButton ForceAddControl = new QMNestedButton(ForceSubMenu, 5, 0, "Tweak Force Amounts", "Force Tweaker Menu!", null, null, null, null);

			Forces.ForceAmnt2 = new QMSingleButton(ForceAddControl, 0, 0, "Force : " + Forces.Force, new Action(Forces.ResetForcesVar), string.Empty, null, null);
			Forces.SpinForceAmnt2 = new QMSingleButton(ForceAddControl, 0, 1, "Spin Force : " + Forces.SpinForce, new Action(Forces.ResetSpinForcesVar), string.Empty, null, null);

			ForceSlider = new QMSlider(Utils.QuickMenu.transform.Find(ForceAddControl.getMenuName()), "Force Power :", 150, -720, delegate (float value)
			{
				Forces.SetForceAmount((int)value);
			}, Forces.DefaultForce, 1000, 1, true);
			ForceSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
			ForceSlider.SetTextLabel("");
			Forces.ResetForcesVar();

			SpinForceSlider = new QMSlider(Utils.QuickMenu.transform.Find(ForceAddControl.getMenuName()), "Spin Power : ", 150, -1120, delegate (float value)
			{
				Forces.SetSpinForceAmount((int)value);
			}, Forces.DefaultSpinForce, 1000, 1, true);
			SpinForceSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
			SpinForceSlider.SetTextLabel("");
			Forces.ResetSpinForcesVar();

			new QMSingleButton(ForceSubMenu, 5, 1, "Kill Any Object Forces", new Action(() => { Tweaker_Object.GetGameObjectToEdit().KillForces(); }), "Kill Obj Forces", null, null);
			var right = new QMSingleButton(ForceSubMenu, 4, 2, "→", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Right(); }), string.Empty, null, null);
			//right.SetButtonToArrow();
			//right.RotateButton(90);
			var left = new QMSingleButton(ForceSubMenu, 2, 2, "←", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Left(); }), string.Empty, null, null);
			//left.SetButtonToArrow();
			//left.RotateButton(-90);
			var foward = new QMSingleButton(ForceSubMenu, 3, 1, "↑", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Foward(); }), string.Empty, null, null);
			//foward.SetButtonToArrow();
			//foward.RotateButton()
			var backward = new QMSingleButton(ForceSubMenu, 3, 2, "↓", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Backward(); }), string.Empty, null, null);
			//backward.SetButtonToArrow();
			//backward.RotateButton(-10);
			new QMSingleButton(ForceSubMenu, 1, 0, "Push", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Push(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 2, 0, "Pull", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Pull(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 1, 1, "Rotate X", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SpinX(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 2, 1, "Rotate Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SpinY(); }), string.Empty, null, null);
			new QMSingleButton(ForceSubMenu, 1, 2, "Rotate Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SpinZ(); }), string.Empty, null, null);
		}

		public static void RocketComponentSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var submenu = new QMNestedButton(menu, x, y, "Rocket Maker", "Turn Items Into Rockets, Be careful as they will explode on impact!", null, null, null, null, btnHalf);
			new QMSingleButton(submenu, 1, 0, "Rocket Object Direction (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithG(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 2, 0, "Rocket Object Direction (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutG(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 1, 1, "Rocket Always UP (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithGAndGoUp(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 2, 1, "Rocket Always UP (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().MakeRocketItemWithoutGAndGoUp(); }), "Turn Held Object Into a rocket!", null, null);
			new QMSingleButton(submenu, 5, 0, "Remove all rockets", new Action(RocketManager.KillRockets), "Removes all Rockets components from objects!", null, null);
			RocketManager.RocketTimer = new QMSingleButton(submenu, 4, 0, "none", null, "Tells What's the Rocket Speed!", null, null);
			new QMSingleButton(submenu, 1, 2, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncRocketSpeed(); }), "Edits the Rocket Speed", null, null);
			new QMSingleButton(submenu, 2, 2, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecRocketSpeed(); }), "Edits the Rocket Speed", null, null);
		}

		public static void CrazyComponentSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var submenu = new QMNestedButton(menu, x, y, "Crazy Object", "Make Items fly in random directions lol!", null, null, null, null, btnHalf);
			new QMSingleButton(submenu, 1, 0, "Crazy Object (With Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithGravity(); }), "Make Held Object Go Nuts!", null, null);
			new QMSingleButton(submenu, 2, 0, "Crazy Object (No Gravity)", new Action(() => { Tweaker_Object.GetGameObjectToEdit().GoNutsWithoutGravity(); }), "Make Held Object Go Nuts!", null, null);
			new QMSingleButton(submenu, 3, 0, "Remove all Crazy Objects", new Action(CrazyObjectManager.KillCrazyObjects), "Removes all Rockets components from objects!", null, null);
			CrazyObjectManager.CrazyTimerBtn = new QMSingleButton(submenu, 4, 0, "none", null, "Tells CrazyObj Speed", null, null);
			new QMSingleButton(submenu, 1, 1, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncCrazySpeed(); }), "Edits the CrazyObj Speed", null, null);
			new QMSingleButton(submenu, 2, 1, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecCrazySpeed(); }), "Edits the CrazyObj Speed", null, null);
		}

		public static void SpinnerSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var submenu = new QMNestedButton(menu, x, y, "Spin Control", "Make them spiiiiin!", null, null, null, null, btnHalf);
			new QMSingleButton(submenu, 1, 0, "+ 1 x", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceX(); }), "Add Spin Force to spinner!", null, null);
			new QMSingleButton(submenu, 2, 0, "+ 1 Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceY(); }), "Add Spin Force to spinner!", null, null);
			new QMSingleButton(submenu, 3, 0, "+ 1 Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_SpinForceZ(); }), "Add Spin Force to spinner!", null, null);
			ObjectSpinnerManager.SpinAmountTell = new QMSingleButton(submenu, 4, 0, "none", null, "Tells What's the spin force of the spinner!", null, null);
			new QMSingleButton(submenu, 1, 1, "- 1 x", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceX(); }), "Subtract Spin Force to spinner!", null, null);
			new QMSingleButton(submenu, 2, 1, "- 1 Y", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceY(); }), "Subtract Spin Force to spinner!", null, null);
			new QMSingleButton(submenu, 3, 1, "- 1 Z", new Action(() => { Tweaker_Object.GetGameObjectToEdit().SubtractSpinForceZ(); }), "Subtract Spin Force to spinner!", null, null);
			ObjectSpinnerManager.SpinnerTimerBtn = new QMSingleButton(submenu, 4, 1, "none", null, "Tells What's the spin Speed!", null, null);
			new QMSingleButton(submenu, 2, 2, "Remove all Spinner Objects", new Action(ObjectSpinnerManager.KillObjectSpinners), "Removes all Spinner components from objects!", null, null);
			new QMSingleButton(submenu, 1, 2, "Remove Spinner from Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Spinner(); }), "Removes all Spinner components from object!", null, null);
			new QMSingleButton(submenu, 3, 2, "+1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncSpinnerSpeed(); }), "Edits the Spinner Speed", null, null);
			new QMSingleButton(submenu, 4, 2, "-1 Timer", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecSpinnerSpeed(); }), "Edits the Spinner Speed", null, null);
		}

		public static void KillSpawnedPrefabs()
		{
			foreach (var prefab in SpawnedPrefabs)
			{
				if (prefab != null)
				{
					if (!prefab.DestroyMeOnline())
					{
						prefab.DestroyMeLocal();
					}
				}
			}
			SpawnedPrefabs.Clear();
			UpdateSpawnedPrefabsBtn();
		}

		public override void OnLevelLoaded()
		{
			SpawnedPrefabs.Clear();
			WorldObjects.Clear();
			UpdateTeleportToMeBtns();
			UpdateTargetButtons();
			UpdateSpawnedPrefabsBtn();
			if (CurrentObjectCoordsBtn != null)
			{
				CurrentObjectCoordsBtn.setButtonText($"X: 0 \n Y: 0 \n Z: 0");
			}
			if (Pickup_IsEditMode != null)
			{
				Pickup_IsEditMode.setButtonText("Edit Mode : OFF");
				Pickup_IsEditMode.setTextColor(Color.red);
			}
			if (HasPickupComponent != null)
			{
				HasPickupComponent.setTextColor(Color.red);
			}

			#region PickupOrientation

			if (Pickup_PickupOrientation_prop_any != null)
			{
				Pickup_PickupOrientation_prop_any.setTextColor(Color.red);
			}
			if (Pickup_PickupOrientation_prop_Grip != null)
			{
				Pickup_PickupOrientation_prop_Grip.setTextColor(Color.red);
			}
			if (Pickup_PickupOrientation_prop_Gun != null)
			{
				Pickup_PickupOrientation_prop_Gun.setTextColor(Color.red);
			}

			#endregion PickupOrientation

			#region Autohold

			if (Pickup_AutoHoldMode_prop_AutoDetect != null)
			{
				Pickup_AutoHoldMode_prop_AutoDetect.setTextColor(Color.red);
			}
			if (Pickup_AutoHoldMode_prop_Yes != null)
			{
				Pickup_AutoHoldMode_prop_Yes.setTextColor(Color.red);
			}
			if (Pickup_AutoHoldMode_prop_No != null)
			{
				Pickup_AutoHoldMode_prop_No.setTextColor(Color.red);
			}

			#endregion Autohold

			#region AllowManipulationWhenEquipped

			if (Pickup_allowManipulationWhenEquipped != null)
			{
				Pickup_allowManipulationWhenEquipped.setToggleState(false);
			}

			#endregion AllowManipulationWhenEquipped

			#region Pickupable

			if (Pickup_pickupable != null)
			{
				Pickup_pickupable.setToggleState(false);
			}

			#endregion Pickupable

			#region DisallowTheft

			if (Pickup_DisallowTheft != null)
			{
				Pickup_DisallowTheft.setToggleState(false);
			}

			#endregion DisallowTheft
		}

		public static void KillCustomComponents()
		{
			CrazyObjectManager.KillCrazyObjects();
			RocketManager.KillRockets();
			ObjectSpinnerManager.KillObjectSpinners();
		}

		public static void UpdateTargetButtons()
		{
			try
			{
				if (TeleportToTargetPickup != null)
				{
					TeleportToTargetPickup.setButtonText(GetTeleportToTargetText);
					TeleportToTargetPickup.setToolTip(GetTeleportToTargetText);
				}
				if (SubMenuTeleportToTarget != null)
				{
					SubMenuTeleportToTarget.setButtonText(GetTeleportToTargetText);
					SubMenuTeleportToTarget.setToolTip(GetTeleportToTargetText);
				}
				if (SelWorld_TeleportToTargetPickup != null)
				{
					SelWorld_TeleportToTargetPickup.setButtonText(GetTeleportToTargetText);
					SelWorld_TeleportToTargetPickup.setToolTip(GetTeleportToTargetText);
				}
			}
			catch { }
		}

		public static string GetSpawnedPrefabText
		{
			get
			{
				return "Spawned Prefabs : " + SpawnedPrefabs.Count();
			}
		}

		public static string GetClonesPickupText
		{
			get
			{
				return "Pickup Clones : " + GlobalLists.ClonedObjects.Count();
			}
		}

		public static void UpdateSpawnedPickupsBtn()
		{
			if (SpawnedPickupsCounter != null)
			{
				SpawnedPickupsCounter.setButtonText(GetClonesPickupText);
				SpawnedPickupsCounter.setToolTip(GetClonesPickupText);
			}
		}

		public static void UpdateSpawnedPrefabsBtn()
		{
			if (SpawnedPrefabsCounter != null)
			{
				SpawnedPrefabsCounter.setButtonText(GetSpawnedPrefabText);
				SpawnedPrefabsCounter.setToolTip(GetSpawnedPrefabText);
			}
		}

		public static void PickupPropertySubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var PickupEditor = new QMNestedButton(menu, x, y, "Pickup Property", "Pickup Property Editor Menu!", null, null, null, null, btnHalf);
			HasPickupComponent = new QMSingleButton(PickupEditor, 0, -1f, "Force Pickup Component", new Action(() => { Pickup.ForcePickupComponentPresence(Tweaker_Object.GetGameObjectToEdit()); }), "Forces Pickup component in case there's none.", null, null, true);
			Pickup_IsEditMode = new QMSingleButton(PickupEditor, 0, -0.5f, "Edit Mode : OFF", null, "Shows if Pickup properties are currently being overriden.", null, null, true);

			new QMSingleButton(PickupEditor, 0, 0, "Reset Properties", new Action(() => { Pickup.RestoreOriginalProperty(Tweaker_Object.GetGameObjectToEdit()); }), "Revert Pickup Properties Edits. (disabling editmode)", null, null, true);
			Pickup_IsHeld = new QMSingleButton(PickupEditor, 0, 0.5f, "Held : No", null, "See if Pickup is held or not.", null, null, true);
			Pickup_CurrentObjOwner = new QMSingleButton(PickupEditor, 0, 1f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
			Pickup_CurrentObjOwner.SetResizeTextForBestFit(true);
			Pickup_CurrentObjHolder = new QMSingleButton(PickupEditor, -1, 1f, "Current Holder : null", null, "Who is Holding the object.", null, null, false);
			Pickup_CurrentObjHolder.SetResizeTextForBestFit(true);

			new QMSingleButton(PickupEditor, 1, 0, "Pickup Orientation", null, "Pickup Orientation", null, null, true);
			Pickup_PickupOrientation_prop_any = new QMSingleButton(PickupEditor, 1, 0.5f, "Any", new Action(() => { Pickup.SetPickupOrientation(Tweaker_Object.GetGameObjectToEdit(), VRC_Pickup.PickupOrientation.Any); }), "", null, null, true);
			Pickup_PickupOrientation_prop_Grip = new QMSingleButton(PickupEditor, 1, 1f, "Grip", new Action(() => { Pickup.SetPickupOrientation(Tweaker_Object.GetGameObjectToEdit(), VRC_Pickup.PickupOrientation.Grip); }), "", null, null, true);
			Pickup_PickupOrientation_prop_Gun = new QMSingleButton(PickupEditor, 1, 1.5f, "Gun", new Action(() => { Pickup.SetPickupOrientation(Tweaker_Object.GetGameObjectToEdit(), VRC_Pickup.PickupOrientation.Gun); }), "", null, null, true);

			var autohold = new QMSingleButton(PickupEditor, 2, 0, "Pickup AutoHoldMode", null, "Pickup AutoHoldMode", null, null, true);
			autohold.SetResizeTextForBestFit(true);

			Pickup_AutoHoldMode_prop_AutoDetect = new QMSingleButton(PickupEditor, 2, 0.5f, "AutoDetect", new Action(() => { Pickup.SetAutoHoldMode(Tweaker_Object.GetGameObjectToEdit(), VRC_Pickup.AutoHoldMode.AutoDetect); }), "", null, null, true);
			Pickup_AutoHoldMode_prop_Yes = new QMSingleButton(PickupEditor, 2, 1f, "Yes", new Action(() => { Pickup.SetAutoHoldMode(Tweaker_Object.GetGameObjectToEdit(), VRC_Pickup.AutoHoldMode.Yes); }), "", null, null, true);
			Pickup_AutoHoldMode_prop_No = new QMSingleButton(PickupEditor, 2, 1.5f, "No", new Action(() => { Pickup.SetAutoHoldMode(Tweaker_Object.GetGameObjectToEdit(), VRC_Pickup.AutoHoldMode.No); }), "", null, null, true);
			InitProximitySliderSubmenu(PickupEditor, 3, 0, true);
			Pickup_allowManipulationWhenEquipped = new QMToggleButton(PickupEditor, 4, 0, "Allow Manipulation Equip", new Action(() => { Pickup.SetallowManipulationWhenEquipped(Tweaker_Object.GetGameObjectToEdit(), true); }), "Disallow Manipulation Equip", new Action(() => { Pickup.SetallowManipulationWhenEquipped(Tweaker_Object.GetGameObjectToEdit(), false); }), "Control Manipulation Equip property", null, null, null);
			Pickup_pickupable = new QMToggleButton(PickupEditor, 4, 1, "Pickupable", new Action(() => { Pickup.SetPickupable(Tweaker_Object.GetGameObjectToEdit(), true); }), "Not Pickupable", new Action(() => { Pickup.SetPickupable(Tweaker_Object.GetGameObjectToEdit(), false); }), "Control Pickupable Property", null, null, null);
			Pickup_DisallowTheft = new QMToggleButton(PickupEditor, 4, 2, "Allow Theft", new Action(() => { Pickup.SetDisallowTheft(Tweaker_Object.GetGameObjectToEdit(), true); }), "Block Theft", new Action(() => { Pickup.SetDisallowTheft(Tweaker_Object.GetGameObjectToEdit(), false); }), "Control DisallowTheft property", null, null, null);
		}

		public static void InitProximitySliderSubmenu(QMNestedButton menu, float x, float y, bool btnHalf)
		{
			var slider = new QMNestedButton(menu, x, y, "Proximity", "Value Slider Editor!", null, null, null, null, btnHalf);
			PickupProximitySlider = new QMSlider(Utils.QuickMenu.transform.Find(slider.getMenuName()), "Proximity : ", 250, -720, delegate (float value)
{
	Pickup.SetProximity(Tweaker_Object.GetGameObjectToEdit(), (int)value);
}, 5, 1000, 0, true);
			PickupProximitySlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
		}

		public static void SetActiveButtonStatus(GameObject obj)
		{
			if (obj != null)
			{
				if (ObjectActiveToggle != null)
				{
					ObjectActiveToggle.setToggleState(obj.active);
				}
			}
		}

		public static QMToggleButton CurrentObjectGravity;
		public static QMSlider ForceSlider;
		public static QMSlider SpinForceSlider;
		public static QMSlider ScaleSlider;
		public static QMSingleButton TeleportToTargetPickup;
		public static QMSingleButton TeleportToMePickup;
		public static QMSingleButton SubMenuTeleportToMe;
		public static QMSingleButton SubMenuTeleportToTarget;

		public static QMSingleButton SpawnedPickupsCounter;
		public static QMSingleButton SpawnedPrefabsCounter;

		public static QMSingleToggleButton ProtectionInteractor;

		public static List<GameObject> WorldObjects = new List<GameObject>();

		public static QMSingleButton Object_no_Gravity;
		public static QMSingleButton Object_Gravity;

		public static QMSingleButton HasPickupComponent;

		public static QMSingleButton Pickup_PickupOrientation_prop_any;
		public static QMSingleButton Pickup_PickupOrientation_prop_Grip;
		public static QMSingleButton Pickup_PickupOrientation_prop_Gun;

		public static QMSingleButton Pickup_AutoHoldMode_prop_AutoDetect;
		public static QMSingleButton Pickup_AutoHoldMode_prop_Yes;
		public static QMSingleButton Pickup_AutoHoldMode_prop_No;

		public static QMToggleButton Pickup_allowManipulationWhenEquipped;
		public static QMToggleButton Pickup_pickupable;
		public static QMToggleButton Pickup_DisallowTheft;

		public static QMSingleButton Pickup_IsEditMode;
		public static QMSingleButton Pickup_IsHeld;
		public static QMSingleButton Pickup_CurrentObjOwner;
		public static QMSingleButton Pickup_CurrentObjHolder;

		public static QMSingleButton SelPickup_IsHeld;
		public static QMSingleButton SelPickup_CurrentObjOwner;
		public static QMSingleButton SelPickup_CurrentObjHolder;

		public static QMSingleButton SelWorld_IsHeld;
		public static QMSingleButton SelWorld_CurrentObjOwner;
		public static QMSingleButton SelWorld_CurrentObjHolder;

		public static QMSingleButton SelWorld_TeleportToTargetPickup;
		public static QMSingleButton SelWorld_TeleportToMePickup;

		public static QMSingleButton Main_CurrentObjOwner;
		public static QMSingleButton Main_CurrentObjHolder;

		public static QMSingleButton Forces_Pickup_IsHeld;
		public static QMSingleButton Forces_SelPickup_CurrentObjOwner;
		public static QMSingleButton Forces_CurrentObjHolder;

		public static QMSingleButton CurrentObjectCoordsBtn;

		public static QMSlider PickupProximitySlider;

		public static QMSingleToggleButton ObjectActiveToggle;
	}
}