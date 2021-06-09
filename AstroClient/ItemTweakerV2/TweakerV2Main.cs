namespace AstroClient.ItemTweakerV2
{
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Handlers;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus;
	using AstroClient.ItemTweakerV2.Submenus.ScrollMenus;
	using AstroClient.variables;
	using AstroLibrary;
	using RubyButtonAPI;
	using System;
	using System.Reflection;
	using UnityEngine;
	using Color = UnityEngine.Color;
	using AstroLibrary.Extensions;
	using VRC;

	public class TweakerV2Main : Tweaker_Events
	{
		public static void Init_TweakerV2Main()
		{
			QMTabMenu menu = new QMTabMenu(3f, "Item Tweaker", null, null, null, CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.box.png"));
			PhysicsSubmenu.Init_PhysicSubMenu(menu, 2, 0, true);
			PickupSubmenu.Init_PickupSubMenu(menu, 2, 0.5f, true);
			ScaleSubmenu.Init_ScaleSubMenu(menu, 2, 1, true);



			GameObjMenu.InitTogglerMenu(menu, 3, 0f, true);
			ObjectInfoSubMenu.Init_ObjectInfoSubMenu(menu, 3, 0.5f, true);
			new QMSingleButton(menu, 3, 1f, "Teleport to Object", new Action(() => { GameObjectUtils.TeleportPlayerToPickup(Tweaker_Object.GetGameObjectToEdit()); }), "Teleport to object.", null, null, true);
			new QMSingleButton(menu, 3, 1.5f, "Respawn Object", new Action(() => { GameObjectUtils.RestoreOriginalLocation(Tweaker_Object.GetGameObjectToEdit(), false); }), "Reset Object Position.", null, null, true);
			PickupSelectionScrollMenu.Init_PickupSelectionQMScroll(menu, 3, 2, true);
			WorldObjectsScrollMenu.Init_WorldObjectScrollMenu(menu, 3, 2.5f, true);
			VRC_TriggersScrollMenu.Init_VRC_TriggersScrollMenu(menu, 4, 0, true);
			VRC_InteractableScrollMenu.Init_VRC_InteractableScrollMenu(menu, 4, 0.5f, true);
			if (Bools.IsDeveloper)
			{
				UdonScrollMenu.Init_Internal_UdonEvents(menu, 4, 1, true);
			}

			ComponentSubMenu.Init_ComponentSubMenu(menu, 4, 1.5f, true);
			SpawnerSubmenu.Init_SpawnerSubmenu(menu, 4, 2f, true);

			ObjectActiveToggle = new QMSingleToggleButton(menu, 1, 1.5f, "Enabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(true); }, "Disabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(false); }, "Toggles SetActive", Color.green, Color.red, null, false, true);
			new QMSingleToggleButton(menu, 2, 1.5f, "Selected Item ESP : ON", () => { EspHandler.TweakerESPEnabled = true; }, "Selected Item ESP : OFF", () => { EspHandler.TweakerESPEnabled = false; }, "Toggles Selected item ESP", Color.green, Color.red, null, false, true).SetResizeTextForBestFit(true);
			LockHoldItem = new QMSingleToggleButton(menu, 2, 2.5f, "Lock ON", () => { Tweaker_Object.LockItem = true; }, "Lock OFF", () => { Tweaker_Object.LockItem = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)", Color.green, Color.red, null, false, true);
			ObjectToEditBtn = new QMSingleButton(menu, 1, 2f, "None", new Action(() => { Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", null, null);

			// TODO: remake teleport buttons <3
			TeleportToMe = new QMSingleButton(menu, -1, 1.5f, Button_strings_ext.Generate_TeleportToMe_ButtonText(null), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }), Button_strings_ext.Generate_TeleportToMe_ButtonText(null), null, null);
			TeleportToMe.SetResizeTextForBestFit(true);

			TeleportToTarget = new QMSingleButton(menu, -1, 2.5f, Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }), Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), null, null);
			TeleportToTarget.SetResizeTextForBestFit(true);

			new QMSingleButton(menu, 6, 2f, "DANGER : Destroy item.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DestroyObject(); }), "Destroys Object , You need to reload the world to restore it back.", null, Color.red, true);

			ProtectionInteractor = new QMSingleToggleButton(menu, 6, 1, "Interaction block ON", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_PreventOthersFromGrabbing(true); }, "Interaction block OFF", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_PreventOthersFromGrabbing(false); }, "Prevents Others from interacting with the object", Color.green, Color.red, null, false, true);
			new QMSingleButton(menu, 6, 1.5f, "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().TakeOwnership(); }), "Make Whatever Player, drop the object.", null, Color.cyan, true);


		}

		public override void On_New_GameObject_Selected(GameObject obj)
		{
			UpdateCapturedObject(obj);
			if (TeleportToTarget != null)
			{
				TeleportToTarget.SetButtonText(Button_strings_ext.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
				TeleportToTarget.SetToolTip(Button_strings_ext.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
			}
			if (TeleportToMe != null)
			{
				TeleportToMe.SetButtonText(obj.Generate_TeleportToMe_ButtonText());
				TeleportToMe.SetToolTip(obj.Generate_TeleportToMe_ButtonText());
			}
		}



		public override void OnSelectedObject_Enabled()
		{
			ObjectActiveToggle.SetToggleState(true);
		}

		public override void OnSelectedObject_Disabled()
		{
			ObjectActiveToggle.SetToggleState(false);
		}

		public override void OnTargetSet(Player player)
		{
			if (TeleportToTarget != null)
			{
				TeleportToTarget.SetButtonText(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
				TeleportToTarget.SetToolTip(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
			}

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

		public static QMSingleButton TeleportToMe;

		public static QMSingleButton TeleportToTarget;


		public static QMSingleToggleButton LockHoldItem;
		public static QMSingleButton ObjectToEditBtn;
		public static QMSingleToggleButton ObjectActiveToggle;
		public static QMSingleToggleButton ProtectionInteractor;




	}
}