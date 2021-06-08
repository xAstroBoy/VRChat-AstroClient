namespace AstroClient.ItemTweakerV2
{
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Handlers;
	using AstroClient.ItemTweakerV2.Submenus;
	using AstroClient.ItemTweakerV2.Submenus.ScrollMenus;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.variables;
	using AstroLibrary;
	using RubyButtonAPI;
	using System;
	using System.Reflection;
	using UnityEngine;
	using Color = UnityEngine.Color;

	public class TweakerV2Main : Tweaker_Events
	{
		public static void Init_TweakerV2Main()
		{
			QMTabMenu menu = new QMTabMenu(3f, "Item Tweaker", null, null, null, CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.box.png"));

			GameObjMenu.InitTogglerMenu(menu, -1, -1.5f, true);
			ObjectToEditBtn = new QMSingleButton(menu, -1, -1f, "None", new Action(() => { Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", null, null);

			ObjectActiveToggle = new QMSingleToggleButton(menu, -1, 0f, "Enabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(true); }, "Disabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(false); }, "Toggles SetActive", Color.green, Color.red, null, false, true);
			// TODO: remake teleport buttons <3
			//SubMenuTeleportToMe = new QMSingleButton(menu, -1, 1.5f, GetTeleportToMeBtnText, new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }), GetTeleportToMeBtnText, null, null);
			//SubMenuTeleportToMe.SetResizeTextForBestFit(true);

			//SubMenuTeleportToTarget = new QMSingleButton(menu, -1, 2.5f, GetTeleportToTargetText, new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }), GetTeleportToTargetText, null, null);
			//SubMenuTeleportToTarget.SetResizeTextForBestFit(true);

			new QMSingleButton(menu, 2, 1.5f, "Restore Rigidbody", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RigidBody_RestoreOriginalBody(); }), "Restore Default RigidBody Config.", null, null, true);
			new QMSingleButton(menu, 1, 1.5f, "Remove Add-ons", () => { ComponentSubMenu.KillCustomComponents(); }, "Kill All Custom Add-ons.", null, null, true);
			new QMSingleButton(menu, 2, 2f, "Teleport to Object", new Action(() => { GameObjectUtils.TeleportPlayerToPickup(Tweaker_Object.GetGameObjectToEdit()); }), "Teleport to object.", null, null, true);
			new QMSingleButton(menu, 2, 2.5f, "Respawn Object", new Action(() => { GameObjectUtils.RestoreOriginalLocation(Tweaker_Object.GetGameObjectToEdit(), false); }), "Reset Object Position.", null, null, true);

			PhysicsSubmenu.Init_PhysicSubMenu(menu, 2, 0, true);
			PickupSubmenu.Init_PickupSubMenu(menu, 2, 1, true);

			////Goes in SpawnSubmenu

			new QMSingleButton(menu, 3, 0, "Spawn Clone", new Action(() => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }), "Instantiates a copy of The selected object.", null, null, true);
			new QMSingleButton(menu, 3, 0.5f, "Kill Clones", new Action(() => { Cloner.ObjectCloner.ClonedObjectsDeleter(); }), "Removes All Cloned Objects.", null, null, true);

			ScaleSubmenu.Init_ScaleSubMenu(menu, 1, 1, true);

			var tmp = new QMSingleToggleButton(menu, 1, 2, "Selected Item ESP : ON", () => { EspHandler.TweakerESPEnabled = true; }, "Selected Item ESP : OFF", () => { EspHandler.TweakerESPEnabled = false; }, "Toggles Selected item ESP", Color.green, Color.red, null, false, true); tmp.SetResizeTextForBestFit(true);

			LockHoldItem = new QMSingleToggleButton(menu, 1, 2.5f, "Lock ON", () => { Tweaker_Object.LockItem = true; }, "Lock OFF", () => { Tweaker_Object.LockItem = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)", Color.green, Color.red, null, false, true); 
            PickupSelectionScrollMenu.Init_PickupSelectionQMScroll(menu, 3, 2, true);
			WorldObjectsScrollMenu.Init_WorldObjectScrollMenu(menu, 3, 2.5f, true);
			VRC_TriggersScrollMenu.Init_VRC_TriggersScrollMenu(menu, 4, 2, true);
			VRC_InteractableScrollMenu.Init_VRC_InteractableScrollMenu(menu, 4, 2.5f, true);
			if (Bools.IsDeveloper)
			{
				UdonScrollMenu.Init_Internal_UdonEvents(menu, 5, 2, true);
			}

			//Goes in ObjectInfo Submenu
			//CurrentObjectCoordsBtn = new QMSingleButton(menu, 5, -1, "", null, "Shows Object Coords", null, null, false);
			//CurrentObjectCoordsBtn.GetGameObject().GetComponent<UnityEngine.UI.Image>().enabled = false;
			//CurrentObjectCoordsBtn.SetResizeTextForBestFit(true);

			new QMSingleButton(menu, 6, -2f, "Copy Local Position.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyLocalPosition(); }), "Copies Object Current Local Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 6, -1.5f, "Copy Position.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyPosition(); }), "Copies Object Current Position in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 6, -1f, "Copy Rotation.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyRotation(); }), "Copies Object Current Rotation in clipboard.", null, Color.yellow, true);
			new QMSingleButton(menu, 6, -0.5f, "Copy Object Path.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().CopyPath(); }), "Copies Object Current Path in clipboard.", null, Color.yellow, true);

			new QMSingleButton(menu, 6, 2f, "DANGER : Destroy item.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DestroyObject(); }), "Destroys Object , You need to reload the world to restore it back.", null, Color.red, true);
			//SpawnedPickupsCounter = new QMSingleButton(menu, 6, 0, GetClonesPickupText, null, GetClonesPickupText, null, Color.cyan, true);
			//SpawnedPrefabsCounter = new QMSingleButton(menu, 6, 0.5f, GetSpawnedPrefabText, null, GetSpawnedPrefabText, null, Color.cyan, true);
			ProtectionInteractor = new QMSingleToggleButton(menu, 6, 1, "Interaction block ON", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_PreventOthersFromGrabbing(true); }, "Interaction block OFF", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_PreventOthersFromGrabbing(false); }, "Prevents Others from interacting with the object", Color.green, Color.red, null, false, true); 
			// Goes in PhysicsSubmenu
			ForcesSubmenu.Init_ForceSubMenu(menu, 4, 0, true);

			//Goes in Components Submenu

			RocketComponentSubMenu.Init_RocketComponentSubMenu(menu, 4, 0.5f, true);
			CrazyComponentSubMenu.Init_CrazyComponentSubMenu(menu, 4, 1f, true);
			SpinnerSubMenu.Init_SpinnerSubMenu(menu, 4, 1.5f, true);
			//Goes in spawner

			PrefabSpawnerScrollMenu.Init_PrefabSpawnerQMScroll(menu, 3, 1f, true);
			new QMSingleButton(menu, 3, 1.5f, "Kill Spawned Prefabs", new Action(() => { SpawnerSubmenu.KillSpawnedPrefabs(); }), "Removes All Prefabs Objects.", null, null, true);

			//Goes in ColliderEditor
			new QMSingleButton(menu, 5, 0.5f, "Activates all Colliders", new Action(() => { Tweaker_Object.GetGameObjectToEdit().EnableColliders(); }), "Enables all colliders bound to the object", null, null, true);
			new QMSingleButton(menu, 5, 1f, "Add Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);
			new QMSingleButton(menu, 5, 1.5f, "Add Trigger Collider", new Action(() => { Tweaker_Object.GetGameObjectToEdit().AddTriggerCollider(); }), "Adds A Collider to the object (use it in case it doesn't have any!)", null, null, true);

			new QMSingleButton(menu, 6, 1.5f, "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().TakeOwnership(); }), "Make Whatever Player, drop the object.", null, Color.cyan, true);
		}

		public override void On_New_GameObject_Selected(GameObject obj)
		{
			UpdateCapturedObject(obj);
		}

		public override void OnSelectedObject_Enabled()
		{
			ObjectActiveToggle.SetToggleState(true);
		}

		public override void OnSelectedObject_Disabled()
		{
			ObjectActiveToggle.SetToggleState(false);
		}

		public override void OnSelectedObject_Destroyed()
		{
			Reset();
		}

		public override void OnLevelLoaded()
		{
			Reset();
		}

		public static void Reset()
		{
			Tweaker_Object.LockItem = false;
			Tweaker_Selector.SelectedObject = null;
		}

		public static void UpdateCapturedObject(GameObject obj)
		{
			if (obj != null)
			{
				if (ObjectToEditBtn != null)
				{
					ObjectToEditBtn.SetButtonText("Editing: " + obj.name);
					ObjectToEditBtn.SetToolTip("Editing: " + obj.name);
					ObjectToEditBtn.SetTextColor(obj.Get_GameObject_Active_ToColor());
				}
				if (GameObjMenu.GameObjMenuObjectToEdit != null)
				{
					GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Editing: " + obj.name);
					GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Editing: " + obj.name);
					GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(obj.Get_GameObject_Active_ToColor());
				}
			}
			else
			{
				if (ObjectToEditBtn != null)
				{
					ObjectToEditBtn.SetButtonText("Pick a Gameobject to start!");
					ObjectToEditBtn.SetToolTip("Pick a Gameobject to start!");
					ObjectToEditBtn.SetTextColor(Color.white);

				}
				if (GameObjMenu.GameObjMenuObjectToEdit != null)
				{
					GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Pick a Gameobject to start!");
					GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Pick a Gameobject to start!");
					GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.white);
				}
			}
		}


		public static QMSingleToggleButton LockHoldItem;
		public static QMSingleButton ObjectToEditBtn;
		public static QMSingleToggleButton ObjectActiveToggle;
		public static QMSingleToggleButton ProtectionInteractor;

	}
}