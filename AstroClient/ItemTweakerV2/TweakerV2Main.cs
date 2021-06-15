namespace AstroClient.ItemTweakerV2
{
	using AstroClient.Components;
	using AstroClient.GameObjectDebug;
	using AstroClient.ItemTweakerV2.Handlers;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroClient.ItemTweakerV2.Submenus;
	using AstroClient.ItemTweakerV2.Submenus.ScrollMenus;
	using AstroClient.Variables;
	using AstroLibrary;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Reflection;
	using UnityEngine;
	using VRC;
	using Color = UnityEngine.Color;

	public class TweakerV2Main : Tweaker_Events
    {
        public static void Init_TweakerV2Main()
        {
            QMTabMenu menu = new QMTabMenu(3f, "Item Tweaker", null, null, null, CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.box.png"));

            // Outside Area

            Pickup_IsHeldStatus = new QMSingleButton(menu, -1, -1f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

            Pickup_CurrentObjectHolder = new QMSingleButton(menu, -1, -0.5f, "Current holder : null", null, "Who is the current object Holder.", null, null, false);
            Pickup_CurrentObjectHolder.SetResizeTextForBestFit(true);

            Pickup_CurrentObjectOwner = new QMSingleButton(menu, -1, 0.5f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
            Pickup_CurrentObjectOwner.SetResizeTextForBestFit(true);

            TeleportToMe = new QMSingleButton(menu, -1, 1.5f, Button_strings_ext.Generate_TeleportToMe_ButtonText(null), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToMe(); }), Button_strings_ext.Generate_TeleportToMe_ButtonText(null), null, null);
            TeleportToMe.SetResizeTextForBestFit(true);

            TeleportToTarget = new QMSingleButton(menu, -1, 2.5f, Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), new Action(() => { Tweaker_Object.GetGameObjectToEdit().TeleportToTarget(); }), Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, TargetSelector.CurrentTarget), null, null);
            TeleportToTarget.SetResizeTextForBestFit(true);

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

            new QMSingleButton(menu, 1, 0.5f, "Drop Object", new Action(() => { Tweaker_Object.GetGameObjectToEdit().TakeOwnership(); }), "Make Whatever Player, drop the object.", null, Color.cyan, true);
            ProtectionInteractor = new QMSingleToggleButton(menu, 1, 1, "Interaction block ON", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_PreventOthersFromGrabbing(true); }, "Interaction block OFF", () => { Tweaker_Object.GetGameObjectToEdit().RigidBody_PreventOthersFromGrabbing(false); }, "Prevents Others from interacting with the object", Color.green, Color.red, null, false, true);
            ObjectActiveToggle = new QMSingleToggleButton(menu, 1, 1.5f, "Enabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(true); }, "Disabled", () => { Tweaker_Object.GetGameObjectToEdit().SetActive(false); }, "Toggles SetActive", Color.green, Color.red, null, false, true);
            new QMSingleToggleButton(menu, 2, 1.5f, "Selected Item ESP : ON", () => { EspHandler.TweakerESPEnabled = true; }, "Selected Item ESP : OFF", () => { EspHandler.TweakerESPEnabled = false; }, "Toggles Selected item ESP", Color.green, Color.red, null, false, true).SetResizeTextForBestFit(true);
            LockHoldItem = new QMSingleToggleButton(menu, 2, 2.5f, "Lock ON", () => { Tweaker_Object.LockItem = true; }, "Lock OFF", () => { Tweaker_Object.LockItem = false; }, "Lock the Held object (prevents the mod from grabbing a new holding object)", Color.green, Color.red, null, false, true);
            ObjectToEditBtn = new QMSingleButton(menu, 1, 2f, "None", new Action(() => { Tweaker_Object.GetGameObjectToEdit(); }), "GameObject To Edit", null, null);

            // TODO: remake teleport buttons <3

            new QMSingleButton(menu, 5, -0.5f, "DANGER : Destroy item.", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DestroyObject(); }), "Destroys Object , You need to reload the world to restore it back.", null, Color.red, true);
        }

        public override void OnPickupController_OnUpdate(PickupController control)
        {
            if (control != null)
            {
                if (Pickup_IsHeldStatus != null)
                {
                    Pickup_IsHeldStatus.SetButtonText(control.Get_IsHeld_ButtonText());
                    Pickup_IsHeldStatus.SetTextColor(control.Get_IsHeld_ButtonColor());
                }
                if (Pickup_CurrentObjectOwner != null)
                {
                    Pickup_CurrentObjectOwner.SetButtonText(control.Get_PickupOwner_ButtonText());
                }
                if (Pickup_CurrentObjectHolder != null)
                {
                    Pickup_CurrentObjectHolder.SetButtonText(control.Get_IsHeldBy_ButtonText());
                }
            }
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

        public override void OnTargetSet(Player player)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
                TeleportToTarget.SetToolTip(Button_strings_ext.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.Component_Get_SelectedObject, player));
            }
        }

        public override void OnSelectedObject_Enabled()
        {
            ObjectActiveToggle.SetToggleState(true);
            if (ObjectToEditBtn != null)
            {
                ObjectToEditBtn.SetTextColor(Color.green);
            }
            if (GameObjMenu.GameObjMenuObjectToEdit != null)
            {
                GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.green);
            }
        }

        public override void OnSelectedObject_Disabled()
        {
            ObjectActiveToggle.SetToggleState(false);
            if (ObjectToEditBtn != null)
            {
                ObjectToEditBtn.SetTextColor(Color.red);
            }
            if (GameObjMenu.GameObjMenuObjectToEdit != null)
            {
                GameObjMenu.GameObjMenuObjectToEdit.SetTextColor(Color.red);
            }
        }

        public override void OnSelectedObject_Destroyed()
        {
            Reset();
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
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
                }
                if (GameObjMenu.GameObjMenuObjectToEdit != null)
                {
                    GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Editing: " + obj.name);
                    GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Editing: " + obj.name);
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

        private static QMSingleButton Pickup_IsHeldStatus { get; set; }
        private static QMSingleButton Pickup_CurrentObjectHolder { get; set; }
        private static QMSingleButton Pickup_CurrentObjectOwner { get; set; }
    }
}